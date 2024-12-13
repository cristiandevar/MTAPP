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
   public class productsrankingsale : GXProcedure
   {
      public productsrankingsale( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public productsrankingsale( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           ref int aP1_SupplierId ,
                           ref int aP2_SectorId ,
                           ref int aP3_BrandId ,
                           ref DateTime aP4_FromDate ,
                           ref DateTime aP5_ToDate ,
                           ref short aP6_Order )
      {
         this.AV2Name = aP0_Name;
         this.AV3SupplierId = aP1_SupplierId;
         this.AV4SectorId = aP2_SectorId;
         this.AV5BrandId = aP3_BrandId;
         this.AV6FromDate = aP4_FromDate;
         this.AV7ToDate = aP5_ToDate;
         this.AV8Order = aP6_Order;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV3SupplierId;
         aP2_SectorId=this.AV4SectorId;
         aP3_BrandId=this.AV5BrandId;
         aP4_FromDate=this.AV6FromDate;
         aP5_ToDate=this.AV7ToDate;
         aP6_Order=this.AV8Order;
      }

      public short executeUdp( string aP0_Name ,
                               ref int aP1_SupplierId ,
                               ref int aP2_SectorId ,
                               ref int aP3_BrandId ,
                               ref DateTime aP4_FromDate ,
                               ref DateTime aP5_ToDate )
      {
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_FromDate, ref aP5_ToDate, ref aP6_Order);
         return AV8Order ;
      }

      public void executeSubmit( string aP0_Name ,
                                 ref int aP1_SupplierId ,
                                 ref int aP2_SectorId ,
                                 ref int aP3_BrandId ,
                                 ref DateTime aP4_FromDate ,
                                 ref DateTime aP5_ToDate ,
                                 ref short aP6_Order )
      {
         productsrankingsale objproductsrankingsale;
         objproductsrankingsale = new productsrankingsale();
         objproductsrankingsale.AV2Name = aP0_Name;
         objproductsrankingsale.AV3SupplierId = aP1_SupplierId;
         objproductsrankingsale.AV4SectorId = aP2_SectorId;
         objproductsrankingsale.AV5BrandId = aP3_BrandId;
         objproductsrankingsale.AV6FromDate = aP4_FromDate;
         objproductsrankingsale.AV7ToDate = aP5_ToDate;
         objproductsrankingsale.AV8Order = aP6_Order;
         objproductsrankingsale.context.SetSubmitInitialConfig(context);
         objproductsrankingsale.initialize();
         Submit( executePrivateCatch,objproductsrankingsale);
         aP1_SupplierId=this.AV3SupplierId;
         aP2_SectorId=this.AV4SectorId;
         aP3_BrandId=this.AV5BrandId;
         aP4_FromDate=this.AV6FromDate;
         aP5_ToDate=this.AV7ToDate;
         aP6_Order=this.AV8Order;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productsrankingsale)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2Name,(int)AV3SupplierId,(int)AV4SectorId,(int)AV5BrandId,(DateTime)AV6FromDate,(DateTime)AV7ToDate,(short)AV8Order} ;
         ClassLoader.Execute("aproductsrankingsale","GeneXus.Programs","aproductsrankingsale", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 7 ) )
         {
            AV3SupplierId = (int)(args[1]) ;
            AV4SectorId = (int)(args[2]) ;
            AV5BrandId = (int)(args[3]) ;
            AV6FromDate = (DateTime)(args[4]) ;
            AV7ToDate = (DateTime)(args[5]) ;
            AV8Order = (short)(args[6]) ;
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

      private short AV8Order ;
      private int AV3SupplierId ;
      private int AV4SectorId ;
      private int AV5BrandId ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private string AV2Name ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private DateTime aP4_FromDate ;
      private DateTime aP5_ToDate ;
      private short aP6_Order ;
      private Object[] args ;
   }

}
