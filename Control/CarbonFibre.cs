// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="CarbonFibre.cs" company="Zeroit Dev Technologies">
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
        /// Carbons the fiber progress bar.
        /// </summary>
        private void CarbonFiberProgressBar()
        {
            Size = new Size(419, 27);
        }


        //private bool _ShowPercentage = true;
        //public bool ShowPercentage
        //{
        //    get { return _ShowPercentage; }
        //    set
        //    {
        //        _ShowPercentage = value;
        //        Invalidate();
        //    }
        //}
        #endregion

        #region Paint

        /// <summary>
        /// Carbons the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void CarbonOnPaint(PaintEventArgs e)
        {

            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;

            //G.Clear(Color.FromArgb(22, 22, 22));
            LinearGradientBrush Glow = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 7), Color.FromArgb(22, 22, 22), Color.FromArgb(27, 27, 27), -270);
            G.FillRectangle(Glow, new Rectangle(3, 3, Width - 7, Height - 7));
            G.DrawRectangle(Pens.Black, new Rectangle(3, 3, Width - 7, Height - 7));



            dynamic W = Convert.ToInt32(Value * (1/Maximum) * Width);

            Rectangle R = new Rectangle(3, 3, W - 6, Height - 6);
            
            LinearGradientBrush Header = new LinearGradientBrush(R, Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270);
            G.FillRectangle(Header, R);
            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, R);

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(_value/Maximum * 100, "%")), Font, new SolidBrush(Color.FromArgb(6, 6, 6)), new Rectangle(1, 2, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString(Convert.ToString(string.Concat(_value / Maximum * 100, "%")), Font, new SolidBrush(Color.FromArgb(255, 150, 0)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            G.FillRectangle(new SolidBrush(Color.FromArgb(3, Color.White)), R.X, R.Y, R.Width, Convert.ToInt32(R.Height * 0.45));
            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(4, 4, Width - 9, Height - 9));
            G.DrawRectangle(new Pen(Color.FromArgb(10, 10, 10)), R.X, R.X, R.Width - 1, R.Height - 1);


            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }
        
        #endregion

    }

}

