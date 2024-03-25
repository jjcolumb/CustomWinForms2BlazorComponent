using CustomBlazorComponent.Module.BusinessObjects;
using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBlazorComponent.Blazor.Server.Controllers
{
    public partial class ShowFormPopup : ViewController
    {
        PopupWindowShowAction OpenForm;
        public ShowFormPopup()
        {
            InitializeComponent();
            OpenForm = new PopupWindowShowAction(this, "OpenForm", PredefinedCategory.Edit)
            {
                Caption = "Open Form"
            };
            OpenForm.CustomizePopupWindowParams += OpenForm_CustomizePopupWindowParams;
            OpenForm.Execute += OpenForm_Execute;
        }

        private void OpenForm_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            AcquistoArticoli currentElement = e.PopupWindowView.CurrentObject as AcquistoArticoli;
        }

        private void OpenForm_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace obs = Application.CreateObjectSpace(typeof(AcquistoArticoli));
            AcquistoArticoli componentInstance = obs.CreateObject<AcquistoArticoli>();

            DetailView articoliView = Application.CreateDetailView(obs, "AcquistoArticoli_DetailView", false, componentInstance);
            e.View = articoliView;
            e.Maximized = true;
        }

    }
}
