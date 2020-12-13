using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Services
{
    public interface ICombinedAPIService
    {
        Task<CombinedAPIObject> GetCombinedObject(string address);
        bool IsPointInPolygon(CoordinatePoint point, List<CoordinatePoint> polygon);

    }

    public class CombinedAPIService : ICombinedAPIService
    {
        private IMUAPService _muapService;
        private IGeocodingService _geocodingService;
        private const string _allData = "1%3D1";

        public CombinedAPIService(IMUAPService muapService, IGeocodingService geocodingService)
        {
            _muapService = muapService;
            _geocodingService = geocodingService;
        }

        public async Task<CombinedAPIObject> GetCombinedObject(string address)
        {
            var muapResults = await _muapService.GetMUAPResults(_allData);
            var geocodingResults = await _geocodingService.GetGeocodingResults(address);
            foreach (var feature in muapResults.Features)
            {
                feature.Geometry.FlattenRings();
            }

            var combinedAPIObject = new CombinedAPIObject() { GeocodingObject = geocodingResults, MUAPObject = muapResults };
            return combinedAPIObject;
        }
        
        public bool IsPointInPolygon(CoordinatePoint point, List<CoordinatePoint> polygon)
        {
            double minX = polygon[0].Longitude;
            //double minX = polygon.CoordinateSet.Select(_ => _.Coordinates.Min(x => x.Longitude)).First();
            double maxX = polygon[0].Longitude;
            //double maxX = polygon.CoordinateSet.Select(_ => _.Coordinates.Max(x => x.Longitude)).First();double minX = polygon[0].Coordinates[0].Longitude;
            double minY = polygon[0].Latitude;
            //double minY = polygon.CoordinateSet.Select(_ => _.Coordinates.Min(x => x.Latitude)).First();
            double maxY = polygon[0].Latitude;
            //double maxY = polygon.CoordinateSet.Select(_ => _.Coordinates.Max(x => x.Latitude)).First();
            for (int i = 1; i < polygon.Count; i++)
            {
                var q = polygon.ElementAt(i);

                //for (int k = 0; k < q.Coordinates.Count; k++)
                //{
                    minX = Math.Min(q.Longitude, minX);
                    maxX = Math.Max(q.Longitude, maxX);
                    minY = Math.Min(q.Latitude, minY);
                    maxY = Math.Max(q.Latitude, maxY);
                //}


            }

            if (point.Longitude < minX || point.Longitude > maxX || point.Latitude < minY || point.Latitude > maxY)
            {
                return false;
            }

            // https://wrf.ecse.rpi.edu/Research/Short_Notes/pnpoly.html
            bool inside = false;
            //for (int i = 0; i < polygon.Count; i++)

            //{
            //    var q = polygon.CoordinateSet.ElementAt(k);
                for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
                {

                    if ((polygon[i].Latitude > point.Latitude) != (polygon[j].Latitude > point.Latitude) &&
                         point.Longitude < (polygon[j].Longitude - polygon[i].Longitude) * (point.Latitude - polygon[i].Latitude) / (polygon[j].Latitude - polygon[i].Latitude) + polygon[i].Longitude) 
                    {
                        inside = !inside;
                    }
                }
            //}

            return inside;
        }
        
    }


    public class CombinedAPIObject
    {
        public GeocodingObject GeocodingObject { get; set; }
        public MUAPObject MUAPObject { get; set; }
        
    }

}
