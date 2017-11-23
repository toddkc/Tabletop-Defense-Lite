namespace TowerDefense
{
	using UnityEngine;
	public class Bullet : MonoBehaviour {

		public float speed = 10;
		public GameObject hitFx;
		public Transform target;


		void FixedUpdate()
		{
			if (target) 
			{
				Vector3 dir = target.position - transform.position;
				GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
			} 
			else 
			{
				ObjectPool.Destroy (gameObject);
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			if (coll.tag == "Ground Mob") 
			{
				ObjectPool.Instantiate (hitFx, transform.position, Random.rotation);
				coll.GetComponentInParent<MobHealth> ().Hit();
				ObjectPool.Destroy (gameObject);
			}
		}
	}
}