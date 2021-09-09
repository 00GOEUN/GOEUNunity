using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // ** 추적할 목표 객체
    private GameObject Target;

    // ** 얼마만큼의 위치에서 추적할 것인지 결정
    private Vector3 Offset;

    // ** 화면 확대/축소 거리
    private float ZoomDistance;

    // ** 메인카메라를 받아옴
    private Camera MainCamera;


    // ** 카메라가 흔들릴 시간
    private float ShakeTime;


    // ** [const]

    // ** 카메라 줌 최소값
    private const float Minimum = 40.0F;

    // ** 카메라 줌 최대값
    private const float Maximum = 65.0F;


    private void Awake()
    {
        // ** 목표물 설정
        Target = GameObject.Find("Player");
        
        // ** 메인 카메라를 받아옴
        MainCamera = Camera.main;
    }

    private void Start()
    {
        // ** 따라다닐 위치를 설정한다.
        Offset = new Vector3(0.0f, 9f, -6.0f);

        // ** 현재 오브젝트를 목표물의 하위 계층으로 귀속
        //this.transform.parent = Target.transform;

        // ** 카메라의 위치를 최초에 한번 지정된 장소로 셋팅
        this.transform.position = new Vector3(
            Offset.x + Target.transform.position.x,
            Offset.y + Target.transform.position.y,
            Offset.z + Target.transform.position.z);

        // ** 최초에 한번 플레이어를 바라보게 만듬.
        this.transform.rotation = Quaternion.LookRotation( 
            (Target.transform.position - this.transform.position).normalized );

        // ** 초기 거리는 0 으로 셋팅
        ZoomDistance = 50.0f;

        // ** 카메라가 흔들릴 시간
        ShakeTime = 0.08f;
    }

    void Update()
    {
        // ** 마우스의 스크롤 값을 받아옴.
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel") * -1;

        // ** 카메라와 타겟과의 거리를 받아옴
        ZoomDistance += (MouseScroll * 15);

        // ** 거리 최소값 설정.
        if (ZoomDistance < Minimum)
            ZoomDistance = Minimum;

        // ** 거리 최대값 설정.
        if (ZoomDistance > Maximum)
            ZoomDistance = Maximum;

        // ** 선형보간 이동 : 카메라와 타겟과의 거리를 조정 
        MainCamera.fieldOfView = Mathf.Lerp(
            MainCamera.fieldOfView,
            ZoomDistance, Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.X))
            StartCoroutine("ShakeCamera");


        FolloingCamera();
    }


    void FolloingCamera()
    {
        // ** 카메라가 목표지점까지 이동하는 시간을 셋팅.
        // ** Vector3.Lerp(시작점, 도착점, 시간)
        Vector3 SmoothFolloingPosition = Vector3.Lerp(
            this.transform.position, Target.transform.position + Offset, Time.deltaTime * 5.0f);

        // ** 위에서 셋팅된 위치로 적용.d
        this.transform.position = SmoothFolloingPosition;
    }


    IEnumerator ShakeCamera()
    {
        // ** 함수가 시작되면 제일 처음으로 카메라 좌표를 받아옴.
        Vector3 OldPosition = this.transform.position;

        while (true)
        {
            // ** 0.005f 초 마다 실행
            yield return new WaitForSeconds(0.005f);

            // ** 카메라가 흔들릴 반경 셋팅
            this.transform.position = this.transform.position +
                new Vector3(
                    Random.Range(-0.15f, 0.15f),
                    Random.Range(-0.15f, 0.15f), 
                    Random.Range(-0.15f, 0.15f));

            ShakeTime -= Time.deltaTime;

            if (ShakeTime < 0)
                break;
        }

        // ** 받아온 좌표로(기존에 있던 위치로) 되돌림.
        MainCamera.transform.position = OldPosition;

        // ** 카메라가 흔들릴 시간
        ShakeTime = 0.08f;
    }
}
