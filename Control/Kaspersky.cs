// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Kaspersky.cs" company="Zeroit Dev Technologies">
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
        /// Kasperskies the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void KasperskyOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            //G.Clear(Parent.BackColor);

            int progressWidth = Convert.ToInt32(Math.Truncate((Value / Maximum) * this.Width));

            Rectangle progressRect = new Rectangle(0, 0, progressWidth, this.Height);

            if (Value > 0)
            {
                LinearGradientBrush pbg = new LinearGradientBrush(progressRect, Color.FromArgb(2, 158, 131), Color.FromArgb(4, 129, 107), LinearGradientMode.Vertical);

                //G.FillRectangle(pbg, new Rectangle(0, 0, progressWidth, this.Height));

                GraphicsPath gpth = Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32(Math.Truncate((Value / Maximum) * this.Width)) - 4, this.Height - 5), 3);
                G.FillPath(pbg, gpth);

                //Draw.DrawRoundRect(G, Pens.Gray, 0, 0, Convert.ToInt32(Math.Truncate((Value / Maximum) * this.Width)) - 1, this.Height - 1, 3);
            }
            RectangleF r1 = new RectangleF(1, 1, this.Width - 2, this.Height - 4);
            r1.Width = Convert.ToSingle(r1.Width * Value / Maximum);
            Region reg1 = new Region(r1);
            Region reg2 = new Region(this.ClientRectangle);
            reg2.Exclude(reg1);

            SizeF textSize = G.MeasureString(this.Text, this.Font);

            float y = (this.ClientRectangle.Height - textSize.Height) / 2;

            G.Clip = reg1;
            G.DrawString(this.Text, this.Font, Brushes.WhiteSmoke, 10, y);
            G.Clip = reg2;

            //G.DrawString(this.Text, this.Font, Brushes.Gray, 10, y);

            G.DrawString(Convert.ToString(_value) + "%", Font, new SolidBrush(ForeColor), new Point(Width / 2 - 9, Height / 2 - 7));

            reg1.Dispose();
            reg2.Dispose();

            Draw.DrawRoundRect(G, Pens.Gray, 0, 0, this.Width-1, this.Height-1, 3);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }


    }

}

