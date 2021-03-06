﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="EightBall.cs" company="Zeroit Dev Technologies">
//    This program is for creating a progress bar control.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Zeroit.Framework.BarProgressThematic.ThemeManagers;

namespace Zeroit.Framework.BarProgressThematic.Controls
{

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    public partial class BarProgressThematic
    {

        /// <summary>
        /// The bar color
        /// </summary>
        private Color _barColor = Color.Gray;
        /// <summary>
        /// Gets or sets the color of the bar.
        /// </summary>
        /// <value>The color of the bar.</value>
        public Color BarColor
        {
            get { return _barColor; }
            set
            {
                _barColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Eights the ball progressbar.
        /// </summary>
        private void EightBallProgressbar()
        {
            Size = new Size(200, 26);
            
        }

        /// <summary>
        /// Eights the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void EightOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap b = new Bitmap(Width, Height);
            Graphics g = e.Graphics;
            g.SmoothingMode = Smoothing;
            g.Clear(Parent.BackColor);

            int slope = 6;

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath mainPath = Draw.RoundRect(mainRect, slope);
            LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, BackColor, Color.FromArgb(25, 25, 25), 90f);
            g.FillPath(bgBrush, mainPath);

            float percent = (Value / Maximum) * 100;
            if (percent > 2.75)
            {
                Rectangle barRect = new Rectangle(0, 0, Convert.ToInt32((Width / Maximum) * _value) - 1, Height - 1);
                GraphicsPath barPath = Draw.RoundRect(barRect, slope);
                LinearGradientBrush barBrush = new LinearGradientBrush(barRect, BarColor, Color.FromArgb(45, 45, 45), 90f);
                g.FillPath(barBrush, barPath);
            }

            g.DrawPath(new Pen(Color.FromArgb(50, 50, 50)), mainPath);

            //e.Graphics.DrawImage(b, 0, 0);

            //g.Dispose();
            //b.Dispose();

        }


    }

}

