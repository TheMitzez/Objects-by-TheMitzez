using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime;
    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 0;

    private float timer = 0;

    private float setSpeed = 0;

    protected override void Start()
    {
        base.Start();
        health =  new Health(1, 0, 1);
        setSpeed = speed;
        weapon = new Weapon("Melee weapon", weaponDamage, bulletSpeed);
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
            Debug.Log($"Melee enemy damage ; {weapon.GetDamage()}");
        }
    }

    public void SetMeleeEnemy(float attackRange, float attackTime)
    {
        this.attackRange = attackRange;
        this.attackTime = attackTime;
    }
}
