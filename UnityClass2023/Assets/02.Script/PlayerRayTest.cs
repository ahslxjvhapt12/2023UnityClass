using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayTest : MonoBehaviour
{
    float maxDistance = 10;

    private void OnDrawGizmos()
    {
        RaycastHit hit;

        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, maxDistance);

        if (isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
