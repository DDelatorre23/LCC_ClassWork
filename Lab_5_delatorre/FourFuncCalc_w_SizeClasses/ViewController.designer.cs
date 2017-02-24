// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FourFuncCalc
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AboutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AdditionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ClearButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DisplayLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DivisionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EightButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EqualsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FiveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FourButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwipeGestureRecognizer historyCalcSwipeGesture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MultiplyButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NineButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton OneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SevenButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SixButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubtractButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SymbolLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ThreeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TwoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ZeroButton { get; set; }

        [Action ("Clear_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Clear_TouchUpInside (UIKit.UIButton sender);

        [Action ("Equals_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Equals_TouchUpInside (UIKit.UIButton sender);

        [Action ("Numeral_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Numeral_TouchUpInside (UIKit.UIButton sender);

        [Action ("Operation_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Operation_TouchUpInside (UIKit.UIButton sender);

        [Action ("View_SwipeRecognized:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void View_SwipeRecognized (UIKit.UISwipeGestureRecognizer sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutButton != null) {
                AboutButton.Dispose ();
                AboutButton = null;
            }

            if (AdditionButton != null) {
                AdditionButton.Dispose ();
                AdditionButton = null;
            }

            if (ClearButton != null) {
                ClearButton.Dispose ();
                ClearButton = null;
            }

            if (DisplayLabel != null) {
                DisplayLabel.Dispose ();
                DisplayLabel = null;
            }

            if (DivisionButton != null) {
                DivisionButton.Dispose ();
                DivisionButton = null;
            }

            if (EightButton != null) {
                EightButton.Dispose ();
                EightButton = null;
            }

            if (EqualsButton != null) {
                EqualsButton.Dispose ();
                EqualsButton = null;
            }

            if (FiveButton != null) {
                FiveButton.Dispose ();
                FiveButton = null;
            }

            if (FourButton != null) {
                FourButton.Dispose ();
                FourButton = null;
            }

            if (historyCalcSwipeGesture != null) {
                historyCalcSwipeGesture.Dispose ();
                historyCalcSwipeGesture = null;
            }

            if (MultiplyButton != null) {
                MultiplyButton.Dispose ();
                MultiplyButton = null;
            }

            if (NineButton != null) {
                NineButton.Dispose ();
                NineButton = null;
            }

            if (OneButton != null) {
                OneButton.Dispose ();
                OneButton = null;
            }

            if (SevenButton != null) {
                SevenButton.Dispose ();
                SevenButton = null;
            }

            if (SixButton != null) {
                SixButton.Dispose ();
                SixButton = null;
            }

            if (SubtractButton != null) {
                SubtractButton.Dispose ();
                SubtractButton = null;
            }

            if (SymbolLabel != null) {
                SymbolLabel.Dispose ();
                SymbolLabel = null;
            }

            if (ThreeButton != null) {
                ThreeButton.Dispose ();
                ThreeButton = null;
            }

            if (TwoButton != null) {
                TwoButton.Dispose ();
                TwoButton = null;
            }

            if (ZeroButton != null) {
                ZeroButton.Dispose ();
                ZeroButton = null;
            }
        }
    }
}