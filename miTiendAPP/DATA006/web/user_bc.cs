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
   public class user_bc : GxSilentTrn, IGxSilentTrn
   {
      public user_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public user_bc( IGxContext context )
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
         ReadRow0416( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0416( ) ;
         standaloneModal( ) ;
         AddRow0416( ) ;
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
               Z99UserId = A99UserId;
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
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0416( ) ;
            }
            else
            {
               CheckExtendedTable0416( ) ;
               if ( AnyError == 0 )
               {
                  ZM0416( 8) ;
               }
               CloseExtendedTableCursors0416( ) ;
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
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( (0==AV11UserId) )
         {
            AV11UserId = AV14Context.gxTpr_Userid;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "user view") )
         {
            if ( AV11UserId != AV14Context.gxTpr_Userid )
            {
               CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "user insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "user update") )
         {
            if ( AV11UserId != AV14Context.gxTpr_Userid )
            {
               CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "user delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV28AuxUserName = A100UserName;
            AV29AuxUserEmail = A137UserEmail;
            AV32AuxRoleId = A104RoleId;
         }
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV21UserName = A100UserName;
         AV16UserEmail = A137UserEmail;
         AV27UserActive = A111UserActive;
         AV34RoleId = A104RoleId;
         AV26RolName = A105RoleName;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean2 = false;
            new user_resetpassword(context ).execute(  A99UserId, out  GXt_boolean2) ;
            /* Execute user subroutine: 'PREPARENOTIFICATIONINSERT' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            /* Execute user subroutine: 'WASCHANGED' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV35WasChanged )
            {
               /* Execute user subroutine: 'PREPARENOTIFICATIONUPDATE' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /* Execute user subroutine: 'SENDNOTIFICATION' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SENDNOTIFICATION' Routine */
         returnInSub = false;
         AV19URLs.Clear();
         AV20Names.Clear();
         new sendemailprepareheader(context ).execute(  AV24EmailTitle,  AV25EmailSubtitle,  AV17EmailBody, out  AV18EmailBodyAux) ;
         AV17EmailBody = AV18EmailBodyAux;
         new sendemail(context ).execute(  AV16UserEmail, ref  AV17EmailBody, ref  AV36EmailSubject, ref  AV19URLs, ref  AV20Names, ref  AV15AllOk) ;
      }

      protected void S112( )
      {
         /* 'PREPARENOTIFICATIONINSERT' Routine */
         returnInSub = false;
         AV36EmailSubject = "User Generated";
         AV24EmailTitle = "User Generated";
         AV25EmailSubtitle = "An User was Generated with the next information";
         AV22USerCreatedDAte = DateTimeUtil.ServerDate( context, pr_default);
         AV17EmailBody = "";
         AV17EmailBody = "                <table class=\"table table-border table-striped\">";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AV17EmailBody += "                        <td>" + AV16UserEmail + "</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>User Name</strong></td>";
         AV17EmailBody += "                        <td>" + AV21UserName + "</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += context.localUtil.DToC( AV22USerCreatedDAte, 1, "/");
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Rol</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += AV26RolName;
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>State</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += (AV27UserActive ? "Enabled" : "Disabled");
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                </table>";
      }

      protected void S132( )
      {
         /* 'PREPARENOTIFICATIONUPDATE' Routine */
         returnInSub = false;
         AV36EmailSubject = "User Modified";
         AV24EmailTitle = "User Modified";
         AV25EmailSubtitle = "The information of the you user has been modified";
         AV22USerCreatedDAte = DateTimeUtil.ServerDate( context, pr_default);
         AV17EmailBody = "                <table class=\"table table-border table-striped\">";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AV17EmailBody += "                        <td>" + AV16UserEmail + "</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>User Name</strong></td>";
         AV17EmailBody += "                        <td>" + AV21UserName + "</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += context.localUtil.DToC( AV22USerCreatedDAte, 1, "/");
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Rol</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += AV26RolName;
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                    <tr>";
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>State</strong></td>";
         AV17EmailBody += "                        <td>";
         AV17EmailBody += (AV27UserActive ? "Enabled" : "Disabled");
         AV17EmailBody += "					</td>";
         AV17EmailBody += "                    </tr>";
         AV17EmailBody += "                </table>";
      }

      protected void S122( )
      {
         /* 'WASCHANGED' Routine */
         returnInSub = false;
         AV35WasChanged = false;
         if ( AV32AuxRoleId != AV34RoleId )
         {
            AV35WasChanged = true;
         }
         if ( StringUtil.StrCmp(AV29AuxUserEmail, AV16UserEmail) != 0 )
         {
            AV35WasChanged = true;
         }
         if ( StringUtil.StrCmp(AV28AuxUserName, AV21UserName) != 0 )
         {
            AV35WasChanged = true;
         }
      }

      protected void ZM0416( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z137UserEmail = A137UserEmail;
            Z100UserName = A100UserName;
            Z101UserPassword = A101UserPassword;
            Z109UserHash = A109UserHash;
            Z102UserCreatedDate = A102UserCreatedDate;
            Z103UserModifiedDate = A103UserModifiedDate;
            Z111UserActive = A111UserActive;
            Z104RoleId = A104RoleId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z105RoleName = A105RoleName;
         }
         if ( GX_JID == -6 )
         {
            Z99UserId = A99UserId;
            Z137UserEmail = A137UserEmail;
            Z100UserName = A100UserName;
            Z101UserPassword = A101UserPassword;
            Z109UserHash = A109UserHash;
            Z102UserCreatedDate = A102UserCreatedDate;
            Z103UserModifiedDate = A103UserModifiedDate;
            Z111UserActive = A111UserActive;
            Z104RoleId = A104RoleId;
            Z105RoleName = A105RoleName;
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
            A102UserCreatedDate = Gx_date;
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               A102UserCreatedDate = Gx_date;
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0416( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A99UserId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound16 = 1;
            A137UserEmail = BC00045_A137UserEmail[0];
            n137UserEmail = BC00045_n137UserEmail[0];
            A100UserName = BC00045_A100UserName[0];
            A101UserPassword = BC00045_A101UserPassword[0];
            A109UserHash = BC00045_A109UserHash[0];
            A102UserCreatedDate = BC00045_A102UserCreatedDate[0];
            A103UserModifiedDate = BC00045_A103UserModifiedDate[0];
            A105RoleName = BC00045_A105RoleName[0];
            A111UserActive = BC00045_A111UserActive[0];
            n111UserActive = BC00045_n111UserActive[0];
            A104RoleId = BC00045_A104RoleId[0];
            n104RoleId = BC00045_n104RoleId[0];
            ZM0416( -6) ;
         }
         pr_default.close(3);
         OnLoadActions0416( ) ;
      }

      protected void OnLoadActions0416( )
      {
         AV38Pgmname = "User_BC";
      }

      protected void CheckExtendedTable0416( )
      {
         nIsDirty_16 = 0;
         standaloneModal( ) ;
         AV38Pgmname = "User_BC";
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A100UserName, A99UserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"User Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( ! ( GxRegex.IsMatch(A137UserEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) ) )
         {
            GX_msglist.addItem("Field User Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) )
         {
            GX_msglist.addItem("Email is required", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A102UserCreatedDate) || ( DateTimeUtil.ResetTime ( A102UserCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field User Created Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A103UserModifiedDate) || ( DateTimeUtil.ResetTime ( A103UserModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field User Modified Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A104RoleId) ) )
            {
               GX_msglist.addItem("No matching 'Role'.", "ForeignKeyNotFound", 1, "ROLEID");
               AnyError = 1;
            }
         }
         A105RoleName = BC00044_A105RoleName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0416( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0416( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A99UserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A99UserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0416( 6) ;
            RcdFound16 = 1;
            A99UserId = BC00043_A99UserId[0];
            A137UserEmail = BC00043_A137UserEmail[0];
            n137UserEmail = BC00043_n137UserEmail[0];
            A100UserName = BC00043_A100UserName[0];
            A101UserPassword = BC00043_A101UserPassword[0];
            A109UserHash = BC00043_A109UserHash[0];
            A102UserCreatedDate = BC00043_A102UserCreatedDate[0];
            A103UserModifiedDate = BC00043_A103UserModifiedDate[0];
            A111UserActive = BC00043_A111UserActive[0];
            n111UserActive = BC00043_n111UserActive[0];
            A104RoleId = BC00043_A104RoleId[0];
            n104RoleId = BC00043_n104RoleId[0];
            Z99UserId = A99UserId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0416( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0416( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0416( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0416( ) ;
         if ( RcdFound16 == 0 )
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

      protected void CheckOptimisticConcurrency0416( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A99UserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"User"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z137UserEmail, BC00042_A137UserEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z100UserName, BC00042_A100UserName[0]) != 0 ) || ( StringUtil.StrCmp(Z101UserPassword, BC00042_A101UserPassword[0]) != 0 ) || ( StringUtil.StrCmp(Z109UserHash, BC00042_A109UserHash[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z102UserCreatedDate ) != DateTimeUtil.ResetTime ( BC00042_A102UserCreatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z103UserModifiedDate ) != DateTimeUtil.ResetTime ( BC00042_A103UserModifiedDate[0] ) ) || ( Z111UserActive != BC00042_A111UserActive[0] ) || ( Z104RoleId != BC00042_A104RoleId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"User"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0416( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0416( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0416( 0) ;
            CheckOptimisticConcurrency0416( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0416( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0416( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00048 */
                     pr_default.execute(6, new Object[] {n137UserEmail, A137UserEmail, A100UserName, A101UserPassword, A109UserHash, A102UserCreatedDate, A103UserModifiedDate, n111UserActive, A111UserActive, n104RoleId, A104RoleId});
                     A99UserId = BC00048_A99UserId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("User");
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
               Load0416( ) ;
            }
            EndLevel0416( ) ;
         }
         CloseExtendedTableCursors0416( ) ;
      }

      protected void Update0416( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0416( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0416( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0416( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0416( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {n137UserEmail, A137UserEmail, A100UserName, A101UserPassword, A109UserHash, A102UserCreatedDate, A103UserModifiedDate, n111UserActive, A111UserActive, n104RoleId, A104RoleId, A99UserId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("User");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"User"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0416( ) ;
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
            EndLevel0416( ) ;
         }
         CloseExtendedTableCursors0416( ) ;
      }

      protected void DeferredUpdate0416( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0416( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0416( ) ;
            AfterConfirm0416( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0416( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000410 */
                  pr_default.execute(8, new Object[] {A99UserId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("User");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0416( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0416( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV38Pgmname = "User_BC";
            /* Using cursor BC000411 */
            pr_default.execute(9, new Object[] {n104RoleId, A104RoleId});
            A105RoleName = BC000411_A105RoleName[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000412 */
            pr_default.execute(10, new Object[] {A99UserId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invoice"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0416( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0416( ) ;
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

      public void ScanKeyStart0416( )
      {
         /* Scan By routine */
         /* Using cursor BC000413 */
         pr_default.execute(11, new Object[] {A99UserId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound16 = 1;
            A99UserId = BC000413_A99UserId[0];
            A137UserEmail = BC000413_A137UserEmail[0];
            n137UserEmail = BC000413_n137UserEmail[0];
            A100UserName = BC000413_A100UserName[0];
            A101UserPassword = BC000413_A101UserPassword[0];
            A109UserHash = BC000413_A109UserHash[0];
            A102UserCreatedDate = BC000413_A102UserCreatedDate[0];
            A103UserModifiedDate = BC000413_A103UserModifiedDate[0];
            A105RoleName = BC000413_A105RoleName[0];
            A111UserActive = BC000413_A111UserActive[0];
            n111UserActive = BC000413_n111UserActive[0];
            A104RoleId = BC000413_A104RoleId[0];
            n104RoleId = BC000413_n104RoleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0416( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound16 = 0;
         ScanKeyLoad0416( ) ;
      }

      protected void ScanKeyLoad0416( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound16 = 1;
            A99UserId = BC000413_A99UserId[0];
            A137UserEmail = BC000413_A137UserEmail[0];
            n137UserEmail = BC000413_n137UserEmail[0];
            A100UserName = BC000413_A100UserName[0];
            A101UserPassword = BC000413_A101UserPassword[0];
            A109UserHash = BC000413_A109UserHash[0];
            A102UserCreatedDate = BC000413_A102UserCreatedDate[0];
            A103UserModifiedDate = BC000413_A103UserModifiedDate[0];
            A105RoleName = BC000413_A105RoleName[0];
            A111UserActive = BC000413_A111UserActive[0];
            n111UserActive = BC000413_n111UserActive[0];
            A104RoleId = BC000413_A104RoleId[0];
            n104RoleId = BC000413_n104RoleId[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0416( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0416( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0416( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0416( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0416( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0416( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0416( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0416( )
      {
      }

      protected void send_integrity_lvl_hashes0416( )
      {
      }

      protected void AddRow0416( )
      {
         VarsToRow16( bcUser) ;
      }

      protected void ReadRow0416( )
      {
         RowToVars16( bcUser, 1) ;
      }

      protected void InitializeNonKey0416( )
      {
         A137UserEmail = "";
         n137UserEmail = false;
         A100UserName = "";
         A101UserPassword = "";
         A109UserHash = "";
         A102UserCreatedDate = DateTime.MinValue;
         A103UserModifiedDate = DateTime.MinValue;
         A104RoleId = 0;
         n104RoleId = false;
         A105RoleName = "";
         A111UserActive = false;
         n111UserActive = false;
         Z137UserEmail = "";
         Z100UserName = "";
         Z101UserPassword = "";
         Z109UserHash = "";
         Z102UserCreatedDate = DateTime.MinValue;
         Z103UserModifiedDate = DateTime.MinValue;
         Z111UserActive = false;
         Z104RoleId = 0;
      }

      protected void InitAll0416( )
      {
         A99UserId = 0;
         InitializeNonKey0416( ) ;
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

      public void VarsToRow16( SdtUser obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Useremail = A137UserEmail;
         obj16.gxTpr_Username = A100UserName;
         obj16.gxTpr_Userpassword = A101UserPassword;
         obj16.gxTpr_Userhash = A109UserHash;
         obj16.gxTpr_Usercreateddate = A102UserCreatedDate;
         obj16.gxTpr_Usermodifieddate = A103UserModifiedDate;
         obj16.gxTpr_Roleid = A104RoleId;
         obj16.gxTpr_Rolename = A105RoleName;
         obj16.gxTpr_Useractive = A111UserActive;
         obj16.gxTpr_Userid = A99UserId;
         obj16.gxTpr_Userid_Z = Z99UserId;
         obj16.gxTpr_Useremail_Z = Z137UserEmail;
         obj16.gxTpr_Username_Z = Z100UserName;
         obj16.gxTpr_Userpassword_Z = Z101UserPassword;
         obj16.gxTpr_Userhash_Z = Z109UserHash;
         obj16.gxTpr_Usercreateddate_Z = Z102UserCreatedDate;
         obj16.gxTpr_Usermodifieddate_Z = Z103UserModifiedDate;
         obj16.gxTpr_Roleid_Z = Z104RoleId;
         obj16.gxTpr_Rolename_Z = Z105RoleName;
         obj16.gxTpr_Useractive_Z = Z111UserActive;
         obj16.gxTpr_Useremail_N = (short)(Convert.ToInt16(n137UserEmail));
         obj16.gxTpr_Roleid_N = (short)(Convert.ToInt16(n104RoleId));
         obj16.gxTpr_Useractive_N = (short)(Convert.ToInt16(n111UserActive));
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtUser obj16 )
      {
         obj16.gxTpr_Userid = A99UserId;
         return  ;
      }

      public void RowToVars16( SdtUser obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A137UserEmail = obj16.gxTpr_Useremail;
         n137UserEmail = false;
         A100UserName = obj16.gxTpr_Username;
         A101UserPassword = obj16.gxTpr_Userpassword;
         A109UserHash = obj16.gxTpr_Userhash;
         A102UserCreatedDate = obj16.gxTpr_Usercreateddate;
         A103UserModifiedDate = obj16.gxTpr_Usermodifieddate;
         A104RoleId = obj16.gxTpr_Roleid;
         n104RoleId = false;
         A105RoleName = obj16.gxTpr_Rolename;
         A111UserActive = obj16.gxTpr_Useractive;
         n111UserActive = false;
         A99UserId = obj16.gxTpr_Userid;
         Z99UserId = obj16.gxTpr_Userid_Z;
         Z137UserEmail = obj16.gxTpr_Useremail_Z;
         Z100UserName = obj16.gxTpr_Username_Z;
         Z101UserPassword = obj16.gxTpr_Userpassword_Z;
         Z109UserHash = obj16.gxTpr_Userhash_Z;
         Z102UserCreatedDate = obj16.gxTpr_Usercreateddate_Z;
         Z103UserModifiedDate = obj16.gxTpr_Usermodifieddate_Z;
         Z104RoleId = obj16.gxTpr_Roleid_Z;
         Z105RoleName = obj16.gxTpr_Rolename_Z;
         Z111UserActive = obj16.gxTpr_Useractive_Z;
         n137UserEmail = (bool)(Convert.ToBoolean(obj16.gxTpr_Useremail_N));
         n104RoleId = (bool)(Convert.ToBoolean(obj16.gxTpr_Roleid_N));
         n111UserActive = (bool)(Convert.ToBoolean(obj16.gxTpr_Useractive_N));
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A99UserId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0416( ) ;
         ScanKeyStart0416( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z99UserId = A99UserId;
         }
         ZM0416( -6) ;
         OnLoadActions0416( ) ;
         AddRow0416( ) ;
         ScanKeyEnd0416( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcUser, 0) ;
         ScanKeyStart0416( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z99UserId = A99UserId;
         }
         ZM0416( -6) ;
         OnLoadActions0416( ) ;
         AddRow0416( ) ;
         ScanKeyEnd0416( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0416( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0416( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A99UserId != Z99UserId )
               {
                  A99UserId = Z99UserId;
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
                  Update0416( ) ;
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
                  if ( A99UserId != Z99UserId )
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
                        Insert0416( ) ;
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
                        Insert0416( ) ;
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
         RowToVars16( bcUser, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcUser) ;
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
         RowToVars16( bcUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0416( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcUser) ;
         }
         else
         {
            SdtUser auxBC = new SdtUser(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A99UserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUser);
               auxBC.Save();
               bcUser.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars16( bcUser, 1) ;
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
         RowToVars16( bcUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0416( ) ;
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
               VarsToRow16( bcUser) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcUser) ;
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
         RowToVars16( bcUser, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0416( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A99UserId != Z99UserId )
            {
               A99UserId = Z99UserId;
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
            if ( A99UserId != Z99UserId )
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
         context.RollbackDataStores("user_bc",pr_default);
         VarsToRow16( bcUser) ;
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
         Gx_mode = bcUser.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUser.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUser )
         {
            bcUser = (SdtUser)(sdt);
            if ( StringUtil.StrCmp(bcUser.gxTpr_Mode, "") == 0 )
            {
               bcUser.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcUser) ;
            }
            else
            {
               RowToVars16( bcUser, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUser.gxTpr_Mode, "") == 0 )
            {
               bcUser.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcUser, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUser User_BC
      {
         get {
            return bcUser ;
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
         AV14Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV38Pgmname = "";
         AV28AuxUserName = "";
         A100UserName = "";
         AV29AuxUserEmail = "";
         A137UserEmail = "";
         AV21UserName = "";
         AV16UserEmail = "";
         AV26RolName = "";
         A105RoleName = "";
         AV19URLs = new GxSimpleCollection<string>();
         AV20Names = new GxSimpleCollection<string>();
         AV24EmailTitle = "";
         AV25EmailSubtitle = "";
         AV17EmailBody = "";
         AV18EmailBodyAux = "";
         AV36EmailSubject = "";
         AV22USerCreatedDAte = DateTime.MinValue;
         Z137UserEmail = "";
         Z100UserName = "";
         Z101UserPassword = "";
         A101UserPassword = "";
         Z109UserHash = "";
         A109UserHash = "";
         Z102UserCreatedDate = DateTime.MinValue;
         A102UserCreatedDate = DateTime.MinValue;
         Z103UserModifiedDate = DateTime.MinValue;
         A103UserModifiedDate = DateTime.MinValue;
         Z105RoleName = "";
         Gx_date = DateTime.MinValue;
         BC00045_A99UserId = new int[1] ;
         BC00045_A137UserEmail = new string[] {""} ;
         BC00045_n137UserEmail = new bool[] {false} ;
         BC00045_A100UserName = new string[] {""} ;
         BC00045_A101UserPassword = new string[] {""} ;
         BC00045_A109UserHash = new string[] {""} ;
         BC00045_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00045_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00045_A105RoleName = new string[] {""} ;
         BC00045_A111UserActive = new bool[] {false} ;
         BC00045_n111UserActive = new bool[] {false} ;
         BC00045_A104RoleId = new int[1] ;
         BC00045_n104RoleId = new bool[] {false} ;
         BC00046_A100UserName = new string[] {""} ;
         BC00044_A105RoleName = new string[] {""} ;
         BC00047_A99UserId = new int[1] ;
         BC00043_A99UserId = new int[1] ;
         BC00043_A137UserEmail = new string[] {""} ;
         BC00043_n137UserEmail = new bool[] {false} ;
         BC00043_A100UserName = new string[] {""} ;
         BC00043_A101UserPassword = new string[] {""} ;
         BC00043_A109UserHash = new string[] {""} ;
         BC00043_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00043_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00043_A111UserActive = new bool[] {false} ;
         BC00043_n111UserActive = new bool[] {false} ;
         BC00043_A104RoleId = new int[1] ;
         BC00043_n104RoleId = new bool[] {false} ;
         sMode16 = "";
         BC00042_A99UserId = new int[1] ;
         BC00042_A137UserEmail = new string[] {""} ;
         BC00042_n137UserEmail = new bool[] {false} ;
         BC00042_A100UserName = new string[] {""} ;
         BC00042_A101UserPassword = new string[] {""} ;
         BC00042_A109UserHash = new string[] {""} ;
         BC00042_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00042_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00042_A111UserActive = new bool[] {false} ;
         BC00042_n111UserActive = new bool[] {false} ;
         BC00042_A104RoleId = new int[1] ;
         BC00042_n104RoleId = new bool[] {false} ;
         BC00048_A99UserId = new int[1] ;
         BC000411_A105RoleName = new string[] {""} ;
         BC000412_A20InvoiceId = new int[1] ;
         BC000413_A99UserId = new int[1] ;
         BC000413_A137UserEmail = new string[] {""} ;
         BC000413_n137UserEmail = new bool[] {false} ;
         BC000413_A100UserName = new string[] {""} ;
         BC000413_A101UserPassword = new string[] {""} ;
         BC000413_A109UserHash = new string[] {""} ;
         BC000413_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000413_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000413_A105RoleName = new string[] {""} ;
         BC000413_A111UserActive = new bool[] {false} ;
         BC000413_n111UserActive = new bool[] {false} ;
         BC000413_A104RoleId = new int[1] ;
         BC000413_n104RoleId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.user_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A99UserId, BC00042_A137UserEmail, BC00042_n137UserEmail, BC00042_A100UserName, BC00042_A101UserPassword, BC00042_A109UserHash, BC00042_A102UserCreatedDate, BC00042_A103UserModifiedDate, BC00042_A111UserActive, BC00042_n111UserActive,
               BC00042_A104RoleId, BC00042_n104RoleId
               }
               , new Object[] {
               BC00043_A99UserId, BC00043_A137UserEmail, BC00043_n137UserEmail, BC00043_A100UserName, BC00043_A101UserPassword, BC00043_A109UserHash, BC00043_A102UserCreatedDate, BC00043_A103UserModifiedDate, BC00043_A111UserActive, BC00043_n111UserActive,
               BC00043_A104RoleId, BC00043_n104RoleId
               }
               , new Object[] {
               BC00044_A105RoleName
               }
               , new Object[] {
               BC00045_A99UserId, BC00045_A137UserEmail, BC00045_n137UserEmail, BC00045_A100UserName, BC00045_A101UserPassword, BC00045_A109UserHash, BC00045_A102UserCreatedDate, BC00045_A103UserModifiedDate, BC00045_A105RoleName, BC00045_A111UserActive,
               BC00045_n111UserActive, BC00045_A104RoleId, BC00045_n104RoleId
               }
               , new Object[] {
               BC00046_A100UserName
               }
               , new Object[] {
               BC00047_A99UserId
               }
               , new Object[] {
               BC00048_A99UserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000411_A105RoleName
               }
               , new Object[] {
               BC000412_A20InvoiceId
               }
               , new Object[] {
               BC000413_A99UserId, BC000413_A137UserEmail, BC000413_n137UserEmail, BC000413_A100UserName, BC000413_A101UserPassword, BC000413_A109UserHash, BC000413_A102UserCreatedDate, BC000413_A103UserModifiedDate, BC000413_A105RoleName, BC000413_A111UserActive,
               BC000413_n111UserActive, BC000413_A104RoleId, BC000413_n104RoleId
               }
            }
         );
         AV38Pgmname = "User_BC";
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
      private short RcdFound16 ;
      private short nIsDirty_16 ;
      private int trnEnded ;
      private int Z99UserId ;
      private int A99UserId ;
      private int AV11UserId ;
      private int AV32AuxRoleId ;
      private int A104RoleId ;
      private int AV34RoleId ;
      private int Z104RoleId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV38Pgmname ;
      private string sMode16 ;
      private DateTime AV22USerCreatedDAte ;
      private DateTime Z102UserCreatedDate ;
      private DateTime A102UserCreatedDate ;
      private DateTime Z103UserModifiedDate ;
      private DateTime A103UserModifiedDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV27UserActive ;
      private bool A111UserActive ;
      private bool GXt_boolean2 ;
      private bool AV35WasChanged ;
      private bool AV15AllOk ;
      private bool Z111UserActive ;
      private bool n137UserEmail ;
      private bool n111UserActive ;
      private bool n104RoleId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string AV28AuxUserName ;
      private string A100UserName ;
      private string AV29AuxUserEmail ;
      private string A137UserEmail ;
      private string AV21UserName ;
      private string AV16UserEmail ;
      private string AV26RolName ;
      private string A105RoleName ;
      private string AV24EmailTitle ;
      private string AV25EmailSubtitle ;
      private string AV17EmailBody ;
      private string AV18EmailBodyAux ;
      private string AV36EmailSubject ;
      private string Z137UserEmail ;
      private string Z100UserName ;
      private string Z101UserPassword ;
      private string A101UserPassword ;
      private string Z109UserHash ;
      private string A109UserHash ;
      private string Z105RoleName ;
      private SdtUser bcUser ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00045_A99UserId ;
      private string[] BC00045_A137UserEmail ;
      private bool[] BC00045_n137UserEmail ;
      private string[] BC00045_A100UserName ;
      private string[] BC00045_A101UserPassword ;
      private string[] BC00045_A109UserHash ;
      private DateTime[] BC00045_A102UserCreatedDate ;
      private DateTime[] BC00045_A103UserModifiedDate ;
      private string[] BC00045_A105RoleName ;
      private bool[] BC00045_A111UserActive ;
      private bool[] BC00045_n111UserActive ;
      private int[] BC00045_A104RoleId ;
      private bool[] BC00045_n104RoleId ;
      private string[] BC00046_A100UserName ;
      private string[] BC00044_A105RoleName ;
      private int[] BC00047_A99UserId ;
      private int[] BC00043_A99UserId ;
      private string[] BC00043_A137UserEmail ;
      private bool[] BC00043_n137UserEmail ;
      private string[] BC00043_A100UserName ;
      private string[] BC00043_A101UserPassword ;
      private string[] BC00043_A109UserHash ;
      private DateTime[] BC00043_A102UserCreatedDate ;
      private DateTime[] BC00043_A103UserModifiedDate ;
      private bool[] BC00043_A111UserActive ;
      private bool[] BC00043_n111UserActive ;
      private int[] BC00043_A104RoleId ;
      private bool[] BC00043_n104RoleId ;
      private int[] BC00042_A99UserId ;
      private string[] BC00042_A137UserEmail ;
      private bool[] BC00042_n137UserEmail ;
      private string[] BC00042_A100UserName ;
      private string[] BC00042_A101UserPassword ;
      private string[] BC00042_A109UserHash ;
      private DateTime[] BC00042_A102UserCreatedDate ;
      private DateTime[] BC00042_A103UserModifiedDate ;
      private bool[] BC00042_A111UserActive ;
      private bool[] BC00042_n111UserActive ;
      private int[] BC00042_A104RoleId ;
      private bool[] BC00042_n104RoleId ;
      private int[] BC00048_A99UserId ;
      private string[] BC000411_A105RoleName ;
      private int[] BC000412_A20InvoiceId ;
      private int[] BC000413_A99UserId ;
      private string[] BC000413_A137UserEmail ;
      private bool[] BC000413_n137UserEmail ;
      private string[] BC000413_A100UserName ;
      private string[] BC000413_A101UserPassword ;
      private string[] BC000413_A109UserHash ;
      private DateTime[] BC000413_A102UserCreatedDate ;
      private DateTime[] BC000413_A103UserModifiedDate ;
      private string[] BC000413_A105RoleName ;
      private bool[] BC000413_A111UserActive ;
      private bool[] BC000413_n111UserActive ;
      private int[] BC000413_A104RoleId ;
      private bool[] BC000413_n104RoleId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV19URLs ;
      private GxSimpleCollection<string> AV20Names ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV14Context ;
   }

   public class user_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@UserEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@UserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@UserActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@UserEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@UserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@UserActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmBC000413;
          prmBC000413 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [UserId], [UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId] FROM [User] WITH (UPDLOCK) WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [UserId], [UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT TM1.[UserId], TM1.[UserEmail], TM1.[UserName], TM1.[UserPassword], TM1.[UserHash], TM1.[UserCreatedDate], TM1.[UserModifiedDate], T2.[RoleName], TM1.[UserActive], TM1.[RoleId] FROM ([User] TM1 LEFT JOIN [Role] T2 ON T2.[RoleId] = TM1.[RoleId]) WHERE TM1.[UserId] = @UserId ORDER BY TM1.[UserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT [UserName] FROM [User] WHERE ([UserName] = @UserName) AND (Not ( [UserId] = @UserId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00047", "SELECT [UserId] FROM [User] WHERE [UserId] = @UserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "INSERT INTO [User]([UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId]) VALUES(@UserEmail, @UserName, @UserPassword, @UserHash, @UserCreatedDate, @UserModifiedDate, @UserActive, @RoleId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00049", "UPDATE [User] SET [UserEmail]=@UserEmail, [UserName]=@UserName, [UserPassword]=@UserPassword, [UserHash]=@UserHash, [UserCreatedDate]=@UserCreatedDate, [UserModifiedDate]=@UserModifiedDate, [UserActive]=@UserActive, [RoleId]=@RoleId  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK,prmBC00049)
             ,new CursorDef("BC000410", "DELETE FROM [User]  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK,prmBC000410)
             ,new CursorDef("BC000411", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000412", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000413", "SELECT TM1.[UserId], TM1.[UserEmail], TM1.[UserName], TM1.[UserPassword], TM1.[UserHash], TM1.[UserCreatedDate], TM1.[UserModifiedDate], T2.[RoleName], TM1.[UserActive], TM1.[RoleId] FROM ([User] TM1 LEFT JOIN [Role] T2 ON T2.[RoleId] = TM1.[RoleId]) WHERE TM1.[UserId] = @UserId ORDER BY TM1.[UserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
