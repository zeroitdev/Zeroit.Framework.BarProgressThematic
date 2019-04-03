// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Black.cs" company="Zeroit Dev Technologies">
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
        /// The black blend
        /// </summary>
        private ColorBlend blackBlend = new ColorBlend()
        {
            Colors = new Color[]
            {
                Color.FromArgb(37, 37, 37),
                Color.FromArgb(64, 66, 68),
                Color.FromArgb(64, 66, 68),
                Color.FromArgb(37, 37, 37)
            },
            Positions = new float[]
            {
                0f,
                0.4f,
                0.6f,
                1f
            }

        };
        /// <summary>
        /// Blacks the progress bar.
        /// </summary>
        private void BlackProgressBar()
        {

            IsAnimated = true;

        }

        /// <summary>
        /// The black glow position
        /// </summary>
        private float blackGlowPosition = -1f;

        /// <summary>
        /// Subspaces the on animation.
        /// </summary>
        private void SubspaceOnAnimation()
        {
            blackGlowPosition += 0.05f;
            if (blackGlowPosition >= 1f)
                blackGlowPosition = -1f;
        }



        /// <summary>
        /// The black p1
        /// </summary>
        Color blackP1 = Color.FromArgb(32, 32, 32);
        /// <summary>
        /// The black p2
        /// </summary>
        Color blackP2 = Color.FromArgb(15, Color.White);
        /// <summary>
        /// The black p3
        /// </summary>
        Color blackP3 = Color.Black;
        /// <summary>
        /// The black p4
        /// </summary>
        Color blackP4 = Color.Black;

        /// <summary>
        /// The black b1
        /// </summary>
        Color blackB1 = Color.FromArgb(50, 50, 50);
        /// <summary>
        /// The black b2
        /// </summary>
        Color blackB2 = Color.FromArgb(37, 37, 37);
        /// <summary>
        /// The black b3
        /// </summary>
        Color blackB3 = Color.FromArgb(13, Color.White);

        /// <summary>
        /// The black c1
        /// </summary>
        Color blackC1 = Color.FromArgb(8, 8, 8);
        /// <summary>
        /// The black c2
        /// </summary>
        Color blackC2 = Color.FromArgb(23, 23, 23);



        /// <summary>
        /// Blacks the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void BlackPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            DrawBorders(new Pen(blackP1), 1);
            G.FillRectangle(new SolidBrush(blackB1), 0, 0, Width, 8);

            DrawGradient(blackC1, blackC2, 2, 2, Width - 4, Height - 4, 90f);

            dynamic Progress = Convert.ToInt32((Value / Maximum) * Width);

            if (!(Progress == 0))
            {
                R1 = new Rectangle(3, 3, Progress - 6, Height - 6);

                G.SetClip(R1);
                G.FillRectangle(new SolidBrush(blackB2), 0, 0, Progress, Height);

                DrawGradient(blackBlend, Convert.ToInt32(blackGlowPosition * Progress), 0, Progress, Height, 0f);
                DrawBorders(new Pen(blackP2), 3, 3, Progress - 6, Height - 6);

                G.FillRectangle(new SolidBrush(blackB3), 3, 3, Width - 6, 5);
                G.ResetClip();
            }

            DrawBorders(new Pen(blackP3), 2);
            DrawBorders(new Pen(blackP4));

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }


    }

}
