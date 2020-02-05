using UnityEngine;

public class InteractableController : MonoBehaviour
{
  [SerializeField] Transform _player;
  private PlayerController _playerController;

  public float radius { get; } = 3f;

  private bool interacting = false;
  private bool hasInteracted = false;
  private float distance;

  private void Start()
  {
    _playerController = _player.GetComponent<PlayerController>();
  }

  void Update()
  {
    distance = Vector3.Distance(transform.position, _player.position);

    if (!interacting) return;

    if (distance <= radius)
    {
      _playerController.StopMoving();
      if (!hasInteracted)
      {
        Debug.Log("interacting with: " + transform.name);
        hasInteracted = true;
      }
    }

  }

  private void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, radius);
    Gizmos.color = Color.yellow;
  }

  public void StartInteract()
  {
    interacting = true;
    hasInteracted = false;
  }

  public void StopInteract()
  {
    interacting = false;
    hasInteracted = false;
  }
}