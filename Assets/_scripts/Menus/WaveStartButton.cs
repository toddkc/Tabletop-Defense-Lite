namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class WaveStartButton : MonoBehaviour {

		public GameObject manager;
		private WaveStats waveStats;
		private VRTK_ControllerActions controllerActions;

		void Start(){
			waveStats = manager.GetComponent<WaveStats> ();
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

		void OnTriggerEnter(Collider coll)
		{
			controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
			controllerActions.TriggerHapticPulse (1.0f);

				if (waveStats.gameStarted == false) 
				{
					waveStats.gameStarted = true;
				} else 
				{
					waveStats.NextWave ();
				}
		}

	}
}