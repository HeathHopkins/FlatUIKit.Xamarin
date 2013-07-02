using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FlatUIKit
{
    public static partial class FlatUI
    {
        public static void Apply()
        {
            // bar button items
            SetBarButtonItemAppearance(UIBarButtonItem.Appearance, FlatUI.Color.PeterRiver, FlatUI.Color.BelizeHole, UIColor.White, 3f, 1f);

            SetFlatNavigationBarAppearance(UINavigationBar.Appearance, FlatUI.Color.Carrot, FlatUI.Color.Clouds);
        }

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

        public static void SetFlatNavigationBarAppearance(UINavigationBar.UINavigationBarAppearance appearance, UIColor color, UIColor textColor)
        {
            UIImage backgroundImage = FlatUI.Image(color, 0);
            appearance.SetBackgroundImage(backgroundImage, UIBarMetrics.Default);
            appearance.SetBackgroundImage(backgroundImage, UIBarMetrics.LandscapePhone);

            UITextAttributes titleTextAttributes = appearance.GetTitleTextAttributes();
            if (titleTextAttributes == null)
                titleTextAttributes = new UITextAttributes();
            titleTextAttributes.TextShadowColor = UIColor.Clear;
            titleTextAttributes.TextShadowOffset = new UIOffset(0, 0);
            titleTextAttributes.TextColor = textColor;
            titleTextAttributes.Font = FlatUI.BoldFontOfSize(0);
            appearance.SetTitleTextAttributes(titleTextAttributes);
            if (appearance.RespondsToSelector(new MonoTouch.ObjCRuntime.Selector("setShadowImage:")))
                appearance.ShadowImage = FlatUI.Image(UIColor.Clear, 0);
        }

        public static void SetBarButtonItemAppearance(UIBarButtonItem.UIBarButtonItemAppearance appearance, UIColor color, UIColor highlightedColor, UIColor textColor, float cornerRadius, float borderWidth)
        {
            UIImage backButtonPortraitImage = FlatUI.BackButtonImage(color,
                                                                     UIBarMetrics.Default,
                                                                     cornerRadius,
                                                                     color.Darken(2),
                                                                     borderWidth);
            UIImage highlightedBackButtonPortraitImage = FlatUI.BackButtonImage(highlightedColor,
                                                                                UIBarMetrics.Default,
                                                                                cornerRadius,
                                                                                highlightedColor.Darken(2),
                                                                                borderWidth);
            UIImage backButtonLandscapeImage = FlatUI.BackButtonImage(color,
                                                                      UIBarMetrics.LandscapePhone,
                                                                      cornerRadius,
                                                                      color.Darken(2),
                                                                      borderWidth);
            UIImage highlightedBackButtonLandscapeImage = FlatUI.BackButtonImage(highlightedColor,
                                                                                 UIBarMetrics.LandscapePhone,
                                                                                 cornerRadius,
                                                                                 highlightedColor.Darken(2),
                                                                                 borderWidth);

            appearance.SetBackButtonBackgroundImage(backButtonPortraitImage, UIControlState.Normal, UIBarMetrics.Default);
            appearance.SetBackButtonBackgroundImage(backButtonLandscapeImage, UIControlState.Normal, UIBarMetrics.LandscapePhone);
            appearance.SetBackButtonBackgroundImage(highlightedBackButtonPortraitImage, UIControlState.Highlighted, UIBarMetrics.Default);
            appearance.SetBackButtonBackgroundImage(highlightedBackButtonLandscapeImage, UIControlState.Highlighted, UIBarMetrics.LandscapePhone);

            appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(1f, 1f), UIBarMetrics.Default);
            appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(1f, 1f), UIBarMetrics.LandscapePhone);

            UIImage buttonImageNormal = FlatUI.Image(color, cornerRadius, color.Darken(2), borderWidth);
            UIImage buttonImageHighlighted = FlatUI.Image(highlightedColor, cornerRadius, highlightedColor.Darken(2), borderWidth);

            appearance.SetBackgroundImage(buttonImageNormal, UIControlState.Normal, UIBarMetrics.Default);
            appearance.SetBackgroundImage(buttonImageHighlighted, UIControlState.Highlighted, UIBarMetrics.Default);

            UITextAttributes titleTextAttributes = appearance.GetTitleTextAttributes(UIControlState.Normal);
            if (titleTextAttributes == null)
                titleTextAttributes = new UITextAttributes();
            titleTextAttributes.TextShadowColor = UIColor.Clear;
            titleTextAttributes.TextShadowOffset = new UIOffset(0, 0);
            titleTextAttributes.TextColor = textColor;
            titleTextAttributes.Font = FlatUI.FontOfSize(0);
            appearance.SetTitleTextAttributes(titleTextAttributes, UIControlState.Normal);
            appearance.SetTitleTextAttributes(titleTextAttributes, UIControlState.Highlighted);
        }

        public static UIImage ButtonImage(UIColor color, float cornerRadius, UIColor shadowColor, UIEdgeInsets shadowInsets)
        {
            UIImage topImage = FlatUI.Image(color, cornerRadius);
            UIImage bottomImage = FlatUI.Image(shadowColor, cornerRadius);
            float totalHeight = FlatUI.EdgeSize(cornerRadius) + shadowInsets.Top + shadowInsets.Bottom;
            float totalWidth = FlatUI.EdgeSize(cornerRadius) + shadowInsets.Left + shadowInsets.Right;
            float topWidth = FlatUI.EdgeSize(cornerRadius);
            float topHeight = FlatUI.EdgeSize(cornerRadius);
            RectangleF topRect = new RectangleF(shadowInsets.Left, shadowInsets.Top, topWidth, topHeight);
            RectangleF bottomRect = new RectangleF(0, 0, totalWidth, totalHeight);

            UIGraphics.BeginImageContextWithOptions(new SizeF(totalWidth, totalHeight), false, 0f);
            if (!bottomRect.Equals(topRect))
                bottomImage.Draw(bottomRect);
            topImage.Draw(topRect);
            UIImage buttonImage = UIGraphics.GetImageFromCurrentImageContext();
            UIEdgeInsets resizeableInsets = new UIEdgeInsets(cornerRadius + shadowInsets.Top,
                                                             cornerRadius + shadowInsets.Left,
                                                             cornerRadius + shadowInsets.Bottom,
                                                             cornerRadius + shadowInsets.Right);
            UIGraphics.EndImageContext();
            return buttonImage.CreateResizableImage(resizeableInsets);
        }

        public static float EdgeSize(float cornerRadius)
        {
            return cornerRadius * 2 + 1;
        }

        public static UIImage Image(UIColor color, float cornerRadius)
        {
            return FlatUI.Image(color, cornerRadius, color, 0);
        }

        public static UIImage Image(UIColor color, float cornerRadius, UIColor borderColor, float borderWidth)
        {
            float minEdgeSize = EdgeSize(cornerRadius);
            RectangleF rect = new RectangleF(0, 0, minEdgeSize, minEdgeSize);
            UIBezierPath fillPath = UIBezierPath.FromRoundedRect(rect, cornerRadius);

            UIBezierPath strokePath = fillPath;
            if (borderWidth > 0)
            {
                RectangleF insetRect = RectangleF.Inflate(rect, -1 * borderWidth / 2, -1 * borderWidth / 2);
                strokePath = UIBezierPath.FromRoundedRect(insetRect, cornerRadius);
            }

            UIGraphics.BeginImageContextWithOptions(rect.Size, false, 0f);
            color.SetFill();
            borderColor.SetStroke();
            fillPath.Fill();
            if (borderWidth > 0)
                strokePath.Stroke();
            fillPath.AddClip();
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return image.CreateResizableImage(new UIEdgeInsets(cornerRadius, cornerRadius, cornerRadius, cornerRadius), UIImageResizingMode.Stretch);
        }

        public static UIImage BackButtonImage(UIColor color, UIBarMetrics metrics, float cornerRadius)
        {
            return FlatUI.BackButtonImage(color, metrics, cornerRadius, color, 0);
        }

        public static UIImage BackButtonImage(UIColor color, UIBarMetrics metrics, float cornerRadius, UIColor borderColor, float borderWidth)
        {
            SizeF size;
            if (metrics.Equals(UIBarMetrics.Default))
                size = new SizeF(50, 30);
            else
                size = new SizeF(60, 23);

            UIBezierPath fillPath = BezierPathForBackButton(new RectangleF(0, 0, size.Width, size.Height), cornerRadius);
            fillPath.LineWidth = 2 * borderWidth;

            UIGraphics.BeginImageContextWithOptions(size, false, 0f);
            color.SetFill();
            borderColor.SetStroke();
            fillPath.AddClip();
            fillPath.Fill();
            if (borderWidth > 0)
                fillPath.Stroke();
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return image.CreateResizableImage(new UIEdgeInsets(cornerRadius, 15f, cornerRadius, cornerRadius), UIImageResizingMode.Stretch);
        }

        public static UIBezierPath BezierPathForBackButton(RectangleF rect, float radius)
        {
            var path = new UIBezierPath();
            var mPoint = new PointF(rect.Right - radius, rect.Y);
            var ctrlPoint = mPoint;
            path.MoveTo(mPoint);

            ctrlPoint.Y += radius;
            mPoint.X += radius;
            mPoint.Y += radius;
            if (radius > 0)
                path.AddArc(ctrlPoint, radius, (float)(Math.PI + Math.PI / 2), 0, true);

            mPoint.Y = rect.Bottom - radius;
            path.AddLineTo(mPoint);

            ctrlPoint = mPoint;
            mPoint.Y += radius;
            mPoint.X -= radius;
            ctrlPoint.X -= radius;
            if (radius > 0)
                path.AddArc(ctrlPoint, radius, 0, (float)(Math.PI / 2), true);

            mPoint.X = rect.X + 10f;
            path.AddLineTo(mPoint);

            path.AddLineTo(new PointF(rect.X, rect.Height / 2));

            mPoint.Y = rect.Y;
            path.AddLineTo(mPoint);

            path.ClosePath();
            return path;
        }
    }
}

