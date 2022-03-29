using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform firePoint;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    public void Shoot(float direction) 
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletRB2D = currentBullet.GetComponent<Rigidbody2D>();
        if (!_playerMovement.spriteRenderer.flipX)
        {
            firePoint.transform.position = new Vector2(transform.position.x + 0.14f, transform.position.y + 1);
            currentBulletRB2D.velocity = new Vector2(shootSpeed * 1, currentBulletRB2D.velocity.y);
        }
        else
        {
            firePoint.transform.position = new Vector2(transform.position.x - 0.14f, transform.position.y + 1);
            currentBulletRB2D.velocity = new Vector2(shootSpeed * -1, currentBulletRB2D.velocity.y);
        }
    }
}
