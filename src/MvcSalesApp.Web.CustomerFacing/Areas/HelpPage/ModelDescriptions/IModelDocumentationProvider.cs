using System;
using System.Reflection;

namespace MvcSalesApp.Web.CustomerFacing.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}