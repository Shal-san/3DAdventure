using TMPro;
using UnityEngine;

public class KidCharacter : CharacterBase {
    CharacterState _current = CharacterState.Move;
    [SerializeField] float _interactRadius = 1.5f;
    [SerializeField] float _interactForward = 1f;
    [SerializeField] float _InteractDown = 0f;
    InteractableBase _currentInteractable = null;
    [SerializeField] TextMeshProUGUI _interactGuide = null;

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

        if (_currentInteractable != null) {
            _currentInteractable.Interact();
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

    protected override void ShowInteractsGuide() {
        InteractableBase previousInteractable = _currentInteractable;

        Collider[] hits = Physics.OverlapSphere(transform.position +
        transform.forward * _interactForward +
        Vector3.down * _InteractDown, _interactRadius, _interactLayer);

        if (hits.Length == 1) {
            _currentInteractable = hits[0].GetComponent<InteractableBase>();
        }
        else if (hits.Length > 1) {
            // Handle multiple interactables, e.g., by selecting the closest one
            float closestDistance = float.MaxValue;
            foreach (var hit in hits) {
                if (hit.TryGetComponent(out InteractableBase potentialInteractable)) {
                    float distance = Vector3.Distance(transform.position, hit.transform.position);
                    if (distance < closestDistance) {
                        closestDistance = distance;
                        _currentInteractable = potentialInteractable;
                    }
                }
            }
        }
        else {
            _currentInteractable = null;
        }

        if (_interactGuide != null) {
            if (_currentInteractable == null) {
                _interactGuide.gameObject.SetActive(false);
            }
            else if (previousInteractable != _currentInteractable) {
                _interactGuide.text = _currentInteractable.name;
                _interactGuide.gameObject.SetActive(true);
            }
        }
    }
}
