using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rig;
    public float speed;

    [Header("Light")]
    public float decreValue;
    public Light2D pointLight;

    [Header("Die")]
    public bool isDie;
    public Transform spawnTr;

    [Header("Key")] // 변수 명 바꿔도 됨
    public bool isGetkey;

    [Header("게임 매니저")]
    private GameSceneManager gsm;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        pointLight = GetComponent<Light2D>();
        gsm = FindObjectOfType<GameSceneManager>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rig.velocity = movement.normalized * speed;

        //사망
        if (pointLight.pointLightOuterRadius <= 7)
        {
            transform.position = spawnTr.position;
            pointLight.pointLightOuterRadius = 35;
            isGetkey = false;
            if(!gsm.isSpawnKey)
                gsm.SpawnKey();
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            pointLight.pointLightOuterRadius -= decreValue * Time.deltaTime;
            Debug.Log("test : " + pointLight.pointLightOuterRadius);

            //if()
        }

        if (coll.gameObject.CompareTag("key"))
        {
            isGetkey = true;
            gsm.isSpawnKey = false;
            Destroy(coll.gameObject);
            Debug.Log(isGetkey);
        }

        //임시로 짜 놓은 코드임
        if (coll.gameObject.CompareTag("keyPoint")) // 태그 명 바꿔도 됨
        {
            if (isGetkey)
            {
                Debug.Log("클리어");
                //나머지 코드
            }
        }
    }
}
