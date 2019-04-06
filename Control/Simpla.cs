// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Simpla.cs" company="Zeroit Dev Technologies">
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
        /// The simpla ofs
        /// </summary>
        private int simplaOFS = 0;
        /// <summary>
        /// The simpla speed
        /// </summary>
        private int simplaSpeed = 50;
        

        /// <summary>
        /// Simplas the create handle.
        /// </summary>
        private void SimplaCreateHandle()
        {
            // Dim tmr As New Timer With {.Interval = simplaSpeed}
            // AddHandler tmr.Tick, AddressOf SimplaAnimate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(SimplaAnimate);
            T.IsBackground = true;
            //T.Start()
        }
        /// <summary>
        /// Simplas the animate.
        /// </summary>
        public void SimplaAnimate()
        {
            while (true)
            {
                if (simplaOFS <= Width)
                {
                    simplaOFS += 1;
                }
                else
                {
                    simplaOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(simplaSpeed);
            }
        }
        
        #endregion

        /// <summary>
        /// Enum ColorSchemes
        /// </summary>
        public enum ColorSchemes
        {
            /// <summary>
            /// The dark gray
            /// </summary>
            DarkGray,
            /// <summary>
            /// The green
            /// </summary>
            Green,
            /// <summary>
            /// The blue
            /// </summary>
            Blue,
            /// <summary>
            /// The white
            /// </summary>
            White,
            /// <summary>
            /// The red
            /// </summary>
            Red
        }
        /// <summary>
        /// The color scheme
        /// </summary>
        private ColorSchemes _ColorScheme;
        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Simplas the progress bar.
        /// </summary>
        private void SimplaProgressBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Simplas the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void SimplaOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);

            int intValue = Convert.ToInt32(Value / Maximum * Width);

            
            
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));

            SolidBrush percentColor = new SolidBrush(Color.White);
            ////// Bar Fill
            if (!(intValue == 0))
            {
                switch (ColorScheme)
                {
                    case ColorSchemes.DarkGray:
                        LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90);
                        G.FillPath(g1, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.Green:
                        LinearGradientBrush g11 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90);
                        G.FillPath(g11, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.Blue:
                        LinearGradientBrush g12 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90);
                        G.FillPath(g12, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                    case ColorSchemes.White:
                        LinearGradientBrush g13 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90);
                        G.FillPath(g13, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.FromArgb(20, 20, 20));
                        break;
                    case ColorSchemes.Red:
                        LinearGradientBrush g14 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90);
                        G.FillPath(g14, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));
                        percentColor = new SolidBrush(Color.White);
                        break;
                }
            }

            ////// Outer Rectangle
            G.DrawPath(new Pen(Color.FromArgb(190, 56, 56, 56)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            ////// Bar Size
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

            if (ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
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

