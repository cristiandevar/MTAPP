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
   public class movement_bc : GxSilentTrn, IGxSilentTrn
   {
      public movement_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public movement_bc( IGxContext context )
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
         ReadRow0F22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F22( ) ;
         standaloneModal( ) ;
         AddRow0F22( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z123MovementId = A123MovementId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F22( ) ;
            }
            else
            {
               CheckExtendedTable0F22( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0F22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0F22( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z125MovementCreatedDate = A125MovementCreatedDate;
            Z124MovementType = A124MovementType;
            Z128MovementKeyAditional = A128MovementKeyAditional;
            Z140MovementDescription = A140MovementDescription;
         }
         if ( GX_JID == -3 )
         {
            Z123MovementId = A123MovementId;
            Z125MovementCreatedDate = A125MovementCreatedDate;
            Z124MovementType = A124MovementType;
            Z128MovementKeyAditional = A128MovementKeyAditional;
            Z140MovementDescription = A140MovementDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A125MovementCreatedDate = DateTimeUtil.ServerDate( context, pr_default);
         }
      }

      protected void Load0F22( )
      {
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A125MovementCreatedDate = BC000F4_A125MovementCreatedDate[0];
            A124MovementType = BC000F4_A124MovementType[0];
            A128MovementKeyAditional = BC000F4_A128MovementKeyAditional[0];
            A140MovementDescription = BC000F4_A140MovementDescription[0];
            ZM0F22( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0F22( ) ;
      }

      protected void OnLoadActions0F22( )
      {
      }

      protected void CheckExtendedTable0F22( )
      {
         nIsDirty_22 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A124MovementType == 1 ) || ( A124MovementType == 2 ) || ( A124MovementType == 3 ) ) )
         {
            GX_msglist.addItem("Field Movement Type is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0F22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F22( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F22( 3) ;
            RcdFound22 = 1;
            A123MovementId = BC000F3_A123MovementId[0];
            A125MovementCreatedDate = BC000F3_A125MovementCreatedDate[0];
            A124MovementType = BC000F3_A124MovementType[0];
            A128MovementKeyAditional = BC000F3_A128MovementKeyAditional[0];
            A140MovementDescription = BC000F3_A140MovementDescription[0];
            Z123MovementId = A123MovementId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0F22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0F22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F22( ) ;
         if ( RcdFound22 == 0 )
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
         CONFIRM_0F0( ) ;
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

      protected void CheckOptimisticConcurrency0F22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A123MovementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Movement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z125MovementCreatedDate ) != DateTimeUtil.ResetTime ( BC000F2_A125MovementCreatedDate[0] ) ) || ( Z124MovementType != BC000F2_A124MovementType[0] ) || ( Z128MovementKeyAditional != BC000F2_A128MovementKeyAditional[0] ) || ( StringUtil.StrCmp(Z140MovementDescription, BC000F2_A140MovementDescription[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Movement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F22( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F22( 0) ;
            CheckOptimisticConcurrency0F22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F6 */
                     pr_default.execute(4, new Object[] {A125MovementCreatedDate, A124MovementType, A128MovementKeyAditional, A140MovementDescription});
                     A123MovementId = BC000F6_A123MovementId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Movement");
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
               Load0F22( ) ;
            }
            EndLevel0F22( ) ;
         }
         CloseExtendedTableCursors0F22( ) ;
      }

      protected void Update0F22( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A125MovementCreatedDate, A124MovementType, A128MovementKeyAditional, A140MovementDescription, A123MovementId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Movement");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Movement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F22( ) ;
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
            EndLevel0F22( ) ;
         }
         CloseExtendedTableCursors0F22( ) ;
      }

      protected void DeferredUpdate0F22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F22( ) ;
            AfterConfirm0F22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F8 */
                  pr_default.execute(6, new Object[] {A123MovementId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Movement");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0F22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F22( ) ;
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

      public void ScanKeyStart0F22( )
      {
         /* Scan By routine */
         /* Using cursor BC000F9 */
         pr_default.execute(7, new Object[] {A123MovementId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound22 = 1;
            A123MovementId = BC000F9_A123MovementId[0];
            A125MovementCreatedDate = BC000F9_A125MovementCreatedDate[0];
            A124MovementType = BC000F9_A124MovementType[0];
            A128MovementKeyAditional = BC000F9_A128MovementKeyAditional[0];
            A140MovementDescription = BC000F9_A140MovementDescription[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F22( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound22 = 0;
         ScanKeyLoad0F22( ) ;
      }

      protected void ScanKeyLoad0F22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound22 = 1;
            A123MovementId = BC000F9_A123MovementId[0];
            A125MovementCreatedDate = BC000F9_A125MovementCreatedDate[0];
            A124MovementType = BC000F9_A124MovementType[0];
            A128MovementKeyAditional = BC000F9_A128MovementKeyAditional[0];
            A140MovementDescription = BC000F9_A140MovementDescription[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0F22( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0F22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F22( )
      {
      }

      protected void send_integrity_lvl_hashes0F22( )
      {
      }

      protected void AddRow0F22( )
      {
         VarsToRow22( bcMovement) ;
      }

      protected void ReadRow0F22( )
      {
         RowToVars22( bcMovement, 1) ;
      }

      protected void InitializeNonKey0F22( )
      {
         A125MovementCreatedDate = DateTime.MinValue;
         A124MovementType = 0;
         A128MovementKeyAditional = 0;
         A140MovementDescription = "";
         Z125MovementCreatedDate = DateTime.MinValue;
         Z124MovementType = 0;
         Z128MovementKeyAditional = 0;
         Z140MovementDescription = "";
      }

      protected void InitAll0F22( )
      {
         A123MovementId = 0;
         InitializeNonKey0F22( ) ;
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

      public void VarsToRow22( SdtMovement obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Movementcreateddate = A125MovementCreatedDate;
         obj22.gxTpr_Movementtype = A124MovementType;
         obj22.gxTpr_Movementkeyaditional = A128MovementKeyAditional;
         obj22.gxTpr_Movementdescription = A140MovementDescription;
         obj22.gxTpr_Movementid = A123MovementId;
         obj22.gxTpr_Movementid_Z = Z123MovementId;
         obj22.gxTpr_Movementtype_Z = Z124MovementType;
         obj22.gxTpr_Movementcreateddate_Z = Z125MovementCreatedDate;
         obj22.gxTpr_Movementkeyaditional_Z = Z128MovementKeyAditional;
         obj22.gxTpr_Movementdescription_Z = Z140MovementDescription;
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtMovement obj22 )
      {
         obj22.gxTpr_Movementid = A123MovementId;
         return  ;
      }

      public void RowToVars22( SdtMovement obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         if ( forceLoad == 1 )
         {
            A125MovementCreatedDate = obj22.gxTpr_Movementcreateddate;
         }
         A124MovementType = obj22.gxTpr_Movementtype;
         A128MovementKeyAditional = obj22.gxTpr_Movementkeyaditional;
         A140MovementDescription = obj22.gxTpr_Movementdescription;
         A123MovementId = obj22.gxTpr_Movementid;
         Z123MovementId = obj22.gxTpr_Movementid_Z;
         Z124MovementType = obj22.gxTpr_Movementtype_Z;
         Z125MovementCreatedDate = obj22.gxTpr_Movementcreateddate_Z;
         Z128MovementKeyAditional = obj22.gxTpr_Movementkeyaditional_Z;
         Z140MovementDescription = obj22.gxTpr_Movementdescription_Z;
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A123MovementId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F22( ) ;
         ScanKeyStart0F22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z123MovementId = A123MovementId;
         }
         ZM0F22( -3) ;
         OnLoadActions0F22( ) ;
         AddRow0F22( ) ;
         ScanKeyEnd0F22( ) ;
         if ( RcdFound22 == 0 )
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
         RowToVars22( bcMovement, 0) ;
         ScanKeyStart0F22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z123MovementId = A123MovementId;
         }
         ZM0F22( -3) ;
         OnLoadActions0F22( ) ;
         AddRow0F22( ) ;
         ScanKeyEnd0F22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0F22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F22( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A123MovementId != Z123MovementId )
               {
                  A123MovementId = Z123MovementId;
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
                  Update0F22( ) ;
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
                  if ( A123MovementId != Z123MovementId )
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
                        Insert0F22( ) ;
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
                        Insert0F22( ) ;
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
         RowToVars22( bcMovement, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcMovement) ;
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
         RowToVars22( bcMovement, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcMovement) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcMovement) ;
         }
         else
         {
            SdtMovement auxBC = new SdtMovement(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A123MovementId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMovement);
               auxBC.Save();
               bcMovement.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bcMovement, 1) ;
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
         RowToVars22( bcMovement, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F22( ) ;
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
               VarsToRow22( bcMovement) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcMovement) ;
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
         RowToVars22( bcMovement, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0F22( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A123MovementId != Z123MovementId )
            {
               A123MovementId = Z123MovementId;
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
            if ( A123MovementId != Z123MovementId )
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
         context.RollbackDataStores("movement_bc",pr_default);
         VarsToRow22( bcMovement) ;
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
         Gx_mode = bcMovement.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMovement.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMovement )
         {
            bcMovement = (SdtMovement)(sdt);
            if ( StringUtil.StrCmp(bcMovement.gxTpr_Mode, "") == 0 )
            {
               bcMovement.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcMovement) ;
            }
            else
            {
               RowToVars22( bcMovement, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMovement.gxTpr_Mode, "") == 0 )
            {
               bcMovement.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcMovement, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtMovement Movement_BC
      {
         get {
            return bcMovement ;
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
         Z125MovementCreatedDate = DateTime.MinValue;
         A125MovementCreatedDate = DateTime.MinValue;
         Z140MovementDescription = "";
         A140MovementDescription = "";
         BC000F4_A123MovementId = new int[1] ;
         BC000F4_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A124MovementType = new short[1] ;
         BC000F4_A128MovementKeyAditional = new int[1] ;
         BC000F4_A140MovementDescription = new string[] {""} ;
         BC000F5_A123MovementId = new int[1] ;
         BC000F3_A123MovementId = new int[1] ;
         BC000F3_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000F3_A124MovementType = new short[1] ;
         BC000F3_A128MovementKeyAditional = new int[1] ;
         BC000F3_A140MovementDescription = new string[] {""} ;
         sMode22 = "";
         BC000F2_A123MovementId = new int[1] ;
         BC000F2_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000F2_A124MovementType = new short[1] ;
         BC000F2_A128MovementKeyAditional = new int[1] ;
         BC000F2_A140MovementDescription = new string[] {""} ;
         BC000F6_A123MovementId = new int[1] ;
         BC000F9_A123MovementId = new int[1] ;
         BC000F9_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000F9_A124MovementType = new short[1] ;
         BC000F9_A128MovementKeyAditional = new int[1] ;
         BC000F9_A140MovementDescription = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.movement_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A123MovementId, BC000F2_A125MovementCreatedDate, BC000F2_A124MovementType, BC000F2_A128MovementKeyAditional, BC000F2_A140MovementDescription
               }
               , new Object[] {
               BC000F3_A123MovementId, BC000F3_A125MovementCreatedDate, BC000F3_A124MovementType, BC000F3_A128MovementKeyAditional, BC000F3_A140MovementDescription
               }
               , new Object[] {
               BC000F4_A123MovementId, BC000F4_A125MovementCreatedDate, BC000F4_A124MovementType, BC000F4_A128MovementKeyAditional, BC000F4_A140MovementDescription
               }
               , new Object[] {
               BC000F5_A123MovementId
               }
               , new Object[] {
               BC000F6_A123MovementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F9_A123MovementId, BC000F9_A125MovementCreatedDate, BC000F9_A124MovementType, BC000F9_A128MovementKeyAditional, BC000F9_A140MovementDescription
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z124MovementType ;
      private short A124MovementType ;
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private int trnEnded ;
      private int Z123MovementId ;
      private int A123MovementId ;
      private int Z128MovementKeyAditional ;
      private int A128MovementKeyAditional ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode22 ;
      private DateTime Z125MovementCreatedDate ;
      private DateTime A125MovementCreatedDate ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z140MovementDescription ;
      private string A140MovementDescription ;
      private SdtMovement bcMovement ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000F4_A123MovementId ;
      private DateTime[] BC000F4_A125MovementCreatedDate ;
      private short[] BC000F4_A124MovementType ;
      private int[] BC000F4_A128MovementKeyAditional ;
      private string[] BC000F4_A140MovementDescription ;
      private int[] BC000F5_A123MovementId ;
      private int[] BC000F3_A123MovementId ;
      private DateTime[] BC000F3_A125MovementCreatedDate ;
      private short[] BC000F3_A124MovementType ;
      private int[] BC000F3_A128MovementKeyAditional ;
      private string[] BC000F3_A140MovementDescription ;
      private int[] BC000F2_A123MovementId ;
      private DateTime[] BC000F2_A125MovementCreatedDate ;
      private short[] BC000F2_A124MovementType ;
      private int[] BC000F2_A128MovementKeyAditional ;
      private string[] BC000F2_A140MovementDescription ;
      private int[] BC000F6_A123MovementId ;
      private int[] BC000F9_A123MovementId ;
      private DateTime[] BC000F9_A125MovementCreatedDate ;
      private short[] BC000F9_A124MovementType ;
      private int[] BC000F9_A128MovementKeyAditional ;
      private string[] BC000F9_A140MovementDescription ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class movement_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000F4;
          prmBC000F4 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F5;
          prmBC000F5 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F3;
          prmBC000F3 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F2;
          prmBC000F2 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F6;
          prmBC000F6 = new Object[] {
          new ParDef("@MovementCreatedDate",GXType.Date,8,0) ,
          new ParDef("@MovementType",GXType.Int16,4,0) ,
          new ParDef("@MovementKeyAditional",GXType.Int32,6,0) ,
          new ParDef("@MovementDescription",GXType.NVarChar,200,0)
          };
          Object[] prmBC000F7;
          prmBC000F7 = new Object[] {
          new ParDef("@MovementCreatedDate",GXType.Date,8,0) ,
          new ParDef("@MovementType",GXType.Int16,4,0) ,
          new ParDef("@MovementKeyAditional",GXType.Int32,6,0) ,
          new ParDef("@MovementDescription",GXType.NVarChar,200,0) ,
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F8;
          prmBC000F8 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmBC000F9;
          prmBC000F9 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000F2", "SELECT [MovementId], [MovementCreatedDate], [MovementType], [MovementKeyAditional], [MovementDescription] FROM [Movement] WITH (UPDLOCK) WHERE [MovementId] = @MovementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F3", "SELECT [MovementId], [MovementCreatedDate], [MovementType], [MovementKeyAditional], [MovementDescription] FROM [Movement] WHERE [MovementId] = @MovementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F4", "SELECT TM1.[MovementId], TM1.[MovementCreatedDate], TM1.[MovementType], TM1.[MovementKeyAditional], TM1.[MovementDescription] FROM [Movement] TM1 WHERE TM1.[MovementId] = @MovementId ORDER BY TM1.[MovementId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F5", "SELECT [MovementId] FROM [Movement] WHERE [MovementId] = @MovementId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F6", "INSERT INTO [Movement]([MovementCreatedDate], [MovementType], [MovementKeyAditional], [MovementDescription]) VALUES(@MovementCreatedDate, @MovementType, @MovementKeyAditional, @MovementDescription); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000F7", "UPDATE [Movement] SET [MovementCreatedDate]=@MovementCreatedDate, [MovementType]=@MovementType, [MovementKeyAditional]=@MovementKeyAditional, [MovementDescription]=@MovementDescription  WHERE [MovementId] = @MovementId", GxErrorMask.GX_NOMASK,prmBC000F7)
             ,new CursorDef("BC000F8", "DELETE FROM [Movement]  WHERE [MovementId] = @MovementId", GxErrorMask.GX_NOMASK,prmBC000F8)
             ,new CursorDef("BC000F9", "SELECT TM1.[MovementId], TM1.[MovementCreatedDate], TM1.[MovementType], TM1.[MovementKeyAditional], TM1.[MovementDescription] FROM [Movement] TM1 WHERE TM1.[MovementId] = @MovementId ORDER BY TM1.[MovementId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
