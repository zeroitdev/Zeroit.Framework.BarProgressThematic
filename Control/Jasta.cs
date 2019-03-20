// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Jasta.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

