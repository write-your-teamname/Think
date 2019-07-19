using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rig;
    private Transform tr;
    private Vector2 moveDir;
    private float size = 1.0f;
    public float speed;
    public Transform rayOffset;

    [Header("Light")]
    public float decreValue;
    public Light2D pointLight;

    [Header("Die")]
    public bool isDie;

    [Header("Animation")]
    public Animator anim;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        pointLight = GetComponent<Light2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        AnimationCtrl();

        rig.velocity = moveDir.normalized * speed;
    }

    void AnimationCtrl()
    {
        if (moveDir.x > 0.1f || moveDir.x < -0.1f)
        {
            anim.SetBool("IsSide", true);
            anim.SetBool("IsFront", false);
            anim.SetBool("IsBack", false);
            anim.SetBool("IsWalk", true);

            if (moveDir.x < 0.1)
                tr.localScale = new Vector2(size, tr.localScale.y);

            else
                tr.localScale = new Vector2(-size, tr.localScale.y);
        }
        else if(moveDir.y > 0.1f)
        {
            anim.SetBool("IsBack", true);
            anim.SetBool("IsFront", false);
            anim.SetBool("IsSide", false);
            anim.SetBool("IsWalk", true);
        }
        else if(moveDir.y < -0.1f)
        {
            anim.SetBool("IsFront", true);
            anim.SetBool("IsBack", false);
            anim.SetBool("IsSide", false);
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsFront", false);
            anim.SetBool("IsBack", false);
            anim.SetBool("IsSide", false);
            anim.SetBool("IsWalk", false);
        } 
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            pointLight.pointLightOuterRadius -= decreValue * Time.deltaTime;
        }
    }
}
