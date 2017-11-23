namespace TowerDefense{
	using UnityEngine;
	using System.Collections;
	public class SpawnHeal : MonoBehaviour {

		Collider[] mobs;
		bool running;
		public float frequency=0.1f;
		public LayerMask layerMask;

		void Start(){
			running = true;
			StartCoroutine (SpawnRepair ());
		}

		IEnumerator SpawnRepair(){
			
			while (running) {
				
				mobs = Physics.OverlapSphere (transform.position, 5.0f, layerMask);

				if (mobs.Length >= 1) {
					foreach (var item in mobs) {
						var health = item.GetComponentInParent<MobHealth> ();
						if (health) {
							health.currentHealth = health.maxHealth;
							health.healthBarImage.fillAmount = 1;
						}
					}
				}
				yield return new WaitForSeconds (frequency);
			}
		}
	}
}