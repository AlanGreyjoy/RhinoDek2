using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls.UI;

namespace RhinoDek2.Pages
{
    public partial class Database : UserControl
    {
        public Database()
        {
            InitializeComponent();
            LoadDatabase_Items();

        }

        private void LoadDatabase_Items()
        {
            sheet_ColorsTableAdapter.Fill(rhinoDekDataSet.Sheet_Colors);
            texturesTableAdapter.Fill(rhinoDekDataSet.Textures);
            thicknessesTableAdapter1.Fill(rhinoDekDataSet.Thicknesses);
            oITMTableAdapter.Fill(seaDekDataSet.OITM);
            edge_StylesTableAdapter.Fill(rhinoDekDataSet.Edge_Styles);
            adhesionsTableAdapter.Fill(rhinoDekDataSet.Adhesions);
            logo_StylesTableAdapter.Fill(rhinoDekDataSet.Logo_Styles);
            doublePlyTableAdapter.Fill(rhinoDekDataSet.DoublePly);
            project_FoldersTableAdapter.Fill(rhinoDekDataSet.Project_Folders);
        }

        #region BOM tabs
        // Added Thickness \\
        private void gridThicknesses_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                thicknessesBindingSource.EndEdit();
                thicknessesTableAdapter1.Update(rhinoDekDataSet.Thicknesses);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Thickness added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Deleted Thickness \\
        private void gridThicknesses_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                thicknessesBindingSource.EndEdit();
                thicknessesTableAdapter1.Update(rhinoDekDataSet.Thicknesses);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Thickness removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Added Texture \\
        private void gridTextures_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                texturesBindingSource.EndEdit();
                texturesTableAdapter.Update(rhinoDekDataSet.Textures);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Texture has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Removed Texture \\
        private void gridTextures_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                texturesBindingSource.EndEdit();
                texturesTableAdapter.Update(rhinoDekDataSet.Textures);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Texture has been removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Added Color \\
        private void gridColors_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                sheetColorsBindingSource.EndEdit();
                sheet_ColorsTableAdapter.Update(rhinoDekDataSet.Sheet_Colors);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Sheet color has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Removed Color \\
        private void gridColors_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                sheetColorsBindingSource.EndEdit();
                sheet_ColorsTableAdapter.Update(rhinoDekDataSet.Sheet_Colors);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Sheet Color has been removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Added Logo Style \\
        private void radGridView2_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                logo_StylesBindingSource.EndEdit();
                logo_StylesTableAdapter.Update(rhinoDekDataSet.Logo_Styles);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Logo Style has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Removed Logo Style \\
        private void radGridView2_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                logo_StylesBindingSource.EndEdit();
                logo_StylesTableAdapter.Update(rhinoDekDataSet.Logo_Styles);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Logo Style has been removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Added Edge Style \\
        private void gridEdgeStyle_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                edgeStylesBindingSource.EndEdit();
                edge_StylesTableAdapter.Update(rhinoDekDataSet.Edge_Styles);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Edge Style has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Removed Edge Style \\
        private void gridEdgeStyle_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                edgeStylesBindingSource.EndEdit();
                edge_StylesTableAdapter.Update(rhinoDekDataSet.Edge_Styles);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Edge Style has been removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Added Adhesion \\
        private void MasterTemplate_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                adhesionsBindingSource.EndEdit();
                adhesionsTableAdapter.Update(rhinoDekDataSet.Adhesions);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Adhesion has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Removed Adhesion \\
        private void MasterTemplate_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                adhesionsBindingSource.EndEdit();
                adhesionsTableAdapter.Update(rhinoDekDataSet.Adhesions);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Adhesion has been removed from to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }
        #endregion

        #region SeaDek Colors Tab


        #endregion

        // Add Double Ply \\
        private void gridDoublePly_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                doublePlyBindingSource.EndEdit();
                doublePlyTableAdapter.Update(rhinoDekDataSet.DoublePly);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "New Double Ply Sheet has been added to the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Remove Double Ply \\
        private void gridDoublePly_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Validate();
                doublePlyBindingSource.EndEdit();
                doublePlyTableAdapter.Update(rhinoDekDataSet.DoublePly);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Sheet has been removed from the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }

        // Double Ply Sheet Updated \\
        private void gridDoublePly_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Validate();
                doublePlyBindingSource.EndEdit();
                doublePlyTableAdapter.Update(rhinoDekDataSet.DoublePly);
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "Sheet has been updated in the database";
                alert.Show();
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Info";
                alert.ContentText = "There was a problem with the server!" + Environment.NewLine +
                    ex.Message;
                alert.Show();
            }
        }


    }
}
