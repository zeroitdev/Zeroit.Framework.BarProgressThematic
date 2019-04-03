// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Gray.cs" company="Zeroit Dev Technologies">
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
        /// Grays the progress bar.
        /// </summary>
        private void GrayProgressBar()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            //_maximum = 100;
            //_minimum = 0;
            //_value = 0;
        }

        /// <summary>
        /// Grays the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void GrayOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            //G.Clear(Parent.BackColor);

            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);


            G.FillPath(DesignFunctions.ToBrush(85, 85, 85), DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));

            LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135));

            G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(0, 1, progressWidth - 1, Height - 3, 3));
            G.DrawPath(DesignFunctions.ToPen(150, Color.Black), DesignFunctions.RoundRect(0, 1, progressWidth - 1, Height - 3, 3));
            
            if (Value > 0)
            {
                G.SmoothingMode = SmoothingMode.AntiAlias;

                G.SetClip(DesignFunctions.RoundRect(0, 0, progressWidth - 1, Height - 1, 3));
                for (int i = 0; i <= progressWidth - 1; i += 25)
                {
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(35, Color.White)), 10), new Point(i, 0 - 5), new Point(i + 25, Height + 10));
                }
                G.ResetClip();

                G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(2, 1), new Point(Convert.ToInt32((Width - 3) * _value / Maximum - 3), 1));

                G.SmoothingMode = SmoothingMode.None;
            }

            G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 3));

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

}

