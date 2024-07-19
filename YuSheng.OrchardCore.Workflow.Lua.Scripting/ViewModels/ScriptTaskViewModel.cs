using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Lua.Scripting.ViewModels
{
    public class ScriptTaskViewModel
    {
        [Required]
        public string Script { get; set; }
    }
}
