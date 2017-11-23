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
		private void Loot()
		{
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
		public void Hit()
		{
			//if health is 1 or more then lower it
			if (currentHealth > 1.0f) 
			{
				currentHealth -= 1.0f;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			} 
			//if health is less than one mob is destroyed
			else 
			{
				ObjectPool.Instantiate (explosion, transform.position, transform.rotation);
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

		/*
		#region Variables
		[Header("Prefab Link")]
		public GameObject healthBarPrefab;
		public GameObject healthBar;
		[HideInInspector]
		public Image healthBarImage;
		public GameObject canvas;
		[HideInInspector]
		public float currentHealth;
		[HideInInspector]
		public float maxHealth;
		[Header("Stats")]
		public float basicHealth;
		public float rangedHealth;
		public float flyingHealth;
		public float bossHealth;
		[HideInInspector]
		public MobStats mobStats;
		private float offset;
		[Header("Loot")]
		public bool dropLoot;
		[Range(1,100)]
		public int percentChance;
		public GameObject lootPrefab;
		public GameObject upgradeCrown;
		public GameObject explosion;
		//public for gem to see
		public bool hasDeathBeenCounted;
		#endregion

		//sets variables
		void Start () 
		{
			//instantiate healthbar
			healthBar = Instantiate (healthBarPrefab, transform.position, Quaternion.identity, canvas.transform);
			//set healthbar to see this object
			healthBar.GetComponent<HealthBar> ().target = gameObject;
			//set healthbar type
			healthBar.GetComponent<HealthBar> ().mob = true;
			//tower variable is this tower
		}

		//sets health and ui offset based on mob type
		public void BasicMobStart(int level){
			maxHealth = basicHealth * level;
			currentHealth = maxHealth;
			offset = 1.5f;
			if(level > 1){
				upgradeCrown.SetActive (true);
			}
		}
		public void RangedMobStart(int level){
			maxHealth = rangedHealth * level;
			currentHealth = maxHealth;
			offset = 2.0f;
			if(level > 1){
				upgradeCrown.SetActive (true);
			}
		}
		public void FlyingMobStart(int level){
			maxHealth = flyingHealth * level;
			currentHealth = maxHealth;
			offset = 1.0f;
			if(level > 1){
				upgradeCrown.SetActive (true);
			}
		}
		public void BossMobStart(int level){
			maxHealth = bossHealth * level;
			currentHealth = maxHealth;
			offset = 5.0f;
			if(level > 1){
				upgradeCrown.SetActive (true);
			}
		}

		//moves healthbar with mob 
		void Update()
		{
			if (healthBar)
			{
				healthBar.transform.position = new Vector3 (transform.position.x, transform.position.y + offset, transform.position.z);
			}
		}

		//drops loot when killed
		private void Loot()
		{
			var i = Random.Range (1, 101);
			if (i <= percentChance) {
				var drop = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
				Instantiate (lootPrefab, drop, Quaternion.identity);
			}
		}

		//lower health, destroy when killed, drop loot if needed
		public void Hit()
		{
			//if health is 1 or more then lower it
			if (currentHealth > 1.0f) 
			{
				currentHealth -= 1.0f;
			} 
			//if health is less than one tower is destroyed
			else 
			{
				MasterAudio.PlaySound3DAtTransformAndForget ("Demolish", transform);
				GameObject blast = Instantiate (explosion, transform.position, transform.rotation);
				Destroy (blast, 1.0f);
				Destroy (healthBar);
				Destroy (gameObject);
				if (mobStats.mobsCurrentlyActive > 0 && hasDeathBeenCounted==false) 
				{
					hasDeathBeenCounted = true;
					mobStats.mobsCurrentlyActive--;
				}
				if(dropLoot==true){
					Loot ();
				}
			}
		}
		*/
	}
}