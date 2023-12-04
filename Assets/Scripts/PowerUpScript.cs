using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float speedAmount = 5;
    public AudioClip speedClip;
    public ParticleSystem speedCollect;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.speed = speedAmount; 
            Destroy(gameObject);
            Instantiate(speedCollect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

            controller.PlaySound(speedClip);
        }

    }
}
