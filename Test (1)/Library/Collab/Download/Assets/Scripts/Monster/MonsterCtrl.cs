using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class MonsterCtrl : MonoBehaviour
{
    //[Header("Spawn Point")]
    //private List<GameObject> spawn;
    //public float spawnDelay;

    [Header("Movement")]
    public Transform playerTr;
    private Transform tr;
    public float moveSpeed = 0.2f;
    private MonsterMgr monsterMgr;
    public float reposDelay = 3.0f;
    public CircleCollider2D circle;

    [Header("Animatoin")]
    public Animator anim;
    public float animDelay = 3.0f;

    //[Header("Animation")]
    //public Light2D monsterLight;
    //public float waitTime;
    //public float lgihtMinSize;
    //public float animSpeed;
    // Start is called before the first frame update

    void Start()
    {
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        monsterMgr = FindObjectOfType<MonsterMgr>().GetComponent<MonsterMgr>();
        anim = GetComponent<Animator>();
        circle = GetComponent<CircleCollider2D>();
        //monsterLight = gameObject.GetComponent<Light2D>();
        //StartCoroutine(LightAnim());    //Light Anim 실행
        StartCoroutine(Reposition());
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = Vector2.Lerp(tr.position, playerTr.position, moveSpeed * Time.deltaTime);
    }

    IEnumerator Reposition()
    {
        while(true)
        {
            yield return new WaitForSeconds(reposDelay);
            Transform repos = monsterMgr.SetPosition();
            circle.enabled = false;
            Debug.Log("Anim On!");
            anim.SetBool("isAnim", true);
            yield return new WaitForSeconds(0.01f);
            anim.SetBool("isAnim", false);
            yield return new WaitForSeconds(animDelay);

            circle.enabled = true;             //다시 충돌 활성화 
            tr.position = repos.position;//일정 시간이 지나면 포지션 이동
            //GetComponent<SpriteRenderer>().sprite = temp; // 포지션 이동과 함께 스프라이트 교체
            SetSprite();

            Debug.Log("ReOn!");
        }
    }

    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = FindObjectOfType<GameSceneManager>().enemySprite[Random.Range(0, 3)];
    }

    //IEnumerator LightAnim()
    //{
    //    float size;
    //    float defaultSize = monsterLight.pointLightOuterRadius;
    //    float minSize = defaultSize - lgihtMinSize;

    //    size = defaultSize;
    //    while(true)
    //    {
    //        monsterLight.pointLightOuterRadius = Mathf.Lerp(monsterLight.pointLightOuterRadius, size, animSpeed * Time.deltaTime);

    //        yield return new WaitForSeconds(waitTime);  //일정 시간이 지나면 size 다시 설정
    //        size = Random.Range(minSize, defaultSize);
    //    }
    //}
}
