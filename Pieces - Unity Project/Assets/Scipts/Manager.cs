using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<MovementScript> movableObjects;
    List<MovementScript> stopedObjects;

    List<GoalPlace> goals;

    PlayerController player;

    
    // Start is called before the first frame update
    private void Awake()
    {
        movableObjects = new List<MovementScript>();
    }
    void Start()
    {
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
        player.EnableControls();
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
    }
}
