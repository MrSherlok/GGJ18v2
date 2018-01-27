using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChoose : MonoBehaviour {

    [SerializeField]
    GameObject pl1;



    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log(col.gameObject.tag + "2");
            if (col.gameObject.tag == "TransmissionObj")
            {
                Debug.Log(col.gameObject.tag + "3");
                pl1.GetComponent<MovingMouse>().mouseModeJ1 = false;
                pl1.GetComponent<Joystick>().enabled = false;
                col.gameObject.GetComponent<StandardTelepatedObject>().StartTransmission();
                Time.timeScale = 1f;

                gameObject.SetActive(false);
            }
        }
    }

}
