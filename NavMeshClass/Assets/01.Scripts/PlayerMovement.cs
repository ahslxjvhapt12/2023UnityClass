using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _navAgent;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos;
            if (GameManager.Instance.GetMouseWorldPosition(out pos))
            {
                _navAgent.SetDestination(pos);
            }
        }
    }

}
