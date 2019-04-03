// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="ButterScotch progressbar.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

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
        /// Butters the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void ButterOnPaint(PaintEventArgs e)
        {
            //Bitmap b = new Bitmap(Width, Height);
            Graphics g = e.Graphics;
            int percent = Convert.ToInt32((Width - 1) * (Value / Maximum));
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle maininnerrect = new Rectangle(7, 7, Width - 15, Height - 15);
            Rectangle innerrect = new Rectangle(4, 4, percent - 9, Height - 9);
            //g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(new SolidBrush(Color.FromArgb(40, 37, 33)), Draw.RoundRect(outerrect, 5));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(outerrect, 5));
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(maininnerrect, 3));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(maininnerrect, 3));
            if (percent != 0)
            {
                LinearGradientBrush progressgb = new LinearGradientBrush(innerrect, Color.FromArgb(91, 82, 73), Color.FromArgb(57, 52, 46), 90);
                g.FillPath(progressgb, Draw.RoundRect(innerrect, 7));
            }
            if (ShowPercentage)
            {
                g.DrawString(string.Format("{0}%", Value), new Font("Segoe UI", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(246, 180, 12)), new Rectangle(10, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            //e.Graphics.DrawImage(b, new Point(0, 0));
            //g.Dispose();
            //b.Dispose();
        }

    }


}

