 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{

    // �̱�(����)�� ����
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        // Getter ��ȯ��
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();

            return Instance;
        }
    }

    // ������ private ���� : �ܺο��� ���� ���X
    private ObjectManager() { }

    // Enemy ������Ʈ �������� �߰�
    //private GameObject EnemyPrefab;


    // Enemy ���� ����Ʈ
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
   //    // ���̶�Ű �信 EnemyList��� �� ���� ������Ʈ�� �߰�
   //    //GameObject ViewObject = new GameObject("EnablsList");
   //    new GameObject("EnablsList");
   //    new GameObject("DisableList");
   //
   //    // Resources ���� �ȿ� �ִ� ���ҽ��� �ҷ���
   //    // Resources.Load("���") as GameObject;
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

    

    // ������Ʈ ����Ʈ�� �߰�
    public void AddObject(GameObject _Object)
    {

        // EnemyController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
        _Object.AddComponent<EnemyController>();

        // ���̶�Ű �信 �߰��� EnemyList�� �� ���� ������Ʈ�� �θ�� ���� : ��������
        _Object.transform.parent = GameObject.Find("DisableList").transform;

        // ������ Enemy�� �浹ü�� �ִ� Trigger ����� ��
        _Object.GetComponent<BoxCollider>().isTrigger = true;

        // ���� �Լ� Random.Range( Min, Max)
        _Object.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // ������ ������Ʈ�� ��Ȱ��ȭ ����
        _Object.gameObject.SetActive(false);

        // ����Ʈ�� �߰�
        DisableList.Push(_Object);

    // Enemy �ʱ� ����
    //void CreateEnemy()
        //for (int i = 0; i < 5; ++i)
        //{
        //    // Insantiate �����Լ�
        //    // EnemyPrefab�� ������Ʈ�� ����
        //    //GameObject Obj = Instantiate(EnemyPrefab);
        //
        //    // EnemyController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
        //    //Obj.AddComponent<EnemyController>();
        //
        //    // ���̶�Ű �信 �߰��� EnemyList�� �� ���� ������Ʈ�� �θ�� ���� : ��������
        //    //Obj.transform.parent = GameObject.Find("DisableList").transform;
        //
        //    // ������ Enemy�� �浹ü�� �ִ� Trigger ����� ��
        //    //Obj.GetComponent<BoxCollider>().isTrigger = true;
        //
        //    // x = -25 ~ 25
        //    // y = -25 ~ 25
        //
        //    // ���� �Լ� Random.Range( Min, Max)
        //    //Obj.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        //    // ������ ������Ʈ�� ��Ȱ��ȭ ����
        //    //Obj.SetActive(false);
        //
        //    // ����Ʈ�� �߰�
        //    //EnemyList.Add(Obj);
        //    //DisableList.Push(Obj);
        //
        // }
    }

}
