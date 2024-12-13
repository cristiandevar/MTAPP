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
   public class productsrankingpurchasesubtotal1 : GXProcedure
   {
      public productsrankingpurchasesubtotal1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public productsrankingpurchasesubtotal1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           ref int aP1_SectorId )
      {
         this.AV2SupplierId = aP0_SupplierId;
         this.AV3SectorId = aP1_SectorId;
         initialize();
         executePrivate();
         aP1_SectorId=this.AV3SectorId;
      }

      public int executeUdp( int aP0_SupplierId )
      {
         execute(aP0_SupplierId, ref aP1_SectorId);
         return AV3SectorId ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 ref int aP1_SectorId )
      {
         productsrankingpurchasesubtotal1 objproductsrankingpurchasesubtotal1;
         objproductsrankingpurchasesubtotal1 = new productsrankingpurchasesubtotal1();
         objproductsrankingpurchasesubtotal1.AV2SupplierId = aP0_SupplierId;
         objproductsrankingpurchasesubtotal1.AV3SectorId = aP1_SectorId;
         objproductsrankingpurchasesubtotal1.context.SetSubmitInitialConfig(context);
         objproductsrankingpurchasesubtotal1.initialize();
         Submit( executePrivateCatch,objproductsrankingpurchasesubtotal1);
         aP1_SectorId=this.AV3SectorId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productsrankingpurchasesubtotal1)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2SupplierId,(int)AV3SectorId} ;
         ClassLoader.Execute("aproductsrankingpurchasesubtotal1","GeneXus.Programs","aproductsrankingpurchasesubtotal1", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3SectorId = (int)(args[1]) ;
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

      private int AV2SupplierId ;
      private int AV3SectorId ;
      private IGxDataStore dsDefault ;
      private int aP1_SectorId ;
      private Object[] args ;
   }

}