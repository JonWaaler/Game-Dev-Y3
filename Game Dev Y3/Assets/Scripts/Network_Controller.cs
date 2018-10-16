using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network_Controller : NetworkBehaviour {

    private CameraBehavior camBehavior;
    

    private void Awake()
    {
        camBehavior = GameObject.FindObjectOfType<CameraBehavior>();

        camBehavior.players.Add(this.transform);


    }

}
