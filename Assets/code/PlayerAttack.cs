using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool ApplyDamage(float amount);
        Debug.Log("Hit!");
    }
}
