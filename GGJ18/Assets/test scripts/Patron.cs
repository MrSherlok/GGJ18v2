using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour {

    public int vector = 1;
    [SerializeField]
    private int speed = 1;
    [SerializeField]
    private int damage = 1;
    private float timer = 0;
    public int defDamage;

    private void OnEnable()
    {
        defDamage = damage;
        timer = 0;
    }

    // Update is called once per frame
    void Update () {
        if(defDamage <= 0)
        {
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;
        if (timer > 0.8)
            gameObject.SetActive(false);
        transform.Translate(Vector3.right * Time.deltaTime*vector*speed);
	}
}
