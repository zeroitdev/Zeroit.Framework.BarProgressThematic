// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="NS.cs" company="Zeroit Dev Technologies">
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

    public partial class BarProgressThematic
    {

        private void NSProgressBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            
        }

        
        private Color nsP1 = Color.FromArgb(24, 24, 24);
        private Color nsP2 = Color.FromArgb(55, 55, 55);
        private Color nsB1 = Color.FromArgb(51, 181, 229);
        

        
        private void NSOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            //G.Clear(Parent.BackColor);
            
            GraphicsPath GP1 = Draw.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GraphicsPath GP2 = Draw.CreateRound(1, 1, Width - 3, Height - 3, 7);

            Rectangle R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            LinearGradientBrush GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90f);

            G.SetClip(GP1);
            G.FillRectangle(GB1, R1);
            
            //dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);
            
            dynamic progressValue = Convert.ToInt32((Value - Minimum) / (Maximum - Minimum) * (Width - 3));

            if (progressValue > 1)
            {
                GraphicsPath GP3 = Draw.CreateRound(1, 1, progressValue, Height - 3, 7);

                Rectangle R2 = new Rectangle(1, 1, progressValue, Height - 3);
                LinearGradientBrush GB2 = new LinearGradientBrush(R2, Color.FromArgb(51, 181, 229), Color.FromArgb(0, 153, 204), 90f);

                G.FillPath(GB2, GP3);
                G.DrawPath(new Pen(nsP1), GP3);

                G.SetClip(GP3);
                G.SmoothingMode = SmoothingMode.None;

                G.FillRectangle(new SolidBrush(nsB1), R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.ResetClip();
            }

            G.DrawPath(new Pen(nsP2), GP1);
            G.DrawPath(new Pen(nsP1), GP2);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }


    }

}

