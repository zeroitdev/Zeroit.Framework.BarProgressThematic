// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Ambiance.cs" company="Zeroit Dev Technologies">
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


        #region Enums 

        /// <summary>
        /// Enum Alignment
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// The right
            /// </summary>
            Right,
            /// <summary>
            /// The center
            /// </summary>
            Center
        }

        #endregion
        #region Variables 


        /// <summary>
        /// The aln
        /// </summary>
        private Alignment ALN = Alignment.Center;
        /// <summary>
        /// The draw hatch
        /// </summary>
        private bool _DrawHatch = true;

        //private int I1;

        #endregion
        #region Properties 

        /// <summary>
        /// Gets or sets the value alignment.
        /// </summary>
        /// <value>The value alignment.</value>
        public Alignment ValueAlignment
        {
            get { return ALN; }
            set
            {
                ALN = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw hatch].
        /// </summary>
        /// <value><c>true</c> if [draw hatch]; otherwise, <c>false</c>.</value>
        public bool DrawHatch
        {
            get { return _DrawHatch; }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }


        #endregion
        #region EventArgs

        /// <summary>
        /// Ambiances the on resize.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AmbianceOnResize(EventArgs e)
        {
            this.Height = 20;
            Size minimumSize = new Size(58, 20);
            this.MinimumSize = minimumSize;
        }

        #endregion

        /// <summary>
        /// Ambiances the progress bar.
        /// </summary>
        private void Ambiance_ProgressBar()
        {
            Maximum = 100;
            ShowPercentage = true;
            _DrawHatch = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }


        /// <summary>
        /// Ambiances the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void AmbianceOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;

           
            //G.SmoothingMode = Smoothing;

            //G.Clear(Parent.BackColor);
            

            GraphicsPath GP1 = Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 4);
            GraphicsPath  GP2 = Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4);

            Rectangle R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            LinearGradientBrush GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);

            // Draw inside background
            G.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), R1);
            G.SetClip(GP1);
            G.FillPath(new SolidBrush(Color.FromArgb(244, 241, 243)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));


            dynamic I1 = (int)Math.Round(((double)(this.Value - this.Minimum) / (double)(this.Maximum - this.Minimum)) * (double)(this.Width - 3));
            if (I1 > 1)
            {
                GraphicsPath GP3 = Draw.RoundRect(new Rectangle(1, 1, I1, Height - 3), 4);

                Rectangle R2 = new Rectangle(1, 1, I1, Height - 3);
                LinearGradientBrush GB2 = new LinearGradientBrush(R2, Color.FromArgb(214, 89, 37), Color.FromArgb(223, 118, 75), 90f);

                // Fill the value with its gradient
                G.FillPath(GB2, GP3);

                // Draw diagonal lines
                if (_DrawHatch == true)
                {
                    for (var i = 0; i <= (Width - 1) * Maximum / Value; i += 20)
                    {
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10.0F), new Point(System.Convert.ToInt32(i), 0), new Point((int)(i - 10), Height));
                    }
                }

                G.SetClip(GP3);
                G.ResetClip();
            }

            // Draw value as a string
            string DrawString = Convert.ToString(Convert.ToInt32(Value)) + "%";
            int textX = (int)(this.Width - G.MeasureString(DrawString, Font).Width - 1);
            int textY = (int)((this.Height / 2) - (System.Convert.ToInt32(G.MeasureString(DrawString, Font).Height / 2) - 2));

            if (ShowPercentage == true)
            {
                switch (ValueAlignment)
                {
                    case Alignment.Right:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Point(textX, textY));
                        break;
                    case Alignment.Center:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Rectangle(0, 0, Width, Height + 2), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            // Draw border
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), GP2);

            //e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }
}
