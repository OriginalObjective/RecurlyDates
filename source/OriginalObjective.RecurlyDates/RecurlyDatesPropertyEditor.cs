using ClientDependency.Core;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace OriginalObjective.RecurlyDates
{
    [PropertyEditor("OriginalObjective.RecurlyDates", "Original Objective: Recurly Dates", "/App_Plugins/OriginalObjective.RecurlyDates/Editor.html", ValueType = "JSON")]
    [PropertyEditorAsset(ClientDependencyType.Javascript, "/App_Plugins/OriginalObjective.RecurlyDates/Editor.js")]
    [PropertyEditorAsset(ClientDependencyType.Css, "/App_Plugins/OriginalObjective.RecurlyDates/Editor.css")]
    public class RecurlyDatesPropertyEditor : PropertyEditor
    {
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new RecurlyDatesPreValueEditor();
        }
    }
}