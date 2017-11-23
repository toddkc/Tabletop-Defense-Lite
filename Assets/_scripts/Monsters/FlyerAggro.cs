namespace TowerDefense{
	using UnityEngine;
	using System.Collections;

	public class FlyerAggro : MonoBehaviour {

		public float fireSpeed = 2.0f;
		public GameObject bombPrefab;
		public Vector3 sphereOffset;
		float lastShot;
		[HideInInspector]
		public GameObject target;
		bool isRunning, upgraded;
		public LayerMask layerMask;
		int mobLevel = 1;
		MobHealth health;

		void Start(){
			RandomROF ();
			isRunning = true;
			health = GetComponentInParent<MobHealth> ();
			mobLevel = health.mobLevel;
			if(health.upgraded==true){
				upgraded = true;
				fireSpeed -= 1.0f;
			}else{
				upgraded = false;
			}
			StartCoroutine (GetNewTarget ());
		}

		void Update()
		{
			if (target) {
				FireDelay ();
			}
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
				target = null;
				Collider[] towers = Physics.OverlapSphere (transform.position-sphereOffset, 20.0f, layerMask);

				if (towers.Length >= 1) {
					var randomTarget = Random.Range (0, towers.Length);
					if (towers [randomTarget]) {
						target = towers [randomTarget].gameObject;
					}
				}
				yield return new WaitForSeconds (1.0f);
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
		void Fire(){
			var targetVector = target.transform.position;
			var bomb = ObjectPool.Instantiate (bombPrefab, transform.position, Quaternion.identity);
			var bs = bomb.GetComponent<Bomb> ();
			bs.exploded = false;
			bs.target = targetVector;
			bs.damageAmount = mobLevel;
			lastShot = Time.time;
		}
	
	}
}