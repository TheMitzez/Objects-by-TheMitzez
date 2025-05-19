using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    [SerializeField] private PickupSpawn[] pickups;
    [Range(0, 1)]
    [SerializeField] private float pickupProbability;
    private Player player;

    private List<Pickup> pickupPool = new List<Pickup>();
    Pickup chosenPickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(PickupSpawn spawn in pickups)
        {
            for (int i = 0; i < spawn.spawnAmount; i++)
            {
                pickupPool.Add(spawn.pickup);
            }
        }
    }

    private void Update()
    {
        player = GameManager.GetInstance().GetPlayer();
    }

    public void SpawnPickup(Vector2 spawnPos)
    {
        if(pickupPool.Count == 0) { return; }
        if(player.HasBulletPickup()) { return; } 

        if(Random.Range(0.0f, 1.0f) < pickupProbability)
        {
            chosenPickup = pickupPool[Random.Range(0, pickupPool.Count)];
            Instantiate(chosenPickup, spawnPos, Quaternion.identity);
        }
    }
}

[System.Serializable]
public struct PickupSpawn
{
    public Pickup pickup;
    public int spawnAmount;
}