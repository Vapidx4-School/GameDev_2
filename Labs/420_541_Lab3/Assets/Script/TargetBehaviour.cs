using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public ScoreManager scoreManager;
    public void Start() {
     //   scoreManager = FindFirstByObjectType<ScoreManager>();
    }
    void OnCollisionEnter(Collision other) {
        if(scoreManager != null){
            if (other.gameObject.tag == "Projectile")
            {
                scoreManager.IncrementScore();
                Invoke("UnhideTarget", 3.0f);
                gameObject.transform.parent.GetComponent<Renderer>().material.color = Color.red;
                gameObject.SetActive(false);
            }
        }
    }
    public void UnhideTargets(){
        gameObject.SetActive(true);
    }
}
