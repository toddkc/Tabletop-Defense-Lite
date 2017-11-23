namespace TowerDefense{
using UnityEngine;

public class BuildMenuMaster : MonoBehaviour {

		//the currently selected tower base block
		[HideInInspector]
		public GameObject currentBlock;
		//the currently selected tower
		[HideInInspector]
		public GameObject currentTower;
		//the money object in the game
		[HideInInspector]
		public GameObject money;
		//the player object used for menu rotation
		private GameObject player;

		void Awake(){
			money = GameObject.Find ("Money");
		}

		void Start(){
			player = GameObject.Find ("Player");
		}

		//face menu towards player when it's moved and activated
		public void MenuEnabled(GameObject block){
			currentBlock = block;
			transform.forward = player.transform.forward;
		}

		//move the menu away when it's done being used
		public void Relocate(){
			gameObject.transform.position = new Vector3 (0f, -100f, 0f);
		}
	}
}