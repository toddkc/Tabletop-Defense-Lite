namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;
	public class HealthBar : MonoBehaviour {

		#region Variables
		[Tooltip("The image to adjust as health decreases.")]
		public Image healthBarImage;
		[HideInInspector]
		public GameObject target;
		[HideInInspector]
		public bool tower;
		[HideInInspector]
		public bool mob;
		[HideInInspector]
		public bool gem;
		[HideInInspector]
		public bool player;
		//variables depending on what entity this is attached to
		private TowerHealth towerHealth;
		private Gem gemHealth;
		private MobHealth mobHealth;
		#endregion

		void Start()
		{
			if (tower == true) {
				towerHealth = target.GetComponent<TowerHealth> ();
			}
			else if(gem == true){
				gemHealth = target.GetComponent<Gem> ();
			}
			else if(mob == true){
				mobHealth = target.GetComponent<MobHealth> ();
			}

		}

		void Update () 
		{
			if (tower == true) 
			{
				healthBarImage.fillAmount = towerHealth.currentHealth / towerHealth.maxHealth;
			}
			else if(gem == true)
			{
				healthBarImage.fillAmount = gemHealth.currentHealth / gemHealth.maxHealth;
			}
			else if(mob == true)
			{
				healthBarImage.fillAmount = mobHealth.currentHealth / mobHealth.maxHealth;
			}
		}
	}
}