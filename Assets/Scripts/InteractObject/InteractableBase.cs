using UnityEngine;
using TMPro;

abstract public class InteractableBase : MonoBehaviour {
    [SerializeField] protected TextMeshProUGUI _interactMessage = null;

    abstract public void Interact();
}
