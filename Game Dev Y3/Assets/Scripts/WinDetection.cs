using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinDetection : MonoBehaviour {


    private float health = 100F;
    private Slider slider_PlayerHealth;

    // Attach to the player.
    private void Start()
    {
        if (gameObject.name == "Player Parent 1")
        {
            slider_PlayerHealth = GameObject.Find("Player 1 - Health").GetComponent<Slider>();
        }
        else if (gameObject.name == "Player Parent 2")
        {
            slider_PlayerHealth = GameObject.Find("Player 2 - Health").GetComponent<Slider>();
        }
        else if (gameObject.name == "Player Parent 3")
        {
            slider_PlayerHealth = GameObject.Find("Player 3 - Health").GetComponent<Slider>();
        }
        else if (gameObject.name == "Player Parent 4")
        {
            slider_PlayerHealth = GameObject.Find("Player 4 - Health").GetComponent<Slider>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if this player collides with the bullet
        if(other.gameObject.tag == "Bullet")
        {
            string temp = gameObject.name;
            temp = temp.Substring(temp.Length-1);

            print("TEMP VAR"+temp);

            if(other.gameObject.GetComponent<Bullet>().ID != temp)
            {
                // This means our bullet came from another player
                slider_PlayerHealth.value -= other.GetComponent<Bullet>().Damage;
                print("<color=green>Player " + other.GetComponent<Bullet>().ID + " did " + other.GetComponent<Bullet>().Damage + " Damage</color>");

                print("Made it here");
                if (slider_PlayerHealth.value <= 0.2f)
                    Destroy(gameObject);
            }

        }
    }
}
