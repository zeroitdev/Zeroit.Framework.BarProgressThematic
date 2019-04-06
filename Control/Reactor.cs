// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Reactor.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.BarProgressThematic.Controls
{

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    public partial class BarProgressThematic
    {


        #region " Control Help - Properties & Flicker Control "

        //---------------------------Include in Paint--------------------//
        //                                                               //
        //        G.RenderingOrigin = new Point(reactorOFS, 0);          //
        //                                                               //
        //---------------------------Include in Paint--------------------//

        /// <summary>
        /// The reactor ofs
        /// </summary>
        private int reactorOFS = 0;
        /// <summary>
        /// The reactor speed
        /// </summary>
        private int reactorSpeed = 50;

        /// <summary>
        /// Reactors the create handle.
        /// </summary>
        private void ReactorCreateHandle()
        {
            // Dim tmr As New Timer With {.Interval = reactorSpeed}
            // AddHandler tmr.Tick, AddressOf ReactorAnimate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(ReactorAnimate);
            T.IsBackground = true;
            T.Start();
        }

        /// <summary>
        /// Reactors the animate.
        /// </summary>
        public void ReactorAnimate()
        {
            while (true)
            {
                if (reactorOFS <= Width)
                {
                    reactorOFS += 1;
                }
                else
                {
                    reactorOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(reactorSpeed);
            }
        }


        #endregion

        /// <summary>
        /// Reactors the progress bar.
        /// </summary>
        private void ReactorProgressBar()
        {
            DoubleBuffered = true;
        }

        /// <summary>
        /// Reactors the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ReactorOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);
            int intValue = Convert.ToInt32(Value / Maximum * Width);
            

            LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, intValue - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
            G.FillRectangle(backGrad, new Rectangle(1, 1, intValue - 1, Height - 2));
            HatchBrush hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(175, 219, 78, 0), Color.FromArgb(175, 229, 98, 0));
            G.RenderingOrigin = new Point(reactorOFS, 0);
            G.FillRectangle(hatch, new Rectangle(1, 1, intValue - 2, Height - 2));
            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, intValue - 2, Height / 2 - 1), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, intValue - 2, Height / 2 - 1));

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

}

