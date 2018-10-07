using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour {
	
	public GameObject mainmenu;
	public GameObject characterselect;
	public CanvasGroup PressA;
	
	private float fade = 1f;
	private bool Fade = true;

	void Awake()
	{
		mainmenu.SetActive(true);
		characterselect.SetActive(false);
	}

	void FixedUpdate()
	{
		// Text fade in and out
		if (fade >= 1f)
			Fade = true;
		else if (fade <= 0.25f)
			Fade = false;

		if (Fade)
			fade -= Time.deltaTime;
		else
			fade += Time.deltaTime;

		PressA.alpha = fade;

		if (characterselect.activeInHierarchy && Input.GetButtonDown("AButton1"))
		{
			SceneManager.LoadScene(1);
		}
	}

	public void Play()
	{
		SceneManager.LoadScene(1);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
