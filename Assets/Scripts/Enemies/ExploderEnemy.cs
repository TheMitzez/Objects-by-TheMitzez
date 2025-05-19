using System.Collections;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime;
    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 0;


    private ParticleSystem explosion;

    private float timer = 0;

    private float setSpeed = 0;

    private GameManager gameManager;

    protected override void Start()
    {
        base.Start();
        explosion = GetComponent<ParticleSystem>();
        gameManager = GameManager.GetInstance();
        health = new Health(3, 0, 3);
        setSpeed = speed;
        weapon = new Weapon("Exploder weapon", weaponDamage, bulletSpeed);
    }

    protected override void Update()
    {
        base.Update();

        if ((target == null))
            return;

        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            speed = 0;
            Attack(attackTime);

        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
            gameManager.explosion.Play();
            gameManager.Explosion();
            Destroy(gameObject);

        }
    }


    public void SetExploderEnemy(float attackRange, float attackTime)
    {
        this.attackRange = attackRange;
        this.attackTime = attackTime;
    }
}
