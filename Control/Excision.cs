﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Excision.cs" company="Zeroit Dev Technologies">
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
        /// The ofs
        /// </summary>
        private int OFS = 0;
        /// <summary>
        /// The speed
        /// </summary>
        private int Speed = 50;



        /// <summary>
        /// Excisions the on create handle.
        /// </summary>
        private void ExcisionOnCreateHandle()
        {
            base.CreateHandle();
            // Dim tmr As New Timer With {.Interval = Speed}
            // AddHandler tmr.Tick, AddressOf ExcisionAnimate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(ExcisionAnimate);
            T.IsBackground = true;
            //T.Start()
        }

        /// <summary>
        /// Excisions the animate.
        /// </summary>
        public void ExcisionAnimate()
        {
            while (true)
            {
                if (OFS <= Width)
                {
                    OFS += 1;
                }
                else
                {
                    OFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(Speed);
            }
        }
        #endregion

        /// <summary>
        /// Excisions the progress bar.
        /// </summary>
        private void ExcisionProgressBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Excisions the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ExcisionOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;

            G.SmoothingMode = Smoothing;

            int intValue = Convert.ToInt32(Value / Maximum * Width);
            G.Clear(Parent.BackColor);

            ImageToCodeClass d = new ImageToCodeClass();
            Bitmap GRAINIMAGE2 = (Bitmap)d.CodeToImage("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");
            TextureBrush TEXTUREIMAGE2 = new TextureBrush(GRAINIMAGE2, WrapMode.TileFlipX);
            ////// Inner Fill
            G.FillPath(TEXTUREIMAGE2, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));

            ////// Bar Fill
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(60, 60, 60), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(g1, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

            ///// Bar Overlap
            //Dim h1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(40, Color.White), Color.FromArgb(20, Color.White))
            //G.FillPath(h1, Draw.RoundRect(New Rectangle(0, 0, intValue - 1, Height - 2), 1))

            ////// Outer Rectangle
            G.DrawPath(new Pen(Color.FromArgb(190, 70, 70, 70)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            ////// Bar Size
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

            if (ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
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

