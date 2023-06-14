using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class formInput : MonoBehaviour
{
    [SerializeField]
    private GameObject popup;

    private string textLongitude = null;//kinh
    private string textLatitude = null;//vi
    private DateTime parsedTime;
    private bool isValidFormat = false;

    private string desiredFormatLongitude = "^([0-9]|[1-9][0-9]|[1][0-7][0-9]|180)[EW]$";
    private string desiredFormatLatitude = "^([0-9]|[1-8][0-9]|90)[NS]$";

    public void OnInputLongitude(InputField inputLongitude)
    {
        Debug.Log("[OnInputLongitude]: " + inputLongitude.text);
        bool isValid = CheckTextFormat(inputLongitude.text, desiredFormatLongitude);
        if (isValid)
        {
            textLongitude = inputLongitude.text;
            popup.SetActive(false);
        }
    }

    public void OnLatitude(InputField inputLatitude)
    {
        Debug.Log("[OnLatitude]: " + inputLatitude.text);
        bool isValid = CheckTextFormat(inputLatitude.text, desiredFormatLatitude);
        if (isValid)
        {
            textLatitude = inputLatitude.text;
            popup.SetActive(false);
        }
    }

    public void OnInputTime(InputField inputTime)
    {
        Debug.Log("[OnInputTime]: " + inputTime.text);
        string text = inputTime.text;
        //check format
        popup.SetActive(false);
        isValidFormat = DateTime.TryParseExact(text, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out parsedTime);
        
    }
    private bool CheckTextFormat(string text, string pattern)
    {
        bool isMatch = Regex.IsMatch(text, pattern);

        return isMatch;
    }

    public void OnSubmit()
    {
        if (textLongitude == null || textLatitude == null || !isValidFormat)
        {
            //show form notify
            popup.SetActive(true);
            return;
        }

        int longitudeValue = 0;
        int latitudeValue = 0;
        if (textLongitude.EndsWith("E") || textLongitude.EndsWith("W"))
        {
            if(textLongitude.EndsWith("W"))
                textLongitude = textLongitude.Insert(0,"-");
            string longitude = textLongitude.Substring(0,textLongitude.Length - 1);
            longitudeValue = Convert.ToInt32(longitude);
        }

        if (textLatitude.EndsWith("S") || textLatitude.EndsWith("N"))
        {
            if (textLatitude.EndsWith("N"))
                textLatitude = textLatitude.Insert(0, "-");
            string latitude = textLatitude.Substring(0, textLatitude.Length - 1);
            latitudeValue = Convert.ToInt32(latitude);
        }

        GameObject sun = GameObject.FindGameObjectWithTag("sun");
        sun.GetComponent<Sun>().SetPosSun(parsedTime.Hour, parsedTime.Minute, parsedTime.Second, longitudeValue, latitudeValue);
    }
}