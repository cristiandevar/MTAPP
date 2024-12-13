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
   public class paymentmethod_bc : GxSilentTrn, IGxSilentTrn
   {
      public paymentmethod_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public paymentmethod_bc( IGxContext context )
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
         ReadRow0E20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E20( ) ;
         standaloneModal( ) ;
         AddRow0E20( ) ;
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
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z115PaymentMethodId = A115PaymentMethodId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E20( ) ;
            }
            else
            {
               CheckExtendedTable0E20( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0E20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E20( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z117PaymentMethodActive = A117PaymentMethodActive;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
         if ( GX_JID == -3 )
         {
            Z115PaymentMethodId = A115PaymentMethodId;
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z117PaymentMethodActive = A117PaymentMethodActive;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0E20( )
      {
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A116PaymentMethodDescription = BC000E4_A116PaymentMethodDescription[0];
            A117PaymentMethodActive = BC000E4_A117PaymentMethodActive[0];
            A129PaymentMethodDiscount = BC000E4_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000E4_A130PaymentMethodRecarge[0];
            ZM0E20( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0E20( ) ;
      }

      protected void OnLoadActions0E20( )
      {
      }

      protected void CheckExtendedTable0E20( )
      {
         nIsDirty_20 = 0;
         standaloneModal( ) ;
         if ( ! ( ( ( A129PaymentMethodDiscount >= Convert.ToDecimal( -999 )) && ( A129PaymentMethodDiscount <= Convert.ToDecimal( 999 )) ) ) )
         {
            GX_msglist.addItem("Field Payment Method Discount is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A130PaymentMethodRecarge >= Convert.ToDecimal( -999 )) && ( A130PaymentMethodRecarge <= Convert.ToDecimal( 999 )) ) ) )
         {
            GX_msglist.addItem("Field Payment Method Recarge is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0E20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E20( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E20( 3) ;
            RcdFound20 = 1;
            A115PaymentMethodId = BC000E3_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000E3_n115PaymentMethodId[0];
            A116PaymentMethodDescription = BC000E3_A116PaymentMethodDescription[0];
            A117PaymentMethodActive = BC000E3_A117PaymentMethodActive[0];
            A129PaymentMethodDiscount = BC000E3_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000E3_A130PaymentMethodRecarge[0];
            Z115PaymentMethodId = A115PaymentMethodId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0E20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0E20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0E0( ) ;
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

      protected void CheckOptimisticConcurrency0E20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaymentMethod"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z116PaymentMethodDescription, BC000E2_A116PaymentMethodDescription[0]) != 0 ) || ( Z117PaymentMethodActive != BC000E2_A117PaymentMethodActive[0] ) || ( Z129PaymentMethodDiscount != BC000E2_A129PaymentMethodDiscount[0] ) || ( Z130PaymentMethodRecarge != BC000E2_A130PaymentMethodRecarge[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PaymentMethod"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E20( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E20( 0) ;
            CheckOptimisticConcurrency0E20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E6 */
                     pr_default.execute(4, new Object[] {A116PaymentMethodDescription, A117PaymentMethodActive, A129PaymentMethodDiscount, A130PaymentMethodRecarge});
                     A115PaymentMethodId = BC000E6_A115PaymentMethodId[0];
                     n115PaymentMethodId = BC000E6_n115PaymentMethodId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
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
               Load0E20( ) ;
            }
            EndLevel0E20( ) ;
         }
         CloseExtendedTableCursors0E20( ) ;
      }

      protected void Update0E20( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E7 */
                     pr_default.execute(5, new Object[] {A116PaymentMethodDescription, A117PaymentMethodActive, A129PaymentMethodDiscount, A130PaymentMethodRecarge, n115PaymentMethodId, A115PaymentMethodId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaymentMethod"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E20( ) ;
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
            EndLevel0E20( ) ;
         }
         CloseExtendedTableCursors0E20( ) ;
      }

      protected void DeferredUpdate0E20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E20( ) ;
            AfterConfirm0E20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E8 */
                  pr_default.execute(6, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0E20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E9 */
            pr_default.execute(7, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Payment Method"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0E20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E20( ) ;
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

      public void ScanKeyStart0E20( )
      {
         /* Scan By routine */
         /* Using cursor BC000E10 */
         pr_default.execute(8, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound20 = 1;
            A115PaymentMethodId = BC000E10_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000E10_n115PaymentMethodId[0];
            A116PaymentMethodDescription = BC000E10_A116PaymentMethodDescription[0];
            A117PaymentMethodActive = BC000E10_A117PaymentMethodActive[0];
            A129PaymentMethodDiscount = BC000E10_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000E10_A130PaymentMethodRecarge[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E20( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound20 = 0;
         ScanKeyLoad0E20( ) ;
      }

      protected void ScanKeyLoad0E20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound20 = 1;
            A115PaymentMethodId = BC000E10_A115PaymentMethodId[0];
            n115PaymentMethodId = BC000E10_n115PaymentMethodId[0];
            A116PaymentMethodDescription = BC000E10_A116PaymentMethodDescription[0];
            A117PaymentMethodActive = BC000E10_A117PaymentMethodActive[0];
            A129PaymentMethodDiscount = BC000E10_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = BC000E10_A130PaymentMethodRecarge[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0E20( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0E20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E20( )
      {
      }

      protected void send_integrity_lvl_hashes0E20( )
      {
      }

      protected void AddRow0E20( )
      {
         VarsToRow20( bcPaymentMethod) ;
      }

      protected void ReadRow0E20( )
      {
         RowToVars20( bcPaymentMethod, 1) ;
      }

      protected void InitializeNonKey0E20( )
      {
         A116PaymentMethodDescription = "";
         A117PaymentMethodActive = false;
         A129PaymentMethodDiscount = 0;
         A130PaymentMethodRecarge = 0;
         Z116PaymentMethodDescription = "";
         Z117PaymentMethodActive = false;
         Z129PaymentMethodDiscount = 0;
         Z130PaymentMethodRecarge = 0;
      }

      protected void InitAll0E20( )
      {
         A115PaymentMethodId = 0;
         n115PaymentMethodId = false;
         InitializeNonKey0E20( ) ;
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

      public void VarsToRow20( SdtPaymentMethod obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Paymentmethoddescription = A116PaymentMethodDescription;
         obj20.gxTpr_Paymentmethodactive = A117PaymentMethodActive;
         obj20.gxTpr_Paymentmethoddiscount = A129PaymentMethodDiscount;
         obj20.gxTpr_Paymentmethodrecarge = A130PaymentMethodRecarge;
         obj20.gxTpr_Paymentmethodid = A115PaymentMethodId;
         obj20.gxTpr_Paymentmethodid_Z = Z115PaymentMethodId;
         obj20.gxTpr_Paymentmethoddescription_Z = Z116PaymentMethodDescription;
         obj20.gxTpr_Paymentmethodactive_Z = Z117PaymentMethodActive;
         obj20.gxTpr_Paymentmethoddiscount_Z = Z129PaymentMethodDiscount;
         obj20.gxTpr_Paymentmethodrecarge_Z = Z130PaymentMethodRecarge;
         obj20.gxTpr_Paymentmethodid_N = (short)(Convert.ToInt16(n115PaymentMethodId));
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( SdtPaymentMethod obj20 )
      {
         obj20.gxTpr_Paymentmethodid = A115PaymentMethodId;
         return  ;
      }

      public void RowToVars20( SdtPaymentMethod obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A116PaymentMethodDescription = obj20.gxTpr_Paymentmethoddescription;
         A117PaymentMethodActive = obj20.gxTpr_Paymentmethodactive;
         A129PaymentMethodDiscount = obj20.gxTpr_Paymentmethoddiscount;
         A130PaymentMethodRecarge = obj20.gxTpr_Paymentmethodrecarge;
         A115PaymentMethodId = obj20.gxTpr_Paymentmethodid;
         n115PaymentMethodId = false;
         Z115PaymentMethodId = obj20.gxTpr_Paymentmethodid_Z;
         Z116PaymentMethodDescription = obj20.gxTpr_Paymentmethoddescription_Z;
         Z117PaymentMethodActive = obj20.gxTpr_Paymentmethodactive_Z;
         Z129PaymentMethodDiscount = obj20.gxTpr_Paymentmethoddiscount_Z;
         Z130PaymentMethodRecarge = obj20.gxTpr_Paymentmethodrecarge_Z;
         n115PaymentMethodId = (bool)(Convert.ToBoolean(obj20.gxTpr_Paymentmethodid_N));
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A115PaymentMethodId = (int)getParm(obj,0);
         n115PaymentMethodId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E20( ) ;
         ScanKeyStart0E20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z115PaymentMethodId = A115PaymentMethodId;
         }
         ZM0E20( -3) ;
         OnLoadActions0E20( ) ;
         AddRow0E20( ) ;
         ScanKeyEnd0E20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bcPaymentMethod, 0) ;
         ScanKeyStart0E20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z115PaymentMethodId = A115PaymentMethodId;
         }
         ZM0E20( -3) ;
         OnLoadActions0E20( ) ;
         AddRow0E20( ) ;
         ScanKeyEnd0E20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0E20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A115PaymentMethodId != Z115PaymentMethodId )
               {
                  A115PaymentMethodId = Z115PaymentMethodId;
                  n115PaymentMethodId = false;
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
                  Update0E20( ) ;
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
                  if ( A115PaymentMethodId != Z115PaymentMethodId )
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
                        Insert0E20( ) ;
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
                        Insert0E20( ) ;
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
         RowToVars20( bcPaymentMethod, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bcPaymentMethod) ;
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
         RowToVars20( bcPaymentMethod, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bcPaymentMethod) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow20( bcPaymentMethod) ;
         }
         else
         {
            SdtPaymentMethod auxBC = new SdtPaymentMethod(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A115PaymentMethodId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPaymentMethod);
               auxBC.Save();
               bcPaymentMethod.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars20( bcPaymentMethod, 1) ;
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
         RowToVars20( bcPaymentMethod, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E20( ) ;
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
               VarsToRow20( bcPaymentMethod) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow20( bcPaymentMethod) ;
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
         RowToVars20( bcPaymentMethod, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0E20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A115PaymentMethodId != Z115PaymentMethodId )
            {
               A115PaymentMethodId = Z115PaymentMethodId;
               n115PaymentMethodId = false;
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
            if ( A115PaymentMethodId != Z115PaymentMethodId )
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
         context.RollbackDataStores("paymentmethod_bc",pr_default);
         VarsToRow20( bcPaymentMethod) ;
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
         Gx_mode = bcPaymentMethod.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPaymentMethod.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPaymentMethod )
         {
            bcPaymentMethod = (SdtPaymentMethod)(sdt);
            if ( StringUtil.StrCmp(bcPaymentMethod.gxTpr_Mode, "") == 0 )
            {
               bcPaymentMethod.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bcPaymentMethod) ;
            }
            else
            {
               RowToVars20( bcPaymentMethod, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPaymentMethod.gxTpr_Mode, "") == 0 )
            {
               bcPaymentMethod.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bcPaymentMethod, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPaymentMethod PaymentMethod_BC
      {
         get {
            return bcPaymentMethod ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z116PaymentMethodDescription = "";
         A116PaymentMethodDescription = "";
         BC000E4_A115PaymentMethodId = new int[1] ;
         BC000E4_n115PaymentMethodId = new bool[] {false} ;
         BC000E4_A116PaymentMethodDescription = new string[] {""} ;
         BC000E4_A117PaymentMethodActive = new bool[] {false} ;
         BC000E4_A129PaymentMethodDiscount = new decimal[1] ;
         BC000E4_A130PaymentMethodRecarge = new decimal[1] ;
         BC000E5_A115PaymentMethodId = new int[1] ;
         BC000E5_n115PaymentMethodId = new bool[] {false} ;
         BC000E3_A115PaymentMethodId = new int[1] ;
         BC000E3_n115PaymentMethodId = new bool[] {false} ;
         BC000E3_A116PaymentMethodDescription = new string[] {""} ;
         BC000E3_A117PaymentMethodActive = new bool[] {false} ;
         BC000E3_A129PaymentMethodDiscount = new decimal[1] ;
         BC000E3_A130PaymentMethodRecarge = new decimal[1] ;
         sMode20 = "";
         BC000E2_A115PaymentMethodId = new int[1] ;
         BC000E2_n115PaymentMethodId = new bool[] {false} ;
         BC000E2_A116PaymentMethodDescription = new string[] {""} ;
         BC000E2_A117PaymentMethodActive = new bool[] {false} ;
         BC000E2_A129PaymentMethodDiscount = new decimal[1] ;
         BC000E2_A130PaymentMethodRecarge = new decimal[1] ;
         BC000E6_A115PaymentMethodId = new int[1] ;
         BC000E6_n115PaymentMethodId = new bool[] {false} ;
         BC000E9_A20InvoiceId = new int[1] ;
         BC000E9_A118InvoicePaymentMethodId = new int[1] ;
         BC000E10_A115PaymentMethodId = new int[1] ;
         BC000E10_n115PaymentMethodId = new bool[] {false} ;
         BC000E10_A116PaymentMethodDescription = new string[] {""} ;
         BC000E10_A117PaymentMethodActive = new bool[] {false} ;
         BC000E10_A129PaymentMethodDiscount = new decimal[1] ;
         BC000E10_A130PaymentMethodRecarge = new decimal[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paymentmethod_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A115PaymentMethodId, BC000E2_A116PaymentMethodDescription, BC000E2_A117PaymentMethodActive, BC000E2_A129PaymentMethodDiscount, BC000E2_A130PaymentMethodRecarge
               }
               , new Object[] {
               BC000E3_A115PaymentMethodId, BC000E3_A116PaymentMethodDescription, BC000E3_A117PaymentMethodActive, BC000E3_A129PaymentMethodDiscount, BC000E3_A130PaymentMethodRecarge
               }
               , new Object[] {
               BC000E4_A115PaymentMethodId, BC000E4_A116PaymentMethodDescription, BC000E4_A117PaymentMethodActive, BC000E4_A129PaymentMethodDiscount, BC000E4_A130PaymentMethodRecarge
               }
               , new Object[] {
               BC000E5_A115PaymentMethodId
               }
               , new Object[] {
               BC000E6_A115PaymentMethodId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A20InvoiceId, BC000E9_A118InvoicePaymentMethodId
               }
               , new Object[] {
               BC000E10_A115PaymentMethodId, BC000E10_A116PaymentMethodDescription, BC000E10_A117PaymentMethodActive, BC000E10_A129PaymentMethodDiscount, BC000E10_A130PaymentMethodRecarge
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private int trnEnded ;
      private int Z115PaymentMethodId ;
      private int A115PaymentMethodId ;
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
      private string sMode20 ;
      private bool returnInSub ;
      private bool Z117PaymentMethodActive ;
      private bool A117PaymentMethodActive ;
      private bool n115PaymentMethodId ;
      private bool mustCommit ;
      private string Z116PaymentMethodDescription ;
      private string A116PaymentMethodDescription ;
      private SdtPaymentMethod bcPaymentMethod ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000E4_A115PaymentMethodId ;
      private bool[] BC000E4_n115PaymentMethodId ;
      private string[] BC000E4_A116PaymentMethodDescription ;
      private bool[] BC000E4_A117PaymentMethodActive ;
      private decimal[] BC000E4_A129PaymentMethodDiscount ;
      private decimal[] BC000E4_A130PaymentMethodRecarge ;
      private int[] BC000E5_A115PaymentMethodId ;
      private bool[] BC000E5_n115PaymentMethodId ;
      private int[] BC000E3_A115PaymentMethodId ;
      private bool[] BC000E3_n115PaymentMethodId ;
      private string[] BC000E3_A116PaymentMethodDescription ;
      private bool[] BC000E3_A117PaymentMethodActive ;
      private decimal[] BC000E3_A129PaymentMethodDiscount ;
      private decimal[] BC000E3_A130PaymentMethodRecarge ;
      private int[] BC000E2_A115PaymentMethodId ;
      private bool[] BC000E2_n115PaymentMethodId ;
      private string[] BC000E2_A116PaymentMethodDescription ;
      private bool[] BC000E2_A117PaymentMethodActive ;
      private decimal[] BC000E2_A129PaymentMethodDiscount ;
      private decimal[] BC000E2_A130PaymentMethodRecarge ;
      private int[] BC000E6_A115PaymentMethodId ;
      private bool[] BC000E6_n115PaymentMethodId ;
      private int[] BC000E9_A20InvoiceId ;
      private int[] BC000E9_A118InvoicePaymentMethodId ;
      private int[] BC000E10_A115PaymentMethodId ;
      private bool[] BC000E10_n115PaymentMethodId ;
      private string[] BC000E10_A116PaymentMethodDescription ;
      private bool[] BC000E10_A117PaymentMethodActive ;
      private decimal[] BC000E10_A129PaymentMethodDiscount ;
      private decimal[] BC000E10_A130PaymentMethodRecarge ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class paymentmethod_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000E4;
          prmBC000E4 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E5;
          prmBC000E5 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E3;
          prmBC000E3 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E2;
          prmBC000E2 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E6;
          prmBC000E6 = new Object[] {
          new ParDef("@PaymentMethodDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@PaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodRecarge",GXType.Decimal,8,2)
          };
          Object[] prmBC000E7;
          prmBC000E7 = new Object[] {
          new ParDef("@PaymentMethodDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@PaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodRecarge",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E8;
          prmBC000E8 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E9;
          prmBC000E9 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000E10;
          prmBC000E10 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000E2", "SELECT [PaymentMethodId], [PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WITH (UPDLOCK) WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E3", "SELECT [PaymentMethodId], [PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E4", "SELECT TM1.[PaymentMethodId], TM1.[PaymentMethodDescription], TM1.[PaymentMethodActive], TM1.[PaymentMethodDiscount], TM1.[PaymentMethodRecarge] FROM [PaymentMethod] TM1 WHERE TM1.[PaymentMethodId] = @PaymentMethodId ORDER BY TM1.[PaymentMethodId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E5", "SELECT [PaymentMethodId] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000E6", "INSERT INTO [PaymentMethod]([PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge]) VALUES(@PaymentMethodDescription, @PaymentMethodActive, @PaymentMethodDiscount, @PaymentMethodRecarge); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000E7", "UPDATE [PaymentMethod] SET [PaymentMethodDescription]=@PaymentMethodDescription, [PaymentMethodActive]=@PaymentMethodActive, [PaymentMethodDiscount]=@PaymentMethodDiscount, [PaymentMethodRecarge]=@PaymentMethodRecarge  WHERE [PaymentMethodId] = @PaymentMethodId", GxErrorMask.GX_NOMASK,prmBC000E7)
             ,new CursorDef("BC000E8", "DELETE FROM [PaymentMethod]  WHERE [PaymentMethodId] = @PaymentMethodId", GxErrorMask.GX_NOMASK,prmBC000E8)
             ,new CursorDef("BC000E9", "SELECT TOP 1 [InvoiceId], [InvoicePaymentMethodId] FROM [InvoicePaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000E10", "SELECT TM1.[PaymentMethodId], TM1.[PaymentMethodDescription], TM1.[PaymentMethodActive], TM1.[PaymentMethodDiscount], TM1.[PaymentMethodRecarge] FROM [PaymentMethod] TM1 WHERE TM1.[PaymentMethodId] = @PaymentMethodId ORDER BY TM1.[PaymentMethodId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E10,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
       }
    }

 }

}
