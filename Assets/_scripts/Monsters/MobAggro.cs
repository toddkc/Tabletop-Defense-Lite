namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.AI;
	using System.Collections;

	public class MobAggro : MonoBehaviour {

		public GameObject turret, gunfire, turretEnd1, turretEnd2;
		public Animator gunAnimator1, gunAnimator2, bodyAnimator;
		[Header("Is this a boss mob?")]
		public bool boss;
		public float fireSpeed = 2.0f;
		float lastShot, timeSlowed, fireSpeedResume;
		[HideInInspector]
		public GameObject target;
		bool isRunning, gemTargeted, stopped, upgraded, slowed;
		int layerMask;
		Vector3 targetTurretTransform;
		Quaternion rot;
		MobNavigation mobNav;
		MobHealth health;
		public int targetDistance = 1;
		int mobLevel=1;
		public void AggroStart(){
			RandomROF ();
			isRunning = true;
			layerMask = 1 << 13;
			health = GetComponentInParent<MobHealth> ();
			mobLevel = health.mobLevel;
			if(health.upgraded==true){
				upgraded = true;
				fireSpeed -= 1.0f;
			}else{
				upgraded = false;
			}
			mobNav = GetComponentInParent<MobNavigation> ();
			mobNav.mobAggro = this;
			StartCoroutine (GetNewTarget ());
		}

		void RandomROF(){
			var rand = Random.Range (0f, 20f);
			rand *= 0.01f;
			fireSpeed += rand;
		}

		IEnumerator GetNewTarget()
		{
			while (isRunning == true)
			{
				if (!target)
				{
					Collider[] towers = Physics.OverlapSphere (transform.position, 14.0f, layerMask);

					if (towers.Length >= 1) 
					{
						var randomTarget = Random.Range (0, towers.Length);
						if (towers [randomTarget]) 
						{
							target = towers [randomTarget].gameObject;
						}
					}
				}else{
					if(Vector3.Distance(transform.position, target.transform.position)>targetDistance){
						target = null;
					}
				}
				yield return new WaitForSeconds (1.0f);
			}
		}

		void ResumeSpeed(){
			slowed = false;
			fireSpeed = fireSpeedResume;
		}
		public void SlowEffect(){
			if (slowed == false) {
				timeSlowed = Time.time;
				slowed = true;
				fireSpeedResume = fireSpeed;
				fireSpeed *= 2.0f;
			}
		}
			
		void Update()
		{
			if (target) {
				FireDelay ();
			}
			if (slowed==true)
			{
				if(Time.time>timeSlowed + 5.0f)
				{
					ResumeSpeed ();
				}
			}
		}

		void FixedUpdate()
		{
			if (target) 
			{
				FollowTarget ();
			}else{
				CenterRotation ();
			}

			if (gemTargeted == true && stopped==false) 
			{
				if (target) {
					if (Vector3.Distance (target.transform.position, transform.position) < 10) {
						Stop ();
					}
				}
			}
		}

		void FollowTarget(){
			var targetpos = target.transform.position;
			targetTurretTransform = targetpos - turret.transform.position;
			targetTurretTransform.y = 0;
			rot = Quaternion.LookRotation (targetTurretTransform);
			turret.transform.rotation = Quaternion.Slerp (turret.transform.rotation, rot, 0.1f);
		}

		void CenterRotation(){
			turret.transform.localRotation = Quaternion.Slerp (turret.transform.localRotation, Quaternion.identity, 0.1f);
		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.tag == "Gem") {
				if (stopped == false && gemTargeted==false) {
					if (mobNav.agent) {
						var distance = mobNav.agent.remainingDistance;
						if (distance < 12) {
							StopAllCoroutines ();
							isRunning = false;
							gemTargeted = true;
							target = coll.gameObject;
						}
					}
				}
			}
		}
			
		void Stop(){
			stopped = true;
			mobNav.agent.Stop ();
			if (bodyAnimator) {
				bodyAnimator.SetTrigger ("Stop");
			}
		}

		void FireDelay()
		{
			if (Time.time > lastShot + fireSpeed) 
			{
				if (target) {
					Fire ();
				}
			}
		}

		void MuzzleFlash(GameObject location){
			var muzzleFlashObject = ObjectPool.Instantiate(gunfire, location.transform.position, location.transform.rotation, location.transform);
			muzzleFlashObject.transform.Rotate (0f, 180f, 0f);
		}

		void Fire()
		{
			lastShot = Time.time;
			if (gunAnimator1) {
				gunAnimator1.SetTrigger ("Shoot");
			}
			if(gunAnimator2){
				gunAnimator2.SetTrigger ("Shoot");
			}
			if (turretEnd1) {
				MuzzleFlash (turretEnd1);
			}
			if (turretEnd2) {
				MuzzleFlash (turretEnd2);
			}
			if(target) {
				if (target.tag == "Tower") {
					var tower = target.GetComponentInParent<TowerHealth> ();
					//add hits based on level
					tower.Hit (mobLevel);
				}
				if(target.tag=="Gem"){
					var gem = target.GetComponent<Gem> ();
					gem.Hit ();
					if (upgraded == true || boss == true) {
						gem.Hit ();
					}

				}
			}
		}
	}
}