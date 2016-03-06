using System;
using System.Collections.Generic;
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
		/// <summary>
		/// This list acts as a fake local data source for one of our 2 segment controller states.  
		/// </summary>
		private readonly List<string> segmentValuesOne 	= new List<string>(){"One", "Two", "Three", "Four"};
		/// <summary>
		/// This list acts as a fake local data source for one of our 2 segment controller states.
		/// </summary>
		private readonly List<string> segmentValuesTwo 	= new List<string>(){"Six", "Seven", "Eight"};
		/// <summary>
		/// This list represents the current state of the segment controller by taking on either segmentvalueOne or segmentValueTwo's
		/// properties. 
		/// </summary>
		private List<string> currentSegmentController;
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
			currentSegmentController = segmentValuesOne;
			addSegmentSections ();
			SelectedSegment = 0;
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
			ValueChanged += (sender, e)=> valueChanged(this, e);
			base.LayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// This is another method of the SegmentControlSelectionView's api.  This will allow external controller classes or parents to 
		/// update the segment controller.
		/// </summary>
		public void updateSegmentController(bool choice)
		{
			currentSegmentController = choice ? segmentValuesOne : segmentValuesTwo;
			addSegmentSections ();
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// Adds the segment sections. Loops through the current segment control state List and updates the segment Controller
		/// accordingly. 
		/// </summary>
		private void addSegmentSections()
		{
			RemoveAllSegments ();
			foreach (string segment in currentSegmentController) {
				InsertSegment (segment, NumberOfSegments, true);
			}
		}
	}
}

