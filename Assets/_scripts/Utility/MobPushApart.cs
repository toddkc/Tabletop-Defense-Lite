using UnityEngine;

public class MobPushApart : MonoBehaviour {

	void Nudge(float position){
		var x = transform.position.x - position;
		Debug.Log (x);
		if (x > 0.0f){
			transform.position -= transform.right * 0.02f;
		}else if(x<0.0f){
			transform.position += transform.right * 0.02f;
		}
	}
	
	void OnTriggerStay(Collider coll){
		if (coll.tag == "Basic Mob") {
			var position = coll.transform.position.x;
			Nudge (position);
		}
	}
}
