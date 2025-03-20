using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class SnowBall: MonoBehaviour {

public float ballSpeed ;

private Rigidbody2D theRD;

public GameObject snowBalleffect;

// Use this for initialization

void Start () {

theRD = GetComponent<Rigidbody2D>();

// Update is called once per frame
}
void Update () {

theRD.velocity = new Vector2(ballSpeed * transform.localScale.x,0);

}
void OnTriggerEnter2D (Collider2D other){
    Instantiate(snowBalleffect,transform.position,transform.rotation);
     Destroy(gameObject);
}

}