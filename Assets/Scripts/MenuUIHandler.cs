using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public GameObject scoreUIText;

    // Start is called before the first frame update
    void Start()
    {   
        scoreUIText.GetComponent<Text>().text =  "Best Score: " + ScoreManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when Start Button is pressed
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveScore(); 

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // Quit when in Unity editor
    #else
        Application.Quit(); // Quit when in build
    #endif
    }


    
}
