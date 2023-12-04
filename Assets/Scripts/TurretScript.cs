using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectiles : MonoBehaviour
{

	public int numberOfProjectiles;

	public GameObject projectile;

	Vector2 startPoint;

	AudioSource audioSource;

	public AudioClip shootSound;

	float radius, moveSpeed;
	float timer;
	public float fireRate = 3.0f; //Smaller Number = faster fire rate

	// Use this for initialization
	void Start()
	{
		startPoint = new Vector2(6f, -4f); //Not good I know
		radius = 5f;
		moveSpeed = 5f;
		timer = fireRate;
		audioSource = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			SpawnProjectiles(numberOfProjectiles);
			timer = fireRate;
			PlaySound(shootSound);
		}
	}

	void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++)
		{

			float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate(projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D>().velocity =
				new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
	}

	public void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}

}