// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Redemption.cs" company="Zeroit Dev Technologies">
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


        #region "Properties"

        #endregion

        /// <summary>
        /// Redemptions the progress bar.
        /// </summary>
        private void RedemptionProgressBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Redemptions the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void RedemptionOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            int curve = 6;
            //Bitmap b = new Bitmap(Width, Height);
            Graphics g = e.Graphics;
            g.SmoothingMode = Smoothing;
            g.TextRenderingHint = TextRendering;



            dynamic Fill = Convert.ToInt32(Value * (1 / Maximum) * Width) - 1;
            
            
            //g.Clear(Parent.BackColor);

            g.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                g.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), curve));
            }

            if (Fill > 4)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(80, 164, 234)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                HatchBrush FillTexture = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 26, 127, 217), Color.Transparent);
                LinearGradientBrush Gloss = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(75, Color.White), Color.FromArgb(65, Color.Black), 90);
                g.FillPath(Gloss, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                g.FillPath(FillTexture, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                LinearGradientBrush FillGradientBorder = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(183, 223, 249), Color.FromArgb(41, 141, 226), 90);
                g.DrawPath(new Pen(FillGradientBorder), Draw.RoundRect(new Rectangle(1, 1, Fill - 2, Height - 4), curve));
                g.DrawPath(new Pen(Color.FromArgb(1, 44, 76)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));

            }

            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            g.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
            g.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));


            //e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
            //g.Dispose();
            //b.Dispose();

        }

    }

}

