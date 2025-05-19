using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelLoader : MonoBehaviour
{
    public static int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Create a player object
        Player player = new Player();

        //Create two enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        //Create three weapons
        Weapon gun = new Weapon();
        //Weapon rifle = new Weapon("Rifle", 2.0f);
        Weapon machineGun = new Weapon();

        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;

        //Aggregation relationship
        player.weapon = gun;
        //enemy1.weapon = rifle;
        enemy2.weapon = machineGun;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
