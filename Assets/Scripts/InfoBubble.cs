using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoBubble : MonoBehaviour
{
    TMP_Text InfoText;
    RawImage BubbleImage;

    void Start()
    {
        InfoText = GetComponentInChildren<TMP_Text>();
        InfoText.text = "";
        BubbleImage = GetComponent<RawImage>();
        BubbleImage.enabled = false;
    }

    IEnumerator InfoCoroutine(string info)
    {
        InfoText.text = info;
        BubbleImage.enabled = true;
        yield return new WaitForSeconds(2);
        InfoText.text = "";
        BubbleImage.enabled = false;
        yield break;
    }
    public void ShowInfo(string info)
    {
        StartCoroutine(InfoCoroutine(info));
    }
}