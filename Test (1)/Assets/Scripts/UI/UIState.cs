using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour
{
    public int state = 0;
    public GameObject[] stateObj;
    public GameObject cursor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            state++;

            if (state > stateObj.Length - 1)
                state = 0;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            state--;

            if (state < 0)
                state = stateObj.Length - 1;
        }

        UIAnimationCtrl();
    }

    void UIAnimationCtrl()
    {
        cursor.GetComponent<Transform>().position = new Vector2(cursor.GetComponent<Transform>().position.x, stateObj[state].GetComponent<Transform>().position.y);

        foreach(GameObject go in stateObj)
            go.GetComponent<UIAnimation>().ZoomOut();

        stateObj[state].GetComponent<UIAnimation>().ZoomIn();
    }
}
