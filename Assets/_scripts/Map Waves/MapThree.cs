namespace TowerDefense{
using UnityEngine;

public class MapThree : MapWaves {

		private MobSpawner mobSpawner;
		private WaypointManager waypointManager;
		public GameObject winStuff;

		void Awake(){
			waypointManager = GetComponent<WaypointManager> ();
			mobSpawner = GetComponent<MobSpawner> ();
		}
		public override void StopSpawning(){
			StopAllCoroutines ();
		}
		public override void CountdownOne(){
			waypointManager.paths [0].spawnAura.SetActive (true);
		}
		public override void WaveOne(){
			//4
			var group = mobSpawner.GroupSpawnBasicOnly (4, 10, 1, 0, 1);
			StartCoroutine (group);
		}
		public override void WaveTwo(){
			//8, 4 groups of 2 basic
			var group = mobSpawner.GroupSpawnBasicOnly (2, 3, 5, 0, 1);
			StartCoroutine (group);
		}
		public override void WaveThree(){
			//17, three groups of 4 basic, one ranged between groups
			var group = mobSpawner.GroupSpawnBasicOnly (5, 5, 5, 0, 1);
			StartCoroutine (group);
			var ranged = mobSpawner.SpawnSingle ("Ranged", 5, 5, 0, 1);
			var ranged2 = mobSpawner.SpawnSingle ("Ranged", 11, 5, 0, 1);
			StartCoroutine (ranged);
			StartCoroutine (ranged2);
		}
		public override void CountdownFour(){
			waypointManager.paths [1].spawnAura.SetActive (true);
		}
		public override void WaveFour(){
			//21 4 groups of 5, 2 singles
			var group = mobSpawner.GroupSpawnFourBasicOneRanged (5, 3, 0, 1, 1);
			StartCoroutine (group);
			var flyingMobSpawn1 = mobSpawner.SpawnSingle ("Flying", 10, 5, 1, 1);
			StartCoroutine (flyingMobSpawn1);
		}
		public override void WaveFive(){
			//31 5 groups of 5, 2 groups of 3
			var group = mobSpawner.GroupSpawnFourBasicOneRanged (5, 0, 0, 2, 1);//20
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirGroup (3, 3, 41, 1, 1);//50
			StartCoroutine (air);
		}
		public override void WaveSix(){
			//36 5 groups of 6, 2 groups of 3
			var group = mobSpawner.GroupSpawnFourBasicTwoRanged (5, 0, 0, 2, 1);//20 sec
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirGroup (3, 2, 44, 1, 1);//50
			StartCoroutine (air);
		}
		public override void WaveSeven(){
			//42 5 groups of 6, 4 groups of 3
			var group = mobSpawner.GroupSpawnFourBasicTwoRanged (4, 4, 0, 2, 2);//20
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirShooterGroup (2, 19, 1, 1);//25
			StartCoroutine (air);
		}
		public override void WaveEight(){
			//47 5 groups of 7, 4 groups of 3
			var group = mobSpawner.GroupSpawnFiveBasicTwoRanged (4, 0, 0, 3, 2); //20
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirShooterGroup (2, 27.3f, 1, 1);//33.3
			StartCoroutine (air);
		}
		public override void WaveNine(){
			//54 6 groups of 7, 4 groups of 3
			var group = mobSpawner.GroupSpawnFiveBasicTwoRanged (4, 4, 0, 3, 2); //24
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirShooterGroup (2, 30, 1, 2);//36
			StartCoroutine (air);
		}
		public override void WaveTen(){
			//65 7 groups of 7, 5 groups of 3
			var group = mobSpawner.GroupSpawnFiveBasicTwoRanged (4, 5, 0, 3, 3);//25
			StartCoroutine (group);
			var air = mobSpawner.SpawnAirShooterGroup (2, 29, 1, 2);//35
			StartCoroutine (air);
			var boss = mobSpawner.SpawnSingle ("Boss", 32, 1, 0, 1);
			StartCoroutine (boss);
		}
		public override void WinMap(){
			winStuff.SetActive (true);
		}
	}
}
