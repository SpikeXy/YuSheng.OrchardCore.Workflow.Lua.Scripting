using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Activities;
using OrchardCore.Workflows.Models;
using OrchardCore.Workflows.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NLua;
using KeraLua;
using Newtonsoft.Json;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting.Activities
{
    public class LuaScriptTask : TaskActivity
    {

        private readonly IWorkflowScriptEvaluator _scriptEvaluator;
        private readonly IStringLocalizer S;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IWorkflowExpressionEvaluator _expressionEvaluator;
        public LuaScriptTask(IWorkflowScriptEvaluator scriptEvaluator,
            IWorkflowExpressionEvaluator expressionEvaluator,
            IHtmlHelper htmlHelper,
            IStringLocalizer<LuaScriptTask> localizer)
        {
            _scriptEvaluator = scriptEvaluator;
            _expressionEvaluator = expressionEvaluator;
            S = localizer;
            _htmlHelper = htmlHelper;

        }

        public override string Name => nameof(LuaScriptTask);

        public override LocalizedString DisplayText => S["Lua Script Task"];

        public override LocalizedString Category => S["Script"];


        /// <summary>
        /// 
        /// </summary>
        public WorkflowExpression<object> Script
        {
            get => GetProperty(() => new WorkflowExpression<object>());
            set => SetProperty(value);
        }

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            return Outcomes(S["Success"], S["Failed"]);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            return await Task.Run(() =>
            {
                var script = Script.Expression;
                var isSuccess = true;
                var code = "";
                if (!string.IsNullOrEmpty(script))
                {
                    try
                    {
                        using (NLua.Lua state = new NLua.Lua())
                        {
                            object[] results = state.DoString(script);
                            if (results.Length > 0)
                            {
                                code = JsonConvert.SerializeObject(results);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        code = ex.Message;
                        isSuccess = false;
                    }
                }
                else
                {
                    code = "script content is null";
                }

                workflowContext.Output["LuaScript"] = _htmlHelper.Raw(_htmlHelper.Encode(code));

                if (isSuccess)
                {
                    return Outcomes("Success");
                }
                else
                {
                    return Outcomes("Failed");
                }
            });
        }
    }
}
