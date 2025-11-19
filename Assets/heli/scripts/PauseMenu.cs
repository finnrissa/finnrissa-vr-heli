using BNG;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] public GameObject pauseMenu;
	public static bool GameIsPaused = false;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (GameIsPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}
	void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}