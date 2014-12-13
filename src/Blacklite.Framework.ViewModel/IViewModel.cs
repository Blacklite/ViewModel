using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ApplicationModels;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Framework.OptionsModel;
using System;
using System.Linq;
using System.Reflection;

namespace Blacklite.Framework.ViewModel
{
    public interface IViewModel { }

    public interface IViewModelResolver
    {
        object Resolve<T>();
    }

    //public interface IViewModel<T> : IViewModel { }

    //public interface IViewModelProvider<in T, out TViewModel>
    //    where TViewModel : IViewModel
    //{
    //    TViewModel GetViewModel(T context);
    //}

    public class MetadataControllerActionDescriptorProvider : ControllerActionDescriptorProvider
    {
        public MetadataControllerActionDescriptorProvider(
            IAssemblyProvider assemblyProvider,
            IControllerModelBuilder applicationModelBuilder,
            IGlobalFilterProvider globalFilters,
            IOptions<MvcOptions> optionsAccessor,
            MetadataControllerModelBuilder metadataControllerModelBuilder)
            : base(assemblyProvider, applicationModelBuilder, globalFilters, optionsAccessor)
        {
        }

        new ApplicationModel BuildModel()
        {
            var applicationModel = base.BuildModel();



            return applicationModel;
        }
    }

    public class MetadataControllerModelBuilder : DefaultControllerModelBuilder
    {
        public MetadataControllerModelBuilder(IActionModelBuilder actionModelBuilder)
            : base (actionModelBuilder)
        {

        }

        protected override bool IsController([NotNull]TypeInfo typeInfo)
        {
            return typeof(GenericController).IsAssignableFrom(typeInfo.AsType());
        }

        protected override ControllerModel CreateControllerModel([NotNull]TypeInfo typeInfo)
        {
            var controllerModel = base.CreateControllerModel(typeInfo);

            var builtInActions = controllerModel.Actions.Where(x => x.ActionName == "GetGeneric" || x.ActionName == "PostGeneric");
            foreach (var action in builtInActions)
            {
                controllerModel.Actions.Remove(action);
            }




            return controllerModel;
        }
    }
}
