using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class formInput : MonoBehaviour
{
    private string textLongitude = null;//kinh
    private string textLatitude = null;//vi
    private DateTime parsedTime;

    private string desiredFormatLongitude = "^[0-9]+[EW]$";
    private string desiredFormatLatitude = "^([0-9]|[1-8][0-9]|90)[NS]$";

    public void OnInputLongitude(InputField inputLongitude)
    {
        Debug.Log("[OnInputLongitude]: " + inputLongitude.text);
        bool isValid = CheckTextFormat(inputLongitude.text, desiredFormatLongitude);
        if (isValid)
            textLongitude = inputLongitude.text;
        else
            Debug.LogWarning("[OnInputLongitude]: Wrong");
    }

    public void OnLatitude(InputField inputLatitude)
    {
        Debug.Log("[OnLatitude]: " + inputLatitude.text);
        bool isValid = CheckTextFormat(inputLatitude.text, desiredFormatLatitude);
        if (isValid)
            textLatitude = inputLatitude.text;
        else
            Debug.LogWarning("[OnLatitude]: Wrong");
    }

    public void OnInputTime(InputField inputTime)
    {
        Debug.Log("[OnInputTime]: " + inputTime.text);
        string text = inputTime.text;
        //check format
        bool isValidFormat = DateTime.TryParseExact(text, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out parsedTime);
        if(!isValidFormat)
        {
            Debug.LogWarning("WRONG");
        }
        
    }
    private bool CheckTextFormat(string text, string pattern)
    {
        bool isMatch = Regex.IsMatch(text, pattern);

        return isMatch;
    }

    public void OnSubmit()
    {
        if (textLongitude == null || textLatitude == null || parsedTime.ToString() == null)
        {
            //show form notify
            return;
        }

        GameObject sun = GameObject.FindGameObjectWithTag("sun");
        sun.GetComponent<Sun>().SetPosSun(parsedTime.Hour, parsedTime.Minute, parsedTime.Second);
    }
}