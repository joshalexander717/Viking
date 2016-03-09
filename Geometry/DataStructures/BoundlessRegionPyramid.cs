﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace Geometry
{
    public class BoundlessRegionPyramidLevel<T> : IRegionPyramidLevel<T> where T : class
    {
        public ConcurrentDictionary<GridIndex, T> Cells = new ConcurrentDictionary<GridIndex, T>();

        public readonly GridCellDimensions UnscaledCellDimensions;
        public readonly GridCellDimensions ScaledCellDimensions;

        private readonly int _Level;

        public int Level
        {
            get
            {
                return _Level;
            }
        }

        private readonly double _MinRadius;

        public double MinRadius
        {
            get { return _MinRadius; }
        }
        
        private static T GetCell(ConcurrentDictionary<GridIndex, T> Cells, GridIndex key)
        {
            T Result;
            if (Cells.TryGetValue(key, out Result))
                return Result;
            return null;
        }

        public T GetOrAddCell(GridIndex key, Func<GridIndex, T> valueFactory)
        {
            return Cells.GetOrAdd(key, valueFactory);
        }

        public T AddOrUpdateCell(GridIndex key, T addValue, Func<GridIndex, T, T> updateFunction)
        {
            return Cells.AddOrUpdate(key, addValue, updateFunction);
        }

        public T AddOrUpdateCell(GridIndex key, Func<GridIndex, T> addFunction, Func<GridIndex, T, T> updateFunction)
        {
            return Cells.AddOrUpdate(key, addFunction, updateFunction);
        }

        public bool TryUpdateCell(GridIndex key, T value, T comparisonValue)
        {
            return Cells.TryUpdate(key, value, comparisonValue);
        }

        public BoundlessRegionPyramidLevel(int Level, GridCellDimensions UnscaledCellDim)
        {
            this._Level = Level;

            double TwoToTheLevel = Math.Pow(2.0, (double)Level);
            this._MinRadius = TwoToTheLevel;

            this.UnscaledCellDimensions = UnscaledCellDim;
            this.ScaledCellDimensions = new GridCellDimensions(TwoToTheLevel * UnscaledCellDim.Width,
                                                               TwoToTheLevel * UnscaledCellDim.Height);
        }

        public T[] ArrayForRegion(GridRectangle volumeBounds)
        {
            GridIndicies iGrid = GridIndicies.FromRectangle(volumeBounds, ScaledCellDimensions);
            return BoundlessRegionPyramidLevel<T>.ToArray(Cells, iGrid);
        }

        public GridRange<T> SubGridForRegion(GridRectangle volumeBounds)
        {
            GridIndicies iGrid = GridIndicies.FromRectangle(volumeBounds, this.ScaledCellDimensions);
            return BoundlessRegionPyramidLevel<T>.ToSubGrid(Cells, iGrid);
        }

        public static T[] ToArray(ConcurrentDictionary<GridIndex, T> grid, GridIndicies iGrid)
        {
            T[] output = new T[iGrid.NumberOfCells];
            int i = 0;
            for (int iY = iGrid.iMinY; iY < iGrid.iMaxY; iY++)
            {
                for (int iX = iGrid.iMinX; iX < iGrid.iMaxX; iX++)
                {
                    output[i++] = GetCell(grid ,new GridIndex(iX, iY));
                }
            }

            return output;
        }

        public static GridRange<T> ToSubGrid(ConcurrentDictionary<GridIndex, T> grid, GridIndicies iGrid)
        {
            T[,] output = new T[iGrid.Width, iGrid.Height];
            int i = 0;
            for (int iY = iGrid.iMinY; iY < iGrid.iMaxY; iY++)
            {
                for (int iX = iGrid.iMinX; iX < iGrid.iMaxX; iX++)
                {
                    output[iX - iGrid.iMinX, iY - iGrid.iMinY] = GetCell(grid, new GridIndex(iX, iY));
                }
            }

            return new GridRange<T>(output, iGrid);
        }

        public GridRectangle CellBounds(int iX, int iY)
        {
            return new GridRectangle(new GridVector2(iX * ScaledCellDimensions.Width, iY * ScaledCellDimensions.Height),
                                      ScaledCellDimensions.Width, ScaledCellDimensions.Height);
        }
    }

    public interface IRegionPyramid<T> where T : class
    {
        IRegionPyramidLevel<T> GetLevel(double SinglePixelRadius);
    }

    /// <summary>
    /// Divides a volume up into a grid of evenly sized cells.  Query a region to determine which cells are visible
    /// 
    /// Level 0 -> Region Area = Cell Area * 2^0
    /// Level 1 -> Region Area = Cell Area * 2^1
    /// Level N -> Region Area = Cell Area * 2^N
    /// 
    /// Volume Size Screen Size Visible Bounds  Single Pixel Annotation Size    Level   Grid Cell Size
    /// ?           64          512             1                               0       1024
    ///             64          1024            1                               0       1024
    ///             64          2048            2                               1       1024
    ///             64          4096            4                               2       1024
    /// The Pyramid cannot scale to arbitrarily high resolution beyond the cell size, however the 
    /// boundaries are not required to be known
    /// 
    /// </summary>
    public class BoundlessRegionPyramid<T> : IRegionPyramid<T> where T : class
    {
        /// <summary>
        /// Width & Height of a grid cell in the RegionPyramid
        /// </summary>
        public GridCellDimensions CellDimensions;

        ConcurrentDictionary<int, BoundlessRegionPyramidLevel<T>> Levels = new ConcurrentDictionary<int, BoundlessRegionPyramidLevel<T>>();

        public static double FloorToPowerOfTwo(double value)
        {
            return Math.Pow(Math.Floor(Math.Log(value, 2)), 2);
        }

        public BoundlessRegionPyramid(GridCellDimensions cellDimensions)
        {  
            //Level 0 cell dimensions match the boundary dimensions
            CellDimensions = cellDimensions;//new GridCellDimensions(Boundaries.Width, Boundaries.Height); 
        }

        protected BoundlessRegionPyramidLevel<T> GetOrAddLevel(int Level)
        {
            return this.Levels.GetOrAdd(Level, new BoundlessRegionPyramidLevel<T>(Level, this.CellDimensions));
        }

        private double MinRadiusForLevel(GridRectangle screenBounds, int Level)
        {
            return Math.Pow(2.0, Level);
        }

        private int LevelForPixelSizeInVolumeSpace(double SinglePixelRadius)
        {
            int Level = (int)Math.Floor(Math.Log(SinglePixelRadius, 2));
            if (Level < 0)
                Level = 0;
            return Level; 
        }

        public IRegionPyramidLevel<T> GetLevel(double SinglePixelRadius)
        {
            int Level = LevelForPixelSizeInVolumeSpace(SinglePixelRadius);

            return GetOrAddLevel(Level);
        } 
    } 
}
