namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class WaveStartButton : MonoBehaviour {

		private GameObject levelManager;
		private WaveStats waveStats;
		private VRTK_ControllerActions controllerActions;

		void Start(){
			levelManager = GameObject.Find ("LevelManager");
			waveStats = levelManager.GetComponent<WaveStats> ();
		}

		public void StartWave(){
			if (waveStats.gameStarted == false) 
			{
				waveStats.gameStarted = true;
			} else 
			{
				waveStats.NextWave ();
			}
		}

		// for testing
		void Update(){
			if(Input.GetKeyDown (KeyCode.Backspace)){
				StartWave ();
			}
		}

		void OnTriggerEnter(Collider coll)
		{
			controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
			controllerActions.TriggerHapticPulse (1.0f);
			StartWave ();
		}

	}
}