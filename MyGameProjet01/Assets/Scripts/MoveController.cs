using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ** 해당 컴퍼넌트를 삽입 : 현재 Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    // ** 바라보는 방향
    private Vector3 Direction;

    // ** 이동 속도
    [SerializeField] private float Speed;

    // ** 물리엔진
    private Rigidbody Rigid;
    
    // ** Enemy 오브젝트 프리팹을 추가.
    public GameObject EnemyPrefab;

    // ** Bullet 오브젝트 프리팹을 추가.
    public GameObject BulletPrefab;

    // ** 총알발사 확인용
    private bool BulletCheck;


    void Awake()
    {
        // ** 현재 오브젝트의 물리엔진 컴퍼넌트를 받아옴
        Rigid = GetComponent<Rigidbody>();

        // ** Resources 폴더 안에 있는 리소스를 불러옴.
        // ** Resources.Load("경로") as GameObject;  <= 의 형태 
        EnemyPrefab = Resources.Load("Prefab/EnemyPrefabs/TurtleShellPBR") as GameObject;
        BulletPrefab = Resources.Load("Prefab/Bullets/Bullet") as GameObject;
    }

    void Start()
    {
        // ** 바라보는 방향 초기값 셋팅.
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        // ** 물리엔진의 중력을 비활성화.
        Rigid.useGravity = false;

        // ** 이동속도
        Speed = 5.0f;

        // ** 총알 연속 발사를 제어하기 위함.
        // ** 발사 = true
        BulletCheck = true;

        // ** 하이라키 뷰에 "EnemyList" 이름의 빈 게임 오브젝트를 추가
        //GameObject ViewObject = new GameObject("EnablsList");
        new GameObject("EnableList");
        new GameObject("DisableList");


        for (int i = 0; i < 5; ++i)
        {
            // ** Instantiate = 복제함수
            // ** EnemyPrefab 의 오브젝트를 복제함
            //GameObject Obj = Instantiate(EnemyPrefab);
            //ObjectManager.GetInstance.AddObject(Obj);

            ObjectManager.GetInstance.CreateEnemy(
                Instantiate(EnemyPrefab));
        }

        // ** Fistall 코루틴 실행.
        StartCoroutine("Fistall");
    }

    private void Update()
    {
        // ** 플레이어 키보드 이동 관련..
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(Hor * Time.deltaTime * Speed, 0.0f, Ver * Time.deltaTime * Speed);

        // ** 스페이스 키 입력을 받았을때 에너미 생성
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ** Stack 에 데이터가 남아있는지 확인하고 없는상태라면 추가한다.
            if (ObjectManager.GetInstance.GetDisableList.Count == 0)
                for (int i = 0; i < 5; ++i)
                    ObjectManager.GetInstance.CreateEnemy(
                        Instantiate(EnemyPrefab));

            // ** GetDisableList 에 있는 객체 하나를 버리고
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            // ** 버려진 객체를 활성화 시켜 사용상태로 변경
            Obj.gameObject.SetActive(true);

            // ** 활성화된 오브젝트를 관리하는 리스트에 포함시킴.
            ObjectManager.GetInstance.GetEnableList.Add(Obj);
        }
        // ** 비활성화 상태에서 활성화 상태로 변경하고, 변경된 오브젝트는 
        // ** 활성화된 오브젝트만 모여있는 리스트에서 사용이 끝날때까지 관리 된다.


        
        if (Input.GetMouseButtonDown(0) && BulletCheck)
        {
            // ** BulletPrefab 객체 복사 
            GameObject Obj = Instantiate(BulletPrefab);

            // ** 총구의 위치로 이동시킴.
            Obj.transform.position = transform.position + (Vector3.up * 0.5f);

            // ** 플레이어 바라보는 방향으로 셋팅
            Obj.transform.rotation = transform.rotation;

            // ** FistController 이름의 스크립트를 복제된 오브젝트에 추가
            Obj.gameObject.AddComponent<FistController>();

            // ** 총알이 한번만 발사 되도록 설정
            BulletCheck = false;

            // ** Fistall 코루틴 실행
            StartCoroutine("Fistall");
        }
        


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RayPoint(ray);

        // ** 최초에 한번 플레이어를 바라보게 만듬.
        this.transform.rotation = Quaternion.LookRotation(Direction);
    }

    void RayPoint(Ray _ray)
    {
        // ** Ray가 타겟과 충돌했을때 반환 값을 저장하는 곳.
        RaycastHit hit;

        // ** Physics.Raycast( Ray시작 위치와 방향 , 충돌한 지점의 정보, Mathf.Infinity = 무한한)
        // ** 해석 : ray의 위치와 방향으로부터 RayPoint를 무한하게 발사하고 출동이 일어나면 Hit에 정보를 저장함.
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            // ** 충돌한 객체의 tag가 Ground 라면..
            if (hit.transform.tag == "Ground")
            {
                Direction = hit.point - this.transform.position;
                Direction.Normalize();
            }
        }
    }


    IEnumerator Fistall()
    {
        // ** 해당 시간마다 이 항수를 재호출함.
        yield return new WaitForSeconds(0.5f);

        // ** 호출이 될 때마다 true
        BulletCheck = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ** 충돌한 객체의 tag가 Enemy 라면..
        if (other.tag == "Enemy")
        {
            // ** EnableList에 있던 객체를 DisableList 로 변경
            other.transform.parent = GameObject.Find("DisableList").transform;

            // ** 객체를 DisableList 이동
            ObjectManager.GetInstance.GetDisableList.Push(other.gameObject);

            // ** EnableList 에 있던 객체 참조를 삭제
            ObjectManager.GetInstance.GetEnableList.Remove(other.gameObject);

            // ** 이동이 완료되면 객체를 비활성화
            other.gameObject.SetActive(false);
        }
    }
}


