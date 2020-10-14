using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button HomeBtn;//返回首页
    public Button RetaryBtn;//重新开始
    public Button ContinueBtn;//继续
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
        ContinueBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnResume();
        });
        SkipLvBtn.onClick.AddListener(delegate
        {
            SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "点击跳关"); //先看激励视频广告        
            InputManager.IsSK = true;
        });
    }
}
