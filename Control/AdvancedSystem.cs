// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="AdvancedSystem.cs" company="Zeroit Dev Technologies">
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
        #region Private Fields

        /// <summary>
        /// The center color
        /// </summary>
        private Color centerColor = Color.FromArgb(255, 230, 245, 255);

        /// <summary>
        /// The surround color
        /// </summary>
        private Color surroundColor = Color.Transparent;

        /// <summary>
        /// The idle background
        /// </summary>
        private Color[] idleBackground = new Color[]
        {
            Color.FromArgb(32, 32, 32), 
            Color.FromArgb(45, 45, 45)
        };

        /// <summary>
        /// The in progress color
        /// </summary>
        private Color[] inProgressColor = new Color[]
        {
            Color.FromArgb(5, 80, 140),
            Color.FromArgb(45, 180, 200)
        };

        /// <summary>
        /// The vertical bar color
        /// </summary>
        private Color[] verticalBarColor = new Color[]
        {
            Color.Black, 
            Color.Black,
        };

        /// <summary>
        /// The color blends
        /// </summary>
        private Color[] colorBlends = new Color[]
        {
            Color.Transparent,
            Color.Transparent,
            Color.FromArgb(0, 150, 220),
            Color.Transparent,
            Color.Transparent
        };

        /// <summary>
        /// The blend positions
        /// </summary>
        private float[] blendPositions = new float[]
        {
            0.0f,
            0.4f,
            0.5f,
            0.6f,
            1.0f
        };

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the center.
        /// </summary>
        /// <value>The color of the center.</value>
        public Color CenterColor
        {
            get { return centerColor; }
            set
            {
                centerColor = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the surround.
        /// </summary>
        /// <value>The color of the surround.</value>
        public Color SurroundColor
        {
            get { return surroundColor; }
            set
            {
                surroundColor = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the idle background.
        /// </summary>
        /// <value>The idle background.</value>
        public Color[] IdleBackground
        {
            get { return idleBackground; }
            set
            {
                idleBackground = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the in progress.
        /// </summary>
        /// <value>The color of the in progress.</value>
        public Color[] InProgressColor
        {
            get { return inProgressColor; }
            set
            {
                inProgressColor = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the vertical bar.
        /// </summary>
        /// <value>The color of the vertical bar.</value>
        public Color[] VerticalBarColor
        {
            get { return verticalBarColor; }
            set
            {
                verticalBarColor = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color blends.
        /// </summary>
        /// <value>The color blends.</value>
        public Color[] ColorBlends
        {
            get { return colorBlends; }
            set
            {
                colorBlends = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the blend positions.
        /// </summary>
        /// <value>The blend positions.</value>
        public float[] BlendPositions
        {
            get { return blendPositions; }
            set
            {
                blendPositions = value; 
                Invalidate();
            }
        }


        #endregion

        #region Paint

        /// <summary>
        /// Ases the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void ASOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            //G.SmoothingMode = Smoothing;

            
            //G.Clear(Parent.BackColor);

            int slope = 3;

            
            float _percent = (_value / _Maximum) * 100;

            int midY = ((Height - 1) / 2);
            Rectangle mainRect = new Rectangle(12, midY - 4, Width - 25, 7);
            GraphicsPath mainPath = Draw.RoundRect(mainRect, slope);
            LinearGradientBrush barBrush = new LinearGradientBrush(mainRect,IdleBackground[0], IdleBackground[1] , 90f);
            G.FillPath(barBrush, mainPath);

            Rectangle barRect = new Rectangle(12, midY - 4, 
                Convert.ToInt32(((Width / _Maximum) * _value) - ((_percent - 1) / 4)), 7);
            if (barRect.Width > 0)
            {
                LinearGradientBrush barHorizontal = new LinearGradientBrush(barRect,
                    InProgressColor[0],InProgressColor[1] , 0f);
                G.FillPath(barHorizontal, Draw.RoundRect(barRect, slope));

                ColorBlend vertCB = new ColorBlend()
                {
                    Colors = new Color[]
                    {
                        ColorBlends[0],
                        ColorBlends[1],
                        ColorBlends[2],
                        ColorBlends[3],
                        ColorBlends[4]
                    },
                    Positions = new float[]
                    {
                        BlendPositions[0],
                        BlendPositions[1],
                        BlendPositions[2],
                        BlendPositions[3],
                        BlendPositions[4]
                    }
                };
                
                LinearGradientBrush barVertical = new LinearGradientBrush(barRect,
                    VerticalBarColor[0],VerticalBarColor[1],  90f);
                barVertical.InterpolationColors = vertCB;
                G.FillPath(barVertical, Draw.RoundRect(barRect, slope));
            }

            if (_value > 0)
            {
                Rectangle bubbleRect = new Rectangle(barRect.Width - 3, 0, midY * 2 - 3, midY * 2);
                GraphicsPath bubblePath = Draw.RoundRect(bubbleRect, midY);
                PathGradientBrush bubbleBrush = new PathGradientBrush(bubblePath);
                bubbleBrush.CenterColor = CenterColor; //230, 245, 255
                bubbleBrush.SurroundColors = new Color[] { SurroundColor };
                G.FillPath(bubbleBrush, bubblePath);
            }

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();
        }
        

        #endregion
    }
}
