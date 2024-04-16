using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class BtnCatch : MonoBehaviour
{
    public delegate void DEventBtnCatch();

    public event DEventBtnCatch clickCatch;

    public void ClicBtnCatch()
    {
        if (clickCatch != null)
            clickCatch();
    }
}
