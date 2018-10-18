using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{

    public GameObject collisionObj;
    GameObject sphereCol;

    public string XButton_PNum;
    public float abilCool = 1.0f;
    public float speed = 6.0f;
    public float distance = 7.5f;

    // Use this for initialization

    private float nextAbil;
    private bool XButtonPressed = false;

    void Start()
    {
        sphereCol = Instantiate(collisionObj);
        sphereCol.transform.position = transform.position;
        sphereCol.name = "teleporter";
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
        sphereCol.GetComponent<Collider>().enabled = false;
        sphereCol.GetComponent<SphereCollisionCheck>().playerThrow = transform.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(XButton_PNum) && Time.time > nextAbil)
        {
            // set time for when next use of ability available
            nextAbil = Time.time + abilCool;
            XButtonPressed = true;
            StartCoroutine(Teleport(transform.position, speed));
        }
        else if (Input.GetButtonUp(XButton_PNum))
        {
            XButtonPressed = false;
        }
    }

    private IEnumerator Teleport(Vector3 origin, float moveSpeed)
    {
        sphereCol.transform.position = origin;
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = true;
        sphereCol.GetComponent<Collider>().enabled = true;

        Vector3 initalFoward = transform.forward;
        float current = 0;
//        while (XButtonPressed  == true)
           while(current <= distance)
        {
//            nextAbil += Time.deltaTime;
            current+= moveSpeed*Time.deltaTime*20;
            sphereCol.transform.position += (initalFoward * moveSpeed * Time.deltaTime * 20);
            yield return null;
        }

        transform.position = sphereCol.transform.position; // comment this line and uncoment below for non wall teleportation
        
        /*
        if (sphereCol.GetComponent<SphereCollisionCheck>().isCollision == true)
        {
            nextAbil = Time.time;
            sphereCol.transform.position = transform.position;
        }
        else if(sphereCol.GetComponent<SphereCollisionCheck>().isCollision == false)
        {
            transform.position = sphereCol.transform.position;
        }
        */

        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
        sphereCol.GetComponent<Collider>().enabled = false;


    }
}