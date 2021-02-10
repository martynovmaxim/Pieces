using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Manager : MonoBehaviour
{
    public List<MovementScript> movableObjects;
    List<MovementScript> stopedObjects;

    public List<GoalPlace> goals;

    public AudioClip LevelFailedSound;
    public AudioClip LevelCompletedSound;
    AudioSource audioData;

    public int JumpLimits = 5;
    bool failed = false;
    public bool finished = false;

    public string NextLevelName;

    PlayerController player;

    GameObject video;
    GameObject whitePlane;
    public float AlphaDecrease = 1;
    public List<GameObject> WhatToDestroy;
    

    
    // Start is called before the first frame update
    private void Awake()
    {
        movableObjects = new List<MovementScript>();
    }
    void Start()
    {
        audioData = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.EnableControls();
        whitePlane = GameObject.FindGameObjectWithTag("WhitePlane");
        video = GameObject.FindGameObjectWithTag("Video");
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            MeshRenderer meshRenderer =  whitePlane.GetComponent<MeshRenderer>();
            float alpha = meshRenderer.material.GetFloat("Alpha");
            if (alpha != 0)
            {
                float newAlpha = Mathf.Clamp(alpha - AlphaDecrease * Time.deltaTime, 0, 100);
                whitePlane.GetComponent<MeshRenderer>().material.SetFloat("Alpha", newAlpha);
            }
            else
            {
                Destroy(whitePlane);
                this.enabled = false;
            }
            
        }
    }

    public void AddObject(MovementScript obj)
    {
        movableObjects.Add(obj);
    }

    public void ObjectStoped()
    {
        bool stop = true;
        foreach (MovementScript obj in movableObjects)
        {
            if (obj.velocity.magnitude != 0 && obj.enabled)
            {
                stop = false;
                break;
            }
        }
        if (stop) AllObjectsStopeed();
    }

    public void AllObjectsStopeed()
    {

        if ((JumpLimits > 0 && !failed) || finished)
        {
            JumpLimits--;
            player.EnableControls();
        }
        else LevelFailed();
    }

    public void AddGoal(GoalPlace newGoal)
    {
        goals.Add(newGoal);
    }

    public void GoalComplete()
    {
        bool LevelCompleted = true;
        foreach (GoalPlace goal in goals)
        {
            if (!goal.finished) 
            {
                LevelCompleted = false;
                break;
            }
        }
        if (LevelCompleted) LevelFinished();
    }

    void LevelFinished()
    {
        audioData.clip = LevelCompletedSound;
        audioData.Play();
        whitePlane.GetComponent<MeshRenderer>().enabled = true;
        finished = true;
        video.GetComponent<MeshRenderer>().enabled = true;
        video.GetComponent<VideoPlayer>().Play();
        foreach (GameObject obj in WhatToDestroy)
        {
            Destroy(obj);
        }
        gameObject.GetComponent<JumpLimitsGUI>().enabled = false;
    }

    public void LevelFailed()
    {
        if (failed) return;
        failed = true;
        Debug.Log("Failed");
        audioData.clip = LevelFailedSound;
        audioData.Play();
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(LevelFailedSound.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
