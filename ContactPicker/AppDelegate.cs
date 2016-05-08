using Foundation;
using UIKit;
using Contacts;

namespace ContactPicker  
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		/// <summary>
		/// Allows us to get a global reference to the app delegate in a short form from anywhere in the applicaiton.
		/// </summary>
		/// <value>The self.</value>
		public static AppDelegate Self { get; private set;}

		/// <summary>
		/// An authorization class that seperates the logic for requesting authorization to the Contacts of a user.
		/// </summary>
		public AccessAuth auth;

		/// <summary>
		/// Sets the main background color.  Here we programatically add a new instance of our subclassed 
		/// UINavigationController to the window root view controller property.  We then have to call
		/// the MakeKeyAndVisible method on window for it to load properly.  
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="application">Application.</param>
		/// <param name="launchOptions">Launch options.</param>
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Window 				= new UIWindow (UIScreen.MainScreen.Bounds);

			AppDelegate.Self 		= this;
			auth 				= new AccessAuth ();
			this.Window.BackgroundColor 	= UIColor.White;
			var nc 				= new NavigationController();
			Window.RootViewController 	= nc;

			Window.MakeKeyAndVisible ();

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		/// <summary>
		/// Runs a check to see if the user has granted access to the Contacts of a users device or not.
		/// </summary>
		/// <returns><c>true</c>, if contacts auth was granted, <c>false</c> otherwise.</returns>
		public bool checkContactsAuth()
		{
			return auth.requestContactsAccess ();
		}






	}
}


