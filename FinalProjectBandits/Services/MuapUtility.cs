using FinalProjectBandits.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBandits.Services
{
    public class MuapUtility
    {
        private const string muapServiceUri = "https://services2.arcgis.com/qvkbeam7Wirps6zC/arcgis/rest/services/Medically_Underserved_Areas_Population/FeatureServer/0/";
        private const string geoServiceRoot = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates";
        private static HttpClient httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }, false);

        public static bool IsAddressInMUAPArea(string singleLineFullAddress)
        {
            try
            {
                AddressLocation location = FindAddress(singleLineFullAddress);
                if (location != null)
                {

                    return localtionInMUAP(location);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

        private static AddressLocation FindAddress(string singleLineAddress)
        {
            AddressLocation location = null;
            string geoServiceUrl = geoServiceRoot + "?SingleLine=" + singleLineAddress + "&f=pjson";
            var responseMessage = httpClient.GetAsync(geoServiceUrl).Result;
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<GeoCodeResult>(responseBody);
            if (result != null && result.candidates.Length > 0)
            {
                Candidate candidate = result.candidates[0];

                location = new AddressLocation();
                location.spatialReference = result.spatialReference;
                location.x = candidate.location.x;
                location.y = candidate.location.y;
            }
            return location;
        }

        private static bool localtionInMUAP(AddressLocation location)
        {
            string locationJson = JsonConvert.SerializeObject(location);
            string featureServiceUri = muapServiceUri;
            featureServiceUri += "query?where=1=1&outFields=*";
            featureServiceUri += "&geometry=" + locationJson;
            featureServiceUri += "&geometryType=esriGeometryPoint";
            featureServiceUri += "&spatialRel=esriSpatialRelIntersects";
            featureServiceUri += "&resultType=standard";
            featureServiceUri += "&returnGeometry=false";
            featureServiceUri += "&f=pjson";


            var responseMessage = httpClient.GetAsync(featureServiceUri).Result;
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            var retVal = Newtonsoft.Json.JsonConvert.DeserializeObject<FeatureLayerObject>(responseBody);
            return retVal != null && retVal.features.Length > 0;
        }
    }
    public class AddressLocation
    {
        public float x { get; set; }
        public float y { get; set; }
        public Spatialreference spatialReference { get; set; }
    }

    #region Geocode related classes
    public class GeoCodeResult
    {
        public Spatialreference spatialReference { get; set; }
        public Candidate[] candidates { get; set; }
    }

    public class Spatialreference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    public class Candidate
    {
        public string address { get; set; }
        public Location location { get; set; }
        public float score { get; set; }
        public Attributes attributes { get; set; }
        public Extent extent { get; set; }
    }

    public class Location
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Attributes
    {
        public string Match_addr { get; set; }
        public string Addr_type { get; set; }
        public string StAddr { get; set; }
        public string City { get; set; }
    }

    public class Extent
    {
        public float xmin { get; set; }
        public float ymin { get; set; }
        public float xmax { get; set; }
        public float ymax { get; set; }
    }

    #endregion
}
