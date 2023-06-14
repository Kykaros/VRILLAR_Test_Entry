using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    GameObject sun = null;
    GameObject form = null;
    void Start()
    {
        sun = GameObject.FindGameObjectWithTag("sun");
        form = GameObject.FindGameObjectWithTag("form");
    }
}
