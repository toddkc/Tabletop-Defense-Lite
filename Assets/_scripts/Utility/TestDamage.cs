using UnityEngine;
using TowerDefense;
public class TestDamage : MonoBehaviour {

	public GameObject target;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Backspace)){
			target.GetComponentInChildren<TowerHealth> ().Hit ();
		}
	}

}
