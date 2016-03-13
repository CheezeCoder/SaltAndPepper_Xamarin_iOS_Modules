using System;
using System.Collections.Generic;
using UIKit;

namespace CustomCellTableView 
{
	///<summary>
	/// Our subclassed custom UITableViewCell.  W need to subclass this cell to setup its special properties and establish 
	/// its constraints so that it sizes properly.
	///</summary>
	public class TableViewCell : UITableViewCell
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The image of this cell.
		/// </summary>
		private readonly UIImageView image;
		/// <summary>
		/// The Main header of this cell
		/// </summary>
		private readonly UILabel header;
		/// <summary>
		/// The subtitle of this cell
		/// </summary>
		private readonly UILabel subtitle;
		/// <summary>
		/// A label to represent a month data.
		/// </summary>
		private readonly UILabel month;
		/// <summary>
		/// A lable to represent a given date from data
		/// </summary>
		private readonly UILabel date;
		/// <summary>
		/// A label to represent a given time from data.
		/// </summary>
		private readonly UILabel time;
		/// <summary>
		/// A box to house the month label within.
		/// </summary>
		private readonly UIView calendarTop;
		/// <summary>
		/// A box to hosue the date lable within.
		/// </summary>
		private readonly UIView calendarBottom;
		/// <summary>
		/// A helper boolean to establish when the constraints have been updated the first time or not.
		/// </summary>
		private Boolean didUpdateConstraints;
		/// <summary>
		/// A float to help us calculate and reuse the aspect ratio of the image for this cell.
		/// </summary>
		private float imageAspect;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomCellTableView.TableViewCell"/> class.  Instanciates our cell members, calls the 
		/// cells init method and sets our auto resizing masks to false so that we can use the Auto Layouts.   Then we call SetNeedUpdateConstraints
		/// which is an virtual method for UITableCell that can be overriden to help set up our constraints.
		/// </summary>
		public TableViewCell (string reuseIdentifier) : base(UITableViewCellStyle.Default, reuseIdentifier)
		{
			image 		 	= new UIImageView ();
			header 			= new UILabel ();
			subtitle 		= new UILabel ();
			month 			= new UILabel ();
			date 			= new UILabel ();
			time 			= new UILabel ();
			calendarTop 		= new UIView ();
			calendarBottom 		= new UIView ();


			initCell ();


			foreach (UIView view in ContentView.Subviews) {
				view.TranslatesAutoresizingMaskIntoConstraints = false;
			}
			month.TranslatesAutoresizingMaskIntoConstraints = false;
			date.TranslatesAutoresizingMaskIntoConstraints 	= false;
			AutoresizingMask 				= UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			ContentView.SetNeedsUpdateConstraints ();



		}

		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets up our aesthetics for the class.  Sets our background colors essentially. 
		/// </summary>
		public override void LayoutSubviews ()
		{
			calendarTop.BackgroundColor = UIColor.DarkGray;
			calendarBottom.BackgroundColor = UIColor.LightGray;
			base.LayoutSubviews ();
		}

		/// <summary>
		/// We override the UpdateConstraints to allow us to only set up our constraint rules one time.  Since 
		/// we need to use this method to properly call our constraint rules at the right time we use a boolean
		/// as a flag so that we only fix our auto layout once.  Afterwards UpdateConstraints runs as normal. 
		/// </summary>
		public override void UpdateConstraints ()
		{
			if (NeedsUpdateConstraints () && !didUpdateConstraints) {
				setConstraints ();
				didUpdateConstraints = true;
			}
			base.UpdateConstraints ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Our public API.  This method allows the TableViewSource to update the cell with the needed information from the database at run time
		/// in the create cell factory of TableViewSource.  We also make a call to a private method (resizeImage) resize our image here just to 
		/// make it look good.  
		/// </summary>
		/// <param name="image">Image.</param>
		/// <param name="header">Header.</param>
		/// <param name="subtitle">Subtitle.</param>
		/// <param name="date">Date.</param>
		/// <param name="month">Month.</param>
		/// <param name="time">Time.</param>
		public void updateCell(UIImage image, string header, string subtitle, string date, string month, string time )
		{
			this.image.Image 	= image;
			this.header.Text 	= header;
			this.subtitle.Text 	= subtitle;
			this.date.Text 		= date;
			this.month.Text 	= month;
			this.time.Text 		= time;

			this.image.Image = resizeImage (this.image.Image, new CoreGraphics.CGSize (this.image.Image.Size.Width / 2, this.image.Image.Size.Height / 2));

			imageAspect = (float)image.Size.Width / (float)image.Size.Height;

		}

		/// <summary>
		/// This method allows us to resize the image.  For the sake of this example this method works fine but ideally 
		/// there should be checks in for minimum width and heights for the image.  
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="img">Image.</param>
		/// <param name="newSize">New size.</param>
		private static UIImage resizeImage(UIImage img, CoreGraphics.CGSize newSize)
		{
			UIGraphics.BeginImageContext (newSize);
			img.Draw(new CoreGraphics.CGRect(0,0, newSize.Width, newSize.Height));
			UIImage resizedImg = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();

			return resizedImg;
		}

		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// Initiates any non constructor sensitve members of the class.  This is where we add our subviews and set up our nifty little
		/// calebdar block heirarchy in the cell. 
		/// </summary>
		private void initCell()
		{
			didUpdateConstraints 	= false;


			calendarTop.AddSubview (month);
			calendarBottom.AddSubview (date);

			ContentView.AddSubviews (new UIView[] {
				image,
				header,
				subtitle,
				time,
				calendarTop,
				calendarBottom
			});

			return;
		}

		/// <summary>
		/// Our Auto Layout center.  This is where we set all of the size and layout rules of the cell.  Using anchors which unfortunately
		/// makes our app only good in iOS 9+ but anchours are a great and ledgible way of setting up constraints.  We grab our content views
		/// margin guides so we can snap our elements correctly, then begin assembling our rules.  Design how your cell should look first then
		/// you can come in here and set this up.  Reads left to right with the first item acting as the desired target and the item in the
		/// method arguments as the reference item.  So for the first constraint we use our content views leading (or left) anchor and bind
		/// our image's leading (or left) anchor together effectively sayin our image should always be up against the left most margin edge of 
		/// the cells content view. 
		/// </summary>
		private void setConstraints()
		{

			var margins 		= ContentView.LayoutMarginsGuide;
			var imageMargin 	= image.LayoutMarginsGuide;
			var headerMargin 	= header.LayoutMarginsGuide;
			var timeMargin 		= time.LayoutMarginsGuide;

			//Layouts for our image.
			image.LeadingAnchor.ConstraintEqualTo (margins.LeadingAnchor).Active 			= true;
			image.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active 			= true;
			image.TopAnchor.ConstraintEqualTo (margins.TopAnchor).Active 				= true;
			image.WidthAnchor.ConstraintEqualTo(image.HeightAnchor, imageAspect).Active 		= true;

			//Layouts for our header and subtitle.
			header.LeadingAnchor.ConstraintEqualTo (image.TrailingAnchor, 10).Active 		= true;
			header.TopAnchor.ConstraintEqualTo (margins.TopAnchor, 10).Active 			= true;
			header.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 2.0f / 5.0f).Active 		= true;
			subtitle.TopAnchor.ConstraintEqualTo (header.BottomAnchor, 10).Active 			= true;
			subtitle.LeftAnchor.ConstraintEqualTo (header.LeftAnchor).Active 			= true;
			subtitle.WidthAnchor.ConstraintEqualTo (header.WidthAnchor).Active 			= true;

			//Layouts for our Calendar Top container
			calendarTop.TrailingAnchor.ConstraintEqualTo (time.LeadingAnchor, -10).Active 		= true;
			calendarTop.TopAnchor.ConstraintEqualTo (margins.TopAnchor).Active 			= true;
			calendarTop.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 1.0f / 5.0f).Active 	= true;
			calendarTop.HeightAnchor.ConstraintEqualTo (margins.HeightAnchor, 0.5f).Active 		= true;
			calendarTop.BottomAnchor.ConstraintEqualTo (calendarBottom.TopAnchor).Active 		= true;

			//Layouts for our Calendar Bottom container
			calendarBottom.TrailingAnchor.ConstraintEqualTo (time.LeadingAnchor, -10).Active 	= true;
			calendarBottom.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active 		= true;
			calendarBottom.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 1.0f / 5.0f).Active 	= true;
			calendarBottom.HeightAnchor.ConstraintEqualTo (margins.HeightAnchor, 0.5f).Active 	= true;

			//Layouts for our date and month labels.
			date.CenterYAnchor.ConstraintEqualTo (calendarBottom.CenterYAnchor).Active 		= true;
			date.CenterXAnchor.ConstraintEqualTo (calendarBottom.CenterXAnchor).Active 		= true;
			month.CenterYAnchor.ConstraintEqualTo (calendarTop.CenterYAnchor).Active 		= true;
			month.CenterXAnchor.ConstraintEqualTo (calendarTop.CenterXAnchor).Active 		= true;

			//Layouts for our time label.
			time.TrailingAnchor.ConstraintEqualTo (margins.TrailingAnchor).Active 			= true;
			time.CenterYAnchor.ConstraintEqualTo (margins.CenterYAnchor).Active 			= true;

		}
			
	}
}