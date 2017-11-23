namespace TowerDefense{
	using UnityEngine;

	public class MapOne : MapWaves {

		private MobSpawner mobSpawner;
		private WaypointManager waypointManager;
		public GameObject winStuff;

		void Awake(){
			waypointManager = GetComponent<WaypointManager> ();
			mobSpawner = GetComponent<MobSpawner> ();
		}
		public override void StopSpawning()	{
			StopAllCoroutines ();
		}
		public override void WinMap(){
			winStuff.SetActive (true);
		}
		public override void CountdownOne(){
			waypointManager.paths [0].spawnAura.SetActive (true);
		}
		public override void WaveOne(){
			//2 mob
			var group = mobSpawner.GroupSpawnBasicOnly (2, 6, 1, 0, 1);
			StartCoroutine (group);

		}
		public override void WaveTwo(){
			//4 mobs
			var group = mobSpawner.GroupSpawnBasicOnly (4, 6, 1, 0, 1);
			StartCoroutine (group);
		}
		public override void WaveThree(){
			//8 mobs
			var group = mobSpawner.GroupSpawnBasicOnly (4, 6, 10, 0, 1);
			StartCoroutine (group);
		}
		public override void WaveFour(){
			//13 mobs
			var group = mobSpawner.GroupSpawnBasicOnly (4, 5, 8, 0, 1);
			StartCoroutine (group);
			var rang = mobSpawner.SpawnSingle("Ranged", 6, 1, 0, 1);
			StartCoroutine (rang);
		}
		public override void WaveFive(){
			//15 mobs
			var group = mobSpawner.GroupSpawnFourBasicOneRanged (4, 7, 0, 1, 1);
			StartCoroutine (group);
		}
		public override void WaveSix(){
			//25 mobs
			var group = mobSpawner.GroupSpawnFourBasicOneRanged (3, 7, 0, 1, 1);
			StartCoroutine (group);
		}
		public override void WaveSeven(){
			//30
			var group = mobSpawner.GroupSpawnFourBasicTwoRanged (3, 7, 0, 2, 1);
			StartCoroutine (group);
		}
		public override void WaveEight(){
			//36
			var group = mobSpawner.GroupSpawnFourBasicTwoRanged (3, 7, 0, 2, 1);
			StartCoroutine (group);
		}
		public override void WaveNine(){
			//42
			var group = mobSpawner.GroupSpawnFiveBasicTwoRanged (3, 7, 0, 2, 2);
			StartCoroutine (group);
		}
		public override void WaveTen(){
			//45
			var group = mobSpawner.GroupSpawnThreeBasicOneRanged (3, 6, 0, 2, 2);
			StartCoroutine (group);
			var boss = mobSpawner.SpawnSingle ("Boss", 22, 1, 0, 1);
			StartCoroutine (boss);
		}
	}
}