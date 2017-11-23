namespace TowerDefense{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.AI;

	public class Tower : MonoBehaviour {

		#region Variables
		[Header("Type of Tower")]
		public bool gunTower;
		public bool bombTower;
		public bool airTower;
		public bool slowTower;
		[Header("The parts of the turret.")]
		public GameObject turret;
		public GameObject turretEnd;
		public GameObject turretEndTwo;
		public Animator turretOneAnimator;
		public Animator turretTwoAnimator;
		public GameObject blankGunSpot;
		public GameObject upgradeGun;
		[Header("Tower Ammo")]
		public GameObject missilePrefab;
		public GameObject bombPrefab;
		public GameObject bombUpgradePrefab;
		public GameObject slowPrefab;
		public GameObject slowUpgradePrefab;
		[Header("Visual FX")]
		public GameObject gunfire;
		public GameObject upgradeFX;
		[Header("Targets")]
		public GameObject target;
		public GameObject lookAt;
		private Vector3 targetPosition;
		private Vector3 lookAtPosition;
		public GameObject parentBlock;
		[HideInInspector]
		public bool upgraded;
		[HideInInspector]
		public int level = 1;
		//rate of fire
		[Header("Delay Between Shots")]
		[Tooltip("Delay time between shots.")]
		public float fireSpeed;
		[Tooltip("Distance between tower and mob before new target search.")]
		public int targetDistance = 12;
		public float aggroRange = 14;
		//last shot for rate of fire
		private float lastShot = 0;
		//turret rotation items
		private Vector3 targetTurretTransform;
		private Quaternion rot;
		//public bool hasTarget;
		int layerMask;
		bool isRunning = true;
		TowerHealth towerHealth;
		#endregion

		void Start(){
			towerHealth = GetComponent<TowerHealth> ();
			turret.transform.Rotate (0, Random.Range (0, 361), 0);
			RandomROF ();
			//ground are 8, air are 9
			if(airTower==true){
				layerMask=1<<9;
			}else{
				layerMask = 1 << 8;
			}
			StartCoroutine (GetNewTarget ());
		}

		void RandomROF(){
			var rand = Random.Range (0f, 20f);
			rand *= 0.01f;
			fireSpeed += rand;
		}
			
		IEnumerator GetNewTarget(){
			while(isRunning==true){
				if (!target){
					Collider[] mobs = Physics.OverlapSphere (transform.position, aggroRange, layerMask);
					if (mobs.Length >= 1){
						var randomTarget = Random.Range (0, mobs.Length);
						if (mobs [randomTarget]){
							target = mobs [randomTarget].gameObject;
							if(lookAt){
								lookAt = null;
							}
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

		void Update(){
			if (target){
				FireDelay ();
			}
		}

		//rotates turret to face target
		void FixedUpdate(){
			if (target){
				targetTurretTransform = target.transform.position - turret.transform.position;
				targetTurretTransform.y = 0;
				rot = Quaternion.LookRotation (targetTurretTransform);
				turret.transform.rotation = Quaternion.Slerp (turret.transform.rotation, rot, 0.1f);
			}else{
				if(lookAt){
					targetTurretTransform = lookAt.transform.position - turret.transform.position;
					targetTurretTransform.y = 0;
					rot = Quaternion.LookRotation (targetTurretTransform);
					turret.transform.rotation = Quaternion.Slerp (turret.transform.rotation, rot, 0.1f);
				}
			}
		}

		//controls rate of fire
		void FireDelay(){
			if (Time.time > lastShot + fireSpeed){
				if (target){
					Fire ();
				}
			}
		}

		public void Upgrade(){
			level++;
			towerHealth.UpgradeTowerHealth (level);
			if (!upgraded) {
				upgraded = true;
				blankGunSpot.SetActive (false);
				upgradeGun.SetActive (true);
				ObjectPool.Instantiate (upgradeFX, blankGunSpot.transform.position, transform.rotation);
			}else{
				fireSpeed -= 0.2f;
			}
		}

		void MuzzleFlash(GameObject location, float rotate){
			var muzzleFlashObject = ObjectPool.Instantiate(gunfire, location.transform.position, location.transform.rotation, location.transform);
			muzzleFlashObject.transform.Rotate (0f, rotate, 0f);
		}

		void Fire(){
			if(gunTower == true){
				lastShot = Time.time;
				if(target){
					if (turretOneAnimator) {
						turretOneAnimator.SetTrigger ("Shoot");
					}
					if(gunfire){
						MuzzleFlash (turretEnd, 180f);
					}
					var health = target.GetComponentInParent<MobHealth> ();
					health.Hit ();
					if(upgraded==true){
						health.Hit ();
						if (turretTwoAnimator) {
							turretTwoAnimator.SetTrigger ("Shoot");
						}
						if(gunfire){
							MuzzleFlash (turretEndTwo, 180f);
						}
					}
				}
			}else if(airTower==true){
				var bullet = ObjectPool.Instantiate (missilePrefab, turretEnd.transform.position, turretEnd.transform.rotation);
				bullet.GetComponent<Missile> ().target = target.transform;
				bullet.transform.LookAt (target.transform.position);
				lastShot = Time.time;
				MuzzleFlash (turretEnd, 90f);
				if (upgraded == true){
					var bulletTwo = ObjectPool.Instantiate (missilePrefab, turretEndTwo.transform.position, turretEndTwo.transform.rotation);
					bulletTwo.GetComponent<Missile> ().target = target.transform;
					bulletTwo.transform.LookAt (target.transform.position);
					MuzzleFlash (turretEndTwo, -90f);
				}
			}else if(bombTower==true){
				if (upgraded == false){
					var targetVector = target.transform.position;
					var bomb = ObjectPool.Instantiate (bombPrefab, turretEnd.transform.position, Quaternion.identity);
					bomb.GetComponent<Bomb> ().exploded = false;
					bomb.GetComponent<Bomb> ().target = targetVector;
					lastShot = Time.time;
					ObjectPool.Instantiate (gunfire, turretEnd.transform.position, turretEnd.transform.rotation, turretEnd.transform);
				}else if(upgraded==true){
					var targetVector = target.transform.position;
					var bomb = ObjectPool.Instantiate (bombUpgradePrefab, turretEnd.transform.position, Quaternion.identity);
					bomb.GetComponent<Bomb> ().exploded = false;
					bomb.GetComponent<Bomb> ().target = targetVector;
					lastShot = Time.time;
					ObjectPool.Instantiate (gunfire, turretEndTwo.transform.position, turretEndTwo.transform.rotation, turretEndTwo.transform);
				}
			}else if(slowTower==true){
				if (upgraded == false){
					var targetVector = target.transform.position;
					var slow = ObjectPool.Instantiate (slowPrefab, turretEnd.transform.position, Quaternion.identity);
					slow.GetComponent<SlowBomb> ().exploded = false;
					slow.GetComponent<SlowBomb> ().target = targetVector;
					lastShot = Time.time;
					ObjectPool.Instantiate (gunfire, turretEnd.transform.position, turretEnd.transform.rotation, turretEnd.transform);
				}else if (upgraded == true)	{
					var targetVector = target.transform.position;
					var slow = ObjectPool.Instantiate (slowUpgradePrefab, turretEnd.transform.position, Quaternion.identity);
					slow.GetComponent<SlowBomb> ().exploded = false;
					slow.GetComponent<SlowBomb> ().target = targetVector;
					lastShot = Time.time;
					ObjectPool.Instantiate (gunfire, turretEndTwo.transform.position, turretEndTwo.transform.rotation, turretEndTwo.transform);
				}
			}
		}
	}
}