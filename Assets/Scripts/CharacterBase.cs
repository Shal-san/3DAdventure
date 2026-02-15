using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected Rigidbody rb;
    public Vector2 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Update() { }

    protected virtual void Move(Vector2 input) { }
}
