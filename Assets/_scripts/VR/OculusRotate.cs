namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class OculusRotate : MonoBehaviour {
		private GameObject leftController;
		private GameObject rightController;
		private VRTK_ControllerEvents controllerEventsL;
		private VRTK_ControllerEvents controllerEventsR;
		public GameObject viveCameraRig;

		void Start(){
			leftController = GameObject.Find ("LeftController");
			rightController = GameObject.Find ("RightController");
			controllerEventsL = leftController.GetComponent<VRTK_ControllerEvents> ();
			controllerEventsR = rightController.GetComponent<VRTK_ControllerEvents> ();
			//controllerEventsL.SubscribeToButtonAliasEvent (VRTK_ControllerEvents.ButtonAlias.Button_One_Press, true, RotateCCW);
			//controllerEventsR.SubscribeToButtonAliasEvent (VRTK_ControllerEvents.ButtonAlias.Button_One_Press, true, RotateCW);
		}

		void RotateCCW(object sender, ControllerInteractionEventArgs e){
			viveCameraRig.transform.Rotate (0, -90, 0);
		}

		void RotateCW(object sender, ControllerInteractionEventArgs e){
			viveCameraRig.transform.Rotate (0, 90, 0);
		}
	}
}