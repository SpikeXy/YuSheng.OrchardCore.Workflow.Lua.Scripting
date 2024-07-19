using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting.ViewModels
{
    public class YuShengScriptTaskViewModel
    {
        [Required]
        public string Script { get; set; }
    }
}
