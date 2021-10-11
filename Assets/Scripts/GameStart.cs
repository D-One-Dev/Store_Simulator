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
    //начало игры
    private void StartGame()
    {
        //загрузка сцены геймплея
        SceneManager.LoadScene("Gameplay");
    }
}
