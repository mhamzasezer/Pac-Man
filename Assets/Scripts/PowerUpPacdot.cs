using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPacdot : MonoBehaviour
{
    public bool isSpecialPacdot = false;
    public float speedBoostDuration = 4f;
    public float speedBoostAmount = 10f;

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            if (isSpecialPacdot)
            {
                PacmanMove pacmanMove = co.GetComponent<PacmanMove>();
                if (pacmanMove != null)
                {
                    pacmanMove.ApplySpeedBoost(speedBoostDuration, speedBoostAmount);
                }
            }

            Destroy(gameObject);
        }
    }
}