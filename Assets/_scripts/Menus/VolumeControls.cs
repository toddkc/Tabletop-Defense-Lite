namespace TowerDefense{
	using UnityEngine;
	using VRTK;
	using UnityEngine.UI;
	public class VolumeControls : MonoBehaviour {
		
		[Header("Music")]
		public bool musicUp;
		public bool musicDown;

		[Header("Towers")]
		public bool towerUp;
		public bool towerDown;

		[Header("Mobs")]
		public bool mobUp;
		public bool mobDown;

		[Header("Links")]
		public Text current;

		private VRTK_ControllerActions controllerActions;
		private bool clickable;
		private float timeStamp;

		private float currentVolume;
		private float displayVolume;

		void Start()
		{
			if(musicUp==true)
			{
				if (PlayerPrefs.HasKey ("music")==false) {
					PlayerPrefs.SetFloat("music", 0.3f);
				}
				currentVolume = PlayerPrefs.GetFloat ("music");
				Display (currentVolume);
			}
			else if(mobUp==true)
			{
				if (PlayerPrefs.HasKey ("towers and mobs")==false) {
					PlayerPrefs.SetFloat("towers and mobs", 0.8f);
				}
				currentVolume = PlayerPrefs.GetFloat ("towers and mobs");
				Display (currentVolume);
			}
			else if(towerUp==true)
			{
				if (PlayerPrefs.HasKey ("feedback")==false) {
					PlayerPrefs.SetFloat("feedback", 0.8f);
				}
				currentVolume = PlayerPrefs.GetFloat ("feedback");
				Display (currentVolume);
			}
			clickable = true;
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

		void OnTriggerStay(Collider coll)
		{

			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable == true) 
			{
				if (musicUp == true) {
					MusicUp ();
				} else if (musicDown == true) {
					MusicDown ();
				} else if (towerUp == true) {
					TowerUp ();
				} else if (towerDown == true) {
					TowerDown ();
				} else if (mobUp==true){
					MobUp ();
				}else if (mobDown==true){
					MobDown ();
				}
				clickable = false;
				timeStamp = Time.time;
			}
		}

		void Display(float volume){
			displayVolume = volume * 10.0f;
			var rounded = Mathf.RoundToInt (displayVolume);
			current.text = rounded.ToString ();
			PlayerPrefs.Save ();
		}

		void MusicUp(){
			currentVolume = PlayerPrefs.GetFloat ("music");
			if (currentVolume <= 0.95f) {
				currentVolume += 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("music", currentVolume);
				Display (currentVolume);
			}
		}
		void MusicDown(){
			currentVolume = PlayerPrefs.GetFloat ("music");
			if (currentVolume >= 0.06f) {
				currentVolume -= 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("music", currentVolume);
				Display (currentVolume);
			}
		}
		void TowerUp(){
			currentVolume = PlayerPrefs.GetFloat ("feedback");
			if (currentVolume <= 0.95f) {
				currentVolume += 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("feedback", currentVolume);
				Display (currentVolume);
			}
		}
		void TowerDown(){
			currentVolume = PlayerPrefs.GetFloat ("feedback");
			if (currentVolume >= 0.06f) {
				currentVolume -= 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("feedback", currentVolume);
				Display (currentVolume);
			}
		}
		void MobUp(){
			currentVolume = PlayerPrefs.GetFloat ("towers and mobs");
			if (currentVolume <= 0.95f) {
				currentVolume += 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("towers and mobs", currentVolume);
				Display (currentVolume);
			}

		}
		void MobDown(){
			currentVolume = PlayerPrefs.GetFloat ("towers and mobs");
			if (currentVolume >= 0.06f) {
				currentVolume -= 0.1f;
				Mathf.Round (currentVolume);
				PlayerPrefs.SetFloat ("towers and mobs", currentVolume);
				Display (currentVolume);
			}

		}

		void OnTriggerEnter(Collider coll)
		{
			if (coll.name == "Head" || coll.name=="Ring") {
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions> ();
				controllerActions.TriggerHapticPulse (1.0f);
			}
		}
	}
}