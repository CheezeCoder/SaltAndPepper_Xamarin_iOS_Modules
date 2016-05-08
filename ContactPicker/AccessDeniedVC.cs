using System;
using UIKit;

namespace ContactPicker 
{
	///<summary>
	/// This simple messy view controller is just to demonstrate a possible way of gracefully handling the user denying access to their contacts.
	///</summary>
	public class AccessDeniedVC : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The title for our Navigation Controller / App.
		/// </summary>
		private readonly string title 		= "ContactPicker";
		/// <summary>
		/// The message to display on the view controller.
		/// </summary>
		private readonly string message 	= "This app cannot function without access to your contacts. Please allow access to ContactPicker in the settings";
		/// <summary>
		/// Label that houses our message to the user.
		/// </summary>
		private UILabel label;
		/// <summary>
		/// Notification token to listen for when the app becomes active so that we can always check if the user has granted access.
		/// </summary>
		private Foundation.NSObject onActiveStateNotificationToken;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactPicker.AccessDeniedVC"/> class.
		/// </summary>
		public AccessDeniedVC ()
		{
			label = new UILabel ();
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets the frame of our lable and text behaviour.  We also add this view controller as an observer for when the app becomes active again
		/// this way if the user switches out and update their contacts access for this app we can handle re granting use of the app to the user directly
		/// when they come back to our app.
		/// </summary>
		public override void ViewDidLoad ()
		{
			label.Frame 			= new CoreGraphics.CGRect (0, (View.Frame.Height / 2) - (DefaultiOSDimensions.cellHeight*3) / 2, View.Frame.Width, DefaultiOSDimensions.cellHeight*3);
			var mode 			= label.LineBreakMode;
			var lines 			= label.Lines;
			onActiveStateNotificationToken 	= Foundation.NSNotificationCenter.DefaultCenter.AddObserver (UIApplication.DidBecomeActiveNotification, checkAuthStatus);
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			label.Lines 			= 0;
			label.TextAlignment 		= UITextAlignment.Center;
			View.AddSubview (label);
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Sets some basic properties.
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{

			View.BackgroundColor 	= UIColor.White;
			Title 			= title;
			label.Text 		= message;
			base.ViewDidLayoutSubviews ();
		}

		/// <summary>
		/// The method to call when the app becomes in focus again.  We check to see if the user has updated their contacts access
		/// and pop this view controller if they have.
		/// </summary>
		/// <param name="notification">Notification.</param>
		public void checkAuthStatus(Foundation.NSNotification notification)
		{
			if(AppDelegate.Self.checkContactsAuth())
				this.NavigationController.PopViewController (true);
		}

		/// <summary>
		/// De allocate our observer when this view will dissapear.
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillDisappear (bool animated)
		{
			if (onActiveStateNotificationToken != null) {
				Foundation.NSNotificationCenter.DefaultCenter.RemoveObserver (onActiveStateNotificationToken);
			}
			base.ViewWillDisappear (animated);
		}
	
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}