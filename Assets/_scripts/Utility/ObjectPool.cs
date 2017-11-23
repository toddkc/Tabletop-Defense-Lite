namespace TowerDefense{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ObjectPool: MonoBehaviour {

		public static void Instantiate(GameObject pooledObject, Transform objectLocation, Quaternion objectRotation){
			Instantiate (pooledObject, objectLocation, objectRotation);
		}

		public static void Destroy(GameObject pooledObject){
			Destroy (pooledObject);
		}
	}
}
