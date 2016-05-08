using System;
using UIKit;

namespace ContactPicker 
{
	///<summary>
	///
	///</summary>
	public static class Extensions
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC STATIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The iOS default background color for Tables
		/// </summary>
		/// <returns>The user interface table view backgound.</returns>
		/// <param name="color">Color.</param>
		public static UIColor DefaultUITableViewBackgound(this UIColor color)
		{
			return UIColor.FromRGB (239, 239, 244);
		}

		/// <summary>
		/// The iOS default Table header text color.
		/// </summary>
		/// <returns>The user interface table view header text color.</returns>
		/// <param name="color">Color.</param>
		public static UIColor DefaultUITableViewHeaderTextColor(this UIColor color)
		{
			return UIColor.FromRGB (109, 109, 114);

		}

		public static UIColor ToUIColor(this string hexString)
		{
			hexString = hexString.Replace("#", "");

			if (hexString.Length == 3)
				hexString = hexString + hexString;

			if (hexString.Length != 6)
				throw new Exception("Invalid hex string");

			int red = Int32.Parse(hexString.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int green = Int32.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int blue = Int32.Parse(hexString.Substring(4,2), System.Globalization.NumberStyles.AllowHexSpecifier);

			return UIColor.FromRGB(red, green, blue);
		}
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
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