using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRackRoad : MonoBehaviour
{
    public static int knowthetrack = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player" && this.gameObject.tag=="0")
        {
            TrackPool.track01 = 1;
            knowthetrack = 1;
        }
        else if(collision.gameObject.tag=="Player" && this.gameObject.tag=="1")
        {
            TrackPool.track02 = 2;
            knowthetrack = 2;
        }
    }
}
