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
   public class productupdatesamecode : GXProcedure
   {
      public productupdatesamecode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productupdatesamecode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out bool aP1_AllOk ,
                           ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_ErrorMessages )
      {
         this.AV8ProductId = aP0_ProductId;
         this.AV9AllOk = false ;
         this.AV16ErrorMessages = aP2_ErrorMessages;
         initialize();
         executePrivate();
         aP1_AllOk=this.AV9AllOk;
         aP2_ErrorMessages=this.AV16ErrorMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_ProductId ,
                                                                             out bool aP1_AllOk )
      {
         execute(aP0_ProductId, out aP1_AllOk, ref aP2_ErrorMessages);
         return AV16ErrorMessages ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out bool aP1_AllOk ,
                                 ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_ErrorMessages )
      {
         productupdatesamecode objproductupdatesamecode;
         objproductupdatesamecode = new productupdatesamecode();
         objproductupdatesamecode.AV8ProductId = aP0_ProductId;
         objproductupdatesamecode.AV9AllOk = false ;
         objproductupdatesamecode.AV16ErrorMessages = aP2_ErrorMessages;
         objproductupdatesamecode.context.SetSubmitInitialConfig(context);
         objproductupdatesamecode.initialize();
         Submit( executePrivateCatch,objproductupdatesamecode);
         aP1_AllOk=this.AV9AllOk;
         aP2_ErrorMessages=this.AV16ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productupdatesamecode)stateInfo).executePrivate();
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
         GXt_int1 = AV11ProductIdAux;
         new productsearchwithcode(context ).execute(  A55ProductCode, out  GXt_int1) ;
         AV11ProductIdAux = GXt_int1;
         AV10Product.Load(AV8ProductId);
         AV12ProductAux.Load(AV11ProductIdAux);
         if ( AV12ProductAux.gxTpr_Productcostprice > AV10Product.gxTpr_Productcostprice )
         {
            AV10Product.gxTpr_Productcostprice = AV12ProductAux.gxTpr_Productcostprice;
         }
         if ( AV12ProductAux.gxTpr_Productretailprofit > AV10Product.gxTpr_Productretailprofit )
         {
            AV10Product.gxTpr_Productretailprofit = AV12ProductAux.gxTpr_Productretailprofit;
         }
         if ( AV12ProductAux.gxTpr_Productwholesaleprofit > AV10Product.gxTpr_Productwholesaleprofit )
         {
            AV10Product.gxTpr_Productwholesaleprofit = AV12ProductAux.gxTpr_Productwholesaleprofit;
         }
         if ( AV12ProductAux.gxTpr_Productminiumquantitywholesale > AV10Product.gxTpr_Productminiumquantitywholesale )
         {
            AV10Product.gxTpr_Productminiumquantitywholesale = AV12ProductAux.gxTpr_Productminiumquantitywholesale;
         }
         AV10Product.Update();
         if ( AV10Product.Success() )
         {
            AV9AllOk = true;
            context.CommitDataStores("productupdatesamecode",pr_default);
            n93ProductMiniumQuantityWholesale = false;
            n69ProductMiniumStock = false;
            n87ProductWholesaleProfit = false;
            n89ProductRetailProfit = false;
            n85ProductCostPrice = false;
            /* Optimized UPDATE. */
            /* Using cursor P002O2 */
            pr_default.execute(0, new Object[] {n93ProductMiniumQuantityWholesale, AV10Product.gxTpr_Productminiumquantitywholesale, n69ProductMiniumStock, AV10Product.gxTpr_Productminiumstock, n87ProductWholesaleProfit, AV10Product.gxTpr_Productwholesaleprofit, n89ProductRetailProfit, AV10Product.gxTpr_Productretailprofit, n85ProductCostPrice, AV10Product.gxTpr_Productcostprice, AV8ProductId, AV10Product.gxTpr_Productcode});
            pr_default.close(0);
            pr_default.SmartCacheProvider.SetUpdated("Product");
            /* End optimized UPDATE. */
         }
         else
         {
            AV9AllOk = false;
            AV16ErrorMessages = AV10Product.GetMessages();
            context.RollbackDataStores("productupdatesamecode",pr_default);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("productupdatesamecode",pr_default);
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         A55ProductCode = "";
         AV10Product = new SdtProduct(context);
         AV12ProductAux = new SdtProduct(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productupdatesamecode__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private int AV8ProductId ;
      private int AV11ProductIdAux ;
      private int GXt_int1 ;
      private int A69ProductMiniumStock ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A89ProductRetailProfit ;
      private decimal A85ProductCostPrice ;
      private bool AV9AllOk ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n69ProductMiniumStock ;
      private bool n87ProductWholesaleProfit ;
      private bool n89ProductRetailProfit ;
      private bool n85ProductCostPrice ;
      private string A55ProductCode ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_ErrorMessages ;
      private IDataStoreProvider pr_default ;
      private bool aP1_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16ErrorMessages ;
      private SdtProduct AV10Product ;
      private SdtProduct AV12ProductAux ;
   }

   public class productupdatesamecode__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          new ParDef("@ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ProductMiniumStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@AV8ProductId",GXType.Int32,6,0) ,
          new ParDef("@AV10Product__Productcode",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "UPDATE [Product] SET [ProductMiniumQuantityWholesale]=@ProductMiniumQuantityWholesale, [ProductMiniumStock]=@ProductMiniumStock, [ProductWholesaleProfit]=@ProductWholesaleProfit, [ProductRetailProfit]=@ProductRetailProfit, [ProductCostPrice]=@ProductCostPrice  WHERE ([ProductId] <> @AV8ProductId) AND ([ProductCode] = @AV10Product__Productcode)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002O2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
