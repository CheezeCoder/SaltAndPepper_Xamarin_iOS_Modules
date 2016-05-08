using System;
using UIKit;
using Contacts;

namespace ContactPicker 
{
	///<summary>
	/// Encapsulates our Access Authorization for the user's Contacts on their device. This class provides an API for the rest of the application
	/// to check if access was granted for contacts or not.  We need to extend UIViewController to get access to the thread invocation methods.
	///</summary>
	public class AccessAuth : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The access state of the users contacts.
		/// </summary>
		private bool access;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactPicker.AccessAuth"/> class.
		/// </summary>
		public AccessAuth ()
		{
			access = false;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Our exposed method to check if access was granted or not.
		/// </summary>
		/// <returns><c>true</c>, if contacts access was requested, <c>false</c> otherwise.</returns>
		public bool requestContactsAccess()
		{
			checkAccess ();
			if (!access) {
				requestAccess ();
			}

			return access;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

		/// <summary>
		/// This method attempts to request access if the access level is not granted. If the user accepts we
		/// set our access boolean to true and continue otherwise we force an alert message to be displayed.
		/// </summary>
		private void requestAccess()
		{
			var store = new CNContactStore ();
			store.RequestAccess (CNEntityType.Contacts, (auth, error) => {
				if(auth){
					access = true;
				}
				else{
					
					showMessage(error);
				}
			});

		}

		/// <summary>
		/// Redirects the view controller to a VC that informs the user the app cannot be used without access to the users contacts.
		/// </summary>
		/// <param name="a">The alpha component.</param>
		private void reDirectToNoAccess(UIAlertAction a)
		{
			if (!access) {
				UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController (new AccessDeniedVC (), true, null);
			}
		}

		/// <summary>
		/// We need to invoke this on the main thread as it access UI components.  We get the root view controller and present an alert
		/// informing the user that they need to go into settings and change their access to grant this application access to the contacts.
		/// We set the call back of the message to force the user to the No Access Display as th app does not want to allow the user to continue
		/// until they have granted contact access.
		/// </summary>
		/// <param name="error">Error.</param>
		private void showMessage(Foundation.NSError error)
		{
			InvokeOnMainThread(()=> {
				var rvc = UIApplication.SharedApplication.KeyWindow.RootViewController;
				var errorMsg 		= error.LocalizedDescription + "\n\nPlease allow the app to access your contacts through settings";
				var alertController 	= UIAlertController.Create ("Contact Picker", errorMsg, UIAlertControllerStyle.Alert);
				var dismiss 		= UIAlertAction.Create ("OK", UIAlertActionStyle.Default,reDirectToNoAccess);


				alertController.AddAction( dismiss);

				if (rvc != null) {
					rvc.PresentViewController (alertController, true, null);
				}	
			});


		}

		/// <summary>
		/// This method is the base method that makes a check to see if the user has granted access to their contacts for this application or not.
		/// We set our boolean depending on the state.
		/// </summary>
		private void checkAccess()
		{
			var authStatus = CNContactStore.GetAuthorizationStatus (CNEntityType.Contacts);

			switch (authStatus) {
				case CNAuthorizationStatus.Authorized:
					access = true;
					break;
				case CNAuthorizationStatus.Denied:
				case CNAuthorizationStatus.NotDetermined:
					access = false;
					break;
				default:
					access = false;
					break;
			}
		}
	}
}