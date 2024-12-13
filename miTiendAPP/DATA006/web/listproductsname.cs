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
   public class listproductsname : GXProcedure
   {
      public listproductsname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public listproductsname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Supplier )
      {
         this.AV2Supplier = aP0_Supplier;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_Supplier )
      {
         listproductsname objlistproductsname;
         objlistproductsname = new listproductsname();
         objlistproductsname.AV2Supplier = aP0_Supplier;
         objlistproductsname.context.SetSubmitInitialConfig(context);
         objlistproductsname.initialize();
         Submit( executePrivateCatch,objlistproductsname);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listproductsname)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2Supplier} ;
         ClassLoader.Execute("alistproductsname","GeneXus.Programs","alistproductsname", new Object[] {context }, "execute", args);
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

      private short AV2Supplier ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
