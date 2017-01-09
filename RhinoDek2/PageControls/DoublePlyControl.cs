using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RhinoDek2.Classes;
using Telerik.WinControls.UI;

namespace RhinoDek2.PageControls
{
    public partial class DoublePlyControl : UserControl
    {
        public DoublePlyControl()
        {
            InitializeComponent();
            LoadEdgeStyle();
            LoadAdhesion();
            LoadTextures();
            LoadTopColors();
            LoadBottomColors();
            LoadLogoStyles();

            ReadStaticData();

            
        }

        #region LoadCombos

        //Load Edge Styles\\
        private void LoadEdgeStyle()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select edge_style from edge_styles");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["edge_style"].ToString());
                    comboEdgeStyle.Items.Add(item);
                }
            }
        }

        //Load Adhesion\\
        private void LoadAdhesion()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select adhesion from adhesions");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["adhesion"].ToString());
                    comboAdhesion.Items.Add(item);
                }
            }
        }

        //Load Logo Styles\\
        private void LoadLogoStyles()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select Logo_Style from Logo_Styles");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["Logo_Style"].ToString());
                    comboLogoStyle.Items.Add(item);
                }
            }
        }

        //Load Textures\\
        private void LoadTextures()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select texture from textures");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["texture"].ToString());
                    comboTexture.Items.Add(item);
                }
            }
        }

        //Load Top Color\\
        private void LoadTopColors()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select color_name from sheet_colors");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["color_name"].ToString());
                    comboTopColor.Items.Add(item);
                }
            }

        }

        // Load Bottom Color\\
        private void LoadBottomColors()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select color_name from sheet_colors");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["color_name"].ToString());
                    comboBottomColor.Items.Add(item);
                }
            }
        }

        #endregion

        // Read Static Data, if any \\
        private void ReadStaticData()
        {

            if (!Classes.StaticData.DoublePly)
            {
                return;
            }

            try
            {
                comboTexture.Text = StaticData.Texture;
                comboTopColor.Text = StaticData.TopSheetColor;
                comboBottomColor.Text = StaticData.BottomSheetColor;
                tbTopSheetMM.Text = StaticData.TopSheetMM.ToString();
                tbBottomSheetMM.Text = StaticData.BottomSheetMM.ToString();
                tbOverallMM.Text = StaticData.OverallMM.ToString();
                
            }
            catch (Exception ex)
            {

                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Error";
                alert.ContentText = "There were empty fields in the static data class.";
                alert.Show();
            }


        }

        private void comboAdhesion_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Classes.StaticData.Adhesion = comboAdhesion.Text;
        }

        private void comboLogoStyle_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            StaticData.LogoStyle = comboLogoStyle.Text;
        }

        private void comboEdgeStyle_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            StaticData.EdgeStyle = comboEdgeStyle.Text;
        }

        private void comboTexture_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            StaticData.Texture = comboTexture.Text;
        }

        private void comboTopColor_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            StaticData.TopSheetColor = comboTopColor.Text;
        }

        private void comboBottomColor_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            StaticData.BottomSheetColor = comboBottomColor.Text;
        }

        private void radTextBoxControl4_TextChanged(object sender, EventArgs e)
        {
            StaticData.ColorLaminateStyle = radTextBoxControl4.Text;
        }

        private void tbTopSheetMM_TextChanged(object sender, EventArgs e)
        {
            StaticData.TopSheetMM = Convert.ToInt32(tbTopSheetMM.Text);
        }

        private void tbBottomSheetMM_TextChanged(object sender, EventArgs e)
        {
            StaticData.BottomSheetMM = Convert.ToInt32(tbBottomSheetMM.Text);
        }

        private void tbOverallMM_TextChanged(object sender, EventArgs e)
        {
            StaticData.OverallMM = Convert.ToInt32(tbOverallMM.Text);
        }
    }
}
