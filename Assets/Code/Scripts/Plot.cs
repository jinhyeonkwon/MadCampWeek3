using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private void OnMouseExit() {
        sr.color = startColor;
    }
    
    private void OnMouseDown() {
        Debug.Log("Build Tower Here : " + name);

        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if (towerToBuild.cost > LevelManager.main.currency) {
            Debug.Log("You can't afford this tower");
            return;
        }
        if (tower != null) {
            Destroy(tower);
        };
        LevelManager.main.SpendCurency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        startColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
