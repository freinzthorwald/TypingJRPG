using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        WordBank.CreateInstance();
        StartNewGame();
        SceneManager.LoadScene("EventSelection");
    }

    private void StartNewGame()
    {
        NewGame script = this.gameObject.GetComponent<NewGame>();
        script.InitializeGame();
    }
}
