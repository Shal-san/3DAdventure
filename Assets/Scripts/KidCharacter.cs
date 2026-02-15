using UnityEngine;

public class KidCharacter : CharacterBase
{

    public override void Update()
    {
        Move(moveInput);
    }

    protected override void Move(Vector2 input)
    {
        rb.AddForce(new Vector3(input.x, 0, input.y) * 5f);
    }
}
