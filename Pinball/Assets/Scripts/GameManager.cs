using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe usada para gerenciar o jogo
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private string guiName; //nome da fase da interface
    [SerializeField] private string levelName;
    [SerializeField] private GameObject playerAndCameraPrefab;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(guiName);
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive).completed += operation =>
        {

        };
        Vector3 playerStartPosition = GameObject.Find("PlayerStart").transform.position;
        
        Scene levelScene = default;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == levelName)
            {
                levelScene = SceneManager.GetSceneAt(i);
                break;
            }
        }

        if (levelScene != default) SceneManager.SetActiveScene(levelScene);

        Instantiate(playerAndCameraPrefab, playerStartPosition, Quaternion.identity);
    }
}
