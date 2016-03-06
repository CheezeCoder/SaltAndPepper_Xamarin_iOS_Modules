using System;
using UIKit;

namespace CustomOptionsPage 
{
	///<summary>
	/// This is the view controller that represents our view of what option is selected.  
	///</summary>
	public class ContentViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Button object to take the user to the options view controller.
		/// </summary>
		private UIBarButtonItem optionsButton;
		/// <summary>
		/// View that houses the content for this controller.
		/// </summary>
		private readonly UIView contentView;
		/// <summary>
		/// The label to show the update change from the options page.
		/// </summary>
		private readonly UILabel label;
		/// <summary>
		/// The text to display for the optionsButton.
		/// </summary>
		private readonly string optionsButtonText 		= "Options";
		/// <summary>
		/// The text to display in the navigation bar for this controller.
		/// </summary>
		private readonly string contentViewTitleText 		= "Content";
		/// <summary>
		/// The default height in pts of a so called "Action Sheet" row.  As per <see cref="http://iosdesign.ivomynttinen.com"/>
		/// </summary>
		private readonly int iosDefaultActionSheetRowHeight 	= 57;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The api handler to alert any listeners that the "options" button has been pressed.
		/// </summary>
		public event EventHandler buttonSelected;
		/// <summary>
		/// This boolean will dictate what text appears on the label for this controller and acts as a logic
		/// director for the our "fake" database information.
		/// </summary>
		private bool choice = true;
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomOptionsPage.ContentViewController"/> class.
		/// </summary>
		public ContentViewController ()
		{
			this.contentView 	= new UIView();
			this.label 		= new UILabel();
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Instanciates our options button and adds it to our navigation bars left button item, adds our content view to our controller, adds our
		/// label view to the content view and sets our navigation title and background colors. 
		/// </summary>
		public override void ViewDidLoad ()
		{
			this.optionsButton 	= new UIBarButtonItem(this.optionsButtonText,UIBarButtonItemStyle.Plain, buttonSelected);
			this.Add(this.contentView);
			this.contentView.AddSubview(this.label);
			this.Title = this.contentViewTitleText;
		
			this.View.BackgroundColor = UIColor.White;
			this.NavigationItem.SetLeftBarButtonItem(optionsButton, true);


			base.ViewDidLoad ();
		}

		/// <summary>
		/// Establishes our constraints and view sizes.  Sets the child view to the size of our Controller View.  Sets our
		/// our label size to half the size of our view width and to the given default action sheet row height.  We can then
		/// set our label to the center of the page using the views center point and setting it with our labels center point.
		/// </summary>
		public override void ViewDidLayoutSubviews()
		{
			this.contentView.Frame = this.View.Bounds;
			this.label.Frame = new CoreGraphics.CGRect(0, 0, this.contentView.Frame.Width / 2, this.iosDefaultActionSheetRowHeight);
			this.label.Center = new CoreGraphics.CGPoint(this.contentView.Frame.Width / 2, this.contentView.Frame.Height / 2);
			base.ViewDidLayoutSubviews();
		}

		/// <summary>
		/// Sets up our simulated database content in two strings to represent one of two options chosen on the options page.  
		/// If our so called "logic director" bool is set to true it will display content one, if set to false it will display content two.  
		/// </summary>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void ViewWillAppear(bool animated)
		{
			const string contentTypeOne = "I am the main content One";
			const string contentTypeTwo = "I am the main content Two";
			this.label.Text = this.choice ? contentTypeOne : contentTypeTwo;

			base.ViewWillAppear(animated);
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// This is the only method for the api of this controller class and it allows our so called "logic director" to be set
		/// accordingly.  This updates our boolean for the class.  
		/// </summary>
		/// <param name="choice">true or false (true displays option 1, false displays option 2)</param>
		public void updateContent(bool choice)
		{
			this.choice = choice;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}