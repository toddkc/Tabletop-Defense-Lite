namespace TowerDefense{
	using UnityEngine;
	public class Missile : MonoBehaviour {

		public float speed = 10;
		public GameObject hitFx;
		public Transform target;

		void Update(){
			if(!target){
				ObjectPool.Destroy (gameObject);
			}
		}

		void FixedUpdate(){
			if (target) {
				Vector3 dir = target.position - transform.position;
				GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
			}
		}

		void OnTriggerEnter(Collider coll){
			if (coll.tag == "Air Mob") {
				ObjectPool.Instantiate (hitFx, transform.position, Quaternion.Inverse(transform.rotation));
				var health = coll.GetComponentInParent<MobHealth> ();
				if (health) {
					health.Hit ();
				}
				ObjectPool.Destroy (gameObject);
			}
		}
	}
}