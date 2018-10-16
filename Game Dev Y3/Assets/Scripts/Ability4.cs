using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability4 : MonoBehaviour
{

    public GameObject collisionObj;
    GameObject sphereCol;

    public string RB_PNum;
    public float abilCool = 3.0f;
    public float speed = 13.0f;
    public float distance = 4.0f;
    public float hookReelSpd = 1.0f;

    public bool extendHook = false;
    public bool reelHook = false;
    public float nextAbil;
    public bool XButtonPressed = false;

    void Start()
    {
        sphereCol = Instantiate(collisionObj);
        sphereCol.name = "grappleHook";
        sphereCol.transform.position = transform.position;
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
        sphereCol.GetComponent<Collider>().enabled = false;
        sphereCol.GetComponent<SphereCollisionCheck>().playerThrow = transform.gameObject;
        extendHook = false;
        reelHook = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(RB_PNum) && Time.time > nextAbil && extendHook == false && reelHook == false)
        {
            // set time for when next use of ability available
            nextAbil = Time.time + abilCool;
            sphereCol.transform.position = transform.position + (transform.forward * 3.0f);
            StartCoroutine(HookReelOut(transform.position, speed, distance));
        }
        if (sphereCol.GetComponentInChildren<MeshRenderer>().enabled == false)
            sphereCol.transform.position = new Vector3(5.0f,5.0f,5.0f);
    }

    private enum grabbedObj
    {
        nothing,
        wall,
        player,
        other
    };

    private IEnumerator HookReelOut(Vector3 origin, float moveSpeed, float range)
    {
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = true;
        Vector3 initalFoward = transform.forward;
        float current = 0.0f;
        sphereCol.GetComponent<Collider>().enabled = true;
        // Make sure its clean before we start
        sphereCol.GetComponent<SphereCollisionCheck>().isCollision = false;
        sphereCol.GetComponent<SphereCollisionCheck>().isPlayerCollision = false;

        extendHook = true;
        grabbedObj grabbed = grabbedObj.nothing;
        
        while (extendHook == true)
        {
            transform.position = origin;
            // Continue Hook until any 3 conditions met
            if (sphereCol.GetComponent<SphereCollisionCheck>().isCollision)
            { // Wall hit
                extendHook = false;
                grabbed = grabbedObj.wall;
            }
            else if (sphereCol.GetComponent<SphereCollisionCheck>().isPlayerCollision)
            { // Player hit
                extendHook = false;
                grabbed = grabbedObj.player;
            }
            else if (current > range) // Missed
            {
                extendHook = false;
                grabbed = grabbedObj.nothing;
            }
            else
            {
                grabbed = grabbedObj.other;
                current = current + Time.deltaTime * moveSpeed;
                sphereCol.transform.position += (initalFoward * moveSpeed * Time.deltaTime);
                nextAbil += Time.deltaTime / 2; // Don't reset cool down if extending
            }
            yield return null;
        }
        reelHook = true;
        if (grabbed == grabbedObj.wall)
        {
            StartCoroutine(lerpHook(transform.position, sphereCol.transform.position, hookReelSpd, transform.gameObject));
            while (reelHook)
            {
                yield return null;
            }
        }
        else if (grabbed == grabbedObj.player)
        {
            StartCoroutine(lerpHook(sphereCol.GetComponent<SphereCollisionCheck>().playerHit.transform.position, transform.position, hookReelSpd, sphereCol.GetComponent<SphereCollisionCheck>().playerHit));
            StartCoroutine(lerpHook(sphereCol.transform.position, transform.position, hookReelSpd, sphereCol));
            while (reelHook)
            {
                transform.position = origin;
                yield return null;
            }
        }
        else if (grabbed == grabbedObj.nothing)
        {
            //transform.position = origin;
            StartCoroutine(lerpHook(sphereCol.transform.position, transform.position, hookReelSpd, sphereCol.transform.gameObject));
            while (reelHook)
                yield return null;
        }


        // Make sure its set off after were done
        sphereCol.GetComponent<SphereCollisionCheck>().isCollision = false;
        sphereCol.GetComponent<SphereCollisionCheck>().isPlayerCollision = false;
 
        // Don't need the collider anymore
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
        sphereCol.GetComponent<Collider>().enabled = false;

    }

    private IEnumerator lerpHook(Vector3 start, Vector3 end, float lerpTime, GameObject affectedObj)
    {
        float current = 0.0f;
        while (current <= lerpTime)
        {
            current = current + Time.deltaTime * 2;
            float percent = Mathf.Clamp01(current / lerpTime);
            affectedObj.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(start, end, percent));
            yield return null;
        }
        reelHook = false;
    }
}
