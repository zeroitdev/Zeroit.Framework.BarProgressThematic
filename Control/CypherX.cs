// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-14-2018
// ***********************************************************************
// <copyright file="CypherX.cs" company="Zeroit Dev Technologies">
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
        /// Cyperxes the progressbar.
        /// </summary>
        private void CyperxProgressbar()
        {
            Font = new Font("Arial", 8);
            ForeColor = Color.White;
        }

        /// <summary>
        /// The use color
        /// </summary>
        bool _UseColor = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BarProgressThematic"/> is colorize.
        /// </summary>
        /// <value><c>true</c> if colorize; otherwise, <c>false</c>.</value>
        public bool Colorize
        {
            get { return _UseColor; }
            set
            {
                _UseColor = value;
                Invalidate();
            }
        }
        //float Perc = 0;
        //public float Percentage
        //{
        //    get { return Perc; }
        //}
        /// <summary>
        /// Cyphers the x on paint.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void CypherXOnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle WholeR = new Rectangle(0, 0, Width - 1, Height - 1);
            Draw.Gradient(g, _Lightcolor, _DarkColor, WholeR);
            g.DrawRectangle(Pens.Black, WholeR);
            float OneProcent = Maximum / 100;
            int ProgressProcent = Convert.ToInt32(_value / OneProcent);
            //Console.WriteLine(ProgressProcent);

            Rectangle ProgressRec = new Rectangle(2, 2, Convert.ToInt32((Width - 4) * (ProgressProcent * 0.01)), Height - 4);
            //Perc = _value / (Maximum / 100);
            switch (_UseColor)
            {
                case false:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), ProgressRec);
                    break;
                case true:
                    Color Drawcolor = Color.FromArgb(150, 255 - 2 * ProgressProcent, Convert.ToInt32(1.7 * ProgressProcent), 0);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(50, Drawcolor)), ProgressRec);
                    break;
            }

            if (Showt)
                g.DrawString(Convert.ToString(_value) + "%", Font, new SolidBrush(ForeColor), new Point(Width / 2 - 9, Height / 2 - 7));




        }




        #region " Properties "

        /// <summary>
        /// The showt
        /// </summary>
        bool Showt = true;
        /// <summary>
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return Showt; }
            set
            {
                Showt = value;
                Invalidate();
            }
        }


        //private float _Current;
        //public float Current
        //{
        //    get { return _Current; }
        //    set
        //    {
        //        _Current = value;
        //        value = value / _Maximum * 100;
        //        Invalidate();
        //    }
        //}


        /// <summary>
        /// Gets or sets the color of the dark.
        /// </summary>
        /// <value>The color of the dark.</value>
        public Color DarkColor
        {


            get { return _DarkColor; }
            set
            {
                _DarkColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the lightcolor.
        /// </summary>
        /// <value>The lightcolor.</value>
        public Color Lightcolor
        {
            get { return _Lightcolor; }
            set
            {
                _Lightcolor = value;
                Invalidate();
            }
        }

        #endregion

        #region " Colors "
        /// <summary>
        /// The lightcolor
        /// </summary>
        Color _Lightcolor = Color.FromArgb(65, 55, 45);
        /// <summary>
        /// The dark color
        /// </summary>
        Color _DarkColor = Color.FromArgb(75, 70, 65);
        #endregion




    }

}

