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
        if(target != null && (target.transform.position - this.transform.position).magnitude > 0.1)
        {
            Debug.Log(gameObject.name + " MOVE " + target.transform.position);
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }
    }
}
