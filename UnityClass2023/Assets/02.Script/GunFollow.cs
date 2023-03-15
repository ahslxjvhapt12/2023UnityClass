using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public Transform target2Follow;

    private void LateUpdate()
    {
        transform.position = target2Follow.position;
        transform.rotation = target2Follow.rotation;
    }
}
