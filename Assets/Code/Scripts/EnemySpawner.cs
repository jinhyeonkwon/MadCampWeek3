using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 이 스크립트 복제해서 맵별로 다르게 해 줘야 함!

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    //[SerializeField] private int baseEnemies = 8;
    //[SerializeField] private float enemiesPerSecond = 0.5f; // base 속도
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private int numOfWaves = 8;
    //[SerializeField] private float difficultyScalingFactor = 0.75f;
    //[SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("EnemySettings")]
    [SerializeField] private int[] weakPonixNum = {5, 4, 0, 0, 0, 0, 0, 0};
    [SerializeField] private int[] ponixNum = {3, 5, 5, 4, 0, 0, 0, 0};
    [SerializeField] private int[] tankPonixNum = {0, 0, 5, 4, 6, 4, 5, 0};
    [SerializeField] private int[] fastPonixNum = {0, 0, 0, 4, 6, 5, 5, 0};
    [SerializeField] private int[] doublePonixNum = {0, 0, 0, 0, 3, 5, 5, 0};
    [SerializeField] private int[] jangNum = {0, 0, 0, 0, 0, 2, 4, 0};
    [SerializeField] private int[] leeNum = {0, 0, 0, 0, 0, 0, 0, 1};
    [SerializeField] private float[] epsArray = {0.6f, 0.8f, 1f, 1.2f, 1.5f, 2f, 2.5f, 3f}; // 이 숫자의 역수에 몬스터 속도만큼을 곱한 시간을 기다려서 스폰

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int numOfEnemies = 7; // 커스터마이징 실패로 전체 enemy 종류 수를 사용함.
    private int currentWave = 0;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int[] enemiesLeftToSpawnArray = new int[7]; // 모든 적이 다 나오면 7종류이기 때문.
    private int enemiesLeftToSpawn = 0;
    private bool isSpawning = false;
    private float eps; // Enemies per second

    private int currentEnemy; // 몇 번째 적 스폰 중?
    private int currentCnt;

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
        if (currentWave > numOfWaves) {
            Debug.Log("Last Wave Ended!");
            yield break;
        }
        currentEnemy = 0;
        currentCnt = 0;
        isSpawning = true;
        enemiesLeftToSpawnArray[0] = weakPonixNum[currentWave - 1];
        enemiesLeftToSpawnArray[1] = ponixNum[currentWave - 1];
        enemiesLeftToSpawnArray[2] = tankPonixNum[currentWave - 1];
        enemiesLeftToSpawnArray[3] = fastPonixNum[currentWave - 1];
        enemiesLeftToSpawnArray[4] = doublePonixNum[currentWave - 1];
        enemiesLeftToSpawnArray[5] = jangNum[currentWave - 1];
        enemiesLeftToSpawnArray[6] = leeNum[currentWave - 1];
        enemiesLeftToSpawn = 0;
        for (int i = 0; i < numOfEnemies; i++) {
            enemiesLeftToSpawn += enemiesLeftToSpawnArray[i];
        }
        eps = EnemiesPerSecond();
    }

    private void EndWave() {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(startWave());
    }

    // private int EnemiesPerWave() {
    //     return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor ));
    // }

    private float EnemiesPerSecond() {
        return epsArray[currentWave - 1] * enemyPrefabs[currentEnemy].GetComponent<EnemyMovement>().moveSpeed;
    }

    private void SpawnEnemy() {
        if (enemiesLeftToSpawn == 0) return;
        while (enemiesLeftToSpawnArray[currentEnemy] == 0) {
            currentEnemy++;
            eps = EnemiesPerSecond();
            currentCnt = 0;
            if (currentEnemy == numOfEnemies) {
                return;
            }
        }
        if (currentCnt >= enemiesLeftToSpawnArray[currentEnemy]) {
            currentEnemy++;
            eps = EnemiesPerSecond();
            currentCnt = 0;
        }
        GameObject prefabToSpawn = enemyPrefabs[currentEnemy];
        currentCnt++;
        Debug.Log(currentEnemy + " " + currentCnt + " th Monster Spawned");
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
