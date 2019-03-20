// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Atrocity.cs" company="Zeroit Dev Technologies">
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


        #region "Properties"

        #endregion

        /// <summary>
        /// The atrocity gra d1
        /// </summary>
        Color atrocityGRAD1 = Color.FromArgb(24, 23, 26);
        /// <summary>
        /// The atrocity gra d2
        /// </summary>
        Color atrocityGRAD2 = Color.FromArgb(72, 69, 75);
        /// <summary>
        /// The atrocity b g1
        /// </summary>
        Color atrocityBG1 = Color.FromArgb(45, 45, 45);
        /// <summary>
        /// The atrocity p1
        /// </summary>
        Color atrocityP1 = Color.FromArgb(65, 65, 65);
        /// <summary>
        /// The atrocity p2
        /// </summary>
        Color atrocityP2 = Color.FromArgb(70, 70, 70);

        /// <summary>
        /// Atrocities the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void AtrocityPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            //G.Clear(Parent.BackColor);

            //DrawGradient(atrocityGRAD1, atrocityGRAD2, 0, 0, CInt(_Value / _Maximum * Width) - 1, Height - 1, -90S)
            G.FillRectangle(new SolidBrush(atrocityGRAD1), 0, 0, Convert.ToInt32(_value / _Maximum * Width) - 1, Height - 1);

            HatchBrush DarkDown = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            G.FillRectangle(DarkDown, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));




            G.DrawString(Convert.ToString(_value) + "%", new Font("Courier New", 8), new SolidBrush(ForeColor), new Point(Width / 2 - 9, Height / 2 - 7));

            DrawBorders(G, new Pen(atrocityP2), 0);
            DrawBorders(G, new Pen(Color.Black), 1);
            DrawBorders(G, new Pen(atrocityP2), 2);

            DrawCorners(atrocityBG1);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }
}
