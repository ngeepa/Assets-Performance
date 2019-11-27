namespace MyProject.Foundation.Assets.Pipelines.GetPageRendering
{
    using Sitecore;
    using Sitecore.Pipelines;
    using MyProject.Foundation.Assets.Models;
    using MyProject.Foundation.Assets.Repositories;
    using System.Linq;
    using System.Web.Optimization;
    using MyProject.Foundation.Assets.Services;
    using System.Web;

    public class UpdateBundle 
    {
        public virtual void Process(PipelineArgs args)
        {
            UpdateBundles(BundleTable.Bundles);
        }

        private void UpdateBundles(BundleCollection bundles)
        {

            var MyProjectHeadScriptsBundle = bundles.GetBundleFor("~/bundles/MyProjectHeadScriptsBundle");

            if (MyProjectHeadScriptsBundle == null)
                return;


            var listOfHeadJavascripts = AssetRepository.Current.Items
              .Where(asset => asset.Type == AssetType.JavaScript && asset.ContentType == AssetContentType.File && asset.Location == ScriptLocation.Head ).ToList();

            MyProjectHeadScriptsBundle.Include(listOfHeadJavascripts.Select(a => $"~/{a.Content}").ToArray<string>());


            var MyProjectBodyScriptsBundle = bundles.GetBundleFor("~/bundles/MyProjectBodyScriptsBundle");

            if (MyProjectBodyScriptsBundle == null)
                return;


            var listOfBodyJavascripts = AssetRepository.Current.Items
              .Where(asset => asset.Type == AssetType.JavaScript && asset.ContentType == AssetContentType.File && asset.Location == ScriptLocation.Body).ToList();

            MyProjectBodyScriptsBundle.Include(listOfBodyJavascripts.Select(a => $"~/{a.Content}").ToArray<string>());




            var MyProjectStylesBundle = bundles.GetBundleFor("~/bundles/MyProjectStylesBundle");

            if (MyProjectStylesBundle == null)
                return;


            var listOfStyles = AssetRepository.Current.Items
              .Where(asset => asset.Type == AssetType.Css && asset.ContentType == AssetContentType.File).ToList();

            MyProjectStylesBundle.Include(listOfStyles.Select(a => $"~/{a.Content}").ToArray<string>());

        }
    }
}