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
   public class registersaleproductselected : GXProcedure
   {
      public registersaleproductselected( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public registersaleproductselected( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSONProductSelectedId ,
                           ref string aP1_JSONQuantityProduct )
      {
         this.AV2JSONProductSelectedId = aP0_JSONProductSelectedId;
         this.AV3JSONQuantityProduct = aP1_JSONQuantityProduct;
         initialize();
         executePrivate();
         aP1_JSONQuantityProduct=this.AV3JSONQuantityProduct;
      }

      public string executeUdp( string aP0_JSONProductSelectedId )
      {
         execute(aP0_JSONProductSelectedId, ref aP1_JSONQuantityProduct);
         return AV3JSONQuantityProduct ;
      }

      public void executeSubmit( string aP0_JSONProductSelectedId ,
                                 ref string aP1_JSONQuantityProduct )
      {
         registersaleproductselected objregistersaleproductselected;
         objregistersaleproductselected = new registersaleproductselected();
         objregistersaleproductselected.AV2JSONProductSelectedId = aP0_JSONProductSelectedId;
         objregistersaleproductselected.AV3JSONQuantityProduct = aP1_JSONQuantityProduct;
         objregistersaleproductselected.context.SetSubmitInitialConfig(context);
         objregistersaleproductselected.initialize();
         Submit( executePrivateCatch,objregistersaleproductselected);
         aP1_JSONQuantityProduct=this.AV3JSONQuantityProduct;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registersaleproductselected)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2JSONProductSelectedId,(string)AV3JSONQuantityProduct} ;
         ClassLoader.Execute("aregistersaleproductselected","GeneXus.Programs","aregistersaleproductselected", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3JSONQuantityProduct = (string)(args[1]) ;
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

      private string AV2JSONProductSelectedId ;
      private string AV3JSONQuantityProduct ;
      private IGxDataStore dsDefault ;
      private string aP1_JSONQuantityProduct ;
      private Object[] args ;
   }

}
