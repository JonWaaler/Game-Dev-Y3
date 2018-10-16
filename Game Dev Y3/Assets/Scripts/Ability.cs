using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

    public string BButton_PNum;
    public float abilCool = 1;
    public float distance = 10.0f;
    public float rollTime = 0.5f;

    //    private WaitForSeconds lerpDuration = new WaitForSeconds(2);
    private float rollDistance = 10.0f;
    private float nextAbil; 
	
	// Update is called once per frame
	void Update ()
    {
        int layerMask = 1 << 2; // layer 2 says ignore raycast
        layerMask = ~layerMask; // all but layer 2

        if (Input.GetButtonDown(BButton_PNum) && Time.time > nextAbil)
        {
            // set time for when next use of ability available
            nextAbil = Time.time + abilCool;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))
            {
                if (hit.collider.tag.Equals("Wall"))
                {
                    if (Mathf.Abs( hit.distance) < 1.75f)
                    {
                        rollDistance = 0.0f;
                    }
                    else
                    {
                        rollDistance = hit.distance;
                        print("Raycast hit: " + hit.transform.name);
                    }
                }
                else
                {
                    rollDistance = hit.distance;
                    print("Raycast hit: " + hit.transform.name);
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

                }
                    
                Vector3 hitPoint =  transform.position + (transform.forward * (rollDistance * .8f));
                StartCoroutine(Roll(transform.position, hitPoint, rollTime));
            }
            else
            {
                rollDistance = distance;
                StartCoroutine(Roll(transform.position, transform.position + (transform.forward * rollDistance), rollTime));
            }
        }

    }

    private IEnumerator Roll(Vector3 origin, Vector3 target, float lerpTime)
    {
        float current = 0.0f;
        string gameObjTag = gameObject.tag;
//        Color originColor =  <Material>().color;
  //      gameObject.GetComponentInChildren<Material>().color = Color.green;
        while (current <= lerpTime)
        {
            gameObject.tag = "Wall";
            current = current + Time.deltaTime;
            float percent = Mathf.Clamp01(current / lerpTime);
            GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(origin, target, percent));
            yield return null;
        }
//        gameObject.GetComponentInChildren<Material>().color = originColor;
        gameObject.tag = gameObjTag;
    }



}
