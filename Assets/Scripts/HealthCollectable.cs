using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem healthCollect;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1); //Plus 1 HP
                Destroy(gameObject);
                Instantiate(healthCollect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                controller.PlaySound(collectedClip);
            }
        }

    }
}