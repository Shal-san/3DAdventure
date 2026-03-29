using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] CharacterBase _character;

    void Start() {
        GameInputManager.ChangeActionMap(ActionMap.Player);
    }

    void Update() {
        if (_character != null) {
            GameInputManager.ReadValues();
            _character.ControlUpdate();
        }
    }
}
