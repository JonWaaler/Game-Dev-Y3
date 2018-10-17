using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager_UI : MonoBehaviour {

    // UI Manager for
    public GameObject Restart_Canvus;
    private CameraBehavior cameraBehavior;

    private void Start()
    {
        cameraBehavior = FindObjectOfType<CameraBehavior>();

        if (cameraBehavior == null)
            print("<color = red> GameManager_UI can't find 'CameraBehavior'</color>");
    }

    public void Update()
    {
        if (cameraBehavior.players.Count <= 1)
        {
            Restart_Canvus.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    //public void Restart()
    //{
    //    print("HELLO WORLD");
    //}
}
