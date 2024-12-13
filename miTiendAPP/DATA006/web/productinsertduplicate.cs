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
   public class productinsertduplicate : GXProcedure
   {
      public productinsertduplicate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productinsertduplicate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           ref int aP1_ProductStock ,
                           ref int aP2_SupplierId ,
                           ref decimal aP3_ProductCostPrice ,
                           ref decimal aP4_ProductRetailProfit ,
                           ref decimal aP5_ProductWholesaleProfit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_ErrorMessages ,
                           ref bool aP7_AllOk )
      {
         this.AV15ProductId = aP0_ProductId;
         this.AV19ProductStock = aP1_ProductStock;
         this.AV12SupplierId = aP2_SupplierId;
         this.AV14ProductCostPrice = aP3_ProductCostPrice;
         this.AV17ProductRetailProfit = aP4_ProductRetailProfit;
         this.AV18ProductWholesaleProfit = aP5_ProductWholesaleProfit;
         this.AV20ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV21AllOk = aP7_AllOk;
         initialize();
         executePrivate();
         aP1_ProductStock=this.AV19ProductStock;
         aP2_SupplierId=this.AV12SupplierId;
         aP3_ProductCostPrice=this.AV14ProductCostPrice;
         aP4_ProductRetailProfit=this.AV17ProductRetailProfit;
         aP5_ProductWholesaleProfit=this.AV18ProductWholesaleProfit;
         aP6_ErrorMessages=this.AV20ErrorMessages;
         aP7_AllOk=this.AV21AllOk;
      }

      public bool executeUdp( int aP0_ProductId ,
                              ref int aP1_ProductStock ,
                              ref int aP2_SupplierId ,
                              ref decimal aP3_ProductCostPrice ,
                              ref decimal aP4_ProductRetailProfit ,
                              ref decimal aP5_ProductWholesaleProfit ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_ErrorMessages )
      {
         execute(aP0_ProductId, ref aP1_ProductStock, ref aP2_SupplierId, ref aP3_ProductCostPrice, ref aP4_ProductRetailProfit, ref aP5_ProductWholesaleProfit, out aP6_ErrorMessages, ref aP7_AllOk);
         return AV21AllOk ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 ref int aP1_ProductStock ,
                                 ref int aP2_SupplierId ,
                                 ref decimal aP3_ProductCostPrice ,
                                 ref decimal aP4_ProductRetailProfit ,
                                 ref decimal aP5_ProductWholesaleProfit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_ErrorMessages ,
                                 ref bool aP7_AllOk )
      {
         productinsertduplicate objproductinsertduplicate;
         objproductinsertduplicate = new productinsertduplicate();
         objproductinsertduplicate.AV15ProductId = aP0_ProductId;
         objproductinsertduplicate.AV19ProductStock = aP1_ProductStock;
         objproductinsertduplicate.AV12SupplierId = aP2_SupplierId;
         objproductinsertduplicate.AV14ProductCostPrice = aP3_ProductCostPrice;
         objproductinsertduplicate.AV17ProductRetailProfit = aP4_ProductRetailProfit;
         objproductinsertduplicate.AV18ProductWholesaleProfit = aP5_ProductWholesaleProfit;
         objproductinsertduplicate.AV20ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objproductinsertduplicate.AV21AllOk = aP7_AllOk;
         objproductinsertduplicate.context.SetSubmitInitialConfig(context);
         objproductinsertduplicate.initialize();
         Submit( executePrivateCatch,objproductinsertduplicate);
         aP1_ProductStock=this.AV19ProductStock;
         aP2_SupplierId=this.AV12SupplierId;
         aP3_ProductCostPrice=this.AV14ProductCostPrice;
         aP4_ProductRetailProfit=this.AV17ProductRetailProfit;
         aP5_ProductWholesaleProfit=this.AV18ProductWholesaleProfit;
         aP6_ErrorMessages=this.AV20ErrorMessages;
         aP7_AllOk=this.AV21AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productinsertduplicate)stateInfo).executePrivate();
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
         AV16ProductAux.Load(AV15ProductId);
         AV8Product = (SdtProduct)(AV16ProductAux.Clone());
         AV8Product.gxTpr_Productid = 0;
         AV8Product.gxTpr_Productactive = true;
         AV8Product.gxTpr_Productstock = AV19ProductStock;
         AV8Product.gxTpr_Supplierid = AV12SupplierId;
         if ( AV14ProductCostPrice > AV8Product.gxTpr_Productcostprice )
         {
            AV8Product.gxTpr_Productcostprice = AV14ProductCostPrice;
         }
         if ( AV17ProductRetailProfit > AV8Product.gxTpr_Productretailprofit )
         {
            AV8Product.gxTpr_Productretailprofit = AV17ProductRetailProfit;
         }
         if ( AV18ProductWholesaleProfit > AV8Product.gxTpr_Productwholesaleprofit )
         {
            AV8Product.gxTpr_Productwholesaleprofit = AV18ProductWholesaleProfit;
         }
         AV8Product.Insert();
         if ( AV8Product.Success() )
         {
            context.CommitDataStores("productinsertduplicate",pr_default);
            AV21AllOk = true;
         }
         else
         {
            AV20ErrorMessages = AV8Product.GetMessages();
            AV21AllOk = false;
            context.RollbackDataStores("productinsertduplicate",pr_default);
         }
         if ( AV21AllOk )
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
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV20ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16ProductAux = new SdtProduct(context);
         AV8Product = new SdtProduct(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productinsertduplicate__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV15ProductId ;
      private int AV19ProductStock ;
      private int AV12SupplierId ;
      private decimal AV14ProductCostPrice ;
      private decimal AV17ProductRetailProfit ;
      private decimal AV18ProductWholesaleProfit ;
      private bool AV21AllOk ;
      private IGxDataStore dsDefault ;
      private int aP1_ProductStock ;
      private int aP2_SupplierId ;
      private decimal aP3_ProductCostPrice ;
      private decimal aP4_ProductRetailProfit ;
      private decimal aP5_ProductWholesaleProfit ;
      private bool aP7_AllOk ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_ErrorMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20ErrorMessages ;
      private SdtProduct AV16ProductAux ;
      private SdtProduct AV8Product ;
   }

   public class productinsertduplicate__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
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
