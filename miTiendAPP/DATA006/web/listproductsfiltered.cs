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
   public class listproductsfiltered : GXProcedure
   {
      public listproductsfiltered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public listproductsfiltered( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           ref int aP1_SupplierId ,
                           ref int aP2_SectorId ,
                           ref int aP3_BrandId ,
                           ref short aP4_StockFrom ,
                           ref short aP5_StockTo ,
                           ref short aP6_PriceFrom ,
                           ref short aP7_PriceTo ,
                           ref short aP8_Order ,
                           ref bool aP9_Descending ,
                           ref short aP10_Active )
      {
         this.AV2Name = aP0_Name;
         this.AV3SupplierId = aP1_SupplierId;
         this.AV4SectorId = aP2_SectorId;
         this.AV5BrandId = aP3_BrandId;
         this.AV6StockFrom = aP4_StockFrom;
         this.AV7StockTo = aP5_StockTo;
         this.AV8PriceFrom = aP6_PriceFrom;
         this.AV9PriceTo = aP7_PriceTo;
         this.AV10Order = aP8_Order;
         this.AV11Descending = aP9_Descending;
         this.AV12Active = aP10_Active;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV3SupplierId;
         aP2_SectorId=this.AV4SectorId;
         aP3_BrandId=this.AV5BrandId;
         aP4_StockFrom=this.AV6StockFrom;
         aP5_StockTo=this.AV7StockTo;
         aP6_PriceFrom=this.AV8PriceFrom;
         aP7_PriceTo=this.AV9PriceTo;
         aP8_Order=this.AV10Order;
         aP9_Descending=this.AV11Descending;
         aP10_Active=this.AV12Active;
      }

      public short executeUdp( string aP0_Name ,
                               ref int aP1_SupplierId ,
                               ref int aP2_SectorId ,
                               ref int aP3_BrandId ,
                               ref short aP4_StockFrom ,
                               ref short aP5_StockTo ,
                               ref short aP6_PriceFrom ,
                               ref short aP7_PriceTo ,
                               ref short aP8_Order ,
                               ref bool aP9_Descending )
      {
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_StockFrom, ref aP5_StockTo, ref aP6_PriceFrom, ref aP7_PriceTo, ref aP8_Order, ref aP9_Descending, ref aP10_Active);
         return AV12Active ;
      }

      public void executeSubmit( string aP0_Name ,
                                 ref int aP1_SupplierId ,
                                 ref int aP2_SectorId ,
                                 ref int aP3_BrandId ,
                                 ref short aP4_StockFrom ,
                                 ref short aP5_StockTo ,
                                 ref short aP6_PriceFrom ,
                                 ref short aP7_PriceTo ,
                                 ref short aP8_Order ,
                                 ref bool aP9_Descending ,
                                 ref short aP10_Active )
      {
         listproductsfiltered objlistproductsfiltered;
         objlistproductsfiltered = new listproductsfiltered();
         objlistproductsfiltered.AV2Name = aP0_Name;
         objlistproductsfiltered.AV3SupplierId = aP1_SupplierId;
         objlistproductsfiltered.AV4SectorId = aP2_SectorId;
         objlistproductsfiltered.AV5BrandId = aP3_BrandId;
         objlistproductsfiltered.AV6StockFrom = aP4_StockFrom;
         objlistproductsfiltered.AV7StockTo = aP5_StockTo;
         objlistproductsfiltered.AV8PriceFrom = aP6_PriceFrom;
         objlistproductsfiltered.AV9PriceTo = aP7_PriceTo;
         objlistproductsfiltered.AV10Order = aP8_Order;
         objlistproductsfiltered.AV11Descending = aP9_Descending;
         objlistproductsfiltered.AV12Active = aP10_Active;
         objlistproductsfiltered.context.SetSubmitInitialConfig(context);
         objlistproductsfiltered.initialize();
         Submit( executePrivateCatch,objlistproductsfiltered);
         aP1_SupplierId=this.AV3SupplierId;
         aP2_SectorId=this.AV4SectorId;
         aP3_BrandId=this.AV5BrandId;
         aP4_StockFrom=this.AV6StockFrom;
         aP5_StockTo=this.AV7StockTo;
         aP6_PriceFrom=this.AV8PriceFrom;
         aP7_PriceTo=this.AV9PriceTo;
         aP8_Order=this.AV10Order;
         aP9_Descending=this.AV11Descending;
         aP10_Active=this.AV12Active;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listproductsfiltered)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2Name,(int)AV3SupplierId,(int)AV4SectorId,(int)AV5BrandId,(short)AV6StockFrom,(short)AV7StockTo,(short)AV8PriceFrom,(short)AV9PriceTo,(short)AV10Order,(bool)AV11Descending,(short)AV12Active} ;
         ClassLoader.Execute("alistproductsfiltered","GeneXus.Programs","alistproductsfiltered", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 11 ) )
         {
            AV3SupplierId = (int)(args[1]) ;
            AV4SectorId = (int)(args[2]) ;
            AV5BrandId = (int)(args[3]) ;
            AV6StockFrom = (short)(args[4]) ;
            AV7StockTo = (short)(args[5]) ;
            AV8PriceFrom = (short)(args[6]) ;
            AV9PriceTo = (short)(args[7]) ;
            AV10Order = (short)(args[8]) ;
            AV11Descending = (bool)(args[9]) ;
            AV12Active = (short)(args[10]) ;
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

      private short AV6StockFrom ;
      private short AV7StockTo ;
      private short AV8PriceFrom ;
      private short AV9PriceTo ;
      private short AV10Order ;
      private short AV12Active ;
      private int AV3SupplierId ;
      private int AV4SectorId ;
      private int AV5BrandId ;
      private bool AV11Descending ;
      private string AV2Name ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private short aP4_StockFrom ;
      private short aP5_StockTo ;
      private short aP6_PriceFrom ;
      private short aP7_PriceTo ;
      private short aP8_Order ;
      private bool aP9_Descending ;
      private short aP10_Active ;
      private Object[] args ;
   }

}
