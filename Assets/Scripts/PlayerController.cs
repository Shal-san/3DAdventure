using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] CharacterBase _character;
    GameInput _input;
    void Start() {
        _input = GameInputManager.GameInput;
        _input.Player.Enable();
    }

    void Update() {
        if (_character != null) {
            _character.ControlUpdate(_input);
        }
    }
}
