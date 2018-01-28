using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlDead : MonoBehaviour {
    [SerializeField]
    GameObject pl1;
    [SerializeField]
    GameObject pl2;
    [SerializeField]
    GameObject dethPan;

    void Update () {
		if(pl1.GetComponent<Joystick>().isPl1Active == false && pl2.GetComponent<Joystick2>().isPl2Active == false)
        {
            Time.timeScale = 0f;
            dethPan.SetActive(true);
        }

    }
}
