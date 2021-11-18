using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Vector3 pos;
    public Quaternion rot;

    public Tracker(Vector3 pos, Quaternion rot)
    {
        this.pos = pos;
        this.rot = rot;
    }
    
    public List<Tracker> trackList = new List<Tracker>();

    void FixedUpdate()
    {
        UpdateTrackerList();
    }

    public void UpdateTrackerList()
    {
        trackList.Add(new Tracker(transform.position, transform.rotation));
    }

    public void ClearTrackerList()
    {
        trackList.Clear();
        trackList.Add(new Tracker(transform.position, transform.rotation));
    }
}
