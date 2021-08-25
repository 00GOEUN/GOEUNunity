using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    // �̱��� ����
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        // Getter ��ȯ
        get
        {
            if (Instance == null)
                Instance = new ObjectManager(); 

            return Instance;
        }
        // Setter ��ȯ set {}
    }


    // ������ private ���� : �ܺλ��� ���X
    private ObjectManager() { } 
    //private void OnRenderObject() {}


    // Enemy ������Ʈ�� �������� �߰�
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


    // Enemy ���� ����Ʈ
    // �ʱ�ȭ ����ߵ�  = new List<GameObject>();
    //private List<GameObject> EnemyList = new List<GameObject>();

    //void Awake()
    //{
    //    // ���̶���Ű�信 "EnemyLsit" �̸��� �� ���� ������Ʈ �߰�
    //    //GameObject ViewObject = new GameObject("EnableList");
    //    new GameObject("EnableList");
    //    new GameObject("DisableList");
    //
    //   
    //}


    //     private void Start()// ��ŸƮ = �ѹ��� ����
    // {
    //     
    //     
    // }

    // Enemy �ʱ� ����
    //void CreateEnemy()
    // ������Ʈ�� ����Ʈ�� �߰�
    public void AddObject(GameObject _Object)
    {
       
        // Instantiate �����Լ�
        // EnemyPrefab�� ������Ʈ�� ����
        //GameObject Obj = Instantiate(EnemyPrefab);

        // Enemycontroller �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
        //Obj.AddComponent<EnemyController>();
        _Object.AddComponent<EnemyController>();

        // ���̶���Ű �信 �߰��� EnemtList�� �� ���ӿ�����Ʈ�� �θ�� ���� : ��������
        //Obj.transform.parent = GameObject.Find("DisableList").transform;
        _Object.transform.parent = GameObject.Find("DisableList").transform;
        // Obj.name = 
        // ��ġ ����
        // x = -25 ~25
        // z = -25 ~ 25

        // ���� ���� �Լ� Random.Range( Min, Max)
        // Random.Range(-25,25)


        // ������ Enemy �浹ü�� �ִ� Trigger ����� ��
        //Obj.GetComponent<BoxCollider>().isTrigger = true;
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        //Obj.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        _Object.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        // �ѹ��� ���� �� ���� ��ġ ������ �ʿ䰡 ����

        // ������ ������Ʈ�� ��Ȱ��ȭ ��Ŵ
        //Obj.SetActive(false);
        _Object.gameObject.SetActive(false);


        // ����Ʈ�� �߰�
        //EnemyList.Add(Obj);
        //DisableList.Push(Obj);
        DisableList.Push(_Object);

    }

}
