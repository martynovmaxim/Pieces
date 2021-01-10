using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public MovementScript movement;
    public GameObject Arrow;

    public PlayerInput controls;

    bool pressedSpace = false;
    float speed;
    public float speedIncrease;
    public float minSpeed = 0f;
    public float maxSpeed = 15f;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    private void Awake()
    {
        controls = new PlayerInput();
        controls.GameInput.Rotate.performed += ctx => Rotate(ctx.ReadValue<float>());
        controls.GameInput.Charge.performed += _ => Charge();
        controls.GameInput.Launch.performed += _ => Launch();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //read values
        if (pressedSpace)
        {
            speed = Mathf.Clamp(speed + speedIncrease * Time.deltaTime, minSpeed, maxSpeed);
            Debug.Log(speed);
        }
        //

    }

    void Launch()
    {
        Debug.Log("LAUNCH!");
        pressedSpace = false;
    }

    void Charge()
    {
        Debug.Log("Start charging");
        pressedSpace = true;
    }
    void Rotate(float value)
    {
        
        Debug.Log("Rot " + value);
    }
}
