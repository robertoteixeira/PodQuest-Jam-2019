using System.Collections.Generic;
using UnityEngine;

public class AnimationSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] animations;

    private Dictionary<GameObject, AnimationItem> _animationItems;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room"); 
        animations = GameObject.FindGameObjectsWithTag("AnimItem");                

        var currentAnim = animations[0];
        for (int i = 1; i < animations.Length; i++)
        {
            currentAnim.GetComponent<AnimationItem>().OnEnd += animations[i].GetComponent<AnimationItem>().Begin;
            currentAnim = animations[i];
        }

        animations[0].GetComponent<AnimationItem>().Begin();
    }

}
