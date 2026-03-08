using UnityEngine;

public class Obtainable : InteractableBase {
    public override void Interact() {
        Debug.Log(gameObject.name + " Interacted");
        gameObject.SetActive(false); // Example: Deactivate the object to simulate obtaining it
    }
    // ex) OnlyOnce or Respawn
}
