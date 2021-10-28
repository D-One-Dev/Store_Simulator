using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioMixer AM;
    private void Start()
    {
        //getting volume from playerPrefs
        AM.SetFloat("MasterVolume", PlayerPrefs.GetFloat("audioVolume", 1f));
    }
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
