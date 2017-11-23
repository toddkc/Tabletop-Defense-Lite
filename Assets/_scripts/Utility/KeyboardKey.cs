using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey : MonoBehaviour {

	bool clickable = true;

	void OnTriggerEnter(Collider coll){
		if (coll.name == "Head" || coll.name == "Ring") {
			if (clickable) {
				clickable = false;
				GetComponent<Button> ().onClick.Invoke ();
			}
		}
	}
	void OnTriggerExit(Collider coll){
		if (coll.name == "Head" || coll.name == "Ring") {
			clickable = true;
		}
	}
}
