using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float _distance = 10.0f;
    float _yaw = 0.0f;
    float _pitch = 30.0f;
    float _sensitivity = 0.3f;
    GameInput _input;
    [SerializeField] Transform _target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        transform.LookAt(_target);
        var rotation = Quaternion.Euler(_pitch, _yaw, 0);
        transform.position = rotation * new Vector3(0, 0, -_distance) + _target.position;

        _input = GameInputManager.GameInput;
        _input.Player.Enable();
    }

    // Update is called once per frame
    void Update() {
        var lookInput = _input.Player.Look.ReadValue<Vector2>() * _sensitivity;
        _yaw += lookInput.x;
        _pitch -= lookInput.y;

        _pitch = Mathf.Clamp(_pitch, -89.0f, 89.0f);
        var rotation = Quaternion.Euler(_pitch, _yaw, 0);
        transform.position = rotation * new Vector3(0, 0, -_distance) + _target.position;
        transform.LookAt(_target);
    }
}
