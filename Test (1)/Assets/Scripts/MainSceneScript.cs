using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
