using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBgButtonMoveBgButton : MonoBehaviour
{
    //定数定義　部屋番号
    public const int BG_01 = 1; //01
    public const int BG_02 = 2; //02
    public const int BG_03 = 3; //03
    public const int BG_04 = 4; //04
    public const int BG_05 = 5; //05
    public const int BG_06 = 6; //06
    public const int BG_07 = 7; //07
    public const int BG_08 = 8; //08

    public GameObject panelWalls;   //部屋全体

    public void PushArrow01(int bgNo)//Arrow01を押した
    {
        DisplayWall(bgNo); //部屋更新
    }

    void DisplayWall(int bgNo)
    {
        switch (bgNo)
        {
            case BG_01://01
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;

            case BG_02://02
                panelWalls.transform.localPosition = new Vector3(-1100.0f, 0.0f, 0.0f);
                break;

            case BG_03://03
                panelWalls.transform.localPosition = new Vector3(-2200.0f, 0.0f, 0.0f);
                break;

            case BG_04://04
                panelWalls.transform.localPosition = new Vector3(0.0f, 1700.0f, 0.0f);
                break;

            case BG_05://05
                panelWalls.transform.localPosition = new Vector3(-1100.0f, 1700.0f, 0.0f);
                break;

            case BG_06://06
                panelWalls.transform.localPosition = new Vector3(-2200.0f, 1700.0f, 0.0f);
                break;

            case BG_07://07
                panelWalls.transform.localPosition = new Vector3(0.0f, 3400.0f, 0.0f);
                break;

            case BG_08://08
                panelWalls.transform.localPosition = new Vector3(-1100.0f, 3400.0f, 0.0f);
                break;
        }
    }  
}
