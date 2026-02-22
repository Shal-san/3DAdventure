using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBase : MonoBehaviour {
    protected CharacterController _controller;
    protected float _speed = 3f;
    protected float _gravity = -9.81f;
    protected float _velocityY = -2f;
    [SerializeField] Transform _camera;
    protected Vector2 _cameraForward;
    void Start() {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {
        _cameraForward = new Vector2(_camera.forward.x, _camera.forward.z).normalized;
    }

    public virtual void ControlUpdate(GameInput input) { }
}
