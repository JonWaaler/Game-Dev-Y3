using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

    public string BButton_PNum;
    public float abilCool = 1;
    public float distance = 10.0f;
    public float lerpSpeed = 20.0f;
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
                    if (Mathf.Abs( hit.distance) < 1.25f)
                    {
                        rollDistance = 0.0f;
                    }
                    else
                    {
                        rollDistance = hit.distance;
                    }
                }
                else
                {
                    rollDistance = hit.distance;
                    print("Raycast hit: " + hit.transform.name);
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

                }
                    
                Vector3 hitPoint =  transform.position + (transform.forward * (rollDistance * .8f));
                StartCoroutine(Roll(transform.position, hitPoint, lerpSpeed));
            }
            else
            {
                rollDistance = distance;
                StartCoroutine(Roll(transform.position, transform.position + (transform.forward * rollDistance), lerpSpeed));
            }
        }

    }

    private IEnumerator Roll(Vector3 origin, Vector3 target, float velocity)
    {
        string gameObjTag = gameObject.tag;
        Color originColor = transform.GetChild(0).GetComponent<Renderer>().material.color;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        float current = 0.0f;//Elapsed time
        float rollLengh = (target - origin).magnitude; //Distance
        float totalTime = rollLengh / velocity; // Total time to finish distance at said velocity with: T = D/V

        while (current <= totalTime)
        {
            gameObject.tag = "Wall";

            current += Time.deltaTime; // Elapsed time
            float tValue = Mathf.Clamp01(current / totalTime); // figure out how much of % time has passed of elaped time relative to total time 
            GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(origin, target, tValue));

            yield return null;
        }
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", originColor);
        gameObject.tag = gameObjTag;
    }



}
