using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    [Header("Attributes")]
    [SerializeField] private int startCurrency = 300;
    [SerializeField] private int startLives = 50;

    public int currency;
    public int lives;

    private void Awake(){
        main = this;
    }
    
    void Start()
    {
        currency = startCurrency;
        lives = startLives;
    }

    public void IncreaseCurrency(int amount){
        currency += amount;
    }

    public void DecreaseLives(int damage){
        lives -= damage;
        if (lives <= 0) {
            Debug.Log("Game Over");
        }
    }

    public bool SpendCurency(int amount){
        if (amount <= currency) {
            currency -= amount;
            return true;
        } else {
            Debug.Log("You do not have ~~~~");
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
