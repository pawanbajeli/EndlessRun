using UnityEngine;
using System.Collections.Generic;

public class TrackPool : MonoBehaviour
{
    public GameObject[] trackpool;

    bool isroad01FirstTime = true;
    bool isroad02FirstTime = true;

    public static int track01;
    public static int track02;
    public static bool trig01=false;
    public static bool trig02=false;

    

    private void Update() 
    {

        if(track01==1&&isroad01FirstTime)
        {
            isroad01FirstTime=false;
        }
        
        if(track02==2&&isroad02FirstTime)
        {
            isroad02FirstTime=false;
        }


        if(!isroad01FirstTime && trig02)
        {
            trackpool[0].transform.position = trackpool[1].transform.position + new Vector3(0.0f, 0.0f, 29.6f); ;
            trig02 = false;
            //Debug.Log("Position of track1 is changed!");
        }
       else if (!isroad02FirstTime && trig01)
        {
            trackpool[1].transform.position = trackpool[0].transform.position + new Vector3(0.0f, 0.0f, 29.6f); ;
            trig01= false;
           // Debug.Log("Position of track2 is changed!");
        }

    }

}
