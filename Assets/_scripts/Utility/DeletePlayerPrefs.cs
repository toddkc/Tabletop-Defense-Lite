using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour {

	public bool delete = false;

	void Start(){
		if (delete) {
			PlayerPrefs.DeleteAll ();
		}
	}
}
