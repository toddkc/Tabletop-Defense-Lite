namespace TowerDefense{
	using UnityEngine;

	public class MobStats : MonoBehaviour {

		//keeps track of mobs on screen, and mobs that have been spawned this wave
		[HideInInspector]
		public int mobsCurrentlyActive;
		[HideInInspector]
		public int mobsSpawnedThisWave;
		[HideInInspector]
		public int basicMobsSpawned;
		[HideInInspector]
		public int rangedMobsSpawned;
		[HideInInspector]
		public int flyingMobsSpawned;
	}
}