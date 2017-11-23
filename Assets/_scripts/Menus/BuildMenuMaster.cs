namespace TowerDefense{
using UnityEngine;

public class BuildMenuMaster : MonoBehaviour {
	
		public GameObject currentBlock;
		public GameObject currentTower;
		public GameObject money;
		public GameObject vive;

		//face menu towards player
		public void MenuEnabled(GameObject block)
		{

			currentBlock = block;
			transform.forward = vive.transform.forward;
		}

		//move the menu away when it's done being used
		public void Relocate()
		{
			gameObject.transform.position = new Vector3 (0f, -100f, 0f);
		}
	}
}