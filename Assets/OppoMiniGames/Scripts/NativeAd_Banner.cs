using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
/*****************************************
	 文件:   NativeAd.cs
	 作者:   漠白
	 日期:   2020.7.2
	 功能:   OPPO原生广告Banner模版 
 *****************************************/
public class NativeAd_Banner : MonoBehaviour
{
    [Header("指定渲染的UI")]
    public Image Ui;

    [Header("原生广告的ID")]
    public string AdId;

    [Header("原生广告的标题")]
    public Text Title;

    [Header("原生广告的描述")]
    public Text desc;

    public GameObject Root;
    public Button JumpBtn;
    public Button CloseBtn;

    void Awake()
    {
        if (SDKManager.Instance.IsCanShowAd)
        {
            AdId = "203349";//原生BannerID一般唯一
            Root.gameObject.SetActive(true);
            if (SDKManager.Instance.IsNativeAvaiable())
            {
                SDKManager.Instance.ShowAd(ShowAdType.Native, 2, "首页展示原生", Ui);
                Title.text = SDKManager.Instance.adTitle;
                desc.text = SDKManager.Instance.adDesc;  //原生广告正文 
            }
        }
    }
    void Start()
    {

        JumpBtn.onClick.AddListener(delegate 
        {
            SDKManager.Instance.NativeClick(AdId);//原生广告点击回调绑定
        });
        CloseBtn.onClick.AddListener(delegate
        {
            Root.gameObject.SetActive(false);
        });

        if (AdId=="")
        {
           Debug.LogError("请输入原生广告ID");
        }
        else
        {
            if (SDKManager.Instance.IsCanShowAd)
            {
                Debug.Log("原生广告拉取状态: " + SDKManager.Instance.IsNativeAvaiable());

                if (SDKManager.Instance.IsNativeAvaiable())
                {
                    SDKManager.Instance.ShowAd(ShowAdType.Native, 2, "首页展示原生Banner", Ui);
                    Title.text = SDKManager.Instance.adTitle;//原生广告标题
                    desc.text = SDKManager.Instance.adDesc;  //原生广告正文 
                }
            }
        }
    }
}
