using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBrick : MonoBehaviour {
	public Text selectText;
	public GameObject blockManager;

	public Image selectImage;
	private BuildingSystem buildingSystem;

	private float rgbRed;
	private float rgbGreen;
	private float rgbBlue;

	// Use this for initialization
	void Start () {
		buildingSystem = blockManager.GetComponent<BuildingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(buildingSystem.buildModeOn) {
			if(buildingSystem.blockSelectCounter == 0) {	// DarkBrown
				rgbRed = (float)75.0/256; rgbGreen = (float)60.0/256; rgbBlue = (float)60.0/256;
			}
			if(buildingSystem.blockSelectCounter == 1) {	// Brown
				rgbRed = (float)116.0/256; rgbGreen = (float)97.0/256; rgbBlue = (float)97.0/256;
			}
			if(buildingSystem.blockSelectCounter == 2) {	// Green
				rgbRed = (float)60.0/256; rgbGreen = (float)122.0/256; rgbBlue = (float)71.0/256;
			}
			if(buildingSystem.blockSelectCounter == 3) {	// Red
				rgbRed = (float)178/256; rgbGreen = (float)76.0/256; rgbBlue = (float)76.0/256;
			}
			selectText.text = "Build Mode";
		} else {
			rgbRed = 1.0f; rgbGreen = 1.0f; rgbBlue = 1.0f;
			selectText.text = "Destroy Mode";
		}
		selectImage.color = new Color(rgbRed, rgbGreen, rgbBlue);
	}
}
