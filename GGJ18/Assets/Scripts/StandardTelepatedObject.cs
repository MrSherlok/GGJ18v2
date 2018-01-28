using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTelepatedObject : TelepatedObject {

    private float moveH;

    float movingTime;

    [SerializeField]
    GameObject pl1;
    [SerializeField]
    GameObject pl2;
    [SerializeField]
    Vector3 rot;
    public bool isPl1 = false;


    public override void Move()
    {
        if (isMoveable)
        {
            if (isPl1)
            {
                if (Input.GetAxis("J1_L_J_Y_Axise") != 0)
                {
                    transform.Translate(Vector2.up * Input.GetAxis("J1_L_J_Y_Axise") / 10 * -1);
                }
                if (Input.GetAxis("J1_L_J_X_Axise") != 0)
                {
                    transform.Translate(Vector2.right * Input.GetAxis("J1_L_J_X_Axise") / 10 * -1);
                }
            } else
            {
                if (Input.GetAxis("J2_L_J_Y_Axise") != 0)
                {
                    transform.Translate(Vector2.up * Input.GetAxis("J2_L_J_Y_Axise") / 10 * -1);
                }
                if (Input.GetAxis("J2_L_J_X_Axise") != 0)
                {
                    transform.Translate(Vector2.right * Input.GetAxis("J2_L_J_X_Axise") / 10 * -1);
                }
            }
        }
    }

    public override IEnumerator OnTransmissionLogic()
    {
        while (isOnTelepatingMode)
        {
            Move();
            Rotate();
            Use();
            if (isPl1)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button6))
                {
                    StopTransmission();
                }
            }else
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button6))
                {
                    StopTransmission();
                }
            }
            movingTime += Time.deltaTime;
            if (movingTime >= 5)
                StopTransmission();
            yield return null;
        }
    }



    public override void Rotate()
    {
        if (isRotateble)
        {
            if (isPl1)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                {
                    transform.rotation = new Quaternion(0,15,0,0);
                }
            } else
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                {
                    transform.rotation = new Quaternion(0, 15, 0, 0);
                }
            }
            //Тут как будто в апдейте ловишь листенер на кнопку "4"
            //If(Input/KeyCode(кнопка4) {Крутить объект на 90 градусов по x})
        }
    }

    public override void StartTransmission()
    {
        isOnTelepatingMode = true;
        StartCoroutine(OnTransmissionLogic());
    }

    public override void StopTransmission()
    {
        movingTime = 0;
        if(!isPl1)
            pl2.GetComponent<Joystick2>().isPl2Active = true;
        else
            pl1.GetComponent<Joystick>().isPl1Active = true;
        isOnTelepatingMode = false;
    }

    public override void Use()
    {
        if (isUseable)
        {
            if (isPl1)
            {

                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    Debug.Log("Use");
                }
            } else
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                {
                    Debug.Log("Use");
                }
            }
            //Отслеживаешь нажатие кнопки 3 и делаешь уникальное интерактивное действие (DEbug.Log)
        }
    }


}
