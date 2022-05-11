using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace HappyTravel.Komoro.Api.Infrastructure.Conventions;

public class ApiExplorerGroupConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var controllerNamespace = controller.ControllerType.Namespace;
        var controllerPurpose = controllerNamespace!.Split('.')
            .SkipLast(1)
            .Last();

        switch (controllerPurpose)
        {
            case "Api":
                controller.ApiExplorer.GroupName = "komoro";
                return;
            case "TravelClickChannelManager":
                controller.ApiExplorer.GroupName = "travelClick";
                return;
            case "TravelLineChannelManager":
                controller.ApiExplorer.GroupName = "travelLine";
                return;
        }
    }
}
