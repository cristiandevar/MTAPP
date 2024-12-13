using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class productcostpriceroundvalue : GXProcedure
   {
      public productcostpriceroundvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productcostpriceroundvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref decimal aP0_ProductCostPrice )
      {
         this.AV8ProductCostPrice = aP0_ProductCostPrice;
         initialize();
         executePrivate();
         aP0_ProductCostPrice=this.AV8ProductCostPrice;
      }

      public decimal executeUdp( )
      {
         execute(ref aP0_ProductCostPrice);
         return AV8ProductCostPrice ;
      }

      public void executeSubmit( ref decimal aP0_ProductCostPrice )
      {
         productcostpriceroundvalue objproductcostpriceroundvalue;
         objproductcostpriceroundvalue = new productcostpriceroundvalue();
         objproductcostpriceroundvalue.AV8ProductCostPrice = aP0_ProductCostPrice;
         objproductcostpriceroundvalue.context.SetSubmitInitialConfig(context);
         objproductcostpriceroundvalue.initialize();
         Submit( executePrivateCatch,objproductcostpriceroundvalue);
         aP0_ProductCostPrice=this.AV8ProductCostPrice;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productcostpriceroundvalue)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_decimal1 = AV8ProductCostPrice;
         new roundvalue(context ).execute(  AV8ProductCostPrice, out  GXt_decimal1) ;
         AV8ProductCostPrice = GXt_decimal1;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private decimal AV8ProductCostPrice ;
      private decimal GXt_decimal1 ;
      private decimal aP0_ProductCostPrice ;
   }

}
