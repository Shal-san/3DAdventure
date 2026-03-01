using UnityEngine;

public struct InputValues {
    public Vector2 Move;
    public bool Interact;
}

public class GameInputManager : MonoBehaviour {
    public static GameInput GameInput { get; private set; }
    void Awake() {
        GameInput ??= new GameInput();
    }

    void OnEnable() => GameInput.Enable();
    void OnDisable() => GameInput.Disable();

    public static InputValues ReadValues(GameInput input) {
        return new InputValues {
            Move = input.Player.Move.ReadValue<Vector2>(),
            Interact = input.Player.Interact.WasReleasedThisFrame()
        };
    }
}
