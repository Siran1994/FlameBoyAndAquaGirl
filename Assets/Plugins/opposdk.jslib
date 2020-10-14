//U3d中c#调用js方法

mergeInto(LibraryManager.library, {
	
	
	//--------------------------------------------------------Toast-------------------------------------------------
	ShowToast:function(str)
	{
		qg.showToast({title:str});		
	},
	
	//-------------------------------------------------创建桌面图标------------------------------------------
	BtnAddIcon:function()
	{
		qg.hasShortcutInstalled(
		{
			success:function(res)
			{
				//判断图标未存在时,创建桌面图标
				if(res==false)
				{
					qg.installShortcut(
					{
						success:function()
						{
							//执行用户创建图标奖励
							qg.showToast({title:"已添加至桌面"});
							window.alert("创建成功 success",res);	
							unityInstance.SendMessage('SDKManager', 'OnAddIconSuccess',str);  
						},
						fail:function(err)
						{							
						},
						complete:function()
						{							
						}
					}
					)
				}
				else
				{				
				 unityInstance.SendMessage('SDKManager', 'OnHasIcon',str);  
				}
			},
			fail:function(err)
			{
				window.alert("创建失败 fail",err);	
			},
			complete:function()
			{				
			}
	    })
	},
	
	//----------------------------------------------------------------------------------------------------原生广告---------------------------------------
	//原生广告初始化
	initNativeAd:function(adId)
	{
		window.nativeAd = qg.createNativeAd(
		{
			adUnitId:adId
		});
		window.jslib=this;
		window.alert("1111111"+JSON.stringify(window.nativeAd))		
		if(!window.nativeAd){
			return;
		}
		window.nativeAd.onLoad(function(res)
		{
			 window.alert("nativeAd广告加载" + res.adList);
			  window.alert("3333333" + JSON.stringify(res.adList));
			 window.nativeRes = res.adList[0];
		});
		
		window.nativeAd.onError(function(err)
		{
			   var str = JSON.stringify(err)
            window.alert("nativeAd广告加载错误 :" + str);
			unityInstance.SendMessage('SDKManager', 'OnNativeError',str);  
		});
		window.nativeAd.load();
	},	
	
	//原生广告	
	nav_isNativeAvaiable:function()
	{		
		return window.nativeRes!=null;
	},
	
	nav_loadNativeAdInfo:function(AdType)
	{
		//imgurl#^#adId
		//var iconStr =window.nativeRes.desc;	
		//var iconStr =window.nativeRes.title;	

        var imgStr = window.nativeRes.imgUrlList[0]+"#"+window.nativeRes.title+"#"+window.nativeRes.desc;		
		var iconStr = window.nativeRes.icon+"#"+window.nativeRes.title+"#"+window.nativeRes.desc;	
		
		var adid = window.nativeRes.adId;
		
		 window.alert("原生广告img url: " + imgStr);
		 window.alert("原生广告icon url: " + iconStr);
		 window.alert("原生广告adid: " + adid);
		//reportShow
		window.nativeAd.reportAdShow(
		{
			adId:adid
		})
		
		//reload
		window.nativeRes = null;
		window.nativeAd.load();
		
		//convert string
		var str="";
		
		if(AdType==1)
		{	
	      str = imgStr;
		}
		if(AdType==2)
		{
		  str = iconStr;
		}			
		window.alert("当前广告类型: " + AdType);
		var bufferSize = lengthBytesUTF8(str) + 1;
		var buffer = _malloc(bufferSize);
		
		window.alert("4444444 :" + buffer);
		
		stringToUTF8(str,buffer,bufferSize);
		
		window.alert("nativeAd展示成功");	
		return buffer;
	},
	
	nav_clickNativeAd:function()
	{
	   if(!window.nativeRes||!window.nativeRes.adId)
	   {
	      qg.showToast({title:"暂无广告!!!"});
		  return false;
	   }
	   else
	   {
	     window.nativeAd.reportAdClick({adId:window.nativeRes.adId});
		 window.alert("nativeAd被点击" + window.nativeRes.adId);
	   }		
	},	
	
    //----------------------------------------------------------------------------Banner------------------------------------------------------------
    //初始化banner 位置选用默认就好 如果运营需要修改 打开style 在此填写就行
    initBanner: function (adUnitIdTemp) {
        window.bannerAd = qg.createBannerAd({
            adUnitId: adUnitIdTemp
           // style: {
                //          top: top,
                //          left: left,
                //          width: width,
                //          height: height
                //        }

        });
    
        window.alert("banner初始化成功" + adUnitIdTemp);

        window.bannerAd.onShow(function () {

            window.alert("banner展示成功");
        });
        window.bannerAd.onError(function (err) {
  
              var str = JSON.stringify(err)
            window.alert("banner展示失败 :" + str);
			unityInstance.SendMessage('SDKManager', 'OnBannerError',str);  
        });
        window.bannerAd.onLoad(function () {

            window.alert("banner加载成功");
        });
	    window.bannerAd.onHide(function() 
		{
			if(window.isAutoBannerHide)
			{
				window.alert('banner 广告自动隐藏')
				window.isAutoBannerHide = false;
			}				
			else
			{
				window.alert('banner 广告手动隐藏')
				unityInstance.SendMessage('SDKManager', 'OnBannerHide',adUnitIdTemp); 
			}              
        });		
        //banner需要监听什么方法就在此监听 
    },
	
	hideBanner: function (isHandClose)
	{
		window.isAutoBannerHide = isHandClose;
		window.bannerAd.hide();
		
    },
	
  mReport:function(){
   
   qg.reportMonitor('game_scene', 0);
   },
    showBanner: function () {
    
         window.bannerAd.show();
         window.alert("展示banner");
    },
    hideBanner: function () {

        window.bannerAd.hide();
    },
    //---------------------------------------------------------------------------------插屏-------------------------------------------------------------------------
    //初始化插屏
    initInsterAD: function (adUnitIdTemp) {
        window.insterAd = qg.createInsertAd({
            adUnitId: adUnitIdTemp         
        });       
		
        window.alert("插屏初始化成功" + adUnitIdTemp);

        window.insterAd.onShow(function () {

            window.alert("插屏展示成功");
			unityInstance.SendMessage('SDKManager', 'OnInsterclose',adUnitIdTemp);
			
        });
        window.insterAd.onError(function (err) {

            var str = JSON.stringify(err)
            window.alert("插屏展示失败 :" + str);
			 unityInstance.SendMessage('SDKManager', 'OnInsterError',str);
        });
        window.insterAd.onLoad(function () {


            window.alert("插屏加载成功");
        });
		
        //插屏需要监听什么方法就在此监听 
        window.insterAd.offClose(function (){
	        window.insterAd.destory();
			 window.insterAd = qg.createInsertAd({
            adUnitId: adUnitIdTemp         
           });
        });
		
	},


    showInsterAD: function () {
          window.insterAd.load();
          window.insterAd.show();
          window.alert("展示插屏");

    },   
	
	 //--------------------------------------------------------------------------------------激励视频------------------------------------------------------------------------------
    //初始化激励视频
    initVideoAD: function (adUnitIdTemp)
	{
        window.videoAd = qg.createRewardedVideoAd
		({
            adUnitId: adUnitIdTemp         
        });       
		
        window.alert("激励视频初始化成功" + adUnitIdTemp);
       
        window.videoAd.onError(function (err)
		{
            var str = JSON.stringify(err)
            window.alert("激励视频展示失败 :" + str);
			unityInstance.SendMessage('SDKManager', 'OnVideoError',str); 			
        });
        window.videoAd.onLoad(function () 
		{            
		    window.videoAd.show();
            window.alert("激励视频加载成功");
        });
		
        //激励视频需要监听什么方法就在此监听 
        window.videoAd.offClose(function ()
		{			
	        window.insterAd.destory();
			 window.insterAd = qg.createRewardedVideoAd({
            adUnitId: adUnitIdTemp         
           });
        });
		
		window.videoAd.onClose(function(res)
		{
          if (res.isEnded) {
             window.alert('激励视频广告完成，发放奖励');
		     unityInstance.SendMessage('SDKManager', 'OnADclose',adUnitIdTemp);
             } else {
             window.alert('激励视频广告取消关闭，不发放奖励');
             }
       });		
	},

    showVidoeAD: function ()
	{
         window.videoAd.load();
         window.videoAd.show();
         window.alert("展示激励视频");

    },
    //End
});