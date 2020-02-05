using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
  protected Transform player;

  public float radius { get; } = 3f;

  protected bool interacting = false;
  protected bool hasInteracted = false;
  protected float distance;

  void Update()
  {
    if (player != null) distance = Vector3.Distance(transform.position, player.position);

    if (!interacting) return;

    if (distance <= radius)
    {
      player.GetComponent<PlayerController>().StopMoving();
      if (!hasInteracted)
      {
        Interact();
        hasInteracted = true;
      }
    }
  }

  public virtual void Interact()
  {
    Debug.Log("interacting with: " + transform.name);
  }

  private void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, radius);
    Gizmos.color = Color.yellow;
  }

  public void StartInteract(Transform player)
  {
    if (this.player == null) this.player = player;
    interacting = true;
    hasInteracted = false;
  }

  public void StopInteract()
  {
    interacting = false;
    hasInteracted = false;
  }
}