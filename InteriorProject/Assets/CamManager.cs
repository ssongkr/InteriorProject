using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CamManager : MonoBehaviour {

    public GameObject FirstCam;
    public GameObject ThirdCam;

    public const int FIRST_PERSON = 0;
    public const int THIRD_PERSON = 1;

    public int camMode;

    private void Start() {
        camMode = FIRST_PERSON;
    }

    void Update () {
        if(Input.GetButtonDown ("Camera")) {
            if (camMode == 1) {
                camMode = 0;
            } else {
                camMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange() {
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0) {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if(camMode == 1) {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}
