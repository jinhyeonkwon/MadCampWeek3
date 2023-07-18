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

    public int currency;

    private void Awake(){
        main = this;
    }
    
    void Start()
    {
        currency = startCurrency;
    }

    public void IncreaseCurrency(int amount){
        currency += amount;
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
