using Plugin.InAppBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordGeneratorMAUI.DataAccess
{
    internal sealed class PurchaseManager
    {
        private static IInAppBilling _billing;

        private static readonly string _productId_ChordStarProMembership = "CSP_000001";

        private static bool _isPurchased = false;
        private static IEnumerable<InAppBillingPurchase> _inAppPurchases = null;


        static PurchaseManager()
        {
            Task.Factory.StartNew(Initialize);
        }

        private static readonly PurchaseManager _instance = new PurchaseManager();
        internal static PurchaseManager Instance { get { return _instance; } }

        private static async void Initialize()
        {
            try
            {
                if (!CrossInAppBilling.IsSupported)
                    return;

                _billing = CrossInAppBilling.Current;
                _billing.InTestingMode = true; // TODO: remove this after testing

                var connected = _billing.ConnectAsync().Result;
                if (!connected)
                    return;

                // Get user purchase info
                _inAppPurchases = await _billing.GetPurchasesAsync(ItemType.InAppPurchase);
                _isPurchased = _inAppPurchases.Any((p) => p.ProductId == _productId_ChordStarProMembership);

                var n = _inAppPurchases.First().ApplicationUsername;
            }
            catch (InAppBillingPurchaseException pEx)
            {
                //Handle IAP Billing Exception
            }
            catch (Exception ex)
            {
                //Something has gone wrong
            }
            finally
            {
                await _billing.DisconnectAsync();
            }
        }

        //

        internal async Task<bool> MakePurchase()
        {
            try
            {
                //if (_isPurchased)
                //    return false;

                var connected = await _billing.ConnectAsync();
                if (!connected)
                    return false;

                var newPurchase = await _billing.PurchaseAsync(_productId_ChordStarProMembership, ItemType.InAppPurchase);

                if (newPurchase != null)
                {
                    return true;
                }

                return false;
            }
            catch (InAppBillingPurchaseException pEx)
            {
                //Handle IAP Billing Exception
                return false;
            }
            catch (Exception ex)
            {
                //Something has gone wrong
                return false;
            }
            finally
            {
                await _billing.DisconnectAsync();
            }
        }
    }
}
