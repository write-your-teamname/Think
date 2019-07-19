using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IsMe : MonoBehaviour
{
    // Start is called before the first frame update
    public string mySceneName;
    public int myNum;
    public UIState master;

    public void PointInMe()
    {
        master.state = myNum;
    }
    
    public void GoToScene()
    {
        SceneManager.LoadScene(mySceneName);
    }
}
