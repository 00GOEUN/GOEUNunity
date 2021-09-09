using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointBar : MonoBehaviour
{
    [SerializeField] private GameObject HitPoint;
    [SerializeField] private Slider AnchorPoint;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Vector3 CameraPos;

    [SerializeField] private float Damage;

    private void Awake()
    {
        HitPoint = GameObject.Find("HitPointCanvas/HitPointSilder");
        AnchorPoint = HitPoint.GetComponent<Slider>();
        CameraPos = Camera.main.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        AnchorPoint.maxValue = 100;
        AnchorPoint.value = AnchorPoint.maxValue;
        Offset = new Vector3(0.0f, 1.85f, 0.0f);

        Damage = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPos = Offset + transform.position;

        HitPoint.transform.position = Camera.main.WorldToScreenPoint(CameraPos);

        if(Input.GetKey(KeyCode.N))
        {
            AnchorPoint.value -= Damage;
        }
        if (Input.GetKey(KeyCode.M))
        {
            AnchorPoint.value += Damage;

        }

    }
}
