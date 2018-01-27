using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBleck : MonoBehaviour {

    [Range(0f,1f)]
    public float maxIntensity;
    [Range(0f,10f)]
    public float frq;
    private Light lamp;
    public bool isBlecking;
	void Start () {
        isBlecking = true;
        lamp = GetComponent<Light>();
        StartCoroutine(Bloom());
	}
	
	private IEnumerator Bloom()
    {
        while (isBlecking)
        {
            lamp.intensity = Random.Range(0f,maxIntensity);
            yield return new WaitForSeconds(Random.Range(0f,1*frq));
            yield return null;
        }
    }
}
