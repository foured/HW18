using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Shooter _shooter;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        float horisontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
            _shooter.Shoot(horisontalDirection);
        _playerMovement.Move(horisontalDirection, isJumpButtonPressed);
    }
}
