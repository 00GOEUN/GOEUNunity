 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{

    // 싱글(벙글)톤 패턴
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        // Getter 반환만
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
    }

    // 생성자 private 셋팅 : 외부에서 생성 허용X
    private ObjectManager() { }

    // Enemy 오브젝트 프리팹을 추가
    //private GameObject EnemyPrefab;


    // Enemy 관리 리스트
    //private List<GameObject> EnemyList = new List<GameObject>();
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

   

   //private void Awake()
   //{
   //    // 하이라키 뷰에 EnemyList라는 빈 게임 오브젝트를 추가
   //    //GameObject ViewObject = new GameObject("EnablsList");
   //    new GameObject("EnablsList");
   //    new GameObject("DisableList");
   //
   //    // Resources 폴더 안에 있는 리소스를 불러옴
   //    // Resources.Load("경로") as GameObject;
   //    //EnemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;
   //
   //
   //}


   //private void Start()
   //{
   //
   //    CreateEnemy();
   //
   //
   //}

    

    // 오브젝트 리스트에 추가
    public void AddObject(GameObject _Object)
    {

        // EnemyController 이름의 스크립트를 복제된 오브젝트에 추가
        _Object.AddComponent<EnemyController>();

        // 하이라키 뷰에 추가된 EnemyList의 빈 게임 오브젝트를 부모로 셋팅 : 계층구조
        _Object.transform.parent = GameObject.Find("DisableList").transform;

        // 생성된 Enemy의 충돌체에 있는 Trigger 기능을 켬
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        // 난수 함수 Random.Range( Min, Max)
        _Object.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // 생성된 오브젝트를 비활성화 설정
        _Object.gameObject.SetActive(false);

        // 리스트에 추가
        DisableList.Push(_Object);

    // Enemy 초기 생성
    //void CreateEnemy()
        //for (int i = 0; i < 5; ++i)
        //{
        //    // Insantiate 복제함수
        //    // EnemyPrefab의 오브젝트를 복제
        //    //GameObject Obj = Instantiate(EnemyPrefab);
        //
        //    // EnemyController 이름의 스크립트를 복제된 오브젝트에 추가
        //    //Obj.AddComponent<EnemyController>();
        //
        //    // 하이라키 뷰에 추가된 EnemyList의 빈 게임 오브젝트를 부모로 셋팅 : 계층구조
        //    //Obj.transform.parent = GameObject.Find("DisableList").transform;
        //
        //    // 생성된 Enemy의 충돌체에 있는 Trigger 기능을 켬
        //    //Obj.GetComponent<BoxCollider>().isTrigger = true;
        //
        //    // x = -25 ~ 25
        //    // y = -25 ~ 25
        //
        //    // 난수 함수 Random.Range( Min, Max)
        //    //Obj.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        //    // 생성된 오브젝트를 비활성화 설정
        //    //Obj.SetActive(false);
        //
        //    // 리스트에 추가
        //    //EnemyList.Add(Obj);
        //    //DisableList.Push(Obj);
        //
        // }
    }

}
