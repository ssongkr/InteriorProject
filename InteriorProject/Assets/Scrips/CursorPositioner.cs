﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorPositioner : MonoBehaviour {
    private float defaultPosZ;

	// Use this for initialization
	void Start () {
        defaultPosZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {

        /*
         * 커서를 물체 맞앗을때에도 보이게 재설정 해주는 스크립트
         */
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.distance<=defaultPosZ)
            {
                transform.localPosition = new Vector3(0,0,hit.distance);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosZ);
            }
        }

	}
}
