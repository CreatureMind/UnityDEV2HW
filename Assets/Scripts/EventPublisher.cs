using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EventPublisher : MonoBehaviour
{
    public static event Action OnJump;
    public static event Action OnRun;
    public static event Action OnIdle;
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float jumpDuration = 1.0f;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            if (IsJumpLink(agent.currentOffMeshLinkData))
            {
                StartCoroutine(JumpRoutine());
            }
        }
    }

    bool IsJumpLink(OffMeshLinkData linkData)
    {
        return linkData.linkType == OffMeshLinkType.LinkTypeJumpAcross; 
    }

    IEnumerator JumpRoutine()
    {
        agent.enabled = false;
        OnJump?.Invoke();

        OffMeshLinkData linkData = agent.currentOffMeshLinkData;
        Vector3 startPos = linkData.startPos;
        Vector3 endPos = linkData.endPos;
        
        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / jumpDuration;
            
            Vector3 currentPos = Vector3.Lerp(startPos, endPos, normalizedTime);
            
            float parabola = 4 * jumpHeight * normalizedTime * (1 - normalizedTime);
            currentPos.y += parabola;

            transform.position = currentPos;

            yield return null;
        }
        
        transform.position = endPos;

        agent.CompleteOffMeshLink();
        agent.enabled = true;
    }
}
