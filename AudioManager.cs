﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
 
	// Use this for initialization
	void Awake () {
        foreach (Sound s in sounds)
        {
            s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
           
        }
	}

    public void Play(string name)
    {
       Sound s= Array.Find(sounds, Sound => Sound.Name == name);
        s.source.Play();
    }
}
