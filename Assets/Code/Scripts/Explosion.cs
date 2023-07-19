using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Explosion : MonoBehaviour
{

    // [Header("References")]
    // [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float explosionRange = 0.9f;
    
    // public Transform target;

    private void OnDrawGizmosSelected() {
        Handles.color= Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, explosionRange);
    }
    
    // private IEnumerator wait() {
    //     yield return new WaitForSeconds(0.5f);
    //     Destroy(gameObject, 0.5f);
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("폭발!");
        // RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRange, (Vector2) transform.position, 0f, enemyMask);
        // for (int i = 0; i < hits.Length; i++) {
        //     RaycastHit2D hit = hits[i];
        //     Health h = hit.transform.GetComponent<Health>();
        //     h.TakeDamage(bulletDamage);
        // }
        //StartCoroutine(wait());
        Destroy(gameObject, 0.5f);
    }


}