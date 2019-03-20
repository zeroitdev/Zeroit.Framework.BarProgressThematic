// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Influence.cs" company="Zeroit Dev Technologies">
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


        #region " Control Help - Properties & Flicker Control "
        /// <summary>
        /// The influence ofs
        /// </summary>
        private int influenceOFS = 0;
        /// <summary>
        /// The influence speed
        /// </summary>
        private int influenceSpeed = 50;


        /// <summary>
        /// Influences the create handle.
        /// </summary>
        private void InfluenceCreateHandle()
        {
            // Dim tmr As New Timer With {.Interval = influenceSpeed}
            // AddHandler tmr.Tick, AddressOf InfluenceAnimate
            // tmr.Start()
            System.Threading.Thread T = new System.Threading.Thread(InfluenceAnimate);
            T.IsBackground = true;
            //T.Start()
        }
        /// <summary>
        /// Influences the animate.
        /// </summary>
        public void InfluenceAnimate()
        {
            while (true)
            {
                if (influenceOFS <= Width)
                {
                    influenceOFS += 1;
                }
                else
                {
                    influenceOFS = 0;
                }
                Invalidate();
                System.Threading.Thread.Sleep(influenceSpeed);
            }
        }
        #endregion

        /// <summary>
        /// Influences the progress bar.
        /// </summary>
        private void InfluenceProgressBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Influences the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void InfluenceOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            
            int intValue = Convert.ToInt32(Value * (1 / Maximum) * Width);
            
            //G.Clear(Parent.BackColor);

            LinearGradientBrush gB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(16, 16, 16), Color.FromArgb(22, 22, 22), 90);
            G.FillPath(gB, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 0, intValue - 1, Height - 2), Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
            G.FillPath(g1, Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 2));
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            G.FillPath(h1, Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 2), 2));
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillPath(s1, Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height / 2 - 1), 2));

            G.DrawPath(new Pen(Color.FromArgb(125, 97, 94, 90)), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(new Rectangle(0, 0, intValue - 1, Height - 1), 2));

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Value, "%")), Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            //e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

    }

}

