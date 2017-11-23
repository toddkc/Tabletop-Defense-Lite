namespace TowerDefense{
	using UnityEngine;

	public class TowerLookAt : MonoBehaviour {

		private Tower tower;
		public bool airOnly;

		void Start(){
			tower = GetComponentInParent<Tower> ();
		}

		void OnTriggerEnter(Collider coll){
			if (airOnly == false) {
				if(tower.target==null)
				{
					if (coll.tag == "Ground Mob") 
					{
						tower.lookAt = coll.gameObject;
					}
				}	
			}else{
				if(tower.target==null)
				{
					if(coll.tag=="Air Mob")
					{
						tower.lookAt = coll.gameObject;
					}
				}
			}
		}

	}
}