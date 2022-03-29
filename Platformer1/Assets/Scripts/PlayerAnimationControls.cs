using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimationControls : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator anim;
    private Health _playerHealth;
    private PlayerMovement _playerMovement;
    private CanvasContoller _canvasContoller;
    [SerializeField] private GameObject canvas;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _playerHealth = GetComponent<Health>();
        _playerMovement = GetComponent<PlayerMovement>();
        _canvasContoller = canvas.GetComponent<CanvasContoller>();
    }

     private void Update()
     {
        if (Mathf.Abs(playerRB.velocity.y) > 0.001)
        {
            anim.SetBool("IsJumping", true);
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            if (Mathf.Abs(playerRB.velocity.x) > 0.001)
                anim.SetBool("IsRunning", true);
            else
                anim.SetBool("IsRunning", false);
        }
        if (!_playerHealth.isAlive && _playerMovement.isOnGround) 
            anim.SetBool("IsDead", true);
     }
     private void CallDeath() 
    {
        _canvasContoller.Death();
    }
}
