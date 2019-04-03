// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Deumos.cs" company="Zeroit Dev Technologies">
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
        /// The deumos c1
        /// </summary>
        Color deumosC1 = Color.FromArgb(18, 18, 18);
        /// <summary>
        /// The deumos c2
        /// </summary>
        Color deumosC2 = Color.FromArgb(30, Color.White);
        /// <summary>
        /// The deumos c3
        /// </summary>
        Color deumosC3 = Color.FromArgb(5, Color.White);
        /// <summary>
        /// The deumos c4
        /// </summary>
        Color deumosC4 = Color.FromArgb(2, 2, 2);
        /// <summary>
        /// The deumos c5
        /// </summary>
        Color deumosC5 = Color.FromArgb(8, 8, 8);
        /// <summary>
        /// The deumos c6
        /// </summary>
        Color deumosC6 = Color.FromArgb(38, 38, 38);
        /// <summary>
        /// The deumos c7
        /// </summary>
        Color deumosC7 = Color.FromArgb(52, 52, 52);
        /// <summary>
        /// The deumos c8
        /// </summary>
        Color deumosC8 = Color.FromArgb(32, Color.White);
        /// <summary>
        /// The deumos c9
        /// </summary>
        Color deumosC9 = Color.FromArgb(12, Color.White);

        /// <summary>
        /// The deumos p1
        /// </summary>
        Color deumosP1 = Color.Black;
        /// <summary>
        /// The deumos p2
        /// </summary>
        Color deumosP2 = Color.Black;
        /// <summary>
        /// The deumos p3
        /// </summary>
        Color deumosP3 = Color.FromArgb(16, Color.White);


        /// <summary>
        /// Deumoses the paint hook.
        /// </summary>
        private void DeumosPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.Clear(deumosC1);
            DrawGradient(deumosC2, deumosC3, 0, 0, Width, Height / 2);

            DrawGradient(deumosC4, deumosC5, 2, 2, Width - 4, Height - 4);
            DrawBorders(new Pen(deumosP1), 2);

            dynamic I1 = Convert.ToInt32((Value - Minimum) / (Maximum - Minimum) * (Width - 6));

            if (!(I1 == 0))
            {
                Rectangle R1 = new Rectangle(3, 3, I1, Height - 6);

                DrawGradient(deumosC6, deumosC7, R1, 35f);
                DrawBorders(new Pen(deumosP3), R1);

                DrawGradient(deumosC8, deumosC9, 3, 3, I1, Height / 2 - 3);
            }

            DrawBorders(new Pen(deumosP2));
            DrawCorners(BackColor);

            //G.Dispose();
            //B.Dispose();
        }


    }

}

