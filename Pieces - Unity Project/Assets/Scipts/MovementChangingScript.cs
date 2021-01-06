using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChangingScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform transform;
    Vector3 velocity;
    public Vector3 initVel;
    public float deceleration;
    void Start()
    {
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
        velocity = Vector3.Reflect(velocity, collision.GetContact(0).normal);
    }
    private void MovementCycle()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void DecelerationCycle()
    {
        if (velocity.magnitude != 0)
        {
            float speed = velocity.magnitude;
            velocity *= (speed - deceleration * Time.deltaTime) / speed;
        }
    }

    public void SetSpeed(Vector3 newVelocity)
    {
        velocity += newVelocity;
    }
}
