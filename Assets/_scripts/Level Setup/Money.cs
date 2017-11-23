namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

public class Money : MonoBehaviour {
		
		public int moneyMaster;
		public Text tmPro;
		[HideInInspector]
		public int towersBuilt = 0;

		void Update () 
		{
			tmPro.text = moneyMaster.ToString();
		}

		//called when gold is collected, adds money
		public void GoldPickup(int amount)
		{
			moneyMaster += amount;
		}

		//called when a tower is built, subtracts money
		public void TowerBuildCost(int tb)
		{
			moneyMaster -= tb;
		}
	}
}