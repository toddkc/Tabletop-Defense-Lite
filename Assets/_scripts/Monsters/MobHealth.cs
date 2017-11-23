namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

	public class MobHealth : MonoBehaviour {

		public Image healthBarImage;
		public float maxHealth;
		[HideInInspector]
		public float currentHealth;
		private float startHealth;
		[HideInInspector]
		public MobStats mobStats;
		[Header("Loot")]
		public bool dropLoot;
		bool lootDropped;
		[Range(1,100)]
		public int percentChance;
		public GameObject [] lootPrefabs;
		public GameObject upgradeCrown;
		public GameObject explosion;
		//public for gem to see
		[HideInInspector]
		public bool hasDeathBeenCounted;
		[HideInInspector]
		public bool upgraded, pooled;
		[HideInInspector]
		public int mobLevel;

		public void MobStart(int level){
			mobLevel = level;
			startHealth  = maxHealth * level;
			currentHealth = startHealth;
			healthBarImage.fillAmount = 1;
			hasDeathBeenCounted = false;
			if(level > 1){
				upgradeCrown.SetActive (true);
				upgraded = true;
			}
		}

		//drops loot when killed
		private void Loot()	{
			foreach (GameObject loot in lootPrefabs) {
				var i = Random.Range (1, 101);
				if (i <= percentChance) {
					ObjectPool.Instantiate (loot, RandomVector (transform.position), Quaternion.identity);
				}
			}
		}

		Vector3 RandomVector(Vector3 initial){
			var randomVector = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (1.0f, 2.0f),Random.Range (-1.0f, 1.0f));
			return initial + randomVector;
		}



		//lower health, destroy when killed, drop loot if needed
		public void Hit(){
			//if health is 1 or more then lower it
			if (currentHealth > 1.0f){
				currentHealth -= 1.0f;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			} 
			//if health is less than one mob is destroyed
			else {
				if (explosion) {
					ObjectPool.Instantiate (explosion, transform.position, transform.rotation);
				}
				if (mobStats.mobsCurrentlyActive > 0 && hasDeathBeenCounted==false) 
				{
					hasDeathBeenCounted = true;
					mobStats.mobsCurrentlyActive--;
				}
				if(dropLoot==true && lootDropped==false){
					lootDropped = true;
					Loot ();
				}
				if (pooled == true) {
					ObjectPool.Destroy (gameObject);
				}else{
					Destroy (gameObject);
				}
			}
		}
	}
}