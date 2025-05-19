using UnityEngine;

public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health health = new Health();
    public Weapon weapon;
    public abstract void Move(Vector2 direction, Vector2 target);

    //Create two Move methods


    public virtual void Move(Vector2 direction)
    {

    }

    public virtual void Move(float speed)
    {
        
    }

    /// <summary>
    /// Abstract void holding reference to shoot
    /// </summary>
    public abstract void Shoot();

    public abstract void Attack(float interval);

    public abstract void Die();

    public abstract void GetDamage(float damage);
    
}
