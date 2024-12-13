using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomainorderoptionsearchproducts
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainorderoptionsearchproducts ()
      {
         domain[(short)1] = "Name";
         domain[(short)2] = "Supplier";
         domain[(short)3] = "Brand";
         domain[(short)4] = "Sector";
         domain[(short)5] = "Stock";
         domain[(short)6] = "Cost Price";
         domain[(short)9] = "Registered";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Name"] = (short)1;
            domainMap["Supplier"] = (short)2;
            domainMap["Brand"] = (short)3;
            domainMap["Sector"] = (short)4;
            domainMap["Stock"] = (short)5;
            domainMap["CostPrice"] = (short)6;
            domainMap["Registered"] = (short)9;
         }
         return (short)domainMap[key] ;
      }

   }

}
