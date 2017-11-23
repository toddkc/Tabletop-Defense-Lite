using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityAdjustment : MonoBehaviour {

	public bool mainMenu;

	void Start(){
		Time.timeScale = 1.0f;
		if(mainMenu){
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.Medium;
			QualitySettings.antiAliasing = 4;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		}
		else{
			QualitySettings.shadows = ShadowQuality.Disable;
			QualitySettings.antiAliasing = 0;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		}
	}
}
