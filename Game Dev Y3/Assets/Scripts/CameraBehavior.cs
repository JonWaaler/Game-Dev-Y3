using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public List<Transform> players;
    private float z_offset = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (players.Count)
        {
            case 1:
                transform.position = new Vector3(players[0].transform.position.x, 25, players[0].transform.position.z - z_offset);
                break;
            case 2:
                transform.position = Vector3.Lerp(new Vector3(players[0].transform.position.x, 25, players[0].transform.position.z - z_offset), 
                                                new Vector3(players[1].transform.position.x, 25, players[1].transform.position.z - z_offset), 
                                                0.5f);
                break;
            default:
                break;
        }
    }
}
