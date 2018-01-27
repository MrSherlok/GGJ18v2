using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChoose : MonoBehaviour {

    [SerializeField]
    GameObject pl;

    bool StayInObj = false;

    Collider col;


    private void Update()
    {
        if (StayInObj)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                Debug.Log(col.gameObject.tag + "2");
                if (col.gameObject.tag == "TransmissionObjForPl1")
                {
                    Debug.Log(col.gameObject.tag + "3");
                    pl.GetComponent<MovingMouse>().mouseModeJ1 = false;
                    pl.GetComponent<Joystick>().isPl1Active = false;
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
        if (col.gameObject.tag == "TransmissionObjForPl1")
        {
            StayInObj = true;
            //Debug.Log(col.gameObject.tag + "1");
        }
        //if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        //{
        //    Debug.Log(col.gameObject.tag + "2");
        //    if (col.gameObject.tag == "TransmissionObj")
        //    {
        //        Debug.Log(col.gameObject.tag + "3");
        //        pl1.GetComponent<MovingMouse>().mouseModeJ1 = false;
        //        pl1.GetComponent<Joystick>().isPl1Active = false;
        //        col.gameObject.GetComponent<StandardTelepatedObject>().StartTransmission();
        //        Time.timeScale = 1f;

        //        gameObject.SetActive(false);
        //    }
        //}
    }
    void OnTriggerExit(Collider col)
    {
        this.col = col;
        if (col.gameObject.tag == "TransmissionObjForPl1")
        {
            StayInObj = false;
            //Debug.Log(col.gameObject.tag + "1");
        }
    }

    }
