using System;
using System.Globalization;
using System.Net;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public static DateTime GetWorldTime()
    {
        try
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }
        catch
        {
            Debug.LogWarning("No internet connection");
            return DateTime.Now;
        }
    }
}