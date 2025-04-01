using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace AGM
{
	public partial class MathPendulum : Page
	{
		bool _isDragging = false;

		public MathPendulum()
		{
			InitializeComponent();

			materialDotRotate.CenterX = materialDot.Width / 2;
			materialDotRotate.CenterY = -(thread.Height + pivot.Height / 2);
			threadRotate.CenterX = thread.Width / 2;
			threadRotate.CenterY = -(pivot.Height / 2);

		}

		private void MaterialDotMouseEnter(object sender, EventArgs e)
		{
			materialDot.Stroke = Brushes.Black;
		}

		private void MaterialDotMouseClick(object sender, MouseEventArgs e)
		{
			if (_isDragging)
			{
				_isDragging = false;

				Mouse.Capture(null);
			}
			else
			{
				_isDragging = true;
			}
		}

		private void MaterialDotMouseMove(object sender, MouseEventArgs e)
		{
			if (_isDragging)
			{
				Mouse.Capture(materialDot);

				var mousePos = e.GetPosition(this);
				var pivotPos = pivot.TransformToAncestor(this).Transform(new Point(0, 0));

				double angle = Math.Acos((mousePos.Y - pivotPos.Y) / Math.Sqrt(Math.Pow(mousePos.X - pivotPos.X, 2) + Math.Pow(mousePos.Y - pivotPos.Y, 2))) * (180 / Math.PI);
				angle = mousePos.X > pivotPos.X ? -angle : angle;

				materialDotRotate.Angle = angle;

				threadRotate.Angle = angle;
			}
		}

		private void MaterialDotMouseLeave(object sender, EventArgs e)
		{
			materialDot.Stroke = null;
		}
	}
}
