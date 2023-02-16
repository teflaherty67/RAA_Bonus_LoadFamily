#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAA_Bonus_LoadFamily
{
    [Transaction(TransactionMode.Manual)]
    public class cmdLoadFamily : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            string familyName = "Test Family";
            string familySymbolName = "Type 1";
            string familyPath = @"C:\temp\Test Family.rfa";
            XYZ insPoint = new XYZ(0, 0, 0);

            // is family loaded, if not, load it

            if(Utils.IsFamilyLoaded(doc, familyName) == false)
            {
                if (doc.LoadFamily(familyPath) == true)
                    TaskDialog.Show("Load Family", "Loaded family: " + familyName);
                else
                {
                    TaskDialog.Show("Load Family", "Could not load family");
                    return Result.Failed;
                }
            }

            // get family object

            

            // does family have symbol, if not, create it

            // insert family

            return Result.Succeeded;
        }
    }
}
