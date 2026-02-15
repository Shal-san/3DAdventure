using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterBase character;
    void Start()
    {

    }

    void Update()
    {
        if (character != null)
        {
            character.Update();
        }
    }

    void OnMove(InputValue value)
    {
        if (character != null)
        {
            character.moveInput = value.Get<Vector2>();
        }
    }
}
