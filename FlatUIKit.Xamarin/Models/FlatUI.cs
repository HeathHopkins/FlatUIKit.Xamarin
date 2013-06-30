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
            SetBarButtonItemAppearance(UIBarButtonItem.Appearance, FlatUI.Colors.PeterRiver, FlatUI.Colors.BelizeHole, UIColor.White, 3f);
            SetFlatNavigationBarAppearance(UINavigationBar.Appearance, FlatUI.Colors.MidnightBlue);
        }

        public static void SetFlatNavigationBarAppearance(UINavigationBar.UINavigationBarAppearance appearance, UIColor color)
        {
            appearance.SetBackgroundImage(FlatUI.Image(color, 0), UIBarMetrics.Default & UIBarMetrics.LandscapePhone);
            UITextAttributes titleTextAttributes = appearance.GetTitleTextAttributes();
            if (titleTextAttributes == null)
                titleTextAttributes = new UITextAttributes();
            titleTextAttributes.TextShadowColor = UIColor.Clear;
            titleTextAttributes.TextShadowOffset = new UIOffset(0, 0);
            appearance.SetTitleTextAttributes(titleTextAttributes);
            if (appearance.RespondsToSelector(new MonoTouch.ObjCRuntime.Selector("setShadowImage:")))
                appearance.ShadowImage = FlatUI.Image(UIColor.Clear, 0);
        }

        public static void SetBarButtonItemAppearance(UIBarButtonItem.UIBarButtonItemAppearance appearance, UIColor color, UIColor highlightedColor, UIColor textColor, float cornerRadius)
        {
            UIImage backButtonPortraitImage = FlatUI.BackButtonImageWithColor(color, 
                                                                              UIBarMetrics.Default, 
                                                                              cornerRadius);
            UIImage highlightedBackButtonPortraitImage = FlatUI.BackButtonImageWithColor(highlightedColor,
                                                                                         UIBarMetrics.Default,
                                                                                         cornerRadius);
            UIImage backButtonLandscapeImage = FlatUI.BackButtonImageWithColor(color,
                                                                               UIBarMetrics.LandscapePhone,
                                                                               2);
            UIImage highlightedBackButtonLandscapeImage = FlatUI.BackButtonImageWithColor(highlightedColor,
                                                                                          UIBarMetrics.LandscapePhone,
                                                                                          2);

            appearance.SetBackButtonBackgroundImage(backButtonPortraitImage, UIControlState.Normal, UIBarMetrics.Default);
            appearance.SetBackButtonBackgroundImage(backButtonLandscapeImage, UIControlState.Normal, UIBarMetrics.LandscapePhone);
            appearance.SetBackButtonBackgroundImage(highlightedBackButtonPortraitImage, UIControlState.Highlighted, UIBarMetrics.Default);
            appearance.SetBackButtonBackgroundImage(highlightedBackButtonLandscapeImage, UIControlState.Highlighted, UIBarMetrics.LandscapePhone);

            appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(1f, 1f), UIBarMetrics.Default);
            appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(1f, 1f), UIBarMetrics.LandscapePhone);

            UIImage buttonImageNormal = FlatUI.Image(color, cornerRadius);
            UIImage buttonImageHighlighted = FlatUI.Image(highlightedColor, cornerRadius);

            appearance.SetBackgroundImage(buttonImageNormal, UIControlState.Normal, UIBarMetrics.Default);
            appearance.SetBackgroundImage(buttonImageHighlighted, UIControlState.Highlighted, UIBarMetrics.Default);

            UITextAttributes titleTextAttributes = appearance.GetTitleTextAttributes(UIControlState.Normal);
            if (titleTextAttributes == null)
                titleTextAttributes = new UITextAttributes();
            titleTextAttributes.TextShadowColor = UIColor.Clear;
            titleTextAttributes.TextShadowOffset = new UIOffset(0, 0);
            titleTextAttributes.TextColor = textColor;
            appearance.SetTitleTextAttributes(titleTextAttributes, UIControlState.Normal);
            appearance.SetTitleTextAttributes(titleTextAttributes, UIControlState.Highlighted);
        }

        public static UIImage ButtonImageWithColor(UIColor color, float cornerRadius, UIColor shadowColor, UIEdgeInsets shadowInsets)
        {
            UIImage topImage = Image(color, cornerRadius);
            UIImage bottomImage = Image(shadowColor, cornerRadius);
            float totalHeight = EdgeSizeFromCornerRadius(cornerRadius) + shadowInsets.Top + shadowInsets.Bottom;
            float totalWidth = EdgeSizeFromCornerRadius(cornerRadius) + shadowInsets.Left + shadowInsets.Right;
            float topWidth = EdgeSizeFromCornerRadius(cornerRadius);
            float topHeight = EdgeSizeFromCornerRadius(cornerRadius);
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

        public static float EdgeSizeFromCornerRadius(float cornerRadius)
        {
            return cornerRadius * 2 + 1;
        }

        public static UIImage Image(UIColor color, float cornerRadius)
        {
            float minEdgeSize = EdgeSizeFromCornerRadius(cornerRadius);
            RectangleF rect = new RectangleF(0, 0, minEdgeSize, minEdgeSize);
            UIBezierPath roundedRect = UIBezierPath.FromRoundedRect(rect, cornerRadius);
            roundedRect.LineWidth = 0;
            UIGraphics.BeginImageContextWithOptions(rect.Size, false, 0f);
            color.SetFill();
            roundedRect.Fill();
            roundedRect.Stroke();
            roundedRect.AddClip();
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return image.CreateResizableImage(new UIEdgeInsets(cornerRadius, cornerRadius, cornerRadius, cornerRadius), UIImageResizingMode.Stretch);
        }

        public static UIImage BackButtonImageWithColor(UIColor color, UIBarMetrics metrics, float cornerRadius)
        {
            SizeF size;
            if (metrics.Equals(UIBarMetrics.Default))
                size = new SizeF(50, 30);
            else
                size = new SizeF(60, 23);

            UIBezierPath path = BezierPathForBackButton(new RectangleF(0, 0, size.Width, size.Height), cornerRadius);

            UIGraphics.BeginImageContextWithOptions(size, false, 0f);
            color.SetFill();
            path.AddClip();
            path.Fill();
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

