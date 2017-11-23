namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class TowerURSMenu : MonoBehaviour {

		#region ControllerVibration
		//the controller for vibration settings, used on all buttons
		private VRTK_ControllerActions controllerActions;
		void OnTriggerEnter(Collider coll){
			if(coll.name == "Head" || coll.name=="Ring"){
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions>();
				controllerActions.TriggerHapticPulse(1.0f);
			}
		}
		#endregion

		#region Variables
		//object activated on hover for visual feedback
		[Tooltip("Object to be activated for visual feedback.")]
		public GameObject sphere;
		//tower being modified
		[HideInInspector]
		public GameObject tower;
		[Header("Button Type")]
		public bool upgrade;
		public bool repair;
		public bool sell;
		public bool cancelButton;
		[Header("Costs")]
		public int upgradeCostGun;
		public int upgradeCostAir;
		public int upgradeCostBomb;
		public int upgradeCostSlow;

		public int repairCostGun;
		public int repairCostAir;
		public int repairCostBomb;
		public int repairCostSlow;

		public int sellCostGun;
		public int sellCostAir;
		public int sellCostBomb;
		public int sellCostSlow;

		[Tooltip("Text display component.")]
		public TextMesh tm;
		//parent menu component
		private TowerMenuMaster parentMenu;
		//money level object/component
		private Money money;
		//link to master money variable in money script
		private int currentMoney;
		//click setup to avoid spam
		private bool clickable = true;
		private float timeStamp;
		#endregion

		void Start(){
			parentMenu = GetComponentInParent<TowerMenuMaster> ();
			money = parentMenu.money.GetComponent<Money> ();
			currentMoney = money.moneyMaster;
		}

		void Update(){
			if(clickable == false){
				if (Time.time > timeStamp + 1.0f){
					clickable = true;
				}
			}
		}

		//this int is used in refresh and repair/sell/upgrade, saves me typing the name of the tower a bunch
		//gun1 air2 bomb3 slow4
		private int tn;

		#region RefreshButtonCost
		public void RefreshButtonCost(GameObject towerToRefresh)
		{
			tower = towerToRefresh;
			var towerScript = towerToRefresh.GetComponent<Tower> ();
			var towerName = towerToRefresh.name;
			if(towerName== "Gun Tower(Clone)")
			{tn = 1;}
			else if(towerName== "Air Tower(Clone)")
			{tn = 2;}
			else if(towerName== "Bomb Tower(Clone)")
			{tn = 3;}
			else if(towerName== "Slow Tower(Clone)")
			{tn = 4;}

			if(upgrade==true){
				if(tn==1){
					if (towerScript.level <12){
						tm.text = (upgradeCostGun * towerScript.level).ToString();
					}else{
						tm.text="X";
					}
					
				}else if(tn==2){
					if (towerScript.level<12){
						tm.text = (upgradeCostAir* towerScript.level).ToString ();
					}else{
						tm.text="X";
					}
				}else if(tn==3){
					if (towerScript.level <12){
						tm.text = (upgradeCostBomb* towerScript.level).ToString ();
					}else{
						tm.text="X";
					}
				}else if(tn==4){
					if (towerScript.level<12){
						tm.text = (upgradeCostSlow* towerScript.level).ToString ();
					}else{
						tm.text="X";
					}
				}
			}else if(repair==true){
				if(tn==1){
					tm.text = (repairCostGun* towerScript.level).ToString();
				}else if(tn==2){
					tm.text = (repairCostAir* towerScript.level).ToString ();
				}else if(tn==3){
					tm.text = (repairCostBomb* towerScript.level).ToString ();
				}else if(tn==4){
					tm.text = (repairCostSlow* towerScript.level).ToString ();
				}
			}else if(sell==true){
				if(tn==1){
					if (towerScript.upgraded == false){
						tm.text = sellCostGun.ToString();
					}else{
						tm.text = (sellCostGun*2).ToString();
					}
				}else if(tn==2){
					if (towerScript.upgraded == false){
						tm.text = sellCostAir.ToString ();
					}else{
						tm.text = (sellCostAir*2).ToString();
					}
				}else if(tn==3){
					if (towerScript.upgraded == false){
						tm.text = sellCostBomb.ToString ();
					}else{
						tm.text = (sellCostBomb*2).ToString();
					}
				}else if(tn==4){
					if (towerScript.upgraded == false){
						tm.text = sellCostSlow.ToString ();
					}else{
						tm.text = (sellCostSlow*2).ToString ();
					}
				}
			}
		}
		#endregion

		#region Upgrade
		public void Upgrade(GameObject towerUp){
			
			var towerScript = towerUp.GetComponent<Tower> ();
			if(tn==1){
				if(money.moneyMaster>=(upgradeCostGun*towerScript.level)){
					money.moneyMaster -= (upgradeCostGun * towerScript.level);
					towerScript.Upgrade ();
				}else{
				}
			}else if(tn==2){
				if (money.moneyMaster >= (upgradeCostAir*towerScript.level)) {
					money.moneyMaster -= (upgradeCostAir*towerScript.level);
					towerScript.Upgrade ();
				} else {
				}
			}else if(tn==3){
				if (money.moneyMaster >= (upgradeCostBomb*towerScript.level)) {
					money.moneyMaster -= (upgradeCostBomb*towerScript.level);
					towerScript.Upgrade ();
				} else {
				}
			}else if(tn==4){
				if (money.moneyMaster >= (upgradeCostSlow*towerScript.level)) {
					money.moneyMaster -= (upgradeCostSlow*towerScript.level);
					towerScript.Upgrade ();
				} else {
				}
			}
		}
		#endregion

		#region Repair
		public void Repair(GameObject towerRepair){
			var towerScript = towerRepair.GetComponent<Tower> ();
			var towerHealth = towerRepair.GetComponent<TowerHealth> ();
			if (towerHealth.currentHealth < towerHealth.maxHealth){
				if (tn == 1){
					if (money.moneyMaster >= (repairCostGun * towerScript.level)){
						money.moneyMaster -= (repairCostGun * towerScript.level);
						towerHealth.currentHealth = towerHealth.maxHealth;
						towerHealth.healthBarImage.fillAmount = 1.0f;
					}else{
					}
				}else if (tn == 2){
					if (money.moneyMaster >= (repairCostAir * towerScript.level)) {
						money.moneyMaster -= (repairCostAir *towerScript.level);
						towerHealth.currentHealth = towerHealth.maxHealth;
						towerHealth.healthBarImage.fillAmount = 1.0f;
					} else {
					}
				}else if (tn == 3){
					if (money.moneyMaster >= (repairCostBomb * towerScript.level)) {
						money.moneyMaster -= (repairCostBomb * towerScript.level);
						towerHealth.currentHealth = towerHealth.maxHealth;
						towerHealth.healthBarImage.fillAmount = 1.0f;
					} else {
					}
				}else if (tn == 4) {
					if (money.moneyMaster >= (repairCostSlow * towerScript.level)) {
						money.moneyMaster -= (repairCostSlow * towerScript.level);
						towerHealth.currentHealth = towerHealth.maxHealth;
						towerHealth.healthBarImage.fillAmount = 1.0f;
					} else {
					}
				} 
			}
		}
		#endregion

		#region Sell
		public void Sell(GameObject towerSell)
		{
			var towerHealth = towerSell.GetComponent<TowerHealth> ();

			if(tn==1)
			{
				if(towerHealth.upgraded==false)
				{
					money.moneyMaster += sellCostGun;
				}else{
					money.moneyMaster += sellCostGun * 2;
				}
			}else if(tn==2)
			{
				if(towerHealth.upgraded==false)
				{
					money.moneyMaster += sellCostAir;
				}else{
					money.moneyMaster += sellCostAir * 2;
				}
			}else if(tn==3)
			{
				if(towerHealth.upgraded==false)
				{
					money.moneyMaster += sellCostBomb;
				}else{
					money.moneyMaster += sellCostBomb * 2;
				}
			}else if(tn==4)
			{
				if(towerHealth.upgraded==false)
				{
					money.moneyMaster += sellCostSlow;
				}else{
					money.moneyMaster += sellCostSlow * 2;
				}
			}
			//Destroy (towerHealth.healthBar);
			Destroy (towerSell);
		}
		#endregion

		void OnTriggerStay(Collider coll){
			//activate sphere while button is hovered over
			sphere.SetActive (true);
			//check if button is clickable and trigger is pressed
			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable==true){
				//deactivate sphere
				sphere.SetActive (false);
				//move the menu away
				parentMenu.Relocate ();
				//set tower block to not in menu
				parentMenu.currentBlock.GetComponent<TowerBaseBlock>().inMenu = false;
				//reset click timer
				clickable = false;
				timeStamp = Time.time;
				//if this is the cancel button be done
				if(cancelButton==true){
					return;
				//otherwise perform URS function
				}else if (upgrade == true){
					Upgrade (tower);
				} 
				else if (repair == true){
					Repair (tower);
				} 
				else if (sell == true){
					Sell (tower);
				}
			}
		}

		//this turns off the highlight when controller stops hovering over the button
		void OnTriggerExit(Collider coll){
			sphere.SetActive(false);
		}
	}
}