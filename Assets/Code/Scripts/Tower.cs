using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class Tower
{
    public string towerName;
    public int cost;
    public GameObject prefab;
    public float targetingRange;

    public Tower(string _towerName, int _cost, GameObject _prefab, float _targetingRange)
    {
        towerName = _towerName;
        cost = _cost;
        prefab = _prefab;
        targetingRange = _targetingRange;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
