namespace TowerDefense{
	using UnityEngine;
	using System.Collections;

	public class Gold : MonoBehaviour {

		[Tooltip("How much is this object worth?")]
		public int worth;
		[Tooltip("Time before this object is destroyed.")]
		public float delay = 30.0f;

		void OnEnable(){
			StartCoroutine("CheckIfAlive");
		}

		IEnumerator CheckIfAlive (){
			while(true)	{
				yield return new WaitForSeconds(delay);
				ObjectPool.Remove (gameObject);
			}
		}

		void OnTriggerEnter(Collider coll){
			if (coll.tag == "Player" || coll.name=="Head" || coll.name=="Ring") {
					coll.GetComponentInParent<GoldPickup> ().Pickup (worth);
					ObjectPool.Remove(gameObject);
			}
		}
	}
}