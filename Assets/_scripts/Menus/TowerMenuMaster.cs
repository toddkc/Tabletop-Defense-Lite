namespace TowerDefense{
	using UnityEngine;

	public class TowerMenuMaster : MonoBehaviour {

		//the block that was originally selected
		public GameObject currentBlock;
		//the tower being edited
		public GameObject currentTower;
		//the child gameobjects, used to differentiate script components on each button
		public GameObject repairButton;
		public GameObject upgradeButton;
		public GameObject sellButton;
		private TowerURSMenu repair;
		private TowerURSMenu sell;
		private TowerURSMenu upgrade;
		//money gameobject in level
		[HideInInspector]
		public Money money;
		//the player gameobject
		[Tooltip("The object used to rotate the menu when moved and activated.")]
		private GameObject player;

		void Awake(){
			money = GameObject.Find ("LevelManager").GetComponent <Money>();
		}

		void Start(){
			//stores which version of the UpgradeRepairSell script is on which gameobject
			repair = repairButton.GetComponent<TowerURSMenu> ();
			sell = sellButton.GetComponent<TowerURSMenu> ();
			upgrade = upgradeButton.GetComponent<TowerURSMenu> ();
			player = GameObject.Find ("Player");
		}

		//sets block, tower, menu rotation, and sends the tower info to each URS button script
		public void MenuEnabled(GameObject block, GameObject tower){
			currentBlock = block;
			currentTower = tower;
			transform.forward = player.transform.forward;
			repair.RefreshButtonCost (tower);
			upgrade.RefreshButtonCost (tower);
			sell.RefreshButtonCost (tower);
		}

		//move the menu away when it's done being used
		public void Relocate(){
			gameObject.transform.position = new Vector3 (0f, -100f, 0f);
		}
	}
}