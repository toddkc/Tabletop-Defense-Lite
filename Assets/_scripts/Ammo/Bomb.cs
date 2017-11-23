namespace TowerDefense{
	using UnityEngine;

	public class Bomb : MonoBehaviour {
	
		public float speed = 10;
		[HideInInspector]
		public Vector3 target;
		[Header("Prefab Links")]
		public GameObject explosionPrefab;
		public GameObject blastPrefab;
		[HideInInspector]
		public bool exploded = false;
		[HideInInspector]
		public int damageAmount=1;

		void Update()
		{
			Vector3 dir = target - transform.position;
			GetComponent<Rigidbody> ().velocity = dir.normalized * speed;

			if (Vector3.Distance(transform.position, target) < 1.0f) {
				if (exploded == false) {
					Explosion ();
				}
			}

			if(exploded==true){
				ObjectPool.Destroy (gameObject);
			}
		}

		void Explosion(){
			var blast = ObjectPool.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			ObjectPool.Instantiate (blastPrefab, transform.position, transform.rotation);
			blast.GetComponent<explosion> ().damageAmount = damageAmount;
			exploded = true;
		}
	}
}