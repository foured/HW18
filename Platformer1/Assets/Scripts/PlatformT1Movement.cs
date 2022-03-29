using UnityEngine;
[RequireComponent(typeof(SliderJoint2D))]
public class PlatformT1Movement : MonoBehaviour
{
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    private SliderJoint2D sliderJoint2D;
    private SpriteRenderer spriteRenderer2D;
    [SerializeField, Range(-10, 10)] private int speed;
    [SerializeField] private bool enableReversal;
    private void Start()
    {
        spriteRenderer2D = GetComponent<SpriteRenderer>();
        sliderJoint2D = GetComponent<SliderJoint2D>();
        JointMotor2D motor = sliderJoint2D.motor;
        motor.motorSpeed = speed;
        sliderJoint2D.motor = motor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject == target1)|| (collision.gameObject == target2)) 
        {
            if(enableReversal == true) 
            {
                if (spriteRenderer2D.flipX == false)
                    spriteRenderer2D.flipX = true;
                else
                    spriteRenderer2D.flipX = false;
            }
            speed = speed * -1;
            JointMotor2D motor = sliderJoint2D.motor;
            motor.motorSpeed = speed;
            sliderJoint2D.motor = motor;
        }
    }
}
