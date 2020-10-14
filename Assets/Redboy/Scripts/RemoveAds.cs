// DecompilerFi decompiler from Assembly-CSharp.dll class: RemoveAds
// SourcesPostProcessor 

using System;
using UnityEngine;
//using UnityEngine.Purchasing;

public class RemoveAds : MonoBehaviour//, IStoreListener
{
	public static RemoveAds reAds;



	//private static IStoreController m_StoreController;

//	private static IExtensionProvider m_StoreExtensionProvider;

	public static string remove_Ads = "remove_ads";

	public static string itemSkip = "item_skip";

	private void Awake()
	{
		reAds = this;
		if (!PlayerPrefs.HasKey("buyRemoveAds"))
		{
			PlayerPrefs.SetInt("buyRemoveAds", 0);
			PlayerPrefs.SetInt("itemSkip", 3);
			PlayerPrefs.Save();
		}
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
	}

	// private void Start()
	// {
	// 	InitializePurchasing();
	
	// }

	// public void InitializePurchasing()
	// {
	// 	ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
	// 	configurationBuilder.AddProduct(remove_Ads, ProductType.NonConsumable);
	// 	configurationBuilder.AddProduct(itemSkip, ProductType.Consumable);
	// 	UnityPurchasing.Initialize(this, configurationBuilder);
	// }

	// private bool IsInitialized()
	// {
	// 	return m_StoreController != null && m_StoreExtensionProvider != null;
	// }

	public void BuyRemoveAds()
	{
		BuyProductID(remove_Ads);
	}

	public void BuyItemSkip()
	{
		BuyProductID(itemSkip);
	}

	private void BuyProductID(string productId)
	 {
	// 	if (IsInitialized())
	// 	{
	// 		Product product = m_StoreController.products.WithID(productId);
	// 		if (product != null && product.availableToPurchase)
	// 		{
	// 			m_StoreController.InitiatePurchase(product);
	// 			UnityEngine.Debug.Log("1");
	// 		}
	// 		else
	// 		{
	// 			UnityEngine.Debug.Log("Loi: khong co san phan hoac san pham khong ton tai tren store");
	// 		}
	// 	}
	// 	else
	// 	{
	// 		UnityEngine.Debug.Log("Loi: chua khoi tao Unity Purchasing day du");
	// 	}
	}

	// public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	// {
	// 	UnityEngine.Debug.Log("OnInitialized: PASS");
	// 	m_StoreController = controller;
	// 	m_StoreExtensionProvider = extensions;
	// }

	// public void OnInitializeFailed(InitializationFailureReason error)
	// {
	// 	UnityEngine.Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	// }

	// public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	// {
	// 	if (string.Equals(args.purchasedProduct.definition.id, remove_Ads, StringComparison.Ordinal))
	// 	{
	// 		UnityEngine.Debug.Log("MuaThanhCong");
	// 		buttonStartGame.btnSG.btnNoAds.SetActive(value: false);
	// 		PlayerPrefs.SetInt("buyRemoveAds", 1);
	// 		PlayerPrefs.Save();
	// 	}
	// 	else
	// 	{
	// 		UnityEngine.Debug.Log("ProcessPurchase: FAIL");
	// 	}
	// 	if (string.Equals(args.purchasedProduct.definition.id, itemSkip, StringComparison.Ordinal))
	// 	{
	// 		UnityEngine.Debug.Log("MuaThanhCong");
	// 		PlayerPrefs.SetInt("itemSkip", PlayerPrefs.GetInt("itemSkip") + 5);
	// 		PlayerPrefs.Save();
	// 	}
	// 	else
	// 	{
	// 		UnityEngine.Debug.Log("ProcessPurchase: FAIL");
	// 	}
	// 	return PurchaseProcessingResult.Complete;
	// }

	// public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	// {
	// 	UnityEngine.Debug.Log($"OnPurchaseFailed: FAIL. Product: '{product.definition.storeSpecificId}', PurchaseFailureReason: {failureReason}");
	// }
}
