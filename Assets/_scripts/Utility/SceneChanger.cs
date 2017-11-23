using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			SceneManager.LoadScene (1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			SceneManager.LoadScene (0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			SceneManager.LoadScene (2);
		}
	}
}
