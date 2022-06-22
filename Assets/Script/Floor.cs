using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject[] floor;

    // Update is called once per frame
    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);

        for (int i = 0; i < floor.Length; i++)
        {
            var floorPos = Camera.main.WorldToScreenPoint(floor[i].transform.position);
            if (floorPos.y < -4)
            {
                floor[i].SetActive(false);
            }
        }
    }

    public void Return()
    {
        for (int i = 0; i < floor.Length; i++)
        {
            floor[i].SetActive(true);
        }

    }
}
