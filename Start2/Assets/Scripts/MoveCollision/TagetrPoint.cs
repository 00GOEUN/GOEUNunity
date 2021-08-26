using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetrPoint : MonoBehaviour
{
    // ¿·±Ò ∏ÿ√„

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(this.transform.position, 1.0f);
    }
}