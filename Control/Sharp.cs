// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Sharp.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        /// The glow animation
        /// </summary>
        private System.Windows.Forms.Timer GlowAnimation = new System.Windows.Forms.Timer();
        //Private _GlowColor As Color = Color.FromArgb(55, 65, 75)
        /// <summary>
        /// The glow color
        /// </summary>
        private Color _GlowColor = Color.FromArgb(50, 255, 255, 255);
        /// <summary>
        /// The m glow position
        /// </summary>
        private int _mGlowPosition = -100;
        /// <summary>
        /// The animate
        /// </summary>
        private bool _Animate = true;
        /// <summary>
        /// The value
        /// </summary>
        private Int32 _Value = 0;
        /// <summary>
        /// The highlight color
        /// </summary>
        private Color _HighlightColor = Color.Silver;
        /// <summary>
        /// The background color
        /// </summary>
        private Color _BackgroundColor = Color.FromArgb(150, 150, 150);
        #region "Properties"
        /// <summary>
        /// The start color
        /// </summary>
        private Color _StartColor = Color.FromArgb(110, 110, 110);
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get { return _StartColor; }
            set
            {
                _StartColor = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BarProgressThematic"/> is animate.
        /// </summary>
        /// <value><c>true</c> if animate; otherwise, <c>false</c>.</value>
        public bool Animate
        {
            get { return _Animate; }
            set
            {
                _Animate = value;
                if (value == true)
                {
                    GlowAnimation.Start();
                }
                else
                {
                    GlowAnimation.Stop();
                }
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the color of the glow.
        /// </summary>
        /// <value>The color of the glow.</value>
        public Color GlowColor
        {
            get { return _GlowColor; }
            set
            {
                _GlowColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the color of the highlight.
        /// </summary>
        /// <value>The color of the highlight.</value>
        public Color HighlightColor
        {
            get { return _HighlightColor; }
            set
            {
                _HighlightColor = value;
                this.Invalidate();
            }
        }

        #endregion
        /// <summary>
        /// Ins the design mode.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        //-------------------------------------------------------------Draw Glow In Paint Method--------------------------------------------------------------------//
        //Rectangle GlowRect = new Rectangle(_mGlowPosition, 6, 60, 60);
        //LinearGradientBrush GlowLGBS = new LinearGradientBrush(GlowRect, Color.FromArgb(127, 137, 147), Color.FromArgb(75, 85, 95), LinearGradientMode.Horizontal);
        //ColorBlend BColor3 = new ColorBlend()
        //{
        //    Colors = new Color[]
        //    {
        //        Color.Transparent,
        //        this.GlowColor,
        //        this.GlowColor,
        //        Color.Transparent
        //    },
        //    Positions = new float[]
        //    {
        //        0f,
        //        0.5f,
        //        0.6f,
        //        1f
        //    }
        //};
        //GlowLGBS.InterpolationColors = BColor3;
        //Rectangle clip = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
        //clip.Width = Convert.ToInt32((Value* 1f / (Maximum) * this.Width));
        //G.SetClip(clip);
        //G.FillRectangle(GlowLGBS, GlowRect);
        //G.ResetClip();
        //-------------------------------------------------------------Draw Glow In Paint Method--------------------------------------------------------------------//

        /// <summary>
        /// Sharps the progre ss bar.
        /// </summary>
        private void SharpProgreSsBar()
        {
            
            if (!DesignMode)
            {
                GlowAnimation.Interval = 15;
                if (Value < 100)
                    GlowAnimation.Start();

                GlowAnimation.Tick += GlowAnimation_Tick;
            }
        }

        /// <summary>
        /// Handles the Tick event of the GlowAnimation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GlowAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Animate)
            {
                _mGlowPosition += 4;
                if (_mGlowPosition > this.Width)
                {
                    _mGlowPosition = -10;
                    this.Invalidate();
                }


            }
            else
            {
                GlowAnimation.Stop();

                _mGlowPosition = -50;
            }
        }

        /// <summary>
        /// Sharps the on paint.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void SharpOnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            //G.Clear(Color.FromArgb(43, 53, 63));
            //   -------------------Draw Background for the MBProgressBar--------------------

            LinearGradientBrush s2 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 50), Color.FromArgb(35, 45, 55), Color.FromArgb(50, Color.White), 90);

            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 50), Color.FromArgb(75, Color.White), Color.FromArgb(35, 45, 55), 90);

            Rectangle BackRectangle = this.ClientRectangle;
            BackRectangle.Width = BackRectangle.Width - 1;
            BackRectangle.Height = BackRectangle.Height - 1;
            GraphicsPath GrafP = Draw.RoundRect(BackRectangle, 2, 2, 2, 2);
            G.FillPath(s1, GrafP);


            //--------------------Draw Background Shadows for MBProgrssBar------------------
            Rectangle BGSH = new Rectangle(2, 2, 10, this.Height - 5);
            LinearGradientBrush LGBS = new LinearGradientBrush(BGSH, Color.FromArgb(70, 80, 90), Color.FromArgb(95, 105, 115), LinearGradientMode.Horizontal);
            G.FillRectangle(LGBS, BGSH);
            Rectangle BGSRectangle = new Rectangle(this.Width - 12, 2, 10, this.Height - 5);
            LinearGradientBrush LG = new LinearGradientBrush(BGSRectangle, Color.FromArgb(80, 90, 100), Color.FromArgb(75, 85, 95), LinearGradientMode.Horizontal);
            G.FillRectangle(LG, BGSRectangle);


            //----------------------Draw MBProgressBar--------------------	
            Rectangle ProgressRect = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            ProgressRect.Width = Convert.ToInt32((Value * 1f / (100) * this.Width));
            G.FillRectangle(s2, ProgressRect);


            //----------------------Draw Shadows for MBProgressBar------------------
            Rectangle SHRect = new Rectangle(1, 2, 15, this.Height - 3);
            LinearGradientBrush LGSHP = new LinearGradientBrush(SHRect, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend BColor = new ColorBlend()
            {
                Colors = new Color[]
                {
                    Color.Gray,
                    Color.FromArgb(40,0,0,0),
                    Color.Transparent
                },
                Positions = new float[]
                {
                    0f,
                    0.2f,
                    1f
                }
            };
        //    BColor.Colors = new Color[] {
        //    Color.Gray,
        //    Color.FromArgb(40, 0, 0, 0),
        //    Color.Transparent
        //};
        //    BColor.Positions = new float[] {
        //    0f,
        //    0.2f,
        //    1f
        //};
            LGSHP.InterpolationColors = BColor;

            SHRect.X = SHRect.X - 1;
            G.FillRectangle(LGSHP, SHRect);

            Rectangle Rect1 = new Rectangle(this.Width - 3, 2, 15, this.Height - 3);
            Rect1.X = Convert.ToInt32((Value * 1f / (100) * this.Width) - 14);
            LinearGradientBrush LGSH1 = new LinearGradientBrush(Rect1, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend BColor1 = new ColorBlend()
            {
                Colors = new Color[]
                {
                    Color.Transparent,
                    Color.FromArgb(70, 0, 0, 0),
                    Color.Transparent
                },
                Positions = new float[]
                {
                    0f,
                    0.8f,
                    1f
                }
            };

        //    BColor1.Colors = new Color[] {
        //    Color.Transparent,
        //    Color.FromArgb(70, 0, 0, 0),
        //    Color.Transparent
        //};
        //    BColor1.Positions = new float[] {
        //    0f,
        //    0.8f,
        //    1f
        //};
            LGSH1.InterpolationColors = BColor1;

            G.FillRectangle(LGSH1, Rect1);


            //-------------------------Draw Highlight for MBProgressBar-----------------
            Rectangle HLRect = new Rectangle(1, 1, this.Width - 1, 6);
            GraphicsPath HLGPa = Draw.RoundRect(HLRect, 2, 2, 0, 0);
            //G.SetClip(HLGPa)
            LinearGradientBrush HLGBS = new LinearGradientBrush(HLRect, Color.FromArgb(190, 190, 190), Color.FromArgb(150, 150, 150), LinearGradientMode.Vertical);
            G.FillPath(HLGBS, HLGPa);
            G.ResetClip();
            Rectangle HLrect2 = new Rectangle(1, this.Height - 8, this.Width - 1, 6);
            GraphicsPath bp1 = Draw.RoundRect(HLrect2, 0, 0, 2, 2);
            // G.SetClip(bp1)
            LinearGradientBrush bg1 = new LinearGradientBrush(HLrect2, Color.Transparent, Color.FromArgb(150, this.HighlightColor), LinearGradientMode.Vertical);
            G.FillPath(bg1, bp1);
            G.ResetClip();


            //--------------------Draw Inner Sroke for MBProgressBar--------------
            Rectangle Rect20 = this.ClientRectangle;
            Rect20.X = Rect20.X + 1;
            Rect20.Y = Rect20.Y + 1;
            Rect20.Width -= 3;
            Rect20.Height -= 3;
            GraphicsPath Rect15 = Draw.RoundRect(Rect20, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(55, 65, 75)), Rect15);

            //-----------------------Draw Outer Stroke on the Control----------------------------
            Rectangle StrokeRect = this.ClientRectangle;
            StrokeRect.Width = StrokeRect.Width - 1;
            StrokeRect.Height = StrokeRect.Height - 1;
            GraphicsPath GGH = Draw.RoundRect(StrokeRect, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(122, 122, 122)), GGH);

            //------------------------Draw Glow for MBProgressBar-----------------------
            Rectangle GlowRect = new Rectangle(_mGlowPosition, 6, 60, 60);
            LinearGradientBrush GlowLGBS = new LinearGradientBrush(GlowRect, Color.FromArgb(127, 137, 147), Color.FromArgb(75, 85, 95), LinearGradientMode.Horizontal);
            ColorBlend BColor3 = new ColorBlend()
            {
                Colors = new Color[]
                {
                    Color.Transparent,
                    this.GlowColor,
                    this.GlowColor,
                    Color.Transparent
                },
                Positions = new float[]
                {
                    0f,
                    0.5f,
                    0.6f,
                    1f
                }
            };
        
            GlowLGBS.InterpolationColors = BColor3;
            Rectangle clip = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            clip.Width = Convert.ToInt32((Value * 1f / (Maximum) * this.Width));
            G.SetClip(clip);
            G.FillRectangle(GlowLGBS, GlowRect);
            G.ResetClip();

            //e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            //G.Dispose();
            //B.Dispose();
        }

        
        

    }

}

