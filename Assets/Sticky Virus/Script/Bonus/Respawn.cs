using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static bool IsPlaying = true;

    public GameObject virus;

    public void OnDestroy()
    {
        if (Respawn.IsPlaying)
        {
            Instantiate(virus, Vector2.zero, Quaternion.identity);
        }
    }
}
