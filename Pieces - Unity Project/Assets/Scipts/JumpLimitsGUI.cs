using UnityEngine;
using System.Collections;

public class JumpLimitsGUI : MonoBehaviour
{
	Manager manager;

    private void Start()
    {
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void Update()
	{
		
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 4 / 100;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		string text = "";
		if (manager.JumpLimits >= 100)
        {
			text = "Unlimited jumps";
        }
		else if(manager.finished)
		{
			this.enabled = false;
        }
		else
        {
			text = string.Format("Jumps remain: " + manager.JumpLimits);
        }
		GUI.Label(rect, text, style);
	}
}