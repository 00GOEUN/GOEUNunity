using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이게 있어야 충돌가능
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public GameObject WayPoint;
    private bool Move;
    private Vector3 Step;
    private float Speed;
    private float Force;
    private Rigidbody Rigid;
    private float idleTime;

    // ** Bullet 오브젝트 프리팹을 추가.
    public GameObject BulletPrefab;

    // 언제 나가는지 확인
    private bool BulletCheck;

    private void Awake()
    {
        // ** 현재 오브젝트의 물리엔진 컴퍼넌트를 받아옴
        Rigid = GetComponent<Rigidbody>();

        // WayPoint 라는 가상의 목표지점을 생성
        WayPoint = new GameObject("WayPoint");

        // WayPoint의 tag를 WayPoint로 설정
        WayPoint.transform.tag = "WayPoint";


        // 가상의 목표지점에 콜라이더를 삽입
        WayPoint.AddComponent<SphereCollider>();
        // 삽입된 콜라이더에 정보를 받아옴
        SphereCollider Sphere = WayPoint.GetComponent<SphereCollider>();
        // Sphere 콜라이더 크기를 변경
        Sphere.radius = 0.2f;
        // isTrigger를 true로 변경
        Sphere.isTrigger = true;

        // Bullet 프리펩을 불러옴
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;

    }

    private void Start()
    {
        // 대기 상태 시간
        idleTime = 3.0f;



        Speed = 0.05f;
        Rigid.useGravity = false;


        BulletCheck = false;

        this.transform.parent = GameObject.Find("EnableList").transform;

        // 현재 자ㅇ신의 위치
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        //WayPoint = this.transform.FindChild("WayPoint").gameObject;

        Initialized();

        // Bullet코루틴 실행
        StartCoroutine("Bullet");


        //// **WayPoint 이동 목표위치 / 난수 함수 = Random.Range(Min, Max)
        //WayPoint.transform.position = new Vector3(
        //    Random.Range(-25, 25),
        //    0.0f,
        //    Random.Range(-25, 25));
        //
        //// 현재 자ㅇ신의 위치
        //WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        ////** 타겟이 생성되었으니 움직일수 있도록 true로 변경
        //Move = true;
        //
        //// ** 타겟의 방향을 바라보는 벡터를 구함.
        //Step = WayPoint.transform.position - this.transform.position;
        //
        //// ** 방향만 남겨주고
        //Step.Normalize();
        //
        //// ** 남은 방향에 Y값은 그 값조차 없애버림. 오작동 방지.
        //Step.y = 0;


    }
    private void OnEnable()
    {

        this.transform.parent = GameObject.Find("EnableList").transform;

        // 현재 자ㅇ신의 위치
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        Initialized();
        //// ** 초기화.
        //
        //// ** 난수 함수 = Random.Range(Min, Max)
        //this.transform.position = new Vector3(
        //    Random.Range(-25, 25),
        //    0.0f,
        //    Random.Range(-25, 25));
        //
        //// ** 하이라키부에 추가된 EnemyList의 빈 게임오브젝트를 부모로 셋팅 : 계층구조
        //this.transform.parent = GameObject.Find("EnablsList").transform;
        //
        ////** 타겟이 생성되었으니 움직일수 있도록 true로 변경
        //Move = true;
        //
        //// ** 타겟의 방향을 바라보는 벡터를 구함.
        //Step = WayPoint.transform.position - this.transform.position;
        //
        //// ** 방향만 남겨주고
        //Step.Normalize();
        //
        //// ** 남은 방향에 Y값은 그 값조차 없애버림. 오작동 방지.
        //Step.y = 0;
    }


    private void Update()
    {
        if(BulletCheck == true)
        {
            GameObject Obj = Instantiate(BulletPrefab);
            // BulletController 이름의 스크립트를 복제된 오브젝트에 추가
            Obj.gameObject.AddComponent<BulletController>();
            Obj.gameObject.transform.position = this.gameObject.transform.position;

            // Obj.transform.position += Step * Speed;
            //Debug.DrawLine(this.transform.position, WayPoint.transform.position);

            // 총알이 한번만 발사 되도록 설정
            BulletCheck = false;

            // Bullet코루틴 실행
            StartCoroutine("Bullet");
        }
    }


    private void FixedUpdate()
    {
        if (Move == true) // 그 곳으로 이동
        {
            this.transform.position += Step * Speed;
            Debug.DrawLine(this.transform.position, WayPoint.transform.position);
        }

       //else // 아니면 다음타겟을 찾음
       //{
       //
       //
       //    idleTime -= Time.deltaTime;
       //
       //    if (idleTime < 0)
       //    {
       //        // **WayPoint 이동 목표위치 / 난수 함수 = Random.Range(Min, Max)
       //        WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
       //
       //        //** 타겟이 생성되었으니 움직일수 있도록 true로 변경
       //        Move = true;
       //
       //        // ** 타겟의 방향을 바라보는 벡터를 구함.
       //        Step = WayPoint.transform.position - this.transform.position;
       //
       //        // ** 방향만 남겨주고
       //        Step.Normalize();
       //
       //        // ** 남은 방향에 Y값은 그 값조차 없애버림. 오작동 방지.
       //        Step.y = 0;
       //
       //        // 대기 시간 셋팅 3~5초
       //        idleTime = Random.Range(3, 5);
       //    }
       //    // 대기 애니메이션
       //    //else
       //    //{     
       //    //    Force = 2000.0f;
       //    //
       //    //    //** 힘을 가하여 이동시킴.
       //    //   Rigid.AddForce(Vector3.forward * Force);
       //    //}
       //}
    }
    private void Initialized()
    {

        // **WayPoint 이동 목표위치 / 난수 함수 = Random.Range(Min, Max)
        WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        //** 타겟이 생성되었으니 움직일수 있도록 true로 변경
        Move = true;

        // ** 타겟의 방향을 바라보는 벡터를 구함.
        Step = WayPoint.transform.position - this.transform.position;

        // ** 방향만 남겨주고
        Step.Normalize();

        // ** 남은 방향에 Y값은 그 값조차 없애버림. 오작동 방지.
        Step.y = 0;

        // 
        WayPoint.transform.position.Set(WayPoint.transform.position.x, 0.0f, WayPoint.transform.position.z);

        // 객체가 해당방향을 바라봄
        this.transform.LookAt(WayPoint.transform.position);

    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag != "Enemy")
        //{
        //    Move = false;
        //}
        if (other.tag == "WayPoint")
        {
            Move = false;
            StartCoroutine("EnemyState");

        }

        if (other.tag == "Ground")
        {
            Destroy(other.gameObject);
        }

        //   // **WayPoint 이동 목표위치 / 난수 함수 = Random.Range(Min, Max)
        //   WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        //   //** 타겟이 생성되었으니 움직일수 있도록 true로 변경
        //   Move = true;
        //
        //   // ** 타겟의 방향을 바라보는 벡터를 구함.
        //   Step = WayPoint.transform.position - this.transform.position;
        //
        //   // ** 방향만 남겨주고
        //   Step.Normalize();
        //
        //   // ** 남은 방향에 Y값은 그 값조차 없애버림. 오작동 방지.
        //   Step.y = 0;


    }

    IEnumerator EnemyState()
    {


        yield return new WaitForSeconds(Random.Range( 3, 5)); // 이곳부터 1초를 기다렸다가 이후로 넘어감

        Initialized();

    }

    IEnumerator Bullet()
    {


        yield return new WaitForSeconds(Random.Range(3, 5)); // 이곳부터 1초를 기다렸다가 이후로 넘어감

        BulletCheck = true;

    }
}
