using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// chris tutorials inspired /edited code
public class Projectile : MonoBehaviour
{
    public int damage = 15;// base dmg
    public float speed = 10;// move speed
    public Vector2 knockback = Vector2.zero; // knock back set to zero

    public bool facesRight = true; // starts facing right

    Rigidbody2D rb;
    SpriteRenderer sprite;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();  
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError(name + " collison");
        DamageableObject damageable = collision.GetComponent<DamageableObject>();

        if (damageable) // checks if it can dmg smt
        {
            damageable.Hit(damage, knockback);

            // plays audio of hit
            if (audioSource)
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, audioSource.volume);

        }
        Destroy(gameObject); // destory projetice no matter what it colides with
    }

    // fires start moving the projectile
    public void Fire(Vector2 launchDirection)
    {
        rb.velocity = speed * launchDirection;

        if(launchDirection.x > 0) // if x>0 fire right spiret must be right...
        {
            sprite.flipX = !facesRight;
        } else //fire left... sprite must face left
        {
            sprite.flipX = facesRight;
        }
    }
}
