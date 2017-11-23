namespace TowerDefense{
	using UnityEngine;
	using System.Collections;

	public class Gold : MonoBehaviour {

		[Tooltip("How much is this object worth?")]
		public int worth;
		public float speed = 100.0f;

		public float delay = 30.0f;

		void OnEnable()
		{
			StartCoroutine("CheckIfAlive");
		}

		IEnumerator CheckIfAlive ()
		{
			while(true)
			{
				yield return new WaitForSeconds(delay);
				ObjectPool.Destroy (gameObject);
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			if (coll.tag == "Player" || coll.name=="Head" || coll.name=="Ring") 
			{
					coll.GetComponentInParent<GoldPickup> ().Pickup (worth);
					ObjectPool.Destroy(gameObject);
			}
		}
	}
}