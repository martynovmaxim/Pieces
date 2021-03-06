﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundMusic");

        if (objs.Length > 1)
        {
            if (objs[0].GetComponent<AudioSource>().clip == gameObject.GetComponent<AudioSource>().clip) Destroy(this.gameObject);
            else Destroy(objs[0]);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}