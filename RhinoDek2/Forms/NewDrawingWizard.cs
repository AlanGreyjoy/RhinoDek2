using Rhino;
using RhinoDek2.Properties;
using RhinoScript4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RhinoDek2.Forms
{
    public partial class NewDrawingWizard : Telerik.WinControls.UI.ShapedForm
    {
        private string folderPrefix;
        private string seaDekPartNumber;
        private string colorSuffix;
        private string tenDigitPN;
        private string fiveDigitPN;
        private string drawingPath;

        private bool pathExists = false;

        private Color originalBorderColor;

        private int sheetPlySetting;

        IRhinoScript rs;

        public NewDrawingWizard()
        {
            InitializeComponent();
            LoadThicknessCombo();
            LoadWizard();

            originalBorderColor = tbPartNumber.TextBoxElement.BorderColor;

            object obj = RhinoApp.GetPlugInObject("RhinoScript");
            rs = (IRhinoScript)obj;
        }



        //Load Wizard\\
        void LoadWizard()
        {
            radWizard.Cancel += new EventHandler(Cancel_Button_Clicked);

            //Load Manufacture Combo Box\\
            if (Directory.Exists("//surfer/cad/"))
            {
                foreach (string folder in Classes.StaticData.CAD_Folders)
                {
                    String item;
                    item = folder.Substring(13);
                    comboManufacture.Items.Add(item);
                }
            }

        }

        //Load Thickness Combobox\\
        private void LoadThicknessCombo()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select MM from Thicknesses");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    String item = (dr["MM"].ToString());
                    comboThickness.Items.Add(item);
                }
            }
        }

        //Cancel Button Click\\
        private void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        // Changed Combo Sheet Ply \\
        private void comboSheetPly_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (comboSheetPly.Text.Length > 0)
            {
                if (comboSheetPly.Text == "Single Ply")
                {
                    Classes.StaticData.SinglePly = true;
                    Classes.StaticData.DoublePly = false;
                    Classes.StaticData.TripplePly = false;

                    PageControls.SinglePly singlePly = new PageControls.SinglePly();
                    singlePly.Dock = DockStyle.Fill;
                    panelBOM.Controls.Clear();
                    panelBOM.Controls.Add(singlePly);
                    
                }
                if (comboSheetPly.Text == "Double Ply")
                {
                    Classes.StaticData.SinglePly = false;
                    Classes.StaticData.DoublePly = true;
                    Classes.StaticData.TripplePly = false;

                    PageControls.DoublePlyControl doublePly = new PageControls.DoublePlyControl();
                    doublePly.Dock = DockStyle.Fill;
                    panelBOM.Controls.Clear();
                    panelBOM.Controls.Add(doublePly);
                }
                if (comboSheetPly.Text == "Tripple Ply")
                {
                    Classes.StaticData.SinglePly = false;
                    Classes.StaticData.DoublePly = false;
                    Classes.StaticData.TripplePly = true;

                    RadDesktopAlert alert = new RadDesktopAlert();
                    alert.CaptionText = "RhinoDek Info";
                    alert.ContentText = "There is no control for Tripple Ply yet.";
                    alert.Show();
                }
            }
        }

        // Part Number Text Changed \\
        private void tbPartNumber_TextChanged(object sender, EventArgs e)
        {
            string folderPrefix;
            string seaDekPartNumber;
            string colorSuffix;

            if (tbPartNumber.Text.IndexOf("TBD") != -1 )
            {
                Classes.StaticData.IsTBD = true;
                tbPartNumber.TextBoxElement.BorderColor = Color.Green;
            }
            else
            {
                Classes.StaticData.IsTBD = false;
            }

            if (tbPartNumber.TextLength > 0)
            {
                // Get folder name \\
                if (tbPartNumber.TextLength == 5)
                {
                    folderPrefix = tbPartNumber.Text.Substring(2, 3);

                    DataTable dt = Classes.SQLHelper.GetTable(string.Format("select Name from Project_Folders where Prefix like '{0}'", folderPrefix));
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        comboManufacture.Text = (dr["Name"].ToString());
                    }
                }

                // Get SeaDek Part Number & Check if folder exists \\
                if (tbPartNumber.Text.Length == 11)
                {
                    if (Directory.Exists(string.Format(@"\\surfer\cad\{0}\{1}\", comboManufacture.Text, tbPartNumber.Text)))
                    {
                        pathExists = true;
                        tbPartNumber.TextBoxElement.BorderColor = Color.Red;
                        return;
                    }
                    tbPartNumber.TextBoxElement.BorderColor = Color.Green;
                    pathExists = false;
                    fiveDigitPN = tbPartNumber.Text;
                    seaDekPartNumber = fiveDigitPN.Substring(6, 5);
                    tbSeaDekPartNumber.Text = seaDekPartNumber;
                }

                // Get ALL TEXT and inspect them \\
                if (tbPartNumber.Text.Length == 17)
                {
                    colorSuffix = tbPartNumber.Text.Substring(12, 5);
                    tenDigitPN = tbPartNumber.Text;
                    string newStr = tbPartNumber.Text.Substring(0, 11);
                    Classes.StaticData.ColorSuffix = colorSuffix;

                    if (Directory.Exists(string.Format(@"\\surfer\cad\{0}\{1}\", comboManufacture.Text, newStr)))
                    {
                        pathExists = true;
                        return;
                    }

                    tbPartNumber.TextBoxElement.BorderColor = Color.Green;
                    pathExists = false;
                    DataTable dt = Classes.SQLHelper.GetTable(string.Format("select * from SinglePly where ColorSuffix like {0}", colorSuffix));
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Classes.StaticData.OneSheetColor = (dr["TopSheetColor"].ToString());
                        Classes.StaticData.OneSheetMM = (Convert.ToInt32(dr["TopSheetMM"]));
                        Classes.StaticData.OverallMM = (Convert.ToInt32(dr["MM"]));
                        Classes.StaticData.Texture = (dr["Texture"].ToString());
                        Classes.StaticData.SinglePly = true;
                    }
                    dt.Clear();
                    dt = Classes.SQLHelper.GetTable(string.Format("select * from DoublePly where ColorSuffix like {0}", colorSuffix));
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Classes.StaticData.Texture = (dr["Texture"].ToString());
                        Classes.StaticData.TopSheetColor = (dr["TopSheetColor"].ToString());
                        Classes.StaticData.BottomSheetColor = (dr["BottomSheetColor"].ToString());
                        Classes.StaticData.OverallMM = (Convert.ToInt32(dr["MM"]));
                        Classes.StaticData.TopSheetMM = (Convert.ToInt32(dr["TopSheetMM"]));
                        Classes.StaticData.BottomSheetMM = (Convert.ToInt32(dr["BottomSheetMM"]));
                        Classes.StaticData.DoublePly = true;
                    }
                    dt.Clear();
                    dt = Classes.SQLHelper.GetTable(string.Format("select * from TripplePly where ColorSuffix like {0}", colorSuffix));
                    if (dt.Rows.Count > 0)
                    {
                        Classes.StaticData.TripplePly = true;
                    }
                }
            }
        }

        // Next Button Clicked \\
        private void radWizard_Next(object sender, WizardCancelEventArgs e)
        {
            if (tbPartNumber.TextLength == 11)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Error";
                alert.ContentText = "You must enter either TBD or a color suffix";
                alert.Show();
                return;
            }

            if (pathExists)
            {
                
                e.Cancel = true;
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek File Error";
                alert.ContentText = "The drawing " + tbPartNumber.Text + " is already created.";
                alert.Show();
                return;
            }

            if (Classes.StaticData.IsTBD)
            {
                Classes.StaticData.Texture = "TBD";
                Classes.StaticData.TopSheetColor = "TBD";
                Classes.StaticData.MiddleSheetColor = "TBD";
                Classes.StaticData.BottomSheetColor = "TBD";
            }
            else
            {
                if (radWizard.SelectedPage == radWizard.Pages[0])
                {
                    if (Classes.StaticData.SinglePly)
                    {
                        comboThickness.Text = Classes.StaticData.OverallMM.ToString();
                        comboSheetPly.Text = "Single Ply";

                        PageControls.SinglePly singlePly = new PageControls.SinglePly();
                        singlePly.Dock = DockStyle.Fill;
                        panelBOM.Controls.Clear();
                        panelBOM.Controls.Add(singlePly);
                    }
                    if (Classes.StaticData.DoublePly)
                    {
                        comboThickness.Text = Classes.StaticData.OverallMM.ToString();
                        comboSheetPly.Text = "Double Ply";

                        PageControls.DoublePlyControl doublePly = new PageControls.DoublePlyControl();
                        doublePly.Dock = DockStyle.Fill;
                        panelBOM.Controls.Clear();
                        panelBOM.Controls.Add(doublePly);
                    }
                    if (Classes.StaticData.TripplePly)
                    {
                        comboThickness.Text = Classes.StaticData.OverallMM.ToString();
                        comboSheetPly.Text = "Tripple Ply";

                        RadDesktopAlert alert = new RadDesktopAlert();
                        alert.CaptionText = "RhinoDek Info";
                        alert.ContentText = "There is no control for Tripple Ply yet.";
                        alert.Show();
                    }

                }
                //Check Drawing Page\\
                if (this.radWizard.SelectedPage == radWizard.Pages[1])
                {
                    
                    if (Classes.StaticData.SinglePly)
                    {

                    }
                    if (Classes.StaticData.DoublePly)
                    {
                        lblBomCheckDetails.Text = string.Format("Texture: {0}" + Environment.NewLine +
                            "Top Sheet Thickness: {1}" + Environment.NewLine +
                            "Bottom Sheet Thickness: {2}" + Environment.NewLine +
                            "Overall Thickness: {3}" + Environment.NewLine +
                            "Top Sheet Color: {4}" + Environment.NewLine +
                            "Bottom Sheet Color: {5}" + Environment.NewLine +
                            "Adhesion: {6}" + Environment.NewLine +
                            "Logo Style: {7}" + Environment.NewLine +
                            "Edge Style: {8}" + Environment.NewLine +
                            Environment.NewLine,
                            Classes.StaticData.Texture,
                            Classes.StaticData.TopSheetMM.ToString(),
                            Classes.StaticData.BottomSheetMM.ToString(),
                            Classes.StaticData.OverallMM.ToString(),
                            Classes.StaticData.TopSheetColor,
                            Classes.StaticData.BottomSheetColor,
                            Classes.StaticData.Adhesion,
                            Classes.StaticData.LogoStyle,
                            Classes.StaticData.EdgeStyle
                            );

                        lblPartNumberDetails.Text = tenDigitPN;
                        lblDrawingPathDetails.Text = string.Format(@"\\surfer\cad\{0}\{1}\REV000\", comboManufacture.Text, fiveDigitPN);
                        lblCNCPathDetails.Text = string.Format(@"\\surfer\cnc\{0}\{1}\",comboManufacture.Text, fiveDigitPN);
                    }
                }
                //Create Drawing Page\\
                if (radWizard.SelectedPage == radWizard.Pages[2])
                {
                    if (Directory.Exists(string.Format(@"\\surfer\cad\{0}\{1}\", comboManufacture.Text, fiveDigitPN)))
                    {
                        MessageBox.Show(this, "This directory all ready exists!", "File Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CreateDrawing();
                }
            }
        }

        // Finish Button Clicked \\
        private void radWizard_Finish(object sender, EventArgs e)
        {
            
        }






        // Create Drawing \\
        private void CreateDrawing()
        {
            String pdfPath;
            String filePath;
            String documentData = "Drawing_Info";

            Object[] getPVBOMPoint = rs.ObjectsByName("BOM PART VIEW POINT");
            Object[] getTVBOMPoint = rs.ObjectsByName("BOM TABLE VIEW POINT");
            Object pvPointCoor = rs.PointCoordinates(getPVBOMPoint[0]);
            Object tvPointCoor = rs.PointCoordinates(getTVBOMPoint[0]);

            progressBar.Text = "Creating Drawing..";

            //pdf path\\
            if (Classes.StaticData.IsTBD)
            {
                pdfPath = String.Format(@"\\surfer\cnc\{0}\{1}\", comboManufacture.Text, fiveDigitPN);
            }
            else
            {
                pdfPath = String.Format(@"\\surfer\cnc\{0}\{1}\{2}\", comboManufacture.Text, fiveDigitPN, tenDigitPN);
            }
            filePath = String.Format(@"\\surfer\cad\{0}\{1}\REV000\", comboManufacture.Text, fiveDigitPN);

            Directory.CreateDirectory(filePath);
            Directory.CreateDirectory(pdfPath);

            progressBar.Text = "Saving and Formating files...";
            RhinoApp.RunScript(String.Format("_-Saveas {0}", filePath+fiveDigitPN), false);

            //---------------Ply Areas----------------\\
            //Single Ply\\
            if (Classes.StaticData.SinglePly)
            {
                rs.SetDocumentData(documentData, "Overall_Sheet_Ply", Classes.StaticData.OverallMM);
                rs.SetDocumentData(documentData, "Drawing_Folder", comboManufacture.Text);
                rs.SetDocumentData(documentData, "Drawing_Name", fiveDigitPN);
                rs.SetDocumentData(documentData, "Color_Suffix", Classes.StaticData.ColorSuffix);
                rs.SetDocumentData(documentData, "Sheet_Color", Classes.StaticData.OneSheetColor);
                rs.SetDocumentData(documentData, "Texture", Classes.StaticData.Texture);

                progressBar.Text = "Inserting Blocks...";

                object pvBlock = rs.InsertBlock("ONE SHEET BOM", pvPointCoor);
                object tbBlock = rs.InsertBlock("ONE SHEET BOM", tvPointCoor);
                rs.Command("_Explode");
                rs.UnselectAllObjects();

                //Getting drawing objects\\
                object boatmake = rs.ObjectsByName("BOAT MAKE");
                object boatModel = rs.ObjectsByName("BOAT MODEL");
                object custPartName = rs.ObjectsByName("PV - CUSTOMER PART NAME");
                object seadekPN = rs.ObjectsByName("SEADEK PART NUMBER");
                object overallMMobject = rs.ObjectsByName("OVERALL MM INT");
                object textureObject = rs.ObjectsByName("TEXTURE");
                object logoStyleObject = rs.ObjectsByName("LOGO STYLE");
                object edgeStyleObject = rs.ObjectsByName("EDGE STYLE");
                object adhesionObject = rs.ObjectsByName("ADHESION");


            }
            
            //Double Ply\\
            if (Classes.StaticData.DoublePly)
            {
                rs.SetDocumentData(documentData, "Overall_Sheet_Ply", Classes.StaticData.OverallMM);
                rs.SetDocumentData(documentData, "Drawing_Folder", comboManufacture.Text);
                rs.SetDocumentData(documentData, "Drawing_Name", fiveDigitPN);
                rs.SetDocumentData(documentData, "Color_Suffix", Classes.StaticData.ColorSuffix);
                rs.SetDocumentData(documentData, "Top_Sheet_Color", Classes.StaticData.TopSheetColor);
                rs.SetDocumentData(documentData, "Bottom_Sheet_Color", Classes.StaticData.BottomSheetColor);
                rs.SetDocumentData(documentData, "Texture", Classes.StaticData.Texture);

                progressBar.Text = "Inserting blocks and formatting text...";

                object boatmake = rs.ObjectsByName("BOAT MAKE");
                object boatModel = rs.ObjectsByName("BOAT MODEL");
                object custPartName = rs.ObjectsByName("PV - CUSTOMER PART NAME");
                object seadekPN = rs.ObjectsByName("SEADEK PART NUMBER");
                object overallMMobject = rs.ObjectsByName("OVERALL MM INT");
                object textureObject = rs.ObjectsByName("TEXTURE");
                object topSheetMMObject = rs.ObjectsByName("TOP SHEET MM INT");
                object bottomSheetMMObject = rs.ObjectsByName("BOTTOM SHEET MM INT");
                object logoStyleObject = rs.ObjectsByName("LOGO STYLE");
                object edgeStyleObject = rs.ObjectsByName("EDGE STYLE");
                object adhesionObject = rs.ObjectsByName("ADHESION");
            }

            //Tripple Ply\\
            if (Classes.StaticData.TripplePly)
            {
                rs.SetDocumentData(documentData, "Overall_Sheet_Ply", Classes.StaticData.OverallMM);
                rs.SetDocumentData(documentData, "Drawing_folder", comboManufacture.Text);
                rs.SetDocumentData(documentData, "Drawing_Name", fiveDigitPN);
                rs.SetDocumentData(documentData, "Color_Suffix", Classes.StaticData.ColorSuffix);
                rs.SetDocumentData(documentData, "Top_Sheet_Color", Classes.StaticData.TopSheetColor);
                rs.SetDocumentData(documentData, "Middle_Sheet_Color", Classes.StaticData.MiddleSheetColor);
                rs.SetDocumentData(documentData, "Bottom_Sheet_Color", Classes.StaticData.BottomSheetColor);
                rs.SetDocumentData(documentData, "Texture", Classes.StaticData.Texture);
            }


        }

    }

    public class GetDrawingObject
    {
        enum SheetPly
        {
            Single,
            Double,
            Tripple
        };

        public void GetAllObjects(Enum SheetPly)
        {

        }
    }
}
