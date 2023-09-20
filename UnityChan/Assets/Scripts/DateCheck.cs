using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    private System.DateTime now;

    private int nowMonth;

    private int nowDay;

    private AudioSource univoice;

    public AudioClip voiceBirthday;
    public AudioClip voiceData0101;
    public AudioClip voiceData0115;
    public AudioClip voiceData0203;
    public AudioClip voiceData0211;
    public AudioClip voiceData0214;
    public AudioClip voiceData0303;
    public AudioClip voiceData0314;
    public AudioClip voiceData0319;
    public AudioClip voiceData0401;
    public AudioClip voiceData0421;
    public AudioClip voiceData0422;
    public AudioClip voiceData0503;
    public AudioClip voiceData0504;
    public AudioClip voiceData0505;
    public AudioClip voiceData0602;
    public AudioClip voiceData0707;
    public AudioClip voiceData0720;
    public AudioClip voiceData0813;
    public AudioClip voiceData0915;
    public AudioClip voiceData0922;
    public AudioClip voiceData1008;
    public AudioClip voiceData1010;
    public AudioClip voiceData1103;
    public AudioClip voiceData1123;
    public AudioClip voiceData1224;
    public AudioClip voiceData1225;
    public AudioClip voiceData1231;

    private AudioClip[,] voiceDate = new AudioClip[12 + 1, 31 + 1];

    
    
    // Start is called before the first frame update
    void Start()
    {
        now = System.DateTime.Now;
        nowMonth = now.Month;
        nowDay = now.Day;

        voiceDate[1, 1] = voiceData0101;
        voiceDate[1, 15] = voiceData0115;
        voiceDate[2, 3] = voiceData0203;
        voiceDate[2, 11] = voiceData0211;
        voiceDate[2, 14] = voiceData0214;
        voiceDate[3, 3] = voiceData0303;
        voiceDate[3, 14] = voiceData0314;
        voiceDate[3, 19] = voiceData0319;
        voiceDate[4, 1] = voiceData0401;
        voiceDate[4, 21] = voiceData0421;
        voiceDate[4, 22] = voiceData0422;
        voiceDate[5, 3] = voiceData0503;
        voiceDate[5, 4] = voiceData0504;
        voiceDate[5, 5] = voiceData0505;
        voiceDate[6, 2] = voiceData0602;
        voiceDate[7, 7] = voiceData0707;
        voiceDate[7, 20] = voiceData0720;
        voiceDate[8, 13] = voiceData0813;
        voiceDate[9, 15] = voiceData0915;
        voiceDate[9, 22] = voiceData0922;
        voiceDate[10, 08] = voiceData1008;
        voiceDate[10, 10] = voiceData1010;
        voiceDate[11, 03] = voiceData1103;
        voiceDate[11, 23] = voiceData1123;
        voiceDate[12, 24] = voiceData1224;
        voiceDate[12, 25] = voiceData1225;
        voiceDate[12, 31] = voiceData1231;

        int oldMonth = PlayerPrefs.GetInt("Month"); 
        int oldDay = PlayerPrefs.GetInt("Day");
        Debug.Log("이전 실행일 : " + oldMonth + "월 " + oldDay + "일\n" + "현재 실행일 : " + nowMonth + "월 " + nowDay + "일");
        
        
        univoice = GetComponent<AudioSource>();
        if (voiceDate[nowMonth, nowDay] != null && (oldMonth != nowMonth || oldDay != nowDay) )
        {
            univoice.PlayOneShot(voiceDate[nowMonth, nowDay]);
        }
        
        PlayerPrefs.SetInt("Month",nowMonth);
        PlayerPrefs.SetInt("Day", nowDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
