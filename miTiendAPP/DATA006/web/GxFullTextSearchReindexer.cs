using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new SdtPaymentMethod(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtRole(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtInvoice(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtUser(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtProduct(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtSupplier(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPurchaseOrder(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPermission(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
