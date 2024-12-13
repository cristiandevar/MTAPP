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
   public class historyofdircardedproducts_bc : GxSilentTrn, IGxSilentTrn
   {
      public historyofdircardedproducts_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public historyofdircardedproducts_bc( IGxContext context )
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
         ReadRow0B15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B15( ) ;
         standaloneModal( ) ;
         AddRow0B15( ) ;
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
            E110B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B15( ) ;
            }
            else
            {
               CheckExtendedTable0B15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B15( 5) ;
               }
               CloseExtendedTableCursors0B15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120B2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0B15( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z82HistoryOfDircardedProductsDesc = A82HistoryOfDircardedProductsDesc;
            Z83HistoryOfDircardedProductsDate = A83HistoryOfDircardedProductsDate;
            Z84HistoryOfDircardedProductsQuan = A84HistoryOfDircardedProductsQuan;
            Z15ProductId = A15ProductId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
         if ( GX_JID == -4 )
         {
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
            Z82HistoryOfDircardedProductsDesc = A82HistoryOfDircardedProductsDesc;
            Z83HistoryOfDircardedProductsDate = A83HistoryOfDircardedProductsDate;
            Z84HistoryOfDircardedProductsQuan = A84HistoryOfDircardedProductsQuan;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A83HistoryOfDircardedProductsDate) && ( Gx_BScreen == 0 ) )
         {
            A83HistoryOfDircardedProductsDate = Gx_date;
         }
      }

      protected void Load0B15( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
            A16ProductName = BC000B5_A16ProductName[0];
            A17ProductStock = BC000B5_A17ProductStock[0];
            A82HistoryOfDircardedProductsDesc = BC000B5_A82HistoryOfDircardedProductsDesc[0];
            A83HistoryOfDircardedProductsDate = BC000B5_A83HistoryOfDircardedProductsDate[0];
            A84HistoryOfDircardedProductsQuan = BC000B5_A84HistoryOfDircardedProductsQuan[0];
            A15ProductId = BC000B5_A15ProductId[0];
            ZM0B15( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0B15( ) ;
      }

      protected void OnLoadActions0B15( )
      {
      }

      protected void CheckExtendedTable0B15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
         }
         A16ProductName = BC000B4_A16ProductName[0];
         A17ProductStock = BC000B4_A17ProductStock[0];
         pr_default.close(2);
         if ( ( A84HistoryOfDircardedProductsQuan <= 0 ) || ( A84HistoryOfDircardedProductsQuan > A17ProductStock ) )
         {
            GX_msglist.addItem("Quantity Invalid", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A82HistoryOfDircardedProductsDesc)) )
         {
            GX_msglist.addItem("Must be have a description", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0B15( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B15( )
      {
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B15( 4) ;
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = BC000B3_A81HistoryOfDircardedProductsId[0];
            A82HistoryOfDircardedProductsDesc = BC000B3_A82HistoryOfDircardedProductsDesc[0];
            A83HistoryOfDircardedProductsDate = BC000B3_A83HistoryOfDircardedProductsDate[0];
            A84HistoryOfDircardedProductsQuan = BC000B3_A84HistoryOfDircardedProductsQuan[0];
            A15ProductId = BC000B3_A15ProductId[0];
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0B15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0B15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0B0( ) ;
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

      protected void CheckOptimisticConcurrency0B15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A81HistoryOfDircardedProductsId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoryOfDircardedProducts"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z82HistoryOfDircardedProductsDesc, BC000B2_A82HistoryOfDircardedProductsDesc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z83HistoryOfDircardedProductsDate ) != DateTimeUtil.ResetTime ( BC000B2_A83HistoryOfDircardedProductsDate[0] ) ) || ( Z84HistoryOfDircardedProductsQuan != BC000B2_A84HistoryOfDircardedProductsQuan[0] ) || ( Z15ProductId != BC000B2_A15ProductId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoryOfDircardedProducts"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B15( 0) ;
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A82HistoryOfDircardedProductsDesc, A83HistoryOfDircardedProductsDate, A84HistoryOfDircardedProductsQuan, A15ProductId});
                     A81HistoryOfDircardedProductsId = BC000B7_A81HistoryOfDircardedProductsId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
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
               Load0B15( ) ;
            }
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void Update0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B8 */
                     pr_default.execute(6, new Object[] {A82HistoryOfDircardedProductsDesc, A83HistoryOfDircardedProductsDate, A84HistoryOfDircardedProductsQuan, A15ProductId, A81HistoryOfDircardedProductsId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoryOfDircardedProducts"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B15( ) ;
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
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void DeferredUpdate0B15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B15( ) ;
            AfterConfirm0B15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B9 */
                  pr_default.execute(7, new Object[] {A81HistoryOfDircardedProductsId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0B15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000B10 */
            pr_default.execute(8, new Object[] {A15ProductId});
            A16ProductName = BC000B10_A16ProductName[0];
            A17ProductStock = BC000B10_A17ProductStock[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel0B15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B15( ) ;
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

      public void ScanKeyStart0B15( )
      {
         /* Scan By routine */
         /* Using cursor BC000B11 */
         pr_default.execute(9, new Object[] {A81HistoryOfDircardedProductsId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = BC000B11_A81HistoryOfDircardedProductsId[0];
            A16ProductName = BC000B11_A16ProductName[0];
            A17ProductStock = BC000B11_A17ProductStock[0];
            A82HistoryOfDircardedProductsDesc = BC000B11_A82HistoryOfDircardedProductsDesc[0];
            A83HistoryOfDircardedProductsDate = BC000B11_A83HistoryOfDircardedProductsDate[0];
            A84HistoryOfDircardedProductsQuan = BC000B11_A84HistoryOfDircardedProductsQuan[0];
            A15ProductId = BC000B11_A15ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B15( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound15 = 0;
         ScanKeyLoad0B15( ) ;
      }

      protected void ScanKeyLoad0B15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = BC000B11_A81HistoryOfDircardedProductsId[0];
            A16ProductName = BC000B11_A16ProductName[0];
            A17ProductStock = BC000B11_A17ProductStock[0];
            A82HistoryOfDircardedProductsDesc = BC000B11_A82HistoryOfDircardedProductsDesc[0];
            A83HistoryOfDircardedProductsDate = BC000B11_A83HistoryOfDircardedProductsDate[0];
            A84HistoryOfDircardedProductsQuan = BC000B11_A84HistoryOfDircardedProductsQuan[0];
            A15ProductId = BC000B11_A15ProductId[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0B15( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0B15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B15( )
      {
      }

      protected void send_integrity_lvl_hashes0B15( )
      {
      }

      protected void AddRow0B15( )
      {
         VarsToRow15( bcHistoryOfDircardedProducts) ;
      }

      protected void ReadRow0B15( )
      {
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
      }

      protected void InitializeNonKey0B15( )
      {
         A15ProductId = 0;
         A16ProductName = "";
         A17ProductStock = 0;
         A82HistoryOfDircardedProductsDesc = "";
         A84HistoryOfDircardedProductsQuan = 0;
         A83HistoryOfDircardedProductsDate = Gx_date;
         Z82HistoryOfDircardedProductsDesc = "";
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
         Z84HistoryOfDircardedProductsQuan = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0B15( )
      {
         A81HistoryOfDircardedProductsId = 0;
         InitializeNonKey0B15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A83HistoryOfDircardedProductsDate = i83HistoryOfDircardedProductsDate;
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

      public void VarsToRow15( SdtHistoryOfDircardedProducts obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Productid = A15ProductId;
         obj15.gxTpr_Productname = A16ProductName;
         obj15.gxTpr_Productstock = A17ProductStock;
         obj15.gxTpr_Historyofdircardedproductsdescription = A82HistoryOfDircardedProductsDesc;
         obj15.gxTpr_Historyofdircardedproductsquantity = A84HistoryOfDircardedProductsQuan;
         obj15.gxTpr_Historyofdircardedproductsdate = A83HistoryOfDircardedProductsDate;
         obj15.gxTpr_Historyofdircardedproductsid = A81HistoryOfDircardedProductsId;
         obj15.gxTpr_Historyofdircardedproductsid_Z = Z81HistoryOfDircardedProductsId;
         obj15.gxTpr_Productid_Z = Z15ProductId;
         obj15.gxTpr_Productname_Z = Z16ProductName;
         obj15.gxTpr_Productstock_Z = Z17ProductStock;
         obj15.gxTpr_Historyofdircardedproductsdescription_Z = Z82HistoryOfDircardedProductsDesc;
         obj15.gxTpr_Historyofdircardedproductsdate_Z = Z83HistoryOfDircardedProductsDate;
         obj15.gxTpr_Historyofdircardedproductsquantity_Z = Z84HistoryOfDircardedProductsQuan;
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtHistoryOfDircardedProducts obj15 )
      {
         obj15.gxTpr_Historyofdircardedproductsid = A81HistoryOfDircardedProductsId;
         return  ;
      }

      public void RowToVars15( SdtHistoryOfDircardedProducts obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A15ProductId = obj15.gxTpr_Productid;
         A16ProductName = obj15.gxTpr_Productname;
         A17ProductStock = obj15.gxTpr_Productstock;
         A82HistoryOfDircardedProductsDesc = obj15.gxTpr_Historyofdircardedproductsdescription;
         A84HistoryOfDircardedProductsQuan = obj15.gxTpr_Historyofdircardedproductsquantity;
         if ( forceLoad == 1 )
         {
            A83HistoryOfDircardedProductsDate = obj15.gxTpr_Historyofdircardedproductsdate;
         }
         A81HistoryOfDircardedProductsId = obj15.gxTpr_Historyofdircardedproductsid;
         Z81HistoryOfDircardedProductsId = obj15.gxTpr_Historyofdircardedproductsid_Z;
         Z15ProductId = obj15.gxTpr_Productid_Z;
         Z16ProductName = obj15.gxTpr_Productname_Z;
         Z17ProductStock = obj15.gxTpr_Productstock_Z;
         Z82HistoryOfDircardedProductsDesc = obj15.gxTpr_Historyofdircardedproductsdescription_Z;
         Z83HistoryOfDircardedProductsDate = obj15.gxTpr_Historyofdircardedproductsdate_Z;
         Z84HistoryOfDircardedProductsQuan = obj15.gxTpr_Historyofdircardedproductsquantity_Z;
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A81HistoryOfDircardedProductsId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B15( ) ;
         ScanKeyStart0B15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
         }
         ZM0B15( -4) ;
         OnLoadActions0B15( ) ;
         AddRow0B15( ) ;
         ScanKeyEnd0B15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcHistoryOfDircardedProducts, 0) ;
         ScanKeyStart0B15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
         }
         ZM0B15( -4) ;
         OnLoadActions0B15( ) ;
         AddRow0B15( ) ;
         ScanKeyEnd0B15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0B15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
               {
                  A81HistoryOfDircardedProductsId = Z81HistoryOfDircardedProductsId;
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
                  Update0B15( ) ;
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
                  if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
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
                        Insert0B15( ) ;
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
                        Insert0B15( ) ;
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
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcHistoryOfDircardedProducts) ;
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
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcHistoryOfDircardedProducts) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcHistoryOfDircardedProducts) ;
         }
         else
         {
            SdtHistoryOfDircardedProducts auxBC = new SdtHistoryOfDircardedProducts(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A81HistoryOfDircardedProductsId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcHistoryOfDircardedProducts);
               auxBC.Save();
               bcHistoryOfDircardedProducts.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
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
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B15( ) ;
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
               VarsToRow15( bcHistoryOfDircardedProducts) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcHistoryOfDircardedProducts) ;
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
         RowToVars15( bcHistoryOfDircardedProducts, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0B15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
            {
               A81HistoryOfDircardedProductsId = Z81HistoryOfDircardedProductsId;
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
            if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
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
         pr_default.close(8);
         context.RollbackDataStores("historyofdircardedproducts_bc",pr_default);
         VarsToRow15( bcHistoryOfDircardedProducts) ;
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
         Gx_mode = bcHistoryOfDircardedProducts.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcHistoryOfDircardedProducts.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcHistoryOfDircardedProducts )
         {
            bcHistoryOfDircardedProducts = (SdtHistoryOfDircardedProducts)(sdt);
            if ( StringUtil.StrCmp(bcHistoryOfDircardedProducts.gxTpr_Mode, "") == 0 )
            {
               bcHistoryOfDircardedProducts.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcHistoryOfDircardedProducts) ;
            }
            else
            {
               RowToVars15( bcHistoryOfDircardedProducts, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcHistoryOfDircardedProducts.gxTpr_Mode, "") == 0 )
            {
               bcHistoryOfDircardedProducts.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcHistoryOfDircardedProducts, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtHistoryOfDircardedProducts HistoryOfDircardedProducts_BC
      {
         get {
            return bcHistoryOfDircardedProducts ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z82HistoryOfDircardedProductsDesc = "";
         A82HistoryOfDircardedProductsDesc = "";
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
         A83HistoryOfDircardedProductsDate = DateTime.MinValue;
         Z16ProductName = "";
         A16ProductName = "";
         Gx_date = DateTime.MinValue;
         BC000B5_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B5_A16ProductName = new string[] {""} ;
         BC000B5_A17ProductStock = new int[1] ;
         BC000B5_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         BC000B5_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         BC000B5_A84HistoryOfDircardedProductsQuan = new short[1] ;
         BC000B5_A15ProductId = new int[1] ;
         BC000B4_A16ProductName = new string[] {""} ;
         BC000B4_A17ProductStock = new int[1] ;
         BC000B6_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B3_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B3_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         BC000B3_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A84HistoryOfDircardedProductsQuan = new short[1] ;
         BC000B3_A15ProductId = new int[1] ;
         sMode15 = "";
         BC000B2_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B2_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         BC000B2_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A84HistoryOfDircardedProductsQuan = new short[1] ;
         BC000B2_A15ProductId = new int[1] ;
         BC000B7_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B10_A16ProductName = new string[] {""} ;
         BC000B10_A17ProductStock = new int[1] ;
         BC000B11_A81HistoryOfDircardedProductsId = new int[1] ;
         BC000B11_A16ProductName = new string[] {""} ;
         BC000B11_A17ProductStock = new int[1] ;
         BC000B11_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         BC000B11_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         BC000B11_A84HistoryOfDircardedProductsQuan = new short[1] ;
         BC000B11_A15ProductId = new int[1] ;
         i83HistoryOfDircardedProductsDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historyofdircardedproducts_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A81HistoryOfDircardedProductsId, BC000B2_A82HistoryOfDircardedProductsDesc, BC000B2_A83HistoryOfDircardedProductsDate, BC000B2_A84HistoryOfDircardedProductsQuan, BC000B2_A15ProductId
               }
               , new Object[] {
               BC000B3_A81HistoryOfDircardedProductsId, BC000B3_A82HistoryOfDircardedProductsDesc, BC000B3_A83HistoryOfDircardedProductsDate, BC000B3_A84HistoryOfDircardedProductsQuan, BC000B3_A15ProductId
               }
               , new Object[] {
               BC000B4_A16ProductName, BC000B4_A17ProductStock
               }
               , new Object[] {
               BC000B5_A81HistoryOfDircardedProductsId, BC000B5_A16ProductName, BC000B5_A17ProductStock, BC000B5_A82HistoryOfDircardedProductsDesc, BC000B5_A83HistoryOfDircardedProductsDate, BC000B5_A84HistoryOfDircardedProductsQuan, BC000B5_A15ProductId
               }
               , new Object[] {
               BC000B6_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               BC000B7_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B10_A16ProductName, BC000B10_A17ProductStock
               }
               , new Object[] {
               BC000B11_A81HistoryOfDircardedProductsId, BC000B11_A16ProductName, BC000B11_A17ProductStock, BC000B11_A82HistoryOfDircardedProductsDesc, BC000B11_A83HistoryOfDircardedProductsDate, BC000B11_A84HistoryOfDircardedProductsQuan, BC000B11_A15ProductId
               }
            }
         );
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
         A83HistoryOfDircardedProductsDate = DateTime.MinValue;
         i83HistoryOfDircardedProductsDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120B2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z84HistoryOfDircardedProductsQuan ;
      private short A84HistoryOfDircardedProductsQuan ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private int trnEnded ;
      private int Z81HistoryOfDircardedProductsId ;
      private int A81HistoryOfDircardedProductsId ;
      private int Z15ProductId ;
      private int A15ProductId ;
      private int Z17ProductStock ;
      private int A17ProductStock ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode15 ;
      private DateTime Z83HistoryOfDircardedProductsDate ;
      private DateTime A83HistoryOfDircardedProductsDate ;
      private DateTime Gx_date ;
      private DateTime i83HistoryOfDircardedProductsDate ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z82HistoryOfDircardedProductsDesc ;
      private string A82HistoryOfDircardedProductsDesc ;
      private string Z16ProductName ;
      private string A16ProductName ;
      private SdtHistoryOfDircardedProducts bcHistoryOfDircardedProducts ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000B5_A81HistoryOfDircardedProductsId ;
      private string[] BC000B5_A16ProductName ;
      private int[] BC000B5_A17ProductStock ;
      private string[] BC000B5_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] BC000B5_A83HistoryOfDircardedProductsDate ;
      private short[] BC000B5_A84HistoryOfDircardedProductsQuan ;
      private int[] BC000B5_A15ProductId ;
      private string[] BC000B4_A16ProductName ;
      private int[] BC000B4_A17ProductStock ;
      private int[] BC000B6_A81HistoryOfDircardedProductsId ;
      private int[] BC000B3_A81HistoryOfDircardedProductsId ;
      private string[] BC000B3_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] BC000B3_A83HistoryOfDircardedProductsDate ;
      private short[] BC000B3_A84HistoryOfDircardedProductsQuan ;
      private int[] BC000B3_A15ProductId ;
      private int[] BC000B2_A81HistoryOfDircardedProductsId ;
      private string[] BC000B2_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] BC000B2_A83HistoryOfDircardedProductsDate ;
      private short[] BC000B2_A84HistoryOfDircardedProductsQuan ;
      private int[] BC000B2_A15ProductId ;
      private int[] BC000B7_A81HistoryOfDircardedProductsId ;
      private string[] BC000B10_A16ProductName ;
      private int[] BC000B10_A17ProductStock ;
      private int[] BC000B11_A81HistoryOfDircardedProductsId ;
      private string[] BC000B11_A16ProductName ;
      private int[] BC000B11_A17ProductStock ;
      private string[] BC000B11_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] BC000B11_A83HistoryOfDircardedProductsDate ;
      private short[] BC000B11_A84HistoryOfDircardedProductsQuan ;
      private int[] BC000B11_A15ProductId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historyofdircardedproducts_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000B5;
          prmBC000B5 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B4;
          prmBC000B4 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000B6;
          prmBC000B6 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B3;
          prmBC000B3 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B2;
          prmBC000B2 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B7;
          prmBC000B7 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsDesc",GXType.NVarChar,200,0) ,
          new ParDef("@HistoryOfDircardedProductsDate",GXType.Date,8,0) ,
          new ParDef("@HistoryOfDircardedProductsQuan",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000B8;
          prmBC000B8 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsDesc",GXType.NVarChar,200,0) ,
          new ParDef("@HistoryOfDircardedProductsDate",GXType.Date,8,0) ,
          new ParDef("@HistoryOfDircardedProductsQuan",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B9;
          prmBC000B9 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmBC000B10;
          prmBC000B10 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000B11;
          prmBC000B11 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000B2", "SELECT [HistoryOfDircardedProductsId], [HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId] FROM [HistoryOfDircardedProducts] WITH (UPDLOCK) WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B3", "SELECT [HistoryOfDircardedProductsId], [HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId] FROM [HistoryOfDircardedProducts] WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B4", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B5", "SELECT TM1.[HistoryOfDircardedProductsId], T2.[ProductName], T2.[ProductStock], TM1.[HistoryOfDircardedProductsDesc], TM1.[HistoryOfDircardedProductsDate], TM1.[HistoryOfDircardedProductsQuan], TM1.[ProductId] FROM ([HistoryOfDircardedProducts] TM1 INNER JOIN [Product] T2 ON T2.[ProductId] = TM1.[ProductId]) WHERE TM1.[HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ORDER BY TM1.[HistoryOfDircardedProductsId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B6", "SELECT [HistoryOfDircardedProductsId] FROM [HistoryOfDircardedProducts] WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B7", "INSERT INTO [HistoryOfDircardedProducts]([HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId]) VALUES(@HistoryOfDircardedProductsDesc, @HistoryOfDircardedProductsDate, @HistoryOfDircardedProductsQuan, @ProductId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000B8", "UPDATE [HistoryOfDircardedProducts] SET [HistoryOfDircardedProductsDesc]=@HistoryOfDircardedProductsDesc, [HistoryOfDircardedProductsDate]=@HistoryOfDircardedProductsDate, [HistoryOfDircardedProductsQuan]=@HistoryOfDircardedProductsQuan, [ProductId]=@ProductId  WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId", GxErrorMask.GX_NOMASK,prmBC000B8)
             ,new CursorDef("BC000B9", "DELETE FROM [HistoryOfDircardedProducts]  WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId", GxErrorMask.GX_NOMASK,prmBC000B9)
             ,new CursorDef("BC000B10", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000B11", "SELECT TM1.[HistoryOfDircardedProductsId], T2.[ProductName], T2.[ProductStock], TM1.[HistoryOfDircardedProductsDesc], TM1.[HistoryOfDircardedProductsDate], TM1.[HistoryOfDircardedProductsQuan], TM1.[ProductId] FROM ([HistoryOfDircardedProducts] TM1 INNER JOIN [Product] T2 ON T2.[ProductId] = TM1.[ProductId]) WHERE TM1.[HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ORDER BY TM1.[HistoryOfDircardedProductsId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B11,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
