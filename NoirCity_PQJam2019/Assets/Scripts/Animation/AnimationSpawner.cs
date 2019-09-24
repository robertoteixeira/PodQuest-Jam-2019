using UnityEngine;

public class AnimationSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] animations;    
   
    void Start()
    {
        Prepare();
    }

    void Prepare()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        animations = GameObject.FindGameObjectsWithTag("AnimItem");

        var currentAnim = animations[0];
        for (int i = 1; i < animations.Length; i++)
        {
            currentAnim.GetComponent<IAnimationItem>().OnEnd += animations[i].GetComponent<IAnimationItem>().Begin;
            currentAnim = animations[i];
        }
    }

    void Position()
    {

    }

    void Execute()
    {
        animations[0].GetComponent<AnimationItem>().Begin();
    }

}
