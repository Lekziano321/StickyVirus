using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    public Transform shotPos;

    public GameObject projectile;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    private void Update()
    {
        if (timeBtwShoot <= 0)
        {
            Instantiate(projectile, shotPos.position, Quaternion.identity);
            timeBtwShoot = startTimeBtwShoot;
        }
        else
        {
            timeBtwShoot -= Time.deltaTime;
        }
    }
}