using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
	public GameObject playerTXT_01, playerTXT_02, playerTXT_03, playerTXT_04;
	public GameObject pressA_01, pressA_02, pressA_03, pressA_04;
	public GameObject playerSelect;

	private bool CharacterSelect1, CharacterSelect2, CharacterSelect3, CharacterSelect4;

	List<int> controllers = new List<int>();

	void Awake()
	{
		playerTXT_01.SetActive(false);
		playerTXT_02.SetActive(false);
		playerTXT_03.SetActive(false);
		playerTXT_04.SetActive(false);
		pressA_01.SetActive(true);
		pressA_02.SetActive(true);
		pressA_03.SetActive(true);
		pressA_04.SetActive(true);
		CharacterSelect1 = false;
		CharacterSelect2 = false;
		CharacterSelect3 = false;
		CharacterSelect4 = false;
	}

	void FixedUpdate()
	{
		// ---- Add Players ---- //
		if (playerSelect.activeSelf)
		{
			for (int i = 1; i < 4; i++)
			{
				if (Input.GetKeyDown("joystick " + i + " button 0"))
				{
					if (!controllers.Contains(i))
					{
						controllers.Add(i);
						if (i == 1)
						{
							playerTXT_01.SetActive(true);
							pressA_01.SetActive(false);
							CharacterSelect1 = true;
						}
						if (i == 2)
						{
							playerTXT_02.SetActive(true);
							pressA_02.SetActive(false);
							CharacterSelect2 = true;
						}
						if (i == 3)
						{
							playerTXT_03.SetActive(true);
							pressA_03.SetActive(false);
							CharacterSelect3 = true;
						}
						if (i == 4)
						{
							playerTXT_04.SetActive(true);
							pressA_04.SetActive(false);
							CharacterSelect4 = true;
						}
					}
				}
			}
		}

		if (CharacterSelect1)
		{
			
		}
	}
}
