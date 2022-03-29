using UnityEngine;

public class DamageDiller : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damageable") 
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        if(gameObject.tag =="Bullet")
            Destroy(gameObject);
    }
}
