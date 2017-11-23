using UnityEngine;

public class FollowItem : MonoBehaviour {

	public GameObject followThis;
	[HideInInspector]
	public bool isEnabled=true;

	void FixedUpdate(){
		if (isEnabled) {
			transform.position = followThis.transform.position;
		}
	}

}
