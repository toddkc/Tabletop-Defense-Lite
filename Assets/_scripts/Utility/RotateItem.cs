using UnityEngine;

public class RotateItem : MonoBehaviour {

	public float speed = 100.0f;

	void FixedUpdate()
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
