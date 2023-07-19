using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{ 
    public void SceneChangeD1(){
        Debug.Log("123123");
        SceneManager.LoadScene("DotmapScene1");
    }
    public void SceneChangeD2(){
        Debug.Log("123123");
        SceneManager.LoadScene("DotmapScene2");
    }
    public void SceneChangeK(){
        Debug.Log("123123");
        SceneManager.LoadScene("SampleScene");
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
