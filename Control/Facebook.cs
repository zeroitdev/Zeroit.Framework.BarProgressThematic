// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Facebook.cs" company="Zeroit Dev Technologies">
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


        #region "Declarations"
        /// <summary>
        /// The progress colour
        /// </summary>
        private Color _ProgressColour = Color.LightBlue;
        /// <summary>
        /// The glow colour
        /// </summary>
        private Color _GlowColour = Color.FromArgb(73, 185, 213);
        /// <summary>
        /// The border colour
        /// </summary>
        private Color _BorderColour = Color.FromArgb(187, 191, 200);
        /// <summary>
        /// The base colour
        /// </summary>
        private Color _BaseColour = Color.FromArgb(237, 237, 237);
        /// <summary>
        /// The font colour
        /// </summary>
        private Color _FontColour = Color.FromArgb(50, 50, 50);
        #endregion

        #region "Properties"



        /// <summary>
        /// Gets or sets the progress colour.
        /// </summary>
        /// <value>The progress colour.</value>
        [Category("Colours")]
        public Color ProgressColour
        {
            get { return _ProgressColour; }
            set { _ProgressColour = value; }
        }

        /// <summary>
        /// Gets or sets the base colour.
        /// </summary>
        /// <value>The base colour.</value>
        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        /// <summary>
        /// Gets or sets the border colour.
        /// </summary>
        /// <value>The border colour.</value>
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        /// <summary>
        /// Gets or sets the glow colour.
        /// </summary>
        /// <value>The glow colour.</value>
        [Category("Colours")]
        public Color GlowColour
        {
            get { return _GlowColour; }
            set { _GlowColour = value; }
        }

        /// <summary>
        /// Gets or sets the font colour.
        /// </summary>
        /// <value>The font colour.</value>
        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        #endregion

        #region "Events"



        #endregion

        #region "Draw Control"
        /// <summary>
        /// Facebooks the progress bar.
        /// </summary>
        private void FacebookProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
        }

        /// <summary>
        /// Facebooks the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void FacebookOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
           
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            G.TextRenderingHint = TextRendering;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //G.Clear(BackColor);
            int ProgVal = Convert.ToInt32(Value / Maximum * (Width - 40));

            if (Value == 0)
            {
                G.FillRectangle(new SolidBrush(_BaseColour), Base);
                G.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                G.DrawRectangle(new Pen(_BorderColour), Base);
                G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }
            else if (Value == Maximum)
            {
                G.FillRectangle(new SolidBrush(_BaseColour), Base);
                G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                G.DrawRectangle(new Pen(_GlowColour), Base);
                G.DrawLine(new Pen(_GlowColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }
            else
            {
                G.FillRectangle(new SolidBrush(_BaseColour), Base);
                G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                G.DrawRectangle(new Pen(_BorderColour), Base);
                G.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }

            #region Old Code
            //      switch (Value) {
            //	case 0:
            //		G.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		G.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		G.DrawRectangle(new Pen(_BorderColour), Base);
            //		G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
            //		break;
            //	case Maximum:
            //		G.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		G.DrawRectangle(new Pen(_GlowColour), Base);
            //		G.DrawLine(new Pen(_GlowColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
            //		break;
            //	default:
            //		G.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		G.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		G.DrawRectangle(new Pen(_BorderColour), Base);
            //		G.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		G.DrawString(string.Format("{0}%", Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
            //		break;
            //} 
            #endregion

            //e.Graphics.InterpolationMode = (InterpolationMode)7;
            //e.Graphics.DrawImage(B, 0, 0);

            //G.Dispose();
            //B.Dispose();

        }

        #endregion


    }

}

