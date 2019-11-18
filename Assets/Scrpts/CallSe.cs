using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSe : MonoBehaviour
{
    public AudioClip kaeruSE;//カエルSE
    private AudioSource audioSource;//オーディオソース

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void PushButaBButton()//青ブタをタップ
    {
        audioSource.PlayOneShot(kaeruSE);
    }
}
