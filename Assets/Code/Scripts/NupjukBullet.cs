using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NupjukBullet : MonoBehaviour
{
    
    
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private float explosionRange = 0.7f;
    

    public Transform target;

    public void SetTarget(Transform _target) {
        target = _target;
    }

    private void OnDrawGizmosSelected() {
        Handles.color= Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, explosionRange);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;



    }
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject expl = Instantiate(explosion, transform.position + new Vector3(0, 0, -0.2f), Quaternion.identity) as GameObject;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRange, (Vector2) transform.position, 0f, enemyMask);
        for (int i = 0; i < hits.Length; i++) {
            RaycastHit2D hit = hits[i];
            Health h = hit.transform.GetComponent<Health>();
            h.TakeDamage(bulletDamage);
        }
        //expl.SendMessage("TheStart", 0);
        Destroy(gameObject);
    }
}
