using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBandits.Models;
using FinalProjectBandits.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBandits.Controllers
{
    public class MUAPFeatureController : Controller
    {
        // GET: MUAPFeature
        public ActionResult Index()
        {
            FeatureServiceClient client = new FeatureServiceClient();
            FeatureLayerObject featureLayer = client.ReadMUAPFeatures();
            foreach (Feature feature in featureLayer.features)
            {
                MedicallyUnderservedArea area = new MedicallyUnderservedArea();
                area.FuncStat10 = feature.attributes.funcstat_10;
                area.StateFp10 = feature.attributes.statefp_10;
                area.CountyFp10 = feature.attributes.countyfp_10;
                area.ShapeArea = feature.attributes.shape_area;
                area.Muap = feature.attributes.muap;
                area.DateUpdate = feature.attributes.date_updat;
                area.Awater10 = feature.attributes.awater_10;
                area.MuapIndex = feature.attributes.muap_index;
                area.SrvcArea = feature.attributes.srvc_area;
                area.ShapeLeng = feature.attributes.shape_leng;
                area.GeoId10 = feature.attributes.geoid_10;
                area.Name10 = feature.attributes.name_10;
                area.Intptlon = feature.attributes.intptlon_10;
                area.MuapDate = feature.attributes.muap_date;
                area.Aland10 = feature.attributes.aland_10;
                area.Tractce10 = feature.attributes.tractce_10;
                area.NameLsad10 = feature.attributes.namelsad_10;
                area.Intptlat10 = feature.attributes.intptlat_10;
                area.Mtfcc10 = feature.attributes.mtfcc_10;
                area.ObjectId = feature.attributes.ObjectId;
                area.ShapeAreaA = feature.attributes.Shape__Area;
                area.ShapeLengthA = feature.attributes.Shape__Length;

                Console.WriteLine(feature.attributes.ObjectId);
            }
            return View();
        }

        // GET: MUAPFeature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MUAPFeature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MUAPFeature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MUAPFeature/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MUAPFeature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MUAPFeature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MUAPFeature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
