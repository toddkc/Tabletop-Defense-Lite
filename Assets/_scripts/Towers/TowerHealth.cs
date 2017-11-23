namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

	public class TowerHealth : MonoBehaviour {

		#region Variables

		public Image healthBarImage;
		public GameObject canvas;
		public GameObject upgradeCrown;
		public GameObject[] upgradeStars;
		public GameObject explosion;
		[Header("Stats")]
		public float maxHealth;
		[HideInInspector]
		public float currentHealth;
		[HideInInspector]
		public bool upgraded;
		#endregion

		void Start(){
			currentHealth = maxHealth;
		}

		public void UpgradeTowerHealth(int level){
			if (!upgraded){
				upgraded = true;
				canvas.transform.localScale = new Vector3 (0.175f, 0.1f, 0.1f);
				upgradeCrown.SetActive (true);
			}else{
				upgradeStars [level - 3].SetActive (true);
			}
			maxHealth *= level;
			currentHealth = maxHealth;
			healthBarImage.fillAmount = 1.0f;
		}
			
		//when tower is hit
		public void Hit(){
			//if health is 1 or more then lower it
			if (currentHealth > 1.0f){
				currentHealth -= 1.0f;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			//if health is less than one tower is destroyed
			}else{
				ObjectPool.Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		//same but for specific values
		public void Hit(int value){
			//if health is 1 or more then lower it
			if (currentHealth > value){
				currentHealth -= value;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			//if health is less than one tower is destroyed
			}else{
				ObjectPool.Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
}