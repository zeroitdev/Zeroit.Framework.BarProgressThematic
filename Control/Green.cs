// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Green.cs" company="Zeroit Dev Technologies">
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


        #region " Properties "

        /// <summary>
        /// Gets or sets the color1.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get { return C2; }
            set
            {
                C2 = value;
                //UpdateColors();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color2.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get { return C3; }
            set
            {
                C3 = value;
                //UpdateColors();
                Invalidate();
            }
        }

        #endregion



        /// <summary>
        /// The r1
        /// </summary>
        Rectangle R1 = new Rectangle();
        /// <summary>
        /// The r2
        /// </summary>
        Rectangle R2 = new Rectangle(/*2, 2, 2, 2*/);

        /// <summary>
        /// The x
        /// </summary>
        private ColorBlend X = new ColorBlend()
        {
            Colors = new Color[]
            {
                Color.FromArgb(0, 128, 0),
                Color.FromArgb(0, 255, 0),
                Color.FromArgb(0, 255, 0),
                Color.FromArgb(0, 128, 0)
            },
            Positions = new float[]
            {
                0f,
                0.1f,
                0.9f,
                1f
            }
        };


        /// <summary>
        /// The c1
        /// </summary>
        Color C1 = Color.FromArgb(0, 24, 0);
        //Dark Color
        /// <summary>
        /// The c2
        /// </summary>
        Color C2 = Color.FromArgb(0, 128, 0);

        //Light color
        /// <summary>
        /// The c3
        /// </summary>
        Color C3 = Color.FromArgb(0, 255, 0);

        /// <summary>
        /// The p1
        /// </summary>
        Pen P1 = new Pen(Color.FromArgb(70, Color.White), 2);
        /// <summary>
        /// The p2
        /// </summary>
        Pen P2 = new Pen(Color.FromArgb(0, 128, 0));
        /// <summary>
        /// The p3
        /// </summary>
        Pen P3 = new Pen(Color.FromArgb(65, 122, 49));
        /// <summary>
        /// The b1
        /// </summary>
        LinearGradientBrush B1;
        /// <summary>
        /// The b2
        /// </summary>
        private LinearGradientBrush B2;
        /// <summary>
        /// The b3
        /// </summary>
        SolidBrush B3 = new SolidBrush(Color.FromArgb(100, Color.White));


        /// <summary>
        /// Updates the colors.
        /// </summary>
        private void UpdateColors()
        {
            P2.Color = C2;
            //X.Colors = new Color[]{
            //C2,
            //C3,
            //C3,
            //C2
            //};
            B2.InterpolationColors = X;
        }

        /// <summary>
        /// Greens the on size changed.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GreenOnSizeChanged(System.EventArgs e)
        {
            R1 = new Rectangle(0, 1, Width, 4);
            B1 = new LinearGradientBrush(R1, Color.FromArgb(60, Color.Black), Color.Transparent, 90f);
            UpdateProgress();
            Invalidate();
            
        }

        /// <summary>
        /// Updates the progress.
        /// </summary>
        public void UpdateProgress()
        {
            if (Value == 0)
                return;

            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);

            R2 = new Rectangle(2, 2, progressWidth - 4, Height - 4);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180f);
            B2.InterpolationColors = X;
        }





        /// <summary>
        /// Greens the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void GreenOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;

            R1 = new Rectangle(0, 1, Width, 4);

            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);

            R2 = new Rectangle(2, 2, progressWidth - 4  /*Convert.ToInt32((Width - 4) * (Value * 0.01))*/, Height - 4);

            B1 = new LinearGradientBrush(R1, Color.FromArgb(60, Color.Black), Color.Transparent, 90f);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180f);

            X = new ColorBlend()
            {
                Colors = new Color[]
                {
                    C2,
                    C3,
                    C3,
                    C2
                },
                Positions = new float[]
                {
                    0f,
                    0.1f,
                    0.9f,
                    1f
                }
            };
            B2.InterpolationColors = X;

            G.Clear(C1);

            G.FillRectangle(B1, R1);

            if (Value > 0)
            {
                G.FillRectangle(B2, R2);

                G.FillRectangle(B3, 2, 3, R2.Width, 4);
                G.DrawRectangle(P1, 4, 4, R2.Width - 4, Height - 8);

                G.DrawRectangle(P2, 2, 2, R2.Width - 1, Height - 5);
            }

            G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }


    }

}

