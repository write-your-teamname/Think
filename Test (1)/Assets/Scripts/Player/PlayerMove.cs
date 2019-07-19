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
    public StartSceneAnimation gameDone;

    public Animator anim;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        pointLight = GetComponent<Light2D>();
        gsm = FindObjectOfType<GameSceneManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rig.velocity = movement.normalized * speed;

        //사망
        if (pointLight.pointLightOuterRadius <= 7)
        {
            Debug.Log("Die");
            gameDone.isGameDone = true;
            gameDone.isClear = false;
        }

        AnimationCtrl(movement);
    }

    void AnimationCtrl(Vector2 movement)
    {
        if(movement.x > 0.1f || movement.x < -0.1f)
        {
            anim.SetBool("IsSide", true);
            anim.SetBool("IsFront", false);
            anim.SetBool("IsBack", false);
            anim.SetBool("IsWalk", true);

            if(movement.x < -0.1f)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else if(movement.y > 0.1f)
        {
            anim.SetBool("IsSide", false);
            anim.SetBool("IsFront", false);
            anim.SetBool("IsBack", true);
            anim.SetBool("IsWalk", true);
        }
        else if(movement.y < -0.1f)
        {
            anim.SetBool("IsSide", false);
            anim.SetBool("IsFront", true);
            anim.SetBool("IsBack", false);
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            pointLight.pointLightOuterRadius -= decreValue * Time.deltaTime;
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
                gameDone.isClear = true;
                gameDone.isGameDone = true;
            }
        }
    }
}
