using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgDisp : MonoBehaviour
{
    public static string msg;

    public static bool flagDiaplay = false;

    public GUIStyle guiDisplay;

    private Rect rtDisplay = new Rect();

    public static float waitDelay;
    public static int msgLen;
    private float nextTime = 0;
    private void OnGUI()
    {
        const float guiScreen = 1280;
        const float guiWidth = 800;
        const float guiHeight = 200;
        const float guiLeft = (guiScreen - guiWidth) / 2;
        const float guiTop = 720 - guiHeight - 20;

        float gui_scale = Screen.width / guiScreen;

        if (flagDiaplay)
        {
            GUIStyle msgFont = new GUIStyle
            {
                fontSize = (int)(30 * gui_scale)
            };

            rtDisplay.x = guiLeft * gui_scale;
            rtDisplay.y = guiTop * gui_scale;
            rtDisplay.width = guiWidth * gui_scale;
            rtDisplay.height = guiHeight * gui_scale;
            
            GUI.Box(rtDisplay, "창", guiDisplay);
            
            msgFont.normal.textColor = Color.black;
            rtDisplay.x = (guiLeft + 22) * gui_scale;
            rtDisplay.y = (guiTop + 22) * gui_scale;
            GUI.Label( rtDisplay, msg.Substring(0, msgLen), msgFont);

            msgFont.normal.textColor = Color.white;
            rtDisplay.x = (guiLeft + 20) * gui_scale;
            rtDisplay.y = (guiTop + 20) * gui_scale;
            GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);
        }
    }

    public static void ShowMessage(string msg)
    {
        MsgDisp.msg = msg;
        flagDiaplay = true;
        msgLen = 0;
        waitDelay = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flagDiaplay)
        {
            if (msgLen < msg.Length)
            {
                if (Time.time > nextTime)
                {
                    msgLen++;
                    nextTime = Time.time + 0.02f;
                }
                else
                {
                    waitDelay += Time.deltaTime;
                    if (waitDelay > 1 + msg.Length / 4)
                    {
                        flagDiaplay = false;
                    }
                }
            }
        }
    }
}
