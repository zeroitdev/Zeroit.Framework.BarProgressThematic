// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="BAW.cs" company="Zeroit Dev Technologies">
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


        #region " Declarations "
        /// <summary>
        /// The o path
        /// </summary>
        private GraphicsPath OPath;
        /// <summary>
        /// The i path
        /// </summary>
        private GraphicsPath IPath = new GraphicsPath();
        /// <summary>
        /// The indicator
        /// </summary>
        private GraphicsPath Indicator = new GraphicsPath();
        //private int FillValue;
        /// <summary>
        /// The ogb
        /// </summary>
        private LinearGradientBrush OGB;
        /// <summary>
        /// The igb
        /// </summary>
        private LinearGradientBrush IGB;
        /// <summary>
        /// The iogb
        /// </summary>
        private LinearGradientBrush IOGB;
        /// <summary>
        /// The indicator gb
        /// </summary>
        private LinearGradientBrush IndicatorGB;
        /// <summary>
        /// The ba w p1
        /// </summary>
        private Pen baWP1;
        /// <summary>
        /// The ba w p2
        /// </summary>
        private Pen baWP2;
        /// <summary>
        /// The ba w p3
        /// </summary>
        private Pen baWP3 = new Pen(Color.FromArgb(190, 190, 190));
        /// <summary>
        /// The ba w b1
        /// </summary>
        private SolidBrush baWB1 = new SolidBrush(Color.FromArgb(84, 83, 81));

        /// <summary>
        /// The tb
        /// </summary>
        private TextureBrush TB = new TextureBrush(Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAACUElEQVQYGa3BwY1dVRBF0X2q6mExtWDgAQEQIDmRDzn0wBISYtL9771Vx/81CBNAr6Xffv9jbEAC8WRukrh5jBBgbiED5mYbSZjAFrf6/PlnelrDPyRhm5swIQMmUoREBk/GNjdJgBiER9QvX35in8E2Bsx30lDRRIiqoFJkBhFgG9uAwMEguqG+/vkX3WZsbgYskEQGXAlVyVVBVZApxCDANm2YgbPNOkN9/fuBARMYc5NERHBl8qmSa4pyED1IwzsZD3QPezVrN2dD8MFqzYVsJJ4aMaChqvgUw4/xRqoIJ27hEIOw4fSwz7B2s07TberNCTPIjQJSSWXRmXQFO0wTyMkgGDEjdg/7HHbD2uYcmDF1zmA30ASgK1AlUQWZWMHhyWIQbnHarDZ7iXXE2qJHYFGeg+YA5gpxKbhkYoaQcAxjwMKIGbHW4W1t9m5OmxnAxojgg1WvB4GpK0iJSpGCwPQsZgYIPGIs9mleXw9vj81pA8IGI5CoZbgqqUx0JY6iBWNjGww2jM3eh7Wa18dm78YWtgAB5laugAy4iongYGyBjQfaQfewT/NYzVrN3mYc2DwFQtwkU0FTAakBNzR0G9kMwZ7g7Obx2KxHs1bTBpRgnpqbAiJE8MHqh7hIBTHAiOHJ4BmOmz2wVvN4O+zddPMkYLB5FyEyxBWi3laxG0oCjLiJGTg9PPZh78M+5rTBAoTNO8nIphS0Tb28vBASGAKDzM0ztGEkZoYZY/Mv8Z25RYgMqF+/FE8WAyOk4D8ShLANBO8k/s9usAEDwzcn97xOZ2JTrwAAAABJRU5ErkJggg=="))), WrapMode.Tile);

        #endregion

        #region " Properties "



        #endregion

        /// <summary>
        /// Bas the wgui progress bar.
        /// </summary>
        private void BaWGUIProgressBar()
        {
            DoubleBuffered = true;
            
            

            
            
        }

        /// <summary>
        /// Baws the on resize.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BAWOnResize(EventArgs e)
        {
            
            Height = 80;

            Invalidate();
            
        }

        /// <summary>
        /// Baws the on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void BAWOnPaint(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            G.Clear(Parent.BackColor);
            dynamic progressWidth = Convert.ToInt32(Value * (1 / Maximum) * Width - 50);

            
            OGB = new LinearGradientBrush(new Rectangle(Width - 44, Height - 31, 31, 31), Color.FromArgb(173, 173, 173), Color.FromArgb(195, 195, 195), 90);
            IGB = new LinearGradientBrush(new Rectangle(Width - 43, Height - 30, 30, 30), Color.FromArgb(201, 201, 201), Color.FromArgb(225, 225, 225), 90);
            IOGB = new LinearGradientBrush(new Rectangle(19, Height - 26, Width - 6, Height - 26), Color.FromArgb(125, 175, 225), Color.FromArgb(55, 130, 205), -90);
            IndicatorGB = new LinearGradientBrush(new Rectangle(progressWidth - 11, 0, progressWidth + 19, 45), Color.FromArgb(232, 232, 232), Color.FromArgb(202, 202, 202), 90);

            baWP1 = new Pen(OGB);
            baWP2 = new Pen(IOGB);

            TB.TranslateTransform(0, -5, MatrixOrder.Prepend);

            if (progressWidth >= 13)
            {
                IPath.AddArc(19, Height - 26, 20, 20, 180, 90);
                IPath.AddArc(progressWidth, Height - 26, 20, 20, -90, 90);
                IPath.AddArc(progressWidth, Height - 26, 20, 20, 0, 90);
                IPath.AddArc(19, Height - 26, 20, 20, 90, 90);
            }
            Indicator.AddArc(progressWidth - 11, 0, 8, 8, 180, 90);
            Indicator.AddArc(progressWidth + 40, 0, 8, 8, -90, 90);
            Indicator.AddArc(progressWidth + 40, 27, 8, 8, 0, 90);
            Indicator.AddLine(progressWidth + 24, 35, progressWidth + 19, 45);
            Indicator.AddLine(progressWidth + 14, 35, progressWidth - 3, 35);
            Indicator.AddArc(progressWidth - 11, 27, 8, 8, 90, 90);
            Indicator.CloseFigure();

            OPath = new GraphicsPath();

            OPath.AddArc(14, Height - 31, 20, 20, 180, 90);
            OPath.AddArc(Width - 44, Height - 31, 20, 20, -90, 90);
            OPath.AddArc(Width - 44, Height - 21, 20, 20, 0, 90);
            OPath.AddArc(14, Height - 21, 20, 20, 90, 90);
            OPath.CloseAllFigures();

            //ChangePaths();
            G.FillPath(IGB, OPath);
            G.DrawPath(baWP1, OPath);

            if (progressWidth > 0)
            {
                G.FillPath(IGB, OPath);
                G.DrawPath(baWP1, OPath);
                G.FillPath(TB, IPath);
                G.DrawPath(baWP2, IPath);

                G.FillPath(IndicatorGB, Indicator);
                G.DrawPath(baWP3, Indicator);
            }

    //        switch (_Value)
    //        {
    //            case 0:
    //                G.FillPath(IGB, OPath);
    //                G.DrawPath(baWP1, OPath);
    //                break;
    //            default:
    //                G.FillPath(IGB, OPath);
    //                G.DrawPath(baWP1, OPath);
    //                G.FillPath(TB, IPath);
    //                G.DrawPath(baWP2, IPath);

    //                G.FillPath(IndicatorGB, Indicator);
    //                G.DrawPath(baWP3, Indicator);

    ////                switch (_Value)
    ////                {
    ////                    case  // ERROR: Case labels with binary operators are unsupported : LessThan
    ////10:
    ////                        _with2.DrawString(_Value + "%", Font, baWB1, FillValue + 6, 7);
    ////                        break;
    ////                    case  // ERROR: Case labels with binary operators are unsupported : LessThan
    ////100:
    ////                        _with2.DrawString(_Value + "%", Font, baWB1, FillValue - 5, 7);
    ////                        break;
    ////                    default:
    ////                        _with2.DrawString(_Value + "%", Font, baWB1, FillValue - 11, 7);
    ////                        break;
    ////                }
    //                break;
    //        }

            //e.Graphics.DrawImage(B, 0, 0);

        }

        /// <summary>
        /// Changes the paths.
        /// </summary>
        private void ChangePaths()
        {
            if (Width > 0 && Height > 0)
            {
                
                
            }
        }   

    }

}
