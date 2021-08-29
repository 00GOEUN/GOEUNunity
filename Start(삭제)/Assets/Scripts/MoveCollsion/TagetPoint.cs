using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.grey;

        Gizmos.DrawSphere(this.transform.position, 1.0f);
    }
}
