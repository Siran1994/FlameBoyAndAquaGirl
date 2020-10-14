using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum PackageType  //出包类型
{
    PingCe,   //评测包
    AD,       //广告包
}
public enum ShowAdType  //展示广告类型插屏
{
    Native,
    Banner = 1,   //条幅广告
    ChaPing,      //插屏广告
    Reward,       //激励视频
    VideoAD       //激励视频
}
public class SDKManager : MonoBehaviour
{
    public static SDKManager Instance; //单例类

    int insterADCount = 0;//插屏展示次数

    float insterADjiange = 0;//插屏展示间隔

    bool insterShangxian = true;//插屏展示上限
   
    [Header("APK类型")]
    public PackageType PT; //包类型

    [Header("是否展示广告(非AD包:false/Auto)")]
    public bool IsShowAd = true; //是否展示广告

    [HideInInspector]
    public bool IsCanShowAd = false; //OPPO一分钟广告限制

    #region Unity方法
    void Awake()
    {
        this.gameObject.name = "SDKManager";
        if (Instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        if (PT != PackageType.AD || Application.platform == RuntimePlatform.WindowsEditor)
            IsShowAd = false;
    }
    void Start()//广告初始化
    {
        if (IsShowAd == false)
            return;
        //  mReport();
        StartCoroutine("Timer");

        BannerInit(203335);

        StartCoroutine(InitNativeAd());//初始化原生广告

        RewardInit(203341);

        RepeatShowBan(1.5f, 30, "1.5后展示,30秒刷新");//重复调用Banner
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(60);
        PlayerPrefs.SetInt("IsCanShowAd", 1);
    }
    IEnumerator InitNativeAd()
    {
        NativeInit(203349);
        yield return new WaitForSeconds(10);
        NativeInit(203362);
        yield return new WaitForSeconds(10);
        NativeInit(203364);
        yield return new WaitForSeconds(10);
        NativeInit(203366);
    }
    void Update()
    {
        if (insterShangxian == false)
        {
            if (insterADjiange <= 60f)
            {
                insterADjiange += Time.deltaTime;
            }
            else
            {
                insterShangxian = true;
                insterADjiange = 0;
            }
        }
        if (PlayerPrefs.GetInt("IsCanShowAd", 0) == 1)
        {
           // Debug.Log("当前状态为: " + IsCanShowAd);
            IsCanShowAd = true;
        }
        else
        {
            IsCanShowAd = false;
        }
        BannerReShow();//关闭5次后默认2小时可以展示Banner
    }
    #endregion

    #region 对外方法
    public void ShowAd(ShowAdType ADType, int adType, string Log = "Unity日志展示", Image ui = null)
    {
        switch (ADType)
        {
            case ShowAdType.Native:
                ShowNative(ui, adType);
                Debug.Log(Log + "展示原生广告");
                break;
            case ShowAdType.Banner:
                ShowBanner();
                Debug.Log(Log + "展示Banner");
                break;
            case ShowAdType.ChaPing:
               // ShowChaPing();
                Debug.Log(Log + "展示插屏");
                break;
            case ShowAdType.VideoAD:
                Debug.Log(Log + "无此类型广告");
                break;
            case ShowAdType.Reward:
                ShowVideoAD();
                Debug.Log(Log + "展示激励视屏");
                break;
        }
    }
    public void MakeToast(string str = "暂无广告!!!")
    {
        if (IsShowAd == false)
            return;
        AndroidJavaObject currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        if (currentActivity != null && Toast != null)
        {
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                Toast.CallStatic<AndroidJavaObject>("makeText", currentActivity, str, Toast.GetStatic<int>("LENGTH_LONG")).Call("show");
            }));
        }
        else
        {
            ShowToast(str);
        }
    }
    public void AddToDesk()//创建桌面图标
    {
        BtnAddIcon();
    }
    public bool IsNativeAvaiable()//判断原生广告是否加载成功
    {
        if (IsShowAd == false)
            return false;
        return nav_isNativeAvaiable();
    }
    public void NativeClick(string adId)//原生广告点击跳转
    {
        if (IsShowAd == false)
            return;
        nav_clickNativeAd(adId);
    }
    public void RepeatShowBan(float time, int rate, string Log = "Unity日志展示") //重复调用Banner
    {
        Debug.Log(Log + "展示Banner");
        if (IsShowAd == false)
            return;
        if (IsCanShowAd)
        {
            InvokeRepeating("ShowBanner", time, rate);
        }
    }
    public void CloseBanner(string Log = "Unity日志展示") //关闭banner
    {
        Debug.Log(Log + "关闭Banner");
        if (IsShowAd == false)
            return;
        HideBanner(true);
        CancelInvoke("ShowBanner");
    }
    #endregion

    #region 私有方法

    #region 原生广告
    private void NativeInit(int adId) //原生广告初始化
    {
        if (IsShowAd == false)
            return;
        initNativeAd(adId);
    }
    private void ShowNative(Image Ui,int adtype)//展示原生广告
    {
        if (IsShowAd == false)
            return;
        StartCoroutine(LoadNativeAd(Ui, adtype));
    }

    [HideInInspector]
    public string adTitle = "";//广告标题
    [HideInInspector]
    public string adDesc = "";//广告描述
    private IEnumerator LoadNativeAd(Image Ui,int AdType )
    {
        string adTexUrl = "";//两种类型的广告(Img ,icon)

        string adInfo = nav_loadNativeAdInfo(AdType);
        Debug.Log("原生广告信息(adInfo): " + adInfo);
       
        string[] tmpArray = adInfo.Split('#');
       
        Debug.Log("原生广告类型(adTexUrl): " + AdType);
        if (AdType==1)//img 类型的广告
        {
            adTexUrl = tmpArray[0];
            Debug.Log("原生广告图片地址(adTexUrl): " + adTexUrl);
        }
        else　　　// icon 类型的广告
        {
            adTexUrl = tmpArray[0];
            Debug.Log("原生广告图片地址(adTexUrl): " + adTexUrl);
        }

        adTitle = tmpArray[1];
        Debug.Log("原生广告标题(adTitle): " + adTitle);

        adDesc = tmpArray[2];
        Debug.Log("原生广告描述(adDesc): " + adDesc);

        yield return GetTexture(adTexUrl, Ui);
    }
    IEnumerator GetTexture(string url, Image img)
    {
        var uri = new Uri(url);
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();//发送下载请求
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Texture2D texture2 = DownloadHandlerTexture.GetContent(uwr);
                Sprite sprite = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), Vector2.zero);
                Debug.Log("原生广告素材图(sprite): " + sprite);
                img.sprite = sprite;
                Debug.Log("原生广告UI背景(img): " + img.sprite);
                //img.SetNativeSize();
            }
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion

    #region Banner广告
    private void BannerInit(int adId) //Banner初始化
    {
        if (IsShowAd == false)
            return;
        initBanner(adId);
    }
    private void ShowBanner()//展示Banner(一天只能展示5次)
    {
        if (IsShowAd == false)
            return;
        if (PlayerPrefs.GetInt("HandClose", 0) < 5)
        {
            showBanner();
        }
    }
    private void HideBanner(bool isAutoBannerHide)//关闭Banner
    {
        if (IsShowAd == false)
            return;
        if (IsCanShowAd)
        {
            hideBanner(isAutoBannerHide);
        }
    }
    #endregion

    #region 插屏广告
    private void ChaPingInit(int adId) //插屏广告初始化
    {
        if (IsShowAd == false)
            return;
        initInsterAD(adId);
    }
    private void ShowChaPing()//展示ChaPing(一天只能展示8次)
    {
        if (IsShowAd == false)
            return;
        if (PlayerPrefs.GetInt("ins") < 8)
        {
            if (insterShangxian)
            {
                showInsterAD();
                insterShangxian = false;
            }
        }
    }
    #endregion

    #region 激励视频
    private void RewardInit(int adId)  //激励视频初始化
    {
        if (IsShowAd == false)
            return;
        initVideoAD(adId);
    }
    private void ShowVideoAD()//展示激励视频
    {
        if (IsShowAd == false)
            return;
        showVidoeAD();
    }
    #endregion
    #endregion

    #region OPPO小游戏回调方法 
    private static bool IsAddIcon = false;
    private void OnAddIconSuccess()//Banner隐藏
    {
        IsAddIcon = true;
        Debug.LogError("添加桌面成功");
    }
    private void OnHasIcon()//Banner隐藏
    {
        IsAddIcon = true;
        Debug.LogError("添加桌面成功");
    }

    private void OnBannerHide()//Banner隐藏
    {
        PlayerPrefs.SetInt("HandClose", (PlayerPrefs.GetInt("HandClose") + 1));
        if (PlayerPrefs.GetInt("HandClose") >= 5)
        {
            PlayerPrefs.SetString("SetTime", DateTime.Now.ToLongTimeString());
        }
        Debug.LogError("玩家手动关闭Banner次数为: " + PlayerPrefs.GetInt("HandClose"));
        Debug.LogError("banner广告关闭");
    }
    // 判断第一次和现在的时间间隔
    public void BannerReShow(int limitHour = 2)
    {
        DateTime nowTime = DateTime.Now;
        DateTime oldTime = DateTime.Parse(PlayerPrefs.GetString("SetTime", DateTime.Now.ToLongTimeString()));

        TimeSpan timeSpan = nowTime - oldTime;

        //判断上次储存的时间
        if (timeSpan.Days > 1)
        {
            Debug.Log("Days: " + timeSpan.Days);
        }
        else if (timeSpan.Hours > limitHour)//默认2小时可以展示Banner
        {
            PlayerPrefs.SetInt("HandClose", 0);
            Debug.Log("Hours: " + timeSpan.Hours);
        }
        else if (timeSpan.Minutes < 60)
        {
           // Debug.Log("Minutes: " + timeSpan.Minutes);
        }
    }
    private void OnInsterclose()//插屏关闭
    {
        PlayerPrefs.SetInt("ins", PlayerPrefs.GetInt("ins") + 1);
        if (PlayerPrefs.GetInt("ins") >= 8)
        {
            PlayerPrefs.SetInt("Bins", DateTime.Now.Day);
            PlayerPrefs.SetInt("fir2", 1);
        }
        Debug.LogError("插屏广告关闭");
    }
    private void OnADclose()//激励广告发放奖励
    {
        Debug.LogError("激励视频奖励发放");

        if (InputManager.IsSK) //跳关
        {
            InputManager.IsSK = false;
            InputManager.IPmanager.ToGetSkip(); 
        }
        if (InputManager.IsFH) //复活
        {
            InputManager.IsFH = false;
            InputManager.IPmanager.FH();
        }
        if (EasyLevels.IsToUnLock)
        {
            EasyLevels.IsToUnLock = false;
            FindObjectOfType<EasyLevels>().ToUnlock();
        }
        if (NormalLevels.IsToUnLock)
        {
            NormalLevels.IsToUnLock = false;
            FindObjectOfType<NormalLevels>().ToUnlock();
        }
    }
    private void OnBannerError(object obj)//Banner广告展示失败
    {
        Debug.Log(obj.ToString());
    }
    private void OnInsterError(object obj)//插屏广告展示失败
    {
        Debug.Log(obj.ToString());
    }
    private void OnNativeError(object obj)//原生广告展示失败
    {
        Debug.Log(obj.ToString());
    }
    #endregion

    #region OPPO小游戏静态方法
    [DllImport("__Internal")]
    private static extern void mReport();//原生上报

    [DllImport("__Internal")]
    private static extern void ShowToast(string str);//展示吐司

    [DllImport("__Internal")]
    private static extern void BtnAddIcon();//创建桌面图标

    [DllImport("__Internal")]
    private static extern void initNativeAd(int adId);//原生广告初始化

    [DllImport("__Internal")]
    private static extern bool nav_isNativeAvaiable();//原生广告状态判断

    [DllImport("__Internal")]
    private static extern string nav_loadNativeAdInfo(int adType);//原生广告类型(icon,img)//1 img 2 icon

    [DllImport("__Internal")]
    private static extern void nav_clickNativeAd(string adId);//点击原生广告(填入对应的adID)

    [DllImport("__Internal")]
    private static extern void initBanner(int bannerId);//Banner初始化

    [DllImport("__Internal")]
    private static extern void showBanner();//Banner展示

    [DllImport("__Internal")]
    private static extern void hideBanner(bool isAutoBannerHide);//Banner隐藏

    [DllImport("__Internal")]
    private static extern void initInsterAD(int insterId);//插屏初始化

    [DllImport("__Internal")]
    private static extern void showInsterAD();//插屏展示

    [DllImport("__Internal")]
    private static extern void initVideoAD(int videoId);//激励视频初始化

    [DllImport("__Internal")]
    private static extern void showVidoeAD();//激励视频展示
    #endregion
}

#region 编辑器拓展
public class Menus : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("用户数据/一键清理")]
    static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("数据清理成功!");
    }
#endif
}
#endregion