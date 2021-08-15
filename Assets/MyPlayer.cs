using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyPlayer : MonoBehaviour
{
    public MoveTarget target;
    public LookTarget lookTarget;

    private void Awake()
    {
        if(target == null)
        {
            target = FindObjectOfType<MoveTarget>();
        }
        if(lookTarget == null)
        {
            lookTarget = FindObjectOfType<LookTarget>();
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
        MoveAgent();
        DrawSight();
    }

    private void DrawSight()
    {
        var direction = (lookTarget.transform.position - this.transform.position);
        bool isVisible = false;
        int layer = LayerMask.GetMask("Wall");
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, 1000F, 1 << layer);
        if(hit.collider != null)
        {
            Debug.Log("HIT " + hit.collider.gameObject.name);
            if(lookTarget.gameObject == hit.collider.gameObject)
            {
                isVisible = true;
            }
        }
        Color c = Color.red;
        if(isVisible)
        {
            c = Color.green;
        }
        Debug.DrawRay(this.transform.position, direction, c);
    }

    private void MoveAgent()
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
