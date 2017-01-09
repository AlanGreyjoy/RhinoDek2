using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RhinoDek2.PageControls
{
    public partial class SinglePly : UserControl
    {
        public SinglePly()
        {
            InitializeComponent();
            LoadColors();
            LoadTextures();
            LoadAdhesion();
            LoadEdgeStyle();
            LoadLogoStyles();

        }

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

        //Load Colors\\
        private void LoadColors()
        {
            DataTable dt = Classes.SQLHelper.GetTable("select color_name from sheet_colors");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string item = (dr["color_name"].ToString());
                    comboColor.Items.Add(item);
                }
            }

        }


    }
}
