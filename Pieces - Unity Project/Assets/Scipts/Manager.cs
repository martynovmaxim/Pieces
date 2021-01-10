using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<MovementScript> movableObjects;

    PlayerController player;

    List<MovementScript> stopedObjects;
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
            if (obj.velocity != Vector3.zero)
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
}
