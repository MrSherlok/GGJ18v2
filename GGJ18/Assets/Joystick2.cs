using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joystick2 : MonoBehaviour {

    public static bool isPl2Dead = false;

    public int health = 3;


    private Rigidbody2D rb;
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



    [SerializeField]
    KeyCode Jump;
    [SerializeField]
    KeyCode Fire;
    [SerializeField]
    KeyCode SuperFire;
    [SerializeField]
    KeyCode StartB;


    private void Awake()
    {
        Jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Jump"));
        Fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Fire"));
        SuperFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2SuperFire"));
        //Debug.Log(((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2SuperFire"))).ToString());
    }


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        isPl2Dead = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        superShotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {


        superShotTimer += Time.deltaTime;

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

        if (!isPl2Dead)
        {
            //if (Input.GetButtonDown("J2_1_Button"))
            //{
            //    Debug.Log(1);
            //}
            //if (Input.GetButtonDown("J2_2_Button"))
            //{
            //    Debug.Log(2);
            //}
            if (Input.GetKeyDown(Jump))
            {
                movement = new Vector2(0, 1);
                rb.AddForce(movement * jumpSpeed);
                Debug.Log(3);
            }
            //if (Input.GetButtonDown("J2_4_Button"))
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
                if (superShotTimer >= 3)
                {
                    //SuperShooting();
                    superShotTimer = 0;
                }
                Debug.Log("R1");
            }
            //if (Input.GetButtonDown("J2_7_Button"))
            //{
            //    Debug.Log("L2");
            //}
            //if (Input.GetButtonDown("J2_8_Button"))
            //{
            //    Debug.Log("R2");
            //}
            //if (Input.GetButtonDown("J2_9_Button"))
            //{
            //    Debug.Log("Select");
            //}

            //if (Input.GetButtonDown("J2_11_Button"))
            //{
            //    Debug.Log("LAxDown");
            //}
            //if (Input.GetButtonDown("J2_12_Button"))
            //{
            //    Debug.Log("RAxDown");
            //}
            if (Input.GetAxis("J2_L_J_X_Axise") != 0)
            {
                moveH = Input.GetAxis("J2_L_J_X_Axise");
                if (moveH < 0)
                    gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                if (moveH >= 0)
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                movement = new Vector2(moveH, 0);
                transform.Translate(Vector2.right * speed);
                //rb.AddForce(movement * speed);
                //Debug.Log("MainX = " + moveH);
            }
            if (Input.GetAxis("J2_L_J_Y_Axise") != 0)
            {
                //moveV = Input.GetAxis("L_J_Y_Axise");
                //movement = new Vector2(0, moveV*-1);
                //rb.AddForce(movement * speed);
                //Debug.Log("MainY = " + Input.GetAxis("J2_L_J_Y_Axise"));
            }
            if (Input.GetAxis("J2_R_J_Y_Axise") != 0)
            {
                Debug.Log("J2_R_J_Y_Axise = " + Input.GetAxis("J2_R_J_Y_Axise"));
            }
            if (Input.GetAxis("J2_R_J_X_Axise") != 0)
            {
                Debug.Log("J2_R_J_X_Axise = " + Input.GetAxis("J2_R_J_X_Axise"));
            }
            if (Input.GetAxis("J2_L_B_X_Axise") != 0)
            {
                moveH = Input.GetAxis("J2_L_B_X_Axise");
                if (moveH < 0)
                    gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                if (moveH >= 0)
                    gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                movement = new Vector2(moveH, 0);
                transform.Translate(Vector2.right * speed);
                //rb.AddForce(movement * speed);
                Debug.Log("J2_L_B_X_Axise = " + moveH   /*Input.GetAxis("L_B_X_Axise")*/);
            }
            if (Input.GetAxis("J2_L_B_Y_Axise") != 0)
            {
                Debug.Log("J2_L_B_Y_Axise = " + Input.GetAxis("J2_L_B_Y_Axise"));
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
    //    isPl2Dead = true;
    //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //    rb.gravityScale = 0;
    //    if (Joystick.isPl1Dead)
    //    {
    //        Time.timeScale = 0f;
    //        deadScene.SetActive(true);
    //    }
    //}

}
