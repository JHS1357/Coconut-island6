using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtnController : MonoBehaviour
{
    public void ClickPauseBtn()
    {
        Time.timeScale = 0.0f;     
    }

    public void ClickResumeBtn()
    {
        Time.timeScale = 1.0f;
    }
}
