using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int baseDamage = 10;
    public int BaseDamage { get { return baseDamage; } set { baseDamage = value; } }
    public Vector2 knockback = Vector2.zero;

    Collider2D hitCollider;

    private void Awake()
    {
        hitCollider = GetComponent<Collider2D>();
        hitCollider.enabled = false;
    }

    private void Start()
    {
        //stop any potenetial errors of setting a collider to be on from unity console
        hitCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageableObject damageable = collision.GetComponent<DamageableObject>();
        Debug.LogError(name + "'attacked dealt: "+BaseDamage);

        if (damageable != null)
        {
            // Can hit and deal damage so deal damage
            int adjustedDamage = Mathf.RoundToInt(BaseDamage);

            // Flip knockback depending on hit direction with the usage of game objects knock back
            // was gona be implemented for walking golem but due to it braking not used  as drone doing knock back is annoying
            Vector2 directionToTarget = (collision.transform.position - transform.position).normalized;
            float xSign = Mathf.Sign(directionToTarget.x);
            Vector2 finalKnockback = new Vector2(knockback.x * xSign, knockback.y);

            damageable.Hit(adjustedDamage, finalKnockback);
        }
    }
}
