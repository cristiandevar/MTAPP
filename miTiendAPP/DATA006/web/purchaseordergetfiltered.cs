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
   public class purchaseordergetfiltered : GXProcedure
   {
      public purchaseordergetfiltered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordergetfiltered( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           int aP1_SupplierId ,
                           ref DateTime aP2_FromDate ,
                           ref DateTime aP3_ToDate ,
                           ref short aP4_OrderBy ,
                           ref bool aP5_Descending ,
                           out GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> aP6_SDTPurchaseOrderGenerateList )
      {
         this.AV20PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV9SupplierId = aP1_SupplierId;
         this.AV10FromDate = aP2_FromDate;
         this.AV11ToDate = aP3_ToDate;
         this.AV15OrderBy = aP4_OrderBy;
         this.AV16Descending = aP5_Descending;
         this.AV12SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP2_FromDate=this.AV10FromDate;
         aP3_ToDate=this.AV11ToDate;
         aP4_OrderBy=this.AV15OrderBy;
         aP5_Descending=this.AV16Descending;
         aP6_SDTPurchaseOrderGenerateList=this.AV12SDTPurchaseOrderGenerateList;
      }

      public GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> executeUdp( int aP0_PurchaseOrderId ,
                                                                                                            int aP1_SupplierId ,
                                                                                                            ref DateTime aP2_FromDate ,
                                                                                                            ref DateTime aP3_ToDate ,
                                                                                                            ref short aP4_OrderBy ,
                                                                                                            ref bool aP5_Descending )
      {
         execute(aP0_PurchaseOrderId, aP1_SupplierId, ref aP2_FromDate, ref aP3_ToDate, ref aP4_OrderBy, ref aP5_Descending, out aP6_SDTPurchaseOrderGenerateList);
         return AV12SDTPurchaseOrderGenerateList ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 int aP1_SupplierId ,
                                 ref DateTime aP2_FromDate ,
                                 ref DateTime aP3_ToDate ,
                                 ref short aP4_OrderBy ,
                                 ref bool aP5_Descending ,
                                 out GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> aP6_SDTPurchaseOrderGenerateList )
      {
         purchaseordergetfiltered objpurchaseordergetfiltered;
         objpurchaseordergetfiltered = new purchaseordergetfiltered();
         objpurchaseordergetfiltered.AV20PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordergetfiltered.AV9SupplierId = aP1_SupplierId;
         objpurchaseordergetfiltered.AV10FromDate = aP2_FromDate;
         objpurchaseordergetfiltered.AV11ToDate = aP3_ToDate;
         objpurchaseordergetfiltered.AV15OrderBy = aP4_OrderBy;
         objpurchaseordergetfiltered.AV16Descending = aP5_Descending;
         objpurchaseordergetfiltered.AV12SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB") ;
         objpurchaseordergetfiltered.context.SetSubmitInitialConfig(context);
         objpurchaseordergetfiltered.initialize();
         Submit( executePrivateCatch,objpurchaseordergetfiltered);
         aP2_FromDate=this.AV10FromDate;
         aP3_ToDate=this.AV11ToDate;
         aP4_OrderBy=this.AV15OrderBy;
         aP5_Descending=this.AV16Descending;
         aP6_SDTPurchaseOrderGenerateList=this.AV12SDTPurchaseOrderGenerateList;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordergetfiltered)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV18Context, ref  AV19AllOk) ;
         if ( ! AV19AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV12SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV20PurchaseOrderId ,
                                              AV9SupplierId ,
                                              AV10FromDate ,
                                              AV11ToDate ,
                                              A50PurchaseOrderId ,
                                              A4SupplierId ,
                                              A52PurchaseOrderCreatedDate ,
                                              A79PurchaseOrderActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00193 */
         pr_default.execute(0, new Object[] {AV20PurchaseOrderId, AV9SupplierId, AV10FromDate, AV11ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A79PurchaseOrderActive = P00193_A79PurchaseOrderActive[0];
            A52PurchaseOrderCreatedDate = P00193_A52PurchaseOrderCreatedDate[0];
            A4SupplierId = P00193_A4SupplierId[0];
            A50PurchaseOrderId = P00193_A50PurchaseOrderId[0];
            A5SupplierName = P00193_A5SupplierName[0];
            A66PurchaseOrderClosedDate = P00193_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P00193_n66PurchaseOrderClosedDate[0];
            A135PurchaseOrderConfirmatedDate = P00193_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P00193_n135PurchaseOrderConfirmatedDate[0];
            A67PurchaseOrderDetailsQuantity = P00193_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = P00193_n67PurchaseOrderDetailsQuantity[0];
            A5SupplierName = P00193_A5SupplierName[0];
            A67PurchaseOrderDetailsQuantity = P00193_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = P00193_n67PurchaseOrderDetailsQuantity[0];
            AV27PurchaseOrderIdAux = A50PurchaseOrderId;
            /* Execute user subroutine: 'CANADDITEM' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( AV26CanAddItem )
            {
               AV14SDTPurchaseOrderGenerateListItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Purchaseorderid = A50PurchaseOrderId;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Suppliername = A5SupplierName;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Createddate = A52PurchaseOrderCreatedDate;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Closeddate = A66PurchaseOrderClosedDate;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Purchaseorderdetailsquantity = A67PurchaseOrderDetailsQuantity;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Purchaseorderconfirmateddate = A135PurchaseOrderConfirmatedDate;
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Detailslink = "Details";
               AV14SDTPurchaseOrderGenerateListItem.gxTpr_Sdtvoucherlink = "Voucher";
               /* Execute user subroutine: 'CHECKIMAGES' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV22CanRegister )
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Addimage = context.GetImagePath( "8ef610f1-b761-4b0c-9811-2e1ad9adcea3", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Addimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "8ef610f1-b761-4b0c-9811-2e1ad9adcea3", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canadd = true;
               }
               else
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Addimage = context.GetImagePath( "ae94f1e0-05a1-4111-b267-903a7fc91e39", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Addimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "ae94f1e0-05a1-4111-b267-903a7fc91e39", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canadd = false;
               }
               if ( AV24CanEdit )
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Modifyimage = context.GetImagePath( "b4daee42-061f-42ce-b968-5722595bff36", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Modifyimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "b4daee42-061f-42ce-b968-5722595bff36", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canmodify = true;
               }
               else
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Modifyimage = context.GetImagePath( "502ddb8d-4242-4081-9958-91c36b5ce9f5", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Modifyimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "502ddb8d-4242-4081-9958-91c36b5ce9f5", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canmodify = false;
               }
               if ( AV23CanCancel )
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Deleteimage = context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Deleteimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Candelete = true;
               }
               else
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Deleteimage = context.GetImagePath( "01991361-b014-4d5d-9c74-ac9c91f544bb", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Deleteimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "01991361-b014-4d5d-9c74-ac9c91f544bb", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Candelete = false;
               }
               if ( AV25CanPay )
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Paidimage = context.GetImagePath( "100d51fa-044f-4b4b-a697-2e2c1f2fe6c4", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Paidimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "100d51fa-044f-4b4b-a697-2e2c1f2fe6c4", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canpay = true;
               }
               else
               {
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Paidimage = context.GetImagePath( "2c427b4b-67a2-4c95-bb3b-e037978c7792", "", context.GetTheme( ));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Paidimage_gxi = GXDbFile.PathToUrl( context.GetImagePath( "2c427b4b-67a2-4c95-bb3b-e037978c7792", "", context.GetTheme( )));
                  AV14SDTPurchaseOrderGenerateListItem.gxTpr_Canpay = false;
               }
               AV12SDTPurchaseOrderGenerateList.Add(AV14SDTPurchaseOrderGenerateListItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV16Descending )
         {
            if ( AV15OrderBy == 1 )
            {
               AV17StringAux = "[" + gxdomainorderoptionorderpurchase.getDescription(context,AV15OrderBy) + "Name]";
            }
            else if ( AV15OrderBy == 2 )
            {
               AV17StringAux = "[" + gxdomainorderoptionorderpurchase.getDescription(context,AV15OrderBy) + "Date]";
            }
            else if ( AV15OrderBy == 3 )
            {
               AV17StringAux = "[PurchaseOrderId]";
            }
            else
            {
               AV17StringAux = "[PurchaseOrderId]";
            }
         }
         else
         {
            if ( AV15OrderBy == 1 )
            {
               AV17StringAux = gxdomainorderoptionorderpurchase.getDescription(context,AV15OrderBy) + "Name";
            }
            else if ( AV15OrderBy == 2 )
            {
               AV17StringAux = gxdomainorderoptionorderpurchase.getDescription(context,AV15OrderBy) + "Date";
            }
            else if ( AV15OrderBy == 3 )
            {
               AV17StringAux = "PurchaseOrderId";
            }
            else
            {
               AV17StringAux = "PurchaseOrderId";
            }
         }
         AV12SDTPurchaseOrderGenerateList.Sort(AV17StringAux);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CANADDITEM' Routine */
         returnInSub = false;
         AV21PurchaseOrder.Load(AV27PurchaseOrderIdAux);
         AV26CanAddItem = false;
         if ( (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) || AV21PurchaseOrder.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_IsNull( ) || ( DateTimeUtil.ResetTime ( AV21PurchaseOrder.gxTpr_Purchaseordercloseddate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) )
         {
            AV26CanAddItem = true;
         }
         else
         {
            if ( ! AV21PurchaseOrder.gxTpr_Purchaseorderwaspaid )
            {
               AV26CanAddItem = true;
            }
         }
      }

      protected void S121( )
      {
         /* 'CHECKIMAGES' Routine */
         returnInSub = false;
         AV21PurchaseOrder.Load(AV27PurchaseOrderIdAux);
         AV22CanRegister = false;
         AV24CanEdit = false;
         AV23CanCancel = false;
         AV25CanPay = false;
         if ( AV21PurchaseOrder.gxTpr_Purchaseorderactive )
         {
            if ( ! ( AV21PurchaseOrder.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_IsNull( ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) || ( DateTimeUtil.ResetTime ( AV21PurchaseOrder.gxTpr_Purchaseordercloseddate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) ) )
            {
               if ( ! AV21PurchaseOrder.gxTpr_Purchaseorderwaspaid )
               {
                  AV25CanPay = true;
               }
            }
            else if ( AV21PurchaseOrder.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_IsNull( ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) || ( DateTimeUtil.ResetTime ( AV21PurchaseOrder.gxTpr_Purchaseordercloseddate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseordercloseddate) )
            {
               if ( AV21PurchaseOrder.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_IsNull( ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseorderconfirmateddate) || ( DateTimeUtil.ResetTime ( AV21PurchaseOrder.gxTpr_Purchaseorderconfirmateddate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==AV21PurchaseOrder.gxTpr_Purchaseorderconfirmateddate) )
               {
                  AV22CanRegister = true;
                  AV24CanEdit = true;
                  AV23CanCancel = true;
               }
               else
               {
                  AV22CanRegister = true;
               }
            }
            else
            {
               AV22CanRegister = false;
               AV24CanEdit = false;
               AV23CanCancel = false;
               AV25CanPay = false;
            }
         }
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
         AV12SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         AV18Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         P00193_A79PurchaseOrderActive = new bool[] {false} ;
         P00193_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P00193_A4SupplierId = new int[1] ;
         P00193_A50PurchaseOrderId = new int[1] ;
         P00193_A5SupplierName = new string[] {""} ;
         P00193_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P00193_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P00193_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P00193_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         P00193_A67PurchaseOrderDetailsQuantity = new short[1] ;
         P00193_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         A5SupplierName = "";
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         AV14SDTPurchaseOrderGenerateListItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
         AV17StringAux = "";
         AV21PurchaseOrder = new SdtPurchaseOrder(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordergetfiltered__default(),
            new Object[][] {
                new Object[] {
               P00193_A79PurchaseOrderActive, P00193_A52PurchaseOrderCreatedDate, P00193_A4SupplierId, P00193_A50PurchaseOrderId, P00193_A5SupplierName, P00193_A66PurchaseOrderClosedDate, P00193_n66PurchaseOrderClosedDate, P00193_A135PurchaseOrderConfirmatedDate, P00193_n135PurchaseOrderConfirmatedDate, P00193_A67PurchaseOrderDetailsQuantity,
               P00193_n67PurchaseOrderDetailsQuantity
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15OrderBy ;
      private short A67PurchaseOrderDetailsQuantity ;
      private int AV20PurchaseOrderId ;
      private int AV9SupplierId ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int AV27PurchaseOrderIdAux ;
      private string scmdbuf ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private bool AV16Descending ;
      private bool AV19AllOk ;
      private bool A79PurchaseOrderActive ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n67PurchaseOrderDetailsQuantity ;
      private bool returnInSub ;
      private bool AV26CanAddItem ;
      private bool AV22CanRegister ;
      private bool AV24CanEdit ;
      private bool AV23CanCancel ;
      private bool AV25CanPay ;
      private string A5SupplierName ;
      private string AV17StringAux ;
      private IGxDataStore dsDefault ;
      private DateTime aP2_FromDate ;
      private DateTime aP3_ToDate ;
      private short aP4_OrderBy ;
      private bool aP5_Descending ;
      private IDataStoreProvider pr_default ;
      private bool[] P00193_A79PurchaseOrderActive ;
      private DateTime[] P00193_A52PurchaseOrderCreatedDate ;
      private int[] P00193_A4SupplierId ;
      private int[] P00193_A50PurchaseOrderId ;
      private string[] P00193_A5SupplierName ;
      private DateTime[] P00193_A66PurchaseOrderClosedDate ;
      private bool[] P00193_n66PurchaseOrderClosedDate ;
      private DateTime[] P00193_A135PurchaseOrderConfirmatedDate ;
      private bool[] P00193_n135PurchaseOrderConfirmatedDate ;
      private short[] P00193_A67PurchaseOrderDetailsQuantity ;
      private bool[] P00193_n67PurchaseOrderDetailsQuantity ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> aP6_SDTPurchaseOrderGenerateList ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV12SDTPurchaseOrderGenerateList ;
      private SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem AV14SDTPurchaseOrderGenerateListItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV18Context ;
      private SdtPurchaseOrder AV21PurchaseOrder ;
   }

   public class purchaseordergetfiltered__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00193( IGxContext context ,
                                             int AV20PurchaseOrderId ,
                                             int AV9SupplierId ,
                                             DateTime AV10FromDate ,
                                             DateTime AV11ToDate ,
                                             int A50PurchaseOrderId ,
                                             int A4SupplierId ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             bool A79PurchaseOrderActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PurchaseOrderActive], T1.[PurchaseOrderCreatedDate], T1.[SupplierId], T1.[PurchaseOrderId], T2.[SupplierName], T1.[PurchaseOrderClosedDate], T1.[PurchaseOrderConfirmatedDate], COALESCE( T3.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T3 ON T3.[PurchaseOrderId] = T1.[PurchaseOrderId])";
         AddWhere(sWhereString, "(T1.[PurchaseOrderActive] = 1)");
         if ( ! (0==AV20PurchaseOrderId) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderId] = @AV20PurchaseOrderId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV9SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV9SupplierId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV10FromDate) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] >= @AV10FromDate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11ToDate) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] <= @AV11ToDate)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PurchaseOrderId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00193(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (bool)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00193;
          prmP00193 = new Object[] {
          new ParDef("@AV20PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV9SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV10FromDate",GXType.Date,8,0) ,
          new ParDef("@AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00193", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00193,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
