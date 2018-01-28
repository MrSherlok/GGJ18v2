using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMousePl2 : MonoBehaviour {

    [SerializeField]
    GameObject mouse;

    public bool mouseModeJ2 = false;
    private float speedKoef = 0.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick2Button6))
        {
            if (gameObject.GetComponent<Joystick2>().isPl2Active)
            {
                mouseModeJ2 = true;
                mouse.SetActive(mouseModeJ2);
                gameObject.GetComponent<Joystick2>().isPl2Active = false;
            }
            else
            {
                mouseModeJ2 = false;
                mouse.SetActive(mouseModeJ2);
                gameObject.GetComponent<Joystick2>().isPl2Active = true;
            }

            if (mouseModeJ2)
            {
                mouse.transform.position = new Vector3(transform.position.x, transform.position.y, mouse.transform.position.z);
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            Debug.Log(mouseModeJ2);
        }
        if (mouseModeJ2)
        {

            if (Input.GetAxis("J2_L_J_X_Axise") != 0)
            {
                mouse.transform.Translate(Vector2.right * Input.GetAxis("J2_L_J_X_Axise") * speedKoef);
                //rb.AddForce(movement * speed);
                //Debug.Log("J1_L_B_X_Axise = " + Input.GetAxis("J1_L_B_X_Axise"));
            }
            if (Input.GetAxis("J2_L_J_Y_Axise") != 0)
            {
                mouse.transform.Translate(Vector2.up * Input.GetAxis("J2_L_J_Y_Axise") * -speedKoef);
                //Debug.Log("J1_L_B_Y_Axise = " + Input.GetAxis("J1_L_B_Y_Axise"));
            }
        }



    }

}
