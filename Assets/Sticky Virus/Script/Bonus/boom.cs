using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public GameObject SmashEffect;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(SmashEffect, transform.position, Quaternion.identity);
    }
}
