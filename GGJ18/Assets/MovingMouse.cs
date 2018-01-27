using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMouse : MonoBehaviour {

    [SerializeField]
    GameObject mouse;

    [SerializeField]
    //GameObject mouse1;

    public bool mouseModeJ1 = false;
    private bool mouseModeJ2 = false;
    private float speedKoef = 0.7f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            mouseModeJ1 = !mouseModeJ1;
            mouse.SetActive(mouseModeJ1);
            gameObject.GetComponent<Joystick>().enabled = !gameObject.GetComponent<Joystick>().enabled;
            if (mouseModeJ1)
            {
                mouse.transform.position = new Vector3(transform.position.x, transform.position.y, -5);
                Time.timeScale = 0.1f;
            } else
            {
                Time.timeScale = 1f;
            }
            Debug.Log(mouseModeJ1);
        }
        if (mouseModeJ1)
        {
            
            if (Input.GetAxis("J1_L_J_X_Axise") != 0)
            {
                mouse.transform.Translate(Vector2.right * Input.GetAxis("J1_L_J_X_Axise") * speedKoef);
                //rb.AddForce(movement * speed);
                //Debug.Log("J1_L_B_X_Axise = " + Input.GetAxis("J1_L_B_X_Axise"));
            }
            if (Input.GetAxis("J1_L_J_Y_Axise") != 0)
            {
                mouse.transform.Translate(Vector2.up * Input.GetAxis("J1_L_J_Y_Axise")* -speedKoef);
                //Debug.Log("J1_L_B_Y_Axise = " + Input.GetAxis("J1_L_B_Y_Axise"));
            }
        }

        //if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        //{
        //    mouseModeJ2 = !mouseModeJ2;
        //    mouse1.SetActive(mouseModeJ2);
        //    Debug.Log(mouseModeJ2);
        //}
        //if (mouseModeJ2)
        //{
        //    if (Input.GetAxis("J2_L_J_X_Axise") != 0)
        //    {
        //        mouse1.transform.Translate(Vector2.right * Input.GetAxis("J2_L_J_X_Axise") * speedKoef);
        //        //rb.AddForce(movement * speed);
        //        //Debug.Log("J1_L_B_X_Axise = " + Input.GetAxis("J1_L_B_X_Axise"));
        //    }
        //    if (Input.GetAxis("J2_L_J_Y_Axise") != 0)
        //    {
        //        mouse1.transform.Translate(Vector2.up * Input.GetAxis("J2_L_J_Y_Axise") * -speedKoef);
        //        //Debug.Log("J1_L_B_Y_Axise = " + Input.GetAxis("J1_L_B_Y_Axise"));
        //    }
        //}

    }

}
