// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DialogueManagerWrapper : MonoBehaviour
{
	const string DLL_NAME = "DialogueManagerPlugin";
	private float time = 0f;
	public bool p1Win = false;
	public bool p2Win = false;
	private bool delay = false;
	public int debugTEMP;
    public bool USETHIS = true;
	// [DllImport(DLL_NAME)]
	// private static extern void startTXT();
	// [DllImport(DLL_NAME)]
	// private static extern void endTXT();
	[DllImport(DLL_NAME)]
	private static extern void p1WinTXT();
	[DllImport(DLL_NAME)]
	private static extern void p2WinTXT();
	[DllImport(DLL_NAME)]
	private static extern int getNextEvent();

    void Start()
    {
        print("Player 1/2 Wins should be already false...");
        //GameObject.Find("Player 1 Wins").SetActive(false);
        //GameObject.Find("Player 2 Wins").SetActive(false);
    }
	
	void Update () {
        // if game end
        // endTXT();
        if (USETHIS)
        {
            if (p1Win)
                p1WinTXT();
            if (p2Win)
                p2WinTXT();

            int nextEventNum = getNextEvent();

            if (nextEventNum == 1)
            {

            }
            else if (nextEventNum == 2)
            {

            }
            else if (nextEventNum == 3)
            {
                GameObject.Find("Canvas_GameUI").transform.Find("Player 1 Wins").gameObject.SetActive(true);
                delay = true;
            }


            if (nextEventNum == 4)
            {
                GameObject.Find("Canvas_GameUI").transform.Find("Player 2 Wins").gameObject.SetActive(true);
                delay = true;
            }

            if (delay == true)
            {
                time += Time.deltaTime;
                if (time >= 2f)
                {
                    GameObject.Find("Player 1 Wins").SetActive(false);
                    GameObject.Find("Player 2 Wins").SetActive(false);
                    delay = false;
                    time = 0f;
                }
            }
        }
	}
}
