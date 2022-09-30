using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private float x;
    private void LateUpdate()
    {
        x += Time.deltaTime * 20;
        transform.rotation = Quaternion.Euler(0, x, 0);
    }
}