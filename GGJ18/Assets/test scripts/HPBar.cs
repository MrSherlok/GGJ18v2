using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

    [SerializeField]
    private GameObject[] hearts;

    public void HPBarStatus(int hp)
    {
        if(hp == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
        }
        if (hp == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
        }
        if (hp == 1)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
        if (hp == 0)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
    }
}
