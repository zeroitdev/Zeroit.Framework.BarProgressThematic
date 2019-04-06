// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="NYX.cs" company="Zeroit Dev Technologies">
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
        /// Nyxes the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void NYXPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            G.Clear(Color.FromArgb(22, 22, 22));
            //Background

            ColorBlend bar_cblend = new ColorBlend()
            {
                Colors = new Color[]
                {
                    Color.FromArgb(210, 10, 10),
                    Color.FromArgb(120, 10, 10),
                    Color.FromArgb(165, 10, 10)
                },
                Positions = new float[]
                {
                    0,
                    0.5f,
                    1
                }
            };

            ColorBlend bg_cblend = new ColorBlend()
            {
                Colors = new Color[]
                {
                    Color.FromArgb(20, 20, 20),
                    Color.FromArgb(15, 15, 15),
                    Color.FromArgb(20, 20, 20)
                },
                Positions = new float[]
                {
                    0,
                    0.5f,
                    1
                }
            };

            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);
            
            DrawGradients(G,bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
            //Bar
            
            
            DrawGradients(G,bar_cblend, new Rectangle(1, 1, progressWidth - 2, Height - 2));
            //Border
            Point[] borderPoints = {
                new Point(0, 2),
                new Point(2, 0),
                new Point(Width - 3, 0),
                new Point(Width - 1, 2),
                new Point(Width - 1, Height - 3),
                new Point(Width - 3, Height - 1),
                new Point(2, Height - 1),
                new Point(0, Height - 3)
            };

            G.DrawPolygon(Pens.Black, borderPoints);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

}

