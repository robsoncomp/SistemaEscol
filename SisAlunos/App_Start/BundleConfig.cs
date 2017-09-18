﻿using System.Web.Optimization;

namespace SisAlunos
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/GridJs").Include(
                "~/Scripts/jquery-2.1.3.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/grid-0.4.3.min.js"));

            bundles.Add(new StyleBundle("~/Content/GridCss").Include(
                    "~/Content/bootstrap.min.csss",
                    "~/Content/bootstrap-theme.min.css", 
                    "~/Content/grid-0.4.3.min.css"));


                //< link href = "~/Content/bootstrap.min.css" rel = "stylesheet" type = "text/css" >
     
                //< link href = "~/Content/bootstrap-theme.min.css" rel = "stylesheet" type = "text/css" >
          
                //< link href = "~/Content/grid-0.4.3.min.css" rel = "stylesheet" type = "text/css" >
               

                //< script src = "~/Scripts/jquery-2.1.3.min.js" type = "text/javascript" ></ script >
                  
                //< script src = "~/Scripts/bootstrap.min.js" type = "text/javascript" ></ script >
                     
                //< script src = "~/Scripts/grid-0.4.3.min.js" type = "text/javascript" ></ script >



        }
    }
}
