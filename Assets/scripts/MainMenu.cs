using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }
    public void playgame2(){
        SceneManager.LoadSceneAsync(2);
    }
    public void back(){
        SceneManager.LoadSceneAsync(0);
    }
}
