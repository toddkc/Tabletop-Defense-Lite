namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

	public class SavedInfo : MonoBehaviour {

		//public int mapNumber;
		public string mapName;
		int wave;
		int towers;
		public Text highestWave;
		public Text towersBuilt;
		public GameObject waveText;
		public GameObject towerText;
		public GameObject flawless;

		void Start(){

			//waves
			if(PlayerPrefs.HasKey (mapName + "Waves")){
				wave = PlayerPrefs.GetInt (mapName + "Waves");
				highestWave.text = wave.ToString ();
			}else{
				PlayerPrefs.SetInt (mapName + "Waves", 1);
			}

			//towers
			if(PlayerPrefs.HasKey(mapName + "Towers")){
				towers = PlayerPrefs.GetInt (mapName + "Towers");
				waveText.SetActive (false);
				towerText.SetActive (true);
				towersBuilt.text = towers.ToString ();
			}

			//flawless
			if(PlayerPrefs.GetInt(mapName + "Flawless")==1){
				flawless.SetActive (true);
			}

			/*
			//check highest wave of map, one if none
			if(PlayerPrefs.HasKey(mapNumber.ToString())==false)
			{
				PlayerPrefs.SetInt (mapNumber.ToString (), 1);
				highestWave.text = 1.ToString ();
			}else{
				wave = PlayerPrefs.GetInt (mapNumber.ToString ());
				highestWave.text = wave.ToString ();
			}

			//check tower score on map
			if (PlayerPrefs.HasKey ("towers" + mapNumber.ToString ())) {
				towers = PlayerPrefs.GetInt ("towers" + mapNumber.ToString ());
				waveText.SetActive (false);
				towerText.SetActive (true);
				towersBuilt.text = towers.ToString ();
			}

			//check for flawless 0 or 1, 0 if none
			if(PlayerPrefs.HasKey("flawless"+mapNumber.ToString())==false)
			{
				PlayerPrefs.SetInt ("flawless" + mapNumber.ToString (), 0);
			}
			//if flawless 1, set display active
			if(PlayerPrefs.GetInt("flawless"+mapNumber.ToString())==1)
			{
				flawless.SetActive (true);
			}
			*/
		}
	}
}