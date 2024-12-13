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
   public class permission_bc : GxSilentTrn, IGxSilentTrn
   {
      public permission_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public permission_bc( IGxContext context )
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
         ReadRow0D18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D18( ) ;
         standaloneModal( ) ;
         AddRow0D18( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z106PermissionId = A106PermissionId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D18( ) ;
            }
            else
            {
               CheckExtendedTable0D18( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0D18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "permission view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "permission insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "permission update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "permission delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0D18( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z107PermissionName = A107PermissionName;
         }
         if ( GX_JID == -1 )
         {
            Z106PermissionId = A106PermissionId;
            Z107PermissionName = A107PermissionName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0D18( )
      {
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound18 = 1;
            A107PermissionName = BC000D4_A107PermissionName[0];
            ZM0D18( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0D18( ) ;
      }

      protected void OnLoadActions0D18( )
      {
         AV13Pgmname = "Permission_BC";
      }

      protected void CheckExtendedTable0D18( )
      {
         nIsDirty_18 = 0;
         standaloneModal( ) ;
         AV13Pgmname = "Permission_BC";
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A107PermissionName, A106PermissionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Permission Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D18( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D18( )
      {
         /* Using cursor BC000D6 */
         pr_default.execute(4, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D18( 1) ;
            RcdFound18 = 1;
            A106PermissionId = BC000D3_A106PermissionId[0];
            A107PermissionName = BC000D3_A107PermissionName[0];
            Z106PermissionId = A106PermissionId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0D18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0D18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0D0( ) ;
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

      protected void CheckOptimisticConcurrency0D18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A106PermissionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Permission"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z107PermissionName, BC000D2_A107PermissionName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Permission"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D18( )
      {
         BeforeValidate0D18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D18( 0) ;
            CheckOptimisticConcurrency0D18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D7 */
                     pr_default.execute(5, new Object[] {A107PermissionName});
                     A106PermissionId = BC000D7_A106PermissionId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Permission");
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
               Load0D18( ) ;
            }
            EndLevel0D18( ) ;
         }
         CloseExtendedTableCursors0D18( ) ;
      }

      protected void Update0D18( )
      {
         BeforeValidate0D18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A107PermissionName, A106PermissionId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Permission");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Permission"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D18( ) ;
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
            EndLevel0D18( ) ;
         }
         CloseExtendedTableCursors0D18( ) ;
      }

      protected void DeferredUpdate0D18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D18( ) ;
            AfterConfirm0D18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D9 */
                  pr_default.execute(7, new Object[] {A106PermissionId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Permission");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0D18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Permission_BC";
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D10 */
            pr_default.execute(8, new Object[] {A106PermissionId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Permission"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel0D18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D18( ) ;
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

      public void ScanKeyStart0D18( )
      {
         /* Scan By routine */
         /* Using cursor BC000D11 */
         pr_default.execute(9, new Object[] {A106PermissionId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound18 = 1;
            A106PermissionId = BC000D11_A106PermissionId[0];
            A107PermissionName = BC000D11_A107PermissionName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D18( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound18 = 0;
         ScanKeyLoad0D18( ) ;
      }

      protected void ScanKeyLoad0D18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound18 = 1;
            A106PermissionId = BC000D11_A106PermissionId[0];
            A107PermissionName = BC000D11_A107PermissionName[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0D18( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0D18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D18( )
      {
      }

      protected void send_integrity_lvl_hashes0D18( )
      {
      }

      protected void AddRow0D18( )
      {
         VarsToRow18( bcPermission) ;
      }

      protected void ReadRow0D18( )
      {
         RowToVars18( bcPermission, 1) ;
      }

      protected void InitializeNonKey0D18( )
      {
         A107PermissionName = "";
         Z107PermissionName = "";
      }

      protected void InitAll0D18( )
      {
         A106PermissionId = 0;
         InitializeNonKey0D18( ) ;
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

      public void VarsToRow18( SdtPermission obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Permissionname = A107PermissionName;
         obj18.gxTpr_Permissionid = A106PermissionId;
         obj18.gxTpr_Permissionid_Z = Z106PermissionId;
         obj18.gxTpr_Permissionname_Z = Z107PermissionName;
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( SdtPermission obj18 )
      {
         obj18.gxTpr_Permissionid = A106PermissionId;
         return  ;
      }

      public void RowToVars18( SdtPermission obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A107PermissionName = obj18.gxTpr_Permissionname;
         A106PermissionId = obj18.gxTpr_Permissionid;
         Z106PermissionId = obj18.gxTpr_Permissionid_Z;
         Z107PermissionName = obj18.gxTpr_Permissionname_Z;
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A106PermissionId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D18( ) ;
         ScanKeyStart0D18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106PermissionId = A106PermissionId;
         }
         ZM0D18( -1) ;
         OnLoadActions0D18( ) ;
         AddRow0D18( ) ;
         ScanKeyEnd0D18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcPermission, 0) ;
         ScanKeyStart0D18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106PermissionId = A106PermissionId;
         }
         ZM0D18( -1) ;
         OnLoadActions0D18( ) ;
         AddRow0D18( ) ;
         ScanKeyEnd0D18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0D18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A106PermissionId != Z106PermissionId )
               {
                  A106PermissionId = Z106PermissionId;
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
                  Update0D18( ) ;
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
                  if ( A106PermissionId != Z106PermissionId )
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
                        Insert0D18( ) ;
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
                        Insert0D18( ) ;
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
         RowToVars18( bcPermission, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcPermission) ;
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
         RowToVars18( bcPermission, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcPermission) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow18( bcPermission) ;
         }
         else
         {
            SdtPermission auxBC = new SdtPermission(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A106PermissionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPermission);
               auxBC.Save();
               bcPermission.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars18( bcPermission, 1) ;
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
         RowToVars18( bcPermission, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D18( ) ;
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
               VarsToRow18( bcPermission) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow18( bcPermission) ;
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
         RowToVars18( bcPermission, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0D18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A106PermissionId != Z106PermissionId )
            {
               A106PermissionId = Z106PermissionId;
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
            if ( A106PermissionId != Z106PermissionId )
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
         context.RollbackDataStores("permission_bc",pr_default);
         VarsToRow18( bcPermission) ;
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
         Gx_mode = bcPermission.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPermission.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPermission )
         {
            bcPermission = (SdtPermission)(sdt);
            if ( StringUtil.StrCmp(bcPermission.gxTpr_Mode, "") == 0 )
            {
               bcPermission.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcPermission) ;
            }
            else
            {
               RowToVars18( bcPermission, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPermission.gxTpr_Mode, "") == 0 )
            {
               bcPermission.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcPermission, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPermission Permission_BC
      {
         get {
            return bcPermission ;
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
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV13Pgmname = "";
         Z107PermissionName = "";
         A107PermissionName = "";
         BC000D4_A106PermissionId = new int[1] ;
         BC000D4_A107PermissionName = new string[] {""} ;
         BC000D5_A107PermissionName = new string[] {""} ;
         BC000D6_A106PermissionId = new int[1] ;
         BC000D3_A106PermissionId = new int[1] ;
         BC000D3_A107PermissionName = new string[] {""} ;
         sMode18 = "";
         BC000D2_A106PermissionId = new int[1] ;
         BC000D2_A107PermissionName = new string[] {""} ;
         BC000D7_A106PermissionId = new int[1] ;
         BC000D10_A104RoleId = new int[1] ;
         BC000D10_A106PermissionId = new int[1] ;
         BC000D11_A106PermissionId = new int[1] ;
         BC000D11_A107PermissionName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.permission_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A106PermissionId, BC000D2_A107PermissionName
               }
               , new Object[] {
               BC000D3_A106PermissionId, BC000D3_A107PermissionName
               }
               , new Object[] {
               BC000D4_A106PermissionId, BC000D4_A107PermissionName
               }
               , new Object[] {
               BC000D5_A107PermissionName
               }
               , new Object[] {
               BC000D6_A106PermissionId
               }
               , new Object[] {
               BC000D7_A106PermissionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D10_A104RoleId, BC000D10_A106PermissionId
               }
               , new Object[] {
               BC000D11_A106PermissionId, BC000D11_A107PermissionName
               }
            }
         );
         AV13Pgmname = "Permission_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private int trnEnded ;
      private int Z106PermissionId ;
      private int A106PermissionId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV13Pgmname ;
      private string sMode18 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z107PermissionName ;
      private string A107PermissionName ;
      private SdtPermission bcPermission ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000D4_A106PermissionId ;
      private string[] BC000D4_A107PermissionName ;
      private string[] BC000D5_A107PermissionName ;
      private int[] BC000D6_A106PermissionId ;
      private int[] BC000D3_A106PermissionId ;
      private string[] BC000D3_A107PermissionName ;
      private int[] BC000D2_A106PermissionId ;
      private string[] BC000D2_A107PermissionName ;
      private int[] BC000D7_A106PermissionId ;
      private int[] BC000D10_A104RoleId ;
      private int[] BC000D10_A106PermissionId ;
      private int[] BC000D11_A106PermissionId ;
      private string[] BC000D11_A107PermissionName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class permission_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000D4;
          prmBC000D4 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D5;
          prmBC000D5 = new Object[] {
          new ParDef("@PermissionName",GXType.NVarChar,60,0) ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D6;
          prmBC000D6 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D3;
          prmBC000D3 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D2;
          prmBC000D2 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D7;
          prmBC000D7 = new Object[] {
          new ParDef("@PermissionName",GXType.NVarChar,60,0)
          };
          Object[] prmBC000D8;
          prmBC000D8 = new Object[] {
          new ParDef("@PermissionName",GXType.NVarChar,60,0) ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D9;
          prmBC000D9 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D10;
          prmBC000D10 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000D11;
          prmBC000D11 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000D2", "SELECT [PermissionId], [PermissionName] FROM [Permission] WITH (UPDLOCK) WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D3", "SELECT [PermissionId], [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D4", "SELECT TM1.[PermissionId], TM1.[PermissionName] FROM [Permission] TM1 WHERE TM1.[PermissionId] = @PermissionId ORDER BY TM1.[PermissionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D5", "SELECT [PermissionName] FROM [Permission] WHERE ([PermissionName] = @PermissionName) AND (Not ( [PermissionId] = @PermissionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D6", "SELECT [PermissionId] FROM [Permission] WHERE [PermissionId] = @PermissionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D7", "INSERT INTO [Permission]([PermissionName]) VALUES(@PermissionName); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000D8", "UPDATE [Permission] SET [PermissionName]=@PermissionName  WHERE [PermissionId] = @PermissionId", GxErrorMask.GX_NOMASK,prmBC000D8)
             ,new CursorDef("BC000D9", "DELETE FROM [Permission]  WHERE [PermissionId] = @PermissionId", GxErrorMask.GX_NOMASK,prmBC000D9)
             ,new CursorDef("BC000D10", "SELECT TOP 1 [RoleId], [PermissionId] FROM [RolePermission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000D11", "SELECT TM1.[PermissionId], TM1.[PermissionName] FROM [Permission] TM1 WHERE TM1.[PermissionId] = @PermissionId ORDER BY TM1.[PermissionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D11,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
