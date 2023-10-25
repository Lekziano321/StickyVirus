using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private GameObject[] virus;

    private Vector2 target;

    public float speed;

    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        virus = GameObject.FindGameObjectsWithTag("Virus");

        int rand = Random.Range(0, virus.Length);
        target = virus[rand].transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Virus"))
        {
            gm.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
