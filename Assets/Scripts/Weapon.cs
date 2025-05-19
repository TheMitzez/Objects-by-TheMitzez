using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Weapon
{
    private string name;
    private float damage;
    private float bulletSpeed;



    public Weapon(string name, float damage, float bulletSpeed)
    {
        this.name = name;
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
    }

    public Weapon()
    {

    }
   
    public void Shoot(Bullet bullet, PlayableObject player, string targetTag, float timeToDie = 5)
    {
        Debug.Log($"Shooting from weapon");
        Bullet tempBullet = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        tempBullet.SetBullet(damage, targetTag, bulletSpeed);

        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }

    public float GetDamage()
    {
        return damage;
    }
}
