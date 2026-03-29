using UnityEngine;

public struct PlayerInputValues {
    public Vector2 Move;
    public bool Interact;
    public Vector2 Look;
}

public struct UIInputValues {
    // public Vector2 Navigate;
    public bool Submit;
    public bool Cancel;
}

public enum ActionMap {
    Player,
    UI
}

public class GameInputManager : MonoBehaviour {
    // use singleton pattern?

    static GameInput GameInput;
    public static PlayerInputValues PlayerInput { get; private set; }
    public static UIInputValues UIInput { get; private set; }

    void Awake() {
        GameInput ??= new GameInput();
    }

    void OnEnable() => GameInput.Enable();
    void OnDisable() => GameInput.Disable();

    public static void ChangeActionMap(ActionMap action) {
        GameInput.Disable();
        GameInput.asset.FindActionMap(action.ToString()).Enable();
    }

    public static void ReadValues() {
        ReadPlayerValues();
    }

    static void ReadPlayerValues() {
        PlayerInput = new PlayerInputValues {
            Move = GameInput.Player.Move.ReadValue<Vector2>(),
            Interact = GameInput.Player.Interact.WasReleasedThisFrame(),
            Look = GameInput.Player.Look.ReadValue<Vector2>()
        };
    }

    static void ReadUIValues() {
        UIInput = new UIInputValues {
            // Navigate = GameInput.UI.Navigate.ReadValue<Vector2>(),
            Submit = GameInput.UI.Submit.WasReleasedThisFrame(),
            Cancel = GameInput.UI.Cancel.WasReleasedThisFrame()
        };
    }
}
