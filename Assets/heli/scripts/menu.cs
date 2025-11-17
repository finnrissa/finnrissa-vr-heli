using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void onPlayButton()
    {
        SceneManager.LoadScene(7);
    }
	public void onNextButton()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex + 1);
	}

	public void onBackButton()
	{
		//SceneManager.LoadScene(2);
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex - 1);
	}
	public void onTutorialButton()
	{
		SceneManager.LoadScene(1);
	}

	public void onMenuButton()
	{
		SceneManager.LoadScene(0);
	}

	public void OnQuitButton()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
