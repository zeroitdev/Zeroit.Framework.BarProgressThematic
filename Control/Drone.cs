// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Drone.cs" company="Zeroit Dev Technologies">
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
        /// The blend
        /// </summary>
        private ColorBlend Blend = new ColorBlend()
        {
            Colors = new Color[]
            {
                Color.FromArgb(0, 55, 90),
                Color.FromArgb(0, 66, 108),
                Color.FromArgb(0, 66, 108),
                Color.FromArgb(0, 55, 90)
            },
            Positions = new float[] {
            0f,
            0.4f,
            0.6f,
            1f
        }
    };

        /// <summary>
        /// Drones the progress bar.
        /// </summary>
        private void DroneProgressBar()
        {
            
        }


        /// <summary>
        /// Drones the on creation control.
        /// </summary>
        private void DroneOnCreationControl()
        {
            if (!DesignMode)
            {
                System.Threading.Thread T = new System.Threading.Thread(MoveGlow);
                T.IsBackground = true;
                T.Start();
            }
        }

        /// <summary>
        /// The glow position
        /// </summary>
        private float GlowPosition = -1f;
        /// <summary>
        /// Moves the glow.
        /// </summary>
        private void MoveGlow()
        {
            while (true)
            {
                GlowPosition += 0.01f;
                if (GlowPosition >= 1f)
                    GlowPosition = -1f;
                Invalidate();
                System.Threading.Thread.Sleep(25);
            }
        }


        /// <summary>
        /// Increments the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void Increment(int amount)
        {
            Value += amount;
        }



        /// <summary>
        /// Drones the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DronePaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)), 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, 8);

            DrawGradient(Color.FromArgb(8, 8, 8), Color.FromArgb(23, 23, 23), 2, 2, Width - 4, Height - 4, 90f);

            float Progress = Convert.ToInt32((_value / _Maximum) * Width);

            if (!(Progress == 0))
            {
                G.SetClip(new Rectangle(3, 3, (int)Progress - 6, Height - 6));
                G.FillRectangle(new SolidBrush(Color.FromArgb(0, 55, 90)), 0, 0, Progress, Height);

                DrawGradient(Blend, Convert.ToInt32(GlowPosition * Progress), 0, (int)Progress, Height, 0f);
                DrawBorders(new Pen(Color.FromArgb(15, Color.White)), 3, 3, (int)Progress - 6, Height - 6);

                G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 3, 3, Width - 6, 5);

                G.ResetClip();
            }

            DrawBorders(Pens.Black, 2);
            DrawBorders(Pens.Black);

            //e.Graphics.DrawImage(B, 0, 0);

            //G.Dispose();
            //B.Dispose();
        }

    }

}

