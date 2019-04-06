// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Login progress.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
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


        #region Declarations

        /// <summary>
        /// The log progress color
        /// </summary>
        private Color logProgressColor = Color.FromArgb(0, 160, 199);
        /// <summary>
        /// The log border color
        /// </summary>
        private Color logBorderColor = Color.FromArgb(35, 35, 35);
        /// <summary>
        /// The log base color
        /// </summary>
        private Color logBaseColor = Color.FromArgb(42, 42, 42);
        /// <summary>
        /// The log font color
        /// </summary>
        private Color logFontColor = Color.FromArgb(50, 50, 50);
        /// <summary>
        /// The second colour
        /// </summary>
        private Color _SecondColour = Color.FromArgb(0, 145, 184);
        /// <summary>
        /// The two colour
        /// </summary>
        private bool _TwoColour = true;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the second colour.
        /// </summary>
        /// <value>The second colour.</value>
        public Color SecondColour
        {
            get { return _SecondColour; }
            set { _SecondColour = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [two colour].
        /// </summary>
        /// <value><c>true</c> if [two colour]; otherwise, <c>false</c>.</value>
        [Category("Control")]
        public bool TwoColour
        {
            get { return _TwoColour; }
            set { _TwoColour = value; }
        }

        /// <summary>
        /// Gets or sets the color of the log progress.
        /// </summary>
        /// <value>The color of the log progress.</value>
        [Category("Colours")]
        public Color LogProgressColor
        {
            get { return logProgressColor; }
            set { logProgressColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the log base.
        /// </summary>
        /// <value>The color of the log base.</value>
        [Category("Colours")]
        public Color LogBaseColor
        {
            get { return logBaseColor; }
            set { logBaseColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the log border.
        /// </summary>
        /// <value>The color of the log border.</value>
        [Category("Colours")]
        public Color LogBorderColor
        {
            get { return logBorderColor; }
            set { logBorderColor = value; }
        }


        #endregion


        #region Draw Control
        /// <summary>
        /// Logs the in progress bar.
        /// </summary>
        private void LogInProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        /// <summary>
        /// Logs the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void LogOnPaint(PaintEventArgs e)
        {
            Rectangle Base = new Rectangle(0, 0, Width, Height);

            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.TextRenderingHint = TextRendering;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(Parent.BackColor);

            int ProgVal = Convert.ToInt32(Value * (1 / Maximum) * Width);

            if (Value == 0)
            {
                G.FillRectangle(new SolidBrush(logBaseColor), Base);
                G.FillRectangle(new SolidBrush(logProgressColor), new Rectangle(0, 0, ProgVal - 1, Height));
                G.DrawRectangle(new Pen(logBorderColor, 3), Base);

            }
            else if (Value == Maximum)
            {
                G.FillRectangle(new SolidBrush(logBaseColor), Base);
                G.FillRectangle(new SolidBrush(logProgressColor), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    G.SetClip(new Rectangle(0, -10, ProgVal - 1, Height - 5));
                    for (int i = 0; i <= ProgVal - 1; i += 25) //(Width - 1) * Maximum / Value
                    {
                        G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 15), Height));
                    }
                    G.ResetClip();
                }
                else
                {
                }
                G.DrawRectangle(new Pen(logBorderColor, 3), Base);

            }
            else
            {
                G.FillRectangle(new SolidBrush(logBaseColor), Base);
                G.FillRectangle(new SolidBrush(logProgressColor), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    G.SetClip(new Rectangle(0, 0, Convert.ToInt32(Width * Value / Maximum - 1), Height - 1));
                    for (int i = 0; i <= (Width - 1) * Maximum / Value; i += 25)
                    {
                        G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 10), Height));
                    }
                    G.ResetClip();
                }
                else
                {
                }
                G.DrawRectangle(new Pen(logBorderColor, 3), Base);

            }

            //G.InterpolationMode = InterpolationMode;

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

        #endregion


    }

}

