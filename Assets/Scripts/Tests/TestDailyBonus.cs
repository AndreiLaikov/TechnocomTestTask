using System;
using System.Globalization;
using System.Net;
using UnityEngine;

public class TestDailyBonus : MonoBehaviour
{
    private DateTime GetWorldTime()
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
            return DateTime.Now;//todo change to show pop-up "No internet" or don't show DailyBonus View
        }

    }

    [ContextMenu("NextDay")]
    private void MinusDays()
    {
        var now = GetWorldTime().AddDays(-1);
        PlayerPrefs.SetString("LastDayPlayed", now.ToString());
        PlayerPrefs.Save();
    }
}
