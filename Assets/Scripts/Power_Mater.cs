using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Power_Mater : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        Debug.Log("ここまで到達①");　//チェックログ①
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //今が左クリックで0.02ずつfillAmountが増えていきます
        {
            image.fillAmount += 0.02f;
            Debug.Log("ボタンが押されておりました");//チェックログ②

            if (image.fillAmount >= 1)  //ＭＡＸ（1）まで到達するとAmountが0へと戻ります
            {
                image.fillAmount = 0;
            }
        }

    }
}