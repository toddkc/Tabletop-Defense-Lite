namespace TowerDefense{
	using UnityEngine;

	public class GoldPickup : MonoBehaviour {

		Money money;

		void Start(){
			money = GameObject.Find ("Money").GetComponent<Money> ();
		}

		public void Pickup(int amount)
		{
			money.moneyMaster += amount;
		}

	}
}