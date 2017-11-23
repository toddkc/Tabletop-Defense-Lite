namespace TowerDefense{
	using UnityEngine;

	public class MapFive : MapWaves {

		private MobSpawner mobSpawner;
		private WaypointManager waypointManager;
		public GameObject winStuff;

		void Awake()
		{
			waypointManager = GetComponent<WaypointManager> ();
			mobSpawner = GetComponent<MobSpawner> ();
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
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 5.0f, 0, 1);

			StartCoroutine (basicMobSpawn1);
		}
		#endregion
		#region Wave Two
		public override void CountdownTwo(){
			waypointManager.paths [1].spawnAura.SetActive (true);

		}
		public override void WaveTwo()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 1);
			StartCoroutine (basicMobSpawn2);
		}
		#endregion
		#region Wave Three
		public override void CountdownThree(){

		}
		public override void WaveThree()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 10.0f, 0, 1);

			StartCoroutine (basicMobSpawn1);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 1);
			StartCoroutine (basicMobSpawn2);
		}
		#endregion
		#region Wave Four
		public override void CountdownFour(){

		}
		public override void WaveFour()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 8.0f, 0, 1);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 1);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 8.0f, 1, 1);
			StartCoroutine (rangedMobSpawn2);
		}
		#endregion
		#region Wave Five
		public override void CountdownFive(){
			waypointManager.paths [2].spawnAura.SetActive (true);

		}
		public override void WaveFive()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 8.0f, 0, 1);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 1);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 8.0f, 1, 1);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 6.0f, 2, 1);
			StartCoroutine (flyingMobSpawn1);
		}
		#endregion
		#region Wave Six
		public override void CountdownSix(){
			waypointManager.paths [3].spawnAura.SetActive (true);

		}
		public override void WaveSix()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 1);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 8.0f, 0, 1);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 1);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 8.0f, 1, 1);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 6.0f, 2, 1);
			StartCoroutine (flyingMobSpawn1);
			var flyingMobSpawn2 = mobSpawner.MobSpawn ("Flying", 6.0f, 3, 1);
			StartCoroutine (flyingMobSpawn2);
		}
		#endregion
		#region Wave Seven
		public override void CountdownSeven(){

		}
		public override void WaveSeven()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 2);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 7.0f, 0, 1);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 2);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 7.0f, 1, 1);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 5.0f, 2, 1);
			StartCoroutine (flyingMobSpawn1);
			var flyingMobSpawn2 = mobSpawner.MobSpawn ("Flying", 5.0f, 3, 1);
			StartCoroutine (flyingMobSpawn2);
		}
		#endregion
		#region Wave Eight
		public override void CountdownEight(){

		}
		public override void WaveEight()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 2);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 7.0f, 0, 2);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 2);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 7.0f, 1, 2);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 5.0f, 2, 1);
			StartCoroutine (flyingMobSpawn1);
			var flyingMobSpawn2 = mobSpawner.MobSpawn ("Flying", 5.0f, 3, 1);
			StartCoroutine (flyingMobSpawn2);
		}
		#endregion
		#region Wave Nine
		public override void CountdownNine(){

		}
		public override void WaveNine()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 2);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.5f, 0, 2);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 2);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 6.5f, 1, 2);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 2, 2);
			StartCoroutine (flyingMobSpawn1);
			var flyingMobSpawn2 = mobSpawner.MobSpawn ("Flying", 4.0f, 3, 2);
			StartCoroutine (flyingMobSpawn2);
		}
		#endregion
		#region Wave Ten
		public override void CountdownTen(){

		}

		public override void WaveTen()
		{
			var basicMobSpawn1 = mobSpawner.MobSpawn ("Basic", 4.0f, 0, 3);
			StartCoroutine (basicMobSpawn1);
			var rangedMobSpawn1 = mobSpawner.MobSpawn ("Ranged", 6.5f, 0, 3);
			StartCoroutine (rangedMobSpawn1);
			var basicMobSpawn2 = mobSpawner.MobSpawn ("Basic", 4.0f, 1, 2);
			StartCoroutine (basicMobSpawn2);
			var rangedMobSpawn2 = mobSpawner.MobSpawn ("Ranged", 6.5f, 1, 2);
			StartCoroutine (rangedMobSpawn2);
			var flyingMobSpawn1 = mobSpawner.MobSpawn ("Flying", 4.0f, 2, 2);
			StartCoroutine (flyingMobSpawn1);
			var flyingMobSpawn2 = mobSpawner.MobSpawn ("Flying", 4.0f, 3, 2);
			StartCoroutine (flyingMobSpawn2);

			var boss = mobSpawner.SpawnSingle ("Boss", 20, 1, 0, 1);
			StartCoroutine (boss);
		}
		#endregion
		public override void WinMap(){
			winStuff.SetActive (true);
		}
	
	}
}