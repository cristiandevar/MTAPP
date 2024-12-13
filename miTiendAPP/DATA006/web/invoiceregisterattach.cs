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
   public class invoiceregisterattach : GXProcedure
   {
      public invoiceregisterattach( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public invoiceregisterattach( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId )
      {
         this.AV2InvoiceId = aP0_InvoiceId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_InvoiceId )
      {
         invoiceregisterattach objinvoiceregisterattach;
         objinvoiceregisterattach = new invoiceregisterattach();
         objinvoiceregisterattach.AV2InvoiceId = aP0_InvoiceId;
         objinvoiceregisterattach.context.SetSubmitInitialConfig(context);
         objinvoiceregisterattach.initialize();
         Submit( executePrivateCatch,objinvoiceregisterattach);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoiceregisterattach)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2InvoiceId} ;
         ClassLoader.Execute("ainvoiceregisterattach","GeneXus.Programs","ainvoiceregisterattach", new Object[] {context }, "execute", args);
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

      private int AV2InvoiceId ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
