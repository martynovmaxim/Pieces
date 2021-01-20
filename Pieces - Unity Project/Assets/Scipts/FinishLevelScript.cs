using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelScript : MonoBehaviour
{
    public AudioClip FinishMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = FinishMusic;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
