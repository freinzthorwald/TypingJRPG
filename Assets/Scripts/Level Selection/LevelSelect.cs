using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    public string SceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
