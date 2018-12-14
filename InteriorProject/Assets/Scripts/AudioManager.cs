using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip sound;
    AudioSource myAudio;

    public static AudioManager instance;

    void Awake()
    {
        if (AudioManager.instance == null)
            AudioManager.instance = this;
        Debug.Log("1");
    }

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(sound, gameObject.transform.position);      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
