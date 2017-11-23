namespace TowerDefense{
	using UnityEngine;

	public class InstantiateTest : MonoBehaviour {
		public GameObject prefab;
		private GameObject test;
		void Update(){
			if (Input.GetKeyDown (KeyCode.Space)) {
				test = ObjectPool.Instantiate (prefab, transform.position, transform.rotation);
			}

			if (Input.GetKeyDown (KeyCode.Backspace)) {
					ObjectPool.Destroy (test);
			}
		}
	}
}