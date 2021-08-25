using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 해당 컴퍼넌트를 삽입 : 현제 Rigdbody
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject TargetPoint;

    private bool Move;

    private Vector3 Step;
    private Rigidbody Rigid;

    // Enemy 오브젝트를 프리팹을 추가
    public GameObject EnemyPrefab;


    void Awake()
    {
        // 하이라이키뷰에 "EnemyLsit" 이름의 빈 게임 오브젝트 추가
        // GameObject ViewObject = new GameObject("EnemyList");
        
        // 현재 오브젝트의 물리엔진 컴퍼넌트를 받아옴
        Rigid = GetComponent<Rigidbody>();

        // TargetPoint라는 객체를 찾는다
        // 이름을 신경써야함 같은 이름의 객체가 있으면 문제가 생김
        TargetPoint = GameObject.Find("TargetPoint");

        // 리소스 폴더 안에 있는 리로스를 불러옴
        // Resources.Load("경로") as GameObject;  
        EnemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;

        //// 하이라이키뷰에 "EnemyLsit" 이름의 빈 게임 오브젝트 추가
        ////GameObject ViewObject = new GameObject("EnableList");
        //new GameObject("EnableList");
        //new GameObject("DisableList");
    }

    void Start()
    {
        // 물리엔진의 중력을 비활성화
        Rigid.useGravity = false;

        // 시작할때 TargetPoint 위치를 현재 오브젝트의 위치로 초기화
        TargetPoint.transform.position = this.transform.position;
        //this.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        
        // Step = 방향 : 시작할때는 그 방향을 갖지 않음
        Step = new Vector3(0.0f, 0.0f, 0.0f);
        // Speed = 이동속도
        Speed = 15.0f;
        // Move = 이동상태 : 시작할때 정지상태로 만듦
        Move = false;

        //for(int i =0; i<5; ++i)
        //{
        //    ObjectManager.GetInstance.AddObject(Instantiate(EnemyPrefab));
        //}
        new GameObject("EnalsList");
        new GameObject("DisableList");

        for(int i = 0; i < 5; ++i)
        {
            ObjectManager.GetInstance.AddObject(Instantiate(EnemyPrefab));
        }
    }



    private void Update()
    {
       
        //  스페이스 키 입력 받으면
        if (Input.GetKey(KeyCode.Space))
        {
            // GetDisableList에 있는 객체 하나를 버리고
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            //버려진 객체를 활성화 시켜 사용상태로 변경
            Obj.gameObject.SetActive(true);
            // 변경후 parent 를 EnablsList 하위에 포함시키고
            Obj.transform.parent = GameObject.Find("EnableList").transform;
            // 활성화된 오브젝트를 관리하는 리스트에 포함시킴
            ObjectManager.GetInstance.GetEnableList.Add(Obj);
        }
        // 비활성화 상태에서 활성화 샅애로 변경하고, 변경된 오브젝트는
        // 활성화된 오브젝트만 모여있는 리스트에서 사용이 끝날때까지 관리 함


    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            // 화면에 있는 마우스 위치로부터 Ray를 보내기위해 정보를 기록함.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RayPoint(ray);
        }

        // Move가 true일때는 이동 가능한 상태를 말함
        if (Move == true)
            // Step = 방향 Speed = 속도
            // Step 방향으로 Speed 만큼 이동
            this.transform.position += Step * Time.deltaTime * Speed;

    }


    void RayPoint(Ray _ray)
    {
        // Ray가 타겟과 충돌했을때 반환 값을 저장하는 곳.
        RaycastHit hit;

        // Physics.Raycast( Ray시작 위치와 방향 , 충돌한 지점의 정보, Mathf.Infinity = 무한한)
        // ray의 위치와 방향으로부터 RayPoint를 무한하게 발사하고 출동이 일어나면 Hit에 정보를 저장함.
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                // ray의 위치로 부터 hit된 위치까지 선을 그림. 실제 게임에서는 안보임.
                Debug.DrawLine(_ray.origin, hit.point);
                Debug.Log(hit.point);

                // hit된 위치를 타겟 좌표로 받아옴
                TargetPoint.transform.position = hit.point;
                // 타겟이 생성되었으니 움직일 수 있도록 true로 변경
                Move = true;

                // 타겟의 방향을 바라보는 벡터를 구함
                // 함수 = B - A;
                Step = TargetPoint.transform.position - this.transform.position;
                // 방향만 남김
                // 함수.Normalize();
                Step.Normalize();
                // 남은 방향의 y값을 없애버림 오작동 방지
                Step.y = 0;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // 충돌된 객체의 이름이 TargetPoint가 아니라면 무시하고 TargetPoint일때 멈춤
        //if(other.tag =="")
        if (other.name == "TargetPoint")
            Move = false;
    }


   
}