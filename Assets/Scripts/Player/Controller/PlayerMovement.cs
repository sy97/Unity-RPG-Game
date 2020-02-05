using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
  private NavMeshAgent _agent;
  private Transform _focus;

  void Start()
  {
    _agent = GetComponent<NavMeshAgent>();
  }

  public void MoveTo(RaycastHit hit)
  {
    if (_focus != null) _focus.GetComponent<BaseInteractable>().StopInteract();

    _agent.isStopped = false;
    _agent.SetDestination(hit.point);
  }

  public void MoveToInteractable(RaycastHit hit)
  {
    _focus = hit.transform;
    _focus.GetComponent<BaseInteractable>().StartInteract(transform);
    _agent.SetDestination(hit.point);
  }

  public void StopMoving()
  {
    _agent.isStopped = true;
  }
}