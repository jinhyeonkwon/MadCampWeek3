using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TurretSlomo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject iceEffect;

    [Header("Arrtibute")]
    [SerializeField] private float targetingRange = 2.5f;
    [SerializeField] private float aps = 0.25f; // Attacks per second
    [SerializeField] private float freezeTime = 1f;

    private float timeUntilFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmosSelected() {
        Handles.color= Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    // Update is called once per frame
    private void Update()
    {
        timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / aps) {
                FreezeEnemies();
                timeUntilFire = 0f;
            }
    }

    private void FreezeEnemies() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) transform.position, 0f, enemyMask);
        FreezeEffect();

        if (hits.Length > 0) {
            for (int i = 0; i < hits.Length; i++) {
                RaycastHit2D hit = hits[i];
                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(0.25f); // 나는 base에 이 factor를 곱하는 걸로 했음.
                StartCoroutine(ResetEnemySpeed(em));
            }
        }
    }

    private void FreezeEffect() {
        GameObject iceEffectObj = Instantiate(iceEffect, transform.position, Quaternion.identity);
        Destroy(iceEffectObj, freezeTime);
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em) {
        yield return new WaitForSeconds(freezeTime);
        em.ResetSpeed();
    }

    

}
