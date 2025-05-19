using UnityEngine;

public class NukePickup : Pickup, IDamageable
{
    public override void OnPicked()
    {
        base.OnPicked();

        var player = GameManager.GetInstance().GetPlayer();

        player.NukeCounter();
        player.HasNuke();
        Debug.Log("Nuke grabbed!");

    }

    public void GetDamage(float damage)
    {
        OnPicked();
    }
}
