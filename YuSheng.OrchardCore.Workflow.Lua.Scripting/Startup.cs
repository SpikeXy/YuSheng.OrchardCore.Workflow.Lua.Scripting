using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Workflows.Helpers;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.Activities;
using YuSheng.OrchardCore.Workflow.Lua.Scripting.Drivers;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting
{
    [Feature("YuSheng.OrchardCore.Workflow.Lua.Scripting")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddActivity<LuaScriptTask, ScriptTaskDisplayDriver>(); ;


        }
    }
}
