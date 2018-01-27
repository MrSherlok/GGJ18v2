using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private int speed = 1;
    private int damage = 1;
    private GameObject hpBar;
    private GameObject hpBar1;

    private void Start()
    {
        hpBar = GameObject.Find("HP");
        hpBar1 = GameObject.Find("HP1");
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Walls")
        {
            gameObject.transform.Rotate(0, 180, 0, 0);
            //gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "Bullet")
        {
            col.gameObject.GetComponent<Patron>().defDamage += -1;
            gameObject.SetActive(false);
        }
            if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<Joystick>() != null)
            {
                col.gameObject.GetComponent<Joystick>().health += -1;
                if (hpBar != null)
                {
                    hpBar.GetComponent<HPBar>().HPBarStatus(col.gameObject.GetComponent<Joystick>().health);
                }
            }
            if (col.gameObject.GetComponent<Joystick2>() != null)
            {
                col.gameObject.GetComponent<Joystick2>().health += -1;
                if (hpBar1 != null)
                {
                    hpBar1.GetComponent<HPBar>().HPBarStatus(col.gameObject.GetComponent<Joystick2>().health);
                }
            }
            
           
                gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * -1 * speed);
    }
}
