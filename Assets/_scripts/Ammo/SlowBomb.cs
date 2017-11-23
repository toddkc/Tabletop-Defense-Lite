namespace TowerDefense{
	using UnityEngine;

	public class SlowBomb : MonoBehaviour {

		public float speed = 10;
		[HideInInspector]
		public Vector3 target;
		[Header("Prefab Links")]
		public GameObject explosionPrefab;
		public GameObject blastPrefab;
		[HideInInspector]
		public bool exploded = false;

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
			ObjectPool.Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			ObjectPool.Instantiate(blastPrefab, transform.position, transform.rotation);
			exploded = true;
		}
	}
}