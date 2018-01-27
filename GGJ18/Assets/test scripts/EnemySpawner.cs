using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    private Vector2 leftPos = new Vector2(-2.68f, 0f);
    [SerializeField]
    private Vector2 rightPos = new Vector2(3f, 0f);
    [SerializeField]
    private bool isRight = true;
    float timer = 0;
    [SerializeField]
    private GameObject[] enemys;
    private int enemyNum = 0;
    [SerializeField]
    float spawnSpeed = 2f;

    private void Start()
    {
        enemyNum = -1;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        //check timer
        if(timer > spawnSpeed)
        {
            enemyNum++;
            if (enemyNum > 9)
                enemyNum = 0;
            timer = 0;
            //check where to spawn enemy
            if (isRight)
            {
                if (!enemys[enemyNum].active)
                {
                    enemys[enemyNum].transform.rotation = new Quaternion(0, 0, 0, 0);
                    enemys[enemyNum].transform.localPosition = rightPos;
                    enemys[enemyNum].SetActive(true);
                    isRight = false;
                }
            } else
            {
                if (!enemys[enemyNum].active)
                {
                    enemys[enemyNum].transform.rotation = new Quaternion(0, 180, 0, 0);
                    enemys[enemyNum].transform.localPosition = leftPos;
                    enemys[enemyNum].SetActive(true);
                    isRight = true;
                }
            }

        }
	}
}
