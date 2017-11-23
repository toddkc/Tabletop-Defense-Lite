namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

	public class WaveStats : MonoBehaviour {

		#region Variables
		//access other scripts
		private MobStats mobStats;
		private MobSpawner mobSpawner;
		private TDLevelManager levelmanager;
		private MapWaves mapWaves;
		[Space(10)]
		[Tooltip("Delay between waves starting.")]
		public float timeBetweenWaves;
		//stores countdown between waves
		private float timeLeft;
		//stores display info
		[Header("Object Links")]
		public GameObject[] gems;
		public GameObject startButton;
		public GameObject countdownTimer;
		public GameObject winText;
		private TextMesh countdownTimerText;
		private Text tmProCountdown;
		public TextMesh waveCounter;
		public Text tmProWaveCounter;
		public TextMesh mobsTotalText;
		public Text tmProMobCounter;
		//each wave spawns to this number
		[HideInInspector]
		public int mobsTotalThisWave;

		//keep track of each wave that we have done
		private bool wave1Complete = false;
		private bool wave2Complete = false;
		private bool wave3Complete = false;
		private bool wave4Complete = false;
		private bool wave5Complete = false;
		private bool wave6Complete = false;
		private bool wave7Complete = false;
		private bool wave8Complete = false;
		private bool wave9Complete = false;
		private bool wave10Complete = false;

		//needs to be toggled by start button in game to begin first wave
		[HideInInspector]
		public bool gameStarted;
		//are we in a wave or between
		[HideInInspector]
		public bool waveActive;
		//are baddies still spawning
		[HideInInspector]
		public bool waveSpawning;
		//ten waves or unlimited?
		[HideInInspector]
		public bool infiniteWaves;
		private bool gameOver = false;
		[Header("Mobs per Wave")]
		public int waveOneMobs;
		public int waveTwoMobs;
		public int waveThreeMobs;
		public int waveFourMobs;
		public int waveFiveMobs;
		public int waveSixMobs;
		public int waveSevenMobs;
		public int waveEightMobs;
		public int waveNineMobs;
		public int waveTenMobs;

		[HideInInspector]
		public int highestWave;
		public int waveRecord;
		[HideInInspector]
		public bool flawless = true;
		[Header ("Freebuild Map")]
		public bool freebuild;
		string playerName;
		bool startFreebuildWaves = false;
		int freebuildWaveMultiplier=12;
		#endregion

		void Start(){
			//not in a wave
			waveActive = false;
			//game isn't active
			gameStarted = false;
			//mobs not spawning
			waveSpawning = false;
			//get scripts
			mapWaves = GetComponent<MapWaves> ();
			mobStats = GetComponent<MobStats> ();
			mobSpawner = GetComponent<MobSpawner> ();
			levelmanager = GetComponent<TDLevelManager> ();
			waveRecord = PlayerPrefs.GetInt (levelmanager.mapName+"Waves");
			//set display
			tmProCountdown=countdownTimer.GetComponent<Text>();
			//currently only made it to wave 1
			highestWave = 1;
			//all mob info 0 to start
			mobStats.mobsCurrentlyActive = 0;
			mobStats.mobsSpawnedThisWave = 0;
			mapWaves.CountdownOne ();
			tmProWaveCounter.text = 1.ToString ();
			tmProMobCounter.text = waveOneMobs.ToString ();
			if(freebuild){
				if(PlayerPrefs.HasKey("name")){
					playerName = PlayerPrefs.GetString ("name");
				}
			}
		}

		void UpdateLeaderboard(){
			if(playerName == null){
				playerName = PlayerPrefs.GetString ("name");
			}
		}

		//check that record was beat and save, or don't save
		public void UpdateHighestWave(){
			if(highestWave>waveRecord){
				levelmanager.SaveWaveStats ();
			}
		}

		//switches between wave state and countdown state
		void Update()
		{
			//do nothing if game isn't started
			if(gameStarted==false){
				return;
			}
			//keep track of wave/countdown state
			if(waveActive==false)
			{
				DuringCountdown ();
			}
			else
			{
				DuringWave ();
			}
		}

		//keeps track of countdown timer and starts next wave
		void DuringCountdown()
		{
			string count = Mathf.Round (timeLeft).ToString ();
			tmProCountdown.text = count;
			timeLeft -= Time.deltaTime;
			if(timeLeft<=0)
			{
				if (!wave10Complete) {
					NextWave ();
				}else{
					NextWaveFreebuild ();
				}
			}
		}

		//keeps track of mobs and starts countdown when wave is finished
		void DuringWave()
		{
			if(mobStats.mobsSpawnedThisWave >= mobsTotalThisWave)
			{
				if (waveSpawning == true) 
				{
					mapWaves.StopSpawning ();
					waveSpawning = false;
				}
				if(mobStats.mobsCurrentlyActive<=0)
				{
					if (wave10Complete == false) {
						Countdown ();
					} else {
						if (gameOver == false) {
							if (!freebuild) {
								gameOver = true;
								WinGame ();
							}else{
								CountdownFreebuild();
							}
						}
					}
				}
			}
		}

		//toggle wave active, turn on counter
		void Countdown()
		{
			waveActive = false;
			countdownTimer.SetActive (true);
			startButton.SetActive (true);
			timeLeft = timeBetweenWaves;
			highestWave++;
			UpdateHighestWave ();
			if(freebuild){
				UpdateLeaderboard ();
			}
			mobsTotalThisWave = 0;
			mobStats.mobsCurrentlyActive = 0;
			mobStats.mobsSpawnedThisWave = 0;
			tmProWaveCounter.text=highestWave.ToString();
			if (wave2Complete == false) {
				mapWaves.CountdownTwo ();
				tmProMobCounter.text = waveTwoMobs.ToString ();
			} else if (wave3Complete == false) {
				mapWaves.CountdownThree ();
				tmProMobCounter.text = waveThreeMobs.ToString ();
			} else if (wave4Complete == false){
				mapWaves.CountdownFour ();
				tmProMobCounter.text = waveFourMobs.ToString ();
			} else if (wave5Complete == false){
				mapWaves.CountdownFive ();
				tmProMobCounter.text = waveFiveMobs.ToString ();
			} else if (wave6Complete == false){
				mapWaves.CountdownSix ();
				tmProMobCounter.text = waveSixMobs.ToString ();
			} else if (wave7Complete == false){
				mapWaves.CountdownSeven();
				tmProMobCounter.text = waveSevenMobs.ToString ();
			} else if (wave8Complete == false){
				mapWaves.CountdownEight ();
				tmProMobCounter.text = waveEightMobs.ToString ();
			} else if (wave9Complete == false){
				mapWaves.CountdownNine ();
				tmProMobCounter.text = waveNineMobs.ToString ();
			} else if (wave10Complete == false){
				mapWaves.CountdownTen ();
				tmProMobCounter.text = waveTenMobs.ToString ();
			}
		}
		void CountdownFreebuild(){
			waveActive = false;
			countdownTimer.SetActive (true);
			startButton.SetActive (true);
			timeLeft = timeBetweenWaves;
			highestWave++;
			UpdateHighestWave ();
			UpdateLeaderboard ();
			mobsTotalThisWave = 0;
			mobStats.mobsCurrentlyActive = 0;
			mobStats.mobsSpawnedThisWave = 0;
			tmProWaveCounter.text=highestWave.ToString();
			var mobcount = ((freebuildWaveMultiplier * 7) + ((freebuildWaveMultiplier / 2) * 3));
			//var mobcount = ((highestWave - 3) * 10) + ((highestWave - 3) * 3);
			if(highestWave % 5 == 0){
				mobcount++;
			}
			if(highestWave % 10 == 0){
				mobcount++;
			}
			tmProMobCounter.text = mobcount.ToString ();
		}

		//toggles startbutton, wave bools, updates counter, and selects next wave method
		public void NextWave(){
			if (!startFreebuildWaves) {
				countdownTimer.SetActive (false);
				startButton.SetActive (false);
				waveActive = true;
				waveSpawning = true;
				mobStats.mobsCurrentlyActive = 0;
				mobStats.mobsSpawnedThisWave = 0;
				if (wave1Complete == false) {
					Wave1 ();
				} else if (wave2Complete == false) {
					Wave2 ();
				} else if (wave3Complete == false) {
					Wave3 ();
				} else if (wave4Complete == false) {
					Wave4 ();
				} else if (wave5Complete == false) {
					Wave5 ();
				} else if (wave6Complete == false) {
					Wave6 ();
				} else if (wave7Complete == false) {
					Wave7 ();
				} else if (wave8Complete == false) {
					Wave8 ();
				} else if (wave9Complete == false) {
					Wave9 ();
				} else if (wave10Complete == false) {
					Wave10 ();
					if (freebuild) {
						startFreebuildWaves = true;
					}
				}
			}else{
				NextWaveFreebuild ();
			}
		}

		void NextWaveFreebuild(){
			countdownTimer.SetActive (false);
			startButton.SetActive (false);
			waveActive = true;
			waveSpawning = true;
			mobStats.mobsCurrentlyActive = 0;
			mobStats.mobsSpawnedThisWave = 0;
			mobsTotalThisWave = ((freebuildWaveMultiplier * 7) + ((freebuildWaveMultiplier / 2) * 3));
			//mobsTotalThisWave = ((highestWave-3)*10)+((highestWave-3)*3);
			if(highestWave % 5 == 0){
				mobsTotalThisWave++;
			}
			if(highestWave % 10 == 0){
				mobsTotalThisWave ++;
			}
			mapWaves.EndlessWave (highestWave, mobsTotalThisWave);
			freebuildWaveMultiplier += 2;
		}

		//what happens if we win, needs more stuff
		public void WinGame(){
			winText.SetActive(true);
			mapWaves.WinMap ();
			levelmanager.TowersBuilt ();
			if(flawless==true){
				levelmanager.FlawlessSave ();
			}
			foreach(GameObject gem in gems){
				var script = gem.GetComponent<Gem> ();
				script.Win ();
			}
		}

		#region Waves

		void Wave1()
		{
			foreach(GameObject gem in gems){
				var script = gem.GetComponent<Gem> ();
				script.GemStart ();
			}
			//set total mobs
			mobsTotalThisWave = waveOneMobs;
			//set wave complete
			wave1Complete = true;
			//run map specific script wave one method
			mapWaves.WaveOne ();
		}
		void Wave2()
		{
			mobsTotalThisWave = waveTwoMobs;
			wave2Complete = true;
			mapWaves.WaveTwo ();
		}
		void Wave3()
		{
			mobsTotalThisWave = waveThreeMobs;
			wave3Complete = true;
			mapWaves.WaveThree ();
		}
		void Wave4()
		{
			mobsTotalThisWave = waveFourMobs;
			wave4Complete = true;
			mapWaves.WaveFour ();
		}
		void Wave5()
		{
			mobsTotalThisWave = waveFiveMobs;
			wave5Complete = true;
			mapWaves.WaveFive ();
		}
		void Wave6()
		{
			mobsTotalThisWave = waveSixMobs;
			wave6Complete = true;
			mapWaves.WaveSix ();
		}
		void Wave7()
		{
			mobsTotalThisWave = waveSevenMobs;
			wave7Complete = true;
			mapWaves.WaveSeven ();
		}
		void Wave8()
		{
			mobsTotalThisWave = waveEightMobs;
			wave8Complete = true;
			mapWaves.WaveEight ();
		}
		void Wave9()
		{
			mobsTotalThisWave = waveNineMobs;
			wave9Complete = true;
			mapWaves.WaveNine ();
		}
		void Wave10()
		{
			mobsTotalThisWave = waveTenMobs;
			wave10Complete = true;
			mapWaves.WaveTen ();
		}
		#endregion


	}
}