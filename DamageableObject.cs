using UnityEngine;
using UnityEngine.Events;
// chris tutorials edited script
// seperated out for as needed for all things 
// probs could be made into top of heriacy script that all players take
// i think is techinially a event script? 

public class DamageableObject : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;
    public UnityEvent<int, int> hpChange;

    [SerializeField]
    private int maxHP = 100; // hp = health points

    public int MaxHP{ get { return maxHP; } set { maxHP = value; } }

    [SerializeField]
    private int hp = 100;
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            hpChange?.Invoke(hp, MaxHP);
            if (hp <= 0)
                IsAlive = false;
        }
    }

    private bool isAlive = true;

    private bool IsAlive
    {
        get { return isAlive; }
        set
        {
            isAlive = value;
            animator.SetBool(param_isAlive, isAlive);
        }
    }

    [SerializeField]
    private float invincibilityTime = 0.25f;

    private float timeSinceHit = 0;
    private bool isInvincible = false;

    private string param_isAlive = "isAlive";

    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool(param_isAlive, IsAlive);
    }

    public void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                // can be hit again
                isInvincible = false;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public void Hit(int damage, Vector2 knockbackForce)
    {
        if (IsAlive && !isInvincible) // checks if it can take dmg
        {
      
            
            HP =HP- damage;

            Debug.Log(gameObject.name + " took " + damage); // debug check

            // lets other objects know object was hit
            CharacterEvents.characterHit?.Invoke(this, damage);

            // knockback component called of object
            damageableHit.Invoke(damage, knockbackForce);

            animator.SetBool(AnimationStrings.isHit, true);
            timeSinceHit = 0;
            isInvincible = true; // sets invicible time
        }
    }

    // hp state
    public void Heal(int healthReceived)
    {
        if(IsAlive) // needs to be alive
        {
            int amountCouldHeal = MaxHP - HP; // hp missing check

            // amount to restore comparint item healing hp and hp
            int healthRestored = Mathf.Min(healthReceived, amountCouldHeal); 

            HP += healthRestored; // hp

            CharacterEvents.characterHealed?.Invoke(this, healthRestored);
            // invokes healing char event
        }
    }
}
