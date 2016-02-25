﻿using System;
using UIKit;

namespace CustomSegmentController
{
	///<summary>
	///
	///</summary>
	public class ToolBarView : UIToolbar
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly SegmentControlSelectionView segConView;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================

		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomSegmentController.ToolBarView"/> class.
		/// </summary>
		public ToolBarView ()
		{
			this.segConView = new SegmentControlSelectionView ();
			this.AddSubview (this.segConView);
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			this.segConView.Frame 			= new CoreGraphics.CGRect (this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Frame.Height);
			this.segConView.Center 			= new CoreGraphics.CGPoint (this.Frame.Size.Width / 2, this.segConView.Center.Y);
			this.segConView.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}

