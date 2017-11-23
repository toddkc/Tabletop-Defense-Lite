namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.AI;

	public class TutorialNavigation : MonoBehaviour {

		public GameObject navStart;
		public GameObject navEnd;
		private Quaternion locRot;
		private NavMeshAgent agent;


		void Start () {
			agent = GetComponent<NavMeshAgent> ();
			locRot = transform.localRotation;
			agent.destination = navEnd.transform.position;
		}


		void ResetPosition(){
			agent.Warp (navStart.transform.position);
			transform.localRotation = locRot;
			agent.destination = navEnd.transform.position;
		}
			
		void OnTriggerEnter(Collider coll){
			ResetPosition ();
		}
	}
}