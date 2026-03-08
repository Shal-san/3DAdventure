using UnityEngine;

public class KidCharacter : CharacterBase {
    CharacterState _current = CharacterState.Move;
    [SerializeField] float _interactRadius = 1.5f;
    [SerializeField] float _interactForward = 1f;
    [SerializeField] float _InteractDown = 0f;
    public override void CharacterUpdate() {
        base.CharacterUpdate();
        switch (_current) {
            case CharacterState.Move:
                Move();
                break;
            case CharacterState.Interact:
                Interact();
                break;
            default: break;
        }
    }

    protected override void Move() {
        base.Move();
        if (_input.Interact) {
            _current = CharacterState.Interact;
        }
    }

    protected override void Interact() {
        Collider[] hits = Physics.OverlapSphere(transform.position +
        transform.forward * _interactForward +
        Vector3.down * _InteractDown, _interactRadius);
        InteractableBase interactable = null;

        if (hits.Length == 1) {
            interactable = hits[0].GetComponent<InteractableBase>();
        }
        else if (hits.Length > 1) {
            // Handle multiple interactables, e.g., by selecting the closest one
            float closestDistance = float.MaxValue;
            foreach (var hit in hits) {
                if (hit.TryGetComponent<InteractableBase>(out InteractableBase potentialInteractable)) {
                    float distance = Vector3.Distance(transform.position, hit.transform.position);
                    if (distance < closestDistance) {
                        closestDistance = distance;
                        interactable = potentialInteractable;
                    }
                }
            }
        }

        if (interactable != null) {
            interactable.Interact();
        }

        //if interact action ended, return to move state
        _current = CharacterState.Move;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        Vector3 interactCenter =
            transform.position +
            transform.forward * _interactForward +
            Vector3.down * _InteractDown;

        Gizmos.DrawWireSphere(interactCenter, _interactRadius);
    }
}
