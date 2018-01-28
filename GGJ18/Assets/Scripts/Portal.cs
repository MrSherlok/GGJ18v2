using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Portal : MonoBehaviour {

    public bool isDoorOpen = false;

    [SerializeField]
    GameObject pointB;
    
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Cat1")
        {
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Active"))))
                if (isDoorOpen)
                {
                    col.gameObject.transform.position = new Vector3(pointB.transform.position.x, pointB.transform.position.y, 0);
                }

        }
        if (col.gameObject.tag == "Cat2")
        {
            if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Active"))))
                if (isDoorOpen)
                    col.gameObject.transform.position = new Vector3(pointB.transform.position.x, pointB.transform.position.y, 0);
        }
    }

	}
