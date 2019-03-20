// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Imagine.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
        /// The bg
        /// </summary>
        Color BG = Color.FromArgb(13, 13, 13);
        /// <summary>
        /// The prog
        /// </summary>
        Color Prog = Color.FromArgb(12, 27, 74);

        /// <summary>
        /// Imagines the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void ImaginePaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            
            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);
            
            G.Clear(Parent.BackColor);
            HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(15, Color.LightBlue), Color.Transparent);
            G.FillRectangle(new SolidBrush(Prog), 0, 0, progressWidth, Height);
            G.FillRectangle(HB, new Rectangle(0, 0, progressWidth, Height));

            DrawGradients(G,Color.FromArgb(40, Color.White), Color.FromArgb(10, Color.White), ClientRectangle);
            DrawBorders(G,Pens.Black, ClientRectangle);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();

            

        }

    }

}

