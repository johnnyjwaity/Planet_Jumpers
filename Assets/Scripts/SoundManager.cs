using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource music;
    

	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playMusic()
    {
        music.Play();
    }
    public void stopMusic()
    {
        music.Stop();
    }

}
