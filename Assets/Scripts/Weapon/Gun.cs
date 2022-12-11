using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunMuzzle;
    public Projectile bullet;

    private float fireRate; // ms
    private float enableFireTime;
    private float bulletSpeed;

    private AudioSource gunAudioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        gunAudioPlayer = GetComponent<AudioSource>();

        fireRate = 100.0f;
        enableFireTime = 0.0f;
        bulletSpeed = 200.0f;
    }

    public void Fire()
    {
        if(Time.time> enableFireTime)
        {
            enableFireTime = Time.time + fireRate / 1000;
            Projectile newBullet = Instantiate(bullet, gunMuzzle.position, gunMuzzle.rotation);
            newBullet.SetProjectileSpeed(bulletSpeed);

            StartCoroutine(ShotSound());
        }
    }

    private IEnumerator ShotSound()
    {
        gunAudioPlayer.Play();

        yield return null;
    }
}
