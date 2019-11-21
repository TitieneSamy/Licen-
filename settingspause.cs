using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingspause : MonoBehaviour {


    public AudioMixer audioMixer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Setvolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
