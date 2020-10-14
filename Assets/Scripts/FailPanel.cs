using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailPanel : MonoBehaviour
{
    public Button HomeBtn;//返回首页
    public Button RetaryBtn;//重新开始
    public Button SkipLvBtn;//跳关



    void Start()
    {
        HomeBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnHome();
        });
        RetaryBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnReplay();
        });
        SkipLvBtn.onClick.AddListener(delegate
        {
            SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "点击跳关"); //先看激励视频广告        
            InputManager.IsSK = true;
        });
    }
}
