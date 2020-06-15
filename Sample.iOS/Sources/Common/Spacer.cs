using System;
using CoreGraphics;
using UIKit;

namespace Sample.iOS
{
    public class Spacer : UIStackView
    {
        public Spacer(nfloat height)
        {
            this.Height = height;

            this.SetContentCompressionResistancePriority(1000.0f, UILayoutConstraintAxis.Vertical);
            this.SetContentHuggingPriority(1000.0f, UILayoutConstraintAxis.Vertical);
        }

        public Spacer()
        {
            this.Height = null;

            this.SetContentCompressionResistancePriority(0.0f, UILayoutConstraintAxis.Vertical);
            this.SetContentHuggingPriority(0.0f, UILayoutConstraintAxis.Vertical);
        }

        private readonly nfloat? Height;

        public override CGSize IntrinsicContentSize => new CGSize(NoIntrinsicMetric, this.Height ?? NoIntrinsicMetric);
    }
}
