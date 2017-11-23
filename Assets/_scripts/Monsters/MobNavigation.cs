namespace TowerDefense
{
	using UnityEngine;
	using UnityEngine.AI;
	public class MobNavigation : MonoBehaviour {

		#region Variables
		private bool usingNavMesh;
		[HideInInspector]
		public bool freebuild;
		//navmeshagent = public for aggro
		[HideInInspector]
		public NavMeshAgent agent;
		//path to use
		[HideInInspector]
		public Path path;
		//current target
		[HideInInspector]
		public GameObject target;
		//keep track of which waypoint mob is heading towards
		private int waypointNumber;
		//speed for non-navmesh movement (flying mobs)
		[Header("Speed")]
		public float speed;
		private Vector3 lookTransform;
		private Quaternion rot;
		[HideInInspector]
		public bool slowed;
		private float timeSlowed;
		[Header("Object Links")]
		public bool useSpawnEffect;
		public GameObject spawnEffect;
		public GameObject slowCrown;
		[HideInInspector]
		public MobAggro mobAggro;
		public bool highPriority;

		//adding to check mob aggro on gem
		[HideInInspector]
		public bool pathEnd = false;
		[HideInInspector]
		public bool isBoss = false, isRanged = false, isBasic = false;
		#endregion

		public void NavStart(){
			waypointNumber = 0;
			if(useSpawnEffect==true && spawnEffect){
				ObjectPool.Instantiate (spawnEffect, transform.position, transform.rotation);
			}
			if (path.useNavMesh==true){
				usingNavMesh = true;
				agent = GetComponent<NavMeshAgent> ();
				RandomSpeed ();
				agent.speed = speed;
				if (freebuild){
					agent.destination = path.end.transform.position;
				}else{
					agent.SetPath (path.navPath);
				}

			}else{
				if (path.waypoints.Length == 0) {
					target = path.end;
					pathEnd = true;
				}else{
					NextTargetNoNav (waypointNumber);
					pathEnd = false;
				}
			}
		}

		void RandomSpeed(){
			var rand = Random.Range (0f, 20f);
			rand *= 0.01f;
			speed += rand;
		}

		void Update (){
			if (usingNavMesh == false){
				if (target){
					float step = speed * Time.deltaTime;
					transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
					lookTransform = target.transform.position - transform.position;
					lookTransform.y = 0;
					rot = Quaternion.LookRotation (lookTransform);
					transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime);
				}
				if (Vector3.Distance (gameObject.transform.position, target.transform.position) < 3.0f) {
					waypointNumber++;
					if (target != path.end) {
						NextTargetNoNav (waypointNumber);
					}
				}
			}

			if (slowed==true){
				if(Time.time>timeSlowed + 5.0f){
					ResumeSpeed ();
				}
			}
		}

		public void Slowdown(){
			if (agent.speed != 0) {
				agent.speed = speed * 0.5f;
			}
		}

		private void ResumeSpeed(){
			if (agent.speed != 0) {
				agent.speed = speed;
				slowed = false;
				slowCrown.SetActive (false);
			}
		}

		public void SlowEffect (){
			if (agent.speed != 0) {
				timeSlowed = Time.time;
				slowCrown.SetActive (true);
				slowed = true;
				agent.speed = speed * 0.5f;
				if(mobAggro){
					mobAggro.SlowEffect ();
				}
			}
		}

		void NextTargetNavMesh(int waypointNumberCheck){
			
			if(path.waypoints.Length == waypointNumberCheck){
				target = path.end;
				agent.destination = path.end.transform.position;
				pathEnd = true;
			}else{
				target = path.waypoints [waypointNumberCheck];
				agent.destination = target.transform.position;
			}
		}

		void NextTargetNoNav(int waypointNumberCheck){
			if(path.waypoints.Length == waypointNumberCheck){
				target = path.end;
				pathEnd = true;
			}else{
				target = path.waypoints [waypointNumberCheck];
			}
		}

		void OnTriggerStay(Collider coll){
			if(isBasic){
				if(coll.tag=="Ranged Mob"){
					transform.position -= transform.right * 0.01f;
				}else if (coll.tag == "Basic Mob") {
					var x = transform.position.x - coll.transform.position.x;
					if (x > 0.0f){
						transform.position -= transform.right * 0.005f;
					}else if(x<0.0f){
						transform.position += transform.right * 0.005f;
					}
				}
			}else if(isRanged){
				if(coll.tag=="Basic Mob"){
					transform.position += transform.right * 0.01f;
				}else if (coll.tag == "Ranged Mob") {
					var x = transform.position.x - coll.transform.position.x;
					if (x > 0.0f){
						transform.position -= transform.right * 0.005f;
					}else if(x<0.0f){
						transform.position += transform.right * 0.005f;
					}
				}
			}else if(isBoss){
				if(coll.tag=="Basic Mob"){
					transform.position += transform.right * 0.01f;
				}
			}
		}
	}
}