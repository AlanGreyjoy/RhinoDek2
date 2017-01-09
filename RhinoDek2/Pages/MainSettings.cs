using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using RhinoDek2.Classes;
using Telerik.WinControls;
using System.Diagnostics;
using Telerik.WinControls.Layouts;
using System.Drawing.Printing;

namespace RhinoDek2.Pages
{
    public partial class MainSettings : UserControl
    {
        private MainSettingsFile settings = new MainSettingsFile();

        public MainSettings()
        {
            InitializeComponent();
            LoadPage();
        }

        //Load all page settings and boxes\\
        private void LoadPage()
        {
            //Load Theme Name\\
            if (settings.Store_Theme_Name.Length > 0)
            {
                comboTheme.Text = settings.Store_Theme_Name;
            }
            else
            {
                comboTheme.Text = "Change Theme";
            }
            //Load Font Color\\
            if (settings.Title_Font_Color != Color.Gray)
            {
                lblCurrentColor.Text = settings.Title_Font_Color.Name;
            }
            //Load Title Font Family\\
            if (settings.Tile_Font_Family != null)
            {
                lblCurrentFont.Text = settings.Tile_Font_Family.Name;
            }
            //Load Printer Combo\\
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                RadMenuItem item = new RadMenuItem();
                item.Text = printer;
                comboPaperPrinter.Items.Add(item);
            }
            foreach (string printer2 in PrinterSettings.InstalledPrinters)
            {
                RadMenuItem item2 = new RadMenuItem();
                item2.Text = printer2;
                comboPDFPrinter.Items.Add(item2);
            }

        }

        //Save Theme\\
        private void SaveTheme(string themeName)
        {
            ThemeResolutionService.ApplicationThemeName = themeName;
            settings.Store_Theme_Name = themeName;
            settings.Save();
            comboTheme.Text = themeName;
        }

        #region ThemeComboBox
        private void menuItemWindows7_Click(object sender, EventArgs e)
                {
                    SaveTheme("Windows7");
                }

                private void menuItemWindows8_Click(object sender, EventArgs e)
                {
                    SaveTheme("Windows8");
                }

                private void menuItemMetroBlue_Click(object sender, EventArgs e)
                {
                    SaveTheme("TelerikMetroBlue");
                }

                private void menuItemMetroTouch_Click(object sender, EventArgs e)
                {
                    SaveTheme("TelerikMetroTouch");
                }
        #endregion

        //-------------------------------------
        //
        //            Clicks
        //
        //-------------------------------------
        
        //Change Background\\
        private void btnChangeBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images| *.JPG; *.PNG; *.GIF";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                settings.Background = ofd.FileName;
                settings.Save(); 
            }
            else
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "Background Error";
                alert.ContentText = "Invalid Image file";
                alert.Show();
            }
        }

        //Change Background Color\\
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            MainSettingsFile settings = new MainSettingsFile();
            if (radColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = radColorDialog1.SelectedColor;
                settings.Background_Color = color;
                settings.Save();
            }
        }

        //Change Title Colors\\
        private void btnTitleFontColor_Click(object sender, EventArgs e)
        {
            if (radColorDialog1.ShowDialog()== DialogResult.OK)
            {
                Color color = radColorDialog1.SelectedColor;
                settings.Title_Font_Color = color;
                settings.Save();
                lblCurrentColor.Text = settings.Title_Font_Color.ToString();
            }
        }

        //Title Font Button Clicked\\
        private void btnTitleFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                settings.Tile_Font_Family = font;
                settings.Save();
                lblCurrentFont.Text = settings.Tile_Font_Family.Name;
            }
        }
    }
}
