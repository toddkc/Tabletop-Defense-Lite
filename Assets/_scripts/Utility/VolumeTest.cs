using UnityEngine;
public class VolumeTest : MonoBehaviour {

	void Start () {
		Debug.Log ("pp music is " + PlayerPrefs.GetInt ("music"));
		Debug.Log ("pp tower is " + PlayerPrefs.GetFloat ("feedback"));
		Debug.Log ("pp monst is " + PlayerPrefs.GetFloat ("towers and mobs"));
	}
}
