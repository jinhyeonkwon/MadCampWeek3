using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] private int power = 5;

    private Transform target;
    private int pathIndex = 0;

    private float baseSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(Vector2.Distance(target.position, transform.position));
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.main.DecreaseLives(power);
                PlayerStats.Instance.UpdateHealth(LevelManager.main.lives / 10f);
                Destroy(gameObject);
                return;
            } else {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate() {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float speedFactor) {
        moveSpeed = baseSpeed * speedFactor;
    }

    public void ResetSpeed() {
        moveSpeed = baseSpeed;
    }
}
