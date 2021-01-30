using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrLvlChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("LvTitle", LoadSceneMode.Single);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("LvCredits", LoadSceneMode.Single);
    }

    public void Play()
    {
        SceneManager.LoadScene("Lv01", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
