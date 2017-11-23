namespace TowerDefense{
	using UnityEngine;
	using System.Collections;
	using VRTK;
	using UnityEngine.UI;

	public class QualitySettingsButtons : MonoBehaviour {

		public bool shadows, aliasing;
		bool clickable;
		float timeStamp;
		VRTK_ControllerActions controllerActions;
		public Text display;


		void Update(){
			if(clickable == false)
			{
				if (Time.time > timeStamp + 0.5f) 
				{
					clickable = true;
				}
			}
		}

		void OnTriggerEnter(Collider coll){
			if(coll.name == "Head" || coll.name=="Ring")
			{
				controllerActions = coll.GetComponentInParent<VRTK_ControllerActions>();
				controllerActions.TriggerHapticPulse(1.0f);
			}
		}

		void AdjustShadows(){
			var currentShadows =  QualitySettings.shadowResolution;
			if (currentShadows == ShadowResolution.VeryHigh) {
				QualitySettings.shadowResolution = ShadowResolution.Low;
				display.text = "Low";
			} else if (currentShadows == ShadowResolution.High) {
				QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
				display.text = "Max";
			} else if (currentShadows == ShadowResolution.Medium) {
				QualitySettings.shadowResolution = ShadowResolution.High;
				display.text = "Hi";
			} else if (currentShadows == ShadowResolution.Low) {
				QualitySettings.shadowResolution = ShadowResolution.Medium;
				display.text = "Med";
			}
		}
			
		void AntiAliasing(){
			var currentAlias = QualitySettings.antiAliasing;
			if(currentAlias==8){
				QualitySettings.antiAliasing = 0;
				display.text="Off";
			}else if(currentAlias==4){
				QualitySettings.antiAliasing = 8;
				display.text="8x";
			}else if(currentAlias==2){
				QualitySettings.antiAliasing = 4;
				display.text="4x";
			}else if(currentAlias==0){
				QualitySettings.antiAliasing = 2;
				display.text="2x";
			}
		}


		void OnTriggerStay(Collider coll){
			if (coll.GetComponentInParent<VRTK_ControllerEvents> ().triggerPressed == true && clickable==true) 
			{
				clickable = false;
				timeStamp = Time.time;
				if(shadows){
					AdjustShadows ();
				}else if(aliasing){
					AntiAliasing ();
				}
			}
		}
	}
}