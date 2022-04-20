using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RunRent.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/open-iconic-bootstrap/css")
            .Include("~/fonts/css/open-iconic-bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/animate/css")
            .Include("~/fonts/css/animate.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/carousel/css")
            .Include("~/fonts/css/owl.carousel.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/bundles/theme.default/css")
            .Include("~/fonts/css/owl.theme.default.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/bundles/magnific-popup/css")
           .Include("~/fonts/css/magnific-popup.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/aos/css")
           .Include("~/fonts/css/aos.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/ionicons/css")
           .Include("~/fonts/css/ionicons.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-datepicker/css")
           .Include("~/fonts/css/bootstrap-datepicker.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery.timepicker/css")
           .Include("~/fonts/css/jquery.timepicker.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/flaticon/css")
            .Include("~/fonts/css/flaticon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/icomoon/css")
           .Include("~/fonts/css/icomoon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css")
            .Include("~/fonts/css/style.css", new CssRewriteUrlTransform()));
         
            
            bundles.Add(new StyleBundle("~/bundles/styleform/css")
   .Include("~/fonts/css/styleform.css", new CssRewriteUrlTransform()));





            bundles.Add(new ScriptBundle("~/bundles/jquery/js")
            .Include("~/Scripts/js/jquery.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery-migrate/js")
           .Include("~/Scripts/js/jquery-migrate-3.0.1.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/poper/js")
           .Include("~/Scripts/js/popper.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/main/js")
          .Include("~/Scripts/js/main.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js")
         .Include("~/Scripts/js/bootstrap.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery.easing/js")
         .Include("~/Scripts/js/jquery.easing.1.3.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery.waypoints/js")
         .Include("~/Scripts/js/jquery.waypoints.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery.stellar/js")
         .Include("~/Scripts/js/jquery.stellar.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/carousel/js")
         .Include("~/Scripts/js/owl.carousel.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery.magnific-popup/js")
        .Include("~/Scripts/js/jquery.magnific-popup.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/aos/js")
        .Include("~/Scripts/js/aos.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery.animateNumber/js")
        .Include("~/Scripts/js/jquery.animateNumber.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker/js")
        .Include("~/Scripts/js/bootstrap-datepicker.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery.timepicker/js")
        .Include("~/Scripts/js/jquery.timepicker.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/scrollax/js")
        .Include("~/Scripts/js/scrollax.min.js", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/google-map/js")
        .Include("~/Scripts/js/google-map.js", new CssRewriteUrlTransform()));
          
            
            bundles.Add(new ScriptBundle("~/bundles/index/js")
       .Include("~/Scripts/js/index.js", new CssRewriteUrlTransform()));



        }

    }
}