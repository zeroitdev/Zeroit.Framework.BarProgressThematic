// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Jasta.cs" company="Zeroit Dev Technologies">
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
        /// The j back
        /// </summary>
        Color jBack = Color.FromArgb(15, 15, 15);
        /// <summary>
        /// The j border
        /// </summary>
        Color jBorder = Color.Black;

        /// <summary>
        /// The j fill
        /// </summary>
        Color jFill = Color.FromArgb(50, 50, 50);


        /// <summary>
        /// Jastas the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void JastaPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            G.Clear(Parent.BackColor);
            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);
            
            //G.Clear(jBack);
            G.FillRectangle(new SolidBrush(jFill), 0, 0, progressWidth, Height);
            DrawBorders(G,new Pen(jBorder));

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();

        }

    }

}

