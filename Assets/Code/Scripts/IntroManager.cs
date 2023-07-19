using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroManager : MonoBehaviour
{
    public void SceneChange(){
        Debug.Log("123123");
        SceneManager.LoadScene("SampleScene");
    }
}
