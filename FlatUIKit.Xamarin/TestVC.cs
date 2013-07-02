using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace FlatUIKit
{
    public class TestVC : UIViewController
    {
        public int Id { get; set; }

        FUIShadowedButton btnShadowed;
        FUIButton btnFlat;
        UIBarButtonItem bbi;

        public TestVC(int Id)
            : base()
        {
            this.Id = Id;
            Title = string.Format("Test {0}", Id);
        }

        public override void LoadView()
        {
            var view = new UIView(UIScreen.MainScreen.ApplicationFrame)
            {
                BackgroundColor = FlatUI.Color.Clouds,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            bbi = new UIBarButtonItem("New", UIBarButtonItemStyle.Plain, HandleTouchUpInside);
            NavigationItem.RightBarButtonItem = bbi;

            btnShadowed = new FUIShadowedButton(new RectangleF(50, 50, 200, 44), FlatUI.Color.PeterRiver, FlatUI.Color.PeterRiver.Darken(1));
            btnShadowed.SetTitle("Shadowed", UIControlState.Normal);
            view.Add(btnShadowed);

            btnFlat = new FUIButton(new RectangleF(50, 120, 200, 44), FlatUI.Color.PeterRiver, FlatUI.Color.PeterRiver.Darken(1));
            btnFlat.SetTitle("Flat", UIControlState.Normal);
            view.Add(btnFlat);

            this.View = view;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            btnShadowed.TouchUpInside += HandleTouchUpInside;
            btnFlat.TouchUpInside += HandleTouchUpInside;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            btnShadowed.TouchUpInside -= HandleTouchUpInside;
            btnFlat.TouchUpInside -= HandleTouchUpInside;
        }

        void HandleTouchUpInside (object sender, EventArgs e)
        {
            NavigationController.PushViewController(new TestVC(Id + 1), true);
        }
    }
}

