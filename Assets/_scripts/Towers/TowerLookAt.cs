namespace TowerDefense{
	using UnityEngine;

	public class TowerLookAt : MonoBehaviour {

		//the parent tower component
		private Tower tower;
		//true if the turret should only track air mobs
		[Tooltip("True if this turret should only track air mobs.")]
		public bool airOnly;

		void Start(){
			tower = GetComponentInParent<Tower> ();
		}

		void OnTriggerEnter(Collider coll){
			//first check for the aironly bool, 
			if (airOnly == false){
				//then check if tower already has a target
				if(tower.target==null){
					//then check if the object is a ground mob
					if (coll.tag == "Basic Mob" || coll.tag == "Ranged Mob" || coll.tag == "Boss Mob"){
						//if so start following it
						tower.lookAt = coll.gameObject;
					}
				}	
			}else{
				//same but only for air mobs
				if(tower.target==null){
					if(coll.tag=="Air Mob"){
						tower.lookAt = coll.gameObject;
					}
				}
			}
		}
	}
}