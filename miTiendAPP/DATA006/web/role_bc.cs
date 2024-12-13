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
   public class role_bc : GxSilentTrn, IGxSilentTrn
   {
      public role_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public role_bc( IGxContext context )
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
         ReadRow0C17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C17( ) ;
         standaloneModal( ) ;
         AddRow0C17( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z104RoleId = A104RoleId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C17( ) ;
            }
            else
            {
               CheckExtendedTable0C17( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode17 = Gx_mode;
            CONFIRM_0C19( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode17;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode17;
         }
      }

      protected void CONFIRM_0C19( )
      {
         nGXsfl_19_idx = 0;
         while ( nGXsfl_19_idx < bcRole.gxTpr_Permission.Count )
         {
            ReadRow0C19( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound19 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_19 != 0 ) )
            {
               GetKey0C19( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound19 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0C19( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0C19( 4) ;
                        }
                        CloseExtendedTableCursors0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
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
                  if ( RcdFound19 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0C19( ) ;
                        Load0C19( ) ;
                        BeforeValidate0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0C19( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_19 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0C19( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0C19( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0C19( 4) ;
                              }
                              CloseExtendedTableCursors0C19( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
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
               VarsToRow19( ((SdtRole_Permission)bcRole.gxTpr_Permission.Item(nGXsfl_19_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new haspermission(context).executeUdp(  "permission view") )
         {
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "role view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "role insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "role update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "role delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0C17( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z105RoleName = A105RoleName;
         }
         if ( GX_JID == -1 )
         {
            Z104RoleId = A104RoleId;
            Z105RoleName = A105RoleName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C17( )
      {
         /* Using cursor BC000C7 */
         pr_default.execute(5, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A105RoleName = BC000C7_A105RoleName[0];
            ZM0C17( -1) ;
         }
         pr_default.close(5);
         OnLoadActions0C17( ) ;
      }

      protected void OnLoadActions0C17( )
      {
         AV13Pgmname = "Role_BC";
      }

      protected void CheckExtendedTable0C17( )
      {
         nIsDirty_17 = 0;
         standaloneModal( ) ;
         AV13Pgmname = "Role_BC";
         /* Using cursor BC000C8 */
         pr_default.execute(6, new Object[] {A105RoleName, n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Role Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0C17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C17( )
      {
         /* Using cursor BC000C9 */
         pr_default.execute(7, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0C17( 1) ;
            RcdFound17 = 1;
            A104RoleId = BC000C6_A104RoleId[0];
            n104RoleId = BC000C6_n104RoleId[0];
            A105RoleName = BC000C6_A105RoleName[0];
            Z104RoleId = A104RoleId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0C17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0C17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0C0( ) ;
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

      protected void CheckOptimisticConcurrency0C17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C5 */
            pr_default.execute(3, new Object[] {n104RoleId, A104RoleId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Role"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z105RoleName, BC000C5_A105RoleName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Role"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C17( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C17( 0) ;
            CheckOptimisticConcurrency0C17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C10 */
                     pr_default.execute(8, new Object[] {A105RoleName});
                     A104RoleId = BC000C10_A104RoleId[0];
                     n104RoleId = BC000C10_n104RoleId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C17( ) ;
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
               Load0C17( ) ;
            }
            EndLevel0C17( ) ;
         }
         CloseExtendedTableCursors0C17( ) ;
      }

      protected void Update0C17( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C11 */
                     pr_default.execute(9, new Object[] {A105RoleName, n104RoleId, A104RoleId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Role"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C17( ) ;
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
            EndLevel0C17( ) ;
         }
         CloseExtendedTableCursors0C17( ) ;
      }

      protected void DeferredUpdate0C17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C17( ) ;
            AfterConfirm0C17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C17( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0C19( ) ;
                  while ( RcdFound19 != 0 )
                  {
                     getByPrimaryKey0C19( ) ;
                     Delete0C19( ) ;
                     ScanKeyNext0C19( ) ;
                  }
                  ScanKeyEnd0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C12 */
                     pr_default.execute(10, new Object[] {n104RoleId, A104RoleId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0C17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Role_BC";
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C13 */
            pr_default.execute(11, new Object[] {n104RoleId, A104RoleId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0C19( )
      {
         nGXsfl_19_idx = 0;
         while ( nGXsfl_19_idx < bcRole.gxTpr_Permission.Count )
         {
            ReadRow0C19( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound19 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_19 != 0 ) )
            {
               standaloneNotModal0C19( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0C19( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0C19( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0C19( ) ;
                  }
               }
            }
            KeyVarsToRow19( ((SdtRole_Permission)bcRole.gxTpr_Permission.Item(nGXsfl_19_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_19_idx = 0;
            while ( nGXsfl_19_idx < bcRole.gxTpr_Permission.Count )
            {
               ReadRow0C19( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound19 == 0 )
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
                  bcRole.gxTpr_Permission.RemoveElement(nGXsfl_19_idx);
                  nGXsfl_19_idx = (int)(nGXsfl_19_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0C19( ) ;
                  VarsToRow19( ((SdtRole_Permission)bcRole.gxTpr_Permission.Item(nGXsfl_19_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0C19( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_19 = 0;
         nIsMod_19 = 0;
         Gxremove19 = 0;
      }

      protected void ProcessLevel0C17( )
      {
         /* Save parent mode. */
         sMode17 = Gx_mode;
         ProcessNestedLevel0C19( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode17;
         /* ' Update level parameters */
      }

      protected void EndLevel0C17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C17( ) ;
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

      public void ScanKeyStart0C17( )
      {
         /* Scan By routine */
         /* Using cursor BC000C14 */
         pr_default.execute(12, new Object[] {n104RoleId, A104RoleId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A104RoleId = BC000C14_A104RoleId[0];
            n104RoleId = BC000C14_n104RoleId[0];
            A105RoleName = BC000C14_A105RoleName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C17( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound17 = 0;
         ScanKeyLoad0C17( ) ;
      }

      protected void ScanKeyLoad0C17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A104RoleId = BC000C14_A104RoleId[0];
            n104RoleId = BC000C14_n104RoleId[0];
            A105RoleName = BC000C14_A105RoleName[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0C17( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0C17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C17( )
      {
      }

      protected void ZM0C19( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z107PermissionName = A107PermissionName;
         }
         if ( GX_JID == -3 )
         {
            Z104RoleId = A104RoleId;
            Z106PermissionId = A106PermissionId;
            Z107PermissionName = A107PermissionName;
         }
      }

      protected void standaloneNotModal0C19( )
      {
      }

      protected void standaloneModal0C19( )
      {
      }

      protected void Load0C19( )
      {
         /* Using cursor BC000C15 */
         pr_default.execute(13, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound19 = 1;
            A107PermissionName = BC000C15_A107PermissionName[0];
            ZM0C19( -3) ;
         }
         pr_default.close(13);
         OnLoadActions0C19( ) ;
      }

      protected void OnLoadActions0C19( )
      {
      }

      protected void CheckExtendedTable0C19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         standaloneModal0C19( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Permission'.", "ForeignKeyNotFound", 1, "PERMISSIONID");
            AnyError = 1;
         }
         A107PermissionName = BC000C4_A107PermissionName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C19( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0C19( )
      {
      }

      protected void GetKey0C19( )
      {
         /* Using cursor BC000C16 */
         pr_default.execute(14, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0C19( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C19( 3) ;
            RcdFound19 = 1;
            InitializeNonKey0C19( ) ;
            A106PermissionId = BC000C3_A106PermissionId[0];
            Z104RoleId = A104RoleId;
            Z106PermissionId = A106PermissionId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0C19( ) ;
            Load0C19( ) ;
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0C19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0C19( ) ;
            Gx_mode = sMode19;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0C19( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0C19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RolePermission"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RolePermission"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C19( )
      {
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C19( 0) ;
            CheckOptimisticConcurrency0C19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C17 */
                     pr_default.execute(15, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("RolePermission");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0C19( ) ;
            }
            EndLevel0C19( ) ;
         }
         CloseExtendedTableCursors0C19( ) ;
      }

      protected void Update0C19( )
      {
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [RolePermission] */
                     DeferredUpdate0C19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0C19( ) ;
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
            EndLevel0C19( ) ;
         }
         CloseExtendedTableCursors0C19( ) ;
      }

      protected void DeferredUpdate0C19( )
      {
      }

      protected void Delete0C19( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C19( ) ;
            AfterConfirm0C19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C18 */
                  pr_default.execute(16, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("RolePermission");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0C19( )
      {
         standaloneModal0C19( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000C19 */
            pr_default.execute(17, new Object[] {A106PermissionId});
            A107PermissionName = BC000C19_A107PermissionName[0];
            pr_default.close(17);
         }
      }

      protected void EndLevel0C19( )
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

      public void ScanKeyStart0C19( )
      {
         /* Scan By routine */
         /* Using cursor BC000C20 */
         pr_default.execute(18, new Object[] {n104RoleId, A104RoleId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound19 = 1;
            A107PermissionName = BC000C20_A107PermissionName[0];
            A106PermissionId = BC000C20_A106PermissionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C19( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound19 = 0;
         ScanKeyLoad0C19( ) ;
      }

      protected void ScanKeyLoad0C19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound19 = 1;
            A107PermissionName = BC000C20_A107PermissionName[0];
            A106PermissionId = BC000C20_A106PermissionId[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0C19( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0C19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C19( )
      {
      }

      protected void send_integrity_lvl_hashes0C19( )
      {
      }

      protected void send_integrity_lvl_hashes0C17( )
      {
      }

      protected void AddRow0C17( )
      {
         VarsToRow17( bcRole) ;
      }

      protected void ReadRow0C17( )
      {
         RowToVars17( bcRole, 1) ;
      }

      protected void AddRow0C19( )
      {
         SdtRole_Permission obj19;
         obj19 = new SdtRole_Permission(context);
         VarsToRow19( obj19) ;
         bcRole.gxTpr_Permission.Add(obj19, 0);
         obj19.gxTpr_Mode = "UPD";
         obj19.gxTpr_Modified = 0;
      }

      protected void ReadRow0C19( )
      {
         nGXsfl_19_idx = (int)(nGXsfl_19_idx+1);
         RowToVars19( ((SdtRole_Permission)bcRole.gxTpr_Permission.Item(nGXsfl_19_idx)), 1) ;
      }

      protected void InitializeNonKey0C17( )
      {
         A105RoleName = "";
         Z105RoleName = "";
      }

      protected void InitAll0C17( )
      {
         A104RoleId = 0;
         n104RoleId = false;
         InitializeNonKey0C17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0C19( )
      {
         A107PermissionName = "";
      }

      protected void InitAll0C19( )
      {
         A106PermissionId = 0;
         InitializeNonKey0C19( ) ;
      }

      protected void StandaloneModalInsert0C19( )
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

      public void VarsToRow17( SdtRole obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Rolename = A105RoleName;
         obj17.gxTpr_Roleid = A104RoleId;
         obj17.gxTpr_Roleid_Z = Z104RoleId;
         obj17.gxTpr_Rolename_Z = Z105RoleName;
         obj17.gxTpr_Roleid_N = (short)(Convert.ToInt16(n104RoleId));
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( SdtRole obj17 )
      {
         obj17.gxTpr_Roleid = A104RoleId;
         return  ;
      }

      public void RowToVars17( SdtRole obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A105RoleName = obj17.gxTpr_Rolename;
         A104RoleId = obj17.gxTpr_Roleid;
         n104RoleId = false;
         Z104RoleId = obj17.gxTpr_Roleid_Z;
         Z105RoleName = obj17.gxTpr_Rolename_Z;
         n104RoleId = (bool)(Convert.ToBoolean(obj17.gxTpr_Roleid_N));
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow19( SdtRole_Permission obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Permissionname = A107PermissionName;
         obj19.gxTpr_Permissionid = A106PermissionId;
         obj19.gxTpr_Permissionid_Z = Z106PermissionId;
         obj19.gxTpr_Permissionname_Z = Z107PermissionName;
         obj19.gxTpr_Modified = nIsMod_19;
         return  ;
      }

      public void KeyVarsToRow19( SdtRole_Permission obj19 )
      {
         obj19.gxTpr_Permissionid = A106PermissionId;
         return  ;
      }

      public void RowToVars19( SdtRole_Permission obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A107PermissionName = obj19.gxTpr_Permissionname;
         A106PermissionId = obj19.gxTpr_Permissionid;
         Z106PermissionId = obj19.gxTpr_Permissionid_Z;
         Z107PermissionName = obj19.gxTpr_Permissionname_Z;
         nIsMod_19 = obj19.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A104RoleId = (int)getParm(obj,0);
         n104RoleId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C17( ) ;
         ScanKeyStart0C17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z104RoleId = A104RoleId;
         }
         ZM0C17( -1) ;
         OnLoadActions0C17( ) ;
         AddRow0C17( ) ;
         bcRole.gxTpr_Permission.ClearCollection();
         if ( RcdFound17 == 1 )
         {
            ScanKeyStart0C19( ) ;
            nGXsfl_19_idx = 1;
            while ( RcdFound19 != 0 )
            {
               Z104RoleId = A104RoleId;
               Z106PermissionId = A106PermissionId;
               ZM0C19( -3) ;
               OnLoadActions0C19( ) ;
               nRcdExists_19 = 1;
               nIsMod_19 = 0;
               AddRow0C19( ) ;
               nGXsfl_19_idx = (int)(nGXsfl_19_idx+1);
               ScanKeyNext0C19( ) ;
            }
            ScanKeyEnd0C19( ) ;
         }
         ScanKeyEnd0C17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcRole, 0) ;
         ScanKeyStart0C17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z104RoleId = A104RoleId;
         }
         ZM0C17( -1) ;
         OnLoadActions0C17( ) ;
         AddRow0C17( ) ;
         bcRole.gxTpr_Permission.ClearCollection();
         if ( RcdFound17 == 1 )
         {
            ScanKeyStart0C19( ) ;
            nGXsfl_19_idx = 1;
            while ( RcdFound19 != 0 )
            {
               Z104RoleId = A104RoleId;
               Z106PermissionId = A106PermissionId;
               ZM0C19( -3) ;
               OnLoadActions0C19( ) ;
               nRcdExists_19 = 1;
               nIsMod_19 = 0;
               AddRow0C19( ) ;
               nGXsfl_19_idx = (int)(nGXsfl_19_idx+1);
               ScanKeyNext0C19( ) ;
            }
            ScanKeyEnd0C19( ) ;
         }
         ScanKeyEnd0C17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A104RoleId != Z104RoleId )
               {
                  A104RoleId = Z104RoleId;
                  n104RoleId = false;
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
                  Update0C17( ) ;
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
                  if ( A104RoleId != Z104RoleId )
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
                        Insert0C17( ) ;
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
                        Insert0C17( ) ;
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
         RowToVars17( bcRole, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcRole) ;
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
         RowToVars17( bcRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow17( bcRole) ;
         }
         else
         {
            SdtRole auxBC = new SdtRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A104RoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRole);
               auxBC.Save();
               bcRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars17( bcRole, 1) ;
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
         RowToVars17( bcRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C17( ) ;
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
               VarsToRow17( bcRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow17( bcRole) ;
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
         RowToVars17( bcRole, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A104RoleId != Z104RoleId )
            {
               A104RoleId = Z104RoleId;
               n104RoleId = false;
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
            if ( A104RoleId != Z104RoleId )
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
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(17);
         context.RollbackDataStores("role_bc",pr_default);
         VarsToRow17( bcRole) ;
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
         Gx_mode = bcRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRole )
         {
            bcRole = (SdtRole)(sdt);
            if ( StringUtil.StrCmp(bcRole.gxTpr_Mode, "") == 0 )
            {
               bcRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcRole) ;
            }
            else
            {
               RowToVars17( bcRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRole.gxTpr_Mode, "") == 0 )
            {
               bcRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtRole Role_BC
      {
         get {
            return bcRole ;
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
         pr_default.close(17);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode17 = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV13Pgmname = "";
         Z105RoleName = "";
         A105RoleName = "";
         BC000C7_A104RoleId = new int[1] ;
         BC000C7_n104RoleId = new bool[] {false} ;
         BC000C7_A105RoleName = new string[] {""} ;
         BC000C8_A105RoleName = new string[] {""} ;
         BC000C9_A104RoleId = new int[1] ;
         BC000C9_n104RoleId = new bool[] {false} ;
         BC000C6_A104RoleId = new int[1] ;
         BC000C6_n104RoleId = new bool[] {false} ;
         BC000C6_A105RoleName = new string[] {""} ;
         BC000C5_A104RoleId = new int[1] ;
         BC000C5_n104RoleId = new bool[] {false} ;
         BC000C5_A105RoleName = new string[] {""} ;
         BC000C10_A104RoleId = new int[1] ;
         BC000C10_n104RoleId = new bool[] {false} ;
         BC000C13_A99UserId = new int[1] ;
         BC000C14_A104RoleId = new int[1] ;
         BC000C14_n104RoleId = new bool[] {false} ;
         BC000C14_A105RoleName = new string[] {""} ;
         Z107PermissionName = "";
         A107PermissionName = "";
         BC000C15_A104RoleId = new int[1] ;
         BC000C15_n104RoleId = new bool[] {false} ;
         BC000C15_A107PermissionName = new string[] {""} ;
         BC000C15_A106PermissionId = new int[1] ;
         BC000C4_A107PermissionName = new string[] {""} ;
         BC000C16_A104RoleId = new int[1] ;
         BC000C16_n104RoleId = new bool[] {false} ;
         BC000C16_A106PermissionId = new int[1] ;
         BC000C3_A104RoleId = new int[1] ;
         BC000C3_n104RoleId = new bool[] {false} ;
         BC000C3_A106PermissionId = new int[1] ;
         sMode19 = "";
         BC000C2_A104RoleId = new int[1] ;
         BC000C2_n104RoleId = new bool[] {false} ;
         BC000C2_A106PermissionId = new int[1] ;
         BC000C19_A107PermissionName = new string[] {""} ;
         BC000C20_A104RoleId = new int[1] ;
         BC000C20_n104RoleId = new bool[] {false} ;
         BC000C20_A107PermissionName = new string[] {""} ;
         BC000C20_A106PermissionId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.role_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A104RoleId, BC000C2_A106PermissionId
               }
               , new Object[] {
               BC000C3_A104RoleId, BC000C3_A106PermissionId
               }
               , new Object[] {
               BC000C4_A107PermissionName
               }
               , new Object[] {
               BC000C5_A104RoleId, BC000C5_A105RoleName
               }
               , new Object[] {
               BC000C6_A104RoleId, BC000C6_A105RoleName
               }
               , new Object[] {
               BC000C7_A104RoleId, BC000C7_A105RoleName
               }
               , new Object[] {
               BC000C8_A105RoleName
               }
               , new Object[] {
               BC000C9_A104RoleId
               }
               , new Object[] {
               BC000C10_A104RoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C13_A99UserId
               }
               , new Object[] {
               BC000C14_A104RoleId, BC000C14_A105RoleName
               }
               , new Object[] {
               BC000C15_A104RoleId, BC000C15_A107PermissionName, BC000C15_A106PermissionId
               }
               , new Object[] {
               BC000C16_A104RoleId, BC000C16_A106PermissionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C19_A107PermissionName
               }
               , new Object[] {
               BC000C20_A104RoleId, BC000C20_A107PermissionName, BC000C20_A106PermissionId
               }
            }
         );
         AV13Pgmname = "Role_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_19 ;
      private short RcdFound19 ;
      private short GX_JID ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private short nRcdExists_19 ;
      private short Gxremove19 ;
      private short nIsDirty_19 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int Z104RoleId ;
      private int A104RoleId ;
      private int nGXsfl_19_idx=1 ;
      private int Z106PermissionId ;
      private int A106PermissionId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode17 ;
      private string AV13Pgmname ;
      private string sMode19 ;
      private bool returnInSub ;
      private bool n104RoleId ;
      private bool mustCommit ;
      private string Z105RoleName ;
      private string A105RoleName ;
      private string Z107PermissionName ;
      private string A107PermissionName ;
      private SdtRole bcRole ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000C7_A104RoleId ;
      private bool[] BC000C7_n104RoleId ;
      private string[] BC000C7_A105RoleName ;
      private string[] BC000C8_A105RoleName ;
      private int[] BC000C9_A104RoleId ;
      private bool[] BC000C9_n104RoleId ;
      private int[] BC000C6_A104RoleId ;
      private bool[] BC000C6_n104RoleId ;
      private string[] BC000C6_A105RoleName ;
      private int[] BC000C5_A104RoleId ;
      private bool[] BC000C5_n104RoleId ;
      private string[] BC000C5_A105RoleName ;
      private int[] BC000C10_A104RoleId ;
      private bool[] BC000C10_n104RoleId ;
      private int[] BC000C13_A99UserId ;
      private int[] BC000C14_A104RoleId ;
      private bool[] BC000C14_n104RoleId ;
      private string[] BC000C14_A105RoleName ;
      private int[] BC000C15_A104RoleId ;
      private bool[] BC000C15_n104RoleId ;
      private string[] BC000C15_A107PermissionName ;
      private int[] BC000C15_A106PermissionId ;
      private string[] BC000C4_A107PermissionName ;
      private int[] BC000C16_A104RoleId ;
      private bool[] BC000C16_n104RoleId ;
      private int[] BC000C16_A106PermissionId ;
      private int[] BC000C3_A104RoleId ;
      private bool[] BC000C3_n104RoleId ;
      private int[] BC000C3_A106PermissionId ;
      private int[] BC000C2_A104RoleId ;
      private bool[] BC000C2_n104RoleId ;
      private int[] BC000C2_A106PermissionId ;
      private string[] BC000C19_A107PermissionName ;
      private int[] BC000C20_A104RoleId ;
      private bool[] BC000C20_n104RoleId ;
      private string[] BC000C20_A107PermissionName ;
      private int[] BC000C20_A106PermissionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class role_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000C7;
          prmBC000C7 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C8;
          prmBC000C8 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0) ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C9;
          prmBC000C9 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C6;
          prmBC000C6 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C5;
          prmBC000C5 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C10;
          prmBC000C10 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0)
          };
          Object[] prmBC000C11;
          prmBC000C11 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0) ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C12;
          prmBC000C12 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C13;
          prmBC000C13 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C14;
          prmBC000C14 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000C15;
          prmBC000C15 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C4;
          prmBC000C4 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C16;
          prmBC000C16 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C3;
          prmBC000C3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C2;
          prmBC000C2 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C17;
          prmBC000C17 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C18;
          prmBC000C18 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C19;
          prmBC000C19 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmBC000C20;
          prmBC000C20 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000C2", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WITH (UPDLOCK) WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C3", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C4", "SELECT [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C5", "SELECT [RoleId], [RoleName] FROM [Role] WITH (UPDLOCK) WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C6", "SELECT [RoleId], [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C7", "SELECT TM1.[RoleId], TM1.[RoleName] FROM [Role] TM1 WHERE TM1.[RoleId] = @RoleId ORDER BY TM1.[RoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C8", "SELECT [RoleName] FROM [Role] WHERE ([RoleName] = @RoleName) AND (Not ( [RoleId] = @RoleId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C9", "SELECT [RoleId] FROM [Role] WHERE [RoleId] = @RoleId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C10", "INSERT INTO [Role]([RoleName]) VALUES(@RoleName); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C11", "UPDATE [Role] SET [RoleName]=@RoleName  WHERE [RoleId] = @RoleId", GxErrorMask.GX_NOMASK,prmBC000C11)
             ,new CursorDef("BC000C12", "DELETE FROM [Role]  WHERE [RoleId] = @RoleId", GxErrorMask.GX_NOMASK,prmBC000C12)
             ,new CursorDef("BC000C13", "SELECT TOP 1 [UserId] FROM [User] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000C14", "SELECT TM1.[RoleId], TM1.[RoleName] FROM [Role] TM1 WHERE TM1.[RoleId] = @RoleId ORDER BY TM1.[RoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C15", "SELECT T1.[RoleId], T2.[PermissionName], T1.[PermissionId] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) WHERE T1.[RoleId] = @RoleId and T1.[PermissionId] = @PermissionId ORDER BY T1.[RoleId], T1.[PermissionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C15,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C16", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C17", "INSERT INTO [RolePermission]([RoleId], [PermissionId]) VALUES(@RoleId, @PermissionId)", GxErrorMask.GX_NOMASK,prmBC000C17)
             ,new CursorDef("BC000C18", "DELETE FROM [RolePermission]  WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId", GxErrorMask.GX_NOMASK,prmBC000C18)
             ,new CursorDef("BC000C19", "SELECT [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000C20", "SELECT T1.[RoleId], T2.[PermissionName], T1.[PermissionId] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) WHERE T1.[RoleId] = @RoleId ORDER BY T1.[RoleId], T1.[PermissionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C20,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
