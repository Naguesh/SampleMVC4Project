﻿using System.Web;
using System.Web.Optimization;

namespace TimesheetWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.mobile-1.3.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/jquery.tablesorter.min.js",
                        "~/Scripts/jquery.jqplot.min.js",
                        "~/Scripts/jqplot.barRenderer.min.js",
                        "~/Scripts/jqplot.categoryAxisRenderer.min.js",
                        "~/Scripts/site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/jquery.mobile-1.3.2.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/styles.css",
                      "~/Content/site.css",
                      "~/Content/jquery.jqplot.min.css"));

        }
    }
}