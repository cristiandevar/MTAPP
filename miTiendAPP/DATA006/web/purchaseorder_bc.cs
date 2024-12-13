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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class purchaseorder_bc : GxSilentTrn, IGxSilentTrn
   {
      public purchaseorder_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorder_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0710( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0710( ) ;
         standaloneModal( ) ;
         AddRow0710( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z50PurchaseOrderId = A50PurchaseOrderId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_070( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0710( ) ;
            }
            else
            {
               CheckExtendedTable0710( ) ;
               if ( AnyError == 0 )
               {
                  ZM0710( 17) ;
                  ZM0710( 18) ;
               }
               CloseExtendedTableCursors0710( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode10 = Gx_mode;
            CONFIRM_0712( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode10;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode10;
         }
      }

      protected void CONFIRM_0712( )
      {
         s96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         nGXsfl_12_idx = 0;
         while ( nGXsfl_12_idx < bcPurchaseOrder.gxTpr_Detail.Count )
         {
            ReadRow0712( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound12 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_12 != 0 ) )
            {
               GetKey0712( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0712( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0712( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0712( 20) ;
                           ZM0712( 24) ;
                        }
                        CloseExtendedTableCursors0712( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                        O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0712( ) ;
                        Load0712( ) ;
                        BeforeValidate0712( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0712( ) ;
                           O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                           O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                        }
                     }
                     else
                     {
                        if ( nIsMod_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0712( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0712( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0712( 20) ;
                                 ZM0712( 24) ;
                              }
                              CloseExtendedTableCursors0712( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                              O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow12( ((SdtPurchaseOrder_Detail)bcPurchaseOrder.gxTpr_Detail.Item(nGXsfl_12_idx))) ;
            }
         }
         O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
         O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
         /* Start of After( level) rules */
         /* Using cursor BC00076 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A96PurchaseOrderLastDetailId = BC00076_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            A96PurchaseOrderLastDetailId = 0;
         }
         /* End of After( level) rules */
      }

      protected void E12072( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0710( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            Z78PurchaseOrderTotalPaid = A78PurchaseOrderTotalPaid;
            Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
            Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
            Z135PurchaseOrderConfirmatedDate = A135PurchaseOrderConfirmatedDate;
            Z79PurchaseOrderActive = A79PurchaseOrderActive;
            Z136PurchaseOrderCanceledDescripti = A136PurchaseOrderCanceledDescripti;
            Z138PurchaseOrderWasPaid = A138PurchaseOrderWasPaid;
            Z139PurchaseOrderPaidDate = A139PurchaseOrderPaidDate;
            Z4SupplierId = A4SupplierId;
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z5SupplierName = A5SupplierName;
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         }
         if ( GX_JID == -16 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            Z78PurchaseOrderTotalPaid = A78PurchaseOrderTotalPaid;
            Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
            Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
            Z135PurchaseOrderConfirmatedDate = A135PurchaseOrderConfirmatedDate;
            Z79PurchaseOrderActive = A79PurchaseOrderActive;
            Z136PurchaseOrderCanceledDescripti = A136PurchaseOrderCanceledDescripti;
            Z138PurchaseOrderWasPaid = A138PurchaseOrderWasPaid;
            Z139PurchaseOrderPaidDate = A139PurchaseOrderPaidDate;
            Z4SupplierId = A4SupplierId;
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
            Z5SupplierName = A5SupplierName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A52PurchaseOrderCreatedDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A53PurchaseOrderModifiedDate = Gx_date;
            n53PurchaseOrderModifiedDate = false;
         }
         if ( IsIns( )  && (false==A79PurchaseOrderActive) && ( Gx_BScreen == 0 ) )
         {
            A79PurchaseOrderActive = true;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0710( )
      {
         /* Using cursor BC000711 */
         pr_default.execute(7, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
            A5SupplierName = BC000711_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = BC000711_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = BC000711_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = BC000711_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = BC000711_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = BC000711_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = BC000711_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = BC000711_n53PurchaseOrderModifiedDate[0];
            A135PurchaseOrderConfirmatedDate = BC000711_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = BC000711_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = BC000711_A79PurchaseOrderActive[0];
            A136PurchaseOrderCanceledDescripti = BC000711_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = BC000711_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = BC000711_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = BC000711_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = BC000711_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = BC000711_n139PurchaseOrderPaidDate[0];
            A4SupplierId = BC000711_A4SupplierId[0];
            A67PurchaseOrderDetailsQuantity = BC000711_A67PurchaseOrderDetailsQuantity[0];
            A96PurchaseOrderLastDetailId = BC000711_A96PurchaseOrderLastDetailId[0];
            ZM0710( -16) ;
         }
         pr_default.close(7);
         OnLoadActions0710( ) ;
      }

      protected void OnLoadActions0710( )
      {
         O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         AV15Pgmname = "PurchaseOrder_BC";
      }

      protected void CheckExtendedTable0710( )
      {
         nIsDirty_10 = 0;
         standaloneModal( ) ;
         AV15Pgmname = "PurchaseOrder_BC";
         /* Using cursor BC00076 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = BC00076_A67PurchaseOrderDetailsQuantity[0];
            A96PurchaseOrderLastDetailId = BC00076_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            nIsDirty_10 = 1;
            A67PurchaseOrderDetailsQuantity = 0;
            nIsDirty_10 = 1;
            A96PurchaseOrderLastDetailId = 0;
         }
         pr_default.close(3);
         /* Using cursor BC00079 */
         pr_default.execute(6, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
         }
         A5SupplierName = BC00079_A5SupplierName[0];
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A52PurchaseOrderCreatedDate) || ( DateTimeUtil.ResetTime ( A52PurchaseOrderCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Created Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A78PurchaseOrderTotalPaid >= Convert.ToDecimal( 0 )) && ( A78PurchaseOrderTotalPaid <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A78PurchaseOrderTotalPaid) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Closed Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A53PurchaseOrderModifiedDate) || ( DateTimeUtil.ResetTime ( A53PurchaseOrderModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Modified Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A135PurchaseOrderConfirmatedDate) || ( DateTimeUtil.ResetTime ( A135PurchaseOrderConfirmatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Confirmated Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A139PurchaseOrderPaidDate) || ( DateTimeUtil.ResetTime ( A139PurchaseOrderPaidDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Paid Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0710( )
      {
         pr_default.close(3);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0710( )
      {
         /* Using cursor BC000712 */
         pr_default.execute(8, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00078 */
         pr_default.execute(5, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0710( 16) ;
            RcdFound10 = 1;
            A50PurchaseOrderId = BC00078_A50PurchaseOrderId[0];
            A52PurchaseOrderCreatedDate = BC00078_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = BC00078_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = BC00078_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = BC00078_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = BC00078_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = BC00078_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = BC00078_n53PurchaseOrderModifiedDate[0];
            A135PurchaseOrderConfirmatedDate = BC00078_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = BC00078_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = BC00078_A79PurchaseOrderActive[0];
            A136PurchaseOrderCanceledDescripti = BC00078_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = BC00078_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = BC00078_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = BC00078_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = BC00078_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = BC00078_n139PurchaseOrderPaidDate[0];
            A4SupplierId = BC00078_A4SupplierId[0];
            Z50PurchaseOrderId = A50PurchaseOrderId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0710( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0710( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0710( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0710( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_070( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0710( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00077 */
            pr_default.execute(4, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrder"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z52PurchaseOrderCreatedDate ) != DateTimeUtil.ResetTime ( BC00077_A52PurchaseOrderCreatedDate[0] ) ) || ( Z78PurchaseOrderTotalPaid != BC00077_A78PurchaseOrderTotalPaid[0] ) || ( DateTimeUtil.ResetTime ( Z66PurchaseOrderClosedDate ) != DateTimeUtil.ResetTime ( BC00077_A66PurchaseOrderClosedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z53PurchaseOrderModifiedDate ) != DateTimeUtil.ResetTime ( BC00077_A53PurchaseOrderModifiedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z135PurchaseOrderConfirmatedDate ) != DateTimeUtil.ResetTime ( BC00077_A135PurchaseOrderConfirmatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z79PurchaseOrderActive != BC00077_A79PurchaseOrderActive[0] ) || ( StringUtil.StrCmp(Z136PurchaseOrderCanceledDescripti, BC00077_A136PurchaseOrderCanceledDescripti[0]) != 0 ) || ( Z138PurchaseOrderWasPaid != BC00077_A138PurchaseOrderWasPaid[0] ) || ( DateTimeUtil.ResetTime ( Z139PurchaseOrderPaidDate ) != DateTimeUtil.ResetTime ( BC00077_A139PurchaseOrderPaidDate[0] ) ) || ( Z4SupplierId != BC00077_A4SupplierId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PurchaseOrder"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0710( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0710( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0710( 0) ;
            CheckOptimisticConcurrency0710( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0710( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0710( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000713 */
                     pr_default.execute(9, new Object[] {A52PurchaseOrderCreatedDate, n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, n139PurchaseOrderPaidDate, A139PurchaseOrderPaidDate, A4SupplierId});
                     A50PurchaseOrderId = BC000713_A50PurchaseOrderId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0710( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0710( ) ;
            }
            EndLevel0710( ) ;
         }
         CloseExtendedTableCursors0710( ) ;
      }

      protected void Update0710( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0710( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0710( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0710( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0710( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000714 */
                     pr_default.execute(10, new Object[] {A52PurchaseOrderCreatedDate, n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, n139PurchaseOrderPaidDate, A139PurchaseOrderPaidDate, A4SupplierId, A50PurchaseOrderId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrder"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0710( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0710( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0710( ) ;
         }
         CloseExtendedTableCursors0710( ) ;
      }

      protected void DeferredUpdate0710( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0710( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0710( ) ;
            AfterConfirm0710( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0710( ) ;
               if ( AnyError == 0 )
               {
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  ScanKeyStart0712( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0712( ) ;
                     Delete0712( ) ;
                     ScanKeyNext0712( ) ;
                     O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                     O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                  }
                  ScanKeyEnd0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000715 */
                     pr_default.execute(11, new Object[] {A50PurchaseOrderId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0710( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0710( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "PurchaseOrder_BC";
            /* Using cursor BC000717 */
            pr_default.execute(12, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A67PurchaseOrderDetailsQuantity = BC000717_A67PurchaseOrderDetailsQuantity[0];
               A96PurchaseOrderLastDetailId = BC000717_A96PurchaseOrderLastDetailId[0];
            }
            else
            {
               A67PurchaseOrderDetailsQuantity = 0;
               A96PurchaseOrderLastDetailId = 0;
            }
            pr_default.close(12);
            /* Using cursor BC000718 */
            pr_default.execute(13, new Object[] {A4SupplierId});
            A5SupplierName = BC000718_A5SupplierName[0];
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0712( )
      {
         s96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         nGXsfl_12_idx = 0;
         while ( nGXsfl_12_idx < bcPurchaseOrder.gxTpr_Detail.Count )
         {
            ReadRow0712( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound12 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_12 != 0 ) )
            {
               standaloneNotModal0712( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0712( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0712( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0712( ) ;
                  }
               }
               O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
               O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            }
            KeyVarsToRow12( ((SdtPurchaseOrder_Detail)bcPurchaseOrder.gxTpr_Detail.Item(nGXsfl_12_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_12_idx = 0;
            while ( nGXsfl_12_idx < bcPurchaseOrder.gxTpr_Detail.Count )
            {
               ReadRow0712( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcPurchaseOrder.gxTpr_Detail.RemoveElement(nGXsfl_12_idx);
                  nGXsfl_12_idx = (int)(nGXsfl_12_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0712( ) ;
                  VarsToRow12( ((SdtPurchaseOrder_Detail)bcPurchaseOrder.gxTpr_Detail.Item(nGXsfl_12_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* Using cursor BC000717 */
         pr_default.execute(12, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A96PurchaseOrderLastDetailId = BC000717_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            A96PurchaseOrderLastDetailId = 0;
         }
         /* End of After( level) rules */
         InitAll0712( ) ;
         if ( AnyError != 0 )
         {
            O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
         }
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         Gxremove12 = 0;
      }

      protected void ProcessLevel0710( )
      {
         /* Save parent mode. */
         sMode10 = Gx_mode;
         ProcessNestedLevel0712( ) ;
         if ( AnyError != 0 )
         {
            O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
         }
         /* Restore parent mode. */
         Gx_mode = sMode10;
         /* ' Update level parameters */
      }

      protected void EndLevel0710( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0710( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0710( )
      {
         /* Scan By routine */
         /* Using cursor BC000720 */
         pr_default.execute(14, new Object[] {A50PurchaseOrderId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound10 = 1;
            A50PurchaseOrderId = BC000720_A50PurchaseOrderId[0];
            A5SupplierName = BC000720_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = BC000720_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = BC000720_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = BC000720_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = BC000720_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = BC000720_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = BC000720_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = BC000720_n53PurchaseOrderModifiedDate[0];
            A135PurchaseOrderConfirmatedDate = BC000720_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = BC000720_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = BC000720_A79PurchaseOrderActive[0];
            A136PurchaseOrderCanceledDescripti = BC000720_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = BC000720_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = BC000720_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = BC000720_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = BC000720_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = BC000720_n139PurchaseOrderPaidDate[0];
            A4SupplierId = BC000720_A4SupplierId[0];
            A67PurchaseOrderDetailsQuantity = BC000720_A67PurchaseOrderDetailsQuantity[0];
            A96PurchaseOrderLastDetailId = BC000720_A96PurchaseOrderLastDetailId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0710( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound10 = 0;
         ScanKeyLoad0710( ) ;
      }

      protected void ScanKeyLoad0710( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound10 = 1;
            A50PurchaseOrderId = BC000720_A50PurchaseOrderId[0];
            A5SupplierName = BC000720_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = BC000720_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = BC000720_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = BC000720_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = BC000720_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = BC000720_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = BC000720_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = BC000720_n53PurchaseOrderModifiedDate[0];
            A135PurchaseOrderConfirmatedDate = BC000720_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = BC000720_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = BC000720_A79PurchaseOrderActive[0];
            A136PurchaseOrderCanceledDescripti = BC000720_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = BC000720_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = BC000720_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = BC000720_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = BC000720_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = BC000720_n139PurchaseOrderPaidDate[0];
            A4SupplierId = BC000720_A4SupplierId[0];
            A67PurchaseOrderDetailsQuantity = BC000720_A67PurchaseOrderDetailsQuantity[0];
            A96PurchaseOrderLastDetailId = BC000720_A96PurchaseOrderLastDetailId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0710( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0710( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0710( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0710( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0710( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0710( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0710( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0710( )
      {
      }

      protected void ZM0712( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z76PurchaseOrderDetailQuantityOrd = A76PurchaseOrderDetailQuantityOrd;
            Z77PurchaseOrderDetailQuantityRec = A77PurchaseOrderDetailQuantityRec;
            Z134PurchaseOrderDetailSuggestedPr = A134PurchaseOrderDetailSuggestedPr;
            Z15ProductId = A15ProductId;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z16ProductName = A16ProductName;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -19 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            Z76PurchaseOrderDetailQuantityOrd = A76PurchaseOrderDetailQuantityOrd;
            Z77PurchaseOrderDetailQuantityRec = A77PurchaseOrderDetailQuantityRec;
            Z134PurchaseOrderDetailSuggestedPr = A134PurchaseOrderDetailSuggestedPr;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
         }
      }

      protected void standaloneNotModal0712( )
      {
      }

      protected void standaloneModal0712( )
      {
         if ( IsIns( )  )
         {
            A96PurchaseOrderLastDetailId = (int)(O96PurchaseOrderLastDetailId+1);
         }
         if ( IsIns( )  )
         {
            A61PurchaseOrderDetailId = A96PurchaseOrderLastDetailId;
         }
      }

      protected void Load0712( )
      {
         /* Using cursor BC000721 */
         pr_default.execute(15, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound12 = 1;
            A16ProductName = BC000721_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = BC000721_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = BC000721_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = BC000721_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = BC000721_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = BC000721_A15ProductId[0];
            ZM0712( -19) ;
         }
         pr_default.close(15);
         OnLoadActions0712( ) ;
      }

      protected void OnLoadActions0712( )
      {
         if ( IsIns( )  )
         {
            A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
         }
         else
         {
            if ( IsUpd( )  )
            {
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
               }
            }
         }
      }

      protected void CheckExtendedTable0712( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal0712( ) ;
         Gx_BScreen = 0;
         if ( IsIns( )  )
         {
            nIsDirty_12 = 1;
            A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_12 = 1;
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_12 = 1;
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
               }
            }
         }
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A16ProductName = BC00074_A16ProductName[0];
         pr_default.close(2);
         if ( A76PurchaseOrderDetailQuantityOrd <= 0 )
         {
            GX_msglist.addItem("Enter a positive, integer number", 1, "");
            AnyError = 1;
         }
         if ( A77PurchaseOrderDetailQuantityRec < 0 )
         {
            GX_msglist.addItem("Enter a positive, integer number o zero", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A134PurchaseOrderDetailSuggestedPr >= Convert.ToDecimal( 0 )) && ( A134PurchaseOrderDetailSuggestedPr <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A134PurchaseOrderDetailSuggestedPr) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0712( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0712( )
      {
      }

      protected void GetKey0712( )
      {
         /* Using cursor BC000722 */
         pr_default.execute(16, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0712( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0712( 19) ;
            RcdFound12 = 1;
            InitializeNonKey0712( ) ;
            A61PurchaseOrderDetailId = BC00073_A61PurchaseOrderDetailId[0];
            A76PurchaseOrderDetailQuantityOrd = BC00073_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = BC00073_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = BC00073_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = BC00073_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = BC00073_A15ProductId[0];
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0712( ) ;
            Load0712( ) ;
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0712( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0712( ) ;
            Gx_mode = sMode12;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0712( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0712( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrderDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z76PurchaseOrderDetailQuantityOrd != BC00072_A76PurchaseOrderDetailQuantityOrd[0] ) || ( Z77PurchaseOrderDetailQuantityRec != BC00072_A77PurchaseOrderDetailQuantityRec[0] ) || ( Z134PurchaseOrderDetailSuggestedPr != BC00072_A134PurchaseOrderDetailSuggestedPr[0] ) || ( Z15ProductId != BC00072_A15ProductId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PurchaseOrderDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0712( )
      {
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0712( 0) ;
            CheckOptimisticConcurrency0712( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0712( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000723 */
                     pr_default.execute(17, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId, A76PurchaseOrderDetailQuantityOrd, A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A15ProductId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0712( ) ;
            }
            EndLevel0712( ) ;
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void Update0712( )
      {
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0712( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0712( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000724 */
                     pr_default.execute(18, new Object[] {A76PurchaseOrderDetailQuantityOrd, A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A15ProductId, A50PurchaseOrderId, A61PurchaseOrderDetailId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrderDetail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0712( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0712( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0712( ) ;
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void DeferredUpdate0712( )
      {
      }

      protected void Delete0712( )
      {
         Gx_mode = "DLT";
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0712( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0712( ) ;
            AfterConfirm0712( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0712( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000725 */
                  pr_default.execute(19, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0712( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0712( )
      {
         standaloneModal0712( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                  }
               }
            }
            /* Using cursor BC000726 */
            pr_default.execute(20, new Object[] {A15ProductId});
            A16ProductName = BC000726_A16ProductName[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel0712( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0712( )
      {
         /* Scan By routine */
         /* Using cursor BC000727 */
         pr_default.execute(21, new Object[] {A50PurchaseOrderId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound12 = 1;
            A61PurchaseOrderDetailId = BC000727_A61PurchaseOrderDetailId[0];
            A16ProductName = BC000727_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = BC000727_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = BC000727_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = BC000727_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = BC000727_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = BC000727_A15ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0712( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound12 = 0;
         ScanKeyLoad0712( ) ;
      }

      protected void ScanKeyLoad0712( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound12 = 1;
            A61PurchaseOrderDetailId = BC000727_A61PurchaseOrderDetailId[0];
            A16ProductName = BC000727_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = BC000727_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = BC000727_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = BC000727_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = BC000727_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = BC000727_A15ProductId[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0712( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0712( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0712( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0712( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0712( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0712( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0712( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0712( )
      {
      }

      protected void send_integrity_lvl_hashes0712( )
      {
      }

      protected void send_integrity_lvl_hashes0710( )
      {
      }

      protected void AddRow0710( )
      {
         VarsToRow10( bcPurchaseOrder) ;
      }

      protected void ReadRow0710( )
      {
         RowToVars10( bcPurchaseOrder, 1) ;
      }

      protected void AddRow0712( )
      {
         SdtPurchaseOrder_Detail obj12;
         obj12 = new SdtPurchaseOrder_Detail(context);
         VarsToRow12( obj12) ;
         bcPurchaseOrder.gxTpr_Detail.Add(obj12, 0);
         obj12.gxTpr_Mode = "UPD";
         obj12.gxTpr_Modified = 0;
      }

      protected void ReadRow0712( )
      {
         nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
         RowToVars12( ((SdtPurchaseOrder_Detail)bcPurchaseOrder.gxTpr_Detail.Item(nGXsfl_12_idx)), 1) ;
      }

      protected void InitializeNonKey0710( )
      {
         A4SupplierId = 0;
         A5SupplierName = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A78PurchaseOrderTotalPaid = 0;
         n78PurchaseOrderTotalPaid = false;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         n66PurchaseOrderClosedDate = false;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         n53PurchaseOrderModifiedDate = false;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         n135PurchaseOrderConfirmatedDate = false;
         A136PurchaseOrderCanceledDescripti = "";
         n136PurchaseOrderCanceledDescripti = false;
         A138PurchaseOrderWasPaid = false;
         n138PurchaseOrderWasPaid = false;
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         n139PurchaseOrderPaidDate = false;
         A67PurchaseOrderDetailsQuantity = 0;
         A96PurchaseOrderLastDetailId = 0;
         A79PurchaseOrderActive = true;
         O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z78PurchaseOrderTotalPaid = 0;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
         Z135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         Z79PurchaseOrderActive = false;
         Z136PurchaseOrderCanceledDescripti = "";
         Z138PurchaseOrderWasPaid = false;
         Z139PurchaseOrderPaidDate = DateTime.MinValue;
         Z4SupplierId = 0;
      }

      protected void InitAll0710( )
      {
         A50PurchaseOrderId = 0;
         InitializeNonKey0710( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A79PurchaseOrderActive = i79PurchaseOrderActive;
      }

      protected void InitializeNonKey0712( )
      {
         A15ProductId = 0;
         A16ProductName = "";
         A76PurchaseOrderDetailQuantityOrd = 0;
         A77PurchaseOrderDetailQuantityRec = 0;
         A134PurchaseOrderDetailSuggestedPr = 0;
         n134PurchaseOrderDetailSuggestedPr = false;
         Z76PurchaseOrderDetailQuantityOrd = 0;
         Z77PurchaseOrderDetailQuantityRec = 0;
         Z134PurchaseOrderDetailSuggestedPr = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0712( )
      {
         A61PurchaseOrderDetailId = 0;
         InitializeNonKey0712( ) ;
      }

      protected void StandaloneModalInsert0712( )
      {
         A96PurchaseOrderLastDetailId = i96PurchaseOrderLastDetailId;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow10( SdtPurchaseOrder obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Supplierid = A4SupplierId;
         obj10.gxTpr_Suppliername = A5SupplierName;
         obj10.gxTpr_Purchaseordercreateddate = A52PurchaseOrderCreatedDate;
         obj10.gxTpr_Purchaseordertotalpaid = A78PurchaseOrderTotalPaid;
         obj10.gxTpr_Purchaseordercloseddate = A66PurchaseOrderClosedDate;
         obj10.gxTpr_Purchaseordermodifieddate = A53PurchaseOrderModifiedDate;
         obj10.gxTpr_Purchaseorderconfirmateddate = A135PurchaseOrderConfirmatedDate;
         obj10.gxTpr_Purchaseordercanceleddescription = A136PurchaseOrderCanceledDescripti;
         obj10.gxTpr_Purchaseorderwaspaid = A138PurchaseOrderWasPaid;
         obj10.gxTpr_Purchaseorderpaiddate = A139PurchaseOrderPaidDate;
         obj10.gxTpr_Purchaseorderdetailsquantity = A67PurchaseOrderDetailsQuantity;
         obj10.gxTpr_Purchaseorderlastdetailid = A96PurchaseOrderLastDetailId;
         obj10.gxTpr_Purchaseorderactive = A79PurchaseOrderActive;
         obj10.gxTpr_Purchaseorderid = A50PurchaseOrderId;
         obj10.gxTpr_Purchaseorderid_Z = Z50PurchaseOrderId;
         obj10.gxTpr_Supplierid_Z = Z4SupplierId;
         obj10.gxTpr_Suppliername_Z = Z5SupplierName;
         obj10.gxTpr_Purchaseordercreateddate_Z = Z52PurchaseOrderCreatedDate;
         obj10.gxTpr_Purchaseordertotalpaid_Z = Z78PurchaseOrderTotalPaid;
         obj10.gxTpr_Purchaseordercloseddate_Z = Z66PurchaseOrderClosedDate;
         obj10.gxTpr_Purchaseordermodifieddate_Z = Z53PurchaseOrderModifiedDate;
         obj10.gxTpr_Purchaseorderconfirmateddate_Z = Z135PurchaseOrderConfirmatedDate;
         obj10.gxTpr_Purchaseorderactive_Z = Z79PurchaseOrderActive;
         obj10.gxTpr_Purchaseordercanceleddescription_Z = Z136PurchaseOrderCanceledDescripti;
         obj10.gxTpr_Purchaseorderwaspaid_Z = Z138PurchaseOrderWasPaid;
         obj10.gxTpr_Purchaseorderpaiddate_Z = Z139PurchaseOrderPaidDate;
         obj10.gxTpr_Purchaseorderdetailsquantity_Z = Z67PurchaseOrderDetailsQuantity;
         obj10.gxTpr_Purchaseorderlastdetailid_Z = Z96PurchaseOrderLastDetailId;
         obj10.gxTpr_Purchaseordertotalpaid_N = (short)(Convert.ToInt16(n78PurchaseOrderTotalPaid));
         obj10.gxTpr_Purchaseordercloseddate_N = (short)(Convert.ToInt16(n66PurchaseOrderClosedDate));
         obj10.gxTpr_Purchaseordermodifieddate_N = (short)(Convert.ToInt16(n53PurchaseOrderModifiedDate));
         obj10.gxTpr_Purchaseorderconfirmateddate_N = (short)(Convert.ToInt16(n135PurchaseOrderConfirmatedDate));
         obj10.gxTpr_Purchaseordercanceleddescription_N = (short)(Convert.ToInt16(n136PurchaseOrderCanceledDescripti));
         obj10.gxTpr_Purchaseorderwaspaid_N = (short)(Convert.ToInt16(n138PurchaseOrderWasPaid));
         obj10.gxTpr_Purchaseorderpaiddate_N = (short)(Convert.ToInt16(n139PurchaseOrderPaidDate));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( SdtPurchaseOrder obj10 )
      {
         obj10.gxTpr_Purchaseorderid = A50PurchaseOrderId;
         return  ;
      }

      public void RowToVars10( SdtPurchaseOrder obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A4SupplierId = obj10.gxTpr_Supplierid;
         A5SupplierName = obj10.gxTpr_Suppliername;
         A52PurchaseOrderCreatedDate = obj10.gxTpr_Purchaseordercreateddate;
         A78PurchaseOrderTotalPaid = obj10.gxTpr_Purchaseordertotalpaid;
         n78PurchaseOrderTotalPaid = false;
         A66PurchaseOrderClosedDate = obj10.gxTpr_Purchaseordercloseddate;
         n66PurchaseOrderClosedDate = false;
         A53PurchaseOrderModifiedDate = obj10.gxTpr_Purchaseordermodifieddate;
         n53PurchaseOrderModifiedDate = false;
         A135PurchaseOrderConfirmatedDate = obj10.gxTpr_Purchaseorderconfirmateddate;
         n135PurchaseOrderConfirmatedDate = false;
         A136PurchaseOrderCanceledDescripti = obj10.gxTpr_Purchaseordercanceleddescription;
         n136PurchaseOrderCanceledDescripti = false;
         A138PurchaseOrderWasPaid = obj10.gxTpr_Purchaseorderwaspaid;
         n138PurchaseOrderWasPaid = false;
         A139PurchaseOrderPaidDate = obj10.gxTpr_Purchaseorderpaiddate;
         n139PurchaseOrderPaidDate = false;
         A67PurchaseOrderDetailsQuantity = obj10.gxTpr_Purchaseorderdetailsquantity;
         if ( forceLoad == 1 )
         {
            A96PurchaseOrderLastDetailId = obj10.gxTpr_Purchaseorderlastdetailid;
         }
         A79PurchaseOrderActive = obj10.gxTpr_Purchaseorderactive;
         A50PurchaseOrderId = obj10.gxTpr_Purchaseorderid;
         Z50PurchaseOrderId = obj10.gxTpr_Purchaseorderid_Z;
         Z4SupplierId = obj10.gxTpr_Supplierid_Z;
         Z5SupplierName = obj10.gxTpr_Suppliername_Z;
         Z52PurchaseOrderCreatedDate = obj10.gxTpr_Purchaseordercreateddate_Z;
         Z78PurchaseOrderTotalPaid = obj10.gxTpr_Purchaseordertotalpaid_Z;
         Z66PurchaseOrderClosedDate = obj10.gxTpr_Purchaseordercloseddate_Z;
         Z53PurchaseOrderModifiedDate = obj10.gxTpr_Purchaseordermodifieddate_Z;
         Z135PurchaseOrderConfirmatedDate = obj10.gxTpr_Purchaseorderconfirmateddate_Z;
         Z79PurchaseOrderActive = obj10.gxTpr_Purchaseorderactive_Z;
         Z136PurchaseOrderCanceledDescripti = obj10.gxTpr_Purchaseordercanceleddescription_Z;
         Z138PurchaseOrderWasPaid = obj10.gxTpr_Purchaseorderwaspaid_Z;
         Z139PurchaseOrderPaidDate = obj10.gxTpr_Purchaseorderpaiddate_Z;
         Z67PurchaseOrderDetailsQuantity = obj10.gxTpr_Purchaseorderdetailsquantity_Z;
         O67PurchaseOrderDetailsQuantity = obj10.gxTpr_Purchaseorderdetailsquantity_Z;
         Z96PurchaseOrderLastDetailId = obj10.gxTpr_Purchaseorderlastdetailid_Z;
         O96PurchaseOrderLastDetailId = obj10.gxTpr_Purchaseorderlastdetailid_Z;
         n78PurchaseOrderTotalPaid = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseordertotalpaid_N));
         n66PurchaseOrderClosedDate = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseordercloseddate_N));
         n53PurchaseOrderModifiedDate = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseordermodifieddate_N));
         n135PurchaseOrderConfirmatedDate = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseorderconfirmateddate_N));
         n136PurchaseOrderCanceledDescripti = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseordercanceleddescription_N));
         n138PurchaseOrderWasPaid = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseorderwaspaid_N));
         n139PurchaseOrderPaidDate = (bool)(Convert.ToBoolean(obj10.gxTpr_Purchaseorderpaiddate_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow12( SdtPurchaseOrder_Detail obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Productid = A15ProductId;
         obj12.gxTpr_Productname = A16ProductName;
         obj12.gxTpr_Purchaseorderdetailquantityordered = A76PurchaseOrderDetailQuantityOrd;
         obj12.gxTpr_Purchaseorderdetailquantityreceived = A77PurchaseOrderDetailQuantityRec;
         obj12.gxTpr_Purchaseorderdetailsuggestedprice = A134PurchaseOrderDetailSuggestedPr;
         obj12.gxTpr_Purchaseorderdetailid = A61PurchaseOrderDetailId;
         obj12.gxTpr_Purchaseorderdetailid_Z = Z61PurchaseOrderDetailId;
         obj12.gxTpr_Productid_Z = Z15ProductId;
         obj12.gxTpr_Productname_Z = Z16ProductName;
         obj12.gxTpr_Purchaseorderdetailquantityordered_Z = Z76PurchaseOrderDetailQuantityOrd;
         obj12.gxTpr_Purchaseorderdetailquantityreceived_Z = Z77PurchaseOrderDetailQuantityRec;
         obj12.gxTpr_Purchaseorderdetailsuggestedprice_Z = Z134PurchaseOrderDetailSuggestedPr;
         obj12.gxTpr_Purchaseorderdetailsuggestedprice_N = (short)(Convert.ToInt16(n134PurchaseOrderDetailSuggestedPr));
         obj12.gxTpr_Modified = nIsMod_12;
         return  ;
      }

      public void KeyVarsToRow12( SdtPurchaseOrder_Detail obj12 )
      {
         obj12.gxTpr_Purchaseorderdetailid = A61PurchaseOrderDetailId;
         return  ;
      }

      public void RowToVars12( SdtPurchaseOrder_Detail obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A15ProductId = obj12.gxTpr_Productid;
         A16ProductName = obj12.gxTpr_Productname;
         A76PurchaseOrderDetailQuantityOrd = obj12.gxTpr_Purchaseorderdetailquantityordered;
         A77PurchaseOrderDetailQuantityRec = obj12.gxTpr_Purchaseorderdetailquantityreceived;
         A134PurchaseOrderDetailSuggestedPr = obj12.gxTpr_Purchaseorderdetailsuggestedprice;
         n134PurchaseOrderDetailSuggestedPr = false;
         A61PurchaseOrderDetailId = obj12.gxTpr_Purchaseorderdetailid;
         Z61PurchaseOrderDetailId = obj12.gxTpr_Purchaseorderdetailid_Z;
         Z15ProductId = obj12.gxTpr_Productid_Z;
         Z16ProductName = obj12.gxTpr_Productname_Z;
         Z76PurchaseOrderDetailQuantityOrd = obj12.gxTpr_Purchaseorderdetailquantityordered_Z;
         Z77PurchaseOrderDetailQuantityRec = obj12.gxTpr_Purchaseorderdetailquantityreceived_Z;
         Z134PurchaseOrderDetailSuggestedPr = obj12.gxTpr_Purchaseorderdetailsuggestedprice_Z;
         n134PurchaseOrderDetailSuggestedPr = (bool)(Convert.ToBoolean(obj12.gxTpr_Purchaseorderdetailsuggestedprice_N));
         nIsMod_12 = obj12.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A50PurchaseOrderId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0710( ) ;
         ScanKeyStart0710( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z50PurchaseOrderId = A50PurchaseOrderId;
         }
         ZM0710( -16) ;
         OnLoadActions0710( ) ;
         AddRow0710( ) ;
         bcPurchaseOrder.gxTpr_Detail.ClearCollection();
         if ( RcdFound10 == 1 )
         {
            ScanKeyStart0712( ) ;
            nGXsfl_12_idx = 1;
            while ( RcdFound12 != 0 )
            {
               Z50PurchaseOrderId = A50PurchaseOrderId;
               Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
               ZM0712( -19) ;
               OnLoadActions0712( ) ;
               nRcdExists_12 = 1;
               nIsMod_12 = 0;
               AddRow0712( ) ;
               nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
               ScanKeyNext0712( ) ;
            }
            ScanKeyEnd0712( ) ;
         }
         ScanKeyEnd0710( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars10( bcPurchaseOrder, 0) ;
         ScanKeyStart0710( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z50PurchaseOrderId = A50PurchaseOrderId;
         }
         ZM0710( -16) ;
         OnLoadActions0710( ) ;
         AddRow0710( ) ;
         bcPurchaseOrder.gxTpr_Detail.ClearCollection();
         if ( RcdFound10 == 1 )
         {
            ScanKeyStart0712( ) ;
            nGXsfl_12_idx = 1;
            while ( RcdFound12 != 0 )
            {
               Z50PurchaseOrderId = A50PurchaseOrderId;
               Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
               ZM0712( -19) ;
               OnLoadActions0712( ) ;
               nRcdExists_12 = 1;
               nIsMod_12 = 0;
               AddRow0712( ) ;
               nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
               ScanKeyNext0712( ) ;
            }
            ScanKeyEnd0712( ) ;
         }
         ScanKeyEnd0710( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0710( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
            A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            Insert0710( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A50PurchaseOrderId != Z50PurchaseOrderId )
               {
                  A50PurchaseOrderId = Z50PurchaseOrderId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  Update0710( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A50PurchaseOrderId != Z50PurchaseOrderId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                        A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                        Insert0710( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                        A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                        Insert0710( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcPurchaseOrder, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcPurchaseOrder) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcPurchaseOrder, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
         A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         Insert0710( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcPurchaseOrder) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcPurchaseOrder) ;
         }
         else
         {
            SdtPurchaseOrder auxBC = new SdtPurchaseOrder(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A50PurchaseOrderId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPurchaseOrder);
               auxBC.Save();
               bcPurchaseOrder.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcPurchaseOrder, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars10( bcPurchaseOrder, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0710( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow10( bcPurchaseOrder) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcPurchaseOrder) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcPurchaseOrder, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0710( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A50PurchaseOrderId != Z50PurchaseOrderId )
            {
               A50PurchaseOrderId = Z50PurchaseOrderId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A50PurchaseOrderId != Z50PurchaseOrderId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(12);
         pr_default.close(20);
         context.RollbackDataStores("purchaseorder_bc",pr_default);
         VarsToRow10( bcPurchaseOrder) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcPurchaseOrder.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPurchaseOrder.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPurchaseOrder )
         {
            bcPurchaseOrder = (SdtPurchaseOrder)(sdt);
            if ( StringUtil.StrCmp(bcPurchaseOrder.gxTpr_Mode, "") == 0 )
            {
               bcPurchaseOrder.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcPurchaseOrder) ;
            }
            else
            {
               RowToVars10( bcPurchaseOrder, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPurchaseOrder.gxTpr_Mode, "") == 0 )
            {
               bcPurchaseOrder.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcPurchaseOrder, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPurchaseOrder PurchaseOrder_BC
      {
         get {
            return bcPurchaseOrder ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(5);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode10 = "";
         BC00076_A67PurchaseOrderDetailsQuantity = new short[1] ;
         BC00076_A96PurchaseOrderLastDetailId = new int[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV15Pgmname = "";
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         Z135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         Z136PurchaseOrderCanceledDescripti = "";
         A136PurchaseOrderCanceledDescripti = "";
         Z139PurchaseOrderPaidDate = DateTime.MinValue;
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         Z5SupplierName = "";
         A5SupplierName = "";
         Gx_date = DateTime.MinValue;
         BC000711_A50PurchaseOrderId = new int[1] ;
         BC000711_A5SupplierName = new string[] {""} ;
         BC000711_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000711_A78PurchaseOrderTotalPaid = new decimal[1] ;
         BC000711_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         BC000711_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         BC000711_n66PurchaseOrderClosedDate = new bool[] {false} ;
         BC000711_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000711_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         BC000711_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000711_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         BC000711_A79PurchaseOrderActive = new bool[] {false} ;
         BC000711_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         BC000711_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         BC000711_A138PurchaseOrderWasPaid = new bool[] {false} ;
         BC000711_n138PurchaseOrderWasPaid = new bool[] {false} ;
         BC000711_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         BC000711_n139PurchaseOrderPaidDate = new bool[] {false} ;
         BC000711_A4SupplierId = new int[1] ;
         BC000711_A67PurchaseOrderDetailsQuantity = new short[1] ;
         BC000711_A96PurchaseOrderLastDetailId = new int[1] ;
         BC00079_A5SupplierName = new string[] {""} ;
         BC000712_A50PurchaseOrderId = new int[1] ;
         BC00078_A50PurchaseOrderId = new int[1] ;
         BC00078_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00078_A78PurchaseOrderTotalPaid = new decimal[1] ;
         BC00078_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         BC00078_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         BC00078_n66PurchaseOrderClosedDate = new bool[] {false} ;
         BC00078_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00078_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         BC00078_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00078_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         BC00078_A79PurchaseOrderActive = new bool[] {false} ;
         BC00078_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         BC00078_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         BC00078_A138PurchaseOrderWasPaid = new bool[] {false} ;
         BC00078_n138PurchaseOrderWasPaid = new bool[] {false} ;
         BC00078_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         BC00078_n139PurchaseOrderPaidDate = new bool[] {false} ;
         BC00078_A4SupplierId = new int[1] ;
         BC00077_A50PurchaseOrderId = new int[1] ;
         BC00077_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00077_A78PurchaseOrderTotalPaid = new decimal[1] ;
         BC00077_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         BC00077_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         BC00077_n66PurchaseOrderClosedDate = new bool[] {false} ;
         BC00077_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00077_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         BC00077_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00077_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         BC00077_A79PurchaseOrderActive = new bool[] {false} ;
         BC00077_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         BC00077_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         BC00077_A138PurchaseOrderWasPaid = new bool[] {false} ;
         BC00077_n138PurchaseOrderWasPaid = new bool[] {false} ;
         BC00077_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         BC00077_n139PurchaseOrderPaidDate = new bool[] {false} ;
         BC00077_A4SupplierId = new int[1] ;
         BC000713_A50PurchaseOrderId = new int[1] ;
         BC000717_A67PurchaseOrderDetailsQuantity = new short[1] ;
         BC000717_A96PurchaseOrderLastDetailId = new int[1] ;
         BC000718_A5SupplierName = new string[] {""} ;
         BC000720_A50PurchaseOrderId = new int[1] ;
         BC000720_A5SupplierName = new string[] {""} ;
         BC000720_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000720_A78PurchaseOrderTotalPaid = new decimal[1] ;
         BC000720_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         BC000720_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         BC000720_n66PurchaseOrderClosedDate = new bool[] {false} ;
         BC000720_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000720_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         BC000720_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000720_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         BC000720_A79PurchaseOrderActive = new bool[] {false} ;
         BC000720_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         BC000720_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         BC000720_A138PurchaseOrderWasPaid = new bool[] {false} ;
         BC000720_n138PurchaseOrderWasPaid = new bool[] {false} ;
         BC000720_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         BC000720_n139PurchaseOrderPaidDate = new bool[] {false} ;
         BC000720_A4SupplierId = new int[1] ;
         BC000720_A67PurchaseOrderDetailsQuantity = new short[1] ;
         BC000720_A96PurchaseOrderLastDetailId = new int[1] ;
         Z16ProductName = "";
         A16ProductName = "";
         BC000721_A50PurchaseOrderId = new int[1] ;
         BC000721_A61PurchaseOrderDetailId = new int[1] ;
         BC000721_A16ProductName = new string[] {""} ;
         BC000721_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         BC000721_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         BC000721_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         BC000721_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         BC000721_A15ProductId = new int[1] ;
         BC00074_A16ProductName = new string[] {""} ;
         BC000722_A50PurchaseOrderId = new int[1] ;
         BC000722_A61PurchaseOrderDetailId = new int[1] ;
         BC00073_A50PurchaseOrderId = new int[1] ;
         BC00073_A61PurchaseOrderDetailId = new int[1] ;
         BC00073_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         BC00073_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         BC00073_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         BC00073_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         BC00073_A15ProductId = new int[1] ;
         sMode12 = "";
         BC00072_A50PurchaseOrderId = new int[1] ;
         BC00072_A61PurchaseOrderDetailId = new int[1] ;
         BC00072_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         BC00072_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         BC00072_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         BC00072_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         BC00072_A15ProductId = new int[1] ;
         BC000726_A16ProductName = new string[] {""} ;
         BC000727_A50PurchaseOrderId = new int[1] ;
         BC000727_A61PurchaseOrderDetailId = new int[1] ;
         BC000727_A16ProductName = new string[] {""} ;
         BC000727_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         BC000727_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         BC000727_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         BC000727_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         BC000727_A15ProductId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorder_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A50PurchaseOrderId, BC00072_A61PurchaseOrderDetailId, BC00072_A76PurchaseOrderDetailQuantityOrd, BC00072_A77PurchaseOrderDetailQuantityRec, BC00072_A134PurchaseOrderDetailSuggestedPr, BC00072_n134PurchaseOrderDetailSuggestedPr, BC00072_A15ProductId
               }
               , new Object[] {
               BC00073_A50PurchaseOrderId, BC00073_A61PurchaseOrderDetailId, BC00073_A76PurchaseOrderDetailQuantityOrd, BC00073_A77PurchaseOrderDetailQuantityRec, BC00073_A134PurchaseOrderDetailSuggestedPr, BC00073_n134PurchaseOrderDetailSuggestedPr, BC00073_A15ProductId
               }
               , new Object[] {
               BC00074_A16ProductName
               }
               , new Object[] {
               BC00076_A67PurchaseOrderDetailsQuantity, BC00076_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               BC00077_A50PurchaseOrderId, BC00077_A52PurchaseOrderCreatedDate, BC00077_A78PurchaseOrderTotalPaid, BC00077_n78PurchaseOrderTotalPaid, BC00077_A66PurchaseOrderClosedDate, BC00077_n66PurchaseOrderClosedDate, BC00077_A53PurchaseOrderModifiedDate, BC00077_n53PurchaseOrderModifiedDate, BC00077_A135PurchaseOrderConfirmatedDate, BC00077_n135PurchaseOrderConfirmatedDate,
               BC00077_A79PurchaseOrderActive, BC00077_A136PurchaseOrderCanceledDescripti, BC00077_n136PurchaseOrderCanceledDescripti, BC00077_A138PurchaseOrderWasPaid, BC00077_n138PurchaseOrderWasPaid, BC00077_A139PurchaseOrderPaidDate, BC00077_n139PurchaseOrderPaidDate, BC00077_A4SupplierId
               }
               , new Object[] {
               BC00078_A50PurchaseOrderId, BC00078_A52PurchaseOrderCreatedDate, BC00078_A78PurchaseOrderTotalPaid, BC00078_n78PurchaseOrderTotalPaid, BC00078_A66PurchaseOrderClosedDate, BC00078_n66PurchaseOrderClosedDate, BC00078_A53PurchaseOrderModifiedDate, BC00078_n53PurchaseOrderModifiedDate, BC00078_A135PurchaseOrderConfirmatedDate, BC00078_n135PurchaseOrderConfirmatedDate,
               BC00078_A79PurchaseOrderActive, BC00078_A136PurchaseOrderCanceledDescripti, BC00078_n136PurchaseOrderCanceledDescripti, BC00078_A138PurchaseOrderWasPaid, BC00078_n138PurchaseOrderWasPaid, BC00078_A139PurchaseOrderPaidDate, BC00078_n139PurchaseOrderPaidDate, BC00078_A4SupplierId
               }
               , new Object[] {
               BC00079_A5SupplierName
               }
               , new Object[] {
               BC000711_A50PurchaseOrderId, BC000711_A5SupplierName, BC000711_A52PurchaseOrderCreatedDate, BC000711_A78PurchaseOrderTotalPaid, BC000711_n78PurchaseOrderTotalPaid, BC000711_A66PurchaseOrderClosedDate, BC000711_n66PurchaseOrderClosedDate, BC000711_A53PurchaseOrderModifiedDate, BC000711_n53PurchaseOrderModifiedDate, BC000711_A135PurchaseOrderConfirmatedDate,
               BC000711_n135PurchaseOrderConfirmatedDate, BC000711_A79PurchaseOrderActive, BC000711_A136PurchaseOrderCanceledDescripti, BC000711_n136PurchaseOrderCanceledDescripti, BC000711_A138PurchaseOrderWasPaid, BC000711_n138PurchaseOrderWasPaid, BC000711_A139PurchaseOrderPaidDate, BC000711_n139PurchaseOrderPaidDate, BC000711_A4SupplierId, BC000711_A67PurchaseOrderDetailsQuantity,
               BC000711_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               BC000712_A50PurchaseOrderId
               }
               , new Object[] {
               BC000713_A50PurchaseOrderId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000717_A67PurchaseOrderDetailsQuantity, BC000717_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               BC000718_A5SupplierName
               }
               , new Object[] {
               BC000720_A50PurchaseOrderId, BC000720_A5SupplierName, BC000720_A52PurchaseOrderCreatedDate, BC000720_A78PurchaseOrderTotalPaid, BC000720_n78PurchaseOrderTotalPaid, BC000720_A66PurchaseOrderClosedDate, BC000720_n66PurchaseOrderClosedDate, BC000720_A53PurchaseOrderModifiedDate, BC000720_n53PurchaseOrderModifiedDate, BC000720_A135PurchaseOrderConfirmatedDate,
               BC000720_n135PurchaseOrderConfirmatedDate, BC000720_A79PurchaseOrderActive, BC000720_A136PurchaseOrderCanceledDescripti, BC000720_n136PurchaseOrderCanceledDescripti, BC000720_A138PurchaseOrderWasPaid, BC000720_n138PurchaseOrderWasPaid, BC000720_A139PurchaseOrderPaidDate, BC000720_n139PurchaseOrderPaidDate, BC000720_A4SupplierId, BC000720_A67PurchaseOrderDetailsQuantity,
               BC000720_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               BC000721_A50PurchaseOrderId, BC000721_A61PurchaseOrderDetailId, BC000721_A16ProductName, BC000721_A76PurchaseOrderDetailQuantityOrd, BC000721_A77PurchaseOrderDetailQuantityRec, BC000721_A134PurchaseOrderDetailSuggestedPr, BC000721_n134PurchaseOrderDetailSuggestedPr, BC000721_A15ProductId
               }
               , new Object[] {
               BC000722_A50PurchaseOrderId, BC000722_A61PurchaseOrderDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000726_A16ProductName
               }
               , new Object[] {
               BC000727_A50PurchaseOrderId, BC000727_A61PurchaseOrderDetailId, BC000727_A16ProductName, BC000727_A76PurchaseOrderDetailQuantityOrd, BC000727_A77PurchaseOrderDetailQuantityRec, BC000727_A134PurchaseOrderDetailSuggestedPr, BC000727_n134PurchaseOrderDetailSuggestedPr, BC000727_A15ProductId
               }
            }
         );
         Z79PurchaseOrderActive = true;
         A79PurchaseOrderActive = true;
         i79PurchaseOrderActive = true;
         AV15Pgmname = "PurchaseOrder_BC";
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short s67PurchaseOrderDetailsQuantity ;
      private short O67PurchaseOrderDetailsQuantity ;
      private short A67PurchaseOrderDetailsQuantity ;
      private short nIsMod_12 ;
      private short RcdFound12 ;
      private short GX_JID ;
      private short Z67PurchaseOrderDetailsQuantity ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short nRcdExists_12 ;
      private short Gxremove12 ;
      private short nIsDirty_12 ;
      private int trnEnded ;
      private int Z50PurchaseOrderId ;
      private int A50PurchaseOrderId ;
      private int s96PurchaseOrderLastDetailId ;
      private int O96PurchaseOrderLastDetailId ;
      private int A96PurchaseOrderLastDetailId ;
      private int nGXsfl_12_idx=1 ;
      private int Z4SupplierId ;
      private int A4SupplierId ;
      private int Z96PurchaseOrderLastDetailId ;
      private int Z76PurchaseOrderDetailQuantityOrd ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int Z77PurchaseOrderDetailQuantityRec ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int Z15ProductId ;
      private int A15ProductId ;
      private int Z61PurchaseOrderDetailId ;
      private int A61PurchaseOrderDetailId ;
      private int i96PurchaseOrderLastDetailId ;
      private decimal Z78PurchaseOrderTotalPaid ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal Z134PurchaseOrderDetailSuggestedPr ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private string AV15Pgmname ;
      private string sMode12 ;
      private DateTime Z52PurchaseOrderCreatedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime Z66PurchaseOrderClosedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime Z53PurchaseOrderModifiedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime Z135PurchaseOrderConfirmatedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private DateTime Z139PurchaseOrderPaidDate ;
      private DateTime A139PurchaseOrderPaidDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool Z79PurchaseOrderActive ;
      private bool A79PurchaseOrderActive ;
      private bool Z138PurchaseOrderWasPaid ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private bool n138PurchaseOrderWasPaid ;
      private bool n139PurchaseOrderPaidDate ;
      private bool Gx_longc ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool i79PurchaseOrderActive ;
      private bool mustCommit ;
      private string Z136PurchaseOrderCanceledDescripti ;
      private string A136PurchaseOrderCanceledDescripti ;
      private string Z5SupplierName ;
      private string A5SupplierName ;
      private string Z16ProductName ;
      private string A16ProductName ;
      private SdtPurchaseOrder bcPurchaseOrder ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00076_A67PurchaseOrderDetailsQuantity ;
      private int[] BC00076_A96PurchaseOrderLastDetailId ;
      private int[] BC000711_A50PurchaseOrderId ;
      private string[] BC000711_A5SupplierName ;
      private DateTime[] BC000711_A52PurchaseOrderCreatedDate ;
      private decimal[] BC000711_A78PurchaseOrderTotalPaid ;
      private bool[] BC000711_n78PurchaseOrderTotalPaid ;
      private DateTime[] BC000711_A66PurchaseOrderClosedDate ;
      private bool[] BC000711_n66PurchaseOrderClosedDate ;
      private DateTime[] BC000711_A53PurchaseOrderModifiedDate ;
      private bool[] BC000711_n53PurchaseOrderModifiedDate ;
      private DateTime[] BC000711_A135PurchaseOrderConfirmatedDate ;
      private bool[] BC000711_n135PurchaseOrderConfirmatedDate ;
      private bool[] BC000711_A79PurchaseOrderActive ;
      private string[] BC000711_A136PurchaseOrderCanceledDescripti ;
      private bool[] BC000711_n136PurchaseOrderCanceledDescripti ;
      private bool[] BC000711_A138PurchaseOrderWasPaid ;
      private bool[] BC000711_n138PurchaseOrderWasPaid ;
      private DateTime[] BC000711_A139PurchaseOrderPaidDate ;
      private bool[] BC000711_n139PurchaseOrderPaidDate ;
      private int[] BC000711_A4SupplierId ;
      private short[] BC000711_A67PurchaseOrderDetailsQuantity ;
      private int[] BC000711_A96PurchaseOrderLastDetailId ;
      private string[] BC00079_A5SupplierName ;
      private int[] BC000712_A50PurchaseOrderId ;
      private int[] BC00078_A50PurchaseOrderId ;
      private DateTime[] BC00078_A52PurchaseOrderCreatedDate ;
      private decimal[] BC00078_A78PurchaseOrderTotalPaid ;
      private bool[] BC00078_n78PurchaseOrderTotalPaid ;
      private DateTime[] BC00078_A66PurchaseOrderClosedDate ;
      private bool[] BC00078_n66PurchaseOrderClosedDate ;
      private DateTime[] BC00078_A53PurchaseOrderModifiedDate ;
      private bool[] BC00078_n53PurchaseOrderModifiedDate ;
      private DateTime[] BC00078_A135PurchaseOrderConfirmatedDate ;
      private bool[] BC00078_n135PurchaseOrderConfirmatedDate ;
      private bool[] BC00078_A79PurchaseOrderActive ;
      private string[] BC00078_A136PurchaseOrderCanceledDescripti ;
      private bool[] BC00078_n136PurchaseOrderCanceledDescripti ;
      private bool[] BC00078_A138PurchaseOrderWasPaid ;
      private bool[] BC00078_n138PurchaseOrderWasPaid ;
      private DateTime[] BC00078_A139PurchaseOrderPaidDate ;
      private bool[] BC00078_n139PurchaseOrderPaidDate ;
      private int[] BC00078_A4SupplierId ;
      private int[] BC00077_A50PurchaseOrderId ;
      private DateTime[] BC00077_A52PurchaseOrderCreatedDate ;
      private decimal[] BC00077_A78PurchaseOrderTotalPaid ;
      private bool[] BC00077_n78PurchaseOrderTotalPaid ;
      private DateTime[] BC00077_A66PurchaseOrderClosedDate ;
      private bool[] BC00077_n66PurchaseOrderClosedDate ;
      private DateTime[] BC00077_A53PurchaseOrderModifiedDate ;
      private bool[] BC00077_n53PurchaseOrderModifiedDate ;
      private DateTime[] BC00077_A135PurchaseOrderConfirmatedDate ;
      private bool[] BC00077_n135PurchaseOrderConfirmatedDate ;
      private bool[] BC00077_A79PurchaseOrderActive ;
      private string[] BC00077_A136PurchaseOrderCanceledDescripti ;
      private bool[] BC00077_n136PurchaseOrderCanceledDescripti ;
      private bool[] BC00077_A138PurchaseOrderWasPaid ;
      private bool[] BC00077_n138PurchaseOrderWasPaid ;
      private DateTime[] BC00077_A139PurchaseOrderPaidDate ;
      private bool[] BC00077_n139PurchaseOrderPaidDate ;
      private int[] BC00077_A4SupplierId ;
      private int[] BC000713_A50PurchaseOrderId ;
      private short[] BC000717_A67PurchaseOrderDetailsQuantity ;
      private int[] BC000717_A96PurchaseOrderLastDetailId ;
      private string[] BC000718_A5SupplierName ;
      private int[] BC000720_A50PurchaseOrderId ;
      private string[] BC000720_A5SupplierName ;
      private DateTime[] BC000720_A52PurchaseOrderCreatedDate ;
      private decimal[] BC000720_A78PurchaseOrderTotalPaid ;
      private bool[] BC000720_n78PurchaseOrderTotalPaid ;
      private DateTime[] BC000720_A66PurchaseOrderClosedDate ;
      private bool[] BC000720_n66PurchaseOrderClosedDate ;
      private DateTime[] BC000720_A53PurchaseOrderModifiedDate ;
      private bool[] BC000720_n53PurchaseOrderModifiedDate ;
      private DateTime[] BC000720_A135PurchaseOrderConfirmatedDate ;
      private bool[] BC000720_n135PurchaseOrderConfirmatedDate ;
      private bool[] BC000720_A79PurchaseOrderActive ;
      private string[] BC000720_A136PurchaseOrderCanceledDescripti ;
      private bool[] BC000720_n136PurchaseOrderCanceledDescripti ;
      private bool[] BC000720_A138PurchaseOrderWasPaid ;
      private bool[] BC000720_n138PurchaseOrderWasPaid ;
      private DateTime[] BC000720_A139PurchaseOrderPaidDate ;
      private bool[] BC000720_n139PurchaseOrderPaidDate ;
      private int[] BC000720_A4SupplierId ;
      private short[] BC000720_A67PurchaseOrderDetailsQuantity ;
      private int[] BC000720_A96PurchaseOrderLastDetailId ;
      private int[] BC000721_A50PurchaseOrderId ;
      private int[] BC000721_A61PurchaseOrderDetailId ;
      private string[] BC000721_A16ProductName ;
      private int[] BC000721_A76PurchaseOrderDetailQuantityOrd ;
      private int[] BC000721_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] BC000721_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] BC000721_n134PurchaseOrderDetailSuggestedPr ;
      private int[] BC000721_A15ProductId ;
      private string[] BC00074_A16ProductName ;
      private int[] BC000722_A50PurchaseOrderId ;
      private int[] BC000722_A61PurchaseOrderDetailId ;
      private int[] BC00073_A50PurchaseOrderId ;
      private int[] BC00073_A61PurchaseOrderDetailId ;
      private int[] BC00073_A76PurchaseOrderDetailQuantityOrd ;
      private int[] BC00073_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] BC00073_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] BC00073_n134PurchaseOrderDetailSuggestedPr ;
      private int[] BC00073_A15ProductId ;
      private int[] BC00072_A50PurchaseOrderId ;
      private int[] BC00072_A61PurchaseOrderDetailId ;
      private int[] BC00072_A76PurchaseOrderDetailQuantityOrd ;
      private int[] BC00072_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] BC00072_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] BC00072_n134PurchaseOrderDetailSuggestedPr ;
      private int[] BC00072_A15ProductId ;
      private string[] BC000726_A16ProductName ;
      private int[] BC000727_A50PurchaseOrderId ;
      private int[] BC000727_A61PurchaseOrderDetailId ;
      private string[] BC000727_A16ProductName ;
      private int[] BC000727_A76PurchaseOrderDetailQuantityOrd ;
      private int[] BC000727_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] BC000727_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] BC000727_n134PurchaseOrderDetailSuggestedPr ;
      private int[] BC000727_A15ProductId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class purchaseorder_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000711;
          prmBC000711 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC00076;
          prmBC00076 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC00079;
          prmBC00079 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000712;
          prmBC000712 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC00078;
          prmBC00078 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC00077;
          prmBC00077 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC000713;
          prmBC000713 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderPaidDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000714;
          prmBC000714 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderPaidDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC000715;
          prmBC000715 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC000718;
          prmBC000718 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000717;
          prmBC000717 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC000720;
          prmBC000720 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmBC000721;
          prmBC000721 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC00074;
          prmBC00074 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000722;
          prmBC000722 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC00073;
          prmBC00073 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC00072;
          prmBC00072 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000723;
          prmBC000723 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000724;
          prmBC000724 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000725;
          prmBC000725 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000726;
          prmBC000726 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000727;
          prmBC000727 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00072", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00073", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00074", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00076", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T1.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00077", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00078", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00079", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000711", "SELECT TM1.[PurchaseOrderId], T3.[SupplierName], TM1.[PurchaseOrderCreatedDate], TM1.[PurchaseOrderTotalPaid], TM1.[PurchaseOrderClosedDate], TM1.[PurchaseOrderModifiedDate], TM1.[PurchaseOrderConfirmatedDate], TM1.[PurchaseOrderActive], TM1.[PurchaseOrderCanceledDescripti], TM1.[PurchaseOrderWasPaid], TM1.[PurchaseOrderPaidDate], TM1.[SupplierId], COALESCE( T2.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T2.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (([PurchaseOrder] TM1 LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T2 ON T2.[PurchaseOrderId] = TM1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY TM1.[PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000712", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000713", "INSERT INTO [PurchaseOrder]([PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId]) VALUES(@PurchaseOrderCreatedDate, @PurchaseOrderTotalPaid, @PurchaseOrderClosedDate, @PurchaseOrderModifiedDate, @PurchaseOrderConfirmatedDate, @PurchaseOrderActive, @PurchaseOrderCanceledDescripti, @PurchaseOrderWasPaid, @PurchaseOrderPaidDate, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000714", "UPDATE [PurchaseOrder] SET [PurchaseOrderCreatedDate]=@PurchaseOrderCreatedDate, [PurchaseOrderTotalPaid]=@PurchaseOrderTotalPaid, [PurchaseOrderClosedDate]=@PurchaseOrderClosedDate, [PurchaseOrderModifiedDate]=@PurchaseOrderModifiedDate, [PurchaseOrderConfirmatedDate]=@PurchaseOrderConfirmatedDate, [PurchaseOrderActive]=@PurchaseOrderActive, [PurchaseOrderCanceledDescripti]=@PurchaseOrderCanceledDescripti, [PurchaseOrderWasPaid]=@PurchaseOrderWasPaid, [PurchaseOrderPaidDate]=@PurchaseOrderPaidDate, [SupplierId]=@SupplierId  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmBC000714)
             ,new CursorDef("BC000715", "DELETE FROM [PurchaseOrder]  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmBC000715)
             ,new CursorDef("BC000717", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T1.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000717,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000718", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000720", "SELECT TM1.[PurchaseOrderId], T3.[SupplierName], TM1.[PurchaseOrderCreatedDate], TM1.[PurchaseOrderTotalPaid], TM1.[PurchaseOrderClosedDate], TM1.[PurchaseOrderModifiedDate], TM1.[PurchaseOrderConfirmatedDate], TM1.[PurchaseOrderActive], TM1.[PurchaseOrderCanceledDescripti], TM1.[PurchaseOrderWasPaid], TM1.[PurchaseOrderPaidDate], TM1.[SupplierId], COALESCE( T2.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T2.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (([PurchaseOrder] TM1 LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T2 ON T2.[PurchaseOrderId] = TM1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY TM1.[PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000720,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000721", "SELECT T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailSuggestedPr], T1.[ProductId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId and T1.[PurchaseOrderDetailId] = @PurchaseOrderDetailId ORDER BY T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000721,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000722", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000722,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000723", "INSERT INTO [PurchaseOrderDetail]([PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId]) VALUES(@PurchaseOrderId, @PurchaseOrderDetailId, @PurchaseOrderDetailQuantityOrd, @PurchaseOrderDetailQuantityRec, @PurchaseOrderDetailSuggestedPr, @ProductId)", GxErrorMask.GX_NOMASK,prmBC000723)
             ,new CursorDef("BC000724", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityOrd]=@PurchaseOrderDetailQuantityOrd, [PurchaseOrderDetailQuantityRec]=@PurchaseOrderDetailQuantityRec, [PurchaseOrderDetailSuggestedPr]=@PurchaseOrderDetailSuggestedPr, [ProductId]=@ProductId  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK,prmBC000724)
             ,new CursorDef("BC000725", "DELETE FROM [PurchaseOrderDetail]  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK,prmBC000725)
             ,new CursorDef("BC000726", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000726,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000727", "SELECT T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailSuggestedPr], T1.[ProductId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000727,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((bool[]) buf[13])[0] = rslt.getBool(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((bool[]) buf[13])[0] = rslt.getBool(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((short[]) buf[19])[0] = rslt.getShort(13);
                ((int[]) buf[20])[0] = rslt.getInt(14);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((short[]) buf[19])[0] = rslt.getShort(13);
                ((int[]) buf[20])[0] = rslt.getInt(14);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
