using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SampleProject.Domain.Models;

namespace SampleProject.API.Configuration;

public static class ODataConfiguration
{
    public static IMvcBuilder ConfigureOData(this IMvcBuilder mvcBuilder)
    {
        var modelBuilder = new ODataConventionModelBuilder();

        modelBuilder.EntitySet<Company>("Company");
        modelBuilder.EntitySet<Employee>("Employee");

        mvcBuilder.AddOData(
            options => options
                .Select()
                .Filter()
                .OrderBy()
                .Expand()
                .Count()
                .SetMaxTop(null)
                .EnableQueryFeatures()
                .AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel())
                );

        return mvcBuilder;
    }
}