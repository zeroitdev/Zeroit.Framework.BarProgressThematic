// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="xVisual.cs" company="Zeroit Dev Technologies">
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


        #region " Control Help - Properties & Flicker Control "
        /// <summary>
        /// The x visual ofs
        /// </summary>
        private int xVisualOFS = 0;
        /// <summary>
        /// The x visual speed
        /// </summary>
        private int xVisualSpeed = 50;


        /// <summary>
        /// Xvisuals the animate.
        /// </summary>
        public void XvisualAnimate()
        {
            while (true)
            {
                if (xVisualOFS <= Width)
                {
                    xVisualOFS += 1;
                }
                else
                {
                    xVisualOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(xVisualSpeed);
            }
        }
        #endregion

        /// <summary>
        /// xes the visual progress bar.
        /// </summary>
        private void xVisualProgressBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(274, 30);
        }

        /// <summary>
        /// The inner texture
        /// </summary>
        TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(55, 52, 48),
        Color.FromArgb(57, 50, 50),
        Color.FromArgb(53, 50, 46)
    });
        /// <summary>
        /// xes the visual on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void xVisualOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);

            int intValue = Convert.ToInt32(Value / Maximum * Width);
            

            SolidBrush percentColor = new SolidBrush(Color.White);

            G.FillRectangle(InnerTexture, new Rectangle(0, 0, Width - 1, Height - 1));

            ColorBlend blend = new ColorBlend();

            //Add the Array of Color
            Color[] bColors = new Color[] {
            Color.FromArgb(20, Color.White),
            Color.FromArgb(10, Color.Black),
            Color.FromArgb(10, Color.White)
        };
            blend.Colors = bColors;

            //Add the Array Single (0-1) colorpoints to place each Color
            float[] bPts = new float[] {
            0,
            0.8f,
            1
        };
            blend.Positions = bPts;

            using (LinearGradientBrush br = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.White, Color.Black, LinearGradientMode.Vertical))
            {

                //Blend the colors into the Brush
                br.InterpolationColors = blend;

                //Fill the rect with the blend
                G.FillRectangle(br, new Rectangle(0, 0, Width - 1, Height - 1));

            }

            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 1, Width - 3, 1);
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 60, 57)), 1, Height - 2, Width - 3, Height - 2);

            ////// Bar Fill
            if (!(intValue == 0))
            {
                G.FillRectangle(new LinearGradientBrush(new Rectangle(2, 2, intValue - 3, Height - 4), Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90), new Rectangle(2, 2, intValue - 3, Height - 4));
                G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), 2, 2, intValue - 2, 2);
                //G.DrawLine(GetPen(Color.FromArgb(27, 25, 23)), 2, Height - 2, intValue + 1, Height - 2)
                percentColor = new SolidBrush(Color.White);
            }

            if (ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), Draw.GetBrush(Color.FromArgb(20, 20, 20)), new Rectangle(1, 2, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            //G.Dispose();
            //B.Dispose();

        }

    }

}

