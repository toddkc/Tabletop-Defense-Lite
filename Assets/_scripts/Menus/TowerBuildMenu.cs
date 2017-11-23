namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	using UnityEngine.UI;
	using UnityEngine.AI;
	using System.Collections;
	public class TowerBuildMenu : MonoBehaviour {
		#region ControllerVibration
		//the controller for vibration settings, used on all buttons
		private VRTK_ControllerActions controllerActions;
		void OnTriggerEnter(Collider coll)
		{
			if(coll.name == "Head" || coll.name=="Ring")
			{
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions>();
				controllerActions.TriggerHapticPulse(1.0f);
			}
		}
		#endregion

		public GameObject sphere;
		public GameObject towerPrefab;
		public GameObject towerGhost;
		public int towerCost;
		public bool cancelButton, freebuild;
		public TextMesh tm;
		private BuildMenuMaster parentMenu;
		private GameObject moneyGo;
		private Money money;
		private int currentMoney;
		private bool clickable;
		private float timeStamp;

		public FreebuildSpawnAgent spawnAgent;
		void Start()
		{
			parentMenu = GetComponentInParent<BuildMenuMaster> ();
			money = parentMenu.money.GetComponent<Money> ();
			currentMoney = money.moneyMaster;
			clickable = true;
			if (cancelButton == false) {
				tm.text = towerCost.ToString ();
			}
		}
		void Update()
		{
			if(clickable == false)
			{
				if (Time.time > timeStamp + 1.0f) 
				{
					clickable = true;
				}
			}
		}
		void OnTriggerStay(Collider coll)
		{
			sphere.SetActive (true);
			var towerbase = parentMenu.currentBlock.GetComponent<TowerBaseBlock> ();
			if(cancelButton==false)
			{
				towerGhost.transform.position=parentMenu.currentBlock.transform.position + towerbase.towerOffset;
				towerGhost.SetActive (true);
			}
			if (coll.GetComponentInParent<VRTK_ControllerEvents>().triggerPressed == true && clickable==true)
			{
				clickable = false;
				timeStamp = Time.time;
				sphere.SetActive (false);
				parentMenu.Relocate ();
				towerbase.inMenu = false;

				if(cancelButton==true)
				{
					//do nothing
				}else if(towerbase.hasTower==false)
				{
					currentMoney = money.moneyMaster;
					towerGhost.SetActive (false);
					if(currentMoney>= towerCost)
					{
						if (PlayerCheck ()) {
							if (freebuild == false) {
								towerbase.hasTower = true;
								money.TowerBuildCost (towerCost);
								GameObject tower = (GameObject)Instantiate (towerPrefab);
								tower.transform.position = parentMenu.currentBlock.transform.position + towerbase.towerOffset;
								towerbase.ownedTower = tower;
								money.towersBuilt++;
							}else{
								StartCoroutine(FreebuildTowerCheck (towerbase));
							}
						}
					}else {
						
					}
				}
			}
		}

		public void BuildTower(){
			var towerbase = parentMenu.currentBlock.GetComponent<TowerBaseBlock> ();
			parentMenu.Relocate ();
			towerbase.inMenu = false;
			if(cancelButton==true){
				
			}else if(towerbase.hasTower==false)
			{
				currentMoney = money.moneyMaster;
				if(currentMoney>= towerCost)
				{
					if (PlayerCheck ()) {
						if (freebuild == false) {
							towerbase.hasTower = true;
							money.TowerBuildCost (towerCost);
							GameObject tower = (GameObject)Instantiate (towerPrefab);
							tower.transform.position = parentMenu.currentBlock.transform.position + towerbase.towerOffset;
							towerbase.ownedTower = tower;
							money.towersBuilt++;
						}else{
							StartCoroutine(FreebuildTowerCheck (towerbase));
						}
					}
				}else {
					
				}
			}
		}

		IEnumerator FreebuildTowerCheck(TowerBaseBlock towerbase){

			//build tower to test
			GameObject tower = (GameObject)Instantiate (towerPrefab);
			tower.transform.position = parentMenu.currentBlock.transform.position + towerbase.towerOffset;

			//wait
			yield return new WaitForSeconds (0.01f);

			//check path
			if(spawnAgent.CheckPathValid()){
				towerbase.hasTower = true;
				money.TowerBuildCost (towerCost);
				towerbase.ownedTower = tower;
			}else{
				Destroy (tower);
			}

			yield break;
		}

		public LayerMask playerLayer;
		bool PlayerCheck(){
			Collider[] players = Physics.OverlapSphere (parentMenu.currentBlock.transform.position, 4.0f, playerLayer);
			if(players.Length!=0)
			{
				return false;
			}else{
				return true;
			}
		}
		//this turns off the highlight when controller stops hovering over this button
		void OnTriggerExit(Collider coll)
		{
			sphere.SetActive(false);
			if (cancelButton == false) {
				towerGhost.SetActive (false);
			}
		}
	}
}