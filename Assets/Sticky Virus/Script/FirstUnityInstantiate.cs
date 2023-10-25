using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovements : MonoBehaviour
{
    public GameObject go;
    public GameObject clonePrefab; // Prefab untuk objek clone
    bool canplace;
    bool releasedbutton;
    Vector3 mousePos;

    List<GameObject> squares;
    int maxCloneCount = 2; // Batas jumlah clone yang dapat dibuat
    int currentCloneCount = 0; // Jumlah clone saat ini

    // Start is called before the first frame update
    void Start()
    {
        squares = new List<GameObject>();
        releasedbutton = true;
        canplace = false;
    }

    private void Update()
    {
        mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            releasedbutton = false;
            canplace = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            releasedbutton = true;
            canplace = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject square in squares)
            {
                BoxCollider2D col = square.GetComponent<BoxCollider2D>();
                if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10))))
                {
                    squares.Remove(square);
                    DestroyImmediate(square);
                    break; // Keluar dari loop setelah menghapus clone
                }
            }
        }

        if (releasedbutton == false && canplace && currentCloneCount < maxCloneCount)
        {
            GameObject tmpObj = Instantiate(go);
            squares.Add(tmpObj);
            tmpObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            canplace = false;
            currentCloneCount++;
        }
    }

    public void DestroyObject(GameObject objectToDestroy)
    {
        squares.Remove(objectToDestroy);
        Destroy(objectToDestroy);

        // Kloning objek setelah menghancurkan objek
        if (currentCloneCount < maxCloneCount)
        {
            GameObject cloneObj = Instantiate(clonePrefab);
            squares.Add(cloneObj);
            cloneObj.transform.position = objectToDestroy.transform.position;
            currentCloneCount++;
        }
    }
}
