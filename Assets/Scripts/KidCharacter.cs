using UnityEngine;

public class KidCharacter : CharacterBase {
    CharacterState _current = CharacterState.Move;

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
        if (_input.Interact) {
            _current = _current == CharacterState.Move ? CharacterState.Interact : CharacterState.Move;
        }
    }

    // protected override void Move(Vector2 moveInput) {
    //     base.Move(moveInput);
    //     // Additional Move logic
    // }
}
