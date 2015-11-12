﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry;
using Microsoft.SqlServer.Types;
using WebAnnotationModel;
using SqlGeometryUtils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VikingXNA;

namespace WebAnnotation.View
{
    class LocationLineView : LocationCanvasView
    {
        public override bool IsVisible(VikingXNA.Scene scene)
        {
            return scene.VisibleWorldBounds.Intersects(this.BoundingBox);
        }

        public override bool IsVisibleOnAdjacent(VikingXNA.Scene scene)
        {
            return scene.VisibleWorldBounds.Intersects(this.BoundingBox);
        }
        
        public override GridRectangle BoundingBox
        {
            get
            {
                return this.RenderedVolumeShape.Envelope();
            }
        }

        public override bool Intersects(GridVector2 Position)
        {
            return this.RenderedVolumeShape.Intersects(Position);
        }

        public override bool Intersects(SqlGeometry shape)
        {
            return this.RenderedVolumeShape.STIntersects(shape).IsTrue;
        }

        public override bool IntersectsOnAdjacent(GridVector2 Position)
        {
            return this.RenderedVolumeShape.Intersects(Position);
        }
         
        public override double Distance(GridVector2 Position)
        {
            return this.RenderedVolumeShape.Distance(Position);
        }

        public override double DistanceFromCenterNormalized(GridVector2 Position)
        {
            //TODO: Find a more accurate measurement.  Returning 0 means the line is always on top in selection.
            return 0;
        }

        protected override void OnObjPropertyChanged(object o, PropertyChangedEventArgs args)
        {
            _RenderedVolumeShape = null;
        }

        public override void DrawLabel(SpriteBatch spriteBatch, SpriteFont font, Vector2 LocationCenterScreenPosition, float MagnificationFactor, int DirectionToVisiblePlane)
        {
            return;
        }

        public override LocationAction GetActionForPositionOnAnnotation(GridVector2 WorldPosition, int VisibleSectionNumber)
        {
            //If we are over a control point then enable adjust mode to nudge control points
            //Otherwise enable translate
            double distance = this.Distance(WorldPosition);
            if (distance > 0)
                return LocationAction.NONE;

            //Find distance to nearest control point
            if (this.VolumeShape.ToPoints().Select(p => GridVector2.Distance(WorldPosition, p) < this.Width).Any())
                return LocationAction.ADJUST;

            return LocationAction.TRANSLATE;
        }

        
        public override IList<LocationCanvasView> OverlappingLinks
        {
            get
            {
                return new List<LocationCanvasView>();
            }
        }

        public virtual double Width
        {
            get { return modelObj.Radius; }
        }

        public LocationLineView(LocationObj obj) : base(obj)
        { }

        private SqlGeometry _RenderedVolumeShape;
        public virtual SqlGeometry RenderedVolumeShape
        {
            get
            {
                if (_RenderedVolumeShape == null)
                {
                    _RenderedVolumeShape = this.modelObj.VolumeShape.STBuffer(this.Width);
                }

                return _RenderedVolumeShape;
            }
        }
        
        public SqlGeometry VolumeShape
        {
            get { return this.modelObj.VolumeShape; }
        }
    }
}
