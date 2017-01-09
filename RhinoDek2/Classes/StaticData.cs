using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RhinoDek2.Classes
{
    class StaticData
    {
        //Connection String\\
        public static string SQL_ConnectionString
        {
            get
            {
                return @"Server=engsrv\sigmanest;Database=rhinodek;User Id=SNUser;Password=bestnest1445;";
            }
        }

        //Textures\\
        public static string Texture
        {
            get; set;
        }

        //Colors\\
        public static string OneSheetColor
        {
            get; set;
        }

        public static string ColorSuffix
        {
            get; set;
        }

        public static string TopSheetColor
        {
            get; set;
        }

        public static string MiddleSheetColor
        {
            get; set;
        }

        public static string BottomSheetColor
        {
            get; set;
        }

        public static int OneSheetMM
        {
            get; set;
        }

        public static bool SinglePly
        {
            get; set;
        }

        public static bool DoublePly
        {
            get; set;
        }

        public static bool TripplePly
        {
            get; set;
        }

        public static bool IsTBD
        {
            get; set;
        }

        public static string Adhesion
        {
            get; set;
        }
        
        public static string EdgeStyle
        {
            get; set;
        }

        public static string LogoStyle
        {
            get; set;
        }

        public static string ColorLaminateStyle
        {
            get; set;
        }

        //MM\\
        public static int TopSheetMM
        {
            get; set;
        }

        public static int MiddleSheetMM
        {
            get; set;
        }

        public static int BottomSheetMM
        {
            get; set;
        }

        public static int OverallMM
        {
            get; set;
        }

        //Paths\\
        public static string SaveProjectPath
        {
            get; set;
        }

        //Change Theme\\
        public static string ChangeTheme
        {
            get; set;
        }

        //Page\\
        public static string Page
        {
            get;set;
        }

        //CAD Folders\\
        public static string[] CAD_Folders
        {
            get; set;
        }

        //Logo Groups\\
        public static List<string> Logo_Group_Names
        {
            get; set;
        }

        public static DataTable Get_Logo_Details
        {
            get; set;
        }
    }
}
