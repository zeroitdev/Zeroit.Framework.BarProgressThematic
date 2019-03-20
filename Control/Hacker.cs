﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Hacker.cs" company="Zeroit Dev Technologies">
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
        /// Hackers the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void HackerPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            //G.Clear(Parent.BackColor);
            //Border
            Rectangle left = new Rectangle(0, 0, 60, Height - 1);
            LinearGradientBrush leftLGB = new LinearGradientBrush(left, Color.FromArgb(255, 32, 32, 32), Color.FromArgb(100, Color.White), 180f);
            G.FillRectangle(leftLGB, left);
            Rectangle right = new Rectangle(Width - 61, 0, 60, Height - 1);
            LinearGradientBrush rightLGB = new LinearGradientBrush(right, Color.FromArgb(100, Color.White), Color.FromArgb(255, 32, 32, 32), 180f);
            G.FillRectangle(rightLGB, right);
            Rectangle middle = new Rectangle(60, 0, Width - 120, Height - 1);
            SolidBrush middleSB = new SolidBrush(Color.FromArgb(255, 32, 32, 32));
            G.FillRectangle(middleSB, middle);
            //Background
            Rectangle rect = new Rectangle(2, 2, Width - 4, Height - 4);
            HatchBrush backHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(255, 10, 10, 10), Color.FromArgb(255, 11, 11, 11));
            G.FillRectangle(backHB, rect);
            //Bar
            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.Lime;
            cblend.Colors[1] = Color.FromArgb(255, 8, 90, 8);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            
            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);

            DrawGradients(G,cblend, new Rectangle(2, 2, progressWidth - 4, Height - 4));

            //Border
            DrawBorders(G,Pens.Black, 0);
            DrawBorders(G,Pens.Black, 2);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

}

