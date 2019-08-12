﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viking.Common;
using System.Diagnostics;
using System.Windows.Forms;
using WebAnnotation.UI;

namespace WebAnnotation
{
    [MenuAttribute("Annotation")]
    class AnnotationMenu : Viking.Common.IMenuFactory
    {
        static FindStructureNumberForm _FindStructureNumberForm = null;
        static MergeStructuresForm _MergeStructuresForm = null;

        static ToolStripMenuItem menuPenMode;

        System.Windows.Forms.ToolStripItem Viking.Common.IMenuFactory.CreateMenuItem()
        {
            //Create a menu containing each of our bookmarks
            ToolStripMenuItem menuRoot = new ToolStripMenuItem("Annotation");

            if (Global.Export != null)
            {
                //Create the option to hide bookmarks on the display
                ToolStripMenuItem menuExport = new ToolStripMenuItem("Export");

                //Create the option to hide bookmarks on the display
                ToolStripMenuItem menuExportMotifs = new ToolStripMenuItem("Motifs");

                ToolStripMenuItem menuExportMotifTLP = new ToolStripMenuItem("To Tulip Format");
                menuExportMotifTLP.Click += OnExportMotifsTLP;

                menuPenMode = new ToolStripMenuItem("Pen Mode");
                menuPenMode.Checked = WebAnnotation.Global.PenMode;
                menuPenMode.Click += OnPenMode;


                menuExportMotifs.DropDownItems.Add(menuExportMotifTLP);
                menuExport.DropDownItems.Add(menuExportMotifs);
                menuRoot.DropDownItems.Add(menuExport);
                menuRoot.DropDownItems.Add(menuPenMode);
            }

            return menuRoot as ToolStripItem; 
        }

        static public void OnExportMotifsTLP(object sender, EventArgs e)
        {
            Debug.Print("OnExportMotifsTLP");

            Global.Export.OpenMotif();
        }

        [MenuItem("Show Pen Input Window")]
        static public void OnShowPenInputWindow(object sender, EventArgs e)
        {
            Debug.Print("OnShowPenInputWindow");

            if(Global.PenAnnotationForm == null || Global.PenAnnotationForm.IsDisposed)
            {
                Global.PenAnnotationForm = new UI.Forms.PenAnnotationViewForm(Viking.UI.State.ViewerForm.Section);
                Global.PenAnnotationForm.Show();
            }
            else
            {
                Global.PenAnnotationForm.Visible = !Global.PenAnnotationForm.Visible;
            }
        }

        [MenuItem("Open Last Modified Location")]
        static public void GoToLastModifiedLocation(object sender, EventArgs e)
        {
            AnnotationOverlay.GotoLastModifiedLocation();
        }
          
        static public void OnPenMode(object sender, EventArgs e)
        {
            Global.PenMode = !Global.PenMode;
            menuPenMode.Checked = Global.PenMode;
        }

        [MenuItem("Open Structure")]
        static public void ShowStructure(object sender, EventArgs e)
        {
            Debug.Print("Show Structure");

            if (_FindStructureNumberForm == null)
            {
                _FindStructureNumberForm = new FindStructureNumberForm();
            }
            else if (_FindStructureNumberForm.IsDisposed)
            {
                _FindStructureNumberForm = new FindStructureNumberForm();
            }

            _FindStructureNumberForm.Show();
            _FindStructureNumberForm.Focus(); 
        }

        [MenuItem("Goto Structure")]
        static public void GotoStructure(object sender, EventArgs e)
        {
            Debug.Print("Goto Structure");

            WebAnnotation.AnnotationOverlay.CurrentOverlay.OpenGotoStructureForm();
        }

        [MenuItem("Goto Location")]
        static public void GotoLocation(object sender, EventArgs e)
        {
            Debug.Print("Goto Location");

            WebAnnotation.AnnotationOverlay.CurrentOverlay.OpenGotoLocationForm();
        }

        [MenuItem("Merge Structures")]
        static public void MergeStructures(object sender, EventArgs e)
        {
            Debug.Print("Merge Structures");

            if (_MergeStructuresForm == null)
            {
                _MergeStructuresForm = new MergeStructuresForm();
            }
            else if (_MergeStructuresForm.IsDisposed)
            {
                _MergeStructuresForm = new MergeStructuresForm();
            }

            _MergeStructuresForm.ShowDialog();
            _MergeStructuresForm.Focus();
        }

        [MenuItem("Export")]
        static public void Export(object sender, EventArgs e)
        {
            Debug.Print("Export");

            
        }

       
    }
}
