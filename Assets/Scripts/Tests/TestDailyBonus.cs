using TechnoApp;
using UnityEngine;


public class TestDailyBonus : MonoBehaviour
{
    public int minusDays = -1;
    public int daysInRow;

    [ContextMenu("MinusDays")]
    private void MinusDays()
    {
        var now = WorldTime.Instance.GetWorldTime().AddDays(minusDays);
        PlayerPrefs.SetString(GameController.Instance.lastDayPlayed_key, now.ToString());
    }

    [ContextMenu("SetDaysInRow")]
    private void SetDaysInRow()
    {
        PlayerPrefs.SetInt(GameController.Instance.daysInRow_key, daysInRow);
    }
}
