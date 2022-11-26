using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace CustomAddon
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create Ribbon Tab
            application.CreateRibbonTab("CPAC BIM");

            string path = Assembly.GetExecutingAssembly().Location;
            RibbonPanel commandPanel = application.CreateRibbonPanel("CPAC BIM", "Commands");
            RibbonPanel familyPanel = application.CreateRibbonPanel("CPAC BIM", "Family Document");

            //Retrive Images
            //ID Icon
            Uri idImgPath = new Uri(@"C:\Users\CHATPONG\Desktop\Programing Learning\CsharpRevitAPI\AddOn\RevitCustomAddIn\CustomAddon\Sources\img\idImg.png");
            BitmapImage bitmapId = new BitmapImage(idImgPath);
            //Save Icon
            Uri saveImgPath = new Uri(@"C:\Users\CHATPONG\Desktop\Programing Learning\CsharpRevitAPI\AddOn\RevitCustomAddIn\CustomAddon\Sources\img\SaveIcon.png");
            BitmapImage bitmapSave = new BitmapImage(saveImgPath);
            //Save As Icon
            Uri saveAsImgPath = new Uri(@"C:\Users\CHATPONG\Desktop\Programing Learning\CsharpRevitAPI\AddOn\RevitCustomAddIn\CustomAddon\Sources\img\SaveAsIcon.png");
            BitmapImage bitmapSaveAs = new BitmapImage(saveAsImgPath);

            //Get Element id 
            PushButtonData GetEleIdButton = new PushButtonData("Button1", "Element \n ID", path, "CustomAddon.GetElementId");
            PushButton GetEleIdPushButton = commandPanel.AddItem(GetEleIdButton) as PushButton;
            GetEleIdPushButton.LargeImage = bitmapId;
            GetEleIdPushButton.ToolTip = "Get id from selected element";

            //Save Add prefix-name file by get Omniclass title
            PushButtonData saveWithOmniNameButton = new PushButtonData("Button2", "Save", path, "CustomAddon.SaveWithOmniName");
            PushButton saveWithOmniNamePushBotton = familyPanel.AddItem(saveWithOmniNameButton) as PushButton;
            saveWithOmniNamePushBotton.LargeImage = bitmapSave;
            saveWithOmniNamePushBotton.ToolTip = "Save file with omniclass title prefix";

            //Save as add prefix-name file by get Omniclass title
            PushButtonData saveAsOmniName = new PushButtonData("Button3", "Save As", path, "CustomAddon.SaveAsWithOmniName");
            PushButton saveAsOmniNamePushBotton = familyPanel.AddItem(saveAsOmniName) as PushButton;
            saveAsOmniNamePushBotton.LargeImage = bitmapSaveAs;
            saveAsOmniNamePushBotton.ToolTip = "Save as file by select folder with omniclass title prefix";
            
           

            return Result.Succeeded;
        }
    }
}
