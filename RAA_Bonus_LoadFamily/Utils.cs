using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAA_Bonus_LoadFamily
{
    internal class Utils
    {
        internal static bool IsFamilyLoaded(Document doc, string familyName)
        {
            List<Family> famList = GetAllFamilies(doc);

            foreach (Family curFam in famList)
            {
                if (curFam.Name == familyName)
                    return true;
            }

            return false;
        }

        private static List<Family> GetAllFamilies(Document doc)
        {
            List<Family> returnList = new List<Family>();

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Family));

            foreach(Element curElem in collector)
            {
                Family curFam = curElem as Family; 
                returnList.Add(curFam);
            }

            return returnList;
        }
    }
}
