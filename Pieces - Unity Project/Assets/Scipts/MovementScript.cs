using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MovementScript : MonoBehaviour
{
    Transform transform;
    public Vector3 velocity;
    public Vector3 initVel;
    public float deceleration = 3f;

    //Audio
    AudioSource audioData;
    public AudioClip HitWall;
    public AudioClip HitMovable;

    public int id;

    bool stoped = true;
    bool hasContacted;

    Manager manager;

    float initialZ;

    void Start()
    {
        initialZ = gameObject.transform.position.z;
        audioData = GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        manager.AddObject(this);
        transform = gameObject.GetComponent<Transform>();
        velocity = initVel;
    }

    void Update()
    {
        MovementCycle();
        DecelerationCycle();
    }

    private void LateUpdate()
    {
        Vector3 newPos = gameObject.transform.position;
        newPos.z = initialZ;
        gameObject.transform.position = newPos;
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

    void PlayHitSound(AudioClip sound)
    {
        audioData.clip = sound;
        audioData.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (hasContacted)
        {
            hasContacted = false;
            return;
        }
        MovementScript others = collision.gameObject.GetComponent<MovementScript>();
        if (others != null && velocity.magnitude > others.velocity.magnitude)
        {
            
            others.hasContacted = true;
            PlayHitSound(HitMovable);
            Vector3 delta = velocity - others.velocity;
            //if (delta.x > 0 || delta.y > 0)
            //{
                float speed = ((velocity + others.velocity) / 2).magnitude;
                Vector3 direction = velocity.normalized;
                velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized * speed;
                others.AddVelocity(direction * speed);
            //}
            //else
            //{
            //    float speed = ((velocity + others.velocity) / 2).magnitude;
            //    velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized * speed;
            //    others.velocity = Vector3.Reflect(others.velocity, collision.GetContact(0).normal * -1).normalized * speed;
            //}
        }
        else
        {
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null && gameObject.GetComponent<PlayerController>() != null)
            {
                velocity = Vector3.zero;
                manager.LevelFailed();
            }
            else
            {
                PlayHitSound(HitWall);
                velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal);
            }
        }
    }
}
