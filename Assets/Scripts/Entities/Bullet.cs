using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    protected string targetTag;

    public void SetBullet(float damage, string targetTag, float speed = 10)
    {
        this.damage = damage;
        this.speed = speed;
        this.targetTag = targetTag;
    }

    protected void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected virtual void Damage(IDamageable damageable)
    {
        if(damageable != null)
        {
            Debug.Log("Damage something!");
            damageable.GetDamage(damage);

            //Use our singleton from Game Manager to access the score manager
            //GameManager.GetInstance().scoreManager.IncrementScore();
            Destroy(gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        //Check for the target
        if(!other.gameObject.CompareTag(targetTag))
            return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
