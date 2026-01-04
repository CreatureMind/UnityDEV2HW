using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private InputType myMovementInputType;
    
    public void Awake()
    {
        PlayerInputMethods.OnInputPerformed += SendInputToAgent;
    }

    private void SendInputToAgent(InputType inputType)
    {
        if (myMovementInputType != inputType) return;
        Vector2 inputPosition = Mouse.current.position.ReadValue();
        
        Physics.Raycast(Camera.main.ScreenPointToRay(inputPosition), out var hit);
        Debug.Log(hit.collider.gameObject.name + hit.point);
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
