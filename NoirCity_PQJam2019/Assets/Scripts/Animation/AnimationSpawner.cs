using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationSpawner : MonoBehaviour
{
    public GameObject MainAnimation;
    [Range(1, 9)]
    public int Room = 1;

    public GameObject[] Rooms;
    public GameObject[] Animations;    

    void Start()
    {
        Prepare();
        //Position();
    }

    void Prepare()
    {
        //MainAnimation.tag = "Untagged";

        Rooms = GameObject.FindGameObjectsWithTag("Room").OrderBy(r => r.name).ToArray();
        Animations = GameObject.FindGameObjectsWithTag("AnimItem");

        var currentAnim = Animations[0];
        for (int i = 1; i < Animations.Length; i++)
        {
            currentAnim.GetComponent<IAnimationItem>().OnEnd += Animations[i].GetComponent<IAnimationItem>().Begin;
            currentAnim = Animations[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Position();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Execute();
        }
    }

    void Position()
    {
        var chosenRooms = new List<int>();
        chosenRooms.Add(Room-1);

        for (int i = 0; i < Animations.Length; i++)
        {
            var roomIndex = Random.Range(0, Rooms.Length - 1);

            while (chosenRooms.Contains(roomIndex))
            {
                roomIndex = Random.Range(0, Rooms.Length);                
            }
            
            chosenRooms.Add(roomIndex);
            Animations[i].transform.position = new Vector3(Rooms[roomIndex].transform.position.x, Rooms[roomIndex].transform.position.y + 1.0f, Rooms[roomIndex].transform.position.z);
            MainAnimation.transform.position = new Vector3(Rooms[Room - 1].transform.position.x, Rooms[Room - 1].transform.position.y + 1.0f, Rooms[Room - 1].transform.position.z);

            Animations[i].SetActive(false);
            MainAnimation.SetActive(false);
        }        

        Debug.Log(string.Join("-", chosenRooms));
    }

    void Execute()
    {
        Animations[0].GetComponent<IAnimationItem>().Begin();
    }

}
