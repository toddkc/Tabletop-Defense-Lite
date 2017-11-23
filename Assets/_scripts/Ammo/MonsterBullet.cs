namespace TowerDefense{
	using UnityEngine;



	//this is not used, switched to raycasting


	public class MonsterBullet : MonoBehaviour {

		public float speed = 10;
		public GameObject hitFx;
		[HideInInspector]
		public Transform target;


		void FixedUpdate()
		{
			if (target) 
			{
				Vector3 dir = target.position - transform.position;
				GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
			} else 
			{
				Destroy (gameObject);
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			if (coll.tag == "Tower") 
			{
				GameObject hit = Instantiate (hitFx, transform.position, Random.rotation);
				Destroy (hit, 0.1f);
				var health = coll.GetComponentInParent<TowerHealth> ();
				if (health) 
				{
					Destroy (gameObject);
					health.Hit();
				}
				else
				{
					Destroy (gameObject);
				}
			}
			else if (coll.tag == "Gem") 
			{
				var gem = coll.GetComponent<Gem> ();
				if (gem) 
				{
					Destroy (gameObject);
					gem.Hit ();
				}
				else
				{
					Destroy (gameObject);
				}
			}
		}
	}
}