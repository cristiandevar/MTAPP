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
   public class purchaseordergenerateattach : GXProcedure
   {
      public purchaseordergenerateattach( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public purchaseordergenerateattach( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.AV2PurchaseOrderId = aP0_PurchaseOrderId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_PurchaseOrderId )
      {
         purchaseordergenerateattach objpurchaseordergenerateattach;
         objpurchaseordergenerateattach = new purchaseordergenerateattach();
         objpurchaseordergenerateattach.AV2PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordergenerateattach.context.SetSubmitInitialConfig(context);
         objpurchaseordergenerateattach.initialize();
         Submit( executePrivateCatch,objpurchaseordergenerateattach);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordergenerateattach)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2PurchaseOrderId} ;
         ClassLoader.Execute("apurchaseordergenerateattach","GeneXus.Programs","apurchaseordergenerateattach", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
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

      private int AV2PurchaseOrderId ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
