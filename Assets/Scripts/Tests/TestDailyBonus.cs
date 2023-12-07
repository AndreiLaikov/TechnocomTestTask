using System;
using System.Globalization;
using System.Net;
using TechnoApp;
using UnityEngine;

public class TestDailyBonus : MonoBehaviour
{
    public int minusDays = -1;
    public int daysInRow;

    [ContextMenu("MinusDays")]
    private void MinusDays()
    {
        var now = GetWorldTime().AddDays(minusDays);
        PlayerPrefs.SetString("LastDayPlayed", now.ToString());
    }

    [ContextMenu("SetDaysInRow")]
    private void SetDaysInRow()
    {
        PlayerPrefs.SetInt("DaysInRow", daysInRow);
    }

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

    [ContextMenu("ReadPrefs")]
    private void Read()
    {
        Debug.Log("daysInRow " + PlayerPrefs.GetInt("DaysInRow"));

    }
}
