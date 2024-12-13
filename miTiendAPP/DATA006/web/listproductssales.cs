using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class listproductssales : GXProcedure
   {
      public listproductssales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public listproductssales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Supplier ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo )
      {
         this.AV2Supplier = aP0_Supplier;
         this.AV3DateFrom = aP1_DateFrom;
         this.AV4DateTo = aP2_DateTo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_Supplier ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo )
      {
         listproductssales objlistproductssales;
         objlistproductssales = new listproductssales();
         objlistproductssales.AV2Supplier = aP0_Supplier;
         objlistproductssales.AV3DateFrom = aP1_DateFrom;
         objlistproductssales.AV4DateTo = aP2_DateTo;
         objlistproductssales.context.SetSubmitInitialConfig(context);
         objlistproductssales.initialize();
         Submit( executePrivateCatch,objlistproductssales);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listproductssales)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2Supplier,(DateTime)AV3DateFrom,(DateTime)AV4DateTo} ;
         ClassLoader.Execute("alistproductssales","GeneXus.Programs","alistproductssales", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2Supplier ;
      private DateTime AV3DateFrom ;
      private DateTime AV4DateTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
