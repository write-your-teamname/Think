using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [Header("type")]
    public bool zoomIn;         //무엇을 쓸 것 인지
    public bool zoomOut;
    public bool moveSmooth;
    public bool zoomInOut;

    [Header("ZoomIn, Out")]
    public Vector2 maxZoom;     //최대
    public Vector2 defaultZoom; //최소
    public bool zoom;

    [Header("MoveSmooth")]
    public Vector2 firstPos;    //처음 위치, 현재 배치된 곳이 firstPos, goFirst가 활성화 되면 그 위치로 이동
    public Vector2 lastPos;     //나중 위치, goFirst가 비활성이 되면 그 위치로 이동
    bool goFirst = true;

    [Header("ZoomIn & Out")]
    public float delay;

    [Header("MoveSpeed")]
    public float moveSpeed;

    private Transform tr;

    void Start()
    {
        tr = GetComponent<RectTransform>();

        

        if(moveSmooth)
        {
            firstPos = tr.position;
            lastPos += firstPos;
        }
        if(zoomInOut)
        {
            StartCoroutine(ZoomInOut());
        }
    }

    private void Update()
    {
        if (zoomIn || zoomOut)
        {
            Debug.Log("test");
            if (zoom)
                ZoomIn();
            else
                ZoomOut();
        }

        if(moveSmooth)
        {
            MoveSmooth();
        }
    }

    // Update is called once per frame
    public void UseZoom()
    {
        zoom = !zoom;
    }

    public void UseMove()
    {
        goFirst = !goFirst;
    }

    public void ZoomIn()
    {
        Debug.Log("ZoomIn");
        tr.localScale = Vector2.Lerp(tr.localScale, maxZoom, moveSpeed * Time.deltaTime);
    }

    public void ZoomOut()
    {
        tr.localScale = Vector2.Lerp(tr.localScale, defaultZoom, moveSpeed * Time.deltaTime);
    }

    public void MoveSmooth()
    {
        if(goFirst)
        {
            tr.position = Vector2.Lerp(tr.position, firstPos, Time.deltaTime * moveSpeed);
        }
        else
        {
            tr.position = Vector2.Lerp(tr.position, lastPos, Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator ZoomInOut()
    {
        ZoomIn();

        yield return new WaitForSeconds(delay);

        ZoomOut();
    }
}
