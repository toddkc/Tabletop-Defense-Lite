namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	// This Script lives on the 'selectable' part of Tower Base Blocks, which are placed around levels to allow the player to build towers.

	public class TowerBaseBlock : MonoBehaviour {

		//tower button menu gameobject
		private GameObject towerButtonsMenu;
		//script component on that gameobject
		private BuildMenuMaster tbm;

		//tower edit menu gameobject
		private GameObject towerEditMenu;
		//script on that gameobject
		private TowerMenuMaster tem;

		//offset to place menu over block
		[Tooltip("This is the XYZ offset where the menu will appear over the tower block.")]
		public Vector3 menuOffset;

		//offset to spawn tower on block
		[Tooltip("This is the XYZ offset where the tower will be instantiated on the block.")]
		public Vector3 towerOffset;

		//vrtk script used to vibrate controller
		private VRTK_ControllerActions vrtkController;

		//aura highlight to turn on/off as block is selected
		[Tooltip("This gameobject will be activated when the block is selected as a visual indication.")]
		public GameObject aura;

		//if block has a tower, and the tower gameobject if true
		[HideInInspector]
		public bool hasTower;
		[HideInInspector]
		public GameObject ownedTower;

		//bools to control highlight on/off
		[HideInInspector]
		public bool currentlySelected = false;
		[HideInInspector]
		public bool inMenu = false;

		//bool and time reference to make block only selectable once every .5 seconds
		private bool clickable = true;
		private float clickTimeStamp;

		void Start(){
			//find tower menus and get script componenets
			towerButtonsMenu = GameObject.Find ("TowerBuildMenu");
			tbm = towerButtonsMenu.GetComponent<BuildMenuMaster> ();
			towerEditMenu = GameObject.Find ("TowerEditMenu");
			tem = towerEditMenu.GetComponent<TowerMenuMaster> ();
		}

		void Update(){
			//this limits the speed block can be selected for user friendliness 
			if(clickable == false && Time.time > clickTimeStamp + 0.5f){
				clickable = true;
			}
			//checks if block is active and sets aura object active
			if(currentlySelected==true){
				aura.SetActive (true);
			}else{
				//if block is not active, and not in a menu, then set aura object deactive
				if(inMenu==false){
					aura.SetActive (false);
				}
			}
		}
			
		void OnTriggerEnter(Collider coll){
			//check if vive or oculus controller
			if(coll.name == "Head" || coll.name=="Ring"){
				//activates aura in update
				currentlySelected = true;
				//vibrate controller
				vrtkController = coll.GetComponentInParent<VRTK_ControllerActions>();
				vrtkController.TriggerHapticPulse(1.0f);
			}
		}

		void OnTriggerExit(Collider coll){
			//check if vive or oculus controller
			if (coll.name == "Head" || coll.name=="Ring"){
				//deactivae aura in update
				currentlySelected = false;
			}
		}

		void OnTriggerStay(Collider coll){
			//check if vive or oculus controller
			if (coll.name=="Head" ||coll.name=="Ring"){
				//if block is clickable and controller trigger is pressed
				if(coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable==true){
					//activate the click delay
					clickable = false;
					clickTimeStamp = Time.time;
					//set both menus currentblock to inmenu=false to clear any other block that is active
					tem.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;
					tbm.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;
					//and then set this block to inmenu
					inMenu = true;
					//check if block does not have a tower
					if (!ownedTower){
						//refresh hastower=false in case one was sold/destroyed
						hasTower = false;
						//move other menu offscreen
						tem.Relocate ();
						//new menu position for this menu based on offset
						towerButtonsMenu.transform.position = new Vector3 (
							gameObject.transform.position.x + menuOffset.x,
							gameObject.transform.position.y + menuOffset.y,
							gameObject.transform.position.z + menuOffset.z);
						//enable menu after repositioning it
						tbm.MenuEnabled (gameObject);
					//if block has a tower
					}else if (ownedTower){
						//move other menu offscreen
						tbm.Relocate ();
						//new menu position for this menu based on offset
						towerEditMenu.transform.position = new Vector3 (
							gameObject.transform.position.x + menuOffset.x,
							gameObject.transform.position.y + menuOffset.y,
							gameObject.transform.position.z + menuOffset.z);
						//enable menu after repositioning it
						tem.MenuEnabled (gameObject, ownedTower);
					}
				}
			}
		}

		//called from tower build menu when a new tower is instantiated
		public void TowerCheck(GameObject towerCheckTower){
			ownedTower = towerCheckTower;
		}

		//used for testing, can probably be deleted
		/*
		public void MouseClicked(){
			clickable = false;//no click spam
			clickTimeStamp = Time.time;//no click spam
			currentlySelected = true;
			tem.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;//set whatever block has menu now to not be inmenu
			tbm.currentBlock.GetComponent<TowerBaseBlock> ().inMenu = false;
			inMenu = true;
			if (!ownedTower){
				hasTower = false;//in case it was still true
				tem.Relocate ();//move other menu away
				//new menu position for this menu
				tbm.MenuEnabled (gameObject);//run menuenabled
			} 
			else if (ownedTower){
				tbm.Relocate ();//move other menu away
				//new menu position for this menu
				tem.MenuEnabled (gameObject, ownedTower);//run menuenabled
			}
		}*/
	}
}
