using RhinoDek2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using RhinoDek2.Classes;
using System.Data;
using System.Data.SqlClient;

namespace RhinoDek2
{
    public partial class MainMenu : Telerik.WinControls.UI.RadForm
    {
        private RadTitleBarElement titleBar;
        private RadButtonElement backButton;
        private LightVisualElement headerLabel;
        private LightVisualElement page;
        private Dictionary<string, UserControl> pageControls;
        private string currentPage = string.Empty;
        private MainSettingsFile settings = new MainSettingsFile();

        public Image setImage;

        public MainMenu()
        {
            InitializeComponent();

            this.radPanorama1.ScrollBarAlignment = HorizontalScrollAlignment.Bottom;
            this.radPanorama1.ScrollBarThickness = 10;
            this.FormElement.TitleBar.MaxSize = new Size(0, 1);
            this.radPanorama1.SizeChanged += new EventHandler(radTilePanel1_SizeChanged);

            Load_Static_Data();
            CheckApplicationSettings();
            LoadTheme();
            LoadApperance();
            LoadTitle();
            PrepareHeader();
            PreparePages();
        }

        #region EventHandlers

        void titleBar_Minimize(object sender, EventArgs args)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void titleBar_Close(object sender, EventArgs args)
        {
            this.Close();
        }

        void titleBar_MaximizeRestore(object sender, EventArgs args)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        void backButton_Click(object sender, EventArgs e)
        {
            UnloadPage();
        }

        #endregion

        #region Pages and Controls

        //Prepare Pages\\
        private void PreparePages()
        {
            page = new LightVisualElement();
            page.DrawText = false;
            page.DrawFill = true;
            page.BackColor = Color.White;
            page.GradientStyle = GradientStyles.Solid;
            page.Visibility = ElementVisibility.Collapsed;
            radPanorama1.PanoramaElement.Children.Add(page);
            page.Margin = new Padding(0, 140, 0, 0);

            pageControls = new Dictionary<string, UserControl>();
            pageControls.Add("MainSettings", new Pages.MainSettings());
            pageControls.Add("Database", new Pages.Database());
            pageControls.Add("NewDrawing", new Pages.NewDrawing());
            pageControls.Add("LogoBrowser", new Pages.LogoBrowser());
            PreloadControls();
        }

        //Load a page\\
        private void LoadPage(string pageName, RadTileElement tile)
        {
            if (currentPage != string.Empty)
            {
                return;
            }

            this.currentPage = pageName;

            this.headerLabel.Text = tile.Text;
            this.backButton.Visibility = ElementVisibility.Visible;

            this.page.PositionOffset = new SizeF(-this.radPanorama1.Width, 0);
            page.Visibility = ElementVisibility.Visible;
            AnimatedPropertySetting setting =
            new AnimatedPropertySetting(RadElement.PositionOffsetProperty,
                                        new SizeF(-this.radPanorama1.Width, 0),
                                        SizeF.Empty, (int)(10d * 800d / this.Width), 10);

            setting.AnimationFinished += new AnimationFinishedEventHandler(OnPageOpened);
            setting.ApplyValue(this.page);
        }

        private void UnloadPage()
        {
            this.Controls.Remove(this.GetCurrentPageControl());

            this.backButton.Visibility = ElementVisibility.Hidden;
            this.headerLabel.Text = "RhinoDek";
            MainSettingsFile updatedSettings = new MainSettingsFile();

            if (File.Exists(updatedSettings.Background))
            {
                Image newImage = Image.FromFile(updatedSettings.Background);
                this.radPanorama1.PanelImage = newImage;
            }
            if (updatedSettings.Title_Font_Color != Color.Gray)
            {
                tileGroupDrawing.ForeColor = updatedSettings.Title_Font_Color;
                tileGroupSettings.ForeColor = updatedSettings.Title_Font_Color;
            }
            if (updatedSettings.Tile_Font_Family != null)
            {
                tileGroupDrawing.Font = updatedSettings.Tile_Font_Family;
                tileGroupSettings.Font = updatedSettings.Tile_Font_Family;
            }

            this.page.PositionOffset = new SizeF(-this.radPanorama1.Width, 0);
            page.Visibility = ElementVisibility.Visible;
            AnimatedPropertySetting setting =
            new AnimatedPropertySetting(RadElement.PositionOffsetProperty,
                                        SizeF.Empty,
                                        new SizeF(-this.radPanorama1.Width, 0),
                                        (int)(10d * 800d / this.Width), 10);

            setting.AnimationFinished += new AnimationFinishedEventHandler(OnPageClosed);
            setting.ApplyValue(this.page);
        }

        private void OnPageOpened(object sender, AnimationStatusEventArgs e)
        {
            UserControl ctrl = this.GetCurrentPageControl();
            if (ctrl != null)
            {
                this.Controls.Add(ctrl);
                ctrl.BringToFront();
                this.UpdatePageControlPosition();
                
            }
        }

        private void OnPageClosed(object sender, AnimationStatusEventArgs e)
        {
            ((AnimatedPropertySetting)sender).AnimationFinished -= OnPageClosed;
            this.page.Visibility = ElementVisibility.Collapsed;
            this.currentPage = string.Empty;
        }

        private void UpdatePageControlPosition()
        {
            UserControl ctrl = this.GetCurrentPageControl();
            if (ctrl != null)
            {
                //Point default is 120 in X and 60 in the Y
                //Size default is -180 in the X and -120 in the Y
                ctrl.Bounds = new Rectangle(
                    new Point(10, this.page.ControlBoundingRectangle.Y + 10),
                    new Size(this.Width - 50, this.Height - this.page.ControlBoundingRectangle.Y - 50));
            }
        }

        private UserControl GetCurrentPageControl()
        {
            if (this.currentPage != "" && this.pageControls.ContainsKey(this.currentPage))
            {
                return this.pageControls[this.currentPage];
            }

            return null;
        }

        //Prepare Controls\\
        private void PreloadControls()
        {
            foreach (KeyValuePair<string, UserControl> entry in this.pageControls)
            {
                this.Controls.Add(entry.Value);
                entry.Value.Location = new Point(120, 180);
            }
        }

        void radTilePanel1_SizeChanged(object sender, EventArgs e)
        {
            int width = this.radPanorama1.Width + Math.Max((this.radPanorama1.PanoramaElement.ScrollBar.Maximum - this.radPanorama1.Width) / 4, 1);
            this.radPanorama1.PanelImageSize = new Size(width, 768);
            this.radPanorama1.PanoramaElement.UpdateViewOnScroll();

            UpdatePageControlPosition();
        }

        protected override FormControlBehavior InitializeFormBehavior()
        {
            return new MyFormBehavior(this, true);
        }

        public class MyFormBehavior : RadFormBehavior
        {
            public MyFormBehavior(IComponentTreeHandler treeHandler, bool shouldCreateChildren) :
                base(treeHandler, shouldCreateChildren)
            {
            }

            public override Padding BorderWidth
            {
                get
                {
                    return new Padding(1);
                }
            }
        }

        #endregion

        //Pre Load Static Data\\
        void Load_Static_Data()
        {
            //Load CAD Folders\\
            if (Directory.Exists("//surfer/cad/"))
            {
                StaticData.CAD_Folders = Directory.GetDirectories("//surfer/cad/");
            }
            else
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Info";
                alert.ContentText = "There was a error in the network." + "Could not list folders in the CAD drive.";
            }

            DataTable logoGroupDT = SQLHelper.GetTable("select Group_Name from Logo_Groups");
            StaticData.Logo_Group_Names = new List<string>();
            foreach (DataRow row in logoGroupDT.Rows)
            {
                StaticData.Logo_Group_Names.Add(row["Group_Name"].ToString());
            }

        }

        //Load Apperance\\
        void LoadApperance()
        {
            //Load Font Colors\\
            if (settings.Title_Font_Color != Color.Gray)
            {
                tileGroupDrawing.ForeColor = settings.Title_Font_Color;
                tileGroupSettings.ForeColor = settings.Title_Font_Color;
            }
            //Load Fonts\\
            if (settings.Tile_Font_Family != null)
            {
                tileGroupDrawing.Font = settings.Tile_Font_Family;
                tileGroupSettings.Font = settings.Tile_Font_Family;
            }
            //Load Background\\
            if (File.Exists(settings.Background))
            {
                if (File.Exists(settings.Background))
                {
                    Image newImage = Image.FromFile(settings.Background);
                    radPanorama1.PanelImage = newImage;
                }
                else
                {
                    RadDesktopAlert alert = new RadDesktopAlert();
                    alert.CaptionText = "RhinoDek Info";
                    alert.ContentText = "Backgroud file no longer exists!";
                    alert.Show();
                }
            }
        }

        // Check Application Settings\\
        void CheckApplicationSettings()
        {
            
        }

        //LoadTheme\\
        void LoadTheme()
        {
            if (settings.Store_Theme_Name != "Windows8")
            {
                ThemeResolutionService.ApplicationThemeName = settings.Store_Theme_Name;
            }
            else
            {
                ThemeResolutionService.ApplicationThemeName = "Windows8";
            }
        }

        //LoadTitle\\
        void LoadTitle()
        {
            titleBar = new RadTitleBarElement();

            titleBar.FillPrimitive.Visibility = ElementVisibility.Hidden;
            titleBar.MaxSize = new Size(0, 50);
            titleBar.Children[1].Visibility = ElementVisibility.Hidden;

            titleBar.CloseButton.Parent.PositionOffset = new SizeF(0, -10);
            titleBar.CloseButton.SetValue(RadFormElement.IsFormActiveProperty, true);

            titleBar.Close += new TitleBarSystemEventHandler(titleBar_Close);
            titleBar.Minimize += new TitleBarSystemEventHandler(titleBar_Minimize);
            titleBar.MaximizeRestore += new TitleBarSystemEventHandler(titleBar_MaximizeRestore);

            radPanorama1.PanoramaElement.Children.Add(titleBar);
        }

        //Prepareheader\\
        private void PrepareHeader()
        {
            StackLayoutElement headerLayout = new StackLayoutElement();
            headerLayout.Orientation = Orientation.Horizontal;
            headerLayout.Margin = new System.Windows.Forms.Padding(0, 35, 0, 0);
            headerLayout.NotifyParentOnMouseInput = true;
            headerLayout.ShouldHandleMouseInput = false;
            headerLayout.StretchHorizontally = false;

            this.backButton = new RadButtonElement() { StretchHorizontally = false };
            Image backImage = Resources.back;
            backButton.Image = backImage;
            backButton.ButtonFillElement.BackColor = Color.Transparent;
            backButton.Children[2].Visibility = ElementVisibility.Hidden;
            backButton.Children[0].Visibility = ElementVisibility.Hidden;
            this.backButton.Margin = new Padding(40, 0, 28, 0);
            this.backButton.Click += new EventHandler(backButton_Click);
            this.backButton.Visibility = ElementVisibility.Hidden;
            headerLayout.Children.Add(this.backButton);

            this.headerLabel = new LightVisualElement();
            this.headerLabel.Text = "RhinoDek";
            this.headerLabel.Font = new Font("Segoe UI Light", 42, GraphicsUnit.Point);
            this.headerLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.headerLabel.ForeColor = Color.White;
            this.headerLabel.TextAlignment = ContentAlignment.MiddleLeft;
            this.headerLabel.MaxSize = new Size(630, 110);
            this.headerLabel.NotifyParentOnMouseInput = true;
            this.headerLabel.ShouldHandleMouseInput = false;
            this.headerLabel.StretchHorizontally = false;
            headerLayout.Children.Add(this.headerLabel);

            this.radPanorama1.PanoramaElement.Children.Add(headerLayout);
        }

        //Main Settings Clicked\\
        private void tileMainSettings_Click(object sender, EventArgs e)
        {
            LoadPage("MainSettings", (RadTileElement)sender);
        }

        //Database Clicked\\
        private void tileDatabase_Click(object sender, EventArgs e)
        {
            LoadPage("Database", (RadTileElement)sender);
        }

        //New Drawing Clicked\\
        private void tileNewDrawing_Click(object sender, EventArgs e)
        {
            Forms.NewDrawingWizard wizard = new Forms.NewDrawingWizard();
            wizard.Show(this);

        }

        //Logo Browser Clicked\\
        private void tileLogoBrowser_Click(object sender, EventArgs e)
        {
            LoadPage("LogoBrowser", (RadTileElement)sender);
        }
    }
}
