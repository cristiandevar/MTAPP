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
   public class invoice_bc : GxSilentTrn, IGxSilentTrn
   {
      public invoice_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoice_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z20InvoiceId = A20InvoiceId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
                  ZM066( 17) ;
                  ZM066( 18) ;
                  ZM066( 19) ;
                  ZM066( 20) ;
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode6 = Gx_mode;
            CONFIRM_0613( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0621( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode6;
                  IsConfirmed = 1;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode6;
         }
      }

      protected void CONFIRM_0621( )
      {
         s131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         nGXsfl_21_idx = 0;
         while ( nGXsfl_21_idx < bcInvoice.gxTpr_Paymentmethod.Count )
         {
            ReadRow0621( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound21 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_21 != 0 ) )
            {
               GetKey0621( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound21 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0621( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0621( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0621( 24) ;
                           ZM0621( 27) ;
                           ZM0621( 30) ;
                        }
                        CloseExtendedTableCursors0621( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                        n131InvoiceLastPaymentMethodId = false;
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
                  if ( RcdFound21 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0621( ) ;
                        Load0621( ) ;
                        BeforeValidate0621( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0621( ) ;
                           O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                           n131InvoiceLastPaymentMethodId = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0621( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0621( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0621( 24) ;
                                 ZM0621( 27) ;
                                 ZM0621( 30) ;
                              }
                              CloseExtendedTableCursors0621( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                              n131InvoiceLastPaymentMethodId = false;
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
               VarsToRow21( ((SdtInvoice_PaymentMethod)bcInvoice.gxTpr_Paymentmethod.Item(nGXsfl_21_idx))) ;
            }
         }
         O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         /* Start of After( level) rules */
         /* Using cursor BC00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = BC00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC00068_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         /* Using cursor BC000610 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A131InvoiceLastPaymentMethodId = BC000610_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000610_n131InvoiceLastPaymentMethodId[0];
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
         }
         /* End of After( level) rules */
      }

      protected void CONFIRM_0613( )
      {
         s97InvoiceLastDetailId = O97InvoiceLastDetailId;
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         nGXsfl_13_idx = 0;
         while ( nGXsfl_13_idx < bcInvoice.gxTpr_Detail.Count )
         {
            ReadRow0613( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound13 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_13 != 0 ) )
            {
               GetKey0613( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0613( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0613( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0613( 22) ;
                           ZM0613( 28) ;
                           ZM0613( 29) ;
                        }
                        CloseExtendedTableCursors0613( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                        O68InvoiceProductQuantity = A68InvoiceProductQuantity;
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
                  if ( RcdFound13 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0613( ) ;
                        Load0613( ) ;
                        BeforeValidate0613( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0613( ) ;
                           O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                           O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0613( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0613( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0613( 22) ;
                                 ZM0613( 28) ;
                                 ZM0613( 29) ;
                              }
                              CloseExtendedTableCursors0613( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                              O68InvoiceProductQuantity = A68InvoiceProductQuantity;
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
               VarsToRow13( ((SdtInvoice_Detail)bcInvoice.gxTpr_Detail.Item(nGXsfl_13_idx))) ;
            }
         }
         O97InvoiceLastDetailId = s97InvoiceLastDetailId;
         O68InvoiceProductQuantity = s68InvoiceProductQuantity;
         /* Start of After( level) rules */
         /* Using cursor BC00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = BC00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC00068_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         /* Using cursor BC000615 */
         pr_default.execute(8, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A97InvoiceLastDetailId = BC000615_A97InvoiceLastDetailId[0];
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            A97InvoiceLastDetailId = 0;
         }
         /* End of After( level) rules */
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "invoice view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV20Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "invoice insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV20Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "invoice update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV20Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "invoice delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV20Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         new getcontext(context ).execute( out  AV17Context, ref  AV18AllOk) ;
         AV14Insert_UserId = AV17Context.gxTpr_Userid;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
            Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
            Z94InvoiceActive = A94InvoiceActive;
            Z99UserId = A99UserId;
            Z80InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z80InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z100UserName = A100UserName;
            Z80InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z80InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z80InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( GX_JID == -16 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
            Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
            Z94InvoiceActive = A94InvoiceActive;
            Z99UserId = A99UserId;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            Z100UserName = A100UserName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A38InvoiceCreatedDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A39InvoiceModifiedDate = Gx_date;
            n39InvoiceModifiedDate = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load066( )
      {
         /* Using cursor BC000621 */
         pr_default.execute(12, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A38InvoiceCreatedDate = BC000621_A38InvoiceCreatedDate[0];
            A100UserName = BC000621_A100UserName[0];
            A39InvoiceModifiedDate = BC000621_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = BC000621_n39InvoiceModifiedDate[0];
            A94InvoiceActive = BC000621_A94InvoiceActive[0];
            A99UserId = BC000621_A99UserId[0];
            A68InvoiceProductQuantity = BC000621_A68InvoiceProductQuantity[0];
            A97InvoiceLastDetailId = BC000621_A97InvoiceLastDetailId[0];
            A131InvoiceLastPaymentMethodId = BC000621_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000621_n131InvoiceLastPaymentMethodId[0];
            ZM066( -16) ;
         }
         pr_default.close(12);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         O97InvoiceLastDetailId = A97InvoiceLastDetailId;
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         AV20Pgmname = "Invoice_BC";
         /* Using cursor BC00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = BC00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC00068_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         pr_default.close(3);
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         AV20Pgmname = "Invoice_BC";
         /* Using cursor BC00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = BC00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC00068_n80InvoiceTotalReceivable[0];
         }
         else
         {
            nIsDirty_6 = 1;
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         pr_default.close(3);
         /* Using cursor BC000615 */
         pr_default.execute(8, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A68InvoiceProductQuantity = BC000615_A68InvoiceProductQuantity[0];
            A97InvoiceLastDetailId = BC000615_A97InvoiceLastDetailId[0];
         }
         else
         {
            nIsDirty_6 = 1;
            A68InvoiceProductQuantity = 0;
            nIsDirty_6 = 1;
            A97InvoiceLastDetailId = 0;
         }
         pr_default.close(8);
         /* Using cursor BC000610 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A131InvoiceLastPaymentMethodId = BC000610_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000610_n131InvoiceLastPaymentMethodId[0];
         }
         else
         {
            nIsDirty_6 = 1;
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A38InvoiceCreatedDate) || ( DateTimeUtil.ResetTime ( A38InvoiceCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Created Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000618 */
         pr_default.execute(11, new Object[] {A99UserId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'User'.", "ForeignKeyNotFound", 1, "USERID");
            AnyError = 1;
         }
         A100UserName = BC000618_A100UserName[0];
         pr_default.close(11);
         if ( ! ( (DateTime.MinValue==A39InvoiceModifiedDate) || ( DateTimeUtil.ResetTime ( A39InvoiceModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Modified Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(3);
         pr_default.close(8);
         pr_default.close(4);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC000622 */
         pr_default.execute(13, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000617 */
         pr_default.execute(10, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            ZM066( 16) ;
            RcdFound6 = 1;
            A20InvoiceId = BC000617_A20InvoiceId[0];
            A38InvoiceCreatedDate = BC000617_A38InvoiceCreatedDate[0];
            A39InvoiceModifiedDate = BC000617_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = BC000617_n39InvoiceModifiedDate[0];
            A94InvoiceActive = BC000617_A94InvoiceActive[0];
            A99UserId = BC000617_A99UserId[0];
            Z20InvoiceId = A20InvoiceId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(10);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000616 */
            pr_default.execute(9, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(9) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invoice"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(9) == 101) || ( DateTimeUtil.ResetTime ( Z38InvoiceCreatedDate ) != DateTimeUtil.ResetTime ( BC000616_A38InvoiceCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z39InvoiceModifiedDate ) != DateTimeUtil.ResetTime ( BC000616_A39InvoiceModifiedDate[0] ) ) || ( Z94InvoiceActive != BC000616_A94InvoiceActive[0] ) || ( Z99UserId != BC000616_A99UserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invoice"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000623 */
                     pr_default.execute(14, new Object[] {A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A94InvoiceActive, A99UserId});
                     A20InvoiceId = BC000623_A20InvoiceId[0];
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel066( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000624 */
                     pr_default.execute(15, new Object[] {A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A94InvoiceActive, A99UserId, A20InvoiceId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invoice"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  ScanKeyStart0621( ) ;
                  while ( RcdFound21 != 0 )
                  {
                     getByPrimaryKey0621( ) ;
                     Delete0621( ) ;
                     ScanKeyNext0621( ) ;
                     O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                     n131InvoiceLastPaymentMethodId = false;
                  }
                  ScanKeyEnd0621( ) ;
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  ScanKeyStart0613( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0613( ) ;
                     Delete0613( ) ;
                     ScanKeyNext0613( ) ;
                     O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                     O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                  }
                  ScanKeyEnd0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000625 */
                     pr_default.execute(16, new Object[] {A20InvoiceId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV20Pgmname = "Invoice_BC";
            /* Using cursor BC000629 */
            pr_default.execute(17, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A80InvoiceTotalReceivable = BC000629_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = BC000629_n80InvoiceTotalReceivable[0];
            }
            else
            {
               A80InvoiceTotalReceivable = 0;
               n80InvoiceTotalReceivable = false;
            }
            pr_default.close(17);
            /* Using cursor BC000631 */
            pr_default.execute(18, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A68InvoiceProductQuantity = BC000631_A68InvoiceProductQuantity[0];
               A97InvoiceLastDetailId = BC000631_A97InvoiceLastDetailId[0];
            }
            else
            {
               A68InvoiceProductQuantity = 0;
               A97InvoiceLastDetailId = 0;
            }
            pr_default.close(18);
            /* Using cursor BC000633 */
            pr_default.execute(19, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A131InvoiceLastPaymentMethodId = BC000633_A131InvoiceLastPaymentMethodId[0];
               n131InvoiceLastPaymentMethodId = BC000633_n131InvoiceLastPaymentMethodId[0];
            }
            else
            {
               A131InvoiceLastPaymentMethodId = 0;
               n131InvoiceLastPaymentMethodId = false;
            }
            pr_default.close(19);
            /* Using cursor BC000634 */
            pr_default.execute(20, new Object[] {A99UserId});
            A100UserName = BC000634_A100UserName[0];
            pr_default.close(20);
         }
      }

      protected void ProcessNestedLevel0613( )
      {
         s97InvoiceLastDetailId = O97InvoiceLastDetailId;
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         nGXsfl_13_idx = 0;
         while ( nGXsfl_13_idx < bcInvoice.gxTpr_Detail.Count )
         {
            ReadRow0613( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound13 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal0613( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0613( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0613( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0613( ) ;
                  }
               }
               O97InvoiceLastDetailId = A97InvoiceLastDetailId;
               O68InvoiceProductQuantity = A68InvoiceProductQuantity;
            }
            KeyVarsToRow13( ((SdtInvoice_Detail)bcInvoice.gxTpr_Detail.Item(nGXsfl_13_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_13_idx = 0;
            while ( nGXsfl_13_idx < bcInvoice.gxTpr_Detail.Count )
            {
               ReadRow0613( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound13 == 0 )
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
                  bcInvoice.gxTpr_Detail.RemoveElement(nGXsfl_13_idx);
                  nGXsfl_13_idx = (int)(nGXsfl_13_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0613( ) ;
                  VarsToRow13( ((SdtInvoice_Detail)bcInvoice.gxTpr_Detail.Item(nGXsfl_13_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* Using cursor BC000629 */
         pr_default.execute(17, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A80InvoiceTotalReceivable = BC000629_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC000629_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         /* Using cursor BC000631 */
         pr_default.execute(18, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A97InvoiceLastDetailId = BC000631_A97InvoiceLastDetailId[0];
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            A97InvoiceLastDetailId = 0;
         }
         /* End of After( level) rules */
         InitAll0613( ) ;
         if ( AnyError != 0 )
         {
            O97InvoiceLastDetailId = s97InvoiceLastDetailId;
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         Gxremove13 = 0;
      }

      protected void ProcessNestedLevel0621( )
      {
         s131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         nGXsfl_21_idx = 0;
         while ( nGXsfl_21_idx < bcInvoice.gxTpr_Paymentmethod.Count )
         {
            ReadRow0621( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound21 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_21 != 0 ) )
            {
               standaloneNotModal0621( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0621( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0621( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0621( ) ;
                  }
               }
               O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
               n131InvoiceLastPaymentMethodId = false;
            }
            KeyVarsToRow21( ((SdtInvoice_PaymentMethod)bcInvoice.gxTpr_Paymentmethod.Item(nGXsfl_21_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_21_idx = 0;
            while ( nGXsfl_21_idx < bcInvoice.gxTpr_Paymentmethod.Count )
            {
               ReadRow0621( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound21 == 0 )
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
                  bcInvoice.gxTpr_Paymentmethod.RemoveElement(nGXsfl_21_idx);
                  nGXsfl_21_idx = (int)(nGXsfl_21_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0621( ) ;
                  VarsToRow21( ((SdtInvoice_PaymentMethod)bcInvoice.gxTpr_Paymentmethod.Item(nGXsfl_21_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* Using cursor BC000629 */
         pr_default.execute(17, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A80InvoiceTotalReceivable = BC000629_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = BC000629_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         /* Using cursor BC000633 */
         pr_default.execute(19, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A131InvoiceLastPaymentMethodId = BC000633_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000633_n131InvoiceLastPaymentMethodId[0];
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
         }
         /* End of After( level) rules */
         InitAll0621( ) ;
         if ( AnyError != 0 )
         {
            O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
         }
         nRcdExists_21 = 0;
         nIsMod_21 = 0;
         Gxremove21 = 0;
      }

      protected void ProcessLevel066( )
      {
         /* Save parent mode. */
         sMode6 = Gx_mode;
         ProcessNestedLevel0613( ) ;
         ProcessNestedLevel0621( ) ;
         if ( AnyError != 0 )
         {
            O97InvoiceLastDetailId = s97InvoiceLastDetailId;
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
            O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode6;
         /* ' Update level parameters */
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Scan By routine */
         /* Using cursor BC000637 */
         pr_default.execute(21, new Object[] {A20InvoiceId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = BC000637_A20InvoiceId[0];
            A38InvoiceCreatedDate = BC000637_A38InvoiceCreatedDate[0];
            A100UserName = BC000637_A100UserName[0];
            A39InvoiceModifiedDate = BC000637_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = BC000637_n39InvoiceModifiedDate[0];
            A94InvoiceActive = BC000637_A94InvoiceActive[0];
            A99UserId = BC000637_A99UserId[0];
            A68InvoiceProductQuantity = BC000637_A68InvoiceProductQuantity[0];
            A97InvoiceLastDetailId = BC000637_A97InvoiceLastDetailId[0];
            A131InvoiceLastPaymentMethodId = BC000637_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000637_n131InvoiceLastPaymentMethodId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = BC000637_A20InvoiceId[0];
            A38InvoiceCreatedDate = BC000637_A38InvoiceCreatedDate[0];
            A100UserName = BC000637_A100UserName[0];
            A39InvoiceModifiedDate = BC000637_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = BC000637_n39InvoiceModifiedDate[0];
            A94InvoiceActive = BC000637_A94InvoiceActive[0];
            A99UserId = BC000637_A99UserId[0];
            A68InvoiceProductQuantity = BC000637_A68InvoiceProductQuantity[0];
            A97InvoiceLastDetailId = BC000637_A97InvoiceLastDetailId[0];
            A131InvoiceLastPaymentMethodId = BC000637_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = BC000637_n131InvoiceLastPaymentMethodId[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void ZM0613( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
            Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
            Z98InvoiceDetailIsWholesale = A98InvoiceDetailIsWholesale;
            Z15ProductId = A15ProductId;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -21 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z25InvoiceDetailId = A25InvoiceDetailId;
            Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
            Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
            Z98InvoiceDetailIsWholesale = A98InvoiceDetailIsWholesale;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
      }

      protected void standaloneNotModal0613( )
      {
      }

      protected void standaloneModal0613( )
      {
         if ( IsIns( )  )
         {
            A97InvoiceLastDetailId = (int)(O97InvoiceLastDetailId+1);
         }
         if ( IsIns( )  )
         {
            A25InvoiceDetailId = A97InvoiceLastDetailId;
         }
      }

      protected void Load0613( )
      {
         /* Using cursor BC000638 */
         pr_default.execute(22, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound13 = 1;
            A16ProductName = BC000638_A16ProductName[0];
            A17ProductStock = BC000638_A17ProductStock[0];
            n17ProductStock = BC000638_n17ProductStock[0];
            A26InvoiceDetailQuantity = BC000638_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = BC000638_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = BC000638_A98InvoiceDetailIsWholesale[0];
            A15ProductId = BC000638_A15ProductId[0];
            ZM0613( -21) ;
         }
         pr_default.close(22);
         OnLoadActions0613( ) ;
      }

      protected void OnLoadActions0613( )
      {
         if ( IsIns( )  )
         {
            A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
         }
         else
         {
            if ( IsUpd( )  )
            {
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
               }
            }
         }
      }

      protected void CheckExtendedTable0613( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal0613( ) ;
         Gx_BScreen = 0;
         if ( IsIns( )  )
         {
            nIsDirty_13 = 1;
            A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_13 = 1;
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_13 = 1;
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
               }
            }
         }
         /* Using cursor BC000613 */
         pr_default.execute(7, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A16ProductName = BC000613_A16ProductName[0];
         A17ProductStock = BC000613_A17ProductStock[0];
         n17ProductStock = BC000613_n17ProductStock[0];
         pr_default.close(7);
         if ( A26InvoiceDetailQuantity > A17ProductStock )
         {
            GX_msglist.addItem("Quantity must be lower or equal than Stock", 1, "");
            AnyError = 1;
         }
         if ( A26InvoiceDetailQuantity <= 0 )
         {
            GX_msglist.addItem("Quantity must be positive number", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A65InvoiceDetailHistoricPrice >= Convert.ToDecimal( 0 )) && ( A65InvoiceDetailHistoricPrice <= 999999999999999.99m ) ) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0613( )
      {
         pr_default.close(7);
      }

      protected void enableDisable0613( )
      {
      }

      protected void GetKey0613( )
      {
         /* Using cursor BC000639 */
         pr_default.execute(23, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(23);
      }

      protected void getByPrimaryKey0613( )
      {
         /* Using cursor BC000612 */
         pr_default.execute(6, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0613( 21) ;
            RcdFound13 = 1;
            InitializeNonKey0613( ) ;
            A25InvoiceDetailId = BC000612_A25InvoiceDetailId[0];
            A26InvoiceDetailQuantity = BC000612_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = BC000612_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = BC000612_A98InvoiceDetailIsWholesale[0];
            A15ProductId = BC000612_A15ProductId[0];
            Z20InvoiceId = A20InvoiceId;
            Z25InvoiceDetailId = A25InvoiceDetailId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0613( ) ;
            Load0613( ) ;
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0613( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0613( ) ;
            Gx_mode = sMode13;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0613( ) ;
         }
         pr_default.close(6);
      }

      protected void CheckOptimisticConcurrency0613( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000611 */
            pr_default.execute(5, new Object[] {A20InvoiceId, A25InvoiceDetailId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( Z26InvoiceDetailQuantity != BC000611_A26InvoiceDetailQuantity[0] ) || ( Z65InvoiceDetailHistoricPrice != BC000611_A65InvoiceDetailHistoricPrice[0] ) || ( Z98InvoiceDetailIsWholesale != BC000611_A98InvoiceDetailIsWholesale[0] ) || ( Z15ProductId != BC000611_A15ProductId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"InvoiceDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0613( )
      {
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0613( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0613( 0) ;
            CheckOptimisticConcurrency0613( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0613( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000640 */
                     pr_default.execute(24, new Object[] {A20InvoiceId, A25InvoiceDetailId, A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A98InvoiceDetailIsWholesale, A15ProductId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( (pr_default.getStatus(24) == 1) )
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
               Load0613( ) ;
            }
            EndLevel0613( ) ;
         }
         CloseExtendedTableCursors0613( ) ;
      }

      protected void Update0613( )
      {
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0613( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0613( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0613( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000641 */
                     pr_default.execute(25, new Object[] {A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A98InvoiceDetailIsWholesale, A15ProductId, A20InvoiceId, A25InvoiceDetailId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0613( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0613( ) ;
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
            EndLevel0613( ) ;
         }
         CloseExtendedTableCursors0613( ) ;
      }

      protected void DeferredUpdate0613( )
      {
      }

      protected void Delete0613( )
      {
         Gx_mode = "DLT";
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0613( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0613( ) ;
            AfterConfirm0613( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0613( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000642 */
                  pr_default.execute(26, new Object[] {A20InvoiceId, A25InvoiceDetailId});
                  pr_default.close(26);
                  pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0613( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0613( )
      {
         standaloneModal0613( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                  }
               }
            }
            /* Using cursor BC000643 */
            pr_default.execute(27, new Object[] {A15ProductId});
            A16ProductName = BC000643_A16ProductName[0];
            A17ProductStock = BC000643_A17ProductStock[0];
            n17ProductStock = BC000643_n17ProductStock[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel0613( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0613( )
      {
         /* Scan By routine */
         /* Using cursor BC000644 */
         pr_default.execute(28, new Object[] {A20InvoiceId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = BC000644_A25InvoiceDetailId[0];
            A16ProductName = BC000644_A16ProductName[0];
            A17ProductStock = BC000644_A17ProductStock[0];
            n17ProductStock = BC000644_n17ProductStock[0];
            A26InvoiceDetailQuantity = BC000644_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = BC000644_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = BC000644_A98InvoiceDetailIsWholesale[0];
            A15ProductId = BC000644_A15ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0613( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound13 = 0;
         ScanKeyLoad0613( ) ;
      }

      protected void ScanKeyLoad0613( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = BC000644_A25InvoiceDetailId[0];
            A16ProductName = BC000644_A16ProductName[0];
            A17ProductStock = BC000644_A17ProductStock[0];
            n17ProductStock = BC000644_n17ProductStock[0];
            A26InvoiceDetailQuantity = BC000644_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = BC000644_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = BC000644_A98InvoiceDetailIsWholesale[0];
            A15ProductId = BC000644_A15ProductId[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0613( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm0613( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0613( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0613( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0613( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0613( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0613( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0613( )
      {
      }

      protected void send_integrity_lvl_hashes0613( )
      {
      }

      protected void ZM0621( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z120InvoicePaymentMethodImport = A120InvoicePaymentMethodImport;
            Z132InvoicePaymentMethodRechargeIm = A132InvoicePaymentMethodRechargeIm;
            Z133InvoicePaymentMethodDiscountIm = A133InvoicePaymentMethodDiscountIm;
            Z115PaymentMethodId = A115PaymentMethodId;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -23 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
            Z120InvoicePaymentMethodImport = A120InvoicePaymentMethodImport;
            Z132InvoicePaymentMethodRechargeIm = A132InvoicePaymentMethodRechargeIm;
            Z133InvoicePaymentMethodDiscountIm = A133InvoicePaymentMethodDiscountIm;
            Z115PaymentMethodId = A115PaymentMethodId;
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
      }

      protected void standaloneNotModal0621( )
      {
      }

      protected void standaloneModal0621( )
      {
         if ( IsIns( )  )
         {
            A131InvoiceLastPaymentMethodId = (int)(O131InvoiceLastPaymentMethodId+1);
            n131InvoiceLastPaymentMethodId = false;
         }
         if ( IsIns( )  )
         {
            A118InvoicePaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
      }

      protected void Load0621( )
      {
         /* Using cursor BC000645 */
         pr_default.execute(29, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound21 = 1;
            A116PaymentMethodDescription = BC000645_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = BC000645_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000645_A130PaymentMethodRecarge[0];
            A120InvoicePaymentMethodImport = BC000645_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = BC000645_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = BC000645_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = BC000645_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = BC000645_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = BC000645_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = BC000645_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000645_n115PaymentMethodId[0];
            ZM0621( -23) ;
         }
         pr_default.close(29);
         OnLoadActions0621( ) ;
      }

      protected void OnLoadActions0621( )
      {
      }

      protected void CheckExtendedTable0621( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         standaloneModal0621( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A115PaymentMethodId) ) )
            {
               GX_msglist.addItem("No matching 'Payment Method of Invoices'.", "ForeignKeyNotFound", 1, "PAYMENTMETHODID");
               AnyError = 1;
            }
         }
         A116PaymentMethodDescription = BC00064_A116PaymentMethodDescription[0];
         A129PaymentMethodDiscount = BC00064_A129PaymentMethodDiscount[0];
         A130PaymentMethodRecarge = BC00064_A130PaymentMethodRecarge[0];
         pr_default.close(2);
         if ( ! ( ( ( A120InvoicePaymentMethodImport >= Convert.ToDecimal( 0 )) && ( A120InvoicePaymentMethodImport <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A120InvoicePaymentMethodImport) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A132InvoicePaymentMethodRechargeIm >= Convert.ToDecimal( 0 )) && ( A132InvoicePaymentMethodRechargeIm <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A132InvoicePaymentMethodRechargeIm) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A133InvoicePaymentMethodDiscountIm >= Convert.ToDecimal( 0 )) && ( A133InvoicePaymentMethodDiscountIm <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A133InvoicePaymentMethodDiscountIm) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0621( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0621( )
      {
      }

      protected void GetKey0621( )
      {
         /* Using cursor BC000646 */
         pr_default.execute(30, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(30);
      }

      protected void getByPrimaryKey0621( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0621( 23) ;
            RcdFound21 = 1;
            InitializeNonKey0621( ) ;
            A118InvoicePaymentMethodId = BC00063_A118InvoicePaymentMethodId[0];
            A120InvoicePaymentMethodImport = BC00063_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = BC00063_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = BC00063_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = BC00063_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = BC00063_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = BC00063_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = BC00063_A115PaymentMethodId[0];
            n115PaymentMethodId = BC00063_n115PaymentMethodId[0];
            Z20InvoiceId = A20InvoiceId;
            Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0621( ) ;
            Load0621( ) ;
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0621( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0621( ) ;
            Gx_mode = sMode21;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0621( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0621( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoicePaymentMethod"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z120InvoicePaymentMethodImport != BC00062_A120InvoicePaymentMethodImport[0] ) || ( Z132InvoicePaymentMethodRechargeIm != BC00062_A132InvoicePaymentMethodRechargeIm[0] ) || ( Z133InvoicePaymentMethodDiscountIm != BC00062_A133InvoicePaymentMethodDiscountIm[0] ) || ( Z115PaymentMethodId != BC00062_A115PaymentMethodId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"InvoicePaymentMethod"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0621( )
      {
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0621( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0621( 0) ;
            CheckOptimisticConcurrency0621( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0621( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0621( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000647 */
                     pr_default.execute(31, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId, n120InvoicePaymentMethodImport, A120InvoicePaymentMethodImport, n132InvoicePaymentMethodRechargeIm, A132InvoicePaymentMethodRechargeIm, n133InvoicePaymentMethodDiscountIm, A133InvoicePaymentMethodDiscountIm, n115PaymentMethodId, A115PaymentMethodId});
                     pr_default.close(31);
                     pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
                     if ( (pr_default.getStatus(31) == 1) )
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
               Load0621( ) ;
            }
            EndLevel0621( ) ;
         }
         CloseExtendedTableCursors0621( ) ;
      }

      protected void Update0621( )
      {
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0621( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0621( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0621( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0621( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000648 */
                     pr_default.execute(32, new Object[] {n120InvoicePaymentMethodImport, A120InvoicePaymentMethodImport, n132InvoicePaymentMethodRechargeIm, A132InvoicePaymentMethodRechargeIm, n133InvoicePaymentMethodDiscountIm, A133InvoicePaymentMethodDiscountIm, n115PaymentMethodId, A115PaymentMethodId, A20InvoiceId, A118InvoicePaymentMethodId});
                     pr_default.close(32);
                     pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
                     if ( (pr_default.getStatus(32) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoicePaymentMethod"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0621( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0621( ) ;
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
            EndLevel0621( ) ;
         }
         CloseExtendedTableCursors0621( ) ;
      }

      protected void DeferredUpdate0621( )
      {
      }

      protected void Delete0621( )
      {
         Gx_mode = "DLT";
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0621( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0621( ) ;
            AfterConfirm0621( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0621( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000649 */
                  pr_default.execute(33, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
                  pr_default.close(33);
                  pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0621( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0621( )
      {
         standaloneModal0621( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000650 */
            pr_default.execute(34, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            A116PaymentMethodDescription = BC000650_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = BC000650_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000650_A130PaymentMethodRecarge[0];
            pr_default.close(34);
         }
      }

      protected void EndLevel0621( )
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

      public void ScanKeyStart0621( )
      {
         /* Scan By routine */
         /* Using cursor BC000651 */
         pr_default.execute(35, new Object[] {A20InvoiceId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound21 = 1;
            A118InvoicePaymentMethodId = BC000651_A118InvoicePaymentMethodId[0];
            A116PaymentMethodDescription = BC000651_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = BC000651_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000651_A130PaymentMethodRecarge[0];
            A120InvoicePaymentMethodImport = BC000651_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = BC000651_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = BC000651_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = BC000651_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = BC000651_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = BC000651_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = BC000651_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000651_n115PaymentMethodId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0621( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound21 = 0;
         ScanKeyLoad0621( ) ;
      }

      protected void ScanKeyLoad0621( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound21 = 1;
            A118InvoicePaymentMethodId = BC000651_A118InvoicePaymentMethodId[0];
            A116PaymentMethodDescription = BC000651_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = BC000651_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000651_A130PaymentMethodRecarge[0];
            A120InvoicePaymentMethodImport = BC000651_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = BC000651_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = BC000651_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = BC000651_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = BC000651_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = BC000651_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = BC000651_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000651_n115PaymentMethodId[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0621( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0621( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0621( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0621( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0621( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0621( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0621( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0621( )
      {
      }

      protected void send_integrity_lvl_hashes0621( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcInvoice) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcInvoice, 1) ;
      }

      protected void AddRow0613( )
      {
         SdtInvoice_Detail obj13;
         obj13 = new SdtInvoice_Detail(context);
         VarsToRow13( obj13) ;
         bcInvoice.gxTpr_Detail.Add(obj13, 0);
         obj13.gxTpr_Mode = "UPD";
         obj13.gxTpr_Modified = 0;
      }

      protected void ReadRow0613( )
      {
         nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
         RowToVars13( ((SdtInvoice_Detail)bcInvoice.gxTpr_Detail.Item(nGXsfl_13_idx)), 1) ;
      }

      protected void AddRow0621( )
      {
         SdtInvoice_PaymentMethod obj21;
         obj21 = new SdtInvoice_PaymentMethod(context);
         VarsToRow21( obj21) ;
         bcInvoice.gxTpr_Paymentmethod.Add(obj21, 0);
         obj21.gxTpr_Mode = "UPD";
         obj21.gxTpr_Modified = 0;
      }

      protected void ReadRow0621( )
      {
         nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
         RowToVars21( ((SdtInvoice_PaymentMethod)bcInvoice.gxTpr_Paymentmethod.Item(nGXsfl_21_idx)), 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A38InvoiceCreatedDate = DateTime.MinValue;
         A99UserId = 0;
         A100UserName = "";
         A39InvoiceModifiedDate = DateTime.MinValue;
         n39InvoiceModifiedDate = false;
         A94InvoiceActive = false;
         A80InvoiceTotalReceivable = 0;
         n80InvoiceTotalReceivable = false;
         A68InvoiceProductQuantity = 0;
         A97InvoiceLastDetailId = 0;
         A131InvoiceLastPaymentMethodId = 0;
         n131InvoiceLastPaymentMethodId = false;
         O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         O97InvoiceLastDetailId = A97InvoiceLastDetailId;
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         Z38InvoiceCreatedDate = DateTime.MinValue;
         Z39InvoiceModifiedDate = DateTime.MinValue;
         Z94InvoiceActive = false;
         Z99UserId = 0;
      }

      protected void InitAll066( )
      {
         A20InvoiceId = 0;
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0613( )
      {
         A15ProductId = 0;
         A16ProductName = "";
         A17ProductStock = 0;
         n17ProductStock = false;
         A26InvoiceDetailQuantity = 0;
         A65InvoiceDetailHistoricPrice = 0;
         A98InvoiceDetailIsWholesale = false;
         Z26InvoiceDetailQuantity = 0;
         Z65InvoiceDetailHistoricPrice = 0;
         Z98InvoiceDetailIsWholesale = false;
         Z15ProductId = 0;
      }

      protected void InitAll0613( )
      {
         A25InvoiceDetailId = 0;
         InitializeNonKey0613( ) ;
      }

      protected void StandaloneModalInsert0613( )
      {
         A97InvoiceLastDetailId = i97InvoiceLastDetailId;
      }

      protected void InitializeNonKey0621( )
      {
         A115PaymentMethodId = 0;
         n115PaymentMethodId = false;
         A116PaymentMethodDescription = "";
         A129PaymentMethodDiscount = 0;
         A130PaymentMethodRecarge = 0;
         A120InvoicePaymentMethodImport = 0;
         n120InvoicePaymentMethodImport = false;
         A132InvoicePaymentMethodRechargeIm = 0;
         n132InvoicePaymentMethodRechargeIm = false;
         A133InvoicePaymentMethodDiscountIm = 0;
         n133InvoicePaymentMethodDiscountIm = false;
         Z120InvoicePaymentMethodImport = 0;
         Z132InvoicePaymentMethodRechargeIm = 0;
         Z133InvoicePaymentMethodDiscountIm = 0;
         Z115PaymentMethodId = 0;
      }

      protected void InitAll0621( )
      {
         A118InvoicePaymentMethodId = 0;
         InitializeNonKey0621( ) ;
      }

      protected void StandaloneModalInsert0621( )
      {
         A131InvoiceLastPaymentMethodId = i131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
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

      public void VarsToRow6( SdtInvoice obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Invoicecreateddate = A38InvoiceCreatedDate;
         obj6.gxTpr_Userid = A99UserId;
         obj6.gxTpr_Username = A100UserName;
         obj6.gxTpr_Invoicemodifieddate = A39InvoiceModifiedDate;
         obj6.gxTpr_Invoiceactive = A94InvoiceActive;
         obj6.gxTpr_Invoicetotalreceivable = A80InvoiceTotalReceivable;
         obj6.gxTpr_Invoiceproductquantity = A68InvoiceProductQuantity;
         obj6.gxTpr_Invoicelastdetailid = A97InvoiceLastDetailId;
         obj6.gxTpr_Invoicelastpaymentmethodid = A131InvoiceLastPaymentMethodId;
         obj6.gxTpr_Invoiceid = A20InvoiceId;
         obj6.gxTpr_Invoiceid_Z = Z20InvoiceId;
         obj6.gxTpr_Invoicecreateddate_Z = Z38InvoiceCreatedDate;
         obj6.gxTpr_Userid_Z = Z99UserId;
         obj6.gxTpr_Username_Z = Z100UserName;
         obj6.gxTpr_Invoicemodifieddate_Z = Z39InvoiceModifiedDate;
         obj6.gxTpr_Invoiceactive_Z = Z94InvoiceActive;
         obj6.gxTpr_Invoicetotalreceivable_Z = Z80InvoiceTotalReceivable;
         obj6.gxTpr_Invoiceproductquantity_Z = Z68InvoiceProductQuantity;
         obj6.gxTpr_Invoicelastdetailid_Z = Z97InvoiceLastDetailId;
         obj6.gxTpr_Invoicelastpaymentmethodid_Z = Z131InvoiceLastPaymentMethodId;
         obj6.gxTpr_Invoicemodifieddate_N = (short)(Convert.ToInt16(n39InvoiceModifiedDate));
         obj6.gxTpr_Invoicetotalreceivable_N = (short)(Convert.ToInt16(n80InvoiceTotalReceivable));
         obj6.gxTpr_Invoicelastpaymentmethodid_N = (short)(Convert.ToInt16(n131InvoiceLastPaymentMethodId));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtInvoice obj6 )
      {
         obj6.gxTpr_Invoiceid = A20InvoiceId;
         return  ;
      }

      public void RowToVars6( SdtInvoice obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A38InvoiceCreatedDate = obj6.gxTpr_Invoicecreateddate;
         A99UserId = obj6.gxTpr_Userid;
         A100UserName = obj6.gxTpr_Username;
         A39InvoiceModifiedDate = obj6.gxTpr_Invoicemodifieddate;
         n39InvoiceModifiedDate = false;
         A94InvoiceActive = obj6.gxTpr_Invoiceactive;
         A80InvoiceTotalReceivable = obj6.gxTpr_Invoicetotalreceivable;
         n80InvoiceTotalReceivable = false;
         A68InvoiceProductQuantity = obj6.gxTpr_Invoiceproductquantity;
         if ( forceLoad == 1 )
         {
            A97InvoiceLastDetailId = obj6.gxTpr_Invoicelastdetailid;
         }
         if ( forceLoad == 1 )
         {
            A131InvoiceLastPaymentMethodId = obj6.gxTpr_Invoicelastpaymentmethodid;
            n131InvoiceLastPaymentMethodId = false;
         }
         A20InvoiceId = obj6.gxTpr_Invoiceid;
         Z20InvoiceId = obj6.gxTpr_Invoiceid_Z;
         Z38InvoiceCreatedDate = obj6.gxTpr_Invoicecreateddate_Z;
         Z99UserId = obj6.gxTpr_Userid_Z;
         Z100UserName = obj6.gxTpr_Username_Z;
         Z39InvoiceModifiedDate = obj6.gxTpr_Invoicemodifieddate_Z;
         Z94InvoiceActive = obj6.gxTpr_Invoiceactive_Z;
         Z80InvoiceTotalReceivable = obj6.gxTpr_Invoicetotalreceivable_Z;
         Z68InvoiceProductQuantity = obj6.gxTpr_Invoiceproductquantity_Z;
         O68InvoiceProductQuantity = obj6.gxTpr_Invoiceproductquantity_Z;
         Z97InvoiceLastDetailId = obj6.gxTpr_Invoicelastdetailid_Z;
         O97InvoiceLastDetailId = obj6.gxTpr_Invoicelastdetailid_Z;
         Z131InvoiceLastPaymentMethodId = obj6.gxTpr_Invoicelastpaymentmethodid_Z;
         O131InvoiceLastPaymentMethodId = obj6.gxTpr_Invoicelastpaymentmethodid_Z;
         n39InvoiceModifiedDate = (bool)(Convert.ToBoolean(obj6.gxTpr_Invoicemodifieddate_N));
         n80InvoiceTotalReceivable = (bool)(Convert.ToBoolean(obj6.gxTpr_Invoicetotalreceivable_N));
         n131InvoiceLastPaymentMethodId = (bool)(Convert.ToBoolean(obj6.gxTpr_Invoicelastpaymentmethodid_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow13( SdtInvoice_Detail obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Productid = A15ProductId;
         obj13.gxTpr_Productname = A16ProductName;
         obj13.gxTpr_Productstock = A17ProductStock;
         obj13.gxTpr_Invoicedetailquantity = A26InvoiceDetailQuantity;
         obj13.gxTpr_Invoicedetailhistoricprice = A65InvoiceDetailHistoricPrice;
         obj13.gxTpr_Invoicedetailiswholesale = A98InvoiceDetailIsWholesale;
         obj13.gxTpr_Invoicedetailid = A25InvoiceDetailId;
         obj13.gxTpr_Invoicedetailid_Z = Z25InvoiceDetailId;
         obj13.gxTpr_Productid_Z = Z15ProductId;
         obj13.gxTpr_Productname_Z = Z16ProductName;
         obj13.gxTpr_Productstock_Z = Z17ProductStock;
         obj13.gxTpr_Invoicedetailquantity_Z = Z26InvoiceDetailQuantity;
         obj13.gxTpr_Invoicedetailhistoricprice_Z = Z65InvoiceDetailHistoricPrice;
         obj13.gxTpr_Invoicedetailiswholesale_Z = Z98InvoiceDetailIsWholesale;
         obj13.gxTpr_Productstock_N = (short)(Convert.ToInt16(n17ProductStock));
         obj13.gxTpr_Modified = nIsMod_13;
         return  ;
      }

      public void KeyVarsToRow13( SdtInvoice_Detail obj13 )
      {
         obj13.gxTpr_Invoicedetailid = A25InvoiceDetailId;
         return  ;
      }

      public void RowToVars13( SdtInvoice_Detail obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A15ProductId = obj13.gxTpr_Productid;
         A16ProductName = obj13.gxTpr_Productname;
         A17ProductStock = obj13.gxTpr_Productstock;
         n17ProductStock = false;
         A26InvoiceDetailQuantity = obj13.gxTpr_Invoicedetailquantity;
         A65InvoiceDetailHistoricPrice = obj13.gxTpr_Invoicedetailhistoricprice;
         A98InvoiceDetailIsWholesale = obj13.gxTpr_Invoicedetailiswholesale;
         A25InvoiceDetailId = obj13.gxTpr_Invoicedetailid;
         Z25InvoiceDetailId = obj13.gxTpr_Invoicedetailid_Z;
         Z15ProductId = obj13.gxTpr_Productid_Z;
         Z16ProductName = obj13.gxTpr_Productname_Z;
         Z17ProductStock = obj13.gxTpr_Productstock_Z;
         Z26InvoiceDetailQuantity = obj13.gxTpr_Invoicedetailquantity_Z;
         Z65InvoiceDetailHistoricPrice = obj13.gxTpr_Invoicedetailhistoricprice_Z;
         Z98InvoiceDetailIsWholesale = obj13.gxTpr_Invoicedetailiswholesale_Z;
         n17ProductStock = (bool)(Convert.ToBoolean(obj13.gxTpr_Productstock_N));
         nIsMod_13 = obj13.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow21( SdtInvoice_PaymentMethod obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Paymentmethodid = A115PaymentMethodId;
         obj21.gxTpr_Paymentmethoddescription = A116PaymentMethodDescription;
         obj21.gxTpr_Paymentmethoddiscount = A129PaymentMethodDiscount;
         obj21.gxTpr_Paymentmethodrecarge = A130PaymentMethodRecarge;
         obj21.gxTpr_Invoicepaymentmethodimport = A120InvoicePaymentMethodImport;
         obj21.gxTpr_Invoicepaymentmethodrechargeimport = A132InvoicePaymentMethodRechargeIm;
         obj21.gxTpr_Invoicepaymentmethoddiscountimport = A133InvoicePaymentMethodDiscountIm;
         obj21.gxTpr_Invoicepaymentmethodid = A118InvoicePaymentMethodId;
         obj21.gxTpr_Invoicepaymentmethodid_Z = Z118InvoicePaymentMethodId;
         obj21.gxTpr_Paymentmethodid_Z = Z115PaymentMethodId;
         obj21.gxTpr_Paymentmethoddescription_Z = Z116PaymentMethodDescription;
         obj21.gxTpr_Paymentmethoddiscount_Z = Z129PaymentMethodDiscount;
         obj21.gxTpr_Paymentmethodrecarge_Z = Z130PaymentMethodRecarge;
         obj21.gxTpr_Invoicepaymentmethodimport_Z = Z120InvoicePaymentMethodImport;
         obj21.gxTpr_Invoicepaymentmethodrechargeimport_Z = Z132InvoicePaymentMethodRechargeIm;
         obj21.gxTpr_Invoicepaymentmethoddiscountimport_Z = Z133InvoicePaymentMethodDiscountIm;
         obj21.gxTpr_Paymentmethodid_N = (short)(Convert.ToInt16(n115PaymentMethodId));
         obj21.gxTpr_Invoicepaymentmethodimport_N = (short)(Convert.ToInt16(n120InvoicePaymentMethodImport));
         obj21.gxTpr_Invoicepaymentmethodrechargeimport_N = (short)(Convert.ToInt16(n132InvoicePaymentMethodRechargeIm));
         obj21.gxTpr_Invoicepaymentmethoddiscountimport_N = (short)(Convert.ToInt16(n133InvoicePaymentMethodDiscountIm));
         obj21.gxTpr_Modified = nIsMod_21;
         return  ;
      }

      public void KeyVarsToRow21( SdtInvoice_PaymentMethod obj21 )
      {
         obj21.gxTpr_Invoicepaymentmethodid = A118InvoicePaymentMethodId;
         return  ;
      }

      public void RowToVars21( SdtInvoice_PaymentMethod obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A115PaymentMethodId = obj21.gxTpr_Paymentmethodid;
         n115PaymentMethodId = false;
         A116PaymentMethodDescription = obj21.gxTpr_Paymentmethoddescription;
         A129PaymentMethodDiscount = obj21.gxTpr_Paymentmethoddiscount;
         A130PaymentMethodRecarge = obj21.gxTpr_Paymentmethodrecarge;
         A120InvoicePaymentMethodImport = obj21.gxTpr_Invoicepaymentmethodimport;
         n120InvoicePaymentMethodImport = false;
         A132InvoicePaymentMethodRechargeIm = obj21.gxTpr_Invoicepaymentmethodrechargeimport;
         n132InvoicePaymentMethodRechargeIm = false;
         A133InvoicePaymentMethodDiscountIm = obj21.gxTpr_Invoicepaymentmethoddiscountimport;
         n133InvoicePaymentMethodDiscountIm = false;
         A118InvoicePaymentMethodId = obj21.gxTpr_Invoicepaymentmethodid;
         Z118InvoicePaymentMethodId = obj21.gxTpr_Invoicepaymentmethodid_Z;
         Z115PaymentMethodId = obj21.gxTpr_Paymentmethodid_Z;
         Z116PaymentMethodDescription = obj21.gxTpr_Paymentmethoddescription_Z;
         Z129PaymentMethodDiscount = obj21.gxTpr_Paymentmethoddiscount_Z;
         Z130PaymentMethodRecarge = obj21.gxTpr_Paymentmethodrecarge_Z;
         Z120InvoicePaymentMethodImport = obj21.gxTpr_Invoicepaymentmethodimport_Z;
         Z132InvoicePaymentMethodRechargeIm = obj21.gxTpr_Invoicepaymentmethodrechargeimport_Z;
         Z133InvoicePaymentMethodDiscountIm = obj21.gxTpr_Invoicepaymentmethoddiscountimport_Z;
         n115PaymentMethodId = (bool)(Convert.ToBoolean(obj21.gxTpr_Paymentmethodid_N));
         n120InvoicePaymentMethodImport = (bool)(Convert.ToBoolean(obj21.gxTpr_Invoicepaymentmethodimport_N));
         n132InvoicePaymentMethodRechargeIm = (bool)(Convert.ToBoolean(obj21.gxTpr_Invoicepaymentmethodrechargeimport_N));
         n133InvoicePaymentMethodDiscountIm = (bool)(Convert.ToBoolean(obj21.gxTpr_Invoicepaymentmethoddiscountimport_N));
         nIsMod_21 = obj21.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A20InvoiceId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20InvoiceId = A20InvoiceId;
         }
         ZM066( -16) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         bcInvoice.gxTpr_Detail.ClearCollection();
         if ( RcdFound6 == 1 )
         {
            ScanKeyStart0613( ) ;
            nGXsfl_13_idx = 1;
            while ( RcdFound13 != 0 )
            {
               Z20InvoiceId = A20InvoiceId;
               Z25InvoiceDetailId = A25InvoiceDetailId;
               ZM0613( -21) ;
               OnLoadActions0613( ) ;
               nRcdExists_13 = 1;
               nIsMod_13 = 0;
               AddRow0613( ) ;
               nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
               ScanKeyNext0613( ) ;
            }
            ScanKeyEnd0613( ) ;
         }
         bcInvoice.gxTpr_Paymentmethod.ClearCollection();
         if ( RcdFound6 == 1 )
         {
            ScanKeyStart0621( ) ;
            nGXsfl_21_idx = 1;
            while ( RcdFound21 != 0 )
            {
               Z20InvoiceId = A20InvoiceId;
               Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
               ZM0621( -23) ;
               OnLoadActions0621( ) ;
               nRcdExists_21 = 1;
               nIsMod_21 = 0;
               AddRow0621( ) ;
               nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
               ScanKeyNext0621( ) ;
            }
            ScanKeyEnd0621( ) ;
         }
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcInvoice, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20InvoiceId = A20InvoiceId;
         }
         ZM066( -16) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         bcInvoice.gxTpr_Detail.ClearCollection();
         if ( RcdFound6 == 1 )
         {
            ScanKeyStart0613( ) ;
            nGXsfl_13_idx = 1;
            while ( RcdFound13 != 0 )
            {
               Z20InvoiceId = A20InvoiceId;
               Z25InvoiceDetailId = A25InvoiceDetailId;
               ZM0613( -21) ;
               OnLoadActions0613( ) ;
               nRcdExists_13 = 1;
               nIsMod_13 = 0;
               AddRow0613( ) ;
               nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
               ScanKeyNext0613( ) ;
            }
            ScanKeyEnd0613( ) ;
         }
         bcInvoice.gxTpr_Paymentmethod.ClearCollection();
         if ( RcdFound6 == 1 )
         {
            ScanKeyStart0621( ) ;
            nGXsfl_21_idx = 1;
            while ( RcdFound21 != 0 )
            {
               Z20InvoiceId = A20InvoiceId;
               Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
               ZM0621( -23) ;
               OnLoadActions0621( ) ;
               nRcdExists_21 = 1;
               nIsMod_21 = 0;
               AddRow0621( ) ;
               nGXsfl_21_idx = (int)(nGXsfl_21_idx+1);
               ScanKeyNext0621( ) ;
            }
            ScanKeyEnd0621( ) ;
         }
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A97InvoiceLastDetailId = O97InvoiceLastDetailId;
            A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A20InvoiceId != Z20InvoiceId )
               {
                  A20InvoiceId = Z20InvoiceId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  Update066( ) ;
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
                  if ( A20InvoiceId != Z20InvoiceId )
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
                        A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                        A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                        A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                        n131InvoiceLastPaymentMethodId = false;
                        Insert066( ) ;
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
                        A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                        A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                        A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                        n131InvoiceLastPaymentMethodId = false;
                        Insert066( ) ;
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
         RowToVars6( bcInvoice, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcInvoice) ;
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
         RowToVars6( bcInvoice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A97InvoiceLastDetailId = O97InvoiceLastDetailId;
         A68InvoiceProductQuantity = O68InvoiceProductQuantity;
         A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcInvoice) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcInvoice) ;
         }
         else
         {
            SdtInvoice auxBC = new SdtInvoice(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A20InvoiceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcInvoice);
               auxBC.Save();
               bcInvoice.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcInvoice, 1) ;
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
         RowToVars6( bcInvoice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
               VarsToRow6( bcInvoice) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcInvoice) ;
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
         RowToVars6( bcInvoice, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A20InvoiceId != Z20InvoiceId )
            {
               A20InvoiceId = Z20InvoiceId;
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
            if ( A20InvoiceId != Z20InvoiceId )
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
         pr_default.close(10);
         pr_default.close(6);
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(20);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(27);
         pr_default.close(34);
         context.RollbackDataStores("invoice_bc",pr_default);
         VarsToRow6( bcInvoice) ;
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
         Gx_mode = bcInvoice.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcInvoice.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcInvoice )
         {
            bcInvoice = (SdtInvoice)(sdt);
            if ( StringUtil.StrCmp(bcInvoice.gxTpr_Mode, "") == 0 )
            {
               bcInvoice.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcInvoice) ;
            }
            else
            {
               RowToVars6( bcInvoice, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcInvoice.gxTpr_Mode, "") == 0 )
            {
               bcInvoice.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcInvoice, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtInvoice Invoice_BC
      {
         get {
            return bcInvoice ;
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
         pr_default.close(34);
         pr_default.close(6);
         pr_default.close(27);
         pr_default.close(10);
         pr_default.close(20);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode6 = "";
         BC00068_A80InvoiceTotalReceivable = new decimal[1] ;
         BC00068_n80InvoiceTotalReceivable = new bool[] {false} ;
         BC000610_A131InvoiceLastPaymentMethodId = new int[1] ;
         BC000610_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         BC000615_A68InvoiceProductQuantity = new short[1] ;
         BC000615_A97InvoiceLastDetailId = new int[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV20Pgmname = "";
         AV17Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         Z38InvoiceCreatedDate = DateTime.MinValue;
         A38InvoiceCreatedDate = DateTime.MinValue;
         Z39InvoiceModifiedDate = DateTime.MinValue;
         A39InvoiceModifiedDate = DateTime.MinValue;
         Z100UserName = "";
         A100UserName = "";
         Gx_date = DateTime.MinValue;
         BC000621_A20InvoiceId = new int[1] ;
         BC000621_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000621_A100UserName = new string[] {""} ;
         BC000621_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000621_n39InvoiceModifiedDate = new bool[] {false} ;
         BC000621_A94InvoiceActive = new bool[] {false} ;
         BC000621_A99UserId = new int[1] ;
         BC000621_A68InvoiceProductQuantity = new short[1] ;
         BC000621_A97InvoiceLastDetailId = new int[1] ;
         BC000621_A131InvoiceLastPaymentMethodId = new int[1] ;
         BC000621_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         BC000618_A100UserName = new string[] {""} ;
         BC000622_A20InvoiceId = new int[1] ;
         BC000617_A20InvoiceId = new int[1] ;
         BC000617_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000617_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000617_n39InvoiceModifiedDate = new bool[] {false} ;
         BC000617_A94InvoiceActive = new bool[] {false} ;
         BC000617_A99UserId = new int[1] ;
         BC000616_A20InvoiceId = new int[1] ;
         BC000616_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000616_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000616_n39InvoiceModifiedDate = new bool[] {false} ;
         BC000616_A94InvoiceActive = new bool[] {false} ;
         BC000616_A99UserId = new int[1] ;
         BC000623_A20InvoiceId = new int[1] ;
         BC000629_A80InvoiceTotalReceivable = new decimal[1] ;
         BC000629_n80InvoiceTotalReceivable = new bool[] {false} ;
         BC000631_A68InvoiceProductQuantity = new short[1] ;
         BC000631_A97InvoiceLastDetailId = new int[1] ;
         BC000633_A131InvoiceLastPaymentMethodId = new int[1] ;
         BC000633_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         BC000634_A100UserName = new string[] {""} ;
         BC000637_A20InvoiceId = new int[1] ;
         BC000637_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000637_A100UserName = new string[] {""} ;
         BC000637_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000637_n39InvoiceModifiedDate = new bool[] {false} ;
         BC000637_A94InvoiceActive = new bool[] {false} ;
         BC000637_A99UserId = new int[1] ;
         BC000637_A68InvoiceProductQuantity = new short[1] ;
         BC000637_A97InvoiceLastDetailId = new int[1] ;
         BC000637_A131InvoiceLastPaymentMethodId = new int[1] ;
         BC000637_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         Z16ProductName = "";
         A16ProductName = "";
         BC000638_A20InvoiceId = new int[1] ;
         BC000638_A25InvoiceDetailId = new int[1] ;
         BC000638_A16ProductName = new string[] {""} ;
         BC000638_A17ProductStock = new int[1] ;
         BC000638_n17ProductStock = new bool[] {false} ;
         BC000638_A26InvoiceDetailQuantity = new int[1] ;
         BC000638_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         BC000638_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         BC000638_A15ProductId = new int[1] ;
         BC000613_A16ProductName = new string[] {""} ;
         BC000613_A17ProductStock = new int[1] ;
         BC000613_n17ProductStock = new bool[] {false} ;
         BC000639_A20InvoiceId = new int[1] ;
         BC000639_A25InvoiceDetailId = new int[1] ;
         BC000612_A20InvoiceId = new int[1] ;
         BC000612_A25InvoiceDetailId = new int[1] ;
         BC000612_A26InvoiceDetailQuantity = new int[1] ;
         BC000612_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         BC000612_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         BC000612_A15ProductId = new int[1] ;
         sMode13 = "";
         BC000611_A20InvoiceId = new int[1] ;
         BC000611_A25InvoiceDetailId = new int[1] ;
         BC000611_A26InvoiceDetailQuantity = new int[1] ;
         BC000611_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         BC000611_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         BC000611_A15ProductId = new int[1] ;
         BC000643_A16ProductName = new string[] {""} ;
         BC000643_A17ProductStock = new int[1] ;
         BC000643_n17ProductStock = new bool[] {false} ;
         BC000644_A20InvoiceId = new int[1] ;
         BC000644_A25InvoiceDetailId = new int[1] ;
         BC000644_A16ProductName = new string[] {""} ;
         BC000644_A17ProductStock = new int[1] ;
         BC000644_n17ProductStock = new bool[] {false} ;
         BC000644_A26InvoiceDetailQuantity = new int[1] ;
         BC000644_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         BC000644_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         BC000644_A15ProductId = new int[1] ;
         Z116PaymentMethodDescription = "";
         A116PaymentMethodDescription = "";
         BC000645_A20InvoiceId = new int[1] ;
         BC000645_A118InvoicePaymentMethodId = new int[1] ;
         BC000645_A116PaymentMethodDescription = new string[] {""} ;
         BC000645_A129PaymentMethodDiscount = new decimal[1] ;
         BC000645_A130PaymentMethodRecarge = new decimal[1] ;
         BC000645_A120InvoicePaymentMethodImport = new decimal[1] ;
         BC000645_n120InvoicePaymentMethodImport = new bool[] {false} ;
         BC000645_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         BC000645_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         BC000645_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         BC000645_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         BC000645_A115PaymentMethodId = new int[1] ;
         BC000645_n115PaymentMethodId = new bool[] {false} ;
         BC00064_A116PaymentMethodDescription = new string[] {""} ;
         BC00064_A129PaymentMethodDiscount = new decimal[1] ;
         BC00064_A130PaymentMethodRecarge = new decimal[1] ;
         BC000646_A20InvoiceId = new int[1] ;
         BC000646_A118InvoicePaymentMethodId = new int[1] ;
         BC00063_A20InvoiceId = new int[1] ;
         BC00063_A118InvoicePaymentMethodId = new int[1] ;
         BC00063_A120InvoicePaymentMethodImport = new decimal[1] ;
         BC00063_n120InvoicePaymentMethodImport = new bool[] {false} ;
         BC00063_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         BC00063_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         BC00063_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         BC00063_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         BC00063_A115PaymentMethodId = new int[1] ;
         BC00063_n115PaymentMethodId = new bool[] {false} ;
         sMode21 = "";
         BC00062_A20InvoiceId = new int[1] ;
         BC00062_A118InvoicePaymentMethodId = new int[1] ;
         BC00062_A120InvoicePaymentMethodImport = new decimal[1] ;
         BC00062_n120InvoicePaymentMethodImport = new bool[] {false} ;
         BC00062_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         BC00062_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         BC00062_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         BC00062_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         BC00062_A115PaymentMethodId = new int[1] ;
         BC00062_n115PaymentMethodId = new bool[] {false} ;
         BC000650_A116PaymentMethodDescription = new string[] {""} ;
         BC000650_A129PaymentMethodDiscount = new decimal[1] ;
         BC000650_A130PaymentMethodRecarge = new decimal[1] ;
         BC000651_A20InvoiceId = new int[1] ;
         BC000651_A118InvoicePaymentMethodId = new int[1] ;
         BC000651_A116PaymentMethodDescription = new string[] {""} ;
         BC000651_A129PaymentMethodDiscount = new decimal[1] ;
         BC000651_A130PaymentMethodRecarge = new decimal[1] ;
         BC000651_A120InvoicePaymentMethodImport = new decimal[1] ;
         BC000651_n120InvoicePaymentMethodImport = new bool[] {false} ;
         BC000651_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         BC000651_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         BC000651_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         BC000651_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         BC000651_A115PaymentMethodId = new int[1] ;
         BC000651_n115PaymentMethodId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoice_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A20InvoiceId, BC00062_A118InvoicePaymentMethodId, BC00062_A120InvoicePaymentMethodImport, BC00062_n120InvoicePaymentMethodImport, BC00062_A132InvoicePaymentMethodRechargeIm, BC00062_n132InvoicePaymentMethodRechargeIm, BC00062_A133InvoicePaymentMethodDiscountIm, BC00062_n133InvoicePaymentMethodDiscountIm, BC00062_A115PaymentMethodId, BC00062_n115PaymentMethodId
               }
               , new Object[] {
               BC00063_A20InvoiceId, BC00063_A118InvoicePaymentMethodId, BC00063_A120InvoicePaymentMethodImport, BC00063_n120InvoicePaymentMethodImport, BC00063_A132InvoicePaymentMethodRechargeIm, BC00063_n132InvoicePaymentMethodRechargeIm, BC00063_A133InvoicePaymentMethodDiscountIm, BC00063_n133InvoicePaymentMethodDiscountIm, BC00063_A115PaymentMethodId, BC00063_n115PaymentMethodId
               }
               , new Object[] {
               BC00064_A116PaymentMethodDescription, BC00064_A129PaymentMethodDiscount, BC00064_A130PaymentMethodRecarge
               }
               , new Object[] {
               BC00068_A80InvoiceTotalReceivable, BC00068_n80InvoiceTotalReceivable
               }
               , new Object[] {
               BC000610_A131InvoiceLastPaymentMethodId, BC000610_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               BC000611_A20InvoiceId, BC000611_A25InvoiceDetailId, BC000611_A26InvoiceDetailQuantity, BC000611_A65InvoiceDetailHistoricPrice, BC000611_A98InvoiceDetailIsWholesale, BC000611_A15ProductId
               }
               , new Object[] {
               BC000612_A20InvoiceId, BC000612_A25InvoiceDetailId, BC000612_A26InvoiceDetailQuantity, BC000612_A65InvoiceDetailHistoricPrice, BC000612_A98InvoiceDetailIsWholesale, BC000612_A15ProductId
               }
               , new Object[] {
               BC000613_A16ProductName, BC000613_A17ProductStock, BC000613_n17ProductStock
               }
               , new Object[] {
               BC000615_A68InvoiceProductQuantity, BC000615_A97InvoiceLastDetailId
               }
               , new Object[] {
               BC000616_A20InvoiceId, BC000616_A38InvoiceCreatedDate, BC000616_A39InvoiceModifiedDate, BC000616_n39InvoiceModifiedDate, BC000616_A94InvoiceActive, BC000616_A99UserId
               }
               , new Object[] {
               BC000617_A20InvoiceId, BC000617_A38InvoiceCreatedDate, BC000617_A39InvoiceModifiedDate, BC000617_n39InvoiceModifiedDate, BC000617_A94InvoiceActive, BC000617_A99UserId
               }
               , new Object[] {
               BC000618_A100UserName
               }
               , new Object[] {
               BC000621_A20InvoiceId, BC000621_A38InvoiceCreatedDate, BC000621_A100UserName, BC000621_A39InvoiceModifiedDate, BC000621_n39InvoiceModifiedDate, BC000621_A94InvoiceActive, BC000621_A99UserId, BC000621_A68InvoiceProductQuantity, BC000621_A97InvoiceLastDetailId, BC000621_A131InvoiceLastPaymentMethodId,
               BC000621_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               BC000622_A20InvoiceId
               }
               , new Object[] {
               BC000623_A20InvoiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000629_A80InvoiceTotalReceivable, BC000629_n80InvoiceTotalReceivable
               }
               , new Object[] {
               BC000631_A68InvoiceProductQuantity, BC000631_A97InvoiceLastDetailId
               }
               , new Object[] {
               BC000633_A131InvoiceLastPaymentMethodId, BC000633_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               BC000634_A100UserName
               }
               , new Object[] {
               BC000637_A20InvoiceId, BC000637_A38InvoiceCreatedDate, BC000637_A100UserName, BC000637_A39InvoiceModifiedDate, BC000637_n39InvoiceModifiedDate, BC000637_A94InvoiceActive, BC000637_A99UserId, BC000637_A68InvoiceProductQuantity, BC000637_A97InvoiceLastDetailId, BC000637_A131InvoiceLastPaymentMethodId,
               BC000637_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               BC000638_A20InvoiceId, BC000638_A25InvoiceDetailId, BC000638_A16ProductName, BC000638_A17ProductStock, BC000638_n17ProductStock, BC000638_A26InvoiceDetailQuantity, BC000638_A65InvoiceDetailHistoricPrice, BC000638_A98InvoiceDetailIsWholesale, BC000638_A15ProductId
               }
               , new Object[] {
               BC000639_A20InvoiceId, BC000639_A25InvoiceDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000643_A16ProductName, BC000643_A17ProductStock, BC000643_n17ProductStock
               }
               , new Object[] {
               BC000644_A20InvoiceId, BC000644_A25InvoiceDetailId, BC000644_A16ProductName, BC000644_A17ProductStock, BC000644_n17ProductStock, BC000644_A26InvoiceDetailQuantity, BC000644_A65InvoiceDetailHistoricPrice, BC000644_A98InvoiceDetailIsWholesale, BC000644_A15ProductId
               }
               , new Object[] {
               BC000645_A20InvoiceId, BC000645_A118InvoicePaymentMethodId, BC000645_A116PaymentMethodDescription, BC000645_A129PaymentMethodDiscount, BC000645_A130PaymentMethodRecarge, BC000645_A120InvoicePaymentMethodImport, BC000645_n120InvoicePaymentMethodImport, BC000645_A132InvoicePaymentMethodRechargeIm, BC000645_n132InvoicePaymentMethodRechargeIm, BC000645_A133InvoicePaymentMethodDiscountIm,
               BC000645_n133InvoicePaymentMethodDiscountIm, BC000645_A115PaymentMethodId, BC000645_n115PaymentMethodId
               }
               , new Object[] {
               BC000646_A20InvoiceId, BC000646_A118InvoicePaymentMethodId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000650_A116PaymentMethodDescription, BC000650_A129PaymentMethodDiscount, BC000650_A130PaymentMethodRecarge
               }
               , new Object[] {
               BC000651_A20InvoiceId, BC000651_A118InvoicePaymentMethodId, BC000651_A116PaymentMethodDescription, BC000651_A129PaymentMethodDiscount, BC000651_A130PaymentMethodRecarge, BC000651_A120InvoicePaymentMethodImport, BC000651_n120InvoicePaymentMethodImport, BC000651_A132InvoicePaymentMethodRechargeIm, BC000651_n132InvoicePaymentMethodRechargeIm, BC000651_A133InvoicePaymentMethodDiscountIm,
               BC000651_n133InvoicePaymentMethodDiscountIm, BC000651_A115PaymentMethodId, BC000651_n115PaymentMethodId
               }
            }
         );
         AV20Pgmname = "Invoice_BC";
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_21 ;
      private short RcdFound21 ;
      private short s68InvoiceProductQuantity ;
      private short O68InvoiceProductQuantity ;
      private short A68InvoiceProductQuantity ;
      private short nIsMod_13 ;
      private short RcdFound13 ;
      private short GX_JID ;
      private short Z68InvoiceProductQuantity ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short nRcdExists_13 ;
      private short Gxremove13 ;
      private short nRcdExists_21 ;
      private short Gxremove21 ;
      private short nIsDirty_13 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private int Z20InvoiceId ;
      private int A20InvoiceId ;
      private int s131InvoiceLastPaymentMethodId ;
      private int O131InvoiceLastPaymentMethodId ;
      private int A131InvoiceLastPaymentMethodId ;
      private int nGXsfl_21_idx=1 ;
      private int s97InvoiceLastDetailId ;
      private int O97InvoiceLastDetailId ;
      private int A97InvoiceLastDetailId ;
      private int nGXsfl_13_idx=1 ;
      private int AV14Insert_UserId ;
      private int Z99UserId ;
      private int A99UserId ;
      private int Z97InvoiceLastDetailId ;
      private int Z131InvoiceLastPaymentMethodId ;
      private int Z26InvoiceDetailQuantity ;
      private int A26InvoiceDetailQuantity ;
      private int Z15ProductId ;
      private int A15ProductId ;
      private int Z17ProductStock ;
      private int A17ProductStock ;
      private int Z25InvoiceDetailId ;
      private int A25InvoiceDetailId ;
      private int Z115PaymentMethodId ;
      private int A115PaymentMethodId ;
      private int Z118InvoicePaymentMethodId ;
      private int A118InvoicePaymentMethodId ;
      private int i97InvoiceLastDetailId ;
      private int i131InvoiceLastPaymentMethodId ;
      private decimal A80InvoiceTotalReceivable ;
      private decimal Z80InvoiceTotalReceivable ;
      private decimal Z65InvoiceDetailHistoricPrice ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal Z120InvoicePaymentMethodImport ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal Z132InvoicePaymentMethodRechargeIm ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal Z133InvoicePaymentMethodDiscountIm ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal Z129PaymentMethodDiscount ;
      private decimal A129PaymentMethodDiscount ;
      private decimal Z130PaymentMethodRecarge ;
      private decimal A130PaymentMethodRecarge ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private string AV20Pgmname ;
      private string sMode13 ;
      private string sMode21 ;
      private DateTime Z38InvoiceCreatedDate ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime Z39InvoiceModifiedDate ;
      private DateTime A39InvoiceModifiedDate ;
      private DateTime Gx_date ;
      private bool n131InvoiceLastPaymentMethodId ;
      private bool n80InvoiceTotalReceivable ;
      private bool returnInSub ;
      private bool AV18AllOk ;
      private bool Z94InvoiceActive ;
      private bool A94InvoiceActive ;
      private bool n39InvoiceModifiedDate ;
      private bool Z98InvoiceDetailIsWholesale ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool n17ProductStock ;
      private bool n120InvoicePaymentMethodImport ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool n115PaymentMethodId ;
      private bool mustCommit ;
      private string Z100UserName ;
      private string A100UserName ;
      private string Z16ProductName ;
      private string A16ProductName ;
      private string Z116PaymentMethodDescription ;
      private string A116PaymentMethodDescription ;
      private SdtInvoice bcInvoice ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC00068_A80InvoiceTotalReceivable ;
      private bool[] BC00068_n80InvoiceTotalReceivable ;
      private int[] BC000610_A131InvoiceLastPaymentMethodId ;
      private bool[] BC000610_n131InvoiceLastPaymentMethodId ;
      private short[] BC000615_A68InvoiceProductQuantity ;
      private int[] BC000615_A97InvoiceLastDetailId ;
      private int[] BC000621_A20InvoiceId ;
      private DateTime[] BC000621_A38InvoiceCreatedDate ;
      private string[] BC000621_A100UserName ;
      private DateTime[] BC000621_A39InvoiceModifiedDate ;
      private bool[] BC000621_n39InvoiceModifiedDate ;
      private bool[] BC000621_A94InvoiceActive ;
      private int[] BC000621_A99UserId ;
      private short[] BC000621_A68InvoiceProductQuantity ;
      private int[] BC000621_A97InvoiceLastDetailId ;
      private int[] BC000621_A131InvoiceLastPaymentMethodId ;
      private bool[] BC000621_n131InvoiceLastPaymentMethodId ;
      private string[] BC000618_A100UserName ;
      private int[] BC000622_A20InvoiceId ;
      private int[] BC000617_A20InvoiceId ;
      private DateTime[] BC000617_A38InvoiceCreatedDate ;
      private DateTime[] BC000617_A39InvoiceModifiedDate ;
      private bool[] BC000617_n39InvoiceModifiedDate ;
      private bool[] BC000617_A94InvoiceActive ;
      private int[] BC000617_A99UserId ;
      private int[] BC000616_A20InvoiceId ;
      private DateTime[] BC000616_A38InvoiceCreatedDate ;
      private DateTime[] BC000616_A39InvoiceModifiedDate ;
      private bool[] BC000616_n39InvoiceModifiedDate ;
      private bool[] BC000616_A94InvoiceActive ;
      private int[] BC000616_A99UserId ;
      private int[] BC000623_A20InvoiceId ;
      private decimal[] BC000629_A80InvoiceTotalReceivable ;
      private bool[] BC000629_n80InvoiceTotalReceivable ;
      private short[] BC000631_A68InvoiceProductQuantity ;
      private int[] BC000631_A97InvoiceLastDetailId ;
      private int[] BC000633_A131InvoiceLastPaymentMethodId ;
      private bool[] BC000633_n131InvoiceLastPaymentMethodId ;
      private string[] BC000634_A100UserName ;
      private int[] BC000637_A20InvoiceId ;
      private DateTime[] BC000637_A38InvoiceCreatedDate ;
      private string[] BC000637_A100UserName ;
      private DateTime[] BC000637_A39InvoiceModifiedDate ;
      private bool[] BC000637_n39InvoiceModifiedDate ;
      private bool[] BC000637_A94InvoiceActive ;
      private int[] BC000637_A99UserId ;
      private short[] BC000637_A68InvoiceProductQuantity ;
      private int[] BC000637_A97InvoiceLastDetailId ;
      private int[] BC000637_A131InvoiceLastPaymentMethodId ;
      private bool[] BC000637_n131InvoiceLastPaymentMethodId ;
      private int[] BC000638_A20InvoiceId ;
      private int[] BC000638_A25InvoiceDetailId ;
      private string[] BC000638_A16ProductName ;
      private int[] BC000638_A17ProductStock ;
      private bool[] BC000638_n17ProductStock ;
      private int[] BC000638_A26InvoiceDetailQuantity ;
      private decimal[] BC000638_A65InvoiceDetailHistoricPrice ;
      private bool[] BC000638_A98InvoiceDetailIsWholesale ;
      private int[] BC000638_A15ProductId ;
      private string[] BC000613_A16ProductName ;
      private int[] BC000613_A17ProductStock ;
      private bool[] BC000613_n17ProductStock ;
      private int[] BC000639_A20InvoiceId ;
      private int[] BC000639_A25InvoiceDetailId ;
      private int[] BC000612_A20InvoiceId ;
      private int[] BC000612_A25InvoiceDetailId ;
      private int[] BC000612_A26InvoiceDetailQuantity ;
      private decimal[] BC000612_A65InvoiceDetailHistoricPrice ;
      private bool[] BC000612_A98InvoiceDetailIsWholesale ;
      private int[] BC000612_A15ProductId ;
      private int[] BC000611_A20InvoiceId ;
      private int[] BC000611_A25InvoiceDetailId ;
      private int[] BC000611_A26InvoiceDetailQuantity ;
      private decimal[] BC000611_A65InvoiceDetailHistoricPrice ;
      private bool[] BC000611_A98InvoiceDetailIsWholesale ;
      private int[] BC000611_A15ProductId ;
      private string[] BC000643_A16ProductName ;
      private int[] BC000643_A17ProductStock ;
      private bool[] BC000643_n17ProductStock ;
      private int[] BC000644_A20InvoiceId ;
      private int[] BC000644_A25InvoiceDetailId ;
      private string[] BC000644_A16ProductName ;
      private int[] BC000644_A17ProductStock ;
      private bool[] BC000644_n17ProductStock ;
      private int[] BC000644_A26InvoiceDetailQuantity ;
      private decimal[] BC000644_A65InvoiceDetailHistoricPrice ;
      private bool[] BC000644_A98InvoiceDetailIsWholesale ;
      private int[] BC000644_A15ProductId ;
      private int[] BC000645_A20InvoiceId ;
      private int[] BC000645_A118InvoicePaymentMethodId ;
      private string[] BC000645_A116PaymentMethodDescription ;
      private decimal[] BC000645_A129PaymentMethodDiscount ;
      private decimal[] BC000645_A130PaymentMethodRecarge ;
      private decimal[] BC000645_A120InvoicePaymentMethodImport ;
      private bool[] BC000645_n120InvoicePaymentMethodImport ;
      private decimal[] BC000645_A132InvoicePaymentMethodRechargeIm ;
      private bool[] BC000645_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] BC000645_A133InvoicePaymentMethodDiscountIm ;
      private bool[] BC000645_n133InvoicePaymentMethodDiscountIm ;
      private int[] BC000645_A115PaymentMethodId ;
      private bool[] BC000645_n115PaymentMethodId ;
      private string[] BC00064_A116PaymentMethodDescription ;
      private decimal[] BC00064_A129PaymentMethodDiscount ;
      private decimal[] BC00064_A130PaymentMethodRecarge ;
      private int[] BC000646_A20InvoiceId ;
      private int[] BC000646_A118InvoicePaymentMethodId ;
      private int[] BC00063_A20InvoiceId ;
      private int[] BC00063_A118InvoicePaymentMethodId ;
      private decimal[] BC00063_A120InvoicePaymentMethodImport ;
      private bool[] BC00063_n120InvoicePaymentMethodImport ;
      private decimal[] BC00063_A132InvoicePaymentMethodRechargeIm ;
      private bool[] BC00063_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] BC00063_A133InvoicePaymentMethodDiscountIm ;
      private bool[] BC00063_n133InvoicePaymentMethodDiscountIm ;
      private int[] BC00063_A115PaymentMethodId ;
      private bool[] BC00063_n115PaymentMethodId ;
      private int[] BC00062_A20InvoiceId ;
      private int[] BC00062_A118InvoicePaymentMethodId ;
      private decimal[] BC00062_A120InvoicePaymentMethodImport ;
      private bool[] BC00062_n120InvoicePaymentMethodImport ;
      private decimal[] BC00062_A132InvoicePaymentMethodRechargeIm ;
      private bool[] BC00062_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] BC00062_A133InvoicePaymentMethodDiscountIm ;
      private bool[] BC00062_n133InvoicePaymentMethodDiscountIm ;
      private int[] BC00062_A115PaymentMethodId ;
      private bool[] BC00062_n115PaymentMethodId ;
      private string[] BC000650_A116PaymentMethodDescription ;
      private decimal[] BC000650_A129PaymentMethodDiscount ;
      private decimal[] BC000650_A130PaymentMethodRecarge ;
      private int[] BC000651_A20InvoiceId ;
      private int[] BC000651_A118InvoicePaymentMethodId ;
      private string[] BC000651_A116PaymentMethodDescription ;
      private decimal[] BC000651_A129PaymentMethodDiscount ;
      private decimal[] BC000651_A130PaymentMethodRecarge ;
      private decimal[] BC000651_A120InvoicePaymentMethodImport ;
      private bool[] BC000651_n120InvoicePaymentMethodImport ;
      private decimal[] BC000651_A132InvoicePaymentMethodRechargeIm ;
      private bool[] BC000651_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] BC000651_A133InvoicePaymentMethodDiscountIm ;
      private bool[] BC000651_n133InvoicePaymentMethodDiscountIm ;
      private int[] BC000651_A115PaymentMethodId ;
      private bool[] BC000651_n115PaymentMethodId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV17Context ;
   }

   public class invoice_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new UpdateCursor(def[31])
         ,new UpdateCursor(def[32])
         ,new UpdateCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000621;
          prmBC000621 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000615;
          prmBC000615 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000618;
          prmBC000618 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000622;
          prmBC000622 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000617;
          prmBC000617 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000616;
          prmBC000616 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000623;
          prmBC000623 = new Object[] {
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000624;
          prmBC000624 = new Object[] {
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@UserId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000625;
          prmBC000625 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000634;
          prmBC000634 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000631;
          prmBC000631 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000629;
          prmBC000629 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000633;
          prmBC000633 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000637;
          prmBC000637 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000638;
          prmBC000638 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000613;
          prmBC000613 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000639;
          prmBC000639 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000640;
          prmBC000640 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@InvoiceDetailIsWholesale",GXType.Boolean,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000641;
          prmBC000641 = new Object[] {
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@InvoiceDetailIsWholesale",GXType.Boolean,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000642;
          prmBC000642 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmBC000643;
          prmBC000643 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000644;
          prmBC000644 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmBC000645;
          prmBC000645 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000646;
          prmBC000646 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC000647;
          prmBC000647 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodImport",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodRechargeIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodDiscountIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000648;
          prmBC000648 = new Object[] {
          new ParDef("@InvoicePaymentMethodImport",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodRechargeIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodDiscountIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC000649;
          prmBC000649 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmBC000650;
          prmBC000650 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000651;
          prmBC000651 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId] FROM [InvoicePaymentMethod] WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [PaymentMethodDescription], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T3.[GXC1], 0) - COALESCE( T2.[GXC2], 0) + COALESCE( T2.[GXC3], 0) AS InvoiceTotalReceivable FROM (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T2, (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T3 WHERE T2.[InvoiceId] = @InvoiceId AND T3.[InvoiceId] = @InvoiceId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000610", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000611", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId] FROM [InvoiceDetail] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000612", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000613", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000615", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T1.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000616", "SELECT [InvoiceId], [InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId] FROM [Invoice] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000617", "SELECT [InvoiceId], [InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000618", "SELECT [UserName] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000621", "SELECT TM1.[InvoiceId], TM1.[InvoiceCreatedDate], T4.[UserName], TM1.[InvoiceModifiedDate], TM1.[InvoiceActive], TM1.[UserId], COALESCE( T2.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T2.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId, COALESCE( T3.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM ((([Invoice] TM1 LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T2 ON T2.[InvoiceId] = TM1.[InvoiceId]) LEFT JOIN (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = TM1.[InvoiceId]) INNER JOIN [User] T4 ON T4.[UserId] = TM1.[UserId]) WHERE TM1.[InvoiceId] = @InvoiceId ORDER BY TM1.[InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000621,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000622", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000623", "INSERT INTO [Invoice]([InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId]) VALUES(@InvoiceCreatedDate, @InvoiceModifiedDate, @InvoiceActive, @UserId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000623,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000624", "UPDATE [Invoice] SET [InvoiceCreatedDate]=@InvoiceCreatedDate, [InvoiceModifiedDate]=@InvoiceModifiedDate, [InvoiceActive]=@InvoiceActive, [UserId]=@UserId  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmBC000624)
             ,new CursorDef("BC000625", "DELETE FROM [Invoice]  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmBC000625)
             ,new CursorDef("BC000629", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T3.[GXC1], 0) - COALESCE( T2.[GXC2], 0) + COALESCE( T2.[GXC3], 0) AS InvoiceTotalReceivable FROM (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T2, (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T3 WHERE T2.[InvoiceId] = @InvoiceId AND T3.[InvoiceId] = @InvoiceId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000629,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000631", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T1.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000631,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000633", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000633,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000634", "SELECT [UserName] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000634,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000637", "SELECT TM1.[InvoiceId], TM1.[InvoiceCreatedDate], T4.[UserName], TM1.[InvoiceModifiedDate], TM1.[InvoiceActive], TM1.[UserId], COALESCE( T2.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T2.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId, COALESCE( T3.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM ((([Invoice] TM1 LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T2 ON T2.[InvoiceId] = TM1.[InvoiceId]) LEFT JOIN (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = TM1.[InvoiceId]) INNER JOIN [User] T4 ON T4.[UserId] = TM1.[UserId]) WHERE TM1.[InvoiceId] = @InvoiceId ORDER BY TM1.[InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000637,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000638", "SELECT T1.[InvoiceId], T1.[InvoiceDetailId], T2.[ProductName], T2.[ProductStock], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailIsWholesale], T1.[ProductId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId and T1.[InvoiceDetailId] = @InvoiceDetailId ORDER BY T1.[InvoiceId], T1.[InvoiceDetailId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000638,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000639", "SELECT [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000639,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000640", "INSERT INTO [InvoiceDetail]([InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId]) VALUES(@InvoiceId, @InvoiceDetailId, @InvoiceDetailQuantity, @InvoiceDetailHistoricPrice, @InvoiceDetailIsWholesale, @ProductId)", GxErrorMask.GX_NOMASK,prmBC000640)
             ,new CursorDef("BC000641", "UPDATE [InvoiceDetail] SET [InvoiceDetailQuantity]=@InvoiceDetailQuantity, [InvoiceDetailHistoricPrice]=@InvoiceDetailHistoricPrice, [InvoiceDetailIsWholesale]=@InvoiceDetailIsWholesale, [ProductId]=@ProductId  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmBC000641)
             ,new CursorDef("BC000642", "DELETE FROM [InvoiceDetail]  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmBC000642)
             ,new CursorDef("BC000643", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000643,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000644", "SELECT T1.[InvoiceId], T1.[InvoiceDetailId], T2.[ProductName], T2.[ProductStock], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailIsWholesale], T1.[ProductId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId], T1.[InvoiceDetailId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000644,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000645", "SELECT T1.[InvoiceId], T1.[InvoicePaymentMethodId], T2.[PaymentMethodDescription], T2.[PaymentMethodDiscount], T2.[PaymentMethodRecarge], T1.[InvoicePaymentMethodImport], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[PaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId and T1.[InvoicePaymentMethodId] = @InvoicePaymentMethodId ORDER BY T1.[InvoiceId], T1.[InvoicePaymentMethodId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000645,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000646", "SELECT [InvoiceId], [InvoicePaymentMethodId] FROM [InvoicePaymentMethod] WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000646,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000647", "INSERT INTO [InvoicePaymentMethod]([InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId]) VALUES(@InvoiceId, @InvoicePaymentMethodId, @InvoicePaymentMethodImport, @InvoicePaymentMethodRechargeIm, @InvoicePaymentMethodDiscountIm, @PaymentMethodId)", GxErrorMask.GX_NOMASK,prmBC000647)
             ,new CursorDef("BC000648", "UPDATE [InvoicePaymentMethod] SET [InvoicePaymentMethodImport]=@InvoicePaymentMethodImport, [InvoicePaymentMethodRechargeIm]=@InvoicePaymentMethodRechargeIm, [InvoicePaymentMethodDiscountIm]=@InvoicePaymentMethodDiscountIm, [PaymentMethodId]=@PaymentMethodId  WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId", GxErrorMask.GX_NOMASK,prmBC000648)
             ,new CursorDef("BC000649", "DELETE FROM [InvoicePaymentMethod]  WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId", GxErrorMask.GX_NOMASK,prmBC000649)
             ,new CursorDef("BC000650", "SELECT [PaymentMethodDescription], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000650,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000651", "SELECT T1.[InvoiceId], T1.[InvoicePaymentMethodId], T2.[PaymentMethodDescription], T2.[PaymentMethodDiscount], T2.[PaymentMethodRecarge], T1.[InvoicePaymentMethodImport], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[PaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId], T1.[InvoicePaymentMethodId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000651,11, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 35 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
