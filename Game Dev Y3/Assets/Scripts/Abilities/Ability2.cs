using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour {

    public string YButton_PNum;
    public float abilCool = 5;
    public float invisTime = 4.0f;
    public float animateTime = 0.5f;

    private float rollDistance = 10.0f;
    private float nextAbil; 
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetButtonDown(YButton_PNum) && Time.time > nextAbil)
        {
            // set time for when next use of ability available
            nextAbil = Time.time + abilCool;

            GameObject child = transform.GetChild(0).gameObject;
            StartCoroutine(Invisible(animateTime, invisTime, child));
        }

    }

    private IEnumerator Invisible( float lerpTime, float duration, GameObject affectedObj)
    {
        float current = 0.0f;
        while(current <= lerpTime)
        {
            current = current + Time.deltaTime;
            float percent = Mathf.Clamp01(current / lerpTime);
            Color alpha = affectedObj.GetComponent<Renderer>().material.color;
            alpha.a = 1 - percent;

            affectedObj.GetComponent<Renderer>().material.color = alpha;
            yield return null;
        }

        current = 0.0f;
        GameObject child = transform.GetChild(1).gameObject;
        affectedObj.GetComponent<Renderer>().enabled = false;
        child.GetComponent<Renderer>().enabled = false;

        while (current <= duration)
        {
            current = current + Time.deltaTime;
            yield return null;
        }
        affectedObj.GetComponent<Renderer>().enabled = true;
        child.GetComponent<Renderer>().enabled = true;

        current = 0.0f;
        while (current <= lerpTime)
        {
            current = current + Time.deltaTime;
            float percent = Mathf.Clamp01(current / lerpTime);
            Color alpha = affectedObj.GetComponent<Renderer>().material.color;
            alpha.a = percent;

            affectedObj.GetComponent<Renderer>().material.color = alpha;
            yield return null;
        }


    }



}
