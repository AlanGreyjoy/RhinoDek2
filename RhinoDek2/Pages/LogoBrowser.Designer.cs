namespace RhinoDek2.Pages
{
    partial class LogoBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.GroupsTitle = new Telerik.WinControls.UI.RadPageViewItemPage();
            this.SettingsTitle = new Telerik.WinControls.UI.RadPageViewItemPage();
            this.AddLogo = new Telerik.WinControls.UI.RadPageViewPage();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.dropDownGroups = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.btnAddBlock = new Telerik.WinControls.UI.RadButton();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.tbDrawnBy = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.taDescription = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.checkLaser = new Telerik.WinControls.UI.RadCheckBox();
            this.checkThreeSixteenth = new Telerik.WinControls.UI.RadCheckBox();
            this.checkFourth = new Telerik.WinControls.UI.RadCheckBox();
            this.checkEigth = new Telerik.WinControls.UI.RadCheckBox();
            this.tbLogoName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnSubmitLogo = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.AddGroup = new Telerik.WinControls.UI.RadPageViewPage();
            this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.tbLogoGroupName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnAddLogoGroup = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.rhinoDekDataSet1 = new RhinoDek2.RhinoDekDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.AddLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropDownGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDrawnBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLaser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkThreeSixteenth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFourth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEigth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmitLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.AddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
            this.radScrollablePanel2.PanelContainer.SuspendLayout();
            this.radScrollablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogoGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddLogoGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhinoDekDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.GroupsTitle);
            this.radPageView1.Controls.Add(this.SettingsTitle);
            this.radPageView1.Controls.Add(this.AddLogo);
            this.radPageView1.Controls.Add(this.AddGroup);
            this.radPageView1.DefaultPage = this.GroupsTitle;
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.AddLogo;
            this.radPageView1.Size = new System.Drawing.Size(1010, 651);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "Add Group";
            this.radPageView1.ThemeName = "ControlDefault";
            this.radPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            this.radPageView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radPageView1_MouseClick);
            ((Telerik.WinControls.UI.RadPageViewBackstageElement)(this.radPageView1.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.FillHeight;
            // 
            // GroupsTitle
            // 
            this.GroupsTitle.ItemSize = new System.Drawing.SizeF(75F, 40F);
            this.GroupsTitle.ItemType = Telerik.WinControls.UI.PageViewItemType.GroupHeaderItem;
            this.GroupsTitle.Location = new System.Drawing.Point(305, 4);
            this.GroupsTitle.Name = "GroupsTitle";
            this.GroupsTitle.Size = new System.Drawing.Size(701, 643);
            this.GroupsTitle.Text = "Groups";
            // 
            // SettingsTitle
            // 
            this.SettingsTitle.ItemSize = new System.Drawing.SizeF(75F, 40F);
            this.SettingsTitle.ItemType = Telerik.WinControls.UI.PageViewItemType.GroupHeaderItem;
            this.SettingsTitle.Location = new System.Drawing.Point(0, 0);
            this.SettingsTitle.Name = "SettingsTitle";
            this.SettingsTitle.Size = new System.Drawing.Size(0, 0);
            this.SettingsTitle.Text = "Settings";
            // 
            // AddLogo
            // 
            this.AddLogo.Controls.Add(this.radScrollablePanel1);
            this.AddLogo.ItemSize = new System.Drawing.SizeF(75F, 45F);
            this.AddLogo.Location = new System.Drawing.Point(305, 4);
            this.AddLogo.Name = "AddLogo";
            this.AddLogo.Size = new System.Drawing.Size(701, 643);
            this.AddLogo.Text = "Add Logo";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.dropDownGroups);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel7);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.logoPictureBox);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnAddBlock);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel8);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.tbDrawnBy);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel5);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.taDescription);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel4);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.checkLaser);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.checkThreeSixteenth);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.checkFourth);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.checkEigth);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.tbLogoName);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.btnSubmitLogo);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel3);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(699, 641);
            this.radScrollablePanel1.Size = new System.Drawing.Size(701, 643);
            this.radScrollablePanel1.TabIndex = 0;
            this.radScrollablePanel1.Text = "radScrollablePanel1";
            ((Telerik.WinControls.UI.RadScrollablePanelElement)(this.radScrollablePanel1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Empty;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // dropDownGroups
            // 
            this.dropDownGroups.AutoSize = false;
            this.dropDownGroups.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.dropDownGroups.Location = new System.Drawing.Point(287, 242);
            this.dropDownGroups.Name = "dropDownGroups";
            this.dropDownGroups.Size = new System.Drawing.Size(254, 30);
            this.dropDownGroups.TabIndex = 25;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(284, 211);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(93, 25);
            this.radLabel7.TabIndex = 24;
            this.radLabel7.Text = "Logo Group";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.White;
            this.logoPictureBox.Location = new System.Drawing.Point(22, 77);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(256, 256);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 22;
            this.logoPictureBox.TabStop = false;
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBlock.Location = new System.Drawing.Point(22, 370);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(120, 30);
            this.btnAddBlock.TabIndex = 15;
            this.btnAddBlock.Text = "Add Block";
            this.btnAddBlock.ThemeName = "TelerikMetroBlue";
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(284, 144);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(75, 25);
            this.radLabel8.TabIndex = 18;
            this.radLabel8.Text = "Drawn By";
            // 
            // tbDrawnBy
            // 
            this.tbDrawnBy.Location = new System.Drawing.Point(284, 175);
            this.tbDrawnBy.Name = "tbDrawnBy";
            this.tbDrawnBy.Size = new System.Drawing.Size(394, 30);
            this.tbDrawnBy.TabIndex = 19;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(284, 278);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(88, 25);
            this.radLabel5.TabIndex = 20;
            this.radLabel5.Text = "Description";
            // 
            // taDescription
            // 
            this.taDescription.Location = new System.Drawing.Point(284, 309);
            this.taDescription.Name = "taDescription";
            this.taDescription.Size = new System.Drawing.Size(394, 172);
            this.taDescription.TabIndex = 21;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(284, 77);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(50, 25);
            this.radLabel4.TabIndex = 17;
            this.radLabel4.Text = "Name";
            // 
            // checkLaser
            // 
            this.checkLaser.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLaser.Location = new System.Drawing.Point(178, 339);
            this.checkLaser.Name = "checkLaser";
            this.checkLaser.Size = new System.Drawing.Size(58, 25);
            this.checkLaser.TabIndex = 19;
            this.checkLaser.Text = "Laser";
            // 
            // checkThreeSixteenth
            // 
            this.checkThreeSixteenth.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkThreeSixteenth.Location = new System.Drawing.Point(71, 339);
            this.checkThreeSixteenth.Name = "checkThreeSixteenth";
            this.checkThreeSixteenth.Size = new System.Drawing.Size(52, 25);
            this.checkThreeSixteenth.TabIndex = 19;
            this.checkThreeSixteenth.Text = "3/16";
            // 
            // checkFourth
            // 
            this.checkFourth.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFourth.Location = new System.Drawing.Point(129, 339);
            this.checkFourth.Name = "checkFourth";
            this.checkFourth.Size = new System.Drawing.Size(43, 25);
            this.checkFourth.TabIndex = 19;
            this.checkFourth.Text = "1/4";
            // 
            // checkEigth
            // 
            this.checkEigth.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEigth.Location = new System.Drawing.Point(22, 339);
            this.checkEigth.Name = "checkEigth";
            this.checkEigth.Size = new System.Drawing.Size(43, 25);
            this.checkEigth.TabIndex = 18;
            this.checkEigth.Text = "1/8";
            // 
            // tbLogoName
            // 
            this.tbLogoName.Location = new System.Drawing.Point(284, 108);
            this.tbLogoName.Name = "tbLogoName";
            this.tbLogoName.Size = new System.Drawing.Size(394, 30);
            this.tbLogoName.TabIndex = 17;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(115, 37);
            this.radLabel2.TabIndex = 15;
            this.radLabel2.Text = "Add Logo";
            // 
            // btnSubmitLogo
            // 
            this.btnSubmitLogo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitLogo.Location = new System.Drawing.Point(284, 487);
            this.btnSubmitLogo.Name = "btnSubmitLogo";
            this.btnSubmitLogo.Size = new System.Drawing.Size(109, 30);
            this.btnSubmitLogo.TabIndex = 14;
            this.btnSubmitLogo.Text = "Submit";
            this.btnSubmitLogo.ThemeName = "TelerikMetroBlue";
            this.btnSubmitLogo.Click += new System.EventHandler(this.btnSubmitLogo_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(22, 46);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(394, 25);
            this.radLabel3.TabIndex = 16;
            this.radLabel3.Text = "You can add logo groups to orginaize the logos better";
            // 
            // AddGroup
            // 
            this.AddGroup.Controls.Add(this.radScrollablePanel2);
            this.AddGroup.ItemSize = new System.Drawing.SizeF(75F, 45F);
            this.AddGroup.Location = new System.Drawing.Point(305, 4);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(701, 643);
            this.AddGroup.Text = "Add Group";
            // 
            // radScrollablePanel2
            // 
            this.radScrollablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel2.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel2.Name = "radScrollablePanel2";
            // 
            // radScrollablePanel2.PanelContainer
            // 
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.tbLogoGroupName);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.btnAddLogoGroup);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel6);
            this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(699, 641);
            this.radScrollablePanel2.Size = new System.Drawing.Size(701, 643);
            this.radScrollablePanel2.TabIndex = 0;
            this.radScrollablePanel2.Text = "radScrollablePanel2";
            // 
            // tbLogoGroupName
            // 
            this.tbLogoGroupName.Location = new System.Drawing.Point(35, 77);
            this.tbLogoGroupName.Name = "tbLogoGroupName";
            this.tbLogoGroupName.Size = new System.Drawing.Size(394, 30);
            this.tbLogoGroupName.TabIndex = 13;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(233, 37);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "Adding Logo Groups";
            // 
            // btnAddLogoGroup
            // 
            this.btnAddLogoGroup.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLogoGroup.Location = new System.Drawing.Point(35, 113);
            this.btnAddLogoGroup.Name = "btnAddLogoGroup";
            this.btnAddLogoGroup.Size = new System.Drawing.Size(200, 30);
            this.btnAddLogoGroup.TabIndex = 10;
            this.btnAddLogoGroup.Text = "Add";
            this.btnAddLogoGroup.ThemeName = "TelerikMetroBlue";
            this.btnAddLogoGroup.Click += new System.EventHandler(this.btnAddLogoGroup_Click);
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(35, 46);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(394, 25);
            this.radLabel6.TabIndex = 12;
            this.radLabel6.Text = "You can add logo groups to orginaize the logos better";
            // 
            // rhinoDekDataSet1
            // 
            this.rhinoDekDataSet1.DataSetName = "RhinoDekDataSet";
            this.rhinoDekDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LogoBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPageView1);
            this.Name = "LogoBrowser";
            this.Size = new System.Drawing.Size(1010, 651);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.AddLogo.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dropDownGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDrawnBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkLaser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkThreeSixteenth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFourth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEigth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmitLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.AddGroup.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
            this.radScrollablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbLogoGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddLogoGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhinoDekDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewItemPage SettingsTitle;
        private Telerik.WinControls.UI.RadPageViewPage AddLogo;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadPageViewPage AddGroup;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel2;
        private Telerik.WinControls.UI.RadTextBoxControl tbLogoGroupName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnAddLogoGroup;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadCheckBox checkLaser;
        private Telerik.WinControls.UI.RadCheckBox checkThreeSixteenth;
        private Telerik.WinControls.UI.RadCheckBox checkFourth;
        private Telerik.WinControls.UI.RadCheckBox checkEigth;
        private Telerik.WinControls.UI.RadTextBoxControl tbLogoName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSubmitLogo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBoxControl taDescription;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBoxControl tbDrawnBy;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private Telerik.WinControls.UI.RadButton btnAddBlock;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadPageViewItemPage GroupsTitle;
        private RhinoDekDataSet rhinoDekDataSet1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadDropDownList dropDownGroups;
    }
}
