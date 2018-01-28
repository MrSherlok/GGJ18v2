using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye : MonoBehaviour {
    bool moving = false;
    GameObject pl;


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Cat1" || col.gameObject.tag == "Cat2")
        {
            moving = true;
            pl = col.gameObject;
            StartCoroutine(MoveToPl());
        }
    }


    IEnumerator MoveToPl()
    {
        while (moving)
        {
            if(gameObject.transform.parent.transform.position == pl.transform.position)
            {
                moving = false;
            }
            gameObject.transform.parent.transform.position = Vector3.MoveTowards(gameObject.transform.parent.transform.position, pl.transform.position, 3f);
            yield return null;
        }

        pl.SetActive(false);
    }
}
