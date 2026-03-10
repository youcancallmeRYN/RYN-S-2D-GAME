using UnityEngine;

 
public class PlayerAttack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    private bool isGrounded;
    private Rigidbody2D rb;
    [SerializeField] float damage = 8f;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //Attack cooldown
      if(Input.GetButtonDown("AttackP1") && isGrounded)
      {
        Collider2D[] playersToDamage = Physics2D.OverlapCollider(attackPos, attackRange , whatIsPlayers);
        for (int i = 0; i < playersToDamage.Length; i++)
        {
            playersToDamage[i].GetComponent<Rigidbody2D>().ApplyDamage(damage);
        }
      }
      timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

       
      if(_animator)
      {
        _animator.SetBool("isGrounded", isGrounded);
      }
    }

     

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attackRange);

    }
}
