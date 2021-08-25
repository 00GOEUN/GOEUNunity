using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �ش� ���۳�Ʈ�� ���� : ���� Rigdbody
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float Speed;

    private GameObject TargetPoint;

    private bool Move;

    private Vector3 Step;
    private Rigidbody Rigid;

    // Enemy ������Ʈ�� �������� �߰�
    public GameObject EnemyPrefab;


    void Awake()
    {
        // ���̶���Ű�信 "EnemyLsit" �̸��� �� ���� ������Ʈ �߰�
        // GameObject ViewObject = new GameObject("EnemyList");
        
        // ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();

        // TargetPoint��� ��ü�� ã�´�
        // �̸��� �Ű����� ���� �̸��� ��ü�� ������ ������ ����
        TargetPoint = GameObject.Find("TargetPoint");

        // ���ҽ� ���� �ȿ� �ִ� ���ν��� �ҷ���
        // Resources.Load("���") as GameObject;  
        EnemyPrefab = Resources.Load("Prefabs/Enemy") as GameObject;

        //// ���̶���Ű�信 "EnemyLsit" �̸��� �� ���� ������Ʈ �߰�
        ////GameObject ViewObject = new GameObject("EnableList");
        //new GameObject("EnableList");
        //new GameObject("DisableList");
    }

    void Start()
    {
        // ���������� �߷��� ��Ȱ��ȭ
        Rigid.useGravity = false;

        // �����Ҷ� TargetPoint ��ġ�� ���� ������Ʈ�� ��ġ�� �ʱ�ȭ
        TargetPoint.transform.position = this.transform.position;
        //this.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        
        // Step = ���� : �����Ҷ��� �� ������ ���� ����
        Step = new Vector3(0.0f, 0.0f, 0.0f);
        // Speed = �̵��ӵ�
        Speed = 15.0f;
        // Move = �̵����� : �����Ҷ� �������·� ����
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
       
        //  �����̽� Ű �Է� ������
        if (Input.GetKey(KeyCode.Space))
        {
            // GetDisableList�� �ִ� ��ü �ϳ��� ������
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            //������ ��ü�� Ȱ��ȭ ���� �����·� ����
            Obj.gameObject.SetActive(true);
            // ������ parent �� EnablsList ������ ���Խ�Ű��
            Obj.transform.parent = GameObject.Find("EnableList").transform;
            // Ȱ��ȭ�� ������Ʈ�� �����ϴ� ����Ʈ�� ���Խ�Ŵ
            ObjectManager.GetInstance.GetEnableList.Add(Obj);
        }
        // ��Ȱ��ȭ ���¿��� Ȱ��ȭ ���ַ� �����ϰ�, ����� ������Ʈ��
        // Ȱ��ȭ�� ������Ʈ�� ���ִ� ����Ʈ���� ����� ���������� ���� ��


    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            // ȭ�鿡 �ִ� ���콺 ��ġ�κ��� Ray�� ���������� ������ �����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RayPoint(ray);
        }

        // Move�� true�϶��� �̵� ������ ���¸� ����
        if (Move == true)
            // Step = ���� Speed = �ӵ�
            // Step �������� Speed ��ŭ �̵�
            this.transform.position += Step * Time.deltaTime * Speed;

    }


    void RayPoint(Ray _ray)
    {
        // Ray�� Ÿ�ٰ� �浹������ ��ȯ ���� �����ϴ� ��.
        RaycastHit hit;

        // Physics.Raycast( Ray���� ��ġ�� ���� , �浹�� ������ ����, Mathf.Infinity = ������)
        // ray�� ��ġ�� �������κ��� RayPoint�� �����ϰ� �߻��ϰ� �⵿�� �Ͼ�� Hit�� ������ ������.
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ground")
            {
                // ray�� ��ġ�� ���� hit�� ��ġ���� ���� �׸�. ���� ���ӿ����� �Ⱥ���.
                Debug.DrawLine(_ray.origin, hit.point);
                Debug.Log(hit.point);

                // hit�� ��ġ�� Ÿ�� ��ǥ�� �޾ƿ�
                TargetPoint.transform.position = hit.point;
                // Ÿ���� �����Ǿ����� ������ �� �ֵ��� true�� ����
                Move = true;

                // Ÿ���� ������ �ٶ󺸴� ���͸� ����
                // �Լ� = B - A;
                Step = TargetPoint.transform.position - this.transform.position;
                // ���⸸ ����
                // �Լ�.Normalize();
                Step.Normalize();
                // ���� ������ y���� ���ֹ��� ���۵� ����
                Step.y = 0;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� �̸��� TargetPoint�� �ƴ϶�� �����ϰ� TargetPoint�϶� ����
        //if(other.tag =="")
        if (other.name == "TargetPoint")
            Move = false;
    }


   
}