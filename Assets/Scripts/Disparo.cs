using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
    }

    void Disparar()
    {
         if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(Bullet ,firePoint.position, firePoint.rotation);
            
        }
    }
}
