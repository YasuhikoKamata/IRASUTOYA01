using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //定数定義：ボタンマーク
    public const int MARK_00 = 0; //〇
    public const int MARK_01 = 1; //△     
    public const int MARK_02 = 2; //☆
    public const int MARK_03 = 3; //◇

    //各オブジェクトを取得
    public GameObject buttonMessage; //ボタンメッセージ
    public GameObject buttonMessageText; //メッセージテキスト

    public GameObject KeyPanel;//鍵パネル
    public GameObject ImageKey;//鍵
    public GameObject KeyIcon;//鍵アイコン
    public GameObject KeyIconActive;//鍵アイコン バック

    public GameObject ImageLockerOpen;//開いたロッカー

    public GameObject ImageHammer;//ハンマー！
    public GameObject HammerPanel;//ハンマーパネル
    public GameObject HammerIcon;//ハンマーアイコン
    public GameObject KeyIconActive2;//ハンマーアイコン バック

    public GameObject ImageButaB;//青ブタ
    public GameObject ImageButaB2;//壊れた青ブタ

    public GameObject ImageCard;//カード
    public GameObject CardPanel;//カードパネル
    public GameObject CardIcon;//カードアイコン
    public GameObject KeyIconActive4;//カードアイコン バック

    public GameObject ImageSake;//酒
    public GameObject SakePanel;//酒パネル
    public GameObject SakeIcon;//酒アイコン
    public GameObject KeyIconActive3;//酒アイコン バック

    public GameObject ImageTanuki;//たぬき
    public GameObject Rect4;//レクト4

    public GameObject ImageEleOpen;//開いたエレベーター
    public GameObject ImageSoujiOpen;//開いた掃除箱

    public GameObject ImageChaki;//茶器
    public GameObject ImageChaki2;//動いた茶器

    public GameObject[] buttonMark = new GameObject[3]; //ボタン　掃除入れ
    public Sprite[] buttonPicture = new Sprite[4]; //ボタン　絵

    private bool doesHaveKey;//鍵フラグ
    private bool doesHaveHammer;//ハンマーフラグ
    private bool doesHaveCard;//カードフラグ
    private bool doesHaveSake;//酒フラグ
    private bool doesHaveSouji;//掃除フラグ

    private int[] buttonColor = new int[3];

    public AudioClip kaeruSE;//カエルSE
    public AudioClip ClearSe;//クリアSE
    public AudioClip CorrectSe;//コレクトSE

    public AudioClip BombSe;//ボムSE
    public AudioClip ChakiSe;//茶器SE

    private AudioSource audioSource;//オーディオソース
    private GameObject activeIcon;//今のアイコン

    private void Start()
    {
        doesHaveKey = false;    //鍵は持っていない
        doesHaveHammer = false; //ハンマーは持っていない
        doesHaveCard = false;   //カードは持っていない
        doesHaveSake = false;   //酒は持っていない
        doesHaveSouji = false;   //掃除は開いてない

        buttonColor [0] = MARK_00;//マークは〇
        buttonColor [1] = MARK_00;//マークは☆
        buttonColor [2] = MARK_00;//マークは◇

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
    }
    //掃除　ボタン１をクリック
    public void PushButtonMark1 ()
    {
        ChangeButtonColor (0);
    }
　   //掃除　ボタン2をクリック
    public void PushButtonMark2()
    {
        ChangeButtonColor(1);
    }
　   //掃除　ボタン3をクリック
    public void PushButtonMark3()
    {
        ChangeButtonColor(2);
    }

    //ボタンの色を変更
    void ChangeButtonColor(int buttonNo)
    {
        buttonColor[buttonNo]++;

        if (buttonColor[buttonNo] > MARK_03)
        {
            buttonColor[buttonNo] = MARK_00;
        }
        buttonMark[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonColor[buttonNo]];


    //ボタンのマークをチェック
        if ((buttonColor[0] == MARK_00) &&
           (buttonColor[1] == MARK_01) &&
           (buttonColor[2] == MARK_02))
        {
        if (doesHaveSouji == false)
            {
            DisplayMessage("やった！　鍵が開いたみたいだ！！");
                audioSource.PlayOneShot(CorrectSe);
                ImageSoujiOpen.SetActive(true);
                doesHaveSouji = true;//掃除フラグ　ON
            }
    }
    }

    void DisplayMessage(string mes)//メッセージを表示
    {
        buttonMessage.SetActive(true);
        buttonMessageText.GetComponent<Text>().text = mes;
    }

    //酒をクリックしたらパネルとメッセージを表示
    public void OnClickImageSake(GameObject icon)
    {
        activeIcon = icon;
        audioSource.PlayOneShot(kaeruSE);
        SakePanel.SetActive(true);
        DisplayMessage("こ、これは・・・銘酒「日本酒」だ！");
        ImageSake.SetActive(false);
        SakeIcon.SetActive(true);
    }

    //酒アイコンをクリックしたらアクティブパネルを表示
    public void OnClickSakeIcon()
    {
        if (doesHaveSake == false)
        {
            KeyIconActive3.SetActive(true);
            doesHaveSake = true;//酒フラグ　ON
        }
        else
        {
            KeyIconActive3.SetActive(false);
            doesHaveSake = false;//鍵フラグ　Off
        }
    }

    //鍵をクリックしたらパネルとメッセージを表示
    public void OnClickImageKey(GameObject icon)
    {
        activeIcon = icon;
        audioSource.PlayOneShot(kaeruSE);
        KeyPanel.SetActive(true);
        DisplayMessage("バケツの底に鍵を見つけたぞ！");
        ImageKey.SetActive(false);
        KeyIcon.SetActive(true);
    }

    //鍵アイコンをクリックしたらアクティブパネルを表示
    public void OnClickKeyIcon()
    {
    if (doesHaveKey == false)
        {
            KeyIconActive.SetActive(true);
            doesHaveKey = true;//鍵フラグ　ON
        }
        else
        {
            KeyIconActive.SetActive(false);
            doesHaveKey = false;//鍵フラグ　Off
        }
    }

    //タヌキをクリックしたらメッセージを表示して、書き換え
    public void OnClickTanukiButton()
    {
        if (doesHaveSake == false)
        {
            audioSource.PlayOneShot(kaeruSE);
            DisplayMessage("床に動かした跡がある・・・\nタヌキが邪魔で動かせない。");
        }
        else
        {
            DisplayMessage("ポポン！！日本酒だ！　じゃあな！！");

            audioSource.PlayOneShot(ChakiSe);
            SakeIcon.SetActive(false);
            KeyIconActive3.SetActive(false);
            ImageTanuki.SetActive(false);
            ImageChaki2.SetActive(true);
            Rect4.SetActive(true);
            ImageChaki.SetActive(false);
        }
    }

    //ハンマーをクリックしたらパネルとメッセージを表示
    public void OnClickImageHammer(GameObject icon)
    {
        activeIcon = icon;
        audioSource.PlayOneShot(kaeruSE);
        HammerPanel.SetActive(true);
        DisplayMessage("ハンマーを見つけたぞ！");
        ImageHammer.SetActive(false);
        HammerIcon.SetActive(true);
    }

    //ハンマーアイコンをクリックしたアクティブパネルを表示
    public void OnClickHammerIcon()
    {
        if (doesHaveHammer == false)
        {
            KeyIconActive2.SetActive(true);
            doesHaveHammer = true;//ハンマーフラグ　ON
        }
        else
        {
            KeyIconActive2.SetActive(false);
            doesHaveHammer = false;//鍵フラグ　Off
        }
    }

    //ロッカーをタップ
    public void PushLockerButton()
    {
        audioSource.PlayOneShot(kaeruSE);

        if (doesHaveKey == false)
        {
            DisplayMessage("鍵がかかっているね！！");
        }
        else
        {
            DisplayMessage("ロッカーが開いたぞ！！");
            KeyIcon.SetActive(false);
            KeyIconActive.SetActive(false);
            ImageLockerOpen.SetActive(true);
        }
    }

    //青ブタをタップ
    public void PushButaBButton()
    {
        audioSource.PlayOneShot(kaeruSE);

        if (doesHaveHammer == false)
        {
            DisplayMessage("中になにか入っているようだね・・・\nぶっ壊せばとりだせる？！");
        }
        else
        {
            DisplayMessage("ハンマーでぶっ壊したぞ！！");

            {
                audioSource.PlayOneShot(BombSe);
                ImageButaB.SetActive(false);
                ImageButaB2.SetActive(true);
                HammerIcon.SetActive(false);
                KeyIconActive2.SetActive(false);
                ImageCard.SetActive(true);
            }
        }
    }
    //カードをクリックしたらパネルとメッセージを表示
    public void OnClickImageCard(GameObject icon)
    {
        activeIcon = icon;
        audioSource.PlayOneShot(kaeruSE);
        CardPanel.SetActive(true);
        DisplayMessage("カードキーを見つけたぞ！");
        ImageCard.SetActive(false);
        CardIcon.SetActive(true);
    }

    //カードアイコンをクリックしたアクティブパネルを表示
    public void OnClickCardIcon()
    {
        if (doesHaveCard == false)
        {
            KeyIconActive4.SetActive(true);
            doesHaveCard = true;//カードフラグ　ON
        }
        else
        {
            KeyIconActive4.SetActive(false);
            doesHaveCard = false;//カードフラグ　Off
        }
    }

    //エレベーターをクリック
    public void PushEkeveButton()
    {
        audioSource.PlayOneShot(kaeruSE);

        if (doesHaveCard == false)
        {
            DisplayMessage("カードキーがいるみたいだね・・");
        }
        else
        {
            DisplayMessage("エレベーターが開いたぞ！！！\nこれで、脱出できる！！！");
            audioSource.PlayOneShot(ChakiSe);
            ImageEleOpen.SetActive(true);
            CardIcon.SetActive(false);
            KeyIconActive4.SetActive(false);
        }
    }

    //エレベーターをクリック
    public void PushEleOpenButton()
    {
        SceneManager.LoadScene("End");
    }

    //メッセージを押したらメッセージを消す
    public void PushMessage()
    {
        if (activeIcon != null)
        {
            activeIcon.SetActive(false);
            activeIcon = null;
        }
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
