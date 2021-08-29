using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰� �־�� �浹����
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

    // ** Bullet ������Ʈ �������� �߰�.
    public GameObject BulletPrefab;

    // ���� �������� Ȯ��
    private bool BulletCheck;

    private void Awake()
    {
        // ** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
        Rigid = GetComponent<Rigidbody>();

        // WayPoint ��� ������ ��ǥ������ ����
        WayPoint = new GameObject("WayPoint");

        // WayPoint�� tag�� WayPoint�� ����
        WayPoint.transform.tag = "WayPoint";


        // ������ ��ǥ������ �ݶ��̴��� ����
        WayPoint.AddComponent<SphereCollider>();
        // ���Ե� �ݶ��̴��� ������ �޾ƿ�
        SphereCollider Sphere = WayPoint.GetComponent<SphereCollider>();
        // Sphere �ݶ��̴� ũ�⸦ ����
        Sphere.radius = 0.2f;
        // isTrigger�� true�� ����
        Sphere.isTrigger = true;

        // Bullet �������� �ҷ���
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;

    }

    private void Start()
    {
        // ��� ���� �ð�
        idleTime = 3.0f;



        Speed = 0.05f;
        Rigid.useGravity = false;


        BulletCheck = false;

        this.transform.parent = GameObject.Find("EnableList").transform;

        // ���� �ڤ����� ��ġ
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        //WayPoint = this.transform.FindChild("WayPoint").gameObject;

        Initialized();

        // Bullet�ڷ�ƾ ����
        StartCoroutine("Bullet");


        //// **WayPoint �̵� ��ǥ��ġ / ���� �Լ� = Random.Range(Min, Max)
        //WayPoint.transform.position = new Vector3(
        //    Random.Range(-25, 25),
        //    0.0f,
        //    Random.Range(-25, 25));
        //
        //// ���� �ڤ����� ��ġ
        //WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        ////** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
        //Move = true;
        //
        //// ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
        //Step = WayPoint.transform.position - this.transform.position;
        //
        //// ** ���⸸ �����ְ�
        //Step.Normalize();
        //
        //// ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
        //Step.y = 0;


    }
    private void OnEnable()
    {

        this.transform.parent = GameObject.Find("EnableList").transform;

        // ���� �ڤ����� ��ġ
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        Initialized();
        //// ** �ʱ�ȭ.
        //
        //// ** ���� �Լ� = Random.Range(Min, Max)
        //this.transform.position = new Vector3(
        //    Random.Range(-25, 25),
        //    0.0f,
        //    Random.Range(-25, 25));
        //
        //// ** ���̶�Ű�ο� �߰��� EnemyList�� �� ���ӿ�����Ʈ�� �θ�� ���� : ��������
        //this.transform.parent = GameObject.Find("EnablsList").transform;
        //
        ////** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
        //Move = true;
        //
        //// ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
        //Step = WayPoint.transform.position - this.transform.position;
        //
        //// ** ���⸸ �����ְ�
        //Step.Normalize();
        //
        //// ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
        //Step.y = 0;
    }


    private void Update()
    {
        if(BulletCheck == true)
        {
            GameObject Obj = Instantiate(BulletPrefab);
            // BulletController �̸��� ��ũ��Ʈ�� ������ ������Ʈ�� �߰�
            Obj.gameObject.AddComponent<BulletController>();
            Obj.gameObject.transform.position = this.gameObject.transform.position;

            // Obj.transform.position += Step * Speed;
            //Debug.DrawLine(this.transform.position, WayPoint.transform.position);

            // �Ѿ��� �ѹ��� �߻� �ǵ��� ����
            BulletCheck = false;

            // Bullet�ڷ�ƾ ����
            StartCoroutine("Bullet");
        }
    }


    private void FixedUpdate()
    {
        if (Move == true) // �� ������ �̵�
        {
            this.transform.position += Step * Speed;
            Debug.DrawLine(this.transform.position, WayPoint.transform.position);
        }

       //else // �ƴϸ� ����Ÿ���� ã��
       //{
       //
       //
       //    idleTime -= Time.deltaTime;
       //
       //    if (idleTime < 0)
       //    {
       //        // **WayPoint �̵� ��ǥ��ġ / ���� �Լ� = Random.Range(Min, Max)
       //        WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
       //
       //        //** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
       //        Move = true;
       //
       //        // ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
       //        Step = WayPoint.transform.position - this.transform.position;
       //
       //        // ** ���⸸ �����ְ�
       //        Step.Normalize();
       //
       //        // ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
       //        Step.y = 0;
       //
       //        // ��� �ð� ���� 3~5��
       //        idleTime = Random.Range(3, 5);
       //    }
       //    // ��� �ִϸ��̼�
       //    //else
       //    //{     
       //    //    Force = 2000.0f;
       //    //
       //    //    //** ���� ���Ͽ� �̵���Ŵ.
       //    //   Rigid.AddForce(Vector3.forward * Force);
       //    //}
       //}
    }
    private void Initialized()
    {

        // **WayPoint �̵� ��ǥ��ġ / ���� �Լ� = Random.Range(Min, Max)
        WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        //** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
        Move = true;

        // ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
        Step = WayPoint.transform.position - this.transform.position;

        // ** ���⸸ �����ְ�
        Step.Normalize();

        // ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
        Step.y = 0;

        // 
        WayPoint.transform.position.Set(WayPoint.transform.position.x, 0.0f, WayPoint.transform.position.z);

        // ��ü�� �ش������ �ٶ�
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

        //   // **WayPoint �̵� ��ǥ��ġ / ���� �Լ� = Random.Range(Min, Max)
        //   WayPoint.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
        //
        //   //** Ÿ���� �����Ǿ����� �����ϼ� �ֵ��� true�� ����
        //   Move = true;
        //
        //   // ** Ÿ���� ������ �ٶ󺸴� ���͸� ����.
        //   Step = WayPoint.transform.position - this.transform.position;
        //
        //   // ** ���⸸ �����ְ�
        //   Step.Normalize();
        //
        //   // ** ���� ���⿡ Y���� �� ������ ���ֹ���. ���۵� ����.
        //   Step.y = 0;


    }

    IEnumerator EnemyState()
    {


        yield return new WaitForSeconds(Random.Range( 3, 5)); // �̰����� 1�ʸ� ��ٷȴٰ� ���ķ� �Ѿ

        Initialized();

    }

    IEnumerator Bullet()
    {


        yield return new WaitForSeconds(Random.Range(3, 5)); // �̰����� 1�ʸ� ��ٷȴٰ� ���ķ� �Ѿ

        BulletCheck = true;

    }
}
