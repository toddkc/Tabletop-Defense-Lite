namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	public class TowerBaseBlock : MonoBehaviour {

		//tower button menu
		private GameObject towerButtonsMenu;
		private BuildMenuMaster tbm;

		//tower edit menu
		private GameObject towerEditMenu;
		private TowerMenuMaster tem;

		//bool for if block has a tower, and the tower gameobject if yes
		public bool hasTower;
		public GameObject ownedTower;

		//offset to place menu over block
		public Vector3 menuOffset;

		//offset to spawn tower on block
		public Vector3 towerOffset;

		//vrtk script to vibrate controller
		private VRTK_ControllerActions vrtkController;

		//aura highlight
		public GameObject aura;

		//bools to control highlight on/off
		public bool currentlySelected;
		public bool inMenu;

		//don't want to spam button with clicks
		private bool clickable;
		private float clickTimeStamp;

		void Start()
		{
			towerButtonsMenu = GameObject.Find ("TowerBuildMenu");
			tbm = towerButtonsMenu.GetComponent<BuildMenuMaster> ();
			towerEditMenu = GameObject.Find ("TowerEditMenu");
			tem = towerEditMenu.GetComponent<TowerMenuMaster> ();
			clickable = true;
			currentlySelected = false;
			inMenu = false;
		}

		void Update()
		{
			if(clickable == false)
			{
				if (Time.time > clickTimeStamp + 1.0f) 
				{
					clickable = true;
				}
			}

			if(currentlySelected==true)
			{
				aura.SetActive (true);
			}
			else
			{
				if(inMenu==false)
				{
					aura.SetActive (false);
				}
			}
		}

		//called when a new tower is built
		public void TowerCheck(GameObject towerCheckTower)
		{
			ownedTower = towerCheckTower;
		}

		void OnTriggerEnter(Collider coll)
		{
			if(coll.name == "Head" || coll.name=="Ring")
			{
				currentlySelected = true;
				vrtkController = coll.GetComponentInParent<VRTK_ControllerActions>();
				vrtkController.TriggerHapticPulse(1.0f);
			}
		}

		void OnTriggerExit(Collider coll){
			if (coll.name == "Head" || coll.name=="Ring")
			{
				currentlySelected = false;
			}
		}

		public void MouseClicked(){
			clickable = false;//no click spam
			clickTimeStamp = Time.time;//no click spam
			currentlySelected = true;
			tem.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;//set whatever block has menu now to not be inmenu
			tbm.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;
			inMenu = true;
			if (!ownedTower) 
			{
				hasTower = false;//in case it was still true
				tem.Relocate ();//move other menu away
				//new menu position for this menu
				tbm.MenuEnabled (gameObject);//run menuenabled
			} 
			else if (ownedTower) 
			{
				tbm.Relocate ();//move other menu away
				//new menu position for this menu
				tem.MenuEnabled (gameObject, ownedTower);//run menuenabled
			}
		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.name=="Head" ||coll.name=="Ring")
			{
				if(coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable==true)
				{
					clickable = false;//no click spam
					clickTimeStamp = Time.time;//no click spam
					tem.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;//set whatever block has menu now to not be inmenu
					tbm.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;
					inMenu = true;
					if (!ownedTower) 
					{
						hasTower = false;//in case it was still true
						tem.Relocate ();//move other menu away
						//new menu position for this menu
						towerButtonsMenu.transform.position = new Vector3 (gameObject.transform.position.x + menuOffset.x, gameObject.transform.position.y + menuOffset.y, gameObject.transform.position.z + menuOffset.z);
						tbm.MenuEnabled (gameObject);//run menuenabled
					} 
					else if (ownedTower) 
					{
						tbm.Relocate ();//move other menu away
						//new menu position for this menu
						towerEditMenu.transform.position = new Vector3 (gameObject.transform.position.x + menuOffset.x, gameObject.transform.position.y + menuOffset.y, gameObject.transform.position.z + menuOffset.z);
						tem.MenuEnabled (gameObject, ownedTower);//run menuenabled
					}

				}
			}
		
		}

	
	}
}
