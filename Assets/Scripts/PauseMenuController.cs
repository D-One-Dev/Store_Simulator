using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    //pause menu GameObject
    [SerializeField] private GameObject pauseMenu;
    //is game paused
    public bool isGamePaused;
    //exit to menu
    public void ExitToMenu()
    {
        //setting normal game speed
        Time.timeScale = 1f;
        //loading menu scene
        SceneManager.LoadScene("Menu");
    }
    //exit to system
    public void ExitToSystem()
    {
        //closing the game
        Application.Quit();
    }
    //changing the pause state on/off
    public void changeState()
    {
        if(!isGamePaused) Pause();
        else Resume();
    }
    //game pause
    void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        //setting game speed to zero
        Time.timeScale = 0f;
    }
    //game resume
    void Resume()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        //setting normal game speed
        Time.timeScale = 1f;
    }
}
