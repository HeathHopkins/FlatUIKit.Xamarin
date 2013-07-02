using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FlatUIKit
{
    [Register("FUIButton")]
    public class FUIButton : UIButton
    {
        //UIEdgeInsets DefaultEdgeInsets, NormalEdgeInsets, HighlightedEdgeInsets;

        public FUIButton(RectangleF frame, UIColor buttonColor, UIColor highlightedColor, float borderWidth = 1f, float cornerRadius = 5f)
            : this(frame, buttonColor, highlightedColor, buttonColor.Darken(2), highlightedColor.Darken(2), borderWidth, cornerRadius)
        {
        }

        public FUIButton(RectangleF frame, UIColor buttonColor, UIColor highlightedColor, UIColor borderColor, UIColor highlightedBorderColor, float borderWidth = 1f, float cornerRadius = 5f)
            : base(frame)
        {
            _ButtonColor = buttonColor;
            _HighlightedColor = highlightedColor;
            _BorderColor = borderColor;
            _HighlightedBorderColor = highlightedBorderColor;
            _BorderWidth = borderWidth;
            _CornerRadius = cornerRadius;

            UpdateBackgroundImages();
        }

        private UIColor _ButtonColor;
        public UIColor ButtonColor
        {
            get
            {
                return _ButtonColor;
            }
            set
            {
                _ButtonColor = value;
                UpdateBackgroundImages();
            }
        }

        private UIColor _HighlightedColor;
        public UIColor HighlightedColor
        {
            get
            {
                return _HighlightedColor;
            }
            set
            {
                _HighlightedColor = value;
                UpdateBackgroundImages();
            }
        }

        private float _BorderWidth;
        public float BorderWidth
        {
            get
            {
                return _BorderWidth;
            }
            set
            {
                _BorderWidth = value;

                //UpdateEdgeInsets();
                UpdateBackgroundImages();
            }
        }

        private float _CornerRadius;
        public float CornerRadius
        {
            get
            {
                return _CornerRadius;
            }
            set
            {
                _CornerRadius = value;
                UpdateBackgroundImages();
            }
        }

        private UIColor _BorderColor;
        public UIColor BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                UpdateBackgroundImages();
            }
        }

        private UIColor _HighlightedBorderColor;
        public UIColor HighlightedBorderColor
        {
            get
            {
                return _HighlightedBorderColor;
            }
            set
            {
                _HighlightedBorderColor = value;
                UpdateBackgroundImages();
            }
        }

        private void UpdateBackgroundImages()
        {
            /*
            UIImage normalBackgroundImage = FlatUI.ButtonImage(ButtonColor, 
                                                                        CornerRadius, 
                                                                        HighlightedColor, 
                                                                        new UIEdgeInsets(0, 0, BorderWidth, 0));
            UIImage highlightedBackgroundImage = FlatUI.ButtonImage(ButtonColor,
                                                                             CornerRadius,
                                                                             UIColor.Clear,
                                                                             new UIEdgeInsets(BorderWidth, 0, 0, 0));
                                                                             */
            UIImage normalBackgroundImage = FlatUI.Image(ButtonColor,
                                                         CornerRadius,
                                                         BorderColor,
                                                         BorderWidth);
            UIImage highlightedBackgroundImage = FlatUI.Image(HighlightedColor,
                                                              CornerRadius,
                                                              HighlightedBorderColor,
                                                              BorderWidth);
            this.SetBackgroundImage(normalBackgroundImage, UIControlState.Normal);
            this.SetBackgroundImage(highlightedBackgroundImage, UIControlState.Highlighted);
        }
    }
}

