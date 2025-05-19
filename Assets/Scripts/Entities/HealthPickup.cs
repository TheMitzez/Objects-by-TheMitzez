using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{

    [SerializeField] private float healthMin, healthMax;

    public override void OnPicked()
    {
        base.OnPicked();

        //Generate a random health value and add it to the player
        float health = Random.Range(healthMin, healthMax);

        var player = GameManager.GetInstance().GetPlayer();
        player.health.AddHealth(health);

        Debug.Log($"Added {health} to {player.name}"); 
    }
    public void GetDamage(float damage)
    {
        OnPicked();
    }
}
