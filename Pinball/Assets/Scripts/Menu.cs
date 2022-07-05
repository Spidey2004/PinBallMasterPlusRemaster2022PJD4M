using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Scenes/Cena");
        Debug.Log("START!");
    }

    public void OnCLickQuit()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
