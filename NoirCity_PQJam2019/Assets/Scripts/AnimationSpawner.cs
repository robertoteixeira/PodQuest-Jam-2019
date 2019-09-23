using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpawner : MonoBehaviour
{
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
