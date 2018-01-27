using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddHero : MonoBehaviour {

    public static bool isPl1Ready = false;
    public static bool isPl2Ready = false;



    [SerializeField]
    GameObject pl1;

    [SerializeField]
    GameObject pl2;


    private void Awake()
    {
        if(PlayerPrefs.GetString("Joystick1Jump") == null || PlayerPrefs.GetString("Joystick1Jump") == "None")
        {
            PlayerPrefs.SetString("Joystick1Jump", "Joystick1Button2");
            PlayerPrefs.SetString("Joystick1Fire", "Joystick1Button3");
            PlayerPrefs.SetString("Joystick1SuperFire", "Joystick1Button4");
            PlayerPrefs.SetString("Joystick2Jump", "Joystick2Button2");
            PlayerPrefs.SetString("Joystick2Fire", "Joystick2Button3");
            PlayerPrefs.SetString("Joystick2SuperFire", "Joystick2Button4");
        }
        Debug.Log(PlayerPrefs.GetString("Joystick1Jump"));
        Debug.Log(PlayerPrefs.GetString("Joystick1Fire"));
        Debug.Log(PlayerPrefs.GetString("Joystick1SuperFire"));
        Debug.Log(PlayerPrefs.GetString("Joystick2Jump"));
        Debug.Log(PlayerPrefs.GetString("Joystick2Fire"));
        Debug.Log(PlayerPrefs.GetString("Joystick2SuperFire"));
    }


    void Start()
    {
        isPl1Ready = false;
        isPl2Ready = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            isPl1Ready = !isPl1Ready;
            pl1.SetActive(isPl1Ready);
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            isPl2Ready = !isPl2Ready;
            pl2.SetActive(isPl2Ready);
        }


        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            SceneManager.LoadScene(1);
        }
    }
}
