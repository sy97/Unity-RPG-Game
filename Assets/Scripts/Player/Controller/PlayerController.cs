using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float movementSpeed = 10;

  private PlayerMovement _playerMovement;

  private RaycastHit _hit;
  // Start is called before the first frame update
  void Start()
  {
    _playerMovement = GetComponent<PlayerMovement>();
  }

  // Update is called once per frame
  void Update()
  {
    UpdateRaycast();
    HandleMouseInput();
  }

  void UpdateRaycast()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (!Physics.Raycast(ray, out _hit, 100)) return;
  }

  void HandleMouseInput()
  {
    if (_hit.transform == transform) return;

    if (Input.GetMouseButtonDown(0))
    {
      if (_hit.transform.gameObject.layer != LayerMask.NameToLayer("Ground"))
      {
        _playerMovement.MoveToInteractable(_hit);
      }
    }

    if (Input.GetMouseButtonDown(1))
    {
      _playerMovement.MoveTo(_hit);
    }
  }

  public void StopMoving()
  {
    _playerMovement.StopMoving();
  }


}
