using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyPlayer : MonoBehaviour
{
    public MyTarget target;

    private void Awake()
    {
        if(target == null)
        {
            target = FindObjectOfType<MyTarget>();
        }
    }

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        var agent = GetComponent<NavMeshAgent>();
        bool isTargetFar = (target.transform.position - this.transform.position).magnitude > 0.1;
        bool isDestinationChanged = (target.transform.position - agent.destination).magnitude > 0.1;
        if (target != null && isTargetFar && isDestinationChanged)
        {
            Debug.Log(gameObject.name + " TARGET=" + target.transform.position + " DEST=" + agent.destination);
            agent.SetDestination(target.transform.position);
        }
    }
}
