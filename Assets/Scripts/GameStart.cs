using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //Input System
    private NewInput PI;
    private void Awake()
    {
        PI = new NewInput();
        PI.Gameplay.Use.performed += context => StartGame();
    }
    private void OnEnable()
    { PI.Enable(); }
    private void OnDisable()
    { PI.Disable(); }
    //game start
    private void StartGame()
    {
        //gameplay scene load
        SceneManager.LoadScene("Gameplay");
    }
}
