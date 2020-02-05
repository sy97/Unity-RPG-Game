using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : BaseInteractable
{
  public override void Interact()
  {
    base.Interact();
    Debug.Log("Picked up");
    Destroy(this.gameObject);
  }
}
