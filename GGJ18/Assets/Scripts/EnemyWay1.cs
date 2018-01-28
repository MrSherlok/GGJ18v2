using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWay1 : MonoBehaviour {

    private Vector3 startPos;
    private Vector3 goPos;
    bool onPlace = false;

    void Start()
    {
        startPos = transform.position;
        ChooseAct();
    }

    IEnumerator II(Vector3 pos)
    {
        while (!onPlace)
        {
            if(transform.position.x  <= -22)
            {
                pos.x = -16;
            }
            if (transform.position.x >= 22)
            {
                pos.x = 16;
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, 0.3f);
            if (transform.position == pos)
                onPlace = true;
            yield return null;
        }
        ChooseAct();
    }

    IEnumerator Wait(float waitTime)
    {
        while (waitTime >= 0)
        {
            waitTime += -1;
            yield return new WaitForSeconds(1);
        }
        ChooseAct();
    }


    void Stay()
    {
        StartCoroutine(Wait(Random.Range(1, 5)));
    }

    void Going()
    {
        onPlace = false;
        goPos = new Vector3(transform.position.x + (Random.Range(-1f, 1f)*10), transform.position.y, 0);
        StartCoroutine(II(goPos));
    }

    void ChooseAct()
    {
        if (Random.Range(0, 9) < 5)
        {
            Stay();
        }
        else
            Going();
    }


}
