using FinalProjectBandits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinalProjectBandits.Services
{
    public class FeatureServiceClient
    {
        private const string arcgisServer = "https://services2.arcgis.com";
        private const string featureServiceUri = "/qvkbeam7Wirps6zC/arcgis/rest/services/" +
                "Medically_Underserved_Areas_Population/FeatureServer/0/" +
                "query?where=1%3D1&objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope" +
                "&inSR=&spatialRel=esriSpatialRelIntersects&resultType=none&distance=0.0" +
                "&units=esriSRUnit_Meter&returnGeodetic=false&outFields=*" +
                "&returnGeometry=true&returnCentroid=false&featureEncoding=esriDefault" +
                "&multipatchOption=xyFootprint&maxAllowableOffset=&geometryPrecision=&outSR=" +
                "&datumTransformation=&applyVCSProjection=false&returnIdsOnly=false" +
                "&returnUniqueIdsOnly=false&returnCountOnly=false&returnExtentOnly=false" +
                "&returnQueryGeometry=false&returnDistinctValues=false&cacheHint=false" +
                "&orderByFields=&groupByFieldsForStatistics=&outStatistics=&having=" +
                "&resultOffset=&resultRecordCount=&returnZ=false&returnM=false" +
                "&returnExceededLimitFeatures=true&quantizationParameters=&sqlFormat=none&f=pjson&token=";
        private HttpClient httpClient;
        public FeatureServiceClient()
        {
            httpClient = new HttpClient(new HttpClientHandler
            {
                UseDefaultCredentials = true
            }, false)
            {
                BaseAddress = new Uri(arcgisServer)
            };
        }

        public FeatureLayerObject ReadMUAPFeatures()
        {
            var responseMessage = httpClient.GetAsync(featureServiceUri).Result;
            var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            var retVal = Newtonsoft.Json.JsonConvert.DeserializeObject<FeatureLayerObject>(responseBody);
            return retVal;
        }
    }
}
