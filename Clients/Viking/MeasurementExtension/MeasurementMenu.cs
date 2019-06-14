﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIMeasurement;

using System.Diagnostics;

namespace MeasurementExtension
{
    [Viking.Common.MenuAttribute("Measurement")]
    class MeasurementMenu
    {
        [Viking.Common.MenuItem("Set Scale")]
        static public void OnMenuSetScale(object sender, EventArgs e)
        {
            Debug.Print("Set Scale");

            using (ScaleForm form = new ScaleForm(Global.UnitOfMeasure.ToString(), Global.UnitsPerPixel))
            {

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Global._UnitsPerPixel = form.UnitsPerPixel;
                    Global._UnitOfMeasure = (SILengthUnits)Enum.Parse(typeof(SILengthUnits), form.UnitsOfMeasure);
                }
            }
        }

        [Viking.Common.MenuItem("Show Scale Bar")]
        static public void OnMenuShowScaleBar(object sender, EventArgs e)
        {
            Debug.Print("Show Scale Bar");

            Measurement.Properties.Settings.Default.ShowScaleBar = !Measurement.Properties.Settings.Default.ShowScaleBar;
            Measurement.Properties.Settings.Default.Save();
        }

        [Viking.Common.MenuItem("Measure Line")]
        static public void OnMenuMeasureLine(object sender, EventArgs e)
        {
            Debug.Print("Measure Line");

            var menuItem = sender as System.Windows.Forms.ToolStripItem;
            Viking.UI.Controls.SectionViewerControl viewer = menuItem.GetCurrentParent().Parent as Viking.UI.Controls.SectionViewerControl;
             
            viewer.CommandQueue.EnqueueCommand(typeof(MeasureCommand));
        } 
    }
}
