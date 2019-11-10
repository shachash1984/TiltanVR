using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public Transform barrel;
    public GameObject bulletPrefab;
    public float force = 10;
    public GameObject blast;

   

    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        blast.SetActive(false);
        blast.SetActive(true);
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody>().velocity = barrel.forward * force;
        Destroy(bullet, 5);
    }

    void PlaySound(LookAtHandler l, bool b)
    {
        if (b)
        {
            AudioSource a = GetComponent<AudioSource>();
            a.Play();
        }
            
      
    }
}
