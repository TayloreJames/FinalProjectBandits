using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Models
{
    public class FeatureLayerObject
    {
        public string objectIdFieldName { get; set; }
        public Uniqueidfield uniqueIdField { get; set; }
        public string globalIdFieldName { get; set; }
        public Geometryproperties geometryProperties { get; set; }
        public string geometryType { get; set; }
        public Spatialreference spatialReference { get; set; }
        public Field[] fields { get; set; }
        public Feature[] features { get; set; }
    }

    public class Uniqueidfield
    {
        public string name { get; set; }
        public bool isSystemMaintained { get; set; }
    }

    public class Geometryproperties
    {
        public string shapeAreaFieldName { get; set; }
        public string shapeLengthFieldName { get; set; }
        public string units { get; set; }
    }

    public class Spatialreference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public string sqlType { get; set; }
        public int length { get; set; }
        public object domain { get; set; }
        public object defaultValue { get; set; }
    }

    public class Feature
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Attributes
    {
        public string funcstat_10 { get; set; }
        public int statefp_10 { get; set; }
        public int countyfp_10 { get; set; }
        public float shape_area { get; set; }
        public string muap { get; set; }
        public long date_updat { get; set; }
        public int awater_10 { get; set; }
        public float muap_index { get; set; }
        public string srvc_area { get; set; }
        public float shape_leng { get; set; }
        public long geoid_10 { get; set; }
        public int name_10 { get; set; }
        public float intptlon_10 { get; set; }
        public long muap_date { get; set; }
        public int aland_10 { get; set; }
        public int tractce_10 { get; set; }
        public string namelsad_10 { get; set; }
        public float intptlat_10 { get; set; }
        public string mtfcc_10 { get; set; }
        public int ObjectId { get; set; }
        public float Shape__Area { get; set; }
        public float Shape__Length { get; set; }
    }

    public class Geometry
    {
        public float[][][] rings { get; set; }
    }
}
