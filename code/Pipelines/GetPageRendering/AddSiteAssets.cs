namespace MyProject.Foundation.Assets.Pipelines.GetPageRendering
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using MyProject.Foundation.Assets.Models;
    using MyProject.Foundation.Assets.Repositories;
        using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
    using Sitecore.Mvc.Presentation;
    using Sitecore;
    using Sitecore.Mvc.Pipelines;
    using Sitecore.Data;
    using System.Linq;

    public class AddSiteAssets : MvcPipelineProcessor<MvcPipelineArgs>
    {
        public override void Process(MvcPipelineArgs args)
        {
            this.AddAssets(GetCurrentSiteItem());
        }

        protected void AddAssets(Item item)
        {
            AddScriptAssetsFromSite(item);
            AddStylingAssetsFromSite(item);
        }


        private static void AddScriptAssetsFromSite(Item item)
        {
            var javaScriptAssets = item[Templates.SiteAssets.Fields.SiteScriptFiles];
            foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
            {
                AssetRepository.Current.AddScriptFile(javaScriptAsset, ScriptLocation.Head, true);
            }
        }

        private static void AddStylingAssetsFromSite(Item item)
        {
            var cssAssets = item[Templates.SiteAssets.Fields.SiteStylingFiles];
            foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
            {
                AssetRepository.Current.AddStylingFile(cssAsset, true);
            }
        }

        

        private static Item GetCurrentSiteItem()
        {
           return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath).Parent;
        }
    }
}