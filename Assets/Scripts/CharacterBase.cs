using UnityEngine;

[RequireComponent(typeof(CharacterController))]
abstract public class CharacterBase : MonoBehaviour {
    protected CharacterController _controller;
    protected float _speed = 3f;
    protected float _gravity = -9.81f;
    protected float _velocityY = -2f;
    [SerializeField] Transform _camera;
    protected Vector2 _cameraForward;
    protected enum CharacterState { Move, Interact }
    protected InputValues _input;

    void Start() {
        _controller = GetComponent<CharacterController>();
    }

    // void Update() {
    //     if (ai_control) {
    //         AIUpdate();
    //     }
    // }

    public void ControlUpdate(InputValues input) {
        _input = input;
        CharacterUpdate();
    }

    // void AIUpdate() {
    //     // AI logic to set _input values
    //     CharacterUpdate();
    // }

    public virtual void CharacterUpdate() {
        _cameraForward = new Vector2(_camera.forward.x, _camera.forward.z).normalized;
    }

    protected virtual void Move() {
        Vector2 move2d = _cameraForward * _input.Move.y + new Vector2(_cameraForward.y, -_cameraForward.x) * _input.Move.x;
        Vector3 move = new Vector3(move2d.x, 0, move2d.y).normalized * _speed;
        if (move2d.magnitude > 0.1f) transform.rotation = Quaternion.LookRotation(move);

        if (_controller.isGrounded) {
            _velocityY = -2f;
        }
        _velocityY += _gravity * Time.deltaTime;
        move.y = _velocityY;
        _controller.Move(move * Time.deltaTime);
    }

    protected virtual void Interact() {
        // Interaction logic
    }
}
