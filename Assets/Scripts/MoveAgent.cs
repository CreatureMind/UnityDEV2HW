using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private InputType myMovementInputType;
    
    private const string FinishLineAreaName = "FinishLine";
    
    public static event Action<GameObject> PlayerTouchedFinishLine;
    
    public void Awake()
    {
        PlayerInputMethods.OnInputPerformed += SendInputToAgent;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(FinishLineAreaName))
        {
            PlayerTouchedFinishLine?.Invoke(gameObject);
        }
    }
    
    

    private void SendInputToAgent(InputType inputType)
    {
        if (myMovementInputType != inputType) return;
        Vector2 inputPosition = Mouse.current.position.ReadValue();
        
        Physics.Raycast(Camera.main.ScreenPointToRay(inputPosition), out var hit);
        if (hit.collider == null) return;
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
