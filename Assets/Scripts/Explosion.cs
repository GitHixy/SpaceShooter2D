using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 1f; // Time before the explosion is destroyed

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
