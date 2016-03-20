using System;
using System.Drawing;
using UIKit;
using Foundation;

namespace UIKit
{
	/// <summary>
	/// Extension Class that allows us to add some extra functionality to our specific app.
	/// </summary>
	public static class UIColorExtensions
	{
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
	}


}

namespace System
{
	/// <summary>
	/// Some handy extensions by https://gist.github.com/HeathHopkins/8289364
	/// </summary>
	public static class ExtensionMethods
	{
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

		public static SizeF StringSize(this UILabel label)
		{
			return (SizeF) new NSString(label.Text).StringSize(label.Font);
		}


		public static void HideGradientBackground(this UIView view)
		{
			try
			{
				foreach(var subview in view.Subviews)
				{
					if(subview.GetType() == typeof(UIImageView))
						subview.Hidden = true;
					subview.HideGradientBackground();
				}
			}
			catch
			{
				// nothing to do
			}
		}





		/// <summary>
		/// Returns a lighter color
		/// </summary>
		/// <param name="steps">The number of steps to lighten.</param>
		public static UIColor Lighten(this UIColor color, int steps)
		{
			int modifier = 16 * steps;

			nfloat rF, gF, bF, aF;
			color.GetRGBA(out rF, out gF, out bF, out aF);

			int r, g, b, a;
			r = (int)Math.Ceiling(rF * 255);
			g = (int)Math.Ceiling(gF * 255);
			b = (int)Math.Ceiling(bF * 255);
			a = (int)Math.Ceiling(aF * 255);

			r += modifier;
			g += modifier;
			b += modifier;
			// leave 'a' alone?

			r = r > 255 ? 255 : r;
			g = g > 255 ? 255 : g;
			b = b > 255 ? 255 : b;

			return UIColor.FromRGBA(r, g, b, a);
		}



		/// <summary>
		/// Returns a darker color
		/// </summary>
		/// <param name="steps">The number of steps to darken.</param>
		public static UIColor Darken(this UIColor color, int steps)
		{
			int modifier = 16 * steps;

			nfloat rF, gF, bF, aF;

			color.GetRGBA(out rF, out gF, out bF, out aF);

			int r, g, b, a;
			r = (int)Math.Ceiling(rF * 255);
			g = (int)Math.Ceiling(gF * 255);
			b = (int)Math.Ceiling(bF * 255);
			a = (int)Math.Ceiling(aF * 255);

			r -= modifier;
			g -= modifier;
			b -= modifier;
			// leave 'a' alone?

			r = r < 0 ? 0 : r;
			g = g < 0 ? 0 : g;
			b = b < 0 ? 0 : b;

			return UIColor.FromRGBA(r, g, b, a);
		}
	}
}