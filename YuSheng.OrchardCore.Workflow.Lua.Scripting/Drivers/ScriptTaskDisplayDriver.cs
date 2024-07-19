using OrchardCore.Workflows.Display;
using OrchardCore.Workflows.Models;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.Activities;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.ViewModels;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting.Drivers
{
    public class ScriptTaskDisplayDriver : ActivityDisplayDriver<LuaScriptTask, ScriptTaskViewModel>
    {
        protected override void EditActivity(LuaScriptTask source, ScriptTaskViewModel model)
        {
            model.Script = source.Script.Expression;
        }

        protected override void UpdateActivity(ScriptTaskViewModel model, LuaScriptTask activity)
        {
            activity.Script = new WorkflowExpression<object>(model.Script);
        }
    }
}
