namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class TDLevelManager : MonoBehaviour {

		[HideInInspector]
		public int mapNumber;
		public string mapName;
		private WaveStats waveStats;
		[Tooltip("Set this to the number of gems in the level.")]
		public int gemCount;
		public GameObject loseText;
		public GameObject restartButton;
		Money money;

		void Start(){
			//mapNumber = SceneManager.GetActiveScene ().buildIndex;
			waveStats = GetComponent<WaveStats> ();
			money = GetComponent<Money> ();
		}
			
		public void GemDestroyed(){
			gemCount--;
			if(gemCount<=0){
				LoseGame ();
			}
		}
	
		public void LoseGame(){
			var player = GameObject.Find ("Player").GetComponentInChildren<VRTK_BasicTeleport> ();
			player.enabled = false;
			Time.timeScale = 0.01f;
			Save ();
			loseText.SetActive (true);
			restartButton.SetActive (true);
		}

		public void FlawlessSave(){
			PlayerPrefs.SetInt (mapName + "Flawless", 1);
			//PlayerPrefs.SetInt ("flawless" + mapNumber.ToString (), 1);
			Save ();
		}

		public void Save(){
			waveStats.UpdateHighestWave ();
		}

		public void TowersBuilt(){
			if (PlayerPrefs.HasKey (mapName + "Towers")) {
				if(money.towersBuilt < PlayerPrefs.GetInt (mapName + "Towers")){
					PlayerPrefs.SetInt (mapName + "Towers", money.towersBuilt);
					PlayerPrefs.Save ();
				}
			}else{
				PlayerPrefs.SetInt (mapName + "Towers", money.towersBuilt);
				PlayerPrefs.Save ();
			}

			/*
			if(PlayerPrefs.HasKey("towers" + mapNumber.ToString())){
				if(money.towersBuilt < PlayerPrefs.GetInt("towers" + mapNumber.ToString())){
					PlayerPrefs.SetInt ("towers" + mapNumber.ToString (), money.towersBuilt);
					PlayerPrefs.Save ();
				}
			}else{
				PlayerPrefs.SetInt ("towers" + mapNumber.ToString (), money.towersBuilt);
				PlayerPrefs.Save ();
			}
			*/

		}

		public void SaveWaveStats(){
			PlayerPrefs.SetInt (mapName + "Waves", waveStats.highestWave);
			//PlayerPrefs.SetInt (mapNumber.ToString (), waveStats.highestWave);
			PlayerPrefs.Save ();
		}
	}
}