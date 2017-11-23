using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TimeScaleAdjust : MonoBehaviour {

	public float timeScale;
	VRTK_ControllerActions controllerActions;

	void OnTriggerEnter(Collider coll){
		if (coll.name == "Head" || coll.name=="Ring") {
			controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
			controllerActions.TriggerHapticPulse (1.0f);
		}
	}
	void OnTriggerStay(Collider coll){
		if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true){
			Time.timeScale = timeScale;
		}
	}
}
