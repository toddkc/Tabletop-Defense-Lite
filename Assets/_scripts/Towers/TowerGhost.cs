namespace TowerDefense{
using UnityEngine;

	public class TowerGhost : MonoBehaviour {
	
		[Header("Type of Tower")]
		public bool gunTower;
		public bool bombTower;
		public bool airTower;
		public bool slowTower;
		public GameObject turret;
		public GameObject target;
		private Vector3 targetPosition;
		private Vector3 targetTurretTransform;
		private Quaternion rot;

		void OnTriggerEnter(Collider coll)
		{
			
				if (airTower == true) 
				{
					if (coll.tag == "Air Mob") 
					{
						target = coll.gameObject;
					}
				} else {
					if (coll.tag == "Ground Mob") 
					{
						target = coll.gameObject;
					}
				}
		}

		void OnTriggerStay(Collider coll)
		{
			
				if (airTower == true) 
				{
					if (coll.tag == "Air Mob") 
					{
						target = coll.gameObject;
					}
				} else {
					if (coll.tag == "Ground Mob") 
					{
						target = coll.gameObject;
					}
				}
		}



		void FixedUpdate()
		{
			
				if (target) {
					targetTurretTransform = target.transform.position - turret.transform.position;
					targetTurretTransform.y = 0;
					rot = Quaternion.LookRotation (targetTurretTransform);
					turret.transform.rotation = Quaternion.Slerp (turret.transform.rotation, rot, Time.deltaTime);
				}
		}


	}
}