// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Login Button with progress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
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


        #region "Declarations"
        /// <summary>
        /// The font
        /// </summary>
        private Font _Font = new Font("Segoe UI", 9);
        /// <summary>
        /// The login progress colour
        /// </summary>
        private Color loginProgressColour = Color.FromArgb(0, 191, 255);
        /// <summary>
        /// The login border colour
        /// </summary>
        private Color loginBorderColour = Color.FromArgb(25, 25, 25);
        /// <summary>
        /// The login font colour
        /// </summary>
        private Color loginFontColour = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// The main colour
        /// </summary>
        private Color _MainColour = Color.FromArgb(42, 42, 42);
        /// <summary>
        /// The hover colour
        /// </summary>
        private Color _HoverColour = Color.FromArgb(52, 52, 52);
        /// <summary>
        /// The pressed colour
        /// </summary>
        private Color _PressedColour = Color.FromArgb(47, 47, 47);
        #endregion

        #region "Mouse States"



        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or sets the color of the login progress.
        /// </summary>
        /// <value>The color of the login progress.</value>
        [Category("Colours")]
        public Color LoginProgressColor
        {
            get { return loginProgressColour; }
            set { loginProgressColour = value; }
        }

        /// <summary>
        /// Gets or sets the color of the login border.
        /// </summary>
        /// <value>The color of the login border.</value>
        [Category("Colours")]
        public Color LoginBorderColor
        {
            get { return loginBorderColour; }
            set { loginBorderColour = value; }
        }

        /// <summary>
        /// Gets or sets the color of the login base.
        /// </summary>
        /// <value>The color of the login base.</value>
        [Category("Colours")]
        public Color LoginBaseColor
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        /// <summary>
        /// Gets or sets the color of the login hover.
        /// </summary>
        /// <value>The color of the login hover.</value>
        [Category("Colours")]
        public Color LoginHoverColor
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }

        /// <summary>
        /// Gets or sets the color of the login pressed.
        /// </summary>
        /// <value>The color of the login pressed.</value>
        [Category("Colours")]
        public Color LoginPressedColor
        {
            get { return _PressedColour; }
            set { _PressedColour = value; }
        }



        #endregion

        #region "Draw Control"
        /// <summary>
        /// Logs the in button with progress.
        /// </summary>
        private void LogInButtonWithProgress()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(75, 30);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Logins the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void LoginOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;
            //G.Clear(Parent.BackColor);

            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width);


            switch (State)
            {
                case MouseState.None:
                    G.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 0, Width, Height - 4));
                    G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height - 4));
                    G.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(0, 0, Width, Height - 4));
                    G.DrawRectangle(new Pen(loginBorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 5));
                    G.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(_PressedColour), new Rectangle(0, 0, Width, Height - 4));
                    G.DrawRectangle(new Pen(loginBorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 5));
                    G.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            if (Value == 0)
            {
                G.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 0, Width, Height - 4));
                G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height - 4));
                
                //return;
            }
            else if (Value == Maximum)
            {
                G.FillRectangle(new SolidBrush(loginProgressColour), new Rectangle(0, Height - 4, Width, Height - 4));
                G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height));

            }
            else
            {


                
                G.FillRectangle(new SolidBrush(loginProgressColour), new Rectangle(0, Height - 4, progressWidth, Height - 4));
                G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height));

            }

            #region Old Code
            //      switch (Value) {
            //	case 0:
            //		break;
            //	case Maximum:
            //		G.FillRectangle(new SolidBrush(loginProgressColour), new Rectangle(0, Height - 4, Width, Height - 4));
            //		G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height));
            //		break;
            //	default:
            //		G.FillRectangle(new SolidBrush(loginProgressColour), new Rectangle(0, Height - 4, Convert.ToInt32(Width / Maximum * Value), Height - 4));
            //		G.DrawRectangle(new Pen(loginBorderColour, 2), new Rectangle(0, 0, Width, Height));
            //		break;
            //} 
            #endregion

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();

        }

        #endregion


    }

}

