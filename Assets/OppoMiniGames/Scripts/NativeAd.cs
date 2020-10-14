using UnityEngine;
using UnityEngine.UI;
/*****************************************
	 文件:   NativeAd.cs
	 作者:   漠白
	 日期:   2020.7.2
	 功能:   OPPO原生广告模版 
 *****************************************/
public class NativeAd : MonoBehaviour
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
    public Button CheckBtn;
    public Button CloseBtn;
    void Awake()
    {
        if (SDKManager.Instance.IsCanShowAd)
        {
            Root.gameObject.SetActive(true);
        }
    }
    void Start()
    {
        //SDKManager.Instance.NativeInit(193995);

        JumpBtn.onClick.AddListener(delegate
        {
            SDKManager.Instance.NativeClick(AdId);//原生广告点击回调绑定
        });
        CheckBtn.onClick.AddListener(delegate
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
            Invoke("ShowNativeAd", 0.0f);
        }
    }
    void ShowNativeAd()
    {
        if (SDKManager.Instance.IsCanShowAd)
        {
            Debug.Log("原生广告拉取状态: " + SDKManager.Instance.IsNativeAvaiable());

            if (SDKManager.Instance.IsNativeAvaiable())
            {
                SDKManager.Instance.ShowAd(ShowAdType.Native, 1, "首页展示原生", Ui);
                Title.text = SDKManager.Instance.adTitle;
            }
        }
    }
}
