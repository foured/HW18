using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [Header("Settings")]
    [SerializeField] private Transform legsColliderTransform;
    [SerializeField] private float jumpOffset;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D playerRB;
    public bool isOnGround = false;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Vector3 overlapsCirclePosition = legsColliderTransform.position;
        isOnGround = Physics2D.OverlapCircle(overlapsCirclePosition, jumpOffset, groundMask);
    }
    public void Move(float direction, bool isJump)
    {
        if (isJump)
            Jump();
        if (Mathf.Abs(direction) > 0.01f)
            HorizontalMovement(direction);
    }
    public void Jump() 
    {
        if(isOnGround)
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
    }
    public void HorizontalMovement(float movementDirection) 
    {
        playerRB.velocity = new Vector2(curve.Evaluate(movementDirection) * speed, playerRB.velocity.y);
        if (movementDirection > 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
