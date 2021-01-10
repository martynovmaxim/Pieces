using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public MovementScript movement;
    public GameObject Arrow;
    GameObject ArrowChild;
    MeshRenderer arrowRender;

    public PlayerInput controls;

    bool pressedSpace = false;
    bool pressedArrow = false;

    float speed;
    public float speedIncrease;
    public float minLaunchSpeed = 1f;
    public float maxLaunchSpeed = 15f;

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
        controls.GameInput.Charge.performed += _ => Charge();
        controls.GameInput.Launch.performed += _ => Launch();
        ArrowChild = Arrow.transform.GetChild(0).gameObject;
        arrowRender = ArrowChild.GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(arrowRender.enabled);
        //Space
        if (pressedSpace)
        {
            speed = Mathf.Clamp(speed + speedIncrease * Time.deltaTime, minLaunchSpeed, maxLaunchSpeed);
            arrowRender.material.SetFloat("Value", speed / maxLaunchSpeed);
            Debug.Log(speed/maxLaunchSpeed);
        }
        //rot
        float rotDir = controls.GameInput.Rotate.ReadValue<float>() * -1;
        if (rotDir != 0) Arrow.transform.Rotate(0, 0, rotationSpeed * rotDir * Time.deltaTime);

    }

    void Launch()
    {
        //Debug.Log("LAUNCH!");
        pressedSpace = false;
        movement.SetVelocity(Arrow.transform.up * speed);
        speed = 0;
        DisableControls();
    }

    void Charge()
    {
        //Debug.Log("Start charging");
        pressedSpace = true;
    }

    public void EnableControls()
    {
        controls.Enable();
        arrowRender.enabled = true;
    }

    public void DisableControls()
    {
        controls.Disable();
        Debug.Log("Enabling controls");
        arrowRender.enabled = false;
    }
}
