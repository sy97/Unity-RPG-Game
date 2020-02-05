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
    if (_focus != null) _focus.GetComponent<InteractableController>().StopInteract();

    _agent.isStopped = false;
    _agent.SetDestination(hit.point);
  }

  public void MoveToInteractable(RaycastHit hit)
  {
    _focus = hit.transform;
    _focus.GetComponent<InteractableController>().StartInteract();
    _agent.SetDestination(hit.point);
  }

  public void StopMoving()
  {
    _agent.isStopped = true;
  }
}