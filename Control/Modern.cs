// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Modern.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using Zeroit.Framework.BarProgressThematic.ThemeManagers;

namespace Zeroit.Framework.BarProgressThematic.Controls
{

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    public partial class BarProgressThematic
    {

        /// <summary>
        /// The modern c1
        /// </summary>
        Color modernC1 = Color.FromArgb(31, 31, 31);
        /// <summary>
        /// The modern c2
        /// </summary>
        Color modernC2 = Color.FromArgb(41, 41, 41);
        /// <summary>
        /// The modern c3
        /// </summary>
        Color modernC3 = Color.FromArgb(51, 51, 51);
        /// <summary>
        /// The modern c4
        /// </summary>
        Color modernC4 = Color.FromArgb(0, 0, 0, 0);
        /// <summary>
        /// The modern c5
        /// </summary>
        Color modernC5 = Color.FromArgb(25, 255, 255, 255);


        /// <summary>
        /// Moderns the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ModernOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            int V = Convert.ToInt32(Width * Value / _Maximum);
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            Draw.Gradient(G, modernC2, modernC3, 1, 1, Width - 2, Height - 2);
            G.DrawRectangle(new Pen(modernC2), 1, 1, V - 3, Height - 3);
            Draw.Gradient(G, modernC3, modernC2, 2, 2, V - 4, Height - 4);

            G.DrawRectangle(new Pen(modernC1), 0, 0, Width - 1, Height - 1);

            //e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

   

}

