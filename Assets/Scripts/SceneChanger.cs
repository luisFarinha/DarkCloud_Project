using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToPlayScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }

    public void ChangeToMenusScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EditScene");
    }
}
