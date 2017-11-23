namespace TowerDefense{
	using UnityEngine;
	using VRTK;

	public class MapSelectGem : MonoBehaviour {
		[Tooltip("This number needs to match the scene in the build index.")]
		public int sceneNumber;
		[Header("Gem Stuff")]
		public GameObject sphere;
		public float rotateSpeed;
		LevelLoader levelLoader;
		private VRTK_ControllerActions controllerActions;

		void Start(){
			levelLoader = GameObject.Find ("LevelLoader").GetComponent<LevelLoader> ();
		}

		void Update(){
			sphere.transform.Rotate (Vector3.right, rotateSpeed * Time.deltaTime);

		}

		void OnTriggerEnter(Collider coll)
		{
			if (coll.name == "Head" || coll.name=="Ring") {
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
				controllerActions.TriggerHapticPulse (1.0f);
			}
		}

		//add level loader
		void OnTriggerStay(Collider coll)
		{
			if (coll.name == "Head" || coll.name=="Ring") {
				if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true) {
					levelLoader.LoadNewScene (sceneNumber);
				}
			}
		}
	}
}