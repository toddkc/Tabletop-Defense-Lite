namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using VRTK;

	public class StartButton : MonoBehaviour {

		//need 4 of these, two to select map either solo or coop, one to start waves, one to restart game
	
		#region Variables
		private VRTK_ControllerActions controllerActions;
		public int sceneNumber;
		public GameObject levelManager;
		public GameObject mapSign;
		public GameObject waveSign;
		public Money money;
		private WaveStats waveStats;
		[HideInInspector]
		public TDLevelManager lm;
		public GameObject[] otherLevels;
		public int startingMoneySolo;
		public int startingMoneyCoop;
		public TextMesh moneyLabel;

		public bool mapSelectButton;
		public bool soloButton;
		public bool coopButton;
		public bool waveStartButton;
		public bool restartButton;

		public GameObject waveStart;
		public GameObject soloStart;
		public GameObject coopStart;

		public GameObject masterAudio;
		public GameObject audioPosition;

		public GameObject playerTwo;
		#endregion

		void Start()
		{
			waveStats = levelManager.GetComponent<WaveStats> ();
			lm = levelManager.GetComponent<TDLevelManager> ();
		}
			
		void OnTriggerEnter(Collider coll)
		{
			controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
			controllerActions.TriggerHapticPulse (1.0f);
			if (restartButton == true) 
			{
				var menu = GameObject.Find ("menu").GetComponent<Menu> ();
				menu.Restart ();
			}
			if (waveStartButton == true) 
			{
				if (waveStats.gameStarted == false) 
				{
					waveStats.gameStarted = true;
				} else 
				{
					waveStats.NextWave ();
				}
			}
		}

		void OnTriggerStay(Collider coll)
		{
			if (mapSelectButton == true) 
			{
				if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true) 
				{
					/*
					mapSign.SetActive (false);
					waveSign.SetActive (true);
					money.tm = moneyLabel;
					waveStart.SetActive (true);
					soloStart.SetActive (false);
					coopStart.SetActive (false);
					foreach (GameObject map in otherLevels) 
					{
						map.SetActive (false);
					}
					masterAudio.transform.position = audioPosition.transform.position;
					var menu = GameObject.Find ("menu").GetComponent<Menu> ();
					menu.MapSelect (levelManager);
					*/
					if (soloButton == true) 
					{
						SceneManager.LoadScene (sceneNumber);
						//waveStats.coop = false;
						//money.singlePlayer = true;
						//money.moneyMaster = startingMoneySolo;
					}
					if (coopButton == true) 
					{
						SceneManager.LoadScene (sceneNumber);
						//waveStats.coop = true;
						//money.singlePlayer = false;
						//money.moneyMaster = startingMoneyCoop;
						//playerTwo.transform.position = audioPosition.transform.position;
						//playerTwo.SetActive (true);
					}
				}
			}
		}
	}
}