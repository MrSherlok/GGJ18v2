using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Joystick : MonoBehaviour {

    public static bool isPl1Dead = false;


    public int health = 3;
    

    private Rigidbody rb;
    private float moveH;
    private float moveV;
    private Vector2 movement;
    [SerializeField]
    float speed;
    [SerializeField]
    int jumpSpeed;
    //[SerializeField]
    //GameObject deadScene;

    float superShotTimer = 0;


    
    KeyCode Jump;
    KeyCode Fire;
    KeyCode SuperFire;
    KeyCode StartB;


    [SerializeField]
    private bool isGraunded = false;

    private void Awake()
    {
        Jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Jump"));
        Fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Fire"));
        SuperFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1SuperFire"));
    }



    // Use this for initialization
    void Start () {
        isPl1Dead = false;
        Time.timeScale = 1f;
        rb = gameObject.GetComponent<Rigidbody>();
        superShotTimer = 0;

        //Debug.Log(PlayerPrefs.GetString("Joystick1Jump"));
        //Debug.Log(PlayerPrefs.GetString("Joystick1Fire"));
        //Debug.Log(PlayerPrefs.GetString("Joystick1SuperFire"));
        //Debug.Log(PlayerPrefs.GetString("Joystick2Jump"));
        //Debug.Log(PlayerPrefs.GetString("Joystick2Fire"));
        //Debug.Log(PlayerPrefs.GetString("Joystick2SuperFire"));

    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(rb.velocity.y);

        if (rb.velocity.y >= 1.1f || rb.velocity.y <= -1.1f)
        {
            isGraunded = false;
        } else
        {
            isGraunded = true;
        }


        //superShotTimer += Time.deltaTime;

        if (rb.velocity.x > 40)
        {
            rb.velocity = rb.velocity.normalized * 40;
        }


        #region hp

        if (health <= 0)
        {
            //DeadScene();
        }
        #endregion hp


        #region input

        if (Input.GetKeyDown(StartB))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Start");
        }

        if (!isPl1Dead)
        {
            //if (Input.GetKeyDown("J1_1_Button"))
            //{
            //    Debug.Log(1);
            //}
            //if (Input.GetButtonDown("J1_2_Button"))
            //{
            //    Debug.Log(2);
            //}
            if (Input.GetKeyDown(Jump) && isGraunded)
            {
                movement = new Vector2(0, 1);
                rb.AddForce(movement * jumpSpeed);
                Debug.Log(3);
            }
            //if (Input.GetButtonDown("J1_4_Button"))
            //{
            //    Debug.Log(4);
            //}
            if (Input.GetKeyDown(Fire))
            {
                //Shooting();
                Debug.Log("L1");
            }
            if (Input.GetKeyDown(SuperFire))
            {
                if(superShotTimer >= 3)
                {
                    //SuperShooting();
                    superShotTimer = 0;
                }
                Debug.Log("R1");
            }
            //if (Input.GetButtonDown("J1_7_Button"))
            //{
            //    Debug.Log("L2");
            //}
            //if (Input.GetButtonDown("J1_8_Button"))
            //{
            //    Debug.Log("R2");
            //}
            //if (Input.GetButtonDown("J1_9_Button"))
            //{
            //    Debug.Log("Select");
            //}

            //if (Input.GetButtonDown("J1_11_Button"))
            //{
            //    Debug.Log("LAxDown");
            //}
            //if (Input.GetButtonDown("J1_12_Button"))
            //{
            //    Debug.Log("RAxDown");
            //}
            if (Input.GetAxis("J1_L_J_X_Axise") != 0)
            {
                moveH = Input.GetAxis("J1_L_J_X_Axise");
                if (moveH < 0)
                    gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                if (moveH >= 0)
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                movement = new Vector2(moveH, 0);
                transform.Translate(Vector2.right * speed);
                //rb.AddForce(movement * speed);
                //Debug.Log("MainX = " + moveH);
            }
            if (Input.GetAxis("J1_L_J_Y_Axise") != 0)
            {
                //moveV = Input.GetAxis("L_J_Y_Axise");
                //movement = new Vector2(0, moveV*-1);
                //rb.AddForce(movement * speed);
                //Debug.Log("MainY = " + Input.GetAxis("J1_L_J_Y_Axise"));
            }
            if (Input.GetAxis("J1_R_J_Y_Axise") != 0)
            {
                Debug.Log("J1_R_J_Y_Axise = " + Input.GetAxis("J1_R_J_Y_Axise"));
            }
            if (Input.GetAxis("J1_R_J_X_Axise") != 0)
            {
                Debug.Log("J1_R_J_X_Axise = " + Input.GetAxis("J1_R_J_X_Axise"));
            }
            if (Input.GetAxis("J1_L_B_X_Axise") != 0)
            {
                moveH = Input.GetAxis("J1_L_B_X_Axise");
                if (moveH < 0)
                    gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                if (moveH >= 0)
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                movement = new Vector2(moveH, 0);
                transform.Translate(Vector2.right * speed);
                //rb.AddForce(movement * speed);
                Debug.Log("J1_L_B_X_Axise = " + moveH   /*Input.GetAxis("L_B_X_Axise")*/);
            }
            if (Input.GetAxis("J1_L_B_Y_Axise") != 0)
            {
                Debug.Log("J1_L_B_Y_Axise = " + Input.GetAxis("J1_L_B_Y_Axise"));
            }
        }
#endregion input
    }


#region controlling
    void Jumping()
    {
        movement = new Vector2(0, 1);
        rb.AddForce(movement * jumpSpeed);
    }

    //private int pat = 0;
    //[SerializeField]
    //private GameObject[] patron;

    //void Shooting()
    //{
    //    pat++;
    //    if (pat == 5)
    //        pat = 0;
    //    patron[pat].transform.position = transform.position;
    //    if (transform.rotation.y == 0)
    //    {
    //        patron[pat].GetComponent<Patron>().vector = 1;
    //    }
    //    else
    //    {
    //        patron[pat].GetComponent<Patron>().vector = -1;
    //    }
    //    patron[pat].SetActive(true);
    //}


    //private int Spat = 0;
    //[SerializeField]
    //private GameObject[] superpatron;

    //void SuperShooting()
    //{
    //    Spat++;
    //    if (Spat == 2)
    //        Spat = 0;
    //    superpatron[Spat].transform.position = transform.position;
    //    if (transform.rotation.y == 0)
    //    {
    //        superpatron[Spat].GetComponent<Patron>().vector = 1;
    //    }
    //    else
    //    {
    //        superpatron[Spat].GetComponent<Patron>().vector = -1;
    //    }
    //    superpatron[Spat].SetActive(true);
    //}

#endregion controlling

    //void DeadScene()
    //{
    //    isPl1Dead = true;
    //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //    rb.gravityScale = 0;
    //    if (Joystick2.isPl2Dead)
    //    {
    //        Time.timeScale = 0f;
    //        deadScene.SetActive(true);
    //    }
    //}

}
