using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f; // base 속도
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 0;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private float eps; // Enemies per second

    private void EnemyDestroyed() {
        enemiesAlive--;
    }
    

    private void Awake() {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startWave());
    }

    private IEnumerator startWave() {
        yield return new WaitForSeconds(timeBetweenWaves);
        currentWave++;
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
    }

    private void EndWave() {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(startWave());
    }

    private int EnemiesPerWave() {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor ));
    }

    private float EnemiesPerSecond() {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0, enemiesPerSecondCap);
    }

    private void SpawnEnemy() {
        int index;
        if (currentWave == 1) {
            index = 0;
        } else if (currentWave <= 2) {
            index = Random.Range(0, 2);
        } else if (currentWave <= 3) {
            index = Random.Range(1, 3);
        } else {
            index = Random.Range(1, 4);
        }
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if ((timeSinceLastSpawn >= (1f / eps)) && (enemiesLeftToSpawn > 0)) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if ((enemiesLeftToSpawn == 0) && (enemiesAlive == 0)) {
            EndWave();
        }
    }
}
