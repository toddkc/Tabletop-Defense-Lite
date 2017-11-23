namespace TowerDefense{
using UnityEngine;
using VRTK;

public class MenuButton : MonoBehaviour {

	#region Variables
		[Header("Menu Buttons")]
		public bool restartButton;
		public bool menuButton;
		public bool quitButton;
		public bool backdropOne;
		public bool backdropTwo;
		public bool backdropThree;

		private Menu menu;
		private VRTK_ControllerActions controllerActions;
		private bool clickable;
		private float timeStamp;
		public GameObject levelManager;
	#endregion

		void Start () 
		{
			menu = GetComponentInParent<Menu> ();
			clickable = true;
		}
			
		void Update()
		{
				
			if(clickable == false)
			{
				if (Time.time > timeStamp + 0.5f) 
				{
					clickable = true;
				}
			}
		}
			
		void OnTriggerEnter(Collider coll)
		{
			if (coll.name == "Head" || coll.name=="Ring") {
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
				controllerActions.TriggerHapticPulse (1.0f);
			}
		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable == true) 
			{
				if (restartButton == true) 
				{
					if(levelManager)
					{
						levelManager.GetComponent<TDLevelManager> ().Save ();
					}
					menu.Restart();
				} 
				else if (menuButton == true) 
				{
					if(levelManager)
					{
						levelManager.GetComponent<TDLevelManager> ().Save ();
					}
					menu.MainMenu();
					//SceneManager.LoadScene (0);
				}
				else if (quitButton == true) 
				{
					if(levelManager)
					{
						levelManager.GetComponent<TDLevelManager> ().Save ();
					}
					Application.Quit ();
				}
				clickable = false;
				timeStamp = Time.time;
			}
		}
	}
}