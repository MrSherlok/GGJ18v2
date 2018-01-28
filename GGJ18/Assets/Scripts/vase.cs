using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vase : MonoBehaviour {


    public bool wasPushed = false;
    float timer;


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "enemy")
        {
            col.gameObject.SetActive(false);
        }
    }


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Cat1")
        {            
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Active"))))
            {
                Debug.Log(col.gameObject.name);
                col.gameObject.GetComponent<Joystick>().isWithVasePl1 = true;
                col.gameObject.GetComponent<Joystick>().vase = gameObject;
                gameObject.transform.SetParent(col.gameObject.transform, true);
                //here coord
            }
        }
        if (col.gameObject.tag == "Cat2")
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Active"))))
            {
                col.gameObject.GetComponent<Joystick2>().isWithVasePl2 = true;
                col.gameObject.GetComponent<Joystick2>().vase = gameObject;
                gameObject.transform.SetParent(col.gameObject.transform, true);
                //here coord
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Cat2" || col.gameObject.tag == "Cat1")
        {
            if (wasPushed)
            {
                timer = 2;
                wasPushed = false;
            }
        }
    }



    IEnumerator ChengeLayer()
    {
        while(timer > 0)
        {
            timer += -1;
            yield return null;
        }
        gameObject.layer = 10;
    }
}
