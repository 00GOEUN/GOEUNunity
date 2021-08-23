using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    private GameObject SunObject;

    private void Awake()
    {

        SunObject = GameObject.Find("Sun");
    }

    // Start is called before the first frame update
    void Start()
    {// 부모를 태양로 
        this.transform.parent = SunObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(this.transform.up * Time.deltaTime * 5.0f);
    }
}
