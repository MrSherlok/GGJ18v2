using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator ani;
    public Rigidbody rigidbody;
    public float moveHorizontal;

	void Start ()
    {
        ani = transform.GetChild(0).GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        moveHorizontal = 0;

    }
    private void LateUpdate()
    {
        ani.SetFloat("Speed", rigidbody.velocity.magnitude);
    }
    public void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        
        rigidbody.velocity = new Vector3(moveHorizontal , rigidbody.velocity.y, 0f);

        if (moveHorizontal > 0.5f && moveHorizontal != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveHorizontal < 0.5f && moveHorizontal !=0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
        //Debug.Log(" Magn : " + rigidbody.velocity.magnitude);

    }
    public void Jump()
    {
        ani.SetTrigger("Jump");
    }
}
