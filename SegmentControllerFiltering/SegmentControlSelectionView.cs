using System;
using UIKit;

namespace SegmentControllerFiltering
{
	///<summary>
	/// The SUbclassed UISegmentController to demonstrate the programatic addition and use of a UISegmentController.
	///</summary>
	public class SegmentControlSelectionView : UISegmentedControl
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Our event for when a value on the UISegmentController index is changed.  The API for our implementaion of the UISegmentController.
		/// </summary>
		public event EventHandler valueChanged;
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentControllerFiltering.SegmentControlSelectionView"/> class.
		/// Sets the inital segment selected to the Segment at index 0.
		/// </summary>
		public SegmentControlSelectionView ()
		{
			addSegmentSections ();
			this.SelectedSegment = 0;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Here we subscribe to UISegmentControls ValueChanged event and update the SelectedSegment
		/// accordingly.  We also use this to call our event to broadcast via our API or Event that
		/// an index has been changed.
		/// </summary>
		public override void LayoutSubviews ()
		{
			this.ValueChanged += (sender, e) => {
				var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
				valueChanged(this, e);
			};
			base.LayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// Adds the segment sections.
		/// </summary>
		private void addSegmentSections()
		{
			InsertSegment ("One", 	0, true);
			InsertSegment ("Two", 	1, true);
			InsertSegment ("Three", 2, true);
			InsertSegment ("Four", 	3, true);
		}
	}
}

