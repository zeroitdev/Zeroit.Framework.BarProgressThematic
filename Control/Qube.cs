// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Qube.cs" company="Zeroit Dev Technologies">
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

        #region Properties

        /// <summary>
        /// The PGS
        /// </summary>
        ProgressBar Pgs = new ProgressBar();
        /// <summary>
        /// Qubes the progress bar.
        /// </summary>
        private void QubeProgressBar()
        {
            Size = new Size(132, 14);
        }

        #endregion

        #region Paint 

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        /// <summary>
        /// Qubes the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void QubeOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            //G.Clear(Color.FromArgb(68, 76, 99));
            LinearGradientBrush Glow = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 7), Color.FromArgb(54, 62, 83), Color.FromArgb(54, 62, 83), -270);
            G.FillRectangle(Glow, new Rectangle(3, 3, Width - 7, Height - 7));
            //54,62,83
            G.DrawRectangle(new Pen(Color.FromArgb(54, 62, 83)), new Rectangle(3, 3, Width - 7, Height - 7));
            dynamic W = Convert.ToInt32(Value * (1 / Maximum) * Width);

            Rectangle R = new Rectangle(3, 3, W - 7, Height - 6);

            LinearGradientBrush Header = new LinearGradientBrush(R, Color.FromArgb(0, 182, 248), Color.FromArgb(0, 182, 248), 270);
            G.FillRectangle(Header, R);

            G.FillRectangle(new SolidBrush(Color.FromArgb(3, Color.White)), R.X, R.Y, R.Width, Convert.ToInt32(R.Height * 0.25));

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();

        }


        #endregion

    }

}

