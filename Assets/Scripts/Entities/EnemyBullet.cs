using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            Debug.Log("Damage something!");
            damageable.GetDamage(damage);

            //Use our singleton from Game Manager to access the score manager
            Destroy(gameObject);
        }
    }
}
