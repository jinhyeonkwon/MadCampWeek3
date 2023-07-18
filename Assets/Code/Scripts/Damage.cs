using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int power = 5;

    private bool isDamaged = false;

    public void TakeDamage(int dmg) {
        if (!isDamaged) {
            LevelManager.main.DecreaseLives(power);
            isDamaged = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
