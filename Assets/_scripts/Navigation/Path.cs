namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.AI;
	public class Path : MonoBehaviour {

		#region Variables
		//if mobs will be on ground and using navigation, otherwise they will just move transform (flyers)
		public bool useNavMesh;
		//store the navmeshagent
		[Header("Start and End")]
		//where to spawn
		public GameObject spawn;
		//where to end up
		public GameObject end;
		[Header("List of Waypoints")]
		//any waypoints outside of the basic navmesh path
		public GameObject[] waypoints;
		public GameObject spawnAura;
		[HideInInspector]
		public NavMeshPath navPath;

		#endregion

		void Start(){
			if(useNavMesh){
				navPath = new NavMeshPath ();
				NavMesh.CalculatePath (spawn.transform.position, end.transform.position, NavMesh.AllAreas, navPath);
			}
		}

		public void UpdatePath(){
			NavMesh.CalculatePath (spawn.transform.position, end.transform.position, NavMesh.AllAreas, navPath);
		}
	}
}