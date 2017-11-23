namespace TowerDefense{
	using UnityEngine;

	public class RestartButton : MonoBehaviour {
		
		void OnTriggerEnter(Collider coll)
		{
			var menu = GameObject.Find ("Menu").GetComponent<Menu>();
			menu.Restart ();
		}
	}
}