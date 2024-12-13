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
   public class supplier_bc : GxSilentTrn, IGxSilentTrn
   {
      public supplier_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public supplier_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4SupplierId = A4SupplierId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 12) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "supplier view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "supplier insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "supplier update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "supplier delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            CallWebObject(formatLink("wwsupplier.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z112SupplierActive = A112SupplierActive;
            Z5SupplierName = A5SupplierName;
            Z6SupplierDescription = A6SupplierDescription;
            Z7SupplierPhone = A7SupplierPhone;
            Z8SupplierEmail = A8SupplierEmail;
            Z32SupplierCreatedDate = A32SupplierCreatedDate;
            Z33SupplierModifiedDate = A33SupplierModifiedDate;
            Z57SupplierProductQuantity = A57SupplierProductQuantity;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z57SupplierProductQuantity = A57SupplierProductQuantity;
         }
         if ( GX_JID == -10 )
         {
            Z4SupplierId = A4SupplierId;
            Z112SupplierActive = A112SupplierActive;
            Z5SupplierName = A5SupplierName;
            Z6SupplierDescription = A6SupplierDescription;
            Z7SupplierPhone = A7SupplierPhone;
            Z8SupplierEmail = A8SupplierEmail;
            Z32SupplierCreatedDate = A32SupplierCreatedDate;
            Z33SupplierModifiedDate = A33SupplierModifiedDate;
            Z57SupplierProductQuantity = A57SupplierProductQuantity;
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
            A112SupplierActive = true;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A32SupplierCreatedDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A33SupplierModifiedDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV12Pgmname = "Supplier_BC";
         }
      }

      protected void Load022( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(3, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A112SupplierActive = BC00027_A112SupplierActive[0];
            A5SupplierName = BC00027_A5SupplierName[0];
            A6SupplierDescription = BC00027_A6SupplierDescription[0];
            n6SupplierDescription = BC00027_n6SupplierDescription[0];
            A7SupplierPhone = BC00027_A7SupplierPhone[0];
            n7SupplierPhone = BC00027_n7SupplierPhone[0];
            A8SupplierEmail = BC00027_A8SupplierEmail[0];
            n8SupplierEmail = BC00027_n8SupplierEmail[0];
            A32SupplierCreatedDate = BC00027_A32SupplierCreatedDate[0];
            A33SupplierModifiedDate = BC00027_A33SupplierModifiedDate[0];
            A57SupplierProductQuantity = BC00027_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = BC00027_n57SupplierProductQuantity[0];
            ZM022( -10) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV12Pgmname = "Supplier_BC";
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         AV12Pgmname = "Supplier_BC";
         /* Using cursor BC00025 */
         pr_default.execute(2, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A57SupplierProductQuantity = BC00025_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = BC00025_n57SupplierProductQuantity[0];
         }
         else
         {
            nIsDirty_2 = 1;
            A57SupplierProductQuantity = 0;
            n57SupplierProductQuantity = false;
         }
         pr_default.close(2);
         /* Using cursor BC00028 */
         pr_default.execute(4, new Object[] {A5SupplierName, A4SupplierId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Supplier Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( ! ( GxRegex.IsMatch(A8SupplierEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) ) )
         {
            GX_msglist.addItem("Field Supplier Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A32SupplierCreatedDate) || ( DateTimeUtil.ResetTime ( A32SupplierCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Supplier Created Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A33SupplierModifiedDate) || ( DateTimeUtil.ResetTime ( A33SupplierModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Supplier Modified Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00029 */
         pr_default.execute(5, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 10) ;
            RcdFound2 = 1;
            A4SupplierId = BC00023_A4SupplierId[0];
            A112SupplierActive = BC00023_A112SupplierActive[0];
            A5SupplierName = BC00023_A5SupplierName[0];
            A6SupplierDescription = BC00023_A6SupplierDescription[0];
            n6SupplierDescription = BC00023_n6SupplierDescription[0];
            A7SupplierPhone = BC00023_A7SupplierPhone[0];
            n7SupplierPhone = BC00023_n7SupplierPhone[0];
            A8SupplierEmail = BC00023_A8SupplierEmail[0];
            n8SupplierEmail = BC00023_n8SupplierEmail[0];
            A32SupplierCreatedDate = BC00023_A32SupplierCreatedDate[0];
            A33SupplierModifiedDate = BC00023_A33SupplierModifiedDate[0];
            Z4SupplierId = A4SupplierId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z112SupplierActive != BC00022_A112SupplierActive[0] ) || ( StringUtil.StrCmp(Z5SupplierName, BC00022_A5SupplierName[0]) != 0 ) || ( StringUtil.StrCmp(Z6SupplierDescription, BC00022_A6SupplierDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z7SupplierPhone, BC00022_A7SupplierPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z8SupplierEmail, BC00022_A8SupplierEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z32SupplierCreatedDate ) != DateTimeUtil.ResetTime ( BC00022_A32SupplierCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z33SupplierModifiedDate ) != DateTimeUtil.ResetTime ( BC00022_A33SupplierModifiedDate[0] ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000210 */
                     pr_default.execute(6, new Object[] {A112SupplierActive, A5SupplierName, n6SupplierDescription, A6SupplierDescription, n7SupplierPhone, A7SupplierPhone, n8SupplierEmail, A8SupplierEmail, A32SupplierCreatedDate, A33SupplierModifiedDate});
                     A4SupplierId = BC000210_A4SupplierId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000211 */
                     pr_default.execute(7, new Object[] {A112SupplierActive, A5SupplierName, n6SupplierDescription, A6SupplierDescription, n7SupplierPhone, A7SupplierPhone, n8SupplierEmail, A8SupplierEmail, A32SupplierCreatedDate, A33SupplierModifiedDate, A4SupplierId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000212 */
                  pr_default.execute(8, new Object[] {A4SupplierId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Supplier");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Supplier_BC";
            /* Using cursor BC000214 */
            pr_default.execute(9, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A57SupplierProductQuantity = BC000214_A57SupplierProductQuantity[0];
               n57SupplierProductQuantity = BC000214_n57SupplierProductQuantity[0];
            }
            else
            {
               A57SupplierProductQuantity = 0;
               n57SupplierProductQuantity = false;
            }
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000215 */
            pr_default.execute(10, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Purchase Order"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000216 */
            pr_default.execute(11, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000218 */
         pr_default.execute(12, new Object[] {A4SupplierId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A4SupplierId = BC000218_A4SupplierId[0];
            A112SupplierActive = BC000218_A112SupplierActive[0];
            A5SupplierName = BC000218_A5SupplierName[0];
            A6SupplierDescription = BC000218_A6SupplierDescription[0];
            n6SupplierDescription = BC000218_n6SupplierDescription[0];
            A7SupplierPhone = BC000218_A7SupplierPhone[0];
            n7SupplierPhone = BC000218_n7SupplierPhone[0];
            A8SupplierEmail = BC000218_A8SupplierEmail[0];
            n8SupplierEmail = BC000218_n8SupplierEmail[0];
            A32SupplierCreatedDate = BC000218_A32SupplierCreatedDate[0];
            A33SupplierModifiedDate = BC000218_A33SupplierModifiedDate[0];
            A57SupplierProductQuantity = BC000218_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = BC000218_n57SupplierProductQuantity[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A4SupplierId = BC000218_A4SupplierId[0];
            A112SupplierActive = BC000218_A112SupplierActive[0];
            A5SupplierName = BC000218_A5SupplierName[0];
            A6SupplierDescription = BC000218_A6SupplierDescription[0];
            n6SupplierDescription = BC000218_n6SupplierDescription[0];
            A7SupplierPhone = BC000218_A7SupplierPhone[0];
            n7SupplierPhone = BC000218_n7SupplierPhone[0];
            A8SupplierEmail = BC000218_A8SupplierEmail[0];
            n8SupplierEmail = BC000218_n8SupplierEmail[0];
            A32SupplierCreatedDate = BC000218_A32SupplierCreatedDate[0];
            A33SupplierModifiedDate = BC000218_A33SupplierModifiedDate[0];
            A57SupplierProductQuantity = BC000218_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = BC000218_n57SupplierProductQuantity[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcSupplier) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcSupplier, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A112SupplierActive = false;
         A5SupplierName = "";
         A6SupplierDescription = "";
         n6SupplierDescription = false;
         A7SupplierPhone = "";
         n7SupplierPhone = false;
         A8SupplierEmail = "";
         n8SupplierEmail = false;
         A32SupplierCreatedDate = DateTime.MinValue;
         A33SupplierModifiedDate = DateTime.MinValue;
         A57SupplierProductQuantity = 0;
         n57SupplierProductQuantity = false;
         Z112SupplierActive = false;
         Z5SupplierName = "";
         Z6SupplierDescription = "";
         Z7SupplierPhone = "";
         Z8SupplierEmail = "";
         Z32SupplierCreatedDate = DateTime.MinValue;
         Z33SupplierModifiedDate = DateTime.MinValue;
      }

      protected void InitAll022( )
      {
         A4SupplierId = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow2( SdtSupplier obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Supplieractive = A112SupplierActive;
         obj2.gxTpr_Suppliername = A5SupplierName;
         obj2.gxTpr_Supplierdescription = A6SupplierDescription;
         obj2.gxTpr_Supplierphone = A7SupplierPhone;
         obj2.gxTpr_Supplieremail = A8SupplierEmail;
         obj2.gxTpr_Suppliercreateddate = A32SupplierCreatedDate;
         obj2.gxTpr_Suppliermodifieddate = A33SupplierModifiedDate;
         obj2.gxTpr_Supplierproductquantity = A57SupplierProductQuantity;
         obj2.gxTpr_Supplierid = A4SupplierId;
         obj2.gxTpr_Supplierid_Z = Z4SupplierId;
         obj2.gxTpr_Suppliername_Z = Z5SupplierName;
         obj2.gxTpr_Supplierdescription_Z = Z6SupplierDescription;
         obj2.gxTpr_Supplierphone_Z = Z7SupplierPhone;
         obj2.gxTpr_Supplieremail_Z = Z8SupplierEmail;
         obj2.gxTpr_Suppliercreateddate_Z = Z32SupplierCreatedDate;
         obj2.gxTpr_Suppliermodifieddate_Z = Z33SupplierModifiedDate;
         obj2.gxTpr_Supplierproductquantity_Z = Z57SupplierProductQuantity;
         obj2.gxTpr_Supplieractive_Z = Z112SupplierActive;
         obj2.gxTpr_Supplierdescription_N = (short)(Convert.ToInt16(n6SupplierDescription));
         obj2.gxTpr_Supplierphone_N = (short)(Convert.ToInt16(n7SupplierPhone));
         obj2.gxTpr_Supplieremail_N = (short)(Convert.ToInt16(n8SupplierEmail));
         obj2.gxTpr_Supplierproductquantity_N = (short)(Convert.ToInt16(n57SupplierProductQuantity));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtSupplier obj2 )
      {
         obj2.gxTpr_Supplierid = A4SupplierId;
         return  ;
      }

      public void RowToVars2( SdtSupplier obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A112SupplierActive = obj2.gxTpr_Supplieractive;
         }
         A5SupplierName = obj2.gxTpr_Suppliername;
         A6SupplierDescription = obj2.gxTpr_Supplierdescription;
         n6SupplierDescription = false;
         A7SupplierPhone = obj2.gxTpr_Supplierphone;
         n7SupplierPhone = false;
         A8SupplierEmail = obj2.gxTpr_Supplieremail;
         n8SupplierEmail = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A32SupplierCreatedDate = obj2.gxTpr_Suppliercreateddate;
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A33SupplierModifiedDate = obj2.gxTpr_Suppliermodifieddate;
         }
         A57SupplierProductQuantity = obj2.gxTpr_Supplierproductquantity;
         n57SupplierProductQuantity = false;
         A4SupplierId = obj2.gxTpr_Supplierid;
         Z4SupplierId = obj2.gxTpr_Supplierid_Z;
         Z5SupplierName = obj2.gxTpr_Suppliername_Z;
         Z6SupplierDescription = obj2.gxTpr_Supplierdescription_Z;
         Z7SupplierPhone = obj2.gxTpr_Supplierphone_Z;
         Z8SupplierEmail = obj2.gxTpr_Supplieremail_Z;
         Z32SupplierCreatedDate = obj2.gxTpr_Suppliercreateddate_Z;
         Z33SupplierModifiedDate = obj2.gxTpr_Suppliermodifieddate_Z;
         Z57SupplierProductQuantity = obj2.gxTpr_Supplierproductquantity_Z;
         Z112SupplierActive = obj2.gxTpr_Supplieractive_Z;
         n6SupplierDescription = (bool)(Convert.ToBoolean(obj2.gxTpr_Supplierdescription_N));
         n7SupplierPhone = (bool)(Convert.ToBoolean(obj2.gxTpr_Supplierphone_N));
         n8SupplierEmail = (bool)(Convert.ToBoolean(obj2.gxTpr_Supplieremail_N));
         n57SupplierProductQuantity = (bool)(Convert.ToBoolean(obj2.gxTpr_Supplierproductquantity_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4SupplierId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4SupplierId = A4SupplierId;
         }
         ZM022( -10) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcSupplier, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4SupplierId = A4SupplierId;
         }
         ZM022( -10) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4SupplierId != Z4SupplierId )
               {
                  A4SupplierId = Z4SupplierId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update022( ) ;
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
                  if ( A4SupplierId != Z4SupplierId )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcSupplier, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcSupplier) ;
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
         RowToVars2( bcSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcSupplier) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcSupplier) ;
         }
         else
         {
            SdtSupplier auxBC = new SdtSupplier(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4SupplierId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSupplier);
               auxBC.Save();
               bcSupplier.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bcSupplier, 1) ;
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
         RowToVars2( bcSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bcSupplier) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcSupplier) ;
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
         RowToVars2( bcSupplier, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4SupplierId != Z4SupplierId )
            {
               A4SupplierId = Z4SupplierId;
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
            if ( A4SupplierId != Z4SupplierId )
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
         pr_default.close(1);
         pr_default.close(9);
         context.RollbackDataStores("supplier_bc",pr_default);
         VarsToRow2( bcSupplier) ;
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
         Gx_mode = bcSupplier.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSupplier.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSupplier )
         {
            bcSupplier = (SdtSupplier)(sdt);
            if ( StringUtil.StrCmp(bcSupplier.gxTpr_Mode, "") == 0 )
            {
               bcSupplier.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcSupplier) ;
            }
            else
            {
               RowToVars2( bcSupplier, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSupplier.gxTpr_Mode, "") == 0 )
            {
               bcSupplier.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcSupplier, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtSupplier Supplier_BC
      {
         get {
            return bcSupplier ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV12Pgmname = "";
         Z5SupplierName = "";
         A5SupplierName = "";
         Z6SupplierDescription = "";
         A6SupplierDescription = "";
         Z7SupplierPhone = "";
         A7SupplierPhone = "";
         Z8SupplierEmail = "";
         A8SupplierEmail = "";
         Z32SupplierCreatedDate = DateTime.MinValue;
         A32SupplierCreatedDate = DateTime.MinValue;
         Z33SupplierModifiedDate = DateTime.MinValue;
         A33SupplierModifiedDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         BC00027_A4SupplierId = new int[1] ;
         BC00027_A112SupplierActive = new bool[] {false} ;
         BC00027_A5SupplierName = new string[] {""} ;
         BC00027_A6SupplierDescription = new string[] {""} ;
         BC00027_n6SupplierDescription = new bool[] {false} ;
         BC00027_A7SupplierPhone = new string[] {""} ;
         BC00027_n7SupplierPhone = new bool[] {false} ;
         BC00027_A8SupplierEmail = new string[] {""} ;
         BC00027_n8SupplierEmail = new bool[] {false} ;
         BC00027_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00027_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00027_A57SupplierProductQuantity = new short[1] ;
         BC00027_n57SupplierProductQuantity = new bool[] {false} ;
         BC00025_A57SupplierProductQuantity = new short[1] ;
         BC00025_n57SupplierProductQuantity = new bool[] {false} ;
         BC00028_A5SupplierName = new string[] {""} ;
         BC00029_A4SupplierId = new int[1] ;
         BC00023_A4SupplierId = new int[1] ;
         BC00023_A112SupplierActive = new bool[] {false} ;
         BC00023_A5SupplierName = new string[] {""} ;
         BC00023_A6SupplierDescription = new string[] {""} ;
         BC00023_n6SupplierDescription = new bool[] {false} ;
         BC00023_A7SupplierPhone = new string[] {""} ;
         BC00023_n7SupplierPhone = new bool[] {false} ;
         BC00023_A8SupplierEmail = new string[] {""} ;
         BC00023_n8SupplierEmail = new bool[] {false} ;
         BC00023_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00023_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         sMode2 = "";
         BC00022_A4SupplierId = new int[1] ;
         BC00022_A112SupplierActive = new bool[] {false} ;
         BC00022_A5SupplierName = new string[] {""} ;
         BC00022_A6SupplierDescription = new string[] {""} ;
         BC00022_n6SupplierDescription = new bool[] {false} ;
         BC00022_A7SupplierPhone = new string[] {""} ;
         BC00022_n7SupplierPhone = new bool[] {false} ;
         BC00022_A8SupplierEmail = new string[] {""} ;
         BC00022_n8SupplierEmail = new bool[] {false} ;
         BC00022_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00022_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000210_A4SupplierId = new int[1] ;
         BC000214_A57SupplierProductQuantity = new short[1] ;
         BC000214_n57SupplierProductQuantity = new bool[] {false} ;
         BC000215_A50PurchaseOrderId = new int[1] ;
         BC000216_A15ProductId = new int[1] ;
         BC000218_A4SupplierId = new int[1] ;
         BC000218_A112SupplierActive = new bool[] {false} ;
         BC000218_A5SupplierName = new string[] {""} ;
         BC000218_A6SupplierDescription = new string[] {""} ;
         BC000218_n6SupplierDescription = new bool[] {false} ;
         BC000218_A7SupplierPhone = new string[] {""} ;
         BC000218_n7SupplierPhone = new bool[] {false} ;
         BC000218_A8SupplierEmail = new string[] {""} ;
         BC000218_n8SupplierEmail = new bool[] {false} ;
         BC000218_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000218_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000218_A57SupplierProductQuantity = new short[1] ;
         BC000218_n57SupplierProductQuantity = new bool[] {false} ;
         N32SupplierCreatedDate = DateTime.MinValue;
         N33SupplierModifiedDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A4SupplierId, BC00022_A112SupplierActive, BC00022_A5SupplierName, BC00022_A6SupplierDescription, BC00022_n6SupplierDescription, BC00022_A7SupplierPhone, BC00022_n7SupplierPhone, BC00022_A8SupplierEmail, BC00022_n8SupplierEmail, BC00022_A32SupplierCreatedDate,
               BC00022_A33SupplierModifiedDate
               }
               , new Object[] {
               BC00023_A4SupplierId, BC00023_A112SupplierActive, BC00023_A5SupplierName, BC00023_A6SupplierDescription, BC00023_n6SupplierDescription, BC00023_A7SupplierPhone, BC00023_n7SupplierPhone, BC00023_A8SupplierEmail, BC00023_n8SupplierEmail, BC00023_A32SupplierCreatedDate,
               BC00023_A33SupplierModifiedDate
               }
               , new Object[] {
               BC00025_A57SupplierProductQuantity, BC00025_n57SupplierProductQuantity
               }
               , new Object[] {
               BC00027_A4SupplierId, BC00027_A112SupplierActive, BC00027_A5SupplierName, BC00027_A6SupplierDescription, BC00027_n6SupplierDescription, BC00027_A7SupplierPhone, BC00027_n7SupplierPhone, BC00027_A8SupplierEmail, BC00027_n8SupplierEmail, BC00027_A32SupplierCreatedDate,
               BC00027_A33SupplierModifiedDate, BC00027_A57SupplierProductQuantity, BC00027_n57SupplierProductQuantity
               }
               , new Object[] {
               BC00028_A5SupplierName
               }
               , new Object[] {
               BC00029_A4SupplierId
               }
               , new Object[] {
               BC000210_A4SupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000214_A57SupplierProductQuantity, BC000214_n57SupplierProductQuantity
               }
               , new Object[] {
               BC000215_A50PurchaseOrderId
               }
               , new Object[] {
               BC000216_A15ProductId
               }
               , new Object[] {
               BC000218_A4SupplierId, BC000218_A112SupplierActive, BC000218_A5SupplierName, BC000218_A6SupplierDescription, BC000218_n6SupplierDescription, BC000218_A7SupplierPhone, BC000218_n7SupplierPhone, BC000218_A8SupplierEmail, BC000218_n8SupplierEmail, BC000218_A32SupplierCreatedDate,
               BC000218_A33SupplierModifiedDate, BC000218_A57SupplierProductQuantity, BC000218_n57SupplierProductQuantity
               }
            }
         );
         AV12Pgmname = "Supplier_BC";
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z57SupplierProductQuantity ;
      private short A57SupplierProductQuantity ;
      private short Gx_BScreen ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private int Z4SupplierId ;
      private int A4SupplierId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV12Pgmname ;
      private string Z7SupplierPhone ;
      private string A7SupplierPhone ;
      private string sMode2 ;
      private DateTime Z32SupplierCreatedDate ;
      private DateTime A32SupplierCreatedDate ;
      private DateTime Z33SupplierModifiedDate ;
      private DateTime A33SupplierModifiedDate ;
      private DateTime Gx_date ;
      private DateTime N32SupplierCreatedDate ;
      private DateTime N33SupplierModifiedDate ;
      private bool returnInSub ;
      private bool Z112SupplierActive ;
      private bool A112SupplierActive ;
      private bool n6SupplierDescription ;
      private bool n7SupplierPhone ;
      private bool n8SupplierEmail ;
      private bool n57SupplierProductQuantity ;
      private bool Gx_longc ;
      private bool N112SupplierActive ;
      private bool mustCommit ;
      private string Z5SupplierName ;
      private string A5SupplierName ;
      private string Z6SupplierDescription ;
      private string A6SupplierDescription ;
      private string Z8SupplierEmail ;
      private string A8SupplierEmail ;
      private SdtSupplier bcSupplier ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00027_A4SupplierId ;
      private bool[] BC00027_A112SupplierActive ;
      private string[] BC00027_A5SupplierName ;
      private string[] BC00027_A6SupplierDescription ;
      private bool[] BC00027_n6SupplierDescription ;
      private string[] BC00027_A7SupplierPhone ;
      private bool[] BC00027_n7SupplierPhone ;
      private string[] BC00027_A8SupplierEmail ;
      private bool[] BC00027_n8SupplierEmail ;
      private DateTime[] BC00027_A32SupplierCreatedDate ;
      private DateTime[] BC00027_A33SupplierModifiedDate ;
      private short[] BC00027_A57SupplierProductQuantity ;
      private bool[] BC00027_n57SupplierProductQuantity ;
      private short[] BC00025_A57SupplierProductQuantity ;
      private bool[] BC00025_n57SupplierProductQuantity ;
      private string[] BC00028_A5SupplierName ;
      private int[] BC00029_A4SupplierId ;
      private int[] BC00023_A4SupplierId ;
      private bool[] BC00023_A112SupplierActive ;
      private string[] BC00023_A5SupplierName ;
      private string[] BC00023_A6SupplierDescription ;
      private bool[] BC00023_n6SupplierDescription ;
      private string[] BC00023_A7SupplierPhone ;
      private bool[] BC00023_n7SupplierPhone ;
      private string[] BC00023_A8SupplierEmail ;
      private bool[] BC00023_n8SupplierEmail ;
      private DateTime[] BC00023_A32SupplierCreatedDate ;
      private DateTime[] BC00023_A33SupplierModifiedDate ;
      private int[] BC00022_A4SupplierId ;
      private bool[] BC00022_A112SupplierActive ;
      private string[] BC00022_A5SupplierName ;
      private string[] BC00022_A6SupplierDescription ;
      private bool[] BC00022_n6SupplierDescription ;
      private string[] BC00022_A7SupplierPhone ;
      private bool[] BC00022_n7SupplierPhone ;
      private string[] BC00022_A8SupplierEmail ;
      private bool[] BC00022_n8SupplierEmail ;
      private DateTime[] BC00022_A32SupplierCreatedDate ;
      private DateTime[] BC00022_A33SupplierModifiedDate ;
      private int[] BC000210_A4SupplierId ;
      private short[] BC000214_A57SupplierProductQuantity ;
      private bool[] BC000214_n57SupplierProductQuantity ;
      private int[] BC000215_A50PurchaseOrderId ;
      private int[] BC000216_A15ProductId ;
      private int[] BC000218_A4SupplierId ;
      private bool[] BC000218_A112SupplierActive ;
      private string[] BC000218_A5SupplierName ;
      private string[] BC000218_A6SupplierDescription ;
      private bool[] BC000218_n6SupplierDescription ;
      private string[] BC000218_A7SupplierPhone ;
      private bool[] BC000218_n7SupplierPhone ;
      private string[] BC000218_A8SupplierEmail ;
      private bool[] BC000218_n8SupplierEmail ;
      private DateTime[] BC000218_A32SupplierCreatedDate ;
      private DateTime[] BC000218_A33SupplierModifiedDate ;
      private short[] BC000218_A57SupplierProductQuantity ;
      private bool[] BC000218_n57SupplierProductQuantity ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class supplier_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@SupplierName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@SupplierActive",GXType.Boolean,4,0) ,
          new ParDef("@SupplierName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SupplierPhone",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@SupplierEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SupplierCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierModifiedDate",GXType.Date,8,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@SupplierActive",GXType.Boolean,4,0) ,
          new ParDef("@SupplierName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SupplierPhone",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@SupplierEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SupplierCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierModifiedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [SupplierId], [SupplierActive], [SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate] FROM [Supplier] WITH (UPDLOCK) WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [SupplierId], [SupplierActive], [SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT COALESCE( T1.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T1 WHERE T1.[SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT TM1.[SupplierId], TM1.[SupplierActive], TM1.[SupplierName], TM1.[SupplierDescription], TM1.[SupplierPhone], TM1.[SupplierEmail], TM1.[SupplierCreatedDate], TM1.[SupplierModifiedDate], COALESCE( T2.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM ([Supplier] TM1 LEFT JOIN (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T2 ON T2.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[SupplierId] = @SupplierId ORDER BY TM1.[SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT [SupplierName] FROM [Supplier] WHERE ([SupplierName] = @SupplierName) AND (Not ( [SupplierId] = @SupplierId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "SELECT [SupplierId] FROM [Supplier] WHERE [SupplierId] = @SupplierId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000210", "INSERT INTO [Supplier]([SupplierActive], [SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate]) VALUES(@SupplierActive, @SupplierName, @SupplierDescription, @SupplierPhone, @SupplierEmail, @SupplierCreatedDate, @SupplierModifiedDate); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000211", "UPDATE [Supplier] SET [SupplierActive]=@SupplierActive, [SupplierName]=@SupplierName, [SupplierDescription]=@SupplierDescription, [SupplierPhone]=@SupplierPhone, [SupplierEmail]=@SupplierEmail, [SupplierCreatedDate]=@SupplierCreatedDate, [SupplierModifiedDate]=@SupplierModifiedDate  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmBC000211)
             ,new CursorDef("BC000212", "DELETE FROM [Supplier]  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmBC000212)
             ,new CursorDef("BC000214", "SELECT COALESCE( T1.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T1 WHERE T1.[SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000215", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000216", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000218", "SELECT TM1.[SupplierId], TM1.[SupplierActive], TM1.[SupplierName], TM1.[SupplierDescription], TM1.[SupplierPhone], TM1.[SupplierEmail], TM1.[SupplierCreatedDate], TM1.[SupplierModifiedDate], COALESCE( T2.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM ([Supplier] TM1 LEFT JOIN (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T2 ON T2.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[SupplierId] = @SupplierId ORDER BY TM1.[SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
