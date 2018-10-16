using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{

    public GameObject collisionObj;
    GameObject sphereCol;

    public string XButton_PNum;
    public float abilCool = 1.0f;
    public float speed = 5.0f;
    // Use this for initialization

    private float nextAbil;
    private bool XButtonPressed = false;

    void Start()
    {
        sphereCol = Instantiate(collisionObj);
        sphereCol.transform.position = transform.position;
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
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
        Vector3 initalFoward = transform.forward;

        while (XButtonPressed  == true)
        {
            nextAbil += Time.deltaTime;
            sphereCol.transform.position += (initalFoward * moveSpeed * Time.deltaTime);
            yield return null;
        }
        sphereCol.GetComponentInChildren<MeshRenderer>().enabled = false;
        if (sphereCol.GetComponent<SphereCollisionCheck>().isCollision == true)
        {
            nextAbil = Time.time;
            print("Teleportation Failed ");
            sphereCol.transform.position = transform.position;
        }
        else if(sphereCol.GetComponent<SphereCollisionCheck>().isCollision == false)
        {
            transform.position = sphereCol.transform.position;
            print("Teleportation Success ");
        }
    }
}