using System;
using System.Collections.Generic;
using UIKit;

namespace CustomCellTableView 
{
	///<summary>
	///
	///</summary>
	public class TableViewCell : UITableViewCell
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly UIImageView image;
		private readonly UILabel header;
		private readonly UILabel subtitle;
		private readonly UILabel month;
		private readonly UILabel date;
		private readonly UILabel time;
		private readonly UIView calendarTop;
		private readonly UIView calendarBottom;
		private Boolean didUpdateConstraints;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomCellTableView.TableViewCell"/> class.
		/// </summary>
		public TableViewCell (string reuseIdentifier) : base(UITableViewCellStyle.Default, reuseIdentifier)
		{
			didUpdateConstraints = false;
			image 		= new UIImageView ();
			header 		= new UILabel ();
			subtitle 	= new UILabel ();
			month 		= new UILabel ();
			date 		= new UILabel ();
			time 		= new UILabel ();
			calendarTop 	= new UIView ();
			calendarBottom 	= new UIView ();

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



			foreach (UIView view in ContentView.Subviews) {
				view.TranslatesAutoresizingMaskIntoConstraints = false;
			}
			month.TranslatesAutoresizingMaskIntoConstraints = false;
			date.TranslatesAutoresizingMaskIntoConstraints 	= false;
			AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			ContentView.SetNeedsLayout ();
			ContentView.LayoutIfNeeded ();
			ContentView.SetNeedsUpdateConstraints ();



		}

		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void LayoutSubviews ()
		{
			calendarTop.BackgroundColor = UIColor.DarkGray;
			calendarBottom.BackgroundColor = UIColor.LightGray;
			base.LayoutSubviews ();
		}

		public override void UpdateConstraints ()
		{
			if (NeedsUpdateConstraints () && !didUpdateConstraints) {
				setConstraints ();
				didUpdateConstraints = true;
			}
			base.UpdateConstraints ();
			base.UpdateConstraints ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		public void updateCell(UIImage image, string header, string subtitle, string date, string month, string time )
		{
			this.image.Image 	= image;
			this.header.Text 	= header;
			this.subtitle.Text 	= subtitle;
			this.date.Text 		= date;
			this.month.Text 	= month;
			this.time.Text 		= time;
		}

		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		private void setConstraints()
		{
			var constraints = new List<NSLayoutConstraint> ();


			var margins = ContentView.LayoutMarginsGuide;
			var imageMargin = image.LayoutMarginsGuide;
			var headerMargin = header.LayoutMarginsGuide;
			var timeMargin = time.LayoutMarginsGuide;

			image.LeadingAnchor.ConstraintEqualTo (margins.LeadingAnchor).Active = true;
			image.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active = true;
			image.TopAnchor.ConstraintEqualTo (margins.TopAnchor).Active = true;
			image.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 1.0f / 5.0f).Active = true;
			image.HeightAnchor.ConstraintEqualTo (image.WidthAnchor).Active = true;

			header.LeadingAnchor.ConstraintEqualTo (image.TrailingAnchor, 10).Active = true;
			header.TopAnchor.ConstraintEqualTo (margins.TopAnchor, 10).Active = true;
			header.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 2.0f / 5.0f).Active = true;
			subtitle.TopAnchor.ConstraintEqualTo (header.BottomAnchor, 10).Active = true;
			subtitle.LeftAnchor.ConstraintEqualTo (header.LeftAnchor).Active = true;
			subtitle.WidthAnchor.ConstraintEqualTo (header.WidthAnchor).Active = true;

			calendarTop.TrailingAnchor.ConstraintEqualTo (time.LeadingAnchor, -10).Active = true;
			calendarTop.TopAnchor.ConstraintEqualTo (margins.TopAnchor).Active = true;
			calendarTop.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 1.0f / 5.0f).Active = true;
			calendarTop.HeightAnchor.ConstraintEqualTo (margins.HeightAnchor, 0.5f).Active = true;

			calendarTop.BottomAnchor.ConstraintEqualTo (calendarBottom.TopAnchor).Active = true;

			calendarBottom.TrailingAnchor.ConstraintEqualTo (time.LeadingAnchor, -10).Active = true;
			calendarBottom.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active = true;
			calendarBottom.WidthAnchor.ConstraintEqualTo (margins.WidthAnchor, 1.0f / 5.0f).Active = true;
			calendarBottom.HeightAnchor.ConstraintEqualTo (margins.HeightAnchor, 0.5f).Active = true;

			date.CenterYAnchor.ConstraintEqualTo (calendarBottom.CenterYAnchor).Active = true;
			date.CenterXAnchor.ConstraintEqualTo (calendarBottom.CenterXAnchor).Active = true;
			month.CenterYAnchor.ConstraintEqualTo (calendarTop.CenterYAnchor).Active = true;
			month.CenterXAnchor.ConstraintEqualTo (calendarTop.CenterXAnchor).Active = true;

			time.TrailingAnchor.ConstraintEqualTo (margins.TrailingAnchor).Active = true;
			time.CenterYAnchor.ConstraintEqualTo (margins.CenterYAnchor).Active = true;





////			var imageLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.LeadingMargin,
//				NSLayoutRelation.Equal,
//				image,
//				NSLayoutAttribute.Leading,
//				1,
//				0
//			)
//			);
//
////			var imageBottom =
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.BottomMargin,
//				NSLayoutRelation.Equal,
//				image,
//				NSLayoutAttribute.Bottom,
//				1,
//				0
//			));
//
////			var iamgeTop =
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.TopMargin,
//				NSLayoutRelation.Equal,
//				image,
//				NSLayoutAttribute.Top,
//				1,
//				0
//			));
//
////			var imageWidth = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.Width,
//				NSLayoutRelation.Equal,
//				image,
//				NSLayoutAttribute.Width,
//				1.0f / 5.0f,
//				0
//			));
//
////			var headerLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				image,
//				NSLayoutAttribute.Trailing,
//				NSLayoutRelation.Equal,
//				header,
//				NSLayoutAttribute.Leading,
//				1,
//				8
//			));
//
////			var headerTop = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.TopMargin,
//				NSLayoutRelation.Equal,
//				header,
//				NSLayoutAttribute.Top,
//				1,
//				0
//			));
//
////			var headerBottom = 
//			constraints.Add (NSLayoutConstraint.Create (
//				subtitle,
//				NSLayoutAttribute.Top,
//				NSLayoutRelation.Equal,
//				header,
//				NSLayoutAttribute.Bottom,
//				1,
//				0
//			));
//
////			var headerWidth = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.Width,
//				NSLayoutRelation.Equal,
//				header,
//				NSLayoutAttribute.Width,
//				2.0f / 5.0f,
//				0
//			));
//
////			var subtitleLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				image,
//				NSLayoutAttribute.Trailing,
//				NSLayoutRelation.Equal,
//				subtitle,
//				NSLayoutAttribute.Leading,
//				1,
//				0
//			));
//
////			var subtitleBottom = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.BottomMargin,
//				NSLayoutRelation.Equal,
//				subtitle,
//				NSLayoutAttribute.Bottom,
//				1,
//				0
//			));
//
////			var subtitleWidth = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.Width,
//				NSLayoutRelation.Equal,
//				subtitle,
//				NSLayoutAttribute.Width,
//				2.0f / 5.0f,
//				0
//			));
//
////			var topCalendarTop = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.TopMargin,
//				NSLayoutRelation.Equal,
//				calendarTop,
//				NSLayoutAttribute.Top,
//				1,
//				0
//			));
//
////			var topCalendarLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				header,
//				NSLayoutAttribute.Trailing,
//				NSLayoutRelation.Equal,
//				calendarTop,
//				NSLayoutAttribute.Leading,
//				1,
//				0
//			));
//
////			var topCalendarBottom = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarBottom,
//				NSLayoutAttribute.Top,
//				NSLayoutRelation.Equal,
//				calendarTop,
//				NSLayoutAttribute.Bottom,
//				1,
//				0
//			));
//
////			var topCalendarWidth = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.Width,
//				NSLayoutRelation.Equal,
//				calendarTop,
//				NSLayoutAttribute.Width,
//				1.0f / 5.0f,
//				0
//			));
//
////			var bottomCalendarTop =
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarTop,
//				NSLayoutAttribute.Bottom,
//				NSLayoutRelation.Equal,
//				calendarBottom,
//				NSLayoutAttribute.Top,
//				1,
//				0
//			));
//
////			var bottomCalendarLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				subtitle,
//				NSLayoutAttribute.Trailing,
//				NSLayoutRelation.Equal,
//				calendarBottom,
//				NSLayoutAttribute.Leading,
//				1,
//				0
//			));
//
////			var bottomCalendarBottom = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.BottomMargin,
//				NSLayoutRelation.Equal,
//				calendarBottom,
//				NSLayoutAttribute.Bottom,
//				1,
//				0
//			));
//
////			var bottomCalendarWidth =
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.Width,
//				NSLayoutRelation.Equal,
//				calendarBottom,
//				NSLayoutAttribute.Width,
//				1.0f / 5.0f,
//				0
//			));
//
////			var monthCenterX = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarTop,
//				NSLayoutAttribute.CenterX,
//				NSLayoutRelation.Equal,
//				month,
//				NSLayoutAttribute.CenterX,
//				1,
//				0
//			));
//
////			var monthCenterY = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarTop,
//				NSLayoutAttribute.CenterY,
//				NSLayoutRelation.Equal,
//				month,
//				NSLayoutAttribute.CenterY,
//				1,
//				0
//			));
//
////			var dateCenterX = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarBottom,
//				NSLayoutAttribute.CenterX,
//				NSLayoutRelation.Equal,
//				date,
//				NSLayoutAttribute.CenterX,
//				1,
//				0
//			));
//
////			var dateCenterY = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarBottom,
//				NSLayoutAttribute.CenterY,
//				NSLayoutRelation.Equal,
//				date,
//				NSLayoutAttribute.CenterY,
//				1,
//				0
//			));
//
////			var timeLeft = 
//			constraints.Add (NSLayoutConstraint.Create (
//				calendarBottom,
//				NSLayoutAttribute.Trailing,
//				NSLayoutRelation.Equal,
//				time,
//				NSLayoutAttribute.Leading,
//				1,
//				0
//			));
//
////			var timeRight = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.TrailingMargin,
//				NSLayoutRelation.Equal,
//				time,
//				NSLayoutAttribute.Trailing,
//				1,
//				0
//			));
//
////			var timeCenter = 
//			constraints.Add (NSLayoutConstraint.Create (
//				this.ContentView,
//				NSLayoutAttribute.CenterYWithinMargins,
//				NSLayoutRelation.Equal,
//				time,
//				NSLayoutAttribute.CenterY,
//				1,
//				0
//			));

			ContentView.AddConstraints (constraints.ToArray ());
		}
			
	}
}