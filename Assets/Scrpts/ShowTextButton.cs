using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextButton : MonoBehaviour
{
    [Multiline]
    public string showText;

    //各オブジェクトを取得
    public GameObject buttonMessage; //ボタンメッセージ
    public GameObject buttonMessageText; //メッセージテキスト

    void DisplayMessage(string mes)//メッセージを表示
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    public void PushButaBButton()//青ブタをタップ
    {
        DisplayMessage(showText);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
