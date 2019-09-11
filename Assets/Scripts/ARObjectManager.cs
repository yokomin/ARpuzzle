using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    public GameObject[] StagesMarkers;

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (GameObject StageMarker in StagesMarkers)
        {
            StageMarker.transform.eulerAngles = new Vector3(270, 0, 0);
        }
    }
}
