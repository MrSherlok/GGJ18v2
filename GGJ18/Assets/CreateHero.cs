using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHero : MonoBehaviour
{
    [SerializeField]
    GameObject[] pl1;

    [SerializeField]
    GameObject[] pl2;


    void Awake()
    {
        if (AddHero.isPl1Ready)
        {
            for(int i =0; i < pl1.Length; i++)
            {
                pl1[i].SetActive(true);
            }
        }

        if (AddHero.isPl2Ready)
        {
            for (int i = 0; i < pl2.Length; i++)
            {
                pl2[i].SetActive(true);
            }
        }

    }
}
