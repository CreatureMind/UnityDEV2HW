using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private InputType myMovementInputType;
    
    public void Awake()
    {
        PlayerInputMethods.OnInputPerformed += SendInputToAgent;
    }

    private void SendInputToAgent(InputType inputType, Vector2 inputPosition)
    {
        if (myMovementInputType != inputType) return;
        Physics.Raycast(Camera.main.ScreenPointToRay(inputPosition), out var hit);
        agent.SetDestination(hit.point);
    }

    public void OnValidate()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
}
