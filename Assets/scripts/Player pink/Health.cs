

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager: MonoBehaviour {

public GameObject player1;

public GameObject player2;

public int P1Life;

public int P2Life;

public GameObject gameOver;
public GameObject[] p1Sticks;
public GameObject[] p2Sticks;



// Use this for initialization

void Start () {

// Update is called once per frane
}
 void Update () {

if (P1Life <= 0){
     player1.SetActive (false);
     gameOver.SetActive(true);
}

if (P2Life <= 0){
    player2. SetActive (false);
    gameOver.SetActive (true);
}
}
public void hurt(){
    P1Life -= 1;
    for(int i=0;i < p1Sticks.Length; i++)
    {

if(P1Life > i){

p1Sticks[i].SetActive (true);
    }
    else {
        p1Sticks[i].SetActive (false);
    }
    
}

}
public void hurtb(){
    P2Life -= 1;
    for(int i=0;i < p2Sticks.Length; i++)
    {

if(P2Life > i){

p2Sticks[i].SetActive (true);
    }
    else {
        p2Sticks[i].SetActive (false);
    }
    
}

}
}