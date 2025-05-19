using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private float horizontal, vertical;
    private Vector2 lookTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GetInstance().IsPlaying())
            return;
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lookTarget = Input.mousePosition;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetMouseButtonDown(0) && !player.HasBulletPickup()) // Referencing the left mouse button
        {
            player.Shoot();
        }
        
        if (player.HasBulletPickup())
        {
            if (Input.GetMouseButton(0))
            {
                player.Shoot();
            }
        }

        if (player.HasNuke())
        {
            if (Input.GetMouseButtonDown(1))
            {
                GameManager.GetInstance().deathSound.Play();
                foreach (GameObject go in enemy)
                {
                    Destroy(go);
                    GameManager.GetInstance().scoreManager.IncrementScore();
                }
                player.NukeDeduct();
            }
        }
      
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2(horizontal, vertical), lookTarget);
    }
}