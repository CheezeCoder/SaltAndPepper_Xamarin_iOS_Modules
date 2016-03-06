using System;
using UIKit;

namespace SegmentControllerFiltering 
{
	///<summary>
	/// This view controller represents the view for where the options are to be chosen. 
	///</summary>
	public class OptionsViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// View that houses the content for this controller.
		/// </summary>
		private readonly UIView choiceView;
		/// <summary>
		/// Button object to allow the user to choose choice one. 
		/// </summary>
		private readonly UIButton choiceOne;
		/// <summary>
		/// Button object to allow the user to choose choice two. 
		/// </summary>
		private readonly UIButton choiceTwo;
		/// <summary>
		/// The default height in pts of a so called "Action Sheet" row.  As per <see cref="http://iosdesign.ivomynttinen.com"/>
		/// </summary>
		private readonly int iosDefaultActionSheetRowHeight = 57;
		/// <summary>
		/// The text to display for the choice one button.
		/// </summary>
		private readonly string choiceOneText = "Choose Choice One";
		/// <summary>
		/// The text to display for the choice two button.
		/// </summary>
		private readonly string choiceTwoText = "Choose Choice Two";
		/// <summary>
		/// The text to display in the navigation bar for this controller.
		/// </summary>
		private readonly string optionsViewTitleText = "Options";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The api handler to alert any listeners that one of the "options" buttons has been pressed.
		/// </summary>
		public event EventHandler choiceMade;

		/// <summary>
		/// Gets a value indicating whether the user has chosen choice one or choice two.  This acts as our communicator
		/// for this controller to let any parents or owners know what choice has been made. 
		/// </summary>
		/// <value><c>true</c> if choice one; otherwise, <c>false</c> if choice two.</value>
		public bool choice
		{
			get;
			private set;
		}
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentControllerFiltering.OptionsViewController"/> class.
		/// </summary>
		public OptionsViewController ()
		{
			this.choiceView = new UIView();
			this.choiceOne 	= new UIButton(UIButtonType.RoundedRect);
			this.choiceTwo 	= new UIButton(UIButtonType.RoundedRect);
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets the navigation bar title for this controler, adds our view for the content, and subsequently adds the label and button views to our 
		/// content view.  Sets the background color and enables the inner controller event listers for the buttons using anonymas fuctions to handle 
		/// them and setting our public choice property according to what button has been pressed. 
		/// </summary>
		public override void ViewDidLoad ()
		{
			this.Title = this.optionsViewTitleText;

			this.View.Add(this.choiceView);
			this.choiceView.AddSubview(this.choiceOne);
			this.choiceView.AddSubview(this.choiceTwo);
			this.View.BackgroundColor = UIColor.White;

			this.choiceOne.SetTitle(this.choiceOneText, UIControlState.Normal);
			this.choiceTwo.SetTitle(this.choiceTwoText, UIControlState.Normal);

			this.choiceOne.TouchDown += (object sender, EventArgs e) => {
				this.choice = true;
				choiceMade(sender, e);
			};

			this.choiceTwo.TouchDown += (object sender, EventArgs e) => {
				this.choice = false;
				choiceMade(sender, e);
			};
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Sets our view dimensions.  Uses center point to set center lables and set up our view correctly. 
		/// </summary>
		public override void ViewDidLayoutSubviews()
		{
			this.choiceView.Frame = this.View.Bounds;
			this.choiceOne.Frame = new CoreGraphics.CGRect(0, 0, this.choiceView.Frame.Width / 2, this.iosDefaultActionSheetRowHeight);
			this.choiceTwo.Frame = new CoreGraphics.CGRect(0, 0, this.choiceView.Frame.Width / 2, this.iosDefaultActionSheetRowHeight);
			this.choiceOne.Center = new CoreGraphics.CGPoint(this.choiceView.Frame.Width / 2, this.choiceView.Frame.Height / 2 - this.iosDefaultActionSheetRowHeight);
			this.choiceTwo.Center = new CoreGraphics.CGPoint(this.choiceView.Frame.Width / 2, this.choiceView.Frame.Height / 2 + this.iosDefaultActionSheetRowHeight);

			base.ViewDidLayoutSubviews();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}