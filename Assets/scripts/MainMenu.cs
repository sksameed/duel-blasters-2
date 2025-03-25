using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(4);
    }
    public void playgame2(){
        SceneManager.LoadSceneAsync(3);
    }
    public void back(){
        SceneManager.LoadSceneAsync(0);
    }
}
