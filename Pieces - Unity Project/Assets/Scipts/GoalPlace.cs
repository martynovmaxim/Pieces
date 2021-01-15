﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlace : MonoBehaviour
{
    public int id;
    public float timeToLerp = 0.5f;

    MovementScript objective;
    Manager manager;

    Vector3 objectivePos;
    float contactTime;

    bool finished;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objective != null && !finished)
        {
            float alpha = Mathf.Clamp((Time.time - contactTime) / timeToLerp, 0, 1);
            alpha *= alpha;
            Debug.Log(alpha);
            objective.transform.position = Vector3.Lerp(objectivePos, transform.position, alpha);
            if (alpha == 1)
            {
                finished = true;
                manager.GoalComplete();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MovementScript obj = other.gameObject.GetComponent<MovementScript>();
        if (obj != null)
        {
            if (id == obj.id)
            {
                Debug.Log("HI THERE");
                objective = obj;
                objectivePos = obj.transform.position;
                contactTime = Time.time;
                obj.SetVelocity(Vector3.zero);
            }
        }
    }
}
