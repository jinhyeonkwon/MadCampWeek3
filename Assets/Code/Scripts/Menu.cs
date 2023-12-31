using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI livesUI;
    [SerializeField] TextMeshProUGUI waveUI;
    [SerializeField] Animator anim;
    [SerializeField] int numOfWaves;
    private bool isMenuOpen = true;


    private void OnGUI() {
        currencyUI.text = "Money : " + LevelManager.main.currency.ToString();
        livesUI.text = "Lives : " + LevelManager.main.lives.ToString();
        waveUI.text = "Wave " + EnemySpawner.main.currentWave.ToString() + " / " + numOfWaves.ToString();
    }

    public void SetSelected() {

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }
}
