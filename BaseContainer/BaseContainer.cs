// ***********************************************************************
// Assembly         : Zeroit.Framework.BarProgressThematic
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2018
// ***********************************************************************
// <copyright file="BaseContainer.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Zeroit.Framework.BarProgressThematic.ThemeManagers;

namespace Zeroit.Framework.BarProgressThematic.Controls
{

    /// <summary>
    /// Class BarProgressThematic.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.BarProgressThematic.ThemeManagers.ThemeControl" />
    [Designer(typeof(BarProgressDesigner))]
    public partial class BarProgressThematic : ThemeControl
    {

        #region Private Fields

        /// <summary>
        /// The progress style
        /// </summary>
        private ProgressStyles progressStyle = ProgressStyles.Atrocity;
        /// <summary>
        /// The state
        /// </summary>
        private MouseState State = MouseState.None;
        #endregion

        #region Public Properties

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.ClearTypeGridFit;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }


        #endregion

        #region Interpolation Mode

        /// <summary>
        /// The interpolation mode
        /// </summary>
        private InterpolationMode interpolationMode = InterpolationMode.HighQualityBilinear;

        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set
            {
                interpolationMode = value;
                Invalidate();
            }
        }

        #endregion

        #region Pixel Offset
        /// <summary>
        /// The pixel offset mode
        /// </summary>
        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.HighQuality;

        /// <summary>
        /// Gets or sets the pixel offset mode.
        /// </summary>
        /// <value>The pixel offset mode.</value>
        public PixelOffsetMode PixelOffsetMode
        {
            get { return pixelOffsetMode; }
            set
            {
                pixelOffsetMode = value;
                Invalidate();
            }
        }



        #endregion

        #region Compositing Quality

        private CompositingQuality compositingQuality = CompositingQuality.HighQuality;
        public CompositingQuality CompositingQuality
        {
            get { return compositingQuality; }
            set
            {
                compositingQuality = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the progress style.
        /// </summary>
        /// <value>The progress style.</value>
        public ProgressStyles ProgressStyle
        {
            get { return progressStyle; }
            set {


                progressStyle = value;
                Invalidate();
            }
        }

        //[Description("The maximum ammount of steps the progressbar can go before being full"), Category("Atrocity"), Browsable(true)]
        //private int _Maximum = 100;
        //public int Maximum
        //{
        //    get { return _Maximum; }

        //    set
        //    {
        //        if (value < 1)
        //            value = 1;
        //        if (value < _Value)
        //            _Value = value;

        //        _Maximum = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// The minimum
        /// </summary>
        private float _Minimum = 0;
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public float Minimum
        {
            get { return _Minimum; }
            set
            {

                switch (ProgressStyle)
                {
                    case ProgressStyles.Ambiance:
                        break;
                    case ProgressStyles.ASC:
                        break;
                    case ProgressStyles.Atrocity:
                        break;
                    //case ProgressStyles.BAW:
                    //    ChangePaths();
                    //    break;
                    case ProgressStyles.Black:
                        break;
                    case ProgressStyles.Butter:
                        break;
                    case ProgressStyles.ButterBut:
                        break;
                    case ProgressStyles.ButterVertical:
                        break;
                    case ProgressStyles.Carbon:
                        break;
                    case ProgressStyles.CypherX:
                        break;
                    case ProgressStyles.Deumos:
                        break;
                    case ProgressStyles.Doom:
                        break;
                    case ProgressStyles.Drone:
                        break;
                    //case ProgressStyles.DroneV2:
                    //    break;
                    case ProgressStyles.Eight:
                        break;
                    case ProgressStyles.Evolve:
                        break;
                    case ProgressStyles.Excision:
                        break;
                    case ProgressStyles.Facebook:
                        break;
                    case ProgressStyles.Gray:
                        break;
                    case ProgressStyles.Green:
                        break;
                    case ProgressStyles.Hacker:
                        break;
                    case ProgressStyles.Imagine:
                        break;
                    case ProgressStyles.Influence:
                        break;
                    case ProgressStyles.Jasta:
                        break;
                    case ProgressStyles.Kasper:
                        break;
                    case ProgressStyles.Login:
                        break;
                    case ProgressStyles.LoginWithProg:
                        break;
                    case ProgressStyles.Modern:
                        break;
                    case ProgressStyles.NS:
                        break;
                    case ProgressStyles.NYX:
                        break;
                    case ProgressStyles.PlayUI:
                        break;
                    case ProgressStyles.Posit:
                        break;
                    case ProgressStyles.Qube:
                        break;
                    case ProgressStyles.Reactor:
                        break;
                    case ProgressStyles.Redemption:
                        break;
                    case ProgressStyles.Sharp:
                        break;
                    case ProgressStyles.Simpla:
                        break;
                    case ProgressStyles.Subspace:
                        break;
                    case ProgressStyles.xVisual:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _Minimum = value;
                //value = _Current / value * 100;
                Invalidate();
            }
        }

        /// <summary>
        /// The maximum
        /// </summary>
        private float _Maximum = 100;
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public float Maximum
        {
            get { return _Maximum; }
            set
            {

                switch (ProgressStyle)
                {
                    case ProgressStyles.Ambiance:
                        break;
                    case ProgressStyles.ASC:
                        break;
                    case ProgressStyles.Atrocity:
                        break;
                    //case ProgressStyles.BAW:
                    //    ChangePaths();
                        break;
                    case ProgressStyles.Black:
                        BlackProgressBar();
                        break;
                    case ProgressStyles.Butter:
                        break;
                    case ProgressStyles.ButterBut:
                        break;
                    case ProgressStyles.ButterVertical:
                        break;
                    case ProgressStyles.Carbon:
                        break;
                    case ProgressStyles.CypherX:
                        break;
                    case ProgressStyles.Deumos:
                        break;
                    case ProgressStyles.Doom:
                        break;
                    case ProgressStyles.Drone:
                        break;
                    //case ProgressStyles.DroneV2:
                    //    break;
                    case ProgressStyles.Eight:
                        break;
                    case ProgressStyles.Evolve:
                        break;
                    case ProgressStyles.Excision:
                        break;
                    case ProgressStyles.Facebook:
                        break;
                    case ProgressStyles.Gray:
                        break;
                    case ProgressStyles.Green:
                        break;
                    case ProgressStyles.Hacker:
                        break;
                    case ProgressStyles.Imagine:
                        break;
                    case ProgressStyles.Influence:
                        break;
                    case ProgressStyles.Jasta:
                        break;
                    case ProgressStyles.Kasper:
                        break;
                    case ProgressStyles.Login:
                        break;
                    case ProgressStyles.LoginWithProg:
                        break;
                    case ProgressStyles.Modern:
                        break;
                    case ProgressStyles.NS:
                        break;
                    case ProgressStyles.NYX:
                        break;
                    case ProgressStyles.PlayUI:
                        break;
                    case ProgressStyles.Posit:
                        break;
                    case ProgressStyles.Qube:
                        break;
                    case ProgressStyles.Reactor:
                        break;
                    case ProgressStyles.Redemption:
                        break;
                    case ProgressStyles.Sharp:
                        break;
                    case ProgressStyles.Simpla:
                        break;
                    case ProgressStyles.Subspace:
                        break;
                    case ProgressStyles.xVisual:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _Maximum = value;
                //value = _Current / value * 100;
                Invalidate();
            }
        }

        /// <summary>
        /// The value
        /// </summary>
        private float _value = 0;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public float Value
        {
            get { return _value; }
            set
            {
                if (value < Minimum)
                    value = Minimum;
                else
                if (value > Maximum)
                    value = Maximum;
                _value = Convert.ToInt32(value);
                //_Current = value * 0.01 * _Maximum;

                try
                {
                    if (Width > 0)
                        UpdateProgress();
                }
                catch (Exception e)
                {
                    
                }

                switch (ProgressStyle)
                {
                    case ProgressStyles.Ambiance:
                        break;
                    case ProgressStyles.ASC:
                        break;
                    case ProgressStyles.Atrocity:
                        break;
                    //case ProgressStyles.BAW:
                    //    break;
                    case ProgressStyles.Black:
                        break;
                    case ProgressStyles.Butter:
                        break;
                    case ProgressStyles.ButterBut:
                        break;
                    case ProgressStyles.ButterVertical:
                        break;
                    case ProgressStyles.Carbon:
                        break;
                    case ProgressStyles.CypherX:
                        break;
                    case ProgressStyles.Deumos:
                        break;
                    case ProgressStyles.Doom:
                        break;
                    case ProgressStyles.Drone:
                        break;
                    //case ProgressStyles.DroneV2:
                    //    break;
                    case ProgressStyles.Eight:
                        break;
                    case ProgressStyles.Evolve:
                        break;
                    case ProgressStyles.Excision:
                        break;
                    case ProgressStyles.Facebook:
                        break;
                    case ProgressStyles.Gray:
                        break;
                    case ProgressStyles.Green:
                        break;
                    case ProgressStyles.Hacker:
                        break;
                    case ProgressStyles.Imagine:
                        break;
                    case ProgressStyles.Influence:
                        break;
                    case ProgressStyles.Jasta:
                        break;
                    case ProgressStyles.Kasper:
                        break;
                    case ProgressStyles.Login:
                        break;
                    case ProgressStyles.LoginWithProg:
                        break;
                    case ProgressStyles.Modern:
                        break;
                    case ProgressStyles.NS:
                        break;
                    case ProgressStyles.NYX:
                        break;
                    case ProgressStyles.PlayUI:
                        break;
                    case ProgressStyles.Posit:
                        break;
                    case ProgressStyles.Qube:
                        break;
                    case ProgressStyles.Reactor:
                        break;
                    case ProgressStyles.Redemption:
                        break;
                    case ProgressStyles.Sharp:

                        //if (value < Maximum) // value < 100
                        //    GlowAnimation.Start();

                        SharpProgreSsBar();

                        break;
                    case ProgressStyles.Simpla:
                        break;
                    case ProgressStyles.Subspace:
                        break;
                    case ProgressStyles.xVisual:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                Invalidate();
            }
        }


        //[Description("The current ammount of steps the progressbar has taken."), Category("Atrocity"), Browsable(true)]
        //private int _Value = 0;
        //public int Value
        //{
        //    get { return _Value; }

        //    set
        //    {
        //        if (value > _Maximum)
        //            value = _Maximum;

        //        _Value = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// The show percentage
        /// </summary>
        private bool _ShowPercentage = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show percentage].
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        [Description("Indicates if the value of the progress bar will be shown in the middle of it.")]
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BarProgressThematic"/> class.
        /// </summary>
        public BarProgressThematic()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;

            IncludeInConstructor();

            SharpProgreSsBar();
        }

        #endregion

        #region Overrides


        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {

        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void PaintHook(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = Smoothing;
            e.Graphics.InterpolationMode = InterpolationMode;
            e.Graphics.PixelOffsetMode = PixelOffsetMode;
            e.Graphics.CompositingQuality = CompositingQuality;
            e.Graphics.TextRenderingHint = TextRendering;
            
            switch (ProgressStyle)
            {
                case ProgressStyles.Ambiance:
                    AmbianceOnPaint(e);
                    break;
                case ProgressStyles.ASC:
                    ASOnPaint(e);
                    break;
                case ProgressStyles.Atrocity:
                    AtrocityPaintHook(e);
                    break;
                //case ProgressStyles.BAW:
                //    //BAWOnPaint(e);
                //    break;
                case ProgressStyles.Black:
                    BlackPaintHook(e);
                    break;
                case ProgressStyles.Butter:
                    ButterOnPaint(e);
                    break;
                case ProgressStyles.ButterBut:
                    break;
                case ProgressStyles.ButterVertical:
                    ButterVertOnPaint(e);
                    break;
                case ProgressStyles.Carbon:
                    CarbonOnPaint(e);
                    break;
                case ProgressStyles.CypherX:
                    CypherXOnPaint(e);
                    break;
                case ProgressStyles.Deumos:
                    DeumosPaintHook(e);
                    break;
                case ProgressStyles.Doom:
                    DoomPaintHook(e);
                    break;
                case ProgressStyles.Drone:
                    DronePaintHook(e);
                    break;
                //case ProgressStyles.DroneV2:
                //    break;
                case ProgressStyles.Eight:
                    EightOnPaint(e);
                    break;
                case ProgressStyles.Evolve:
                    EvolvePaintHook(e);
                    break;
                case ProgressStyles.Excision:
                    ExcisionOnPaint(e);
                    break;
                case ProgressStyles.Facebook:
                    FacebookOnPaint(e);
                    break;
                case ProgressStyles.Gray:
                    GrayOnPaint(e);
                    break;
                case ProgressStyles.Green:
                    GreenOnPaint(e);
                    break;
                case ProgressStyles.Hacker:
                    HackerPaintHook(e);
                    break;
                case ProgressStyles.Imagine:
                    ImaginePaintHook(e);
                    break;
                case ProgressStyles.Influence:
                    InfluenceOnPaint(e);
                    break;
                case ProgressStyles.Jasta:
                    JastaPaintHook(e);
                    break;
                case ProgressStyles.Kasper:
                    KasperskyOnPaint(e);
                    break;
                case ProgressStyles.Login:
                    LogOnPaint(e);
                    break;
                case ProgressStyles.LoginWithProg:
                    LoginOnPaint(e);
                    break;
                case ProgressStyles.Modern:
                    ModernOnPaint(e);
                    break;
                case ProgressStyles.NS:
                    NSOnPaint(e);
                    break;
                case ProgressStyles.NYX:
                    NYXPaintHook(e);
                    break;
                case ProgressStyles.PlayUI:
                    PlayUIOnPaint(e);
                    break;
                case ProgressStyles.Posit:
                    PositronPaintHook(e);
                    break;
                case ProgressStyles.Qube:
                    QubeOnPaint(e);
                    break;
                case ProgressStyles.Reactor:
                    ReactorOnPaint(e);
                    break;
                case ProgressStyles.Redemption:
                    RedemptionOnPaint(e);
                    break;
                case ProgressStyles.Sharp:
                    SharpOnPaint(e);
                    break;
                case ProgressStyles.Simpla:
                    SimplaOnPaint(e);
                    break;
                case ProgressStyles.Subspace:
                    SubspacePaintHook(e);
                    break;
                case ProgressStyles.xVisual:
                    xVisualOnPaint(e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.AutoSizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);

            switch (ProgressStyle)
            {
                case ProgressStyles.Ambiance:
                    break;
                case ProgressStyles.ASC:
                    break;
                case ProgressStyles.Atrocity:
                    break;
                //case ProgressStyles.BAW:
                //    break;
                case ProgressStyles.Black:
                    break;
                case ProgressStyles.Butter:
                    break;
                case ProgressStyles.ButterBut:
                    break;
                case ProgressStyles.ButterVertical:
                    break;
                case ProgressStyles.Carbon:
                    break;
                case ProgressStyles.CypherX:
                    break;
                case ProgressStyles.Deumos:
                    break;
                case ProgressStyles.Doom:
                    break;
                case ProgressStyles.Drone:
                    break;
                //case ProgressStyles.DroneV2:
                //    break;
                case ProgressStyles.Eight:
                    break;
                case ProgressStyles.Evolve:
                    break;
                case ProgressStyles.Excision:
                    break;
                case ProgressStyles.Facebook:
                    break;
                case ProgressStyles.Gray:
                    break;
                case ProgressStyles.Green:
                    GreenOnSizeChanged(e);
                    break;
                case ProgressStyles.Hacker:
                    break;
                case ProgressStyles.Imagine:
                    break;
                case ProgressStyles.Influence:
                    break;
                case ProgressStyles.Jasta:
                    break;
                case ProgressStyles.Kasper:
                    break;
                case ProgressStyles.Login:
                    break;
                case ProgressStyles.LoginWithProg:
                    break;
                case ProgressStyles.Modern:
                    break;
                case ProgressStyles.NS:
                    break;
                case ProgressStyles.NYX:
                    break;
                case ProgressStyles.PlayUI:
                    break;
                case ProgressStyles.Posit:
                    break;
                case ProgressStyles.Qube:
                    break;
                case ProgressStyles.Reactor:
                    break;
                case ProgressStyles.Redemption:
                    break;
                case ProgressStyles.Sharp:
                    break;
                case ProgressStyles.Simpla:
                    break;
                case ProgressStyles.Subspace:
                    break;
                case ProgressStyles.xVisual:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Invalidate();
        }

        /// <summary>
        /// Called when [creation].
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void OnCreation()
        {
            switch (ProgressStyle)
            {
                case ProgressStyles.Ambiance:
                    break;
                case ProgressStyles.ASC:
                    break;
                case ProgressStyles.Atrocity:
                    break;
                //case ProgressStyles.BAW:
                //    break;
                case ProgressStyles.Black:
                    break;
                case ProgressStyles.Butter:
                    break;
                case ProgressStyles.ButterBut:
                    break;
                case ProgressStyles.ButterVertical:
                    break;
                case ProgressStyles.Carbon:
                    break;
                case ProgressStyles.CypherX:
                    break;
                case ProgressStyles.Deumos:
                    break;
                case ProgressStyles.Doom:
                    break;
                case ProgressStyles.Drone:
                    DroneOnCreationControl();
                    break;
                //case ProgressStyles.DroneV2:
                //    break;
                case ProgressStyles.Eight:
                    break;
                case ProgressStyles.Evolve:
                    break;
                case ProgressStyles.Excision:
                    break;
                case ProgressStyles.Facebook:
                    break;
                case ProgressStyles.Gray:
                    break;
                case ProgressStyles.Green:
                    break;
                case ProgressStyles.Hacker:
                    break;
                case ProgressStyles.Imagine:
                    break;
                case ProgressStyles.Influence:
                    break;
                case ProgressStyles.Jasta:
                    break;
                case ProgressStyles.Kasper:
                    break;
                case ProgressStyles.Login:
                    break;
                case ProgressStyles.LoginWithProg:
                    break;
                case ProgressStyles.Modern:
                    break;
                case ProgressStyles.NS:
                    break;
                case ProgressStyles.NYX:
                    break;
                case ProgressStyles.PlayUI:
                    break;
                case ProgressStyles.Posit:
                    break;
                case ProgressStyles.Qube:
                    break;
                case ProgressStyles.Reactor:
                    break;
                case ProgressStyles.Redemption:
                    break;
                case ProgressStyles.Sharp:
                    break;
                case ProgressStyles.Simpla:
                    break;
                case ProgressStyles.Subspace:
                    break;
                case ProgressStyles.xVisual:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Height = 25;
        }

        /// <summary>
        /// Creates a handle for the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            //Height = 25;
            InfluenceCreateHandle();
            SimplaCreateHandle();
            ReactorCreateHandle();
        }

        /// <summary>
        /// Called when [animation].
        /// </summary>
        protected override void OnAnimation()
        {
            base.OnAnimation();

            SubspaceOnAnimation();
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        /// <summary>
        /// Handles the <see cref="E:MouseUp" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        /// <summary>
        /// Handles the <see cref="E:MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        /// <summary>
        /// Handles the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }





        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion




        //protected override void CreateHandle()
        //{

        //    switch (ProgressStyle)
        //    {
        //        case ProgressStyles.Ambiance:
        //            break;
        //        case ProgressStyles.ASC:
        //            break;
        //        case ProgressStyles.Atrocity:
        //            break;
        //        case ProgressStyles.BAW:
        //            break;
        //        case ProgressStyles.Black:
        //            break;
        //        case ProgressStyles.Butter:
        //            break;
        //        case ProgressStyles.ButterBut:
        //            break;
        //        case ProgressStyles.ButterVertical:
        //            break;
        //        case ProgressStyles.Carbon:
        //            break;
        //        case ProgressStyles.CypherX:
        //            break;
        //        case ProgressStyles.Deumos:
        //            break;
        //        case ProgressStyles.Doom:
        //            break;
        //        case ProgressStyles.Drone:
        //            break;
        //        case ProgressStyles.DroneV2:
        //            break;
        //        case ProgressStyles.Eight:
        //            break;
        //        case ProgressStyles.Evolve:
        //            break;
        //        case ProgressStyles.Excision:
        //            ExcisionOnCreateHandle();
        //            break;
        //        case ProgressStyles.Facebook:
        //            break;
        //        case ProgressStyles.Gray:
        //            break;
        //        case ProgressStyles.Green:
        //            break;
        //        case ProgressStyles.Hacker:
        //            break;
        //        case ProgressStyles.Imagine:
        //            break;
        //        case ProgressStyles.Influence:
        //            break;
        //        case ProgressStyles.Jasta:
        //            break;
        //        case ProgressStyles.Kasper:
        //            break;
        //        case ProgressStyles.Login:
        //            break;
        //        case ProgressStyles.LoginWithProg:
        //            break;
        //        case ProgressStyles.Modern:
        //            break;
        //        case ProgressStyles.NS:
        //            break;
        //        case ProgressStyles.NYX:
        //            break;
        //        case ProgressStyles.PlayUI:
        //            break;
        //        case ProgressStyles.Posit:
        //            break;
        //        case ProgressStyles.Qube:
        //            break;
        //        case ProgressStyles.Reactor:
        //            break;
        //        case ProgressStyles.Redemption:
        //            break;
        //        case ProgressStyles.Sharp:
        //            break;
        //        case ProgressStyles.Simpla:
        //            break;
        //        case ProgressStyles.Subspace:
        //            break;
        //        case ProgressStyles.xVisual:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }

        //}



        #endregion

        #region Draw Borders
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawBorders(Graphics G, Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, int offset)
        {
            DrawBorders(G, p1, 0, 0, Width, Height, offset);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="r">The r.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, Rectangle r, int offset)
        {
            DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height, offset);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(G, p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        protected void DrawBorders(Graphics G, Pen p1)
        {
            DrawBorders(G, p1, 0, 0, Width, Height);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="r">The r.</param>
        protected void DrawBorders(Graphics G, Pen p1, Rectangle r)
        {
            DrawBorders(G, p1, r.X, r.Y, r.Width, r.Height);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected void DrawBorders(Graphics G, Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// To the pen.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Pen.</returns>
        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        /// <summary>
        /// To the brush.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Brush.</returns>
        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        #endregion

        #region " DrawGradient "

        //private LinearGradientBrush DrawGradientBrush;

        //private Rectangle DrawGradientRectangle;
        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="blend">The blend.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected void DrawGradients(Graphics G, ColorBlend blend, int x, int y, int width, int height)
        {
            Rectangle DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradients(G,blend, DrawGradientRectangle);
        }
        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="blend">The blend.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradients(Graphics G, ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            Rectangle DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradients(G,blend, DrawGradientRectangle, angle);
        }

        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="blend">The blend.</param>
        /// <param name="r">The r.</param>
        protected void DrawGradients(Graphics G, ColorBlend blend, Rectangle r)
        {
            LinearGradientBrush DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="blend">The blend.</param>
        /// <param name="r">The r.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradients(Graphics G,ColorBlend blend, Rectangle r, float angle)
        {
            LinearGradientBrush DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }


        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected void DrawGradients(Graphics G, Color c1, Color c2, int x, int y, int width, int height)
        {
            Rectangle DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradients(G,c1, c2, DrawGradientRectangle);
        }
        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradients(Graphics G, Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            Rectangle DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradients(G,c1, c2, DrawGradientRectangle, angle);
        }

        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="r">The r.</param>
        protected void DrawGradients(Graphics G,Color c1, Color c2, Rectangle r)
        {
            LinearGradientBrush DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
            G.FillRectangle(DrawGradientBrush, r);
        }
        /// <summary>
        /// Draws the gradients.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="r">The r.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradients(Graphics G, Color c1, Color c2, Rectangle r, float angle)
        {
            LinearGradientBrush DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion




        #region Include in Private Field

        private bool autoAnimate = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerDecrement = new System.Windows.Forms.Timer();
        private float speedMultiplier = 1;
        private float change = 0.1f;
        private bool reverse = true;
        private float value = 0;
        private float minimum = 0;
        private float maximum = 100;
        private bool sluggish = false;
        #endregion

        #region Include in Public Properties

        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                    timerDecrement.Enabled = false;
                }

                Invalidate();
            }
        }

        public bool Reverse
        {
            get { return reverse; }
            set
            {

                reverse = value;
                Invalidate();
            }
        }

        public float Change
        {
            get { return change; }
            set
            {
                change = value;
                Invalidate();
            }
        }

        public float SpeedMultiplier
        {
            get { return speedMultiplier; }
            set
            {
                speedMultiplier = value;
                Invalidate();
            }
        }

        public int TimerInterval
        {
            get { return timer.Interval; }
            set
            {
                timer.Interval = value;
                timerDecrement.Interval = value;
                Invalidate();
            }
        }

        
        public bool Sluggish
        {
            get { return sluggish; }
            set
            {
                sluggish = value;
                Invalidate();
            }
        }

        #endregion

        #region Event

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (Reverse)
            {

                if (this.Value + (0.1f * SpeedMultiplier) > Maximum)
                {
                    timer.Stop();
                    timer.Enabled = false;
                    timerDecrement.Enabled = true;
                    timerDecrement.Start();
                    //timerDecrement.Tick += TimerDecrement_Tick;
                    Invalidate();
                }

                else
                {
                    this.Value += (Change * SpeedMultiplier);
                    Invalidate();
                }


            }
            else
            {

                if (Sluggish)
                {
                    if (this.Value + (0.1f * SpeedMultiplier) > Maximum)
                    {
                        timer.Stop();
                        timer.Enabled = false;
                        timerDecrement.Enabled = true;
                        timerDecrement.Start();
                        //timerDecrement.Tick += TimerDecrement_Tick;
                        Invalidate();
                    }

                    else
                    {
                        this.Value += (Change * SpeedMultiplier);
                        Invalidate();
                    }
                }
                else
                {
                    if (this.Value + (0.1f * SpeedMultiplier) > Maximum)
                    {
                        timerDecrement.Enabled = false;
                        timerDecrement.Stop();
                        //timerDecrement.Tick += TimerDecrement_Tick;
                        Value = 0;
                        Invalidate();
                    }

                    else
                    {
                        this.Value += (Change * SpeedMultiplier);
                        Invalidate();
                    }
                }

            }
        }


        private void TimerDecrement_Tick(object sender, EventArgs e)
        {
            if (this.Value < this.Minimum)
            {
                timerDecrement.Stop();
                timerDecrement.Enabled = false;
                timer.Enabled = true;
                timer.Start();
                //timer.Tick += Timer_Tick;
                Invalidate();
            }

            else
            {
                this.Value -= (0.1f * SpeedMultiplier);
                Invalidate();
            }


        }


        #endregion

        #region Constructor

        private void IncludeInConstructor()
        {

            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                timerDecrement.Tick += TimerDecrement_Tick;
                if (AutoAnimate)
                {
                    timerDecrement.Interval = 100;
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;
                timerDecrement.Tick += TimerDecrement_Tick;
                if (AutoAnimate)
                {
                    timerDecrement.Interval = 100;
                    timer.Interval = 100;
                    timer.Start();
                }
            }

        }

        #endregion




    }
}
