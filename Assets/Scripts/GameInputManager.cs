using UnityEngine;

public class GameInputManager : MonoBehaviour {
    public static GameInput GameInput { get; private set; }
    void Awake() {
        GameInput ??= new GameInput();
    }

    void OnEnable() => GameInput.Enable();
    void OnDisable() => GameInput.Disable();
}
