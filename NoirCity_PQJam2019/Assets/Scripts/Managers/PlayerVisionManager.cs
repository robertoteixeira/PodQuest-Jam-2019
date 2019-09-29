using UnityEngine;
using System.Collections;

public class PlayerVisionManager : Singleton<PlayerVisionManager>
{

    protected PlayerVisionManager() { }

    public GameObject currentTargeted = null;

}
