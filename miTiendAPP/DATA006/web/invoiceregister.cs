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
   public class invoiceregister : GXProcedure
   {
      public invoiceregister( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public invoiceregister( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId ,
                           out bool aP1_AllOk )
      {
         this.AV2InvoiceId = aP0_InvoiceId;
         this.AV3AllOk = false ;
         initialize();
         executePrivate();
         aP1_AllOk=this.AV3AllOk;
      }

      public bool executeUdp( int aP0_InvoiceId )
      {
         execute(aP0_InvoiceId, out aP1_AllOk);
         return AV3AllOk ;
      }

      public void executeSubmit( int aP0_InvoiceId ,
                                 out bool aP1_AllOk )
      {
         invoiceregister objinvoiceregister;
         objinvoiceregister = new invoiceregister();
         objinvoiceregister.AV2InvoiceId = aP0_InvoiceId;
         objinvoiceregister.AV3AllOk = false ;
         objinvoiceregister.context.SetSubmitInitialConfig(context);
         objinvoiceregister.initialize();
         Submit( executePrivateCatch,objinvoiceregister);
         aP1_AllOk=this.AV3AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoiceregister)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2InvoiceId,(bool)AV3AllOk} ;
         ClassLoader.Execute("ainvoiceregister","GeneXus.Programs","ainvoiceregister", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3AllOk = (bool)(args[1]) ;
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
      private bool AV3AllOk ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private bool aP1_AllOk ;
   }

}
