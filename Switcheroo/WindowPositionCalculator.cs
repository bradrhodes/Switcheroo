﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Switcheroo
{
	public interface ICalculateWindowPosition
	{
		WindowPosition CalculateWindowPosition(Screen screen, double windowWidth, double windowHeight);
	}

	class WindowPositionCalculator : ICalculateWindowPosition
	{
		public WindowPosition CalculateWindowPosition(Screen screen, double windowWidth, double windowHeight)
		{
			var top = screen.Bounds.X + (((double) screen.Bounds.Width/2) - (windowWidth/2));
			var left = screen.Bounds.Y + (((double) screen.Bounds.Height/2) - (windowHeight/2));

			return new WindowPosition
			{
				Left = Math.Round(screen.Bounds.X + (((double) screen.Bounds.Width/2) - (windowWidth/2))),
				Top = Math.Round(screen.Bounds.Y + (((double) screen.Bounds.Height/2) - (windowHeight/2)))
			};
		}
	}

	public class WindowPosition
	{
		public double Top { get; set; }
		public double Left { get; set; }
	}
}