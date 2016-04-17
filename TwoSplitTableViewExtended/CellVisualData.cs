using System;
using UIKit;

namespace TwoSplitTableViewExtended 
{
	/// <summary>
	/// Static uitl class to provide default iOS dimensions for frame sizing.
	/// </summary>
	public static class DefaultiOSDimensions{
		/// <summary>
		/// Default height of a standard iOS UITableViewCell.
		/// </summary>
		public const int cellHeight 	= 44;
		/// <summary>
		/// Default width of a standard iOS UItableViewCell.
		/// </summary>
		public const int cellWidth 	= 320;
		/// <summary>
		/// Default left and right padding in a standard UITableViewCell.
		/// </summary>
		public const int cellPadding 	= 15;

		/// <summary>
		/// Default Frame of a standard iOS UItableViewCell.
		/// </summary>
		/// <returns>The frame.</returns>
		public static CoreGraphics.CGRect CellFrame()
		{
			return new CoreGraphics.CGRect (0, 0, cellWidth, cellHeight);
		}
	}

	/// <summary>
	/// Base class for Label Color Access.  
	/// </summary>
	public class LabelType {

		/// <summary>
		/// Returns the default color state for this label.
		/// </summary>
		public readonly UIColor StateOneColor;
		/// <summary>
		/// Returns the selected color state for this label.
		/// </summary>
		public readonly UIColor StateTwoColor;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.LabelType"/> class.
		/// </summary>
		/// <param name="stateOne">State one.</param>
		/// <param name="stateTwo">State two.</param>
		public LabelType(UIColor stateOne, UIColor stateTwo)
		{
			StateOneColor = stateOne;
			StateTwoColor = stateTwo;
		}
	}

	/// <summary>
	/// Container for Cell One's Label Color information.
	/// </summary>
	public class CellOne{
		/// <summary>
		/// Container for Label A's state color information.
		/// </summary>
		public LabelType LabelA;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellOne"/> class.
		/// </summary>
		/// <param name="stateColorOne">State color one.</param>
		/// <param name="stateColorTwo">State color two.</param>
		public CellOne(UIColor stateColorOne, UIColor stateColorTwo){
			LabelA = new LabelType (stateColorOne, stateColorTwo);
		}
	}

	/// <summary>
	/// Container for Cell Two's Label Color information.
	/// </summary>
	public class CellTwo : CellOne {
		/// <summary>
		/// Container for Label B's state color information.
		/// </summary>
		public LabelType LabelB;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellTwo"/> class.
		/// </summary>
		/// <param name="AStateColorOne">A state color one.</param>
		/// <param name="AStateColorTwo">A state color two.</param>
		/// <param name="BStateColorOne">B state color one.</param>
		/// <param name="BStateColorTwo">B state color two.</param>
		public CellTwo (UIColor AStateColorOne, UIColor AStateColorTwo, UIColor BStateColorOne, UIColor BStateColorTwo) 
			: base(AStateColorOne, AStateColorTwo)
		{
			LabelB = new LabelType (BStateColorOne, BStateColorTwo);
		}
	}

	/// <summary>
	/// Container for Cell Three's Label Color information.
	/// </summary>
	public class CellThree : CellTwo{
		/// <summary>
		/// Container for Label C's state color information.
		/// </summary>
		public LabelType LabelC;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellThree"/> class.
		/// </summary>
		/// <param name="AStateColorOne">A state color one.</param>
		/// <param name="AStateColorTwo">A state color two.</param>
		/// <param name="BStateColorOne">B state color one.</param>
		/// <param name="BStateColorTwo">B state color two.</param>
		/// <param name="CStateColorOne">C state color one.</param>
		/// <param name="CStateColorTwo">C state color two.</param>
		public CellThree(UIColor AStateColorOne, UIColor AStateColorTwo, UIColor BStateColorOne, UIColor BStateColorTwo, UIColor CStateColorOne, UIColor CStateColorTwo ) 
			: base(AStateColorOne, AStateColorTwo, BStateColorOne, BStateColorTwo)
		{
			LabelC = new LabelType (CStateColorOne, CStateColorTwo);
		}
	}

	///<summary>
	/// An Object to be instaciated when needing to access a grouping of parameters to helps style the table views.  These are a group of label colors
	/// that will never change under the applications usage.  These colors are hard coded values.  This object is therefore meant to be a source of design
	/// paramaters for the color cell table view row labels.  Each Cell class contains an amount of Label Properties which are in turn classes that contain
	/// a default and selected state UIColor to retrieve and set as the desired UILabel color where applicable.
	///</summary>
	public class CellVisualData
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================\
		/// <summary>
		/// Color for Cell A's label A in its default state
		/// </summary>
		private readonly UIColor cellALabelA1 = UIColor.Brown	;
		/// <summary>
		/// Color for Cell A's label A in its chosen state
		/// </summary>
		private readonly UIColor cellALabelA2 = UIColor.Blue	;
		/// <summary>
		/// Color for Cell B's label A in its default state
		/// </summary>
		private readonly UIColor cellBLabelA1 = UIColor.Red	;
		/// <summary>
		/// Color for Cell B's label A in its chosen state
		/// </summary>
		private readonly UIColor cellBLabelA2 = UIColor.Yellow	;
		/// <summary>
		/// Color for Cell B's label B in its default state
		/// </summary>
		private readonly UIColor cellBLabelB1 = UIColor.Orange	;
		/// <summary>
		/// Color for Cell B's label B in its chosen state
		/// </summary>
		private readonly UIColor cellBLabelB2 = UIColor.Magenta	;
		/// <summary>
		/// Color for Cell C's label A in its default state
		/// </summary>
		private readonly UIColor cellCLabelA1 = UIColor.Purple	;
		/// <summary>
		/// Color for Cell C's label A in its chosen state
		/// </summary>
		private readonly UIColor cellCLabelA2 = UIColor.Cyan	;
		/// <summary>
		/// Color for Cell C's label B in its default state
		/// </summary>
		private readonly UIColor cellCLabelB1 = UIColor.LightGray;
		/// <summary>
		/// Color for Cell C's label B in its chosen state
		/// </summary>
		private readonly UIColor cellCLabelB2 = UIColor.Black	;
		/// <summary>
		/// Color for Cell C's label C in its default state
		/// </summary>
		private readonly UIColor cellCLabelC1 = UIColor.Green	;
		/// <summary>
		/// Color for Cell C's label C in its chosen state
		/// </summary>
		private readonly UIColor cellCLabelC2 = UIColor.DarkGray;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Container for Cell A's Label Color information.
		/// </summary>
		public CellOne CellA;
		/// <summary>
		/// Container for Cell B's Label Color information.
		/// </summary>
		public CellTwo CellB;
		/// <summary>
		/// Container for Cell C's Label Color information.
		/// </summary>
		public CellThree CellC;
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CellVisualData"/> class.  Inits our cell
		/// containers with the right color data.
		/// </summary>
		public CellVisualData ()
		{
			CellA = new CellOne (cellALabelA1, cellALabelA2);
			CellB = new CellTwo (cellBLabelA1, cellBLabelA2, cellBLabelB1, cellBLabelB2);
			CellC = new CellThree (cellCLabelA1, cellCLabelA2, cellCLabelB1, cellCLabelB2, cellCLabelC1, cellCLabelC2);
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}