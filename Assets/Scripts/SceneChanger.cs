using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToPlayScene() // resumes in game time and changes to play scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.PLAY_SCENE);
    }

    public void ChangeToMenusScene() // resumes in game time and changes to main menu scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.EDIT_SCENE);
    }
}
