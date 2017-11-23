namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.AI;

	public class FreebuildSpawnAgent : MonoBehaviour {

		public GameObject start, end;
		NavMeshAgent agent;
		NavMeshPath checkPath;

		void Start(){
			agent = GetComponent<NavMeshAgent> ();
			checkPath = new NavMeshPath ();
		}

		public bool CheckPathValid(){
			agent.CalculatePath (end.transform.position, checkPath);
			if(checkPath.status==NavMeshPathStatus.PathComplete){
				return true;
			}else{
				return false;
			}
		}

	
	}
}