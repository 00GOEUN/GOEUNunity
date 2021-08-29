using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    // 싱글톤 패턴
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        // Getter 반환
        get
        {
            if (Instance == null)
                Instance = new ObjectManager(); 

            return Instance;
        }
        // Setter 반환 set {}
    }


    // 생성자 private 셋팅 : 외부생성 허용X
    private ObjectManager() { } 
    //private void OnRenderObject() {}


    // Enemy 오브젝트를 프리팹을 추가
    //public GameObject EnemyPrefab;


    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }


    private Stack<GameObject> DisableList = new Stack<GameObject>();
    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }


    // Enemy 관리 리스트
    // 초기화 해줘야됨  = new List<GameObject>();
    //private List<GameObject> EnemyList = new List<GameObject>();

    //void Awake()
    //{
    //    // 하이라이키뷰에 "EnemyLsit" 이름의 빈 게임 오브젝트 추가
    //    //GameObject ViewObject = new GameObject("EnableList");
    //    new GameObject("EnableList");
    //    new GameObject("DisableList");
    //
    //   
    //}


    //     private void Start()// 스타트 = 한번만 실행
    // {
    //     
    //     
    // }

    // Enemy 초기 생성
    //void CreateEnemy()
    // 오브젝트를 리스트에 추가
    public void AddObject(GameObject _Object)
    {
       
        // Instantiate 복제함수
        // EnemyPrefab의 오브젝트를 복제
        //GameObject Obj = Instantiate(EnemyPrefab);

        // Enemycontroller 이름의 스크립트를 복제된 오브젝트에 추가
        //Obj.AddComponent<EnemyController>();
        _Object.AddComponent<EnemyController>();

        // 하이라이키 뷰에 추가된 EnemtList의 빈 게임오브젝트를 부모로 셋팅 : 계층구조
        //Obj.transform.parent = GameObject.Find("DisableList").transform;
        _Object.transform.parent = GameObject.Find("DisableList").transform;
        // Obj.name = 
        // 위치 지정
        // x = -25 ~25
        // z = -25 ~ 25

        // 랜덤 난수 함수 Random.Range( Min, Max)
        // Random.Range(-25,25)


        // 생성된 Enemy 충돌체에 있는 Trigger 기능을 켬
        //Obj.GetComponent<BoxCollider>().isTrigger = true;
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        //Obj.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        _Object.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        // 한번만 실행 될 때는 위치 지정할 필요가 없음

        // 생성된 오브젝트를 비활성화 시킴
        //Obj.SetActive(false);
        _Object.gameObject.SetActive(false);


        // 리스트에 추가
        //EnemyList.Add(Obj);
        //DisableList.Push(Obj);
        DisableList.Push(_Object);

    }

}
