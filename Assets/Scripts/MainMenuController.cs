using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        //loading gameplay scene
        SceneManager.LoadScene("Gameplay");
    }
    public void ExitGame()
    {
        //closing the game
        Application.Quit();
    }
}
