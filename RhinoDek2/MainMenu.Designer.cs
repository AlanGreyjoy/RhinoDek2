namespace RhinoDek2
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.radPanorama1 = new Telerik.WinControls.UI.RadPanorama();
            this.tileGroupDrawing = new Telerik.WinControls.UI.TileGroupElement();
            this.tileNewDrawing = new Telerik.WinControls.UI.RadTileElement();
            this.tilePrint = new Telerik.WinControls.UI.RadTileElement();
            this.tilePartsBuilder = new Telerik.WinControls.UI.RadTileElement();
            this.tileToolBuilder = new Telerik.WinControls.UI.RadTileElement();
            this.tileLogoBrowser = new Telerik.WinControls.UI.RadTileElement();
            this.tileGroupSettings = new Telerik.WinControls.UI.TileGroupElement();
            this.tileMainSettings = new Telerik.WinControls.UI.RadTileElement();
            this.tileDatabase = new Telerik.WinControls.UI.RadTileElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanorama1
            // 
            this.radPanorama1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanorama1.Groups.AddRange(new Telerik.WinControls.RadItem[] {
            this.tileGroupDrawing,
            this.tileGroupSettings});
            this.radPanorama1.Location = new System.Drawing.Point(0, 0);
            this.radPanorama1.Name = "radPanorama1";
            this.radPanorama1.RowsCount = 2;
            this.radPanorama1.ShowGroups = true;
            this.radPanorama1.Size = new System.Drawing.Size(1007, 656);
            this.radPanorama1.TabIndex = 0;
            this.radPanorama1.Text = "RhinoDek";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radPanorama1.GetChildAt(0).GetChildAt(1))).Image = global::RhinoDek2.Properties.Resources.defaultBackground;
            // 
            // tileGroupDrawing
            // 
            this.tileGroupDrawing.BorderLeftWidth = 1F;
            this.tileGroupDrawing.CellSize = new System.Drawing.Size(150, 150);
            this.tileGroupDrawing.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tileNewDrawing,
            this.tilePrint,
            this.tilePartsBuilder,
            this.tileToolBuilder,
            this.tileLogoBrowser});
            this.tileGroupDrawing.Margin = new System.Windows.Forms.Padding(120, 130, 25, 0);
            this.tileGroupDrawing.Name = "tileGroupDrawing";
            this.tileGroupDrawing.RowsCount = 2;
            this.tileGroupDrawing.Text = "Drawing";
            // 
            // tileNewDrawing
            // 
            this.tileNewDrawing.Image = global::RhinoDek2.Properties.Resources.appbar_newspaper_create;
            this.tileNewDrawing.Name = "tileNewDrawing";
            this.tileNewDrawing.Text = "New Drawing";
            this.tileNewDrawing.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tileNewDrawing.Click += new System.EventHandler(this.tileNewDrawing_Click);
            // 
            // tilePrint
            // 
            this.tilePrint.BackgroundImage = null;
            this.tilePrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tilePrint.Column = 2;
            this.tilePrint.Image = global::RhinoDek2.Properties.Resources.appbar_printer_text;
            this.tilePrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tilePrint.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tilePrint.Name = "tilePrint";
            this.tilePrint.RowSpan = 2;
            this.tilePrint.Text = "Print";
            this.tilePrint.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tilePrint.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tilePartsBuilder
            // 
            this.tilePartsBuilder.Column = 1;
            this.tilePartsBuilder.Image = global::RhinoDek2.Properties.Resources.appbar_cell_insert_below;
            this.tilePartsBuilder.Name = "tilePartsBuilder";
            this.tilePartsBuilder.Text = "Parts Builder";
            this.tilePartsBuilder.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tileToolBuilder
            // 
            this.tileToolBuilder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(161)))), ((int)(((byte)(227)))));
            this.tileToolBuilder.Column = 3;
            this.tileToolBuilder.Image = global::RhinoDek2.Properties.Resources.appbar_tools;
            this.tileToolBuilder.Name = "tileToolBuilder";
            this.tileToolBuilder.Text = "Tool Builder";
            this.tileToolBuilder.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tileLogoBrowser
            // 
            this.tileLogoBrowser.BackgroundImage = global::RhinoDek2.Properties.Resources._9233c4c98a295848b7c817d3ff6961f7;
            this.tileLogoBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tileLogoBrowser.ColSpan = 2;
            this.tileLogoBrowser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileLogoBrowser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tileLogoBrowser.Image = global::RhinoDek2.Properties.Resources.sdlogo_white;
            this.tileLogoBrowser.Name = "tileLogoBrowser";
            this.tileLogoBrowser.Row = 1;
            this.tileLogoBrowser.Text = "Logo Browser";
            this.tileLogoBrowser.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tileLogoBrowser.Click += new System.EventHandler(this.tileLogoBrowser_Click);
            // 
            // tileGroupSettings
            // 
            this.tileGroupSettings.CellSize = new System.Drawing.Size(150, 150);
            this.tileGroupSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(105)))), ((int)(((byte)(200)))));
            this.tileGroupSettings.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tileMainSettings,
            this.tileDatabase});
            this.tileGroupSettings.Margin = new System.Windows.Forms.Padding(120, 130, 25, 0);
            this.tileGroupSettings.Name = "tileGroupSettings";
            this.tileGroupSettings.Text = "Settings";
            // 
            // tileMainSettings
            // 
            this.tileMainSettings.BackgroundImage = global::RhinoDek2.Properties.Resources.Administrative_Tools;
            this.tileMainSettings.Image = null;
            this.tileMainSettings.Name = "tileMainSettings";
            this.tileMainSettings.Text = "Main Settings";
            this.tileMainSettings.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tileMainSettings.Click += new System.EventHandler(this.tileMainSettings_Click);
            // 
            // tileDatabase
            // 
            this.tileDatabase.BackgroundImage = global::RhinoDek2.Properties.Resources.iCloud;
            this.tileDatabase.Column = 1;
            this.tileDatabase.Name = "tileDatabase";
            this.tileDatabase.Text = "Database";
            this.tileDatabase.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tileDatabase.Click += new System.EventHandler(this.tileDatabase_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 656);
            this.Controls.Add(this.radPanorama1);
            this.Name = "MainMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RhinoDek 2.0";
            this.ThemeName = "Windows8";
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private Telerik.WinControls.UI.RadPanorama radPanorama1;
        private Telerik.WinControls.UI.TileGroupElement tileGroupDrawing;
        private Telerik.WinControls.UI.TileGroupElement tileGroupSettings;
        private Telerik.WinControls.UI.RadTileElement tileMainSettings;
        private Telerik.WinControls.UI.RadTileElement tileDatabase;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadTileElement tileNewDrawing;
        private Telerik.WinControls.UI.RadTileElement tilePrint;
        private Telerik.WinControls.UI.RadTileElement tilePartsBuilder;
        private Telerik.WinControls.UI.RadTileElement tileToolBuilder;
        private Telerik.WinControls.UI.RadTileElement tileLogoBrowser;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
    }
}
