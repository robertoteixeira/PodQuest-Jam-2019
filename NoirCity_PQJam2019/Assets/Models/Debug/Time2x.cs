using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time2x : MonoBehaviour
{
	public float speedX = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Time.timeScale = speedX;
	}
}
