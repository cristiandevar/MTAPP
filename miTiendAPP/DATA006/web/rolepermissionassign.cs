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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class rolepermissionassign : GXWebComponent
   {
      public rolepermissionassign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
      }

      public rolepermissionassign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_RoleId )
      {
         this.AV6RoleId = aP0_RoleId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkavCtlselected = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "RoleId");
               gxfirstwebparm_bkp = gxfirstwebparm;
               gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  dyncall( GetNextPar( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV6RoleId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
               {
                  gxnrGrid1_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
               {
                  gxgrGrid1_refresh_invoke( ) ;
                  return  ;
               }
               else
               {
                  if ( ! IsValidAjaxCall( false) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = gxfirstwebparm_bkp;
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_25 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_25"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_25_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_25_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_25_idx = GetPar( "sGXsfl_25_idx");
         sPrefix = GetPar( "sPrefix");
         AV12Update = GetPar( "Update");
         edtavUpdate_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_25_Refreshing);
         edtavUpdate_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         AV13Delete = GetPar( "Delete");
         edtavDelete_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12Update = GetPar( "Update");
         edtavUpdate_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_25_Refreshing);
         edtavUpdate_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         AV13Delete = GetPar( "Delete");
         edtavDelete_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19SDTPermission);
         A104RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_32 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_32"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_32_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_32_idx = GetPar( "sGXsfl_32_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19SDTPermission);
         A104RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV30Pgmname = "RolePermissionAssign";
               context.Gx_err = 0;
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               edtavCtlpermissionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavCtlpermissionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpermissionid_Enabled), 5, 0), !bGXsfl_32_Refreshing);
               WS3H2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Role Permission Assign") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1853160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rolepermissionassign.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6RoleId,6,0))}, new string[] {"RoleId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTPERMISSION", GetSecureSignedToken( sPrefix, AV19SDTPermission, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ROLEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"RolePermissionAssign");
         forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rolepermissionassign:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdtpermission", AV19SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdtpermission", AV19SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_Sdtpermission", GetSecureSignedToken( sPrefix, AV19SDTPermission, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_32", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_32), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PERMISSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vACTIVE", AV17Active);
         GxWebStd.gx_hidden_field( context, sPrefix+"vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RoleId), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTPERMISSION", GetSecureSignedToken( sPrefix, AV19SDTPermission, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUPDATE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUPDATE_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETE_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3H2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "RolePermissionAssign" ;
      }

      public override string GetPgmdesc( )
      {
         return "Role Permission Assign" ;
      }

      protected void WB3H0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "rolepermissionassign.aspx");
               context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
               context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "ww__view__grid-table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ww__grid-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__view__grid__actions-cell", "left", "top", "", "", "div");
            context.WriteHtmlText( "<nav class=\"navbar navbar-default gx-navbar  ww__view__actions\" data-gx-actiongroup-type=\"menu\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "container-fluid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "navbar-header", "left", "top", "", "", "div");
            context.WriteHtmlText( "<button type=\"button\" class=\"navbar-toggle collapsed gx-navbar-toggle\" data-toggle=\"collapse\" aria-expanded=\"false\">") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "</button>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lbllbl13_Internalname, "", "", "", lbllbl13_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "navbar-brand", 0, "", 1, 1, 0, 0, "HLP_RolePermissionAssign.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_inner_Internalname, 1, 0, "px", 0, "px", "collapse navbar-collapse gx-navbar-inner", "left", "top", "", "", "div");
            context.WriteHtmlText( "<ul class=\"nav navbar-nav\">") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Export", bttBtnexport_Jsonclick, 5, "Export to Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolePermissionAssign.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButton1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Confirm", bttButton1_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RolePermissionAssign.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "</ul>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</nav>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl25( ) ;
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            nRC_GXsfl_25 = (int)(nGXsfl_25_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl32( ) ;
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            nRC_GXsfl_32 = (int)(nGXsfl_32_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               AV26GXV1 = nGXsfl_32_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A104RoleId), 6, 0, ".", "")), StringUtil.LTrim( ((edtRoleId_Enabled!=0) ? context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRoleId_Jsonclick, 0, "Attribute", "", "", "", "", edtRoleId_Visible, edtRoleId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_RolePermissionAssign.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  AV26GXV1 = nGXsfl_32_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3H2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
               }
               Form.Meta.addItem("description", "Role Permission Assign", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3H0( ) ;
            }
         }
      }

      protected void WS3H2( )
      {
         START3H2( ) ;
         EVT3H2( ) ;
      }

      protected void EVT3H2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VACTIVE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E113H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Confirm' */
                                    E123H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
                              SubsflControlProps_326( ) ;
                              AV26GXV1 = (int)(nGXsfl_32_idx+GRID1_nFirstRecordOnPage);
                              if ( ( AV19SDTPermission.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
                              {
                                 AV19SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E133H6 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3H0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "VACTIVE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              nGXsfl_25_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
                              SubsflControlProps_252( ) ;
                              GXCCtl = "ACTIVE_Enabled_" + sGXsfl_25_idx;
                              Active_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
                              AssignProp(sPrefix, false, Active_Internalname, "Enabled", StringUtil.BoolToStr( Active_Enabled), true);
                              A107PermissionName = cgiGet( edtPermissionName_Internalname);
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
                              GXCCtl = "vACTIVE_" + sGXsfl_25_idx;
                              AV17Active = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E143H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E153H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIVE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E113H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3H0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3H2( ) ;
            }
         }
      }

      protected void PA3H2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_252( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            sendrow_252( ) ;
            nGXsfl_25_idx = ((subGrid_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_326( ) ;
         while ( nGXsfl_32_idx <= nRC_GXsfl_32 )
         {
            sendrow_326( ) ;
            nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_326( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int subGrid1_Rows ,
                                       string AV12Update ,
                                       string AV13Delete ,
                                       GXBaseCollection<SdtSDTPermission_SDTPermissionItem> AV19SDTPermission ,
                                       int A104RoleId ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"RolePermissionAssign");
         forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rolepermissionassign:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void gxgrGrid1_refresh( int subGrid_Rows ,
                                        int subGrid1_Rows ,
                                        GXBaseCollection<SdtSDTPermission_SDTPermissionItem> AV19SDTPermission ,
                                        int A104RoleId ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF3H6( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"RolePermissionAssign");
         forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rolepermissionassign:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3H2( ) ;
         RF3H6( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV30Pgmname = "RolePermissionAssign";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavCtlpermissionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlpermissionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpermissionid_Enabled), 5, 0), !bGXsfl_32_Refreshing);
      }

      protected void RF3H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 25;
         nGXsfl_25_idx = 1;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_252( ) ;
         bGXsfl_25_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ViewGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_252( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H003H2 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
            nGXsfl_25_idx = 1;
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A106PermissionId = H003H2_A106PermissionId[0];
               A104RoleId = H003H2_A104RoleId[0];
               AssignAttri(sPrefix, false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ROLEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"), context));
               A107PermissionName = H003H2_A107PermissionName[0];
               A107PermissionName = H003H2_A107PermissionName[0];
               E153H2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 25;
            WB3H0( ) ;
         }
         bGXsfl_25_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3H2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTPERMISSION", AV19SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSDTPERMISSION", GetSecureSignedToken( sPrefix, AV19SDTPermission, context));
      }

      protected void RF3H6( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 32;
         nGXsfl_32_idx = 1;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_326( ) ;
         bGXsfl_32_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", sPrefix);
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "ViewGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_326( ) ;
            E133H6 ();
            if ( ( subGrid1_Islastpage == 0 ) && ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_32_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               E133H6 ();
            }
            wbEnd = 32;
            WB3H0( ) ;
         }
         bGXsfl_32_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3H6( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         /* Using cursor H003H3 */
         pr_default.execute(1);
         GRID_nRecordCount = H003H3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGrid1_Rows, AV12Update, AV13Delete, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return AV19SDTPermission.Count ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid_Rows, subGrid1_Rows, AV19SDTPermission, A104RoleId, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV30Pgmname = "RolePermissionAssign";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavCtlpermissionid_Enabled = 0;
         AssignProp(sPrefix, false, edtavCtlpermissionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpermissionid_Enabled), 5, 0), !bGXsfl_32_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdtpermission"), AV19SDTPermission);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDTPERMISSION"), AV19SDTPermission);
            /* Read saved values. */
            nRC_GXsfl_25 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_25"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_32 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_32"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV6RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RoleId"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            nRC_GXsfl_32 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_32"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_32_fel_idx = 0;
            while ( nGXsfl_32_fel_idx < nRC_GXsfl_32 )
            {
               nGXsfl_32_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_fel_idx+1);
               sGXsfl_32_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_326( ) ;
               AV26GXV1 = (int)(nGXsfl_32_fel_idx+GRID1_nFirstRecordOnPage);
               if ( ( AV19SDTPermission.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
               {
                  AV19SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1));
               }
            }
            if ( nGXsfl_32_fel_idx == 0 )
            {
               nGXsfl_32_idx = 1;
               sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
               SubsflControlProps_326( ) ;
            }
            nGXsfl_32_fel_idx = 1;
            /* Read variables values. */
            A104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRoleId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ROLEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"), context));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"RolePermissionAssign");
            A104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRoleId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ROLEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"), context));
            forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("rolepermissionassign:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E143H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E143H2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new haspermission(context).executeUdp(  "permission view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV30Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         if ( new haspermission(context).executeUdp(  "permission update") )
         {
            AV12Update = "Update";
            AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
         }
         else
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_25_Refreshing);
            edtavUpdate_Enabled = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         }
         if ( new haspermission(context).executeUdp(  "permission delete") )
         {
            AV13Delete = "Delete";
            AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
         }
         else
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_25_Refreshing);
            edtavDelete_Enabled = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         }
         edtRoleId_Visible = 0;
         AssignProp(sPrefix, false, edtRoleId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRoleId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19SDTPermission = new GXBaseCollection<SdtSDTPermission_SDTPermissionItem>( context, "SDTPermissionItem", "mtaKB");
         gx_BV32 = true;
         /* Using cursor H003H4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A106PermissionId = H003H4_A106PermissionId[0];
            A107PermissionName = H003H4_A107PermissionName[0];
            AV20SDTPermissionItem = new SdtSDTPermission_SDTPermissionItem(context);
            AV20SDTPermissionItem.gxTpr_Permissionid = A106PermissionId;
            AV20SDTPermissionItem.gxTpr_Permissionname = A107PermissionName;
            if ( new haspermission(context).executeUdp(  A107PermissionName) )
            {
               AV20SDTPermissionItem.gxTpr_Selected = true;
            }
            else
            {
               AV20SDTPermissionItem.gxTpr_Selected = false;
            }
            AV19SDTPermission.Add(AV20SDTPermissionItem, 0);
            gx_BV32 = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      private void E153H2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV17Active;
         new haspermission(context ).execute(  A107PermissionName, out  GXt_boolean1) ;
         AV17Active = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV17Active", AV17Active);
         edtavUpdate_Link = formatLink("permission.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A106PermissionId,6,0))}, new string[] {"Mode","PermissionId"}) ;
         edtavDelete_Link = formatLink("permission.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A106PermissionId,6,0))}, new string[] {"Mode","PermissionId"}) ;
         if ( new haspermission(context).executeUdp(  "permission view") )
         {
            edtPermissionName_Link = formatLink("viewpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A106PermissionId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PermissionId","TabCode"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 25;
         }
         sendrow_252( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_25_Refreshing )
         {
            DoAjaxLoad(25, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E113H2( )
      {
         /* Active_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV17Active )
         {
            /* Using cursor H003H5 */
            pr_default.execute(3, new Object[] {AV6RoleId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A104RoleId = H003H5_A104RoleId[0];
               AssignAttri(sPrefix, false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_ROLEID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"), context));
               /* Using cursor H003H6 */
               pr_default.execute(4, new Object[] {A106PermissionId, A107PermissionName});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A107PermissionName = H003H6_A107PermissionName[0];
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
         else
         {
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV30Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Permission";
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "RoleId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6RoleId), 6, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void E123H2( )
      {
         AV26GXV1 = (int)(nGXsfl_32_idx+GRID1_nFirstRecordOnPage);
         if ( ( AV26GXV1 > 0 ) && ( AV19SDTPermission.Count >= AV26GXV1 ) )
         {
            AV19SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1));
         }
         /* 'Confirm' Routine */
         returnInSub = false;
         AV34GXV5 = 1;
         while ( AV34GXV5 <= AV19SDTPermission.Count )
         {
            AV20SDTPermissionItem = ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV34GXV5));
            if ( AV20SDTPermissionItem.gxTpr_Selected )
            {
               AV23RolePermission = new SdtRole_Permission(context);
               AV23RolePermission.gxTpr_Permissionid = AV20SDTPermissionItem.gxTpr_Permissionid;
               AV21Role.Load(AV6RoleId);
               AV21Role.gxTpr_Permission.Add((SdtRole_Permission)(AV23RolePermission.Clone()), 0);
               AV21Role.Update();
               if ( AV21Role.Success() )
               {
                  context.CommitDataStores("rolepermissionassign",pr_default);
               }
               else
               {
                  GX_msglist.addItem("Error al agregar: "+AV21Role.GetMessages().ToJSonString(false));
                  context.RollbackDataStores("rolepermissionassign",pr_default);
               }
            }
            else
            {
               if ( new haspermission(context).executeUdp(  AV20SDTPermissionItem.gxTpr_Permissionname) )
               {
                  AV21Role.Load(AV6RoleId);
                  AV21Role.gxTpr_Permission.RemoveByKey(AV20SDTPermissionItem.gxTpr_Permissionid) ;
                  AV21Role.Update();
                  if ( AV21Role.Success() )
                  {
                     context.CommitDataStores("rolepermissionassign",pr_default);
                  }
                  else
                  {
                     GX_msglist.addItem("Error al quitar: "+AV21Role.GetMessages().ToJSonString(false));
                     context.RollbackDataStores("rolepermissionassign",pr_default);
                  }
               }
            }
            AV34GXV5 = (int)(AV34GXV5+1);
         }
      }

      private void E133H6( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV19SDTPermission.Count )
         {
            AV19SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 32;
            }
            if ( ( subGrid1_Islastpage == 1 ) || ( subGrid1_Rows == 0 ) || ( ( GRID1_nCurrentRecord >= GRID1_nFirstRecordOnPage ) && ( GRID1_nCurrentRecord < GRID1_nFirstRecordOnPage + subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_326( ) ;
            }
            GRID1_nEOF = (short)(((GRID1_nCurrentRecord<GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_32_Refreshing )
            {
               DoAjaxLoad(32, Grid1Row);
            }
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6RoleId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 6, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA3H2( ) ;
         WS3H2( ) ;
         WE3H2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6RoleId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "rolepermissionassign", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6RoleId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 6, 0));
         }
         wcpOAV6RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RoleId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV6RoleId != wcpOAV6RoleId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6RoleId = AV6RoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6RoleId = cgiGet( sPrefix+"AV6RoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV6RoleId) > 0 )
         {
            AV6RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6RoleId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 6, 0));
         }
         else
         {
            AV6RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6RoleId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6RoleId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RoleId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6RoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6RoleId_CTRL", StringUtil.RTrim( sCtrlAV6RoleId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Switch/switch.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246100504286", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("rolepermissionassign.js", "?20246100504286", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_252( )
      {
         edtPermissionName_Internalname = sPrefix+"PERMISSIONNAME_"+sGXsfl_25_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_25_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_25_idx;
         Active_Internalname = sPrefix+"ACTIVE_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_252( )
      {
         edtPermissionName_Internalname = sPrefix+"PERMISSIONNAME_"+sGXsfl_25_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_25_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_25_fel_idx;
         Active_Internalname = sPrefix+"ACTIVE_"+sGXsfl_25_fel_idx;
      }

      protected void sendrow_252( )
      {
         SubsflControlProps_252( ) ;
         WB3H0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_25_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_25_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPermissionName_Internalname,(string)A107PermissionName,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtPermissionName_Link,(string)"",(string)"",(string)"",(string)edtPermissionName_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'"+sPrefix+"',false,'"+sGXsfl_25_idx+"',25)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,27);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 28,'"+sPrefix+"',false,'"+sGXsfl_25_idx+"',25)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,28);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td>") ;
            }
            /* User Defined Control */
            GridRow.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)sPrefix+"ACTIVEContainer"+"_"+sGXsfl_25_idx,(short)1});
            send_integrity_lvl_hashes3H2( ) ;
            GXCCtl = "vACTIVE_" + sGXsfl_25_idx;
            GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, AV17Active);
            GXCCtl = "ACTIVE_Enabled_" + sGXsfl_25_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.BoolToStr( Active_Enabled));
            GridContainer.AddRow(GridRow);
            nGXsfl_25_idx = ((subGrid_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         /* End function sendrow_252 */
      }

      protected void SubsflControlProps_326( )
      {
         edtavCtlpermissionid_Internalname = sPrefix+"CTLPERMISSIONID_"+sGXsfl_32_idx;
         edtavCtlpermissionname_Internalname = sPrefix+"CTLPERMISSIONNAME_"+sGXsfl_32_idx;
         chkavCtlselected_Internalname = sPrefix+"CTLSELECTED_"+sGXsfl_32_idx;
      }

      protected void SubsflControlProps_fel_326( )
      {
         edtavCtlpermissionid_Internalname = sPrefix+"CTLPERMISSIONID_"+sGXsfl_32_fel_idx;
         edtavCtlpermissionname_Internalname = sPrefix+"CTLPERMISSIONNAME_"+sGXsfl_32_fel_idx;
         chkavCtlselected_Internalname = sPrefix+"CTLSELECTED_"+sGXsfl_32_fel_idx;
      }

      protected void sendrow_326( )
      {
         SubsflControlProps_326( ) ;
         WB3H0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_32_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_32_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_32_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpermissionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1)).gxTpr_Permissionid), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpermissionid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1)).gxTpr_Permissionid), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1)).gxTpr_Permissionid), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpermissionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlpermissionid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavCtlpermissionname_Enabled!=0)&&(edtavCtlpermissionname_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 34,'"+sPrefix+"',false,'"+sGXsfl_32_idx+"',32)\"" : " ");
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpermissionname_Internalname,((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1)).gxTpr_Permissionname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavCtlpermissionname_Enabled!=0)&&(edtavCtlpermissionname_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,34);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpermissionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavCtlselected.Enabled!=0)&&(chkavCtlselected.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 35,'"+sPrefix+"',false,'"+sGXsfl_32_idx+"',32)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "CTLSELECTED_" + sGXsfl_32_idx;
            chkavCtlselected.Name = GXCCtl;
            chkavCtlselected.WebTags = "";
            chkavCtlselected.Caption = "";
            AssignProp(sPrefix, false, chkavCtlselected_Internalname, "TitleCaption", chkavCtlselected.Caption, !bGXsfl_32_Refreshing);
            chkavCtlselected.CheckedValue = "false";
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavCtlselected_Internalname,StringUtil.BoolToStr( ((SdtSDTPermission_SDTPermissionItem)AV19SDTPermission.Item(AV26GXV1)).gxTpr_Selected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavCtlselected.Enabled!=0)&&(chkavCtlselected.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,35);\"" : " ")});
            send_integrity_lvl_hashes3H6( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_32_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_32_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_326( ) ;
         }
         /* End function sendrow_326 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CTLSELECTED_" + sGXsfl_32_idx;
         chkavCtlselected.Name = GXCCtl;
         chkavCtlselected.WebTags = "";
         chkavCtlselected.Caption = "";
         AssignProp(sPrefix, false, chkavCtlselected_Internalname, "TitleCaption", chkavCtlselected.Caption, !bGXsfl_32_Refreshing);
         chkavCtlselected.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl25( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"25\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Permission Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ViewGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A107PermissionName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtPermissionName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl32( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Grid1Container"+"DivS\" data-gxgridid=\"32\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Permission Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Permission") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "ViewGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", sPrefix);
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpermissionid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lbllbl13_Internalname = sPrefix+"LBL13";
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         bttButton1_Internalname = sPrefix+"BUTTON1";
         divActions_inner_Internalname = sPrefix+"ACTIONS_INNER";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtPermissionName_Internalname = sPrefix+"PERMISSIONNAME";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         Active_Internalname = sPrefix+"ACTIVE";
         edtavCtlpermissionid_Internalname = sPrefix+"CTLPERMISSIONID";
         edtavCtlpermissionname_Internalname = sPrefix+"CTLPERMISSIONNAME";
         chkavCtlselected_Internalname = sPrefix+"CTLSELECTED";
         divGridcontainer_Internalname = sPrefix+"GRIDCONTAINER";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtRoleId_Internalname = sPrefix+"ROLEID";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
         subGrid1_Internalname = sPrefix+"GRID1";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavCtlselected.Caption = "";
         chkavCtlselected.Visible = -1;
         chkavCtlselected.Enabled = 1;
         edtavCtlpermissionname_Jsonclick = "";
         edtavCtlpermissionname_Visible = -1;
         edtavCtlpermissionname_Enabled = 1;
         edtavCtlpermissionid_Jsonclick = "";
         edtavCtlpermissionid_Enabled = 0;
         subGrid1_Class = "ViewGrid";
         subGrid1_Backcolorstyle = 0;
         Active_Enabled = Convert.ToBoolean( 1);
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtPermissionName_Jsonclick = "";
         edtPermissionName_Link = "";
         subGrid_Class = "ViewGrid";
         subGrid_Backcolorstyle = 0;
         edtRoleId_Jsonclick = "";
         edtRoleId_Enabled = 0;
         edtRoleId_Visible = 1;
         edtavCtlpermissionid_Enabled = -1;
         edtavDelete_Enabled = 0;
         edtavDelete_Visible = 0;
         edtavUpdate_Enabled = 0;
         edtavUpdate_Visible = 0;
         subGrid1_Rows = 0;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'sPrefix'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E153H2',iparms:[{av:'A107PermissionName',fld:'PERMISSIONNAME',pic:''},{av:'A106PermissionId',fld:'PERMISSIONID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV17Active',fld:'vACTIVE',pic:''},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtPermissionName_Link',ctrl:'PERMISSIONNAME',prop:'Link'}]}");
         setEventMetadata("VACTIVE.CONTROLVALUECHANGED","{handler:'E113H2',iparms:[{av:'AV17Active',fld:'vACTIVE',pic:''},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZ9'},{av:'A107PermissionName',fld:'PERMISSIONNAME',pic:''}]");
         setEventMetadata("VACTIVE.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("'CONFIRM'","{handler:'E123H2',iparms:[{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("'CONFIRM'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV19SDTPermission',fld:'vSDTPERMISSION',grid:32,pic:'',hsh:true},{av:'nGXsfl_32_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:32},{av:'nRC_GXsfl_32',ctrl:'GRID1',prop:'GridRC',grid:32},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9',hsh:true},{av:'sPrefix'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV12Update = "";
         AV13Delete = "";
         AV19SDTPermission = new GXBaseCollection<SdtSDTPermission_SDTPermissionItem>( context, "SDTPermissionItem", "mtaKB");
         AV30Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         lbllbl13_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnexport_Jsonclick = "";
         bttButton1_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Grid1Container = new GXWebGrid( context);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         A107PermissionName = "";
         scmdbuf = "";
         H003H2_A106PermissionId = new int[1] ;
         H003H2_A104RoleId = new int[1] ;
         H003H2_A107PermissionName = new string[] {""} ;
         H003H3_AGRID_nRecordCount = new long[1] ;
         hsh = "";
         H003H4_A106PermissionId = new int[1] ;
         H003H4_A107PermissionName = new string[] {""} ;
         AV20SDTPermissionItem = new SdtSDTPermission_SDTPermissionItem(context);
         GridRow = new GXWebRow();
         H003H5_A104RoleId = new int[1] ;
         H003H6_A106PermissionId = new int[1] ;
         H003H6_A107PermissionName = new string[] {""} ;
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         AV23RolePermission = new SdtRole_Permission(context);
         AV21Role = new SdtRole(context);
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6RoleId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         subGrid1_Linesclass = "";
         GridColumn = new GXWebColumn();
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rolepermissionassign__default(),
            new Object[][] {
                new Object[] {
               H003H2_A106PermissionId, H003H2_A104RoleId, H003H2_A107PermissionName
               }
               , new Object[] {
               H003H3_AGRID_nRecordCount
               }
               , new Object[] {
               H003H4_A106PermissionId, H003H4_A107PermissionName
               }
               , new Object[] {
               H003H5_A104RoleId
               }
               , new Object[] {
               H003H6_A106PermissionId, H003H6_A107PermissionName
               }
            }
         );
         AV30Pgmname = "RolePermissionAssign";
         /* GeneXus formulas. */
         AV30Pgmname = "RolePermissionAssign";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavCtlpermissionid_Enabled = 0;
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short GRID_nEOF ;
      private short GRID1_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV6RoleId ;
      private int wcpOAV6RoleId ;
      private int edtavUpdate_Visible ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Visible ;
      private int edtavDelete_Enabled ;
      private int nRC_GXsfl_25 ;
      private int nRC_GXsfl_32 ;
      private int subGrid_Rows ;
      private int subGrid1_Rows ;
      private int nGXsfl_25_idx=1 ;
      private int A104RoleId ;
      private int nGXsfl_32_idx=1 ;
      private int edtavCtlpermissionid_Enabled ;
      private int A106PermissionId ;
      private int AV26GXV1 ;
      private int edtRoleId_Enabled ;
      private int edtRoleId_Visible ;
      private int subGrid_Islastpage ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GRID1_nGridOutOfScope ;
      private int nGXsfl_32_fel_idx=1 ;
      private int AV34GXV5 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlpermissionname_Enabled ;
      private int edtavCtlpermissionname_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long GRID1_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_25_idx="0001" ;
      private string AV12Update ;
      private string edtavUpdate_Internalname ;
      private string AV13Delete ;
      private string edtavDelete_Internalname ;
      private string sGXsfl_32_idx="0001" ;
      private string AV30Pgmname ;
      private string edtavCtlpermissionid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lbllbl13_Internalname ;
      private string lbllbl13_Jsonclick ;
      private string divActions_inner_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string bttButton1_Internalname ;
      private string bttButton1_Jsonclick ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid1_Internalname ;
      private string edtRoleId_Internalname ;
      private string edtRoleId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string Active_Internalname ;
      private string edtPermissionName_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_32_fel_idx="0001" ;
      private string hsh ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtPermissionName_Link ;
      private string sCtrlAV6RoleId ;
      private string sGXsfl_25_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtPermissionName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtavCtlpermissionname_Internalname ;
      private string chkavCtlselected_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavCtlpermissionid_Jsonclick ;
      private string edtavCtlpermissionname_Jsonclick ;
      private string subGrid_Header ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool bGXsfl_32_Refreshing=false ;
      private bool AV17Active ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool Active_Enabled ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV32 ;
      private bool GXt_boolean1 ;
      private string A107PermissionName ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebGrid Grid1Container ;
      private GXWebRow GridRow ;
      private GXWebRow Grid1Row ;
      private GXWebColumn GridColumn ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCtlselected ;
      private IDataStoreProvider pr_default ;
      private int[] H003H2_A106PermissionId ;
      private int[] H003H2_A104RoleId ;
      private string[] H003H2_A107PermissionName ;
      private long[] H003H3_AGRID_nRecordCount ;
      private int[] H003H4_A106PermissionId ;
      private string[] H003H4_A107PermissionName ;
      private int[] H003H5_A104RoleId ;
      private int[] H003H6_A106PermissionId ;
      private string[] H003H6_A107PermissionName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private GXBaseCollection<SdtSDTPermission_SDTPermissionItem> AV19SDTPermission ;
      private SdtRole AV21Role ;
      private SdtRole_Permission AV23RolePermission ;
      private SdtSDTPermission_SDTPermissionItem AV20SDTPermissionItem ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class rolepermissionassign__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003H2;
          prmH003H2 = new Object[] {
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003H3;
          prmH003H3 = new Object[] {
          };
          Object[] prmH003H4;
          prmH003H4 = new Object[] {
          };
          Object[] prmH003H5;
          prmH003H5 = new Object[] {
          new ParDef("@AV6RoleId",GXType.Int32,6,0)
          };
          Object[] prmH003H6;
          prmH003H6 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0) ,
          new ParDef("@PermissionName",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003H2", "SELECT T1.[PermissionId], T1.[RoleId], T2.[PermissionName] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) ORDER BY T2.[PermissionName]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003H3", "SELECT COUNT(*) FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003H4", "SELECT [PermissionId], [PermissionName] FROM [Permission] ORDER BY [PermissionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003H5", "SELECT [RoleId] FROM [Role] WHERE [RoleId] = @AV6RoleId ORDER BY [RoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003H6", "SELECT [PermissionId], [PermissionName] FROM [Permission] WHERE ([PermissionId] = @PermissionId) AND ([PermissionName] = @PermissionName) ORDER BY [PermissionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
