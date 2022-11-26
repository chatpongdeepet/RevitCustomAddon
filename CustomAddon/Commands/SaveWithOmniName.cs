using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Reflection;

namespace CustomAddon
{
    [TransactionAttribute(TransactionMode.Manual)]
    internal class SaveWithOmniName : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get Document
            Document doc = uidoc.Document;

            try 
            {
                //Retrived File path and Document title
                string path = doc.PathName;
                string docTitle = doc.Title;
                string ext = Path.GetExtension(path);


                //Get Family from Document 
                Family thisFamily = null;
                if (doc.IsFamilyDocument == true)
                {
                    thisFamily = doc.OwnerFamily;
                }
                if (thisFamily != null)
                {
                    Parameter parOmniclass = thisFamily.get_Parameter(BuiltInParameter.OMNICLASS_DESCRIPTION);

                    //New Name
                    string newDocName = parOmniclass.AsString() + "_" + docTitle;
                    string newPath = path.Replace(docTitle, newDocName);
                    string savePath = newPath;

                    TaskDialog.Show("Info", savePath);

                    //Save Document
                    //Git Test
                    doc.SaveAs(savePath);
                }

                return Result.Succeeded;
            } catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
