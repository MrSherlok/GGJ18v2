using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ChengeButton : MonoBehaviour
{
    [SerializeField]
    KeyCode active;
    [SerializeField]
    KeyCode jump;
    [SerializeField]
    KeyCode fire;
    [SerializeField]
    KeyCode superFire;
    [SerializeField]
    Text activeT;
    [SerializeField]
    Text jumpT;
    [SerializeField]
    Text fireT;
    [SerializeField]
    Text superFireT;

    [SerializeField]
    Text chengeBtnT;


    int joystickID = 1;

    KeyCode tmp = KeyCode.None;



    private void Start()
    {
        joystickID = 1;
        active = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Active"));
        jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Jump"));
        fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Fire"));
        superFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1SuperFire"));
        chengeBtnT.text = "Joystick 1";
        ChengeJoystick();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            SceneManager.LoadScene(0);
        }
        if (active == KeyCode.None)
        {
            if (joystickID == 1)
            {
                active = WaitBtn(activeT);
                activeT.text = active.ToString();
                PlayerPrefs.SetString("Joystick1Active", active.ToString());
            }
            else
            {
                if (joystickID == 2)
                {
                    active = WaitBtnJ2(activeT);
                    activeT.text = active.ToString();
                    PlayerPrefs.SetString("Joystick2Active", active.ToString());
                }
            }
        }
        if (jump == KeyCode.None)
        {
            if (joystickID == 1)
            {
                jump = WaitBtn(jumpT);
                jumpT.text = jump.ToString();
                PlayerPrefs.SetString("Joystick1Jump", jump.ToString());
            }
            else
            {
                if (joystickID == 2)
                {
                    jump = WaitBtnJ2(jumpT);
                    jumpT.text = jump.ToString();
                    PlayerPrefs.SetString("Joystick2Jump", jump.ToString());
                }
            }
        }
        if(fire == KeyCode.None)
        {
            if (joystickID == 1)
            {
                fire = WaitBtn(fireT);
                fireT.text = fire.ToString();
                PlayerPrefs.SetString("Joystick1Fire", fire.ToString());
            }
            else
            {
                if (joystickID == 2)
                {
                    fire = WaitBtnJ2(fireT);
                    fireT.text = fire.ToString();
                    PlayerPrefs.SetString("Joystick2Fire", fire.ToString());
                }
            }
        }
        if(superFire == KeyCode.None)
        {            
            if (joystickID == 1)
            {
                superFire = WaitBtn(superFireT);
                superFireT.text = superFire.ToString();
                PlayerPrefs.SetString("Joystick1SuperFire", superFire.ToString());
            }
            else
            {
                if (joystickID == 2)
                {
                    superFire = WaitBtnJ2(superFireT);
                    superFireT.text = superFire.ToString();
                    PlayerPrefs.SetString("Joystick2SuperFire", superFire.ToString());
                }
            }
        }
    }


    KeyCode WaitBtn(Text txt)
    {
        KeyCode _tmp = KeyCode.None;
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            _tmp =  KeyCode.Joystick1Button0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _tmp =  KeyCode.Joystick1Button1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            _tmp =  KeyCode.Joystick1Button2;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            _tmp =  KeyCode.Joystick1Button3;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            _tmp =  KeyCode.Joystick1Button4;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            _tmp =  KeyCode.Joystick1Button5;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            _tmp =  KeyCode.Joystick1Button6;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            _tmp =  KeyCode.Joystick1Button7;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            _tmp =  tmp;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            _tmp =  KeyCode.Joystick1Button9;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button10))
        {
            _tmp =  tmp;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button11))
        {
            _tmp =  KeyCode.Joystick1Button11;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button12))
        {
            _tmp =  KeyCode.Joystick1Button12;
        }
        txt.text = _tmp.ToString();
        return _tmp;
    }


    KeyCode WaitBtnJ2(Text txt)
    {
        KeyCode _tmp = KeyCode.None;
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            _tmp = KeyCode.Joystick2Button0;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            _tmp = KeyCode.Joystick2Button1;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            _tmp = KeyCode.Joystick2Button2;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button3))
        {
            _tmp = KeyCode.Joystick2Button3;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button4))
        {
            _tmp = KeyCode.Joystick2Button4;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button5))
        {
            _tmp = KeyCode.Joystick2Button5;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button6))
        {
            _tmp = KeyCode.Joystick2Button6;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            _tmp = KeyCode.Joystick2Button7;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button8))
        {
            _tmp = tmp;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button9))
        {
            _tmp = KeyCode.Joystick2Button9;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button10))
        {
            _tmp = tmp;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button11))
        {
            _tmp = KeyCode.Joystick2Button11;
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button12))
        {
            _tmp = KeyCode.Joystick2Button12;
        }
        txt.text = _tmp.ToString();
        return _tmp;
    }


    public void ChengeActive()
    {
        tmp = active;
        active = KeyCode.None;
    }

    public void ChengeJump()
    {
        tmp = jump;
        jump = KeyCode.None;
    }

    public void ChengeFire()
    {
        tmp = fire;
        fire = KeyCode.None;
    }

    public void ChengeSuperFire()
    {
        tmp = superFire;
        superFire = KeyCode.None;
    }


    public void Reset()
    {
        if (joystickID == 1)
        {
            active = KeyCode.Joystick1Button0;
            jump = KeyCode.Joystick1Button2;
            fire = KeyCode.Joystick1Button3;
            superFire = KeyCode.Joystick1Button4;
        }
        if(joystickID == 2)
        {
            active = KeyCode.Joystick2Button0;
            jump = KeyCode.Joystick2Button2;
            fire = KeyCode.Joystick2Button3;
            superFire = KeyCode.Joystick2Button4;
        }
    }

    public void ChengeJoystick()
    {
        if (joystickID == 1)
        {
            joystickID = 2;
            active = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Active"));
            jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Jump"));
            fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2Fire"));
            superFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick2SuperFire"));
            chengeBtnT.text = "Joystick 2";
            jumpT.text = jump.ToString();
            fireT.text = fire.ToString();
            superFireT.text = superFire.ToString();
            activeT.text = active.ToString();
            //Debug.Log(PlayerPrefs.GetString("Joystick1Jump"));
            //Debug.Log(PlayerPrefs.GetString("Joystick1Fire"));
            //Debug.Log(PlayerPrefs.GetString("Joystick1SuperFire"));
            //Debug.Log(PlayerPrefs.GetString("Joystick2Jump"));
            //Debug.Log(PlayerPrefs.GetString("Joystick2Fire"));
            //Debug.Log(PlayerPrefs.GetString("Joystick2SuperFire"));
        }
        else
        {
            if (joystickID == 2)
            {
                joystickID = 1;
                active = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Active"));
                jump = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Jump"));
                fire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1Fire"));
                superFire = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Joystick1SuperFire"));
                chengeBtnT.text = "Joystick 1";
                jumpT.text = jump.ToString();
                fireT.text = fire.ToString();
                superFireT.text = superFire.ToString();
                activeT.text = active.ToString();
            }
        }
    }
}
