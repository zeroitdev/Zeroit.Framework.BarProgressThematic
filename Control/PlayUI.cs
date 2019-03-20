// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="PlayUI.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
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
        /// The value colour
        /// </summary>
        private Color _ValueColour = Color.FromArgb(42, 119, 220);
        /// <summary>
        /// Gets or sets the value colour.
        /// </summary>
        /// <value>The value colour.</value>
        [Category("Colours")]
        public Color ValueColour
        {
            get
            {
                return _ValueColour;
            }
            set
            {
                _ValueColour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Plays the UI on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PlayUIOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            //G.Clear(Parent.BackColor);

            float Percent = (float)this.Value / (float)this._Maximum * 100;

            int Slope = 8;
            Rectangle MyRect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath BorderPath = CreateRound(MyRect, Slope);
            G.FillPath(new SolidBrush(Color.FromArgb(51, 52, 55)), BorderPath);

            ColorBlend ProgressBlend = new ColorBlend()
            {
                Colors = new Color[]
                {
                    _ValueColour,
                    _ValueColour,
                    _ValueColour
                },
                Positions = new float[]
                {
                    0,
                    0.5F,
                    1
                }
            };
            //ProgressBlend.Colors[0] = _ValueColour;
            //ProgressBlend.Colors[1] = _ValueColour;
            //ProgressBlend.Colors[2] = _ValueColour;
            //ProgressBlend.Positions = new Single[] { 0, 0.5F, 1 };

            LinearGradientBrush LGB = new LinearGradientBrush(MyRect, Color.Black, Color.Black, 90.0F);
            LGB.InterpolationColors = ProgressBlend;

            Rectangle ProgressRect = new Rectangle(1, 1, (int)Math.Round(((double)this.Width / (double)this._Maximum * (double)this.Value - 3.0)), this.Height - 3);
            GraphicsPath ProgressPath = CreateRound(ProgressRect, Slope);

            if (Percent >= 1)
            {
                G.FillPath(LGB, ProgressPath);
            }

            try
            {
                G.DrawPath(new Pen(Color.FromArgb(51, 52, 55)), BorderPath);
            }
            catch (Exception)
            {
            }

            //e.Graphics.DrawImage(B, 0, 0);

            //G.Dispose();
            //B.Dispose();
        }

    }
}
