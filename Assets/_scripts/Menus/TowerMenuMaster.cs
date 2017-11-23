namespace TowerDefense{
using UnityEngine;

public class TowerMenuMaster : MonoBehaviour {

		//the block that was originally selected
		public GameObject currentBlock;
		public GameObject currentTower;
		public GameObject repairButton;
		public GameObject upgradeButton;
		public GameObject sellButton;
		public GameObject money;
		private TowerURSMenu repair;
		private TowerURSMenu sell;
		private TowerURSMenu upgrade;
		public GameObject vive;
		void Start(){
			repair = repairButton.GetComponent<TowerURSMenu> ();
			sell = sellButton.GetComponent<TowerURSMenu> ();
			upgrade = upgradeButton.GetComponent<TowerURSMenu> ();
		}


		public void MenuEnabled(GameObject block, GameObject tower)
		{
			currentBlock = block;
			currentTower = tower;
			transform.forward = vive.transform.forward;
			repair.RefreshButtonCost (tower);
			upgrade.RefreshButtonCost (tower);
			sell.RefreshButtonCost (tower);
		}
		//move the menu away when it's done being used
		public void Relocate()
		{
			gameObject.transform.position = new Vector3 (0f, -100f, 0f);
		}
}
}