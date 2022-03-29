using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP;

    public float currentHP;
    public bool isAlive;
    private void Awake()
    {
        isAlive = true;
        currentHP = maxHP;
    }
    public void TakeDamage(float damage) 
    {
        currentHP -= damage;
        CheckIsAlive();
        //if (!isAlive && gameObject.name != "Knight")
            //Destroy(gameObject);
    }
    public void CheckIsAlive() 
    {
        if (currentHP > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
            Kill();
        }
    }
    private void Kill() 
    {
        if(gameObject.name != "Knight")
            Destroy(gameObject);
    }
}
