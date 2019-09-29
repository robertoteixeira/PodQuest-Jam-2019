using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Player vision. Get a list of visibleNPCs so ReactionController can trigger it's events. Also get the current targetted npc.
/// </summary>
public class PlayerVision : MonoBehaviour
{

    public string[] targetableTags;

    GameObject entityTargeted;
    public List<GameObject> visibleNPCs = new List<GameObject>();
    private Plane[] planes;
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        visibleNPCs = GetVisibleList(targetableTags);
        if (visibleNPCs.Count > 0)
        {

            foreach (GameObject i in visibleNPCs)
            {
                Bounds bounds = i.GetComponent<Renderer>().bounds;
                if (bounds.IntersectRay(ray))
                {
                    entityTargeted = i;
                    break;
                }
                else
                {
                    entityTargeted = null;
                }
            }
            PlayerVisionManager.Instance.currentTargeted = entityTargeted;
        }


    }

    List<GameObject> GetVisibleList(string[] searchTags)
    {
        List<GameObject> bufferList = new List<GameObject>();
        foreach (string i in searchTags)
        {
            bufferList.AddRange(GetVisibleList(i));
        }
        return bufferList;
    }

    List<GameObject> GetVisibleList(List<string> searchTags)
    {
        List<GameObject> bufferList = new List<GameObject>();
        foreach (string i in searchTags)
        {
            bufferList.AddRange(GetVisibleList(i));
        }
        return bufferList;
    }

    public List<GameObject> GetVisibleList(string searchTag)
    {
        List<GameObject> bufferList = new List<GameObject>();
        planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());

        foreach (GameObject i in GameObject.FindGameObjectsWithTag(searchTag))
        {
            var renderer = i.GetComponent<Renderer>();
            if (renderer != null)
                if (GeometryUtility.TestPlanesAABB(planes, i.GetComponent<Renderer>().bounds))
                    bufferList.Add(i);
        }
        return bufferList;
    }
}
