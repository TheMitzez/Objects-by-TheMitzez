using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime;
    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private EnemyBullet shooterBulletPrefab;

    private float timer = 0;

    private float setSpeed = 0;

    private AudioSource shooterAudioSource;
    protected override void Start()
    {
        base.Start();
        health =  new Health(2, 0, 2);
        setSpeed = speed;
        weapon =  new Weapon("Shooter weapon", weaponDamage, bulletSpeed);
        shooterAudioSource = GetComponent<AudioSource>();
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

    public override void Shoot()
    {
        Debug.Log("Shooter shooting!");
        weapon.Shoot(shooterBulletPrefab, this, "Player");
        shooterAudioSource.Play();
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
            Shoot();
        }
    }
    public void SetShooterEnemy(float attackRange, float attackTime)
    {
        this.attackRange = attackRange;
        this.attackTime = attackTime;
    }
}
