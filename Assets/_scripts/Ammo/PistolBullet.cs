namespace TowerDefense{
	using UnityEngine;
	public class PistolBullet : MonoBehaviour {
		
		void OnTriggerEnter(Collider coll)
		{
			if (coll.tag == "Ground Mob" || coll.tag =="Air Mob") 
			{
				coll.GetComponentInParent<MobHealth> ().Hit ();
			}
		}
	}
}