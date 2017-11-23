namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	using UnityEngine.UI;

	public class WalkingSpeed : MonoBehaviour {

		private VRTK_ControllerActions controllerActions;
		private bool clickable;
		private float timeStamp;
		public bool raise;
		public bool lower;
		public Text display;

		[Header("Visible for Debug Only")]
		public int currentSpeed;
		public GameObject vrtk;
		private VRTK_TouchpadWalking vrtkWalk;
		void Start(){
			clickable = true;
			vrtkWalk = vrtk.GetComponent<VRTK_TouchpadWalking> ();
			if (raise == true) 
			{
				if (PlayerPrefs.HasKey ("walkspeed") == false) 
				{
					PlayerPrefs.SetInt ("walkspeed", 10);
				}
				SetSpeed ();
			}
		}

		void Update()
		{
			if(clickable == false)
			{
				if (Time.time > timeStamp + 0.5f) 
				{
					clickable = true;
				}
			}
		}

		//makes the controller vibrate when it hovers over this button
		void OnTriggerEnter(Collider coll)
		{
			if(coll.name == "Head" || coll.name=="Ring")
			{
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions>();
				controllerActions.TriggerHapticPulse(1.0f);
			}
		}

		void SetSpeed()
		{
			currentSpeed = PlayerPrefs.GetInt ("walkspeed");
			vrtkWalk.maxWalkSpeed = currentSpeed;
			display.text = currentSpeed.ToString ();
		}

		void Raise()
		{
			currentSpeed = PlayerPrefs.GetInt ("walkspeed");
			currentSpeed++;
			PlayerPrefs.SetInt ("walkspeed", currentSpeed);
			PlayerPrefs.Save ();
			clickable = false;
			timeStamp = Time.time;
			SetSpeed ();
		}

		void Lower()
		{
			currentSpeed = PlayerPrefs.GetInt ("walkspeed");
			currentSpeed--;
			PlayerPrefs.SetInt ("walkspeed", currentSpeed);
			PlayerPrefs.Save ();
			clickable = false;
			timeStamp = Time.time;
			SetSpeed ();
		}

		//pulling cube up visually needs to push floor down
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