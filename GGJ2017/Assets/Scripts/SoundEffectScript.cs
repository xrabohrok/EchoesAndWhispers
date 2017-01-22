using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectScript : MonoBehaviour {

    public AudioClip gunshot;
    public AudioClip scissors;
    public AudioClip murmurs;
    public AudioClip clearThroat;

    private AudioSource source;


	// Use this for initialization
	void Awake () {
        this.source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGunshot()
    {
        source.PlayOneShot(this.gunshot, 1.0f);
    }

    public void PlayScissors()
    {
        source.PlayOneShot(this.scissors, 1.0f);
    }

    public void PlayMurmurs()
    {
        source.PlayOneShot(this.murmurs, 1.0f);
    }

    public void PlayClearThroat()
    {
        source.PlayOneShot(this.clearThroat, 1.0f);
    }

}
