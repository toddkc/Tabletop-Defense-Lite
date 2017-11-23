using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	bool running = false;

	public void LoadNewScene(int scene){
		if (!running) {
			running = true;
			SceneManager.LoadSceneAsync (scene);
		}
	}
}
