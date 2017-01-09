using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using System.Diagnostics;
using Rhino;
using RhinoScript4;
using System.IO;

namespace RhinoDek2.Pages
{
    public partial class LogoBrowser : UserControl
    {
        IRhinoScript rs;
        public Object logo;
        public string logoImagePath;

        public List<string> getDrawnBy = new List<string>();
        public List<string> getDescription = new List<string>();

        DataTable storeLogo = new DataTable();
        DataSet logoDataSet = new DataSet();

        //Main Invoke\\
        public LogoBrowser()
        {
            
            InitializeComponent();
            if (Classes.StaticData.Logo_Group_Names != null)
            {
                foreach (string name in Classes.StaticData.Logo_Group_Names)
                {
                    RadPageViewPage newPage = new RadPageViewPage();
                    newPage.Text = name;
                    radPageView1.Pages.Insert(1, newPage);
                    DescriptionTextListDataItem item = new DescriptionTextListDataItem();
                    item.Text = name;
                    dropDownGroups.Items.Add(item);
                }
            }
            RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter tableAdapter = new RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter();
            tableAdapter.Fill(rhinoDekDataSet1.Logo_Groups);

            object obj = RhinoApp.GetPlugInObject("RhinoScript");
            rs = (IRhinoScript)obj;

            CreateContextMenu();
            Populate_Groups_With_Logos();

        }

        //Adding a Group\\
        private void btnAddLogoGroup_Click(object sender, EventArgs e)
        {
            foreach (RhinoDekDataSet.Logo_GroupsRow row in rhinoDekDataSet1.Logo_Groups)
            {
                if (row.Group_Name == tbLogoGroupName.Text)
                {
                    RadDesktopAlert alert = new RadDesktopAlert();
                    alert.CaptionText = "RhinoDek Error";
                    alert.ContentText = "This Logo Group has already been added!";
                    alert.Show();
                    return;
                }
            }

            RadPageViewPage newPage = new RadPageViewPage();
            newPage.Text = tbLogoGroupName.Text;
            radPageView1.Pages.Insert(1, newPage);

            RhinoDekDataSet.Logo_GroupsRow groupRow;
            groupRow = rhinoDekDataSet1.Logo_Groups.NewLogo_GroupsRow();
            groupRow.Group_Name = newPage.Text;
            groupRow.Group_Directory_Path = @"\\surfer\public\cad\rhinodek\logo_browser\groups\" + tbLogoGroupName.Text;

            rhinoDekDataSet1.Logo_Groups.Rows.Add(groupRow);

            RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter ta = new RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter();

            ta.Update(rhinoDekDataSet1.Logo_Groups);

            if (!Directory.Exists(@"\\surfer\public\cad\rhinodek\logo_browser\groups\" + tbLogoGroupName.Text))
            {
                Directory.CreateDirectory(@"\\surfer\public\cad\rhinodek\logo_browser\groups\" + tbLogoGroupName.Text);
            }
        }

        #region Removing Group Tabs
        private void CreateContextMenu()
        {
            RadMenuItem removeGroupTab = new RadMenuItem();
            removeGroupTab.Text = "Remove group";
            removeGroupTab.Click += new EventHandler(Remove_Group_Click);
            radContextMenu1.Items.Add(removeGroupTab);
        }

        private void Remove_Group_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "------*****------WARNNING!------*****------"
                + Environment.NewLine
                + Environment.NewLine +
                "You are about to remove this group and also remove the folder directory and all files in it!"
                + Environment.NewLine
                + Environment.NewLine +
                "Are you sure you want to do this?", "RhinoDek Warnning - Group Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataRow[] foundRows;
                    foundRows = rhinoDekDataSet1.Tables["Logo_Groups"].Select(string.Format("Group_Name Like '{0}%'",radPageView1.SelectedPage.Text));
                    foreach (DataRow row in foundRows)
                    {
                        row.Delete();
                    }
                    RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter ta = new RhinoDekDataSetTableAdapters.Logo_GroupsTableAdapter();
                    ta.Update(rhinoDekDataSet1.Logo_Groups);
                }
                catch (Exception ex)
                {
                    RadDesktopAlert alert = new RadDesktopAlert();
                    alert.CaptionText = "RhinoDek Database Error";
                    alert.ContentText = "Group could not be removed" + Environment.NewLine +
                        ex.Message;
                    alert.Show();
                    return;
                }
                if (Directory.Exists(@"\\surfer\public\cad\rhinodek\logo_browser\groups\" + radPageView1.SelectedPage.Text))
                {
                    Directory.Delete(@"\\surfer\public\cad\rhinodek\logo_browser\groups\" + radPageView1.SelectedPage.Text);
                }
                radPageView1.Pages.Remove(radPageView1.SelectedPage);
            }
            else
            {
                return;
            }
        }

        void radPageView1_MouseClick(object sender, MouseEventArgs e)
        {
            RadPageViewItem hitItem = this.radPageView1.ViewElement.ItemFromPoint(e.Location);
            if (e.Button == MouseButtons.Right && hitItem != null)
            {
                radPageView1.SelectedPage = hitItem.Page;
                if (radPageView1.SelectedPage.Text != "Add Logo" && radPageView1.SelectedPage.Text != "Add Group")
                {
                    if (radPageView1.SelectedPage.Text != "Groups" && radPageView1.SelectedPage.Text != "Settings")
                    {
                        radContextMenu1.Show(this.radPageView1.PointToScreen(e.Location));
                    }
                }
            }
        }
        #endregion

        //Submit Logo Click\\
        private void btnSubmitLogo_Click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();

            try
            {
                RhinoDekDataSet.Logo_BrowserRow logoRow;
                logoRow = rhinoDekDataSet1.Logo_Browser.NewLogo_BrowserRow();
                logoRow.Logo_Name = tbLogoName.Text;
                logoRow.Drawn_By = tbDrawnBy.Text;
                logoRow.Logo_Group = dropDownGroups.Text;
                logoRow.Description = taDescription.Text;
                logoRow._1_8 = checkEigth.Checked;
                logoRow._1_4 = checkFourth.Checked;
                logoRow._3_16 = checkThreeSixteenth.Checked;
                logoRow.Laser = checkLaser.Checked;
                logoRow.Logo_Image_Path = string.Format(@"\\surfer\public\cad\rhinodek\logo_browser\groups\{0}\{1}.png",dropDownGroups.Text, tbLogoName.Text);

                RhinoDekDataSetTableAdapters.Logo_BrowserTableAdapter ta = new RhinoDekDataSetTableAdapters.Logo_BrowserTableAdapter();
                rhinoDekDataSet1.Logo_Browser.Rows.Add(logoRow);
                ta.Update(rhinoDekDataSet1.Logo_Browser);

                logoPictureBox.Image = null;
                logoPictureBox.InitialImage = null;
                File.Copy(string.Format(@"{0}\RhinoDek_Temp_Logo_Image.png", tempPath), string.Format(@"\\surfer\public\cad\rhinodek\logo_browser\groups\{0}\{1}.png",dropDownGroups.Text,tbLogoName.Text),true);
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Database Error";
                alert.ContentText = "The logo could not be added." + Environment.NewLine +
                    ex.Message;
                alert.Show();
                return;
            }

            //rs.Command(string.Format("_-Export _Pause {0} _Enter", path));

        }

        //Choose Logo Button Click\\
        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();

            logo = rs.GetObjects("Select the logo you wish to add. . .", 0, true,true,true);
            if (logo == null)
            {
                rs.Print("There was no valid object selected. Please try again.");
                return;
            }
            rs.Command("_Zoom _Selected");
            rs.UnselectAllObjects();

            if (File.Exists(tempPath + @"\RhinoDek_Temp_Logo_Image.png"))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(tempPath + @"\RhinoDek_Temp_Logo_Image.png");
            }

            rs.Command(string.Format(@"-ViewCaptureToFile {0}\RhinoDek_Temp_Logo_Image.png TransparentBackground=Yes _Enter", tempPath));

            using (FileStream stream = new FileStream(tempPath + @"\RhinoDek_Temp_Logo_Image.png", FileMode.Open, FileAccess.Read))
            {
                logoPictureBox.Image = Image.FromStream(stream);
                stream.Dispose();
            }

        }





        #region Populating Groups With Logos

        //Populating Groups with logos\\
        Image logoImage;
        public void Populate_Groups_With_Logos()
        {

            RhinoDekDataSetTableAdapters.Logo_BrowserTableAdapter ta = new RhinoDekDataSetTableAdapters.Logo_BrowserTableAdapter();
            ta.Fill(rhinoDekDataSet1.Logo_Browser);

            storeLogo.Columns.Add("DrawnBy", typeof(string));
            storeLogo.Columns.Add("Description", typeof(string));

            foreach (RadPageViewPage page in radPageView1.Pages)
            {
                if (page.Text != "Settings" && page.Text != "Groups")
                {
                    if (page.Text != "Add Logo" && page.Text != "Add Group")
                    {
                        DataTable table = rhinoDekDataSet1.Tables["Logo_Browser"];
                        string expression;
                        expression = string.Format("Logo_Group LIKE '%{0}%'", page.Text);
                        DataRow[] foundRows;

                        BindingList<Logo> dataSource = new BindingList<Logo>();

                        foundRows = table.Select(expression);
                        RadListView listView = new RadListView();

                        listView.ItemDataBound += new ListViewItemEventHandler(Logo_ItemData);
                        listView.VisualItemFormatting += new ListViewVisualItemEventHandler(Logo_VisualItemFormatting);

                        listView.AllowEdit = false;
                        listView.AllowRemove = false;
                        listView.ItemSize = new Size(300, 128);
                        listView.ViewType = ListViewType.ListView;
                        listView.Dock = DockStyle.Fill;
                        listView.DataSource = dataSource;
                        listView.DisplayMember = "LogoName";
                        listView.ValueMember = "Logo_Name";
                        currentListView = listView;

                        foreach (DataRow row in foundRows)
                        {
                            
                            if (row["Logo_Group"].ToString() == page.Text)
                            {
                                if (logoImage != null)
                                {
                                    logoImage = null;
                                    logoImage = Image.FromFile(row["Logo_Image_Path"].ToString());
                                }
                                else
                                {
                                    logoImage = Image.FromFile(row["Logo_Image_Path"].ToString());
                                }

                                dataSource.Add(new Logo(1, row["Logo_Name"].ToString(), row["Drawn_By"].ToString(), row["Logo_Group"].ToString(), row["Description"].ToString(), row["Logo_Image_Path"].ToString(), false, false, false, false));

                                page.Controls.Add(listView);
                                storeLogo.Rows.Add(row["Drawn_By"].ToString(), row["Description"].ToString());
                            }
                        }
                    }
                }
            }

            logoDataSet.Tables.Add(storeLogo);
        }

        public RadListView currentListView;
        void Logo_ItemData(object sender, ListViewItemEventArgs e)
        {
            if (currentListView.ViewType == ListViewType.ListView)
            {
                e.Item.Image = logoImage;

            }
        }

        void Logo_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            e.VisualItem.ImageLayout = ImageLayout.Zoom;

            //string drawnBy = ((RhinoDekDataSet.Logo_BrowserRow)(((DataRowView)(e.VisualItem.Data.DataBoundItem)).Row)).Drawn_By;
            string drawnBy = ((Logo)e.VisualItem.Data.DataBoundItem).DrawnBy;
            string logoName = ((Logo)e.VisualItem.Data.DataBoundItem).LogoName;
            string logoDescription = ((Logo)e.VisualItem.Data.DataBoundItem).LogoDescription;
            e.VisualItem.Text = "<html><b>" + logoName + "</b><br><span style=\"color:#999999\"><b>Drawn By </b>" + drawnBy + "<br><b>Description </b>" + logoDescription + "</span>";
        }

        #endregion


    }




    //Logo Class\\
    public class Logo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _logoID;
        private string _logoName;
        private string _drawnBy;
        private string _logoGroup;
        private string _logoDescription;
        private string _logoImagePath;
        private bool _eigth;
        private bool _threeSixteenth;
        private bool _forth;
        private bool _laser;

        public Logo(int LogoID, string LogoName, string DrawnBy, string LogoGroup, string LogoDescription,
            string LogoImagePath, bool Eight, bool ThreeSixteenth, bool Forth, bool Laser)
        {
            _logoID = LogoID;
            _logoName = LogoName;
            _drawnBy = DrawnBy;
            _logoGroup = LogoGroup;
            _logoDescription = LogoDescription;
            _logoImagePath = LogoImagePath;
            _eigth = Eight;
            _threeSixteenth = ThreeSixteenth;
            _forth = Forth;
            _laser = Laser;
        }

        public int LogoID
        {
            get
            {
                return _logoID;
            }
            set
            {
                if (_logoID != value)
                {
                    _logoID = value;
                    OnPropertyChanged("LogoID");
                }
            }
        }

        public string LogoName
        {
            get
            {
                return _logoName;
            }
            set
            {
                if (_logoName != value)
                {
                    _logoName = value;
                    OnPropertyChanged("Logo_Name");
                }
            }
        }

        public string DrawnBy
        {
            get
            {
                return _drawnBy;
            }
            set
            {
                if (_drawnBy != value)
                {
                    _drawnBy = value;
                    OnPropertyChanged("Drawn_By");
                }
            }
        }

        public string LogoGroup
        {
            get
            {
                return _logoGroup;
            }
            set
            {
                if (_logoGroup != value)
                {
                    _logoGroup = value;
                    OnPropertyChanged("Logo_Group");
                }
            }
        }

        public string LogoDescription
        {
            get
            {
                return _logoDescription;
            }
            set
            {
                if (_logoDescription != value)
                {
                    _logoDescription = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string LogoImagePath
        {
            get
            {
                return _logoImagePath;
            }
            set
            {
                if (_logoImagePath != value)
                {
                    _logoImagePath = value;
                    OnPropertyChanged("Logo_Image_Path");
                }
            }
        }

        public bool EightTool
        {
            get
            {
                return _eigth;
            }
            set
            {
                if (_eigth != value)
                {
                    _eigth = value;
                    OnPropertyChanged("1/8");
                }
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
