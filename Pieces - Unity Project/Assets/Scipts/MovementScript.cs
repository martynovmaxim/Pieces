using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform transform;
    public Vector3 velocity;
    public Vector3 initVel;
    public float deceleration = 0.5f;

    bool stoped = true;

    Manager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.AddObject(this);
        transform = gameObject.GetComponent<Transform>();
        velocity = initVel;
    }

    // Update is called once per frame
    void Update()
    {
        MovementCycle();
        DecelerationCycle();
    }

    public void OnCollisionEnter(Collision collision)
    {
        MovementScript others = collision.gameObject.GetComponent<MovementScript>();
        if (others != null)
        {
            Vector3 delta = velocity - others.velocity;
            if (delta.x > 0 || delta.y > 0)
            {
                float speed = ((velocity + others.velocity) / 2).magnitude;
                velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized * speed;
            }
            else
            {
                float speed = ((velocity + others.velocity) / 2).magnitude;
                velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized * speed;
                others.velocity = Vector3.Reflect(others.velocity, collision.GetContact(0).normal * -1).normalized * speed;
            }               
        }
        else
        {
            velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal);
        }
    }
        
    private void MovementCycle()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void DecelerationCycle()
    {
        if (!stoped)
        {
            if (velocity.magnitude != 0)
            {
                stoped = false;
                float speed = velocity.magnitude;
                velocity *= (speed - deceleration * Time.deltaTime) / speed;
            }
            else
            {
                stoped = true;
                EndMovement();
            }
        }
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        velocity = newVelocity;
        stoped = false;
    }

    public void EndMovement()
    {
        manager.ObjectStoped();
    }
}
