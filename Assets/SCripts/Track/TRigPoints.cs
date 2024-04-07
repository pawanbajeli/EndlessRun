using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRigPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.tag=="Player"&& this.gameObject.tag=="trig01")
        {   
            TrackPool.trig01 = true;
            Debug.Log("trig01 is acitvated");
        }


        if (other.gameObject.tag == "Player" && this.gameObject.tag == "trig02")
        {
            TrackPool.trig02 = true;
            Debug.Log("trig02 is acitvated1");
        }
    }
}
