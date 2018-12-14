using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
	public GameObject target;

	private GameObject blockManager;
	private BuildingSystem buildingSystem;
	private AudioSource destroyAudio;

	// Use this for initialization
	void Start () {
		blockManager = GameObject.Find("BlockManager");
		buildingSystem = blockManager.GetComponent<BuildingSystem>();
		destroyAudio = blockManager.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!buildingSystem.buildModeOn) {
			Transform camera = Camera.main.transform;
			Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 10) && (hit.collider.gameObject == target)) {
				if(Input.GetMouseButtonDown(0)) {
					destroyAudio.Play();
					Destroy(gameObject);
				}
			}
		}
	}
}
