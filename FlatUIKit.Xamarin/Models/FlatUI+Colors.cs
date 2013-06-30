using System;
using MonoTouch.UIKit;

namespace FlatUIKit
{
    public static partial class FlatUI
    {
        public static class Color
        {
            static Lazy<UIColor> turquoise = new Lazy<UIColor>(() => "1ABC9C".ToUIColor());
            public static UIColor Turquoise { get { return turquoise.Value; } }

            static Lazy<UIColor> greenSea = new Lazy<UIColor>(() => "16A085".ToUIColor());
            public static UIColor GreenSea { get { return greenSea.Value; } }

            static Lazy<UIColor> emerald = new Lazy<UIColor>(() => "2ECC71".ToUIColor());
            public static UIColor Emerald { get { return emerald.Value; } }

            static Lazy<UIColor> nephritis = new Lazy<UIColor>(() => "27AE60".ToUIColor());
            public static UIColor Nephritis { get { return nephritis.Value; } }

            static Lazy<UIColor> peterRiver = new Lazy<UIColor>(() => "3498DB".ToUIColor());
            public static UIColor PeterRiver { get { return peterRiver.Value; } }

            static Lazy<UIColor> belizeHole = new Lazy<UIColor>(() => "2980B9".ToUIColor());
            public static UIColor BelizeHole { get { return belizeHole.Value; } }

            static Lazy<UIColor> amethyst = new Lazy<UIColor>(() => "9B59B6".ToUIColor());
            public static UIColor Amethyst { get { return amethyst.Value; } }

            static Lazy<UIColor> wisteria = new Lazy<UIColor>(() => "8E44AD".ToUIColor());
            public static UIColor Wisteria { get { return wisteria.Value; } }

            static Lazy<UIColor> wetAsphalt = new Lazy<UIColor>(() => "34495E".ToUIColor());
            public static UIColor WetAsphalt { get { return wetAsphalt.Value; } }

            static Lazy<UIColor> midnightBlue = new Lazy<UIColor>(() => "2C3E50".ToUIColor());
            public static UIColor MidnightBlue { get { return midnightBlue.Value; } }

            static Lazy<UIColor> sunFlower = new Lazy<UIColor>(() => "F1C40F".ToUIColor());
            public static UIColor SunFlower { get { return sunFlower.Value; } }

            static Lazy<UIColor> orange = new Lazy<UIColor>(() => "F39C12".ToUIColor());
            public static UIColor Orange { get { return orange.Value; } }

            static Lazy<UIColor> carrot = new Lazy<UIColor>(() => "E67E22".ToUIColor());
            public static UIColor Carrot { get { return carrot.Value; } }

            static Lazy<UIColor> pumpkin = new Lazy<UIColor>(() => "D35400".ToUIColor());
            public static UIColor Pumpkin { get { return pumpkin.Value; } }

            static Lazy<UIColor> alizarin = new Lazy<UIColor>(() => "E74C3C".ToUIColor());
            public static UIColor Alizarin { get { return alizarin.Value; } }

            static Lazy<UIColor> pomegranate = new Lazy<UIColor>(() => "C0392B".ToUIColor());
            public static UIColor Pomegranate { get { return pomegranate.Value; } }

            static Lazy<UIColor> clouds = new Lazy<UIColor>(() => "ECF0F1".ToUIColor());
            public static UIColor Clouds { get { return clouds.Value; } }

            static Lazy<UIColor> silver = new Lazy<UIColor>(() => "BDC3C7".ToUIColor());
            public static UIColor Silver { get { return silver.Value; } }

            static Lazy<UIColor> concrete = new Lazy<UIColor>(() => "95A5A6".ToUIColor());
            public static UIColor Concrete { get { return concrete.Value; } }

            static Lazy<UIColor> asbestos = new Lazy<UIColor>(() => "7F8C8D".ToUIColor());
            public static UIColor Asbestos { get { return asbestos.Value; } }
        }
    }
}

