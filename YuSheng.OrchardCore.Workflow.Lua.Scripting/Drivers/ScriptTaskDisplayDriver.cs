using OrchardCore.Workflows.Display;
using OrchardCore.Workflows.Models;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.Activities;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.ViewModels;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting.Drivers
{
    public class ScriptTaskDisplayDriver : ActivityDisplayDriver<LuaScriptTask, YuShengScriptTaskViewModel>
    {
        protected override void EditActivity(LuaScriptTask source, YuShengScriptTaskViewModel model)
        {
            model.Script = source.Script.Expression;
        }

        protected override void UpdateActivity(YuShengScriptTaskViewModel model, LuaScriptTask activity)
        {
            activity.Script = new WorkflowExpression<object>(model.Script);
        }
    }
}
