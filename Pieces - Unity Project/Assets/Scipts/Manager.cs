using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public string NextLevelName;

    PlayerController player;

    
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
    }

    // Update is called once per frame
    void Update()
    {

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
            if (obj.velocity.magnitude != 0)
            {
                stop = false;
                break;
            }
        }
        if (stop) AllObjectsStopeed();
    }

    public void AllObjectsStopeed()
    {
        JumpLimits--;
        if (JumpLimits >= 0 && !failed) player.EnableControls();
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
        GameObject exit = GameObject.FindGameObjectWithTag("Exit");
        exit.transform.position = exit.transform.position + new Vector3(0, 50, 0);
        audioData.clip = LevelCompletedSound;
        audioData.Play();
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
