using UnityEngine;

public class Poster : InteractableBase {
    override public void Interact() {
        Debug.Log(gameObject.name + " Interacted");
    }
    // Branches depending on the position (orientation) where the player interacts with it. ex)front, back
}
