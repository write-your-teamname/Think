using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Transform tr;
    public float SmoothSpeed;
    private void Start()
    {
        tr = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 temp = player.position;
        temp.z = -10;
        tr.position = Vector3.Lerp(tr.position, temp, SmoothSpeed * Time.deltaTime);
    }
}
