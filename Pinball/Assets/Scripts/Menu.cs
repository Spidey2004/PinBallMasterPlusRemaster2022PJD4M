using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/Protitype");
        Debug.Log("START!");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
