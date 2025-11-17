using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseButton;
    private bool paused;
    public void PauseGame()
    {
        pauseButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pauseButton.SetActive(false);
        Time.timeScale = 1;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ContinueGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
	}
}
