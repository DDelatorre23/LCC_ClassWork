using System;
using System.Collections.Generic;
using UIKit;
using FourFuncCalc;

namespace FourFuncCalc
{
	public partial class ViewController : UIViewController
	{
		string currentCaluclation = "";
		List<string> Calcs;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			Calcs = new List<string>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			AboutButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				AboutController aboutController = this.Storyboard.InstantiateViewController("AboutController") as AboutController;
				this.NavigationController.PushViewController(aboutController, true);
			};
		}

		partial void View_SwipeRecognized(UISwipeGestureRecognizer sender)
		{
			CalculationsHistoryController calcController = this.Storyboard.InstantiateViewController("CalculationsHistoryController") as CalculationsHistoryController;
			if (Calcs != null)
			{
				calcController.Calculations = Calcs;
				this.NavigationController.PushViewController(calcController, true);

			}
		}

		// x will equal the first variable entered by the user, y will be the second variable, and z will be the 
		// result of the x and y.
		string x = "";
		string y = "";
		string z = "";
		string symbol = "";

		partial void Equals_TouchUpInside(UIButton sender)
		{
			// No calculations are performed if either variable is not entered.
			if (x == "" || y == "")
			{
				x = "";
				y = "";
			}
			else
			{
				// Sets the z variable to the value of the result from the RunCalc method and displays it.
				z = RunCalc();
				DisplayLabel.Text = z;
				SymbolLabel.Text = "=";
				currentCaluclation = $"{x} {symbol} {y} = {z}";
				Calcs.Add(currentCaluclation);
			}
			currentCaluclation = "";
			x = "";
			y = "";
			symbol = "";
		}

		partial void Clear_TouchUpInside(UIButton sender)
		{
			x = "";
			y = "";
			z = "";
			symbol = "";
			DisplayLabel.Text = "0";

		}

		partial void Operation_TouchUpInside(UIButton sender)
		{
			// if a user has entered both the x and y variable but has not hit enter
			// a calculation will be performed and then the user can continue entering values
			// using the result as their new x value.
			if (x != "" && y != "" ){

				z = RunCalc();
				DisplayLabel.Text = z;

				x = z;
				y = "";

				symbol = sender.TitleLabel.Text;
				SymbolLabel.Text = symbol;
			}
			else {
				if (x != "" && y == "")
				{
					symbol = sender.TitleLabel.Text;
					SymbolLabel.Text = symbol;
				}
				else {
					if (z != "")
					{
						x = z;
						z = "";

						symbol = sender.TitleLabel.Text;
						SymbolLabel.Text = symbol;
					}
				}
			}

		}

		partial void Numeral_TouchUpInside(UIButton sender)
		{
			
			if (symbol == "")
			{
				x += sender.TitleLabel.Text;
				DisplayLabel.Text = x;

			}
			else
			{
				y += sender.TitleLabel.Text;
				DisplayLabel.Text = y;

			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		// Runs a calculation based on what symbol the user has selected and returns the result.
		private string RunCalc()
		{
			double result = 0.0;
			double a, b;

			// Converts x and y into double variables so that they can be calculated 
			double.TryParse(x, out a);
			double.TryParse(y, out b);

			switch (symbol)
			{
				case "+":
					result = Calculations.Addition(a, b);
					break;
				case "-":
					result = Calculations.Subtraction(a, b);
					break;
				case "x":
					result = Calculations.Multiply(a, b);
					break;
				case "/":
					result = Calculations.Division(a, b);
					break;
			}

			return result.ToString();
		}
	}
}
