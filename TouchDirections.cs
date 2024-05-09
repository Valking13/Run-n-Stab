using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// chris tutorials inspired 

[RequireComponent(typeof(Collider2D), typeof(Animator))]
public class TouchDirections : MonoBehaviour
{
    public ContactFilter2D touchFilter;
    public float groundDist = 0.05f;
    public float wallDist = 0.2f;
    public float ceilingDist = 0.05f;
    public Vector2 wallDirection = Vector2.zero;

    private RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private RaycastHit2D[] wallHits = new RaycastHit2D[5];
    private RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    private Animator animator;
    private CapsuleCollider2D col;

    [SerializeField] private bool onWall;
    public bool OnWall { get {return onWall;}
        set
        {
            onWall = value;
            animator.SetBool(AnimationStrings.onWall, value);
        }
    }

    [SerializeField] private bool hitCeiling;
    public bool HitCeiling { get { return hitCeiling; }
        set
        {
            hitCeiling = value;
            animator.SetBool(AnimationStrings.hitCeiling, value);
        }
    }

    [SerializeField] private bool onGround;
    public bool OnGround
    {
        get { return onGround; }
        set
        {
            // if  value changed, interupt states so that correct animi plays
            if (onGround = true && value != true)
                animator.SetTrigger(AnimationStrings.ground_interrupt);
            else if (onGround = false && value != false)
                animator.SetTrigger(AnimationStrings.air_interrupt);

            onGround = value;
            animator.SetBool(AnimationStrings.onGround, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();
    }

    public void FixedUpdate()
    {
        OnGround = col.Cast(Vector2.down, touchFilter, groundHits,  groundDist) > 0;
        OnWall = col.Cast(wallDirection, touchFilter, wallHits, wallDist) > 0;
        HitCeiling = col.Cast(Vector2.up, touchFilter, ceilingHits, ceilingDist) > 0;
    }
}
