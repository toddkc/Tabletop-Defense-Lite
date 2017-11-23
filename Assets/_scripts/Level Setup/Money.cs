namespace TowerDefense{
	using UnityEngine;

	public class Money : MonoBehaviour {

		//the player bank, updated as money is earned/spent.  initial value is what player starts with
		public int moneyMaster;
		private TextMesh tmPro;
		[HideInInspector]
		public int towersBuilt = 0;

		void Start(){
			tmPro = GameObject.Find ("MoneyCounter").GetComponent <TextMesh>();
		}

		void Update (){
			//adust displayed money value, needs to be moved out of update...
			tmPro.text = moneyMaster.ToString();
		}

		//called when gold is collected, adds money
		public void GoldPickup(int amount){
			moneyMaster += amount;
		}

		//called when a tower is built, subtracts money
		public void TowerBuildCost(int tb){
			moneyMaster -= tb;
		}
	}
}