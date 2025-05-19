using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;

    [SerializeField] private Camera cam;
    [SerializeField] private float speed;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int nukeCount;
    [SerializeField] private bool hasNuke;
    private bool hasBulletPickup;
    private float timer;
    private UIManager manager;
    private AudioSource shotFired;

    public Action OnDeath; 

    private Rigidbody2D playerRb;

    private void Awake()
    {
       health = new Health(100, 0.5f, 50);
       playerRb = GetComponent<Rigidbody2D>();

       shotFired = GetComponent<AudioSource>();
       
       cam = Camera.main;

       weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);
       manager = FindAnyObjectByType<UIManager>();

    }

    private void Update()
    {
        health.RegenHealth();
 
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            hasBulletPickup = false;
            manager.SpreeOff();
        }
        if (nukeCount >= 3)
        {
            nukeCount = 3;
        }
        if (nukeCount <= 0)
        {
            nukeCount = 0;
            hasNuke = false;
        }
    }

    public int NukeCount()
    {
        return nukeCount;
    }
    public void NukeCounter()
    {
        nukeCount++;
        if (nukeCount > 0)
        {
            hasNuke = true;
            Debug.Log("Has nuke!");
        }
    }
    public void NukeDeduct()
    {
        nukeCount--;
        StartCoroutine(NukeColour());
    }

    IEnumerator NukeColour()
    {
        cam.backgroundColor = new Color(0.25f, 0, 0, 1);
        yield return new WaitForSeconds(1.5f);
        cam.backgroundColor = Color.black;
        StopCoroutine(NukeColour());
    }
    public bool HasNuke()
    {
        return hasNuke;
    }

    public void BulletPickup()
    {
        hasBulletPickup = true;
        timer = 3f;
        
    }
    public bool HasBulletPickup()
    {
        return hasBulletPickup;
    }
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRb.linearVelocity = direction * speed * Time.deltaTime;

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public override void Shoot()
    {
        Debug.Log("Shooting");
        weapon.Shoot(bulletPrefab, this, "Enemy"); 
        shotFired.Play();
    }

    public override void Attack(float interval)
    {
        Debug.Log($"Player attacking at {interval}");
    }

    public override void Die()
    {
        Debug.Log("Player dead");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
    public override void GetDamage(float damage)
    {
        Debug.Log($"Player getting damaged {damage} damage");  
        health.DeductHealth(damage);

        if (health.GetHealth() <= 0)
            Die();
    }
}
