using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneAnimation : MonoBehaviour
{
    public bool isClear;                //게임의 결과가 성공?
    public bool isGameDone;
    public bool isGameStart;
    public Camera cam;

    public Animator anim;               

    public GameObject mainScreen;
    public GameObject gameresult;

    public GameObject gameStart;
    public GameObject gameOver;
    public float firstDelay;
    public float secondDelay;
    public float thirdDelay;

    [Header("value")]
    public float reMovespeed;
    public bool FadeOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationCtrl1());
        StartCoroutine(AnimationCtrl2());
    }

    private void Update()
    {
        if(FadeOut)
        {
            mainScreen.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.Lerp(mainScreen.GetComponent<Image>().color.a, 0f, reMovespeed * Time.deltaTime));
        }

        else
        {
            mainScreen.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.Lerp(mainScreen.GetComponent<Image>().color.a, 1f, reMovespeed * Time.deltaTime));
        }

        anim.SetBool("IsClear", isClear);
    }

    IEnumerator AnimationCtrl1()
    {
        
        yield return new WaitForSeconds(firstDelay);
        mainScreen.GetComponent<UIAnimation>().UseZoom();
        FadeOut = true;

        yield return new WaitForSeconds(secondDelay);
        //Time.timeScale = 0.0f;

        yield return new WaitForSeconds(secondDelay);
        Time.timeScale = 1.0f;
        cam.orthographicSize = 18.0f;

        yield return new WaitForSeconds(thirdDelay);
        gameStart.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        gameStart.SetActive(false);
    }

    IEnumerator AnimationCtrl2()
    {
        while(true)
        {
            yield return null;

            if (isGameDone)
            {
                FadeOut = false;
                mainScreen.GetComponent<UIAnimation>().UseZoom();
                yield return new WaitForSeconds(firstDelay);
                anim.SetBool("IsClear", isClear);
                anim.SetBool("IsClear", isClear);
                yield return new WaitForSeconds(2.0f);
                gameresult.SetActive(true);
                Debug.Log("isClaer : " + isClear);
                anim.SetBool("IsClear", isClear);
                yield return new WaitForSeconds(3.0f);
                SceneManager.LoadScene("MainScene");
            }
        }
        
    }
}
