using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public void SetPosSun(int hour, int minute, int second, int longitude, int latitude)
    {
        float angle = CalculateAngle(hour, minute, second);
        float angleDay = CalculateDayLight(hour, minute, second);
        this.transform.rotation = Quaternion.Euler(angleDay, angle, 0f);
        this.transform.position = new Vector3(latitude, longitude, 0f);
    }

    private float CalculateDayLight(int hour, int minute, int second)
    {
        float angle = (((float)hour + ((float)minute / 60) + ((float)second / 3600)) / 12) * 90;
        Debug.Log("[CalculateDayLight]: " + angle);
        return angle;
    }

    private float CalculateAngle(int hour, int minute, int second)
    {
        float totalSeconds = hour * 3600f + minute * 60f + second;
        float normalizedTime = totalSeconds / 86400f;

        float angle = normalizedTime * 360f;
        return angle;
    }
}
