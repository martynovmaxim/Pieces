using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{

    public MovementScript movement;
    public GameObject Arrow;
    GameObject ArrowChild;
    MeshRenderer arrowRender;

    AudioSource audioData;
    public AudioClip LaunchSound;
    public AudioClip ChargeSound;

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
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (pressedSpace)
        {
            speed = Mathf.Clamp(speed + speedIncrease * Time.deltaTime, minLaunchSpeed, maxLaunchSpeed);
            arrowRender.material.SetFloat("Value", speed / maxLaunchSpeed);
        }
        float rotDir = controls.GameInput.Rotate.ReadValue<float>() * -1;
        if (rotDir != 0)
        {
            Arrow.transform.Rotate(0, 0, rotationSpeed * rotDir * Time.deltaTime);

        }

    }

    void Launch()
    {
        audioData.Stop();
        audioData.clip = LaunchSound;
        audioData.volume = 1;
        audioData.Play();
        pressedSpace = false;
        movement.SetVelocity(Arrow.transform.up * speed);
        speed = 0;
        DisableControls();
    }

    void Charge()
    {
        pressedSpace = true;
        audioData.clip = ChargeSound;
        audioData.volume = 0.75f;
        audioData.Play();
    }

    public void EnableControls()
    {
        controls.Enable();
        arrowRender.enabled = true;
    }

    public void DisableControls()
    {
        controls.Disable();
        arrowRender.material.SetFloat("Value", 0);
        arrowRender.enabled = false;
    }
}
