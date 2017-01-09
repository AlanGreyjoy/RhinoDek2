using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System.Threading;

namespace RhinoDek2
{
    [System.Runtime.InteropServices.Guid("a2d45494-fcad-4075-bdb9-c48b30a3eb9e")]
    public class RhinoDek2Command : Command
    {
        public RhinoDek2Command()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static RhinoDek2Command Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "2RhinoDek2Command"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show(Rhino.RhinoApp.MainApplicationWindow);

            return Result.Success;
        }
    }
}
