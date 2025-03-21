

using UnityEngine;

public class GameManager: MonoBehaviour {

public GameObject player1;

public GameObject player2;

public int PiLife;

public int P2Life;

public GameObject gameOver;


// Use this for initialization

void Start () {

// Update is called once per frane
}
 void Update () {

if (PiLife <= 0){
     player1.SetActive (false);
     gameOver.SetActive(true);
}

if (P2Life <= 0){
    player1. SetActive (false);
    gameOver.SetActive (true);
}
}
public void hurt(){
    PiLife -= 1;
    
}
}