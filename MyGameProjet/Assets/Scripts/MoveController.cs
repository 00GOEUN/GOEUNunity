using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ** �ش� ���۳�Ʈ�� ���� : ���� Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    // ** �ٶ󺸴� ����
    private Vector3 Direction;

    // ** �̵� �ӵ�
    [SerializeField] private float Speed;

    // ** ��������
    private Rigidbody Rigid;

    // ** Enemy ������Ʈ �������� �߰�.
    public GameObject EnemyPrefab;

    // ** Bullet ������Ʈ �������� �߰�.
    public GameObject BulletPrefab;

    // ** �Ѿ˹߻� Ȯ�ο�
    private bool BulletCheck;


    void Awake()
    {
        // ** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();

        // ** Resources ���� �ȿ� �ִ� ���ҽ��� �ҷ���.
        // ** Resources.Load("���") as GameObject;  <= �� ���� 
        EnemyPrefab = Resources.Load("Prefab/EnemyPrefabs/TurtleShellPBR") as GameObject;
        BulletPrefab = Resources.Load("Prefab/Bullets/Bullet") as GameObject;
    }

    void Start()
    {
        // ** �ٶ󺸴� ���� �ʱⰪ ����.
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        // ** ���������� �߷��� ��Ȱ��ȭ.
        Rigid.useGravity = false;

        // ** �̵��ӵ�
        Speed = 5.0f;

        // ** �Ѿ� ���� �߻縦 �����ϱ� ����.
        // ** �߻� = true
        BulletCheck = true;

        // ** ���̶�Ű �信 "EnemyList" �̸��� �� ���� ������Ʈ�� �߰�
        //GameObject ViewObject = new GameObject("EnablsList");
        new GameObject("EnableList");
        new GameObject("DisableList");


        for (int i = 0; i < 5; ++i)
        {
            // ** Instantiate = �����Լ�
            // ** EnemyPrefab �� ������Ʈ�� ������
            //GameObject Obj = Instantiate(EnemyPrefab);
            //ObjectManager.GetInstance.AddObject(Obj);

            ObjectManager.GetInstance.CreateEnemy(
                Instantiate(EnemyPrefab));
        }

        // ** Fistall �ڷ�ƾ ����.
        StartCoroutine("Fistall");
    }

    private void Update()
    {
        // ** �÷��̾� Ű���� �̵� ����..
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(Hor * Time.deltaTime * Speed, 0.0f, Ver * Time.deltaTime * Speed);



        // ** �����̽� Ű �Է��� �޾����� ���ʹ� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ** Stack �� �����Ͱ� �����ִ��� Ȯ���ϰ� ���»��¶�� �߰��Ѵ�.
            if (ObjectManager.GetInstance.GetDisableList.Count == 0)
                for (int i = 0; i < 5; ++i)
                    ObjectManager.GetInstance.CreateEnemy(
                        Instantiate(EnemyPrefab));

            // ** GetDisableList �� �ִ� ��ü �ϳ��� ������
            GameObject Obj = ObjectManager.GetInstance.GetDisableList.Pop();

            // ** ������ ��ü�� Ȱ��ȭ ���� �����·� ����
            Obj.gameObject.SetActive(true);

            // ** Ȱ��ȭ�� ������Ʈ�� �����ϴ� ����Ʈ�� ���Խ�Ŵ.
            ObjectManager.GetInstance.GetEnableList.Add(Obj);
        }
        // ** ��Ȱ��ȭ ���¿��� Ȱ��ȭ ���·� �����ϰ�, ����� ������Ʈ�� 
        // ** Ȱ��ȭ�� ������Ʈ�� ���ִ� ����Ʈ���� ����� ���������� ���� �ȴ�.



        if (Input.GetMouseButtonDown(0) && BulletCheck)
        {
            // ** BulletPrefab ��ü ���� 
            GameObject Obj = Instantiate(BulletPrefab);

            // ** �ѱ��� ��ġ�� �̵���Ŵ.
            Obj.transform.position = transform.position + (Vector3.up * 0.5f);

            // ** �÷��̾� �ٶ󺸴� �������� ����
            Obj.transform.rotation = transform.rotation;

            // ** FistController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
            Obj.gameObject.AddComponent<FistController>();

            // ** �Ѿ��� �ѹ��� �߻� �ǵ��� ����
            BulletCheck = false;

            // ** Fistall �ڷ�ƾ ����
            StartCoroutine("Fistall");
        }



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RayPoint(ray);

        // ** ���ʿ� �ѹ� �÷��̾ �ٶ󺸰� ����.
        this.transform.rotation = Quaternion.LookRotation(Direction);
    }

    void RayPoint(Ray _ray)
    {
        // ** Ray�� Ÿ�ٰ� �浹������ ��ȯ ���� �����ϴ� ��.
        RaycastHit hit;

        // ** Physics.Raycast( Ray���� ��ġ�� ���� , �浹�� ������ ����, Mathf.Infinity = ������)
        // ** �ؼ� : ray�� ��ġ�� �������κ��� RayPoint�� �����ϰ� �߻��ϰ� �⵿�� �Ͼ�� Hit�� ������ ������.
        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            // ** �浹�� ��ü�� tag�� Ground ���..
            if (hit.transform.tag == "Ground")
            {
                Direction = hit.point - this.transform.position;
                Direction.Normalize();
            }
        }
    }


    IEnumerator Fistall()
    {
        // ** �ش� �ð����� �� �׼��� ��ȣ����.
        yield return new WaitForSeconds(0.5f);

        // ** ȣ���� �� ������ true
        BulletCheck = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ** �浹�� ��ü�� tag�� Enemy ���..
        if (other.tag == "Enemy")
        {
            // ** EnableList�� �ִ� ��ü�� DisableList �� ����
            other.transform.parent = GameObject.Find("DisableList").transform;

            // ** ��ü�� DisableList �̵�
            ObjectManager.GetInstance.GetDisableList.Push(other.gameObject);

            // ** EnableList �� �ִ� ��ü ������ ����
            ObjectManager.GetInstance.GetEnableList.Remove(other.gameObject);

            // ** �̵��� �Ϸ�Ǹ� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);
        }
    }
}