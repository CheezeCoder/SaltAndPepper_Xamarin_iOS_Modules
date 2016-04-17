using System;
using UIKit;
using System.Collections.Generic;

namespace TwoSplitTableViewExtended 
{
	
	/// <summary>
	/// Representation of a cell type ofr Type Cell A.  These cells are specific to the bottom table view for when the ColorCellSource is active.
	/// </summary>
	public class CellA : TableViewRow
	{
		/// <summary>
		/// The Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelA;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellA"/> class.
		/// </summary>
		/// <param name="options">Options.</param>
		public CellA(List<UIColor> options) : base(options, TableViewRowType.A)
		{
			Cell = this;
			labelA = new UILabel ();
		}

		/// <summary>
		/// Lays out the subviews. Sets our label dimensions and adds it to the content view and then calls updateStateColro to set the correct color
		/// for the labels that should represent whatever state the cell is in.
		/// </summary>
		public override void LayoutSubviews ()
		{
			labelA.Frame = new CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding, 0, Frame.Width  - (DefaultiOSDimensions.cellPadding * 2), Frame.Height);
			ContentView.AddSubviews (new UIView[]{ labelA });	
			updateStateColor ();
			base.LayoutSubviews ();

		}

		/// <summary>
		/// Checks the state of this cell and sets its color accordingly from the color options available.
		/// </summary>
		private void updateStateColor()
		{
			labelA.BackgroundColor = state ? primaryStateColors [0] : secondaryStatColors [0];
		}

		/// <summary>
		/// Switchs the state of the cell to its opposite.
		/// </summary>
		public override void SwitchState ()
		{
			state = !state;
			updateStateColor ();
		}
	}

	public class CellB : TableViewRow
	{
		/// <summary>
		/// A Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelA;
		/// <summary>
		/// A Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelB;


		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellB"/> class.
		/// </summary>
		/// <param name="options">Options.</param>
		public CellB(List<UIColor> options) : base(options, TableViewRowType.B)
		{
			Cell = this;
			labelA = new UILabel ();
			labelB = new UILabel ();
		}

		/// <summary>
		/// Lays out the subviews. Sets our labels dimensions and adds it to them content view and then calls updateStateColor to set the correct color
		/// for the labels that should represent whatever state the cell is in.
		/// </summary>
		public override void LayoutSubviews ()
		{
			labelA.Frame = new CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding, 0, (Frame.Width / 2) - (DefaultiOSDimensions.cellPadding * 1.5), Frame.Height);
			labelB.Frame = new CoreGraphics.CGRect(Frame.Width/2 + DefaultiOSDimensions.cellPadding/2, 0, (Frame.Width/2)-(DefaultiOSDimensions.cellPadding * 1.5), Frame.Height); 
			ContentView.AddSubviews (new UIView[]{ labelA, labelB });
//			
			updateStateColor ();


			base.LayoutSubviews ();

		}

		/// <summary>
		/// Checks the state of this cell and sets its color accordingly from the color options available.
		/// </summary>
		private void updateStateColor()
		{
			labelA.BackgroundColor = state ? primaryStateColors [0] : secondaryStatColors [0];
			labelB.BackgroundColor = state ? primaryStateColors [1] : secondaryStatColors [1];
		}


		/// <summary>
		/// Switchs the state of the cell to its opposite.
		/// </summary>
		public override void SwitchState ()
		{
			state = !state;
			updateStateColor ();
		}
	}

	public class CellC : TableViewRow
	{
		/// <summary>
		/// A Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelA;
		/// <summary>
		/// A Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelB;
		/// <summary>
		/// A Label of the cell.  Used to represent its state.  Selected or not selected.  The label changes color depending on the state.
		/// </summary>
		private UILabel labelC;


		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellC"/> class.
		/// </summary>
		/// <param name="options">Options.</param>
		public CellC(List<UIColor> options) : base(options, TableViewRowType.C)
		{
			Cell = this;

			labelA = new UILabel();
			labelB = new UILabel();
			labelC = new UILabel();
		}

		/// <summary>
		/// Lays out the subviews. Sets our labels dimensions and adds it to them content view and then calls updateStateColor to set the correct color
		/// for the labels that should represent whatever state the cell is in.
		/// </summary>
		public override void LayoutSubviews ()
		{
			

			const float totalMargins 	= DefaultiOSDimensions.cellPadding * 4;
			var labelWidth 			= (Frame.Width - totalMargins)/3;
			labelA.Frame = new  CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding,0,labelWidth, Frame.Height);
			labelB.Frame = new  CoreGraphics.CGRect	(DefaultiOSDimensions.cellPadding * 2 + labelWidth, 0,labelWidth, Frame.Height); 
			labelC.Frame = new  CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding * 3 + labelWidth * 2, 0, labelWidth, Frame.Height);

			ContentView.AddSubviews (new UIView[]{ labelA, labelB, labelC });
			updateStateColor ();
			base.LayoutSubviews ();
		}

		/// <summary>
		/// Checks the state of this cell and sets its color accordingly from the color options available.
		/// </summary>
		private void updateStateColor()
		{
			labelA.BackgroundColor = state ? primaryStateColors [0] : secondaryStatColors [0];
			labelB.BackgroundColor = state ? primaryStateColors [1] : secondaryStatColors [1];
			labelC.BackgroundColor = state ? primaryStateColors [2] : secondaryStatColors [2];
		}


		/// <summary>
		/// Switchs the state of the cell to its opposite.
		/// </summary>
		public override void SwitchState ()
		{
			state = !state;
			updateStateColor ();
		}
	}
		
}
