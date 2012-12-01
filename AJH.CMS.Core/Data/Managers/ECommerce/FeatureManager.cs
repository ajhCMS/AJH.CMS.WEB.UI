using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class FeatureManager
    {
        public static int Add(Feature feature)
        {
            return FeatureDataMapper.Add(feature);
        }

        public static void Update(Feature feature)
        {
            FeatureDataMapper.Update(feature);
        }

        public static void AddOtherLanguage(Feature feature)
        {
            FeatureDataMapper.AddOtherLanguage(feature);
        }

        public static void Delete(int id)
        {
            FeatureDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            FeatureDataMapper.DeleteLogical(id);
        }

        public static void AddProductFeature(int featureId, int productId, int productFeatureValue)
        {
            FeatureDataMapper.AddProductFeature(featureId, productId, productFeatureValue);
        }

        public static void DeleteProductFeature(int featureId, int productId)
        {
            FeatureDataMapper.DeleteProductFeature(featureId, productId);
        }

        public static List<Feature> GetFeatures(int languageID)
        {
            return FeatureDataMapper.GetFeatures(languageID);
        }

        public static Feature GetFeature(int id, int languageID)
        {
            return FeatureDataMapper.GetFeature(id, languageID);
        }

        public static List<Feature> GetFeaturesByProductId(int productID, int languageID)
        {
            return FeatureDataMapper.GetFeaturesByProductId(productID, languageID);
        }
    }
}