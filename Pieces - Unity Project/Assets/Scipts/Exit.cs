using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string NextLevelName;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().NextLevelName);
    }
}
