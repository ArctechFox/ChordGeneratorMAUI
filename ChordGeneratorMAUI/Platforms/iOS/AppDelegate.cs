using Foundation;
using GameKit;
using Google.MobileAds;
using StoreKit;
using UIKit;

namespace ChordGeneratorMAUI;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Plugin.InAppBilling.InAppBillingImplementation.OnShouldAddStorePayment = OnShouldAddStorePayment;
        var current = Plugin.InAppBilling.CrossInAppBilling.Current; // initializes

        MobileAds.SharedInstance.Start(CompletionHandler); // initialize admob

        return base.FinishedLaunching(application, launchOptions);
    }

    private void CompletionHandler(InitializationStatus status){}

    bool OnShouldAddStorePayment(SKPaymentQueue queue, SKPayment payment, SKProduct product)
    {
        // TODO: Process and check purchases?
        return true;
    }

}
