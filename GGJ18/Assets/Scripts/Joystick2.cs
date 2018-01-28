using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joystick2 : MonoBehaviour {

    public static bool isPl2Dead = false;
    public PlayerController playerController;

    public int health = 3;

    public bool isPl2Active = true;


    public bool isWithVasePl2 = false;
    public GameObject vase;
    private bool firstUpd = false;

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


    KeyCode Active;
    KeyCode Jump;
    KeyCode Fire;
    KeyCode SuperFire;
    KeyCode StartB;


    [SerializeField]
    private bool isGraunded = false;


    private void Awake()
    {
        Active = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Active"));
        Jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Jump"));
        Fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Fire"));
        SuperFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2SuperFire"));
        StartB = KeyCode.Joystick2Button9;
        //Debug.Log(((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2SuperFire"))).ToString());
    }


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        isPl2Dead = false;
        rb = gameObject.GetComponent<Rigidbody>();
        superShotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y >= 1.1f || rb.velocity.y <= -1.1f)
        {
            isGraunded = false;
        }
        else
        {
            isGraunded = true;
        }


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
        }

        if (!isPl2Dead && isPl2Active)
        {

            if (Input.GetKeyDown(Active) && isWithVasePl2)
            {
                if (vase != null && firstUpd)
                {
                    firstUpd = false;
                    isWithVasePl2 = false;
                    vase.transform.parent = null;
                    vase.GetComponent<vase>().wasPushed = true;
                    if(gameObject.transform.rotation.y == 0)
                    vase.GetComponent<Rigidbody>().AddForce(new Vector3(3000, 1000, 0));
                    else
                        vase.GetComponent<Rigidbody>().AddForce(new Vector3(-3000, 1000, 0));
                }
                else
                {
                    firstUpd = true;
                }
            }

            if (Input.GetKeyDown(Jump) && isGraunded)
            {
                movement = new Vector2(0, 1);
                rb.AddForce(movement * jumpSpeed);
            }

            if (Input.GetKeyDown(Fire))
            {
                //Shooting();
            }
            if (Input.GetKeyDown(SuperFire))
            {
                if (superShotTimer >= 3)
                {
                    //SuperShooting();
                    superShotTimer = 0;
                }
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
                playerController.moveHorizontal = moveH;
            }
            else
            {
                playerController.moveHorizontal = 0;
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
                //Debug.Log("J2_R_J_Y_Axise = " + Input.GetAxis("J2_R_J_Y_Axise"));
            }
            if (Input.GetAxis("J2_R_J_X_Axise") != 0)
            {
                //Debug.Log("J2_R_J_X_Axise = " + Input.GetAxis("J2_R_J_X_Axise"));
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

                //Debug.Log("J2_L_B_X_Axise = " + moveH   /*Input.GetAxis("L_B_X_Axise")*/);
            }
            if (Input.GetAxis("J2_L_B_Y_Axise") != 0)
            {
                //Debug.Log("J2_L_B_Y_Axise = " + Input.GetAxis("J2_L_B_Y_Axise"));
            }
        }
        #endregion input
    }


    #region controlling
    void Jumping()
    {
        playerController.Jump();
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
