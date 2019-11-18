using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //各オブジェクトを取得
    public GameObject buttonMessage; //ボタンメッセージ
    public GameObject buttonMessageText; //メッセージテキスト

    public GameObject SakePanel;//酒（バケツ）パネル
    public GameObject KeyPanel;//鍵パネル
    public GameObject ImageKey;//鍵
    public GameObject KeyIcon;//鍵アイコン
    public GameObject ImageLockerOpen;//開いたロッカー

    public GameObject KeyIconActive;//鍵アイコン バック

    private bool doesHaveKey;//鍵フラグ１

    public AudioClip kaeruSE;//カエルSE
    private AudioSource audioSource;//オーディオソース

    private void Start()
    {
       doesHaveKey = false; //鍵は持っていない
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    void DisplayMessage(string mes)//メッセージを表示
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    //鍵をクリックしたらパネルとメッセージを表示
    public void OnClickImageKey()
    {
        audioSource.PlayOneShot(kaeruSE);
        KeyPanel.SetActive(true);
        DisplayMessage("バケツの底に鍵を見つけた！");
        ImageKey.SetActive(false);
        KeyIcon.SetActive(true);
    }

    //鍵アイコンをクリックしたアクティブパネルを表示
    public void OnClickKeyIcon()
    {
        KeyIconActive.SetActive(true);
        doesHaveKey = true;//鍵フラグ　ON
    }

    //ロッカーをタップ
    public void PushLockerButton()
    {
        audioSource.PlayOneShot(kaeruSE);

        if (doesHaveKey == false)
        {
            DisplayMessage("鍵がかかっている！！");
        }
        else
        {
            DisplayMessage("ロッカーが開いた！！");
            KeyIcon.SetActive(false);
            KeyIconActive.SetActive(false);

            ImageLockerOpen.SetActive(true);
        }
    }
     //メッセージを押したらメッセージを消す
       public void PushMessage()
    {
        audioSource.PlayOneShot(kaeruSE);
        buttonMessage.SetActive(false);
    }

    //キーパネルを押したらパネルを消す
    public void PushKeyPanel()
    {
        audioSource.PlayOneShot(kaeruSE);
        KeyPanel.SetActive(false);
    }   
}





