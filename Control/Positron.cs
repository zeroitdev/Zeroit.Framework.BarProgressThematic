// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="Positron.cs" company="Zeroit Dev Technologies">
//    This program is for creating a progress bar control.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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

        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation _Orientation;
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The positron bt
        /// </summary>
        private Color positronBT = Color.FromArgb(100, 100, 100);
        /// <summary>
        /// The positron ib
        /// </summary>
        private Color positronIB = Color.FromArgb(200, 200, 200);
        /// <summary>
        /// The positron pb
        /// </summary>
        private Color positronPB = Color.FromArgb(150, 150, 150);
        /// <summary>
        /// The positron bg
        /// </summary>
        private Color positronBG = Color.FromArgb(210, 210, 210);

        /// <summary>
        /// The positron ic
        /// </summary>
        private Color positronIC = Color.FromArgb(215, 215, 215);


        /// <summary>
        /// Positrons the paint hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PositronPaintHook(PaintEventArgs e)
        {
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G.SmoothingMode = Smoothing;

            switch (_Orientation)
            {
                case System.Windows.Forms.Orientation.Horizontal:

                    int area = Convert.ToInt32((Value * (Width - 6)) / Maximum);
                    G.Clear(positronBG);
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90f);

                    if (Value == Maximum)
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(G, new Pen(positronPB), 3);
                    }
                    
                    else
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, area, Height - 4));
                        G.DrawRectangle(new Pen(positronPB), new Rectangle(3, 3, area - 1, Height - 7));
                    }

                    if (ShowPercentage)
                    {
                        string val = Value.ToString();
                        DrawText(new SolidBrush(positronBT), val, HorizontalAlignment.Center, 0, 0);
                    }

                    break; // TODO: might not be correct. Was : Exit Select


                    break;
                case System.Windows.Forms.Orientation.Vertical:

                    int area2 = Convert.ToInt32((Value * (Height - 6)) / Maximum);

                    G.Clear(positronBG);
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90f);

                    if (Value == Maximum)
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(G, new Pen(positronPB), 3);
                    }
                    
                    else
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, area2));
                        G.DrawRectangle(new Pen(positronPB), new Rectangle(3, 3, Width - 7, area2));
                    }
                    if (ShowPercentage)
                    {
                        string val = Value.ToString();
                        DrawText(new SolidBrush(positronBT), val, HorizontalAlignment.Center, 0, 0);
                    }


                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }

            DrawBorders(G,new Pen(positronIB));
            DrawBorders(G,new Pen(positronPB), 1);

            //e.Graphics.DrawImage(B, 0, 0);
            //G.Dispose();
            //B.Dispose();


        }

    }

}

