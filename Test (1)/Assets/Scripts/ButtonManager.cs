using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject menu;
    public bool isMenu;

    public void ClickMenu()
    {
        if (!isMenu)
        {
            isMenu = true;
            menu.SetActive(true);
        }
        else if (isMenu)
        {
            isMenu = false;
            menu.SetActive(false);
        }
    }

    public void ClickExitMenu()
    {
        isMenu = false;
        menu.SetActive(false);
    }
}
