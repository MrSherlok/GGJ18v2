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
		if(Joystick.isPl1Dead == true && Joystick2.isPl2Dead == true)
        {
            Time.timeScale = 0f;
            dethPan.SetActive(true);
        }

    }
}
