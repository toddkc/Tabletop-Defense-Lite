namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.AI;
	using System.Collections;

	public class SlowExplosion : MonoBehaviour {

		public float delay;

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
			if (coll.tag == "Ground Mob") 
			{
				coll.GetComponentInParent<MobNavigation> ().SlowEffect();
			}
		}
	} 
}