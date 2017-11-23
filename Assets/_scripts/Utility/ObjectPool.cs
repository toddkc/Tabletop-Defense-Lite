namespace TowerDefense{
	using UnityEngine;

	public class ObjectPool: MonoBehaviour {

		public static void Add(GameObject pooledObject, Vector3 objectLocation, Quaternion objectRotation){
			Instantiate (pooledObject, objectLocation, objectRotation);
		}

		public static void Remove(GameObject pooledObject){
			Destroy (pooledObject);
		}
	}
}
