namespace TowerDefense{
	using System.Collections;
	using UnityEngine;
	public class MobSpawner : MonoBehaviour {

		#region Variables
		private WaypointManager waypointManager;
		public GameObject basicMobPrefab;
		public GameObject bossMobPrefab;
		public GameObject otherBossMobPrefab;
		public GameObject rangedMobPrefab;
		public GameObject flyingMobPrefab;
		public GameObject flyerRangedMobPrefab;
		private GameObject canvas;
		[HideInInspector]
		public MobStats mobStats;
		private WaveStats waveStats;
		public bool freebuild;
		#endregion

		void Start()
		{
			mobStats = GetComponent<MobStats> ();
			waveStats = GetComponent<WaveStats> ();
			waypointManager = GetComponent<WaypointManager> ();
			canvas = GameObject.Find ("Canvas");
		}

		/// <summary>
		/// Spawns a group of basic mechs.
		/// </summary>
		/// <returns>The spawn basic only.</returns>
		/// <param name="groupSize">Group size.</param>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="level">Level.</param>
		public IEnumerator GroupSpawnBasicOnly(int groupSize, int timeBetweenMobs, int timeBetweenGroups, int mobPath, int level){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while (enabled) {
				if (basics < groupSize) {
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (level);
					mobscript.pooled = false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart ();
					yield return new WaitForSeconds (timeBetweenMobs);
				} else {
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns a group of 3 basics and 1 ranged.
		/// </summary>
		/// <returns>The spawn three basic one ranged.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="basicLevel">Basic level.</param>
		/// <param name="rangedLevel">Ranged level.</param>
		public IEnumerator GroupSpawnThreeBasicOneRanged(int timeBetweenMobs, int timeBetweenGroups, int mobPath, int basicLevel, int rangedLevel){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while(enabled){
				if(basics < 3){
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (basicLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					if(basics==2){
						mobStats.mobsCurrentlyActive++;
						mobStats.mobsSpawnedThisWave++;
						var r = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var rs = r.GetComponent<MobHealth> ();
						var rn = r.GetComponent<MobNavigation> ();
						var ra = r.GetComponentInChildren<MobAggro> ();
						rs.mobStats = mobStats;
						rs.MobStart (rangedLevel);
						rs.pooled=false;
						rn.path = path;
						rn.isRanged = true;
						if (freebuild) {
							rn.freebuild = true;
						}
						rn.NavStart();
						ra.AggroStart();
					}
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawn a group of 4 basics and 1 ranged.
		/// </summary>
		/// <returns>The spawn four basic one ranged.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="basicLevel">Basic level.</param>
		/// <param name="rangedLevel">Ranged level.</param>
		public IEnumerator GroupSpawnFourBasicOneRanged(int timeBetweenMobs, int timeBetweenGroups, int mobPath, int basicLevel, int rangedLevel){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while(enabled){
				if(basics < 4){
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (basicLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					if(basics==2){
						mobStats.mobsCurrentlyActive++;
						mobStats.mobsSpawnedThisWave++;
						var r = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var rs = r.GetComponent<MobHealth> ();
						var rn = r.GetComponent<MobNavigation> ();
						var ra = r.GetComponentInChildren<MobAggro> ();
						rs.mobStats = mobStats;
						rs.MobStart (rangedLevel);
						rs.pooled=false;
						rn.path = path;
						rn.isRanged = true;
						if (freebuild) {
							rn.freebuild = true;
						}
						rn.NavStart();
						ra.AggroStart();
					}
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns a group of 4 basics and 2 ranged.
		/// </summary>
		/// <returns>The spawn four basic two ranged.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="basicLevel">Basic level.</param>
		/// <param name="rangedLevel">Ranged level.</param>
		public IEnumerator GroupSpawnFourBasicTwoRanged(int timeBetweenMobs, int timeBetweenGroups, int mobPath, int basicLevel, int rangedLevel){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while(enabled){
				if(basics < 4){
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (basicLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					if(basics==1 || basics == 3){
						mobStats.mobsCurrentlyActive++;
						mobStats.mobsSpawnedThisWave++;
						var r = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var rs = r.GetComponent<MobHealth> ();
						var rn = r.GetComponent<MobNavigation> ();
						var ra = r.GetComponentInChildren<MobAggro> ();
						rs.mobStats = mobStats;
						rs.MobStart (rangedLevel);
						rs.pooled=false;
						rn.path = path;
						rn.isRanged = true;
						if (freebuild) {
							rn.freebuild = true;
						}
						rn.NavStart();
						ra.AggroStart();
					}
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns a group of 5 basics and 2 ranged.
		/// </summary>
		/// <returns>The spawn five basic two ranged.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="basicLevel">Basic level.</param>
		/// <param name="rangedLevel">Ranged level.</param>
		public IEnumerator GroupSpawnFiveBasicTwoRanged(int timeBetweenMobs, int timeBetweenGroups, int mobPath, int basicLevel, int rangedLevel){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while(enabled){
				if(basics < 5){
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (basicLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					if(basics==2 || basics==4){
						mobStats.mobsCurrentlyActive++;
						mobStats.mobsSpawnedThisWave++;
						var r = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var rs = r.GetComponent<MobHealth> ();
						var rn = r.GetComponent<MobNavigation> ();
						var ra = r.GetComponentInChildren<MobAggro> ();
						rs.mobStats = mobStats;
						rs.MobStart (rangedLevel);
						rs.pooled=false;
						rn.path = path;
						rn.isRanged = true;
						if (freebuild) {
							rn.freebuild = true;
						}
						rn.NavStart();
						ra.AggroStart();
					}
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns a group of 5 basics and 3 ranged.
		/// </summary>
		/// <returns>The spawn five basic three ranged.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="basicLevel">Basic level.</param>
		/// <param name="rangedLevel">Ranged level.</param>
		public IEnumerator GroupSpawnFiveBasicThreeRanged(int timeBetweenMobs, int timeBetweenGroups, int mobPath, int basicLevel, int rangedLevel){
			var path = waypointManager.paths [mobPath];
			var basics = 0;
			while(enabled){
				if(basics < 4){
					basics++;
					mobStats.basicMobsSpawned++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (basicLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					if(basics==1 || basics==2 || basics==3){
						mobStats.mobsCurrentlyActive++;
						mobStats.mobsSpawnedThisWave++;
						var r = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var rs = r.GetComponent<MobHealth> ();
						var rn = r.GetComponent<MobNavigation> ();
						var ra = r.GetComponentInChildren<MobAggro> ();
						rs.mobStats = mobStats;
						rs.MobStart (rangedLevel);
						rs.pooled=false;
						rn.path = path;
						rn.isRanged = true;
						if (freebuild) {
							rn.freebuild = true;
						}
						rn.NavStart();
						ra.AggroStart();
					}
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					basics = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns a group of air mechs.
		/// </summary>
		/// <returns>The air group.</returns>
		/// <param name="groupSize">Group size.</param>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="level">Level.</param>
		public IEnumerator SpawnAirGroup(int groupSize, float timeBetweenMobs, float timeBetweenGroups, int mobPath, int level){
			var path = waypointManager.paths [mobPath];
			var air = 0;
			while(enabled){
				if(air < groupSize){
					air++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (level);
					mobscript.pooled=false;
					mobnav.path = path;

					mobnav.NavStart();
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					air = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawns an air shooter trio.
		/// </summary>
		/// <returns>The air shooter group.</returns>
		/// <param name="timeBetweenMobs">Time between mobs.</param>
		/// <param name="timeBetweenGroups">Time between groups.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="level">Level.</param>
		public IEnumerator SpawnAirShooterGroup(float timeBetweenMobs, float timeBetweenGroups, int mobPath, int level){
			var path = waypointManager.paths [mobPath];
			var air = 0;
			while (enabled){
				if(air==0 || air==2){
					air++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (level);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.NavStart();
					yield return new WaitForSeconds (timeBetweenMobs);
				}else if(air==1){
					air++;
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					var mob = Instantiate (flyerRangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (level);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.NavStart();
					yield return new WaitForSeconds (timeBetweenMobs);
				}else{
					air = 0;
					yield return new WaitForSeconds (timeBetweenGroups);
				}
			}
		}

		/// <summary>
		/// Spawn Y mob every Z seconds.
		/// </summary>
		/// <returns>The spawn.</returns>
		/// <param name="mobType">Mob type.</param>
		/// <param name="spawnDelay">Spawn delay.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="mobLevel">Mob level.</param>
		public IEnumerator MobSpawn(string mobType, float spawnDelay, int mobPath, int mobLevel)
		{
			var path = waypointManager.paths [mobPath];
			while(enabled)
			{
				
				yield return new WaitForSeconds(spawnDelay);

				mobStats.mobsCurrentlyActive++;
				mobStats.mobsSpawnedThisWave++;
				if(mobType == "Basic")
				{
					mobStats.basicMobsSpawned++;
					var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (mobLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBasic = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
				} 
				else if (mobType == "Flying")
				{
					var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (mobLevel);
					mobscript.pooled=false;
					mobnav.path = path;

					mobnav.NavStart();
				} 
				else if(mobType == "Ranged")
				{
					var mob = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					var mobaggro = mob.GetComponentInChildren<MobAggro> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (mobLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isRanged = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					mobaggro.AggroStart();
				} 
				else if(mobType == "Boss")
				{
					var mob = Instantiate (bossMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
					var mobscript = mob.GetComponent<MobHealth> ();
					var mobnav = mob.GetComponent<MobNavigation> ();
					var mobaggro = mob.GetComponentInChildren<MobAggro> ();
					mobscript.mobStats = mobStats;
					mobscript.MobStart (mobLevel);
					mobscript.pooled=false;
					mobnav.path = path;
					mobnav.isBoss = true;
					if (freebuild) {
						mobnav.freebuild = true;
					}
					mobnav.NavStart();
					mobaggro.AggroStart();
				}
			}
		}

		/// <summary>
		/// Spawn Y mob when Z basic mobs have been spawned.
		/// </summary>
		/// <returns>The using basic count.</returns>
		/// <param name="mobType">Mob type.</param>
		/// <param name="spawnDelay">Spawn delay.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="mobLevel">Mob level.</param>
		public IEnumerator SpawnUsingBasicCount(string mobType, int spawnDelay, int mobPath, int mobLevel)
		{
			var path = waypointManager.paths [mobPath];
			while(enabled)
			{
				if (mobStats.basicMobsSpawned == spawnDelay) {
					mobStats.basicMobsSpawned = 0;
					yield return new WaitForSeconds (1.0f);
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
					if (mobType == "Flying") {
						var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;

						mobnav.NavStart ();
					} else if (mobType == "Ranged") {
						var mob = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;
						mobnav.isRanged = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart ();
						mobaggro.AggroStart ();
					} else if (mobType == "Boss") {
						var mob = Instantiate (bossMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;
						mobnav.isBoss = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart ();
						mobaggro.AggroStart ();
					}
				}
			}
		}

		/// <summary>
		/// Spawn a single mob Y seconds after Z mobs have spawned.
		/// </summary>
		/// <returns>The single.</returns>
		/// <param name="mobType">Mob type.</param>
		/// <param name="spawnDelay">Spawn delay.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="mobLevel">Mob level.</param>
		public IEnumerator SpawnSingle(string mobType, int spawnDelay, int timeDelay, int mobPath, int mobLevel)
		{
			bool spawned = false;
			var path = waypointManager.paths [mobPath];
			while(enabled){
				if(mobStats.mobsSpawnedThisWave >= spawnDelay && spawned==false){
					spawned=true;
					yield return new WaitForSeconds (timeDelay);
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;

					if(mobType == "Basic")
					{
						mobStats.basicMobsSpawned++;
						var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled=false;
						mobnav.path = path;
						mobnav.isBasic = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart();
					} 
					else if (mobType == "Flying")
					{
						var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled=false;
						mobnav.path = path;

						mobnav.NavStart();
					} 
					else if(mobType == "Ranged")
					{
						var mob = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled=false;
						mobnav.path = path;
						mobnav.isRanged = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart();
						mobaggro.AggroStart();
					} 
					else if(mobType == "Boss")
					{
						var mob = Instantiate (bossMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled=false;
						mobnav.path = path;
						mobnav.isBoss = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart();
						mobaggro.AggroStart();
					}
					else if(mobType == "Boss2")
					{
						var mob = Instantiate (otherBossMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();
						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled=false;
						mobnav.path = path;
						mobnav.isBoss = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart();
						mobaggro.AggroStart();
					}
				}
				yield return new WaitForEndOfFrame();
			}
		}

		/// <summary>
		/// Spawn a single mob after Y seconds.
		/// </summary>
		/// <param name="mobType">Mob type.</param>
		/// <param name="mobPath">Mob path.</param>
		/// <param name="mobLevel">Mob level.</param>
		public IEnumerator SingleMobSpawn(int delay, string mobType, int mobPath, int mobLevel)
		{
			bool spawned = false;
			var path = waypointManager.paths [mobPath];
			while (enabled) {
				if (spawned == false) {
					spawned = true;
					yield return new WaitForSeconds (delay);
					if (mobType == "Basic") {
						mobStats.basicMobsSpawned++;
						var mob = Instantiate (basicMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();

						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;
						mobnav.isBasic = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart ();
					} else if (mobType == "Flying") {
						var mob = Instantiate (flyingMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();

						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;

						mobnav.NavStart ();
					} else if (mobType == "Ranged") {
						var mob = Instantiate (rangedMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();

						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;
						mobnav.isRanged = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart ();
						mobaggro.AggroStart ();
					} else if (mobType == "Boss") {
						var mob = Instantiate (bossMobPrefab, path.spawn.transform.position, path.spawn.transform.rotation);
						var mobscript = mob.GetComponent<MobHealth> ();
						var mobnav = mob.GetComponent<MobNavigation> ();
						var mobaggro = mob.GetComponentInChildren<MobAggro> ();

						mobscript.mobStats = mobStats;
						mobscript.MobStart (mobLevel);
						mobscript.pooled = false;
						mobnav.path = path;
						mobnav.isBoss = true;
						if (freebuild) {
							mobnav.freebuild = true;
						}
						mobnav.NavStart ();
						mobaggro.AggroStart ();
					}
					mobStats.mobsCurrentlyActive++;
					mobStats.mobsSpawnedThisWave++;
				}
				yield return new WaitForEndOfFrame ();

			}
		}
	}
}