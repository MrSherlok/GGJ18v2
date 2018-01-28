using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public Animator ani;
    public Rigidbody rigidbody;
    public float moveHorizontal;

    Vector3 pos1;
    Vector3 pos2;

    void Start()
    {
        ani = transform.GetChild(0).GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        moveHorizontal = 0;
        pos2 = transform.position;

    }

    public void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        pos1 = pos2;
        pos2 = transform.position;
        if ((pos2.x - pos1.x) > 0.2)
            moveHorizontal = 1;
        else if ((pos2.x - pos1.x) < -0.2)
            moveHorizontal = -1;
        else
            moveHorizontal = 0;

        rigidbody.velocity = new Vector3(moveHorizontal, rigidbody.velocity.y, 0f);

        if (moveHorizontal > 0.5f && moveHorizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveHorizontal < 0.5f && moveHorizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //Debug.Log(" Magn : " + rigidbody.velocity.magnitude);

    }

    private void LateUpdate()
    {
        ani.SetFloat("Speed", rigidbody.velocity.magnitude);
    }
    public void Jump()
    {
        ani.SetTrigger("Jump");
    }





    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Cat1")
        {
            //dead scene
            col.gameObject.GetComponent<Joystick>().isPl1Active = false;
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "Cat2")
        {
            //dead scene
            col.gameObject.GetComponent<Joystick2>().isPl2Active = false;
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
