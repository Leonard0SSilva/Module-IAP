using System;
using UnityEngine;

namespace Studio.ModuleIAP
{
    using Studio.CoreInfra;

    /// <summary>
    /// Concrete implementation of IIAPService using Unity IAP.
    /// This class lives in Module-IAP but depends on interfaces from Core-Infra.
    /// 
    /// The Game project wires this up at startup:
    ///   ServiceLocator.Register&lt;IIAPService&gt;(new UnityIAPService());
    /// </summary>
    public class UnityIAPService : IIAPService
    {
        private bool _isInitialized;

        public bool IsInitialized => _isInitialized;

        public void Initialize()
        {
            // In a real project, this would call:
            // UnityPurchasing.Initialize(this, builder);
            Debug.Log("[UnityIAPService] Initialized and connected to store.");
            _isInitialized = true;
        }

        public void FetchProducts(Action<ProductInfo[]> onFetched)
        {
            Debug.Log("[UnityIAPService] Fetching products from store...");

            // Simulated product catalog
            var products = new[]
            {
                new ProductInfo
                {
                    ProductId = "com.studio.game.gems_100",
                    Title = "100 Gems",
                    Description = "A small pile of gems",
                    FormattedPrice = "$0.99"
                },
                new ProductInfo
                {
                    ProductId = "com.studio.game.gems_500",
                    Title = "500 Gems",
                    Description = "A bag of gems",
                    FormattedPrice = "$4.99"
                },
                new ProductInfo
                {
                    ProductId = "com.studio.game.no_ads",
                    Title = "Remove Ads",
                    Description = "Permanently remove all ads",
                    FormattedPrice = "$2.99"
                }
            };

            onFetched?.Invoke(products);
        }

        public void Purchase(string productId, Action<bool> onComplete)
        {
            Debug.Log($"[UnityIAPService] Initiating purchase: {productId}");
            // In production: UnityPurchasing.InitiatePurchase(productId);
            onComplete?.Invoke(true);
        }

        public void RestorePurchases(Action<bool> onComplete)
        {
            Debug.Log("[UnityIAPService] Restoring purchases...");
            // In production: extensions.GetExtension<IAppleExtensions>().RestoreTransactions(...)
            onComplete?.Invoke(true);
        }
    }
}
