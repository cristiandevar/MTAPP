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
   public class listproductspurchase : GXProcedure
   {
      public listproductspurchase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public listproductspurchase( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           short aP1_Supplier )
      {
         this.AV2Date = aP0_Date;
         this.AV3Supplier = aP1_Supplier;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 short aP1_Supplier )
      {
         listproductspurchase objlistproductspurchase;
         objlistproductspurchase = new listproductspurchase();
         objlistproductspurchase.AV2Date = aP0_Date;
         objlistproductspurchase.AV3Supplier = aP1_Supplier;
         objlistproductspurchase.context.SetSubmitInitialConfig(context);
         objlistproductspurchase.initialize();
         Submit( executePrivateCatch,objlistproductspurchase);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listproductspurchase)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2Date,(short)AV3Supplier} ;
         ClassLoader.Execute("alistproductspurchase","GeneXus.Programs","alistproductspurchase", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
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

      private short AV3Supplier ;
      private DateTime AV2Date ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
