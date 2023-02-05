using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start Button starts main game scene
    public void StartButton()
    {
        SceneManager.LoadScene("ValTestScene");
    }

    // Quit Button stops game
    public void QuitButton() {
        Application.Quit();
        Debug.Log("Game Closed");
        
    }

    // Plays Credits Scene
    public void CreditsButton() {
        SceneManager.LoadScene("Credits");
    }
}
