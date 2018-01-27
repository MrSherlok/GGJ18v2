using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChoosepl2 : MonoBehaviour {

    [SerializeField]
    GameObject pl;

    bool StayInObj = false;

    Collider col;


    private void Update()
    {
        if (StayInObj)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                Debug.Log(col.gameObject.tag + "2");
                if (col.gameObject.tag == "TransmissionObjForPl2")
                {
                    Debug.Log(col.gameObject.tag + "3");
                    pl.GetComponent<MovingMousePl2>().mouseModeJ2 = false;
                    pl.GetComponent<Joystick2>().isPl2Active = false;
                    col.gameObject.GetComponent<StandardTelepatedObject>().StartTransmission();
                    Time.timeScale = 1f;

                    gameObject.SetActive(false);
                }
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        this.col = col;
        if (col.gameObject.tag == "TransmissionObjForPl2")
        {
            StayInObj = true;
            //Debug.Log(col.gameObject.tag + "1");
        }

    }
    void OnTriggerExit(Collider col)
    {
        this.col = col;
        if (col.gameObject.tag == "TransmissionObjForPl2")
        {
            StayInObj = false;
            //Debug.Log(col.gameObject.tag + "1");
        }
    }
}
