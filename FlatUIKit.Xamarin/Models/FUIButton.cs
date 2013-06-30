using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FlatUIKit
{
    [Register("FUIButton")]
    public class FUIButton : UIButton
    {
        UIEdgeInsets DefaultEdgeInsets, NormalEdgeInsets, HighlightedEdgeInsets;

        public FUIButton(RectangleF frame, UIColor buttonColor, UIColor shadowColor, float shadowHeight = 3f, float cornerRadius = 6f)
            : base(frame)
        {

            _ButtonColor = buttonColor;
            _ShadowColor = shadowColor;
            _ShadowHeight = shadowHeight;
            _CornerRadius = cornerRadius;

            DefaultEdgeInsets = TitleEdgeInsets;
            UpdateEdgeInsets();
            ConfigureFlatButton();
        }

        private void UpdateEdgeInsets()
        {
            UIEdgeInsets insets = DefaultEdgeInsets;
            HighlightedEdgeInsets = insets;
            insets.Top -= ShadowHeight;
            NormalEdgeInsets = insets;
            TitleEdgeInsets = insets;
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
                ConfigureFlatButton();
            }
        }

        private UIColor _ShadowColor;
        public UIColor ShadowColor
        {
            get
            {
                return _ShadowColor;
            }
            set
            {
                _ShadowColor = value;
                ConfigureFlatButton();
            }
        }

        private float _ShadowHeight;
        public float ShadowHeight
        {
            get
            {
                return _ShadowHeight;
            }
            set
            {
                _ShadowHeight = value;

                UpdateEdgeInsets();
                ConfigureFlatButton();
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
                ConfigureFlatButton();
            }
        }

        public override bool Highlighted
        {
            get
            {
                return base.Highlighted;
            }
            set
            {
                base.Highlighted = value;
                TitleEdgeInsets = Highlighted ? this.HighlightedEdgeInsets : this.NormalEdgeInsets;
            }
        }

        private void ConfigureFlatButton()
        {
            UIImage normalBackgroundImage = FlatUI.ButtonImageWithColor(ButtonColor, 
                                                                        CornerRadius, 
                                                                        ShadowColor, 
                                                                        new UIEdgeInsets(0, 0, ShadowHeight, 0));
            UIImage highlightedBackgroundImage = FlatUI.ButtonImageWithColor(ButtonColor,
                                                                             CornerRadius,
                                                                             UIColor.Clear,
                                                                             new UIEdgeInsets(ShadowHeight, 0, 0, 0));
            this.SetBackgroundImage(normalBackgroundImage, UIControlState.Normal);
            this.SetBackgroundImage(highlightedBackgroundImage, UIControlState.Highlighted);
        }
    }
}

