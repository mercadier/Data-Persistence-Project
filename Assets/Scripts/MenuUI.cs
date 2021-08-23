using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUI : MonoBehaviour
{
    public string playerName;
    public InputField playerNameInput;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
            bestScoreText.text = ConstantManager.Instance.champion + ": " + ConstantManager.Instance.highScore; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        playerName = playerNameInput.text;
        ConstantManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }
    public void OnQuit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
    }
}
