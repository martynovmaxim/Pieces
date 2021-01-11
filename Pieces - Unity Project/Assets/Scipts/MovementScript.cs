using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform transform;
    public Vector3 velocity;
    public Vector3 initVel;
    public float deceleration = 3f
        ;

    public int id;

    bool stoped = true;
    bool hasContacted;

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
        
    private void MovementCycle()
    {
        transform.position += velocity * Time.deltaTime;
        if (velocity.magnitude > 0f) stoped = false;
    }

    void DecelerationCycle()
    {
        if (!stoped)
        {
            if (velocity.magnitude != 0)
            {
                float speed = velocity.magnitude;
                velocity *= (Mathf.Clamp(speed - deceleration * Time.deltaTime, 0, 5000)) / speed;
            }
            else
            {
                EndMovement();
            }
        }
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        velocity = newVelocity;
        if (newVelocity != Vector3.zero) stoped = false;
    }

    public void AddVelocity(Vector3 newVelocity)
    {
        velocity += newVelocity;
        stoped = false;
    }

    public void EndMovement()
    {
        stoped = true;
        manager.ObjectStoped();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!hasContacted)
        {
            MovementScript others = collision.gameObject.GetComponent<MovementScript>();
            if (others != null)
            {
                others.hasContacted = true;
                Vector3 delta = velocity - others.velocity;
                if (delta.x > 0 || delta.y > 0)
                {
                    float speed = ((velocity + others.velocity) / 2).magnitude;
                    Vector3 direction = velocity.normalized;
                    velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized * speed;
                    others.AddVelocity(direction * speed);
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
        else
        {
            hasContacted = false;
        }
    }
}
