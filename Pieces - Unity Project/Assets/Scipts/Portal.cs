using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal AnotherPortal;
    GameObject ignore;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ignore) return;
        MovementScript obj = other.gameObject.GetComponent<MovementScript>();
        if (obj != null)
        {
            AnotherPortal.ignore = other.gameObject;
            obj.gameObject.transform.position = AnotherPortal.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ignore = null;
    }
}
