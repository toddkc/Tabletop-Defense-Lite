using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGem : MonoBehaviour {
	public GameObject gemSphere;
	public float rotateSpeed;

	void Update () {
		gemSphere.transform.Rotate (Vector3.up,  rotateSpeed * Time.deltaTime);
	}
}
