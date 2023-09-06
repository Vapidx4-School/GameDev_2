using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public float FireButtonPressedTime = 0.0f;
    public float MaxTime = 3.0f;
    public GameObject bulletToSpawn;
    public GameObject bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //As long as fire 1 is pressed, add to the timer
        if (Input.GetButton("Fire1")){
            FireButtonPressedTime += Time.deltaTime;
        }
        // Once it is released, the spawned button forced is manipulated according to that time
        if (Input.GetButtonUp("Fire1")){
            float ratio = FireButtonPressedTime / MaxTime;
            ratio = Mathf.Clamp(ratio, 0.0f,1.0f);
            
            GameObject bullet = Instantiate(bulletToSpawn, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            BulletComponent bulletComponent = bullet.GetComponent<BulletComponent>();
            if(bulletComponent != null){
                bulletComponent.strengthRatio = ratio;
            }
        }
    }
}
