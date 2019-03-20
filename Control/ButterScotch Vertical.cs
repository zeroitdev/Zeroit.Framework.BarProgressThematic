// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="ButterScotch Vertical.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    public partial class BarProgressThematic
    {

        /// <summary>
        /// Butters the vert on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void ButterVertOnPaint(PaintEventArgs e)
        {
            //Bitmap b = new Bitmap(Width, Height);
            Graphics g = e.Graphics;
            int percent = Convert.ToInt32((Height - 1) * (Value / Maximum));
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle maininnerrect = new Rectangle(7, 7, Width - 15, Height - 15);
            Rectangle innerrect = new Rectangle(4, (Height - percent) + 4, Width - 9, percent - 9);
            //g.Clear(Parent.BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(new SolidBrush(Color.FromArgb(40, 37, 33)), Draw.RoundRect(outerrect, 5));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(outerrect, 5));
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(maininnerrect, 3));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(maininnerrect, 3));
            if (percent != 0)
            {
                try
                {
                    LinearGradientBrush progressgb = new LinearGradientBrush(innerrect, Color.FromArgb(91, 82, 73), Color.FromArgb(57, 52, 46), 90);
                    g.FillPath(progressgb, Draw.RoundRect(innerrect, 7));
                }
                catch
                {
                }
            }
            if (ShowPercentage)
            {
                g.DrawString(string.Format("{0}%", Value), new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(Color.FromArgb(246, 180, 12)), outerrect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //e.Graphics.DrawImage(b, new Point(0, 0));

            //g.Dispose();
            //b.Dispose();
        }

    }


}

