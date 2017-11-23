namespace TowerDefense{
	using UnityEngine;
	using System.Collections;

	public class explosion : MonoBehaviour {
	
		public float delay;
		public bool air=false;
		[HideInInspector]
		public int damageAmount;

		void OnEnable(){
			StartCoroutine ("DisableDelay");
		}

		IEnumerator DisableDelay(){
			while(true)
			{
				yield return new WaitForSeconds(delay);
				ObjectPool.Destroy (gameObject);
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			if (!air) {
				if (coll.tag == "Ground Mob" || coll.tag == "Air Mob") {
					coll.GetComponentInParent<MobHealth> ().Hit ();
				}
			}else{
				if(coll.tag=="Tower"){
					coll.GetComponentInParent<TowerHealth> ().Hit (damageAmount);
				}if(coll.tag=="Gem"){
					coll.GetComponentInParent<Gem> ().Hit ();
				}
			}
		}
	}
}