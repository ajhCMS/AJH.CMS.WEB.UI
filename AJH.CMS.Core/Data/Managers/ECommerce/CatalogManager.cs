﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class CatalogManager
    {
        public static int Add(Catalog catalog)
        {
            return CatalogDataMapper.Add(catalog);
        }

        public static void Update(Catalog catalog)
        {
            CatalogDataMapper.Update(catalog);
        }

        public static void AddOtherLanguage(Catalog catalog)
        {
            CatalogDataMapper.AddOtherLanguage(catalog);
        }

        public static void Delete(int id)
        {
            CatalogDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            CatalogDataMapper.DeleteLogical(id);
        }

        public static void AddProductCatalog(int prodcutId, int catalogId, int productOrder)
        {
            CatalogDataMapper.AddProductCatalog(prodcutId, catalogId, productOrder);
        }

        public static void DeleteProductCatalog(int prodcutId, int catalogId)
        {
            CatalogDataMapper.DeleteProductCatalog(prodcutId, catalogId);
        }

        public static void DeleteProductCatalogByProductID(int prodcutId)
        {
            CatalogDataMapper.DeleteProductCatalogByProductID(prodcutId);
        }

        public static List<Catalog> GetCatalogs(int portalID, int languageID)
        {
            return CatalogDataMapper.GetCatalogs(portalID, languageID);
        }

        public static Catalog GetCatalog(int id, int languageID)
        {
            return CatalogDataMapper.GetCatalog(id, languageID);
        }

        public static List<Catalog> GetCatalogsByProductID(int productID, int portalID, int languageID)
        {
            return CatalogDataMapper.GetCatalogsByProductID(productID, portalID, languageID);
        }

        public static string GetCatalogXMLPath(string CatalogPath, int portalID, int languageID)
        {
            if (!File.Exists(CatalogPath))
            {
                XmlDocument xmlDoc = new XmlDocument();

                XmlElement xmlRoot = xmlDoc.CreateElement("Catalogs");
                xmlDoc.AppendChild(xmlRoot);

                List<Catalog> Catalogs = GetCatalogs(portalID, languageID);
                List<Catalog> parentCatalogs = Catalogs != null ? Catalogs.Where(m => m.ParentCalalogID == 0).ToList() : null;
                if (parentCatalogs != null)
                    foreach (Catalog item in parentCatalogs)
                    {
                        XmlElement xmlEle = xmlDoc.CreateElement("Catalog");
                        xmlRoot.AppendChild(xmlEle);
                        SetAttributeCatalogNode(xmlDoc, xmlEle, item);
                        SetElementChildCatalog(xmlDoc, xmlEle, Catalogs, item.ID);
                    }

                XmlWriter xmlWriter = XmlWriter.Create(CatalogPath);
                xmlDoc.WriteTo(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            return CatalogPath;
        }

        private static void SetElementChildCatalog(XmlDocument xmlDoc, XmlElement xmlParent, List<Catalog> Catalogs, int ParentCatalogID)
        {
            List<Catalog> childsCatalog = Catalogs.Where(m => m.ParentCalalogID == ParentCatalogID).ToList();
            foreach (Catalog item in childsCatalog)
            {
                XmlElement xmlEle = xmlParent.OwnerDocument.CreateElement("SubCatalog");
                xmlParent.AppendChild(xmlEle);
                SetAttributeCatalogNode(xmlDoc, xmlEle, item);
                SetElementChildCatalog(xmlDoc, xmlEle, Catalogs, item.ID);
            }
        }

        public static XmlDocument GenerateCatalogXmlDoc(Catalog catalog)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement xmlRoot = xmlDoc.CreateElement("Catalogs");
            xmlDoc.AppendChild(xmlRoot);

            XmlElement xmlEle = xmlDoc.CreateElement("Catalog");
            xmlRoot.AppendChild(xmlEle);
            SetAttributeCatalogNode(xmlDoc, xmlEle, catalog);

            return xmlDoc;
        }

        private static void SetAttributeCatalogNode(XmlDocument xmldoc, XmlElement xmlEle, Catalog CatalogItem)
        {
            XmlAttribute xmlAtt = xmlEle.OwnerDocument.CreateAttribute("ID");
            xmlAtt.Value = CatalogItem.ID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Name");
            xmlAtt.Value = CatalogItem.Name;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("ParentID");
            xmlAtt.Value = CatalogItem.ParentCalalogID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Description");
            xmlAtt.Value = CatalogItem.Description;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("IsPublishedCatalog");
            xmlAtt.Value = CatalogItem.IsPublished.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            List<CatalogImage> catalogImages = CatalogImageManager.GetCatalogImagesByCatalogID(CatalogItem.ID);
            if (catalogImages != null && catalogImages.Count > 0)
            {
                foreach (CatalogImage catalogImage in catalogImages)
                {
                    XmlElement imageElement = xmldoc.CreateElement("CatalogImage");
                    XmlAttribute attri = xmldoc.CreateAttribute("ID");

                    attri.Value = catalogImage.ID.ToString();
                    imageElement.Attributes.Append(attri);

                    attri = xmldoc.CreateAttribute("IsCoverImage");
                    attri.Value = catalogImage.IsCoverImage.ToString();
                    imageElement.Attributes.Append(attri);

                    attri = xmldoc.CreateAttribute("ImageName");
                    attri.Value = catalogImage.Image;
                    imageElement.Attributes.Append(attri);

                    xmlEle.AppendChild(imageElement);
                }
            }
        }
    }
}