using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {


    public Canvas Menu;
    public Button StartGame;
    public Button Credits;
    public Button ExitGame;
    public Button ReturnToMain;

	// Use this for initialization
	void Start () {
        Menu = Menu.GetComponent<Canvas>();
        StartGame = StartGame.GetComponent<Button>();
        Credits = Credits.GetComponent<Button>();
        ExitGame= ExitGame.GetComponent<Button>();
        ReturnToMain = ReturnToMain.GetComponent<Button>();

    }
	
	// Update is called once per frame
    void Update () {
		
	}

   public void StartLevel()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {

        Application.Quit();
    }
    
    public void LoadCredits()
    {
        SceneManager.LoadScene(2);

    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
            
            }
}
