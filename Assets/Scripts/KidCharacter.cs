using UnityEngine;

public class KidCharacter : CharacterBase {
    public override void ControlUpdate(GameInput input) {
        Move(input.Player.Move.ReadValue<Vector2>());
    }

    void Move(Vector2 moveInput) {
        Vector2 move2d = _cameraForward * moveInput.y + new Vector2(_cameraForward.y, -_cameraForward.x) * moveInput.x;
        Vector3 move = new Vector3(move2d.x, 0, move2d.y).normalized * _speed;
        if (move2d.magnitude > 0.1f) transform.rotation = Quaternion.LookRotation(move);

        if (_controller.isGrounded) {
            _velocityY = -2f;
        }
        _velocityY += _gravity * Time.deltaTime;
        move.y = _velocityY;
        _controller.Move(move * Time.deltaTime);
    }
}
