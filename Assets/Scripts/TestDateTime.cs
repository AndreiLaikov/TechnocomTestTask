using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDateTime : MonoBehaviour
{
    [ContextMenu("GetTime")]
   public void GetDateTime()
    {
        var serverTime = WorldTime.GetWorldTime();
        DateTime localtime = DateTime.Now;
        Debug.Log("Server: "+serverTime.Date);
        Debug.Log("Local: "+localtime.Date);
    }
}
