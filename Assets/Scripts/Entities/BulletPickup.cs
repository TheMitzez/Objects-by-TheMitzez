using UnityEngine;

public class BulletPickup : Pickup, IDamageable
{

    public override void OnPicked()
    {
        base.OnPicked();

        var player = GameManager.GetInstance().GetPlayer();
        var UI = GameManager.GetInstance().GetUI();
        player.BulletPickup();
        UI.Spree();
        GameManager.GetInstance().spreeSound.Play();
    }
    public void GetDamage(float damage)
    {
        OnPicked();
    }
}
