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
        image.fillAmount = 0;
    }

    void Update()
    {
        int power = (int)GameManager.Instance.GetKilledCount();
        image.fillAmount += power * 0.02f;

        if (image.fillAmount >= 1)  //ＭＡＸ（fillAmountが1）まで到達するとAmountが0へと戻ります
        {
            image.fillAmount = 1;
        }


    }
}