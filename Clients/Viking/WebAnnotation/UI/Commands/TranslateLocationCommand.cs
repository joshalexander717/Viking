﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAnnotationModel;
using Geometry;
using WebAnnotation.View;
using SqlGeometryUtils;
using VikingXNAGraphics;
using System.Windows.Forms;
using System.Diagnostics;

namespace WebAnnotation.UI.Commands
{
    class TranslateCurveLocationCommand : TranslateLocationCommand
    {
        CurveView curveView;
        GridVector2[] OriginalControlPoints;
        GridVector2 OriginalPosition;
        GridVector2 DeltaSum = new GridVector2(0, 0);

        public delegate void OnCommandSuccess(GridVector2[] VolumeControlPoints, GridVector2[] MosaicControlPoints);
        OnCommandSuccess success_callback;

        Viking.VolumeModel.IVolumeToSectionMapper mapping;

        protected override GridVector2 TranslatedPosition
        {
            get
            {
                return OriginalPosition + (DeltaSum);
            } 
        }

        public TranslateCurveLocationCommand(Viking.UI.Controls.SectionViewerControl parent,
                                        GridVector2 OriginalPosition, 
                                        GridVector2[] OriginalControlPoints,
                                        Microsoft.Xna.Framework.Color color,
                                        double LineWidth,
                                        bool IsClosedCurve,
                                        OnCommandSuccess success_callback) : base(parent)
        {
            this.OriginalPosition = OriginalPosition;
            this.OriginalControlPoints = OriginalControlPoints;
            CreateView(OriginalControlPoints, color.ConvertToHSL(0.5f), LineWidth, IsClosedCurve);
            this.success_callback = success_callback;
            mapping = parent.Section.ActiveMapping;
        }

        private void CreateView(GridVector2[] ControlPoints, Microsoft.Xna.Framework.Color color, double LineWidth, bool IsClosed)
        {
            curveView = new CurveView(ControlPoints.ToList(), color, false, lineWidth: LineWidth);
            curveView.TryCloseCurve = IsClosed;
        }

        protected override void UpdateViewPosition(GridVector2 PositionDelta)
        {
            DeltaSum += PositionDelta;
            curveView.ControlPoints = curveView.ControlPoints.Select(p => p + PositionDelta).ToArray();
        }

        protected override void Execute()
        {
            if (this.success_callback != null)
            {
                GridVector2[] TranslatedOriginalControlPoints = OriginalControlPoints.Select(p => p + DeltaSum).ToArray();
                GridVector2[] MosaicControlPoints = null;

                try
                {
                    MosaicControlPoints = mapping.VolumeToSection(TranslatedOriginalControlPoints);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Trace.WriteLine("TranslateLocationCommand: Could not map world point on Execute: " + TranslatedPosition.ToString(), "Command");
                    return;
                }

                this.success_callback(TranslatedOriginalControlPoints, MosaicControlPoints);
            }

            base.Execute();
        }


        public override void OnDraw(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice,
                                    VikingXNA.Scene scene,
                                    Microsoft.Xna.Framework.Graphics.BasicEffect basicEffect)
        {
            CurveView.Draw(graphicsDevice, scene, Parent.LumaOverlayCurveManager, basicEffect, Parent.annotationOverlayEffect, 0, new CurveView[] { this.curveView });
        }
    }

    class TranslateCircleLocationCommand : TranslateLocationCommand
    {
        CircleView circleView;
        GridCircle OriginalCircle;

        public delegate void OnCommandSuccess(GridVector2 VolumePosition, GridVector2 MosaicPosition);
        OnCommandSuccess success_callback;

        Viking.VolumeModel.IVolumeToSectionMapper mapping;

        protected override GridVector2 TranslatedPosition
        {
            get
            {
                return circleView.VolumePosition;
            }
        }

        public TranslateCircleLocationCommand(Viking.UI.Controls.SectionViewerControl parent,
                                        GridCircle circle,
                                        Microsoft.Xna.Framework.Color color,
                                        OnCommandSuccess success_callback) : base(parent)
        {
            CreateView(circle.Center, circle.Radius, color);
            OriginalCircle = circle;
            this.success_callback = success_callback;
            mapping = parent.Section.ActiveMapping;
        }

        private void CreateView(GridVector2 Position, double Radius, Microsoft.Xna.Framework.Color color)
        {
            circleView = new CircleView(new GridCircle(Position, Radius), color);
        }

        protected override void Execute()
        {
            if (this.success_callback != null)
            {
                GridVector2 MosaicPosition;

                bool mappedToMosaic = mapping.TryVolumeToSection(TranslatedPosition, out MosaicPosition);
                if(!mappedToMosaic)
                {
                    Trace.WriteLine("TranslateLocationCommand: Could not map world point on Execute: " + TranslatedPosition.ToString(), "Command");
                    return;
                }

                this.success_callback(this.TranslatedPosition, MosaicPosition);
            } 

            base.Execute();
        }

        protected override void UpdateViewPosition(GridVector2 PositionDelta)
        {
            circleView.Circle = new GridCircle(circleView.Circle.Center + PositionDelta, this.circleView.Radius);
        }

        public override void OnDraw(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice,
                                    VikingXNA.Scene scene,
                                    Microsoft.Xna.Framework.Graphics.BasicEffect basicEffect)
        {
            //TODO: Translate the LocationCanvasView before it is drawn
            CircleView.Draw(graphicsDevice, scene, basicEffect, Parent.annotationOverlayEffect, new CircleView[] { this.circleView });
            //LocationObjRenderer.DrawBackgrounds(items, graphicsDevice, basicEffect, Parent.annotationOverlayEffect, Parent.LumaOverlayLineManager, scene, Parent.Section.Number);            
        }
        public static void DefaultSuccessCallback(LocationObj loc, GridVector2 WorldPosition, GridVector2 MosaicPosition)
        {
            DefaultSuccessNoSaveCallback(loc, WorldPosition, MosaicPosition);
            Store.Locations.Save();
        }

        public static void DefaultSuccessNoSaveCallback(LocationObj loc, GridVector2 WorldPosition, GridVector2 MosaicPosition)
        {
            loc.MosaicShape = loc.MosaicShape.MoveTo(MosaicPosition);
            loc.VolumeShape = loc.VolumeShape.MoveTo(WorldPosition);
        }
    }

    abstract class TranslateLocationCommand : AnnotationCommandBase
    {         
        /// <summary>
        /// Translated position in volume space
        /// </summary>
        protected abstract GridVector2 TranslatedPosition
        {
             get;
        }

        public TranslateLocationCommand(Viking.UI.Controls.SectionViewerControl parent) : base(parent)
        {
        }

        protected abstract void UpdateViewPosition(GridVector2 PositionDelta);

       

        

        public override void OnDeactivate()
        {
            Viking.UI.State.SelectedObject = null;

            base.OnDeactivate();
        }

        protected override void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Redraw if we are dragging a location
            if (this.oldMouse != null)
            {
                if (this.oldMouse.Button == MouseButtons.Left)
                {
                    GridVector2 LastWorldPosition = Parent.ScreenToWorld(oldMouse.X, oldMouse.Y);
                    GridVector2 NewPosition = Parent.ScreenToWorld(e.X, e.Y);
                    UpdateViewPosition(NewPosition - LastWorldPosition);
                    //circleView.Circle = new GridCircle(this.TranslatedPosition, circleView.Radius);
                    Parent.Invalidate();
                }
            }

            base.OnMouseMove(sender, e);
        }

        protected override void OnMouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(sender, e);
            this.Execute();            
        }

        
    }
}