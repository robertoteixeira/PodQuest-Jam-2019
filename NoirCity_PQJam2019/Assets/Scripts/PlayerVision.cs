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

    Ray ray;
    RaycastHit hit;

    GameObject entityTargeted;
    public List<GameObject> visibleNPCs = new List<GameObject>();
    private Plane[] planes;

    // Update is called once per frame
    void Update()
    {

        visibleNPCs = GetVisibleList(targetableTags);
        if (visibleNPCs.Count > 0)
        {

            foreach (GameObject i in visibleNPCs)
            {
                Vector3 objPos = i.transform.Find("Center").position;
                objPos = Camera.main.WorldToScreenPoint(objPos);
                Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, objPos.z);
                //NGUIDebug.Log(Vector3.Distance(centerOfScreen,objPos));
            }
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (visibleNPCs.Find(e => e.tag == hit.collider.tag))
            {
                if (entityTargeted != hit.collider.gameObject)
                {
                    entityTargeted = hit.collider.gameObject;

                }
            }
            else
            {
                entityTargeted = null;
            }
        }
        else
        {
            entityTargeted = null;
        }
        PlayerVisionManager.Instance.currentTargeted = entityTargeted;
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

    List<GameObject> GetVisibleList(string searchTag)
    {
        List<GameObject> bufferList = new List<GameObject>();
        planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());

        foreach (GameObject i in GameObject.FindGameObjectsWithTag(searchTag))
        {
            if (GeometryUtility.TestPlanesAABB(planes, i.GetComponent<Collider>().bounds))
                bufferList.Add(i);
        }
        return bufferList;
    }

    //	bool IsInTagList(string targetTag)
    //	{
    //		bool isInList = false;
    //		foreach (string i in targetableTags)
    //		{
    //			if(i == targetTag)
    //			{
    //				isInList = true;
    //				break;
    //			}
    //		}
    //		return isInList;
    //	}
}
