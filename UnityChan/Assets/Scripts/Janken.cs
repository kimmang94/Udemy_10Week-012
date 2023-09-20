using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Janken : MonoBehaviour
{
    private bool flagJanken = false;
    private int modeJanken = 0;

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    private const int JANEKN = -1;
    private const int GOO = 0;
    private const int CHOKI = 1;
    private const int PAR = 2;
    private const int DRAW = 3;
    private const int WIN = 4;
    private const int LOOSE = 5;

    private Animator animator;
    private AudioSource univoice;

    private int myHand;
    private int unityHand;
    private int flagResult;
    private int[,] tableResult = new int[3, 3];

    private float waitDelay;

    public GUIStyle guiBtnGame;
    public GUIStyle guiBtnGoo;
    public GUIStyle guiBtnChoki;
    public GUIStyle guiBtnPar;

    private Rect rtBtnGame = new Rect();
    private Rect rtBtnGoo = new Rect();
    private Rect rtBtnChoki = new Rect();
    private Rect rtBtnPar = new Rect();
    private void OnGUI()
    {
        const float guiScreen = 1280;
        const float guiPadding = 10;
        const float guiButton = 200;
        const float guiTop = 720 - guiButton - guiPadding;

        float gui_scale = Screen.width / guiScreen;
        float scaledPadding = guiPadding * gui_scale;
        float scaledButton = guiButton * gui_scale;
        float scaledTop = guiTop * gui_scale;

        rtBtnGame.x = scaledPadding;
        rtBtnGame.y = scaledTop;
        rtBtnGame.width = scaledButton;
        rtBtnGame.height = scaledButton;

        float left = (guiScreen - guiPadding * 2 - guiButton * 3) / 2 * gui_scale;
        rtBtnGoo.x = left;
        rtBtnGoo.y = scaledTop;
        rtBtnGoo.width = scaledButton;
        rtBtnGoo.height = scaledButton;

        left += scaledButton + scaledPadding;
        rtBtnChoki.x = left;
        rtBtnChoki.y = scaledTop;
        rtBtnChoki.width = scaledButton;
        rtBtnChoki.height = scaledButton;

        left += scaledButton + scaledPadding;
        rtBtnPar.x = left;
        rtBtnPar.y = scaledTop;
        rtBtnPar.width = scaledButton;
        rtBtnPar.height = scaledButton;
        
        if (!flagJanken)
        {
            flagJanken = (GUI.Button(rtBtnGame, "묵찌빠", guiBtnGame));
        }

        if (modeJanken == 1)
        {
            if (GUI.Button(rtBtnGoo, "묵", guiBtnGoo))
            {
                myHand = GOO;
                modeJanken++;
            }
            if (GUI.Button(rtBtnChoki, "찌", guiBtnChoki))
            {
                myHand = CHOKI;
                modeJanken++;
            }
            if (GUI.Button(rtBtnPar, "빠", guiBtnPar))
            {
                myHand = PAR;
                modeJanken++;
            }
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent < AudioSource>();

        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;
        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;
        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;
    }
    
    void Update()
    {
        if (flagJanken)
        {
            switch (modeJanken)
            {
                case 0:
                    UnityChanAction(JANEKN);
                    modeJanken++;
                    break;
                case 1:
                    animator.SetBool("Janken", false);
                    animator.SetBool("Aiko", false);
                    animator.SetBool("Goo", false);
                    animator.SetBool("Choki", false);
                    animator.SetBool("Par", false);
                    animator.SetBool("Win", false);
                    animator.SetBool("Loose", false);
                    break;
                case 2:
                    flagResult = JANEKN;
                    unityHand = Random.Range(GOO, PAR + 1);
                    UnityChanAction(unityHand);
                    flagResult = tableResult[unityHand, myHand];
                    modeJanken++;
                    break;
                case 3:
                    waitDelay += Time.deltaTime;
                    if (waitDelay > 1.5f)
                    {
                        UnityChanAction(flagResult);

                        waitDelay = 0;
                        modeJanken++;
                    }
                    break;
                default:
                    flagJanken = false;
                    modeJanken = 0;
                    break;
            }
        }
    }

    private void UnityChanAction(int act)
    {
        switch (act)
        {
            case JANEKN:
                animator.SetBool("Janken", true);
                univoice.clip = voiceStart;
                break;
            case GOO:
                animator.SetBool("Goo", true);
                univoice.clip = voiceGoo;
                break;
            case CHOKI:
                animator.SetBool("Choki", true);
                univoice.clip = voiceChoki;
                break;
            case PAR :
                animator.SetBool("Par", true);
                univoice.clip = voicePar;
                break;
            case DRAW :
                animator.SetBool("Aiko", true);
                univoice.clip = voiceDraw;
                break;
            case WIN :
                animator.SetBool("Win", true);
                univoice.clip = voiceWin;
                break;
            case LOOSE :
                animator.SetBool("Loose", true);
                univoice.clip = voiceLoose;
                break;
        }

        univoice.Play();
    }

}
