using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{

    private GameObject EarthObject;

    private void Awake()
    {

        EarthObject = GameObject.Find("Earth");
    }

    // Start is called before the first frame update
    void Start()
    {// 부모를 지구로 
        this.transform.parent = EarthObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
