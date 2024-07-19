using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "YuSheng OrchardCore Workflow Lua Scripting",
    Author = "spike",
    Website = "",
    Version = "0.0.1"
)]

[assembly: Feature(
    Id = "YuSheng OrchardCore Workflow Lua Scripting",
    Name = "YuSheng OrchardCore Workflow Lua Scripting",
    Description = "Provides lua scripting ",
    Dependencies = new[] { "OrchardCore.Workflows" },
    Category = "Workflows"
)]
