namespace MyProject.Foundation.Assets.Pipelines.Initialize
{
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Pipelines;
    using System.Web.Optimization;

    public class BundleAssets
    {        
        public virtual void Process(PipelineArgs args)
        {
            RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/MyProjectHeadScriptsBundle"));
            bundles.Add(new ScriptBundle("~/bundles/MyProjectBodyScriptsBundle"));

            bundles.Add(new StyleBundle("~/bundles/MyProjectStylesBundle"));


            string bundleAndMinify= Settings.GetSetting("MyProject.Foundation.Assets.BundleAndMinify");
            BundleTable.EnableOptimizations = bundleAndMinify.ToLower().Equals("true");

        }
    }
}