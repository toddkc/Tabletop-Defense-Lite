namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using VRTK;

	public class MapSelectButton : MonoBehaviour {
		private VRTK_ControllerActions controllerActions;
		public int sceneNumber;


		void OnTriggerEnter(Collider coll)
		{
			controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
			controllerActions.TriggerHapticPulse (1.0f);
		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true) 
			{
				SceneManager.LoadScene (sceneNumber);
			}
		}
	}
}