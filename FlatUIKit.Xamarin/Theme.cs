using System;
using System.IO;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlatUIKit
{
	public static class Theme
	{
        /// <summary>
        /// Apply app-level UIAppearance properties
        /// </summary>
        public static void Apply()
        {

        }

        static Lazy<UIColor> backgroundColor = new Lazy<UIColor>(() => UIColor.FromRGB(236, 235, 232));
        public static UIColor BackgroundColor { get { return backgroundColor.Value; } }

        //static Lazy<UIColor> linenPattern = new Lazy<UIColor>(() => UIColor.FromPatternImage(UIImage.FromFile("")));
        //public static UIColor LinenPattern { get { return linenPattern.Value; } }

        static Lazy<UIColor> darkText = new Lazy<UIColor>(() => UIColor.FromRGB(66, 66, 66));
        public static UIColor DarkText { get { return darkText.Value; } }

        static Lazy<UIColor> primaryBlue = new Lazy<UIColor>(() => UIColor.FromRGB(3, 36, 77));
        public static UIColor PrimaryBlue { get { return primaryBlue.Value; } }

        static Lazy<UIColor> secondaryBlue = new Lazy<UIColor>(() => UIColor.FromRGB(73, 110, 156));
        public static UIColor SecondaryBlue { get { return secondaryBlue.Value; } }

        static Lazy<UIColor> primaryOrange = new Lazy<UIColor>(() => UIColor.FromRGB(221, 85, 12));
        public static UIColor PrimaryOrange { get { return primaryOrange.Value; } }

        static Lazy<UIColor> secondaryOrange = new Lazy<UIColor>(() => UIColor.FromRGB(246, 128, 38));
        public static UIColor SecondaryOrange { get { return secondaryOrange.Value; } }


        const string FontName = @"HelveticaNeue-Medium";
        const string BoldFontName = @"HelveticaNeue-Bold";

        public static UIFont FontOfSize(float size)
        {
            return UIFont.FromName(FontName, size);
        }

        public static UIFont BoldFontOfSize(float size)
        {
            return UIFont.FromName(BoldFontName, size);
        }


		public static string CachedDocuments
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cached");
			}
		}
	}
}

