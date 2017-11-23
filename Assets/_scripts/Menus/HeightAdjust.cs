namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	using UnityEngine.UI;

	public class HeightAdjust : MonoBehaviour {
		
		[Tooltip("Scaled Child (Factory Items)")]
		public GameObject environment;
		[Tooltip("CameraRig")]
		public GameObject cameraRig;
		public bool raise, lower, offsetHeadsetHeight, offsetFactoryHeight, test;
		public float offsetValue = 3.5f;
		public Text display;

		VRTK_ControllerActions controllerActions;
		bool clickable;
		float timeStamp, adjustedHeight;
		int currentHeight;

		void Start(){
			clickable = true;
			if(raise==true){
				SetHeight (); //will set default to 0
			}
		}

		void Update(){
			if(clickable == false){
				if (Time.time > timeStamp + 0.2f){
					clickable = true;
				}
			}
			if(test&&raise){
				if(Input.GetKeyDown(KeyCode.Alpha0)){
					Raise ();
				}
				if(Input.GetKeyDown(KeyCode.Alpha9)){
					Lower ();
				}
			}
		}

		//makes the controller vibrate when it hovers over this button
		void OnTriggerEnter(Collider coll){
			if(coll.name == "Head" || coll.name=="Ring"){
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions>();
				controllerActions.TriggerHapticPulse(1.0f);
			}
		}

		void SetHeight()
		{
			currentHeight = PlayerPrefs.GetInt ("height", 0); //get int will set default to 0 if no value stored

			adjustedHeight = currentHeight + offsetValue;
			display.text = (currentHeight*-1).ToString ();
			if (offsetFactoryHeight) {
				environment.transform.position = new Vector3 (
					environment.transform.position.x,
					adjustedHeight,
					environment.transform.position.z);
			}else{
				environment.transform.position = new Vector3 (
					environment.transform.position.x,
					currentHeight,
					environment.transform.position.z);
			}

			if (offsetHeadsetHeight) {
				cameraRig.transform.position = new Vector3 (
					cameraRig.transform.position.x,
					adjustedHeight,
					cameraRig.transform.position.z);
			}else{
				cameraRig.transform.position = new Vector3 (
					cameraRig.transform.position.x,
					currentHeight,
					cameraRig.transform.position.z);
			}
		}

		//raising table actually lowers vive and factory
		public void Raise()
		{
			clickable = false;
			timeStamp = Time.time;
			currentHeight = PlayerPrefs.GetInt ("height");
			currentHeight--;
			PlayerPrefs.SetInt ("height", currentHeight);
			PlayerPrefs.Save();
			SetHeight ();
		}

		//lowering table actually raises vive and factory
		public void Lower()
		{
			clickable = false;
			timeStamp = Time.time;
			currentHeight = PlayerPrefs.GetInt ("height");
			currentHeight++;
			PlayerPrefs.SetInt ("height", currentHeight);
			PlayerPrefs.Save ();
			SetHeight ();
		}

		void OnTriggerStay(Collider coll)
		{
			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable==true) 
			{
				if (raise == true) 
				{
					Raise ();
				}
				else if(lower==true)
				{
					Lower ();
				}
			}
		}
	}
}