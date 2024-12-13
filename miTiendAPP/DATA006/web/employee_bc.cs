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
   public class employee_bc : GxSilentTrn, IGxSilentTrn
   {
      public employee_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public employee_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z12EmployeeId = A12EmployeeId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z13EmployeeFirstName = A13EmployeeFirstName;
            Z14EmployeeLastName = A14EmployeeLastName;
            Z36EmployeeCreatedDate = A36EmployeeCreatedDate;
            Z37EmployeeModifiedDate = A37EmployeeModifiedDate;
         }
         if ( GX_JID == -3 )
         {
            Z12EmployeeId = A12EmployeeId;
            Z13EmployeeFirstName = A13EmployeeFirstName;
            Z14EmployeeLastName = A14EmployeeLastName;
            Z36EmployeeCreatedDate = A36EmployeeCreatedDate;
            Z37EmployeeModifiedDate = A37EmployeeModifiedDate;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A36EmployeeCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A36EmployeeCreatedDate = Gx_date;
         }
         if ( IsIns( )  && (DateTime.MinValue==A37EmployeeModifiedDate) && ( Gx_BScreen == 0 ) )
         {
            A37EmployeeModifiedDate = Gx_date;
         }
      }

      protected void Load044( )
      {
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A13EmployeeFirstName = BC00044_A13EmployeeFirstName[0];
            A14EmployeeLastName = BC00044_A14EmployeeLastName[0];
            A36EmployeeCreatedDate = BC00044_A36EmployeeCreatedDate[0];
            A37EmployeeModifiedDate = BC00044_A37EmployeeModifiedDate[0];
            ZM044( -3) ;
         }
         pr_default.close(2);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 3) ;
            RcdFound4 = 1;
            A12EmployeeId = BC00043_A12EmployeeId[0];
            A13EmployeeFirstName = BC00043_A13EmployeeFirstName[0];
            A14EmployeeLastName = BC00043_A14EmployeeLastName[0];
            A36EmployeeCreatedDate = BC00043_A36EmployeeCreatedDate[0];
            A37EmployeeModifiedDate = BC00043_A37EmployeeModifiedDate[0];
            Z12EmployeeId = A12EmployeeId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A12EmployeeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13EmployeeFirstName, BC00042_A13EmployeeFirstName[0]) != 0 ) || ( StringUtil.StrCmp(Z14EmployeeLastName, BC00042_A14EmployeeLastName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z36EmployeeCreatedDate ) != DateTimeUtil.ResetTime ( BC00042_A36EmployeeCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z37EmployeeModifiedDate ) != DateTimeUtil.ResetTime ( BC00042_A37EmployeeModifiedDate[0] ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00046 */
                     pr_default.execute(4, new Object[] {A13EmployeeFirstName, A14EmployeeLastName, A36EmployeeCreatedDate, A37EmployeeModifiedDate});
                     A12EmployeeId = BC00046_A12EmployeeId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00047 */
                     pr_default.execute(5, new Object[] {A13EmployeeFirstName, A14EmployeeLastName, A36EmployeeCreatedDate, A37EmployeeModifiedDate, A12EmployeeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00048 */
                  pr_default.execute(6, new Object[] {A12EmployeeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Employee");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00049 */
            pr_default.execute(7, new Object[] {A12EmployeeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invoice"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Scan By routine */
         /* Using cursor BC000410 */
         pr_default.execute(8, new Object[] {A12EmployeeId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A12EmployeeId = BC000410_A12EmployeeId[0];
            A13EmployeeFirstName = BC000410_A13EmployeeFirstName[0];
            A14EmployeeLastName = BC000410_A14EmployeeLastName[0];
            A36EmployeeCreatedDate = BC000410_A36EmployeeCreatedDate[0];
            A37EmployeeModifiedDate = BC000410_A37EmployeeModifiedDate[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A12EmployeeId = BC000410_A12EmployeeId[0];
            A13EmployeeFirstName = BC000410_A13EmployeeFirstName[0];
            A14EmployeeLastName = BC000410_A14EmployeeLastName[0];
            A36EmployeeCreatedDate = BC000410_A36EmployeeCreatedDate[0];
            A37EmployeeModifiedDate = BC000410_A37EmployeeModifiedDate[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcEmployee) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcEmployee, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A13EmployeeFirstName = "";
         A14EmployeeLastName = "";
         A36EmployeeCreatedDate = Gx_date;
         A37EmployeeModifiedDate = Gx_date;
         Z13EmployeeFirstName = "";
         Z14EmployeeLastName = "";
         Z36EmployeeCreatedDate = DateTime.MinValue;
         Z37EmployeeModifiedDate = DateTime.MinValue;
      }

      protected void InitAll044( )
      {
         A12EmployeeId = 0;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A36EmployeeCreatedDate = i36EmployeeCreatedDate;
         A37EmployeeModifiedDate = i37EmployeeModifiedDate;
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

      public void VarsToRow4( SdtEmployee obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Employeefirstname = A13EmployeeFirstName;
         obj4.gxTpr_Employeelastname = A14EmployeeLastName;
         obj4.gxTpr_Employeecreateddate = A36EmployeeCreatedDate;
         obj4.gxTpr_Employeemodifieddate = A37EmployeeModifiedDate;
         obj4.gxTpr_Employeeid = A12EmployeeId;
         obj4.gxTpr_Employeeid_Z = Z12EmployeeId;
         obj4.gxTpr_Employeefirstname_Z = Z13EmployeeFirstName;
         obj4.gxTpr_Employeelastname_Z = Z14EmployeeLastName;
         obj4.gxTpr_Employeecreateddate_Z = Z36EmployeeCreatedDate;
         obj4.gxTpr_Employeemodifieddate_Z = Z37EmployeeModifiedDate;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtEmployee obj4 )
      {
         obj4.gxTpr_Employeeid = A12EmployeeId;
         return  ;
      }

      public void RowToVars4( SdtEmployee obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A13EmployeeFirstName = obj4.gxTpr_Employeefirstname;
         A14EmployeeLastName = obj4.gxTpr_Employeelastname;
         if ( forceLoad == 1 )
         {
            A36EmployeeCreatedDate = obj4.gxTpr_Employeecreateddate;
         }
         if ( forceLoad == 1 )
         {
            A37EmployeeModifiedDate = obj4.gxTpr_Employeemodifieddate;
         }
         A12EmployeeId = obj4.gxTpr_Employeeid;
         Z12EmployeeId = obj4.gxTpr_Employeeid_Z;
         Z13EmployeeFirstName = obj4.gxTpr_Employeefirstname_Z;
         Z14EmployeeLastName = obj4.gxTpr_Employeelastname_Z;
         Z36EmployeeCreatedDate = obj4.gxTpr_Employeecreateddate_Z;
         Z37EmployeeModifiedDate = obj4.gxTpr_Employeemodifieddate_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A12EmployeeId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z12EmployeeId = A12EmployeeId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcEmployee, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z12EmployeeId = A12EmployeeId;
         }
         ZM044( -3) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A12EmployeeId != Z12EmployeeId )
               {
                  A12EmployeeId = Z12EmployeeId;
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
                  Update044( ) ;
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
                  if ( A12EmployeeId != Z12EmployeeId )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bcEmployee, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcEmployee) ;
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
         RowToVars4( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcEmployee) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcEmployee) ;
         }
         else
         {
            SdtEmployee auxBC = new SdtEmployee(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A12EmployeeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmployee);
               auxBC.Save();
               bcEmployee.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars4( bcEmployee, 1) ;
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
         RowToVars4( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
               VarsToRow4( bcEmployee) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcEmployee) ;
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
         RowToVars4( bcEmployee, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A12EmployeeId != Z12EmployeeId )
            {
               A12EmployeeId = Z12EmployeeId;
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
            if ( A12EmployeeId != Z12EmployeeId )
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
         context.RollbackDataStores("employee_bc",pr_default);
         VarsToRow4( bcEmployee) ;
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
         Gx_mode = bcEmployee.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmployee.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmployee )
         {
            bcEmployee = (SdtEmployee)(sdt);
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcEmployee) ;
            }
            else
            {
               RowToVars4( bcEmployee, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcEmployee, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEmployee Employee_BC
      {
         get {
            return bcEmployee ;
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
         Z13EmployeeFirstName = "";
         A13EmployeeFirstName = "";
         Z14EmployeeLastName = "";
         A14EmployeeLastName = "";
         Z36EmployeeCreatedDate = DateTime.MinValue;
         A36EmployeeCreatedDate = DateTime.MinValue;
         Z37EmployeeModifiedDate = DateTime.MinValue;
         A37EmployeeModifiedDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         BC00044_A12EmployeeId = new int[1] ;
         BC00044_A13EmployeeFirstName = new string[] {""} ;
         BC00044_A14EmployeeLastName = new string[] {""} ;
         BC00044_A36EmployeeCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00044_A37EmployeeModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00045_A12EmployeeId = new int[1] ;
         BC00043_A12EmployeeId = new int[1] ;
         BC00043_A13EmployeeFirstName = new string[] {""} ;
         BC00043_A14EmployeeLastName = new string[] {""} ;
         BC00043_A36EmployeeCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00043_A37EmployeeModifiedDate = new DateTime[] {DateTime.MinValue} ;
         sMode4 = "";
         BC00042_A12EmployeeId = new int[1] ;
         BC00042_A13EmployeeFirstName = new string[] {""} ;
         BC00042_A14EmployeeLastName = new string[] {""} ;
         BC00042_A36EmployeeCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00042_A37EmployeeModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00046_A12EmployeeId = new int[1] ;
         BC00049_A20InvoiceId = new int[1] ;
         BC000410_A12EmployeeId = new int[1] ;
         BC000410_A13EmployeeFirstName = new string[] {""} ;
         BC000410_A14EmployeeLastName = new string[] {""} ;
         BC000410_A36EmployeeCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000410_A37EmployeeModifiedDate = new DateTime[] {DateTime.MinValue} ;
         i36EmployeeCreatedDate = DateTime.MinValue;
         i37EmployeeModifiedDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A12EmployeeId, BC00042_A13EmployeeFirstName, BC00042_A14EmployeeLastName, BC00042_A36EmployeeCreatedDate, BC00042_A37EmployeeModifiedDate
               }
               , new Object[] {
               BC00043_A12EmployeeId, BC00043_A13EmployeeFirstName, BC00043_A14EmployeeLastName, BC00043_A36EmployeeCreatedDate, BC00043_A37EmployeeModifiedDate
               }
               , new Object[] {
               BC00044_A12EmployeeId, BC00044_A13EmployeeFirstName, BC00044_A14EmployeeLastName, BC00044_A36EmployeeCreatedDate, BC00044_A37EmployeeModifiedDate
               }
               , new Object[] {
               BC00045_A12EmployeeId
               }
               , new Object[] {
               BC00046_A12EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00049_A20InvoiceId
               }
               , new Object[] {
               BC000410_A12EmployeeId, BC000410_A13EmployeeFirstName, BC000410_A14EmployeeLastName, BC000410_A36EmployeeCreatedDate, BC000410_A37EmployeeModifiedDate
               }
            }
         );
         Z37EmployeeModifiedDate = DateTime.MinValue;
         A37EmployeeModifiedDate = DateTime.MinValue;
         i37EmployeeModifiedDate = DateTime.MinValue;
         Z36EmployeeCreatedDate = DateTime.MinValue;
         A36EmployeeCreatedDate = DateTime.MinValue;
         i36EmployeeCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private int Z12EmployeeId ;
      private int A12EmployeeId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private DateTime Z36EmployeeCreatedDate ;
      private DateTime A36EmployeeCreatedDate ;
      private DateTime Z37EmployeeModifiedDate ;
      private DateTime A37EmployeeModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i36EmployeeCreatedDate ;
      private DateTime i37EmployeeModifiedDate ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z13EmployeeFirstName ;
      private string A13EmployeeFirstName ;
      private string Z14EmployeeLastName ;
      private string A14EmployeeLastName ;
      private SdtEmployee bcEmployee ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00044_A12EmployeeId ;
      private string[] BC00044_A13EmployeeFirstName ;
      private string[] BC00044_A14EmployeeLastName ;
      private DateTime[] BC00044_A36EmployeeCreatedDate ;
      private DateTime[] BC00044_A37EmployeeModifiedDate ;
      private int[] BC00045_A12EmployeeId ;
      private int[] BC00043_A12EmployeeId ;
      private string[] BC00043_A13EmployeeFirstName ;
      private string[] BC00043_A14EmployeeLastName ;
      private DateTime[] BC00043_A36EmployeeCreatedDate ;
      private DateTime[] BC00043_A37EmployeeModifiedDate ;
      private int[] BC00042_A12EmployeeId ;
      private string[] BC00042_A13EmployeeFirstName ;
      private string[] BC00042_A14EmployeeLastName ;
      private DateTime[] BC00042_A36EmployeeCreatedDate ;
      private DateTime[] BC00042_A37EmployeeModifiedDate ;
      private int[] BC00046_A12EmployeeId ;
      private int[] BC00049_A20InvoiceId ;
      private int[] BC000410_A12EmployeeId ;
      private string[] BC000410_A13EmployeeFirstName ;
      private string[] BC000410_A14EmployeeLastName ;
      private DateTime[] BC000410_A36EmployeeCreatedDate ;
      private DateTime[] BC000410_A37EmployeeModifiedDate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class employee_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@EmployeeFirstName",GXType.NVarChar,60,0) ,
          new ParDef("@EmployeeLastName",GXType.NVarChar,60,0) ,
          new ParDef("@EmployeeCreatedDate",GXType.Date,8,0) ,
          new ParDef("@EmployeeModifiedDate",GXType.Date,8,0)
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@EmployeeFirstName",GXType.NVarChar,60,0) ,
          new ParDef("@EmployeeLastName",GXType.NVarChar,60,0) ,
          new ParDef("@EmployeeCreatedDate",GXType.Date,8,0) ,
          new ParDef("@EmployeeModifiedDate",GXType.Date,8,0) ,
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeeCreatedDate], [EmployeeModifiedDate] FROM [Employee] WITH (UPDLOCK) WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [EmployeeId], [EmployeeFirstName], [EmployeeLastName], [EmployeeCreatedDate], [EmployeeModifiedDate] FROM [Employee] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT TM1.[EmployeeId], TM1.[EmployeeFirstName], TM1.[EmployeeLastName], TM1.[EmployeeCreatedDate], TM1.[EmployeeModifiedDate] FROM [Employee] TM1 WHERE TM1.[EmployeeId] = @EmployeeId ORDER BY TM1.[EmployeeId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [EmployeeId] FROM [Employee] WHERE [EmployeeId] = @EmployeeId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "INSERT INTO [Employee]([EmployeeFirstName], [EmployeeLastName], [EmployeeCreatedDate], [EmployeeModifiedDate]) VALUES(@EmployeeFirstName, @EmployeeLastName, @EmployeeCreatedDate, @EmployeeModifiedDate); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00047", "UPDATE [Employee] SET [EmployeeFirstName]=@EmployeeFirstName, [EmployeeLastName]=@EmployeeLastName, [EmployeeCreatedDate]=@EmployeeCreatedDate, [EmployeeModifiedDate]=@EmployeeModifiedDate  WHERE [EmployeeId] = @EmployeeId", GxErrorMask.GX_NOMASK,prmBC00047)
             ,new CursorDef("BC00048", "DELETE FROM [Employee]  WHERE [EmployeeId] = @EmployeeId", GxErrorMask.GX_NOMASK,prmBC00048)
             ,new CursorDef("BC00049", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000410", "SELECT TM1.[EmployeeId], TM1.[EmployeeFirstName], TM1.[EmployeeLastName], TM1.[EmployeeCreatedDate], TM1.[EmployeeModifiedDate] FROM [Employee] TM1 WHERE TM1.[EmployeeId] = @EmployeeId ORDER BY TM1.[EmployeeId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
