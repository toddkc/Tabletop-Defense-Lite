namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	using UnityEngine.SceneManagement;

	public class Menu : MonoBehaviour {

		public bool startOpen;
		public GameObject viveMenuSpot;
		private GameObject leftController;
		private GameObject rightController;
		private VRTK_ControllerActions controllerActionsL;
		private VRTK_ControllerEvents controllerEventsL;
		private VRTK_ControllerActions controllerActionsR;
		private VRTK_ControllerEvents controllerEventsR;
		private bool clickable;
		private float timeStamp;
		private bool menuOpen;
		private Vector3 menuOpenPosition;
		private Vector3 menuClosedPosition;
		private bool reset;
		private bool tooltipsActive;
		public bool mainMenu=false;
		LevelLoader levelLoader;
		void Start () 
		{
			
			clickable = true;
			reset = true;
			if (startOpen == false) {
				menuOpen = false;
			}else{
				menuOpen = true;
			}
			leftController = GameObject.Find ("LeftController");
			rightController = GameObject.Find ("RightController");
			controllerEventsL = leftController.GetComponent<VRTK_ControllerEvents> ();
			controllerEventsR = rightController.GetComponent<VRTK_ControllerEvents> ();
			controllerActionsL = leftController.GetComponent<VRTK_ControllerActions> ();
			controllerActionsR = rightController.GetComponent<VRTK_ControllerActions> ();
			//controllerEventsL.SubscribeToButtonAliasEvent (VRTK_ControllerEvents.ButtonAlias.Button_Two_Press, true, MenuButtonPressed);
			//controllerEventsR.SubscribeToButtonAliasEvent (VRTK_ControllerEvents.ButtonAlias.Button_Two_Press, true, MenuButtonPressed);
			levelLoader = GameObject.Find ("LevelLoader").GetComponent<LevelLoader> ();
		}

		void MenuButtonPressed(object sender, ControllerInteractionEventArgs e){
			if (!mainMenu) {
				if (clickable == true) {
					clickable = false;
					timeStamp = Time.time;
					controllerActionsL.TriggerHapticPulse (1.0f);
					controllerActionsR.TriggerHapticPulse (1.0f);
					if (menuOpen == false) {
						gameObject.transform.position = viveMenuSpot.transform.position;
						menuOpen = true;
					} else {
						gameObject.transform.position = new Vector3 (0, -200, 0);
						menuOpen = false;
					}
				}
			}else{
				if (clickable == true) {
					clickable = false;
					timeStamp = Time.time;
					controllerActionsL.TriggerHapticPulse (1.0f);
					controllerActionsR.TriggerHapticPulse (1.0f);
					if (menuOpen == false) {
						gameObject.transform.position = viveMenuSpot.transform.position;
						menuOpen = true;
					} else {
						gameObject.transform.position = new Vector3 (0, -200, 0);
						menuOpen = false;
					}
				}
			}
		}

		void Update()
		{
			if (clickable == false) {
				if (Time.time > timeStamp + 1.0f) {
					clickable = true;
				}
			}

			if(reset==false){
				if(Time.time>timeStamp+5.0f){
					reset = true;
				}
			}

			if(controllerEventsL.buttonTwoPressed== true && controllerEventsR.buttonTwoPressed == true){
				if (!mainMenu) {
					clickable = false;
					reset = false;
					timeStamp = Time.time;
				}
				else
				{
					clickable = false;
					reset = false;
					timeStamp = Time.time;
				}
			}
		}

		//add level loader
		public void MainMenu(){
			levelLoader.LoadNewScene (0);
		}

		//add level loader
		public void Restart(){
			Time.timeScale = 1;
			int i = SceneManager.GetActiveScene ().buildIndex;
			levelLoader.LoadNewScene (i);
			//SceneManager.LoadScene (i);
		}
	}
}