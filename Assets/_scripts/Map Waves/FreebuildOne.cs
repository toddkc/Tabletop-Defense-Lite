namespace TowerDefense{
	using UnityEngine;

	public class FreebuildOne : MapWaves {
		private MobSpawner mobSpawner;
		private WaypointManager waypointManager;
		public GameObject winStuff;
		int basicLevel, rangedLevel, smallBossLevel, bigBossLevel, flyerLevel;

		void Awake()
		{
			basicLevel = 4;
			rangedLevel = 3;
			flyerLevel = 4;
			smallBossLevel = 2;
			bigBossLevel = 3;
			waypointManager = GetComponent<WaypointManager> ();
			mobSpawner = GetComponent<MobSpawner> ();
			QualitySettings.shadows = ShadowQuality.Disable;
		}

		public override void StopSpawning()
		{
			StopAllCoroutines ();
		}

		#region Wave One
		public override void CountdownOne(){
			waypointManager.paths [0].spawnAura.SetActive (true);
		}
		public override void WaveOne()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);

			StartCoroutine (basicMobSpawn1);
		}
		#endregion
		#region Wave Two
		public override void CountdownTwo(){

		}
		public override void WaveTwo()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);



		}
		#endregion
		#region Wave Three
		public override void CountdownThree(){
		}
		public override void WaveThree()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 12.5f, 0, 1);
			StartCoroutine (rangedMobSpawn1);



		}
		#endregion
		#region Wave Four
		public override void CountdownFour(){
			
		}
		public override void WaveFour()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 2);
			StartCoroutine (basicMobSpawn1);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 8.5f, 0, 1);
			StartCoroutine (rangedMobSpawn1);

		}
		#endregion
		#region Wave Five
		public override void CountdownFive(){
			waypointManager.paths [1].spawnAura.SetActive (true);
		}
		public override void WaveFive()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 2);
			StartCoroutine (basicMobSpawn1);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 7.0f, 0, 1);
			StartCoroutine (rangedMobSpawn1);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 8.0f, 1, 1);
			StartCoroutine (flyingMobSpawn1);


		}
		#endregion
		#region Wave Six
		public override void CountdownSix(){
			
		}
		public override void WaveSix()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 2);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 2);

			StartCoroutine (basicMobSpawn1);

			StartCoroutine (rangedMobSpawn1);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 6.5f, 1, 1);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion
		#region Wave Seven
		public override void CountdownSeven(){
			
		}
		public override void WaveSeven()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 2);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 2);

			StartCoroutine (basicMobSpawn1);

			StartCoroutine (rangedMobSpawn1);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 5.0f, 1, 2);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion
		#region Wave Eight
		public override void CountdownEight(){
			
		}
		public override void WaveEight()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 3);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 2);

			StartCoroutine (basicMobSpawn1);

			StartCoroutine (rangedMobSpawn1);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 5.0f, 1, 2);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion
		#region Wave Nine
		public override void CountdownNine(){
			
		}
		public override void WaveNine()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 3);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 3);

			StartCoroutine (basicMobSpawn1);
			StartCoroutine (rangedMobSpawn1);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 5.0f, 1, 2);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion
		#region Wave Ten
		public override void CountdownTen(){

		}
		public override void WaveTen()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 3);

			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 3);

			StartCoroutine (basicMobSpawn1);

			StartCoroutine (rangedMobSpawn1);

			var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 1);
			StartCoroutine (boss1);

			var boss2 = mobSpawner.SpawnSingle ("Boss2", 70, 1, 0, 2);
			StartCoroutine (boss2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 2);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion

		//will have 3 flyers for every 10 ground
		public override void EndlessWave(int wave, int mobs){
			
			var ground = mobSpawner.GroupSpawnFiveBasicTwoRanged (3, 0, 0, basicLevel, rangedLevel); //15 seconds
			StartCoroutine (ground);
			var air = mobSpawner.SpawnAirShooterGroup (2, 24, 1, flyerLevel);//30 seconds
			StartCoroutine (air);
			if(wave % 5 == 0){
				var spawn = Mathf.RoundToInt (mobs * 0.2f);
				var boss1 = mobSpawner.SpawnSingle ("Boss", spawn, 1, 0, smallBossLevel);
				StartCoroutine (boss1);
				basicLevel++;
				rangedLevel++;
				flyerLevel++;
			}
			if(wave % 10 == 0){
				var spawn2 = Mathf.RoundToInt (mobs * 0.7f);
				var boss2 = mobSpawner.SpawnSingle ("Boss2", spawn2, 1, 0, bigBossLevel);
				StartCoroutine (boss2);
				smallBossLevel++;
				bigBossLevel++;
			}
		}

		//70/15(85), 77/15(92), 84/18(102), 91/18(109), 98/21(119), 



		/*
		public override void EndlessWave(int wave){
			if (wave < 15) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 4);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 3);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 3);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 15) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 4);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 3);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 3);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 2);
				StartCoroutine (boss1);
			} else if (wave > 15 && wave < 20) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 4);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 4);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 3);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 20) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 4);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 4);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 3);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 2);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 3);
				StartCoroutine (boss2);
			} else if (wave > 20 && wave < 25) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 5);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 4);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 4);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 25) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 5);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 4);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 4);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 3);
				StartCoroutine (boss1);
			} else if (wave > 25 && wave < 30) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 5);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 5);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 4);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 30) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 5);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 5);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 4);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 3);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 4);
				StartCoroutine (boss2);
			} else if (wave > 30 && wave < 35) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 6);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 5);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 5);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 35) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 6);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 5);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 5);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 4);
				StartCoroutine (boss1);
			} else if (wave > 35 && wave < 40) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 6);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 6);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 5);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 40) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 6);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 6);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 5);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 4);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 5);
				StartCoroutine (boss2);
			} else if (wave > 40 && wave < 45) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 7);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 6);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 6);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 45) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 7);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 6);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 6);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 5);
				StartCoroutine (boss1);
			} else if (wave > 45 && wave < 50) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 7);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 7);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 6);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 50) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 7);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 7);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 6);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 5);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 6);
				StartCoroutine (boss2);
			} else if (wave > 50 && wave < 55) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 8);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 7);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 7);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 55) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 8);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 7);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 7);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 6);
				StartCoroutine (boss1);
			} else if (wave > 55 && wave < 60) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 8);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 8);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 7);
				StartCoroutine (flyingMobSpawn1);
			} else if (wave == 60) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 8);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 8);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 7);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 6);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 7);
				StartCoroutine (boss2);
			} else if (wave > 60) {
				var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 3.0f, 0, 10);
				StartCoroutine (basicMobSpawn1);
				var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.0f, 0, 10);
				StartCoroutine (rangedMobSpawn1);
				var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 1, 10);
				StartCoroutine (flyingMobSpawn1);
				var boss1 = mobSpawner.SpawnSingle ("Boss", 25, 1, 0, 10);
				StartCoroutine (boss1);
				var boss2 = mobSpawner.SpawnSingle ("Boss", 70, 1, 0, 10);
				StartCoroutine (boss2);
			}
		}
		*/
	}
}