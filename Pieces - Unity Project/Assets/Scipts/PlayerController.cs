using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public MovementScript movement;
    public GameObject Arrow;
    GameObject ArrowChild;

    public PlayerInput controls;

    bool pressedSpace = false;
    bool pressedArrow = false;

    float speed;
    public float speedIncrease;
    public float minSpeed = 0f;
    public float maxSpeed = 15f;

    public float rotationSpeed;

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
        ArrowChild = Arrow.transform.GetChild(0).gameObject;
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
        float value = controls.GameInput.Rotate.ReadValue<float>();
        Arrow.transform.Rotate(0, 0, rotationSpeed * -value * Time.deltaTime);
        //

    }

    void Launch()
    {
        Debug.Log("LAUNCH!");
        pressedSpace = false;
        movement.velocity = Arrow.transform.up * speed;
        //Debug.Log(Arrow.transform.up);
        speed = 0;
        ArrowChild.GetComponent<MeshRenderer>().enabled = false;
    }

    void Charge()
    {
        Debug.Log("Start charging");
        pressedSpace = true;
    }
    void Rotate(float value)
    {
        ArrowChild.GetComponent<MeshRenderer>().enabled = true;
        //if (ArrowChild == null) Debug.Log("!!!!!!");
        //float z = Arrow.transform.rotation.z;
        //Arrow.transform.Rotate(0, 0, rotationSpeed * -value);
        //Debug.Log("Rot " + z);
    }
}
