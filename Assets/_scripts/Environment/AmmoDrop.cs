namespace TowerDefense{
	using UnityEngine;
	using System.Collections;

	public class AmmoDrop : MonoBehaviour {

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
			if (coll.name=="Head" || coll.name=="Ring") 
			{
				ObjectPool.Destroy(gameObject);
			}
		}
	}
}