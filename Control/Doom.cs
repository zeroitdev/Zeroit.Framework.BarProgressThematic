// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Doom.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.BarProgressThematic.Controls
{

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    public partial class BarProgressThematic
    {


        /// <summary>
        /// The cblend
        /// </summary>
        ColorBlend cblend = new ColorBlend()
        {
            Colors = new Color[]
            {
                Color.Red,
                Color.Transparent,
                Color.FromArgb(255, 90, 8, 8)

            },
            Positions = new float[]
            {
                0,
                0.5f,
                1
            }
        };

        /// <summary>
        /// Dooms the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DoomPaintHook(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);
            //G.Clear(Color.Black);
            //Border
            Rectangle left = new Rectangle(0, 0, 60, Height - 1);
            LinearGradientBrush leftLGB = new LinearGradientBrush(left, Color.FromArgb(255, 32, 32, 32), Color.FromArgb(100, Color.White), 180f);
            G.FillRectangle(leftLGB, left);
            Rectangle right = new Rectangle(Width - 61, 0, 60, Height - 1);
            LinearGradientBrush rightLGB = new LinearGradientBrush(right, Color.FromArgb(100, Color.White), Color.FromArgb(255, 32, 32, 32), 180f);
            G.FillRectangle(rightLGB, right);
            Rectangle middle = new Rectangle(60, 0, Width - 120, Height - 1);
            SolidBrush middleSB = new SolidBrush(Color.FromArgb(255, 32, 32, 32));
            G.FillRectangle(middleSB, middle);
            //Background
            Rectangle rect = new Rectangle(2, 2, Width - 4, Height - 4);
            HatchBrush backHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(255, 10, 10, 10), Color.FromArgb(255, 11, 11, 11));
            G.FillRectangle(backHB, rect);
            //Bar
            
            //cblend.Colors[0] = Color.Red;
            //cblend.Colors[1] = Color.FromArgb(255, 90, 8, 8);
            //cblend.Positions[0] = 0;
            //cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(2, 2, Convert.ToInt32(((Width / Maximum) * Value) - 4), Height - 4));
            //Border
            DrawBorders(Pens.Black, 0);
            DrawBorders(Pens.Black, 2);
            
        }

    }

}

