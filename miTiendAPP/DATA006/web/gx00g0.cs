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
   public class gx00g0 : GXDataArea
   {
      public gx00g0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00g0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pUserId )
      {
         this.AV11pUserId = 0 ;
         executePrivate();
         aP0_pUserId=this.AV11pUserId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkUserActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pUserId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pUserId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pUserId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV11pUserId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pUserId", StringUtil.LTrimStr( (decimal)(AV11pUserId), 6, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cUserId = (int)(Math.Round(NumberUtil.Val( GetPar( "cUserId"), "."), 18, MidpointRounding.ToEven));
         AV7cUserName = GetPar( "cUserName");
         AV8cUserPassword = GetPar( "cUserPassword");
         AV9cUserCreatedDate = context.localUtil.ParseDateParm( GetPar( "cUserCreatedDate"));
         AV10cUserModifiedDate = context.localUtil.ParseDateParm( GetPar( "cUserModifiedDate"));
         AV13cRoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "cRoleId"), "."), 18, MidpointRounding.ToEven));
         AV14cUserHash = GetPar( "cUserHash");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA2R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2R2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00g0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pUserId,6,0))}, new string[] {"pUserId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERNAME", AV7cUserName);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERPASSWORD", AV8cUserPassword);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERCREATEDDATE", context.localUtil.Format(AV9cUserCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERMODIFIEDDATE", context.localUtil.Format(AV10cUserModifiedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cRoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSERHASH", AV14cUserHash);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pUserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USERIDFILTERCONTAINER_Class", StringUtil.RTrim( divUseridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USERNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divUsernamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USERPASSWORDFILTERCONTAINER_Class", StringUtil.RTrim( divUserpasswordfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USERCREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divUsercreateddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USERMODIFIEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divUsermodifieddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ROLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divRoleidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USERHASHFILTERCONTAINER_Class", StringUtil.RTrim( divUserhashfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2R2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00g0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pUserId,6,0))}, new string[] {"pUserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00G0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List User" ;
      }

      protected void WB2R0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUseridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUseridfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbluseridfilter_Internalname, "User Id", "", "", lblLbluseridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuserid_Internalname, "User Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuserid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUserId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCuserid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cUserId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cUserId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuserid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuserid_Visible, edtavCuserid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divUsernamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsernamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusernamefilter_Internalname, "User Name", "", "", lblLblusernamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusername_Internalname, "User Name", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusername_Internalname, AV7cUserName, StringUtil.RTrim( context.localUtil.Format( AV7cUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusername_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusername_Visible, edtavCusername_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divUserpasswordfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUserpasswordfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbluserpasswordfilter_Internalname, "User Password", "", "", lblLbluserpasswordfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e132r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuserpassword_Internalname, "User Password", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuserpassword_Internalname, AV8cUserPassword, StringUtil.RTrim( context.localUtil.Format( AV8cUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuserpassword_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuserpassword_Visible, edtavCuserpassword_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divUsercreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsercreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusercreateddatefilter_Internalname, "User Created Date", "", "", lblLblusercreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e142r1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusercreateddate_Internalname, "User Created Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCusercreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCusercreateddate_Internalname, context.localUtil.Format(AV9cUserCreatedDate, "99/99/99"), context.localUtil.Format( AV9cUserCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusercreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusercreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divUsermodifieddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsermodifieddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusermodifieddatefilter_Internalname, "User Modified Date", "", "", lblLblusermodifieddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e152r1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusermodifieddate_Internalname, "User Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCusermodifieddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCusermodifieddate_Internalname, context.localUtil.Format(AV10cUserModifiedDate, "99/99/99"), context.localUtil.Format( AV10cUserModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusermodifieddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusermodifieddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divRoleidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRoleidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblroleidfilter_Internalname, "Role Id", "", "", lblLblroleidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e162r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCroleid_Internalname, "Role Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCroleid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cRoleId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCroleid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13cRoleId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV13cRoleId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCroleid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCroleid_Visible, edtavCroleid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divUserhashfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUserhashfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbluserhashfilter_Internalname, "User Hash", "", "", lblLbluserhashfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e172r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCuserhash_Internalname, "User Hash", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCuserhash_Internalname, AV14cUserHash, StringUtil.RTrim( context.localUtil.Format( AV14cUserHash, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCuserhash_Jsonclick, 0, "Attribute", "", "", "", "", edtavCuserhash_Visible, edtavCuserhash_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e182r1_client"+"'", TempTags, "", 2, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2R2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
            }
            Form.Meta.addItem("description", "Selection List User", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2R0( ) ;
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A100UserName = cgiGet( edtUserName_Internalname);
                              A101UserPassword = cgiGet( edtUserPassword_Internalname);
                              A102UserCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUserCreatedDate_Internalname), 0));
                              A103UserModifiedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUserModifiedDate_Internalname), 0));
                              A104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRoleId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n104RoleId = false;
                              A111UserActive = StringUtil.StrToBool( cgiGet( chkUserActive_Internalname));
                              n111UserActive = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E192R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E202R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cuserid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSERID"), ".", ",") != Convert.ToDecimal( AV6cUserId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusername Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERNAME"), AV7cUserName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuserpassword Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERPASSWORD"), AV8cUserPassword) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusercreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUSERCREATEDDATE"), 0) != AV9cUserCreatedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusermodifieddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUSERMODIFIEDDATE"), 0) != AV10cUserModifiedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Croleid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCROLEID"), ".", ",") != Convert.ToDecimal( AV13cRoleId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cuserhash Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERHASH"), AV14cUserHash) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E212R2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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

      protected void WE2R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA2R2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cUserId ,
                                        string AV7cUserName ,
                                        string AV8cUserPassword ,
                                        DateTime AV9cUserCreatedDate ,
                                        DateTime AV10cUserModifiedDate ,
                                        int AV13cRoleId ,
                                        string AV14cUserHash )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")));
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
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cUserName ,
                                                 AV8cUserPassword ,
                                                 AV9cUserCreatedDate ,
                                                 AV10cUserModifiedDate ,
                                                 AV13cRoleId ,
                                                 AV14cUserHash ,
                                                 A100UserName ,
                                                 A101UserPassword ,
                                                 A102UserCreatedDate ,
                                                 A103UserModifiedDate ,
                                                 A104RoleId ,
                                                 A109UserHash ,
                                                 AV6cUserId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV7cUserName = StringUtil.Concat( StringUtil.RTrim( AV7cUserName), "%", "");
            lV8cUserPassword = StringUtil.Concat( StringUtil.RTrim( AV8cUserPassword), "%", "");
            lV14cUserHash = StringUtil.Concat( StringUtil.RTrim( AV14cUserHash), "%", "");
            /* Using cursor H002R2 */
            pr_default.execute(0, new Object[] {AV6cUserId, lV7cUserName, lV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, lV14cUserHash, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A109UserHash = H002R2_A109UserHash[0];
               A111UserActive = H002R2_A111UserActive[0];
               n111UserActive = H002R2_n111UserActive[0];
               A104RoleId = H002R2_A104RoleId[0];
               n104RoleId = H002R2_n104RoleId[0];
               A103UserModifiedDate = H002R2_A103UserModifiedDate[0];
               A102UserCreatedDate = H002R2_A102UserCreatedDate[0];
               A101UserPassword = H002R2_A101UserPassword[0];
               A100UserName = H002R2_A100UserName[0];
               A99UserId = H002R2_A99UserId[0];
               /* Execute user event: Load */
               E202R2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB2R0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USERID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cUserName ,
                                              AV8cUserPassword ,
                                              AV9cUserCreatedDate ,
                                              AV10cUserModifiedDate ,
                                              AV13cRoleId ,
                                              AV14cUserHash ,
                                              A100UserName ,
                                              A101UserPassword ,
                                              A102UserCreatedDate ,
                                              A103UserModifiedDate ,
                                              A104RoleId ,
                                              A109UserHash ,
                                              AV6cUserId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV7cUserName = StringUtil.Concat( StringUtil.RTrim( AV7cUserName), "%", "");
         lV8cUserPassword = StringUtil.Concat( StringUtil.RTrim( AV8cUserPassword), "%", "");
         lV14cUserHash = StringUtil.Concat( StringUtil.RTrim( AV14cUserHash), "%", "");
         /* Using cursor H002R3 */
         pr_default.execute(1, new Object[] {AV6cUserId, lV7cUserName, lV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, lV14cUserHash});
         GRID1_nRecordCount = H002R3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
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
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
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
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
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
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
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
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUserId, AV7cUserName, AV8cUserPassword, AV9cUserCreatedDate, AV10cUserModifiedDate, AV13cRoleId, AV14cUserHash) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCuserid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCuserid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSERID");
               GX_FocusControl = edtavCuserid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cUserId = 0;
               AssignAttri("", false, "AV6cUserId", StringUtil.LTrimStr( (decimal)(AV6cUserId), 6, 0));
            }
            else
            {
               AV6cUserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCuserid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cUserId", StringUtil.LTrimStr( (decimal)(AV6cUserId), 6, 0));
            }
            AV7cUserName = cgiGet( edtavCusername_Internalname);
            AssignAttri("", false, "AV7cUserName", AV7cUserName);
            AV8cUserPassword = cgiGet( edtavCuserpassword_Internalname);
            AssignAttri("", false, "AV8cUserPassword", AV8cUserPassword);
            if ( context.localUtil.VCDate( cgiGet( edtavCusercreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"User Created Date"}), 1, "vCUSERCREATEDDATE");
               GX_FocusControl = edtavCusercreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cUserCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV9cUserCreatedDate", context.localUtil.Format(AV9cUserCreatedDate, "99/99/99"));
            }
            else
            {
               AV9cUserCreatedDate = context.localUtil.CToD( cgiGet( edtavCusercreateddate_Internalname), 1);
               AssignAttri("", false, "AV9cUserCreatedDate", context.localUtil.Format(AV9cUserCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCusermodifieddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"User Modified Date"}), 1, "vCUSERMODIFIEDDATE");
               GX_FocusControl = edtavCusermodifieddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cUserModifiedDate = DateTime.MinValue;
               AssignAttri("", false, "AV10cUserModifiedDate", context.localUtil.Format(AV10cUserModifiedDate, "99/99/99"));
            }
            else
            {
               AV10cUserModifiedDate = context.localUtil.CToD( cgiGet( edtavCusermodifieddate_Internalname), 1);
               AssignAttri("", false, "AV10cUserModifiedDate", context.localUtil.Format(AV10cUserModifiedDate, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCroleid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCroleid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCROLEID");
               GX_FocusControl = edtavCroleid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13cRoleId = 0;
               AssignAttri("", false, "AV13cRoleId", StringUtil.LTrimStr( (decimal)(AV13cRoleId), 6, 0));
            }
            else
            {
               AV13cRoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCroleid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13cRoleId", StringUtil.LTrimStr( (decimal)(AV13cRoleId), 6, 0));
            }
            AV14cUserHash = cgiGet( edtavCuserhash_Internalname);
            AssignAttri("", false, "AV14cUserHash", AV14cUserHash);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSERID"), ".", ",") != Convert.ToDecimal( AV6cUserId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERNAME"), AV7cUserName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERPASSWORD"), AV8cUserPassword) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCUSERCREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV9cUserCreatedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCUSERMODIFIEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV10cUserModifiedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCROLEID"), ".", ",") != Convert.ToDecimal( AV13cRoleId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSERHASH"), AV14cUserHash) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E192R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192R2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "User", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E202R2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E212R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E212R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pUserId = A99UserId;
         AssignAttri("", false, "AV11pUserId", StringUtil.LTrimStr( (decimal)(AV11pUserId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV11pUserId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pUserId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11pUserId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV11pUserId", StringUtil.LTrimStr( (decimal)(AV11pUserId), 6, 0));
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261114232", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx00g0.js", "?20241261114232", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtUserId_Internalname = "USERID_"+sGXsfl_84_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_84_idx;
         edtUserPassword_Internalname = "USERPASSWORD_"+sGXsfl_84_idx;
         edtUserCreatedDate_Internalname = "USERCREATEDDATE_"+sGXsfl_84_idx;
         edtUserModifiedDate_Internalname = "USERMODIFIEDDATE_"+sGXsfl_84_idx;
         edtRoleId_Internalname = "ROLEID_"+sGXsfl_84_idx;
         chkUserActive_Internalname = "USERACTIVE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtUserId_Internalname = "USERID_"+sGXsfl_84_fel_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_84_fel_idx;
         edtUserPassword_Internalname = "USERPASSWORD_"+sGXsfl_84_fel_idx;
         edtUserCreatedDate_Internalname = "USERCREATEDDATE_"+sGXsfl_84_fel_idx;
         edtUserModifiedDate_Internalname = "USERMODIFIEDDATE_"+sGXsfl_84_fel_idx;
         edtRoleId_Internalname = "ROLEID_"+sGXsfl_84_fel_idx;
         chkUserActive_Internalname = "USERACTIVE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB2R0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserName_Internalname,(string)A100UserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserPassword_Internalname,(string)A101UserPassword,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserPassword_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserCreatedDate_Internalname,context.localUtil.Format(A102UserCreatedDate, "99/99/99"),context.localUtil.Format( A102UserCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserModifiedDate_Internalname,context.localUtil.Format(A103UserModifiedDate, "99/99/99"),context.localUtil.Format( A103UserModifiedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserModifiedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRoleId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A104RoleId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRoleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "USERACTIVE_" + sGXsfl_84_idx;
            chkUserActive.Name = GXCCtl;
            chkUserActive.WebTags = "";
            chkUserActive.Caption = "";
            AssignProp("", false, chkUserActive_Internalname, "TitleCaption", chkUserActive.Caption, !bGXsfl_84_Refreshing);
            chkUserActive.CheckedValue = "false";
            A111UserActive = StringUtil.StrToBool( StringUtil.BoolToStr( A111UserActive));
            n111UserActive = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkUserActive_Internalname,StringUtil.BoolToStr( A111UserActive),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes2R2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "USERACTIVE_" + sGXsfl_84_idx;
         chkUserActive.Name = GXCCtl;
         chkUserActive.WebTags = "";
         chkUserActive.Caption = "";
         AssignProp("", false, chkUserActive_Internalname, "TitleCaption", chkUserActive.Caption, !bGXsfl_84_Refreshing);
         chkUserActive.CheckedValue = "false";
         A111UserActive = StringUtil.StrToBool( StringUtil.BoolToStr( A111UserActive));
         n111UserActive = false;
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Password") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Modified Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Role Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A100UserName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A101UserPassword));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A102UserCreatedDate, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A103UserModifiedDate, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A104RoleId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A111UserActive)));
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
         lblLbluseridfilter_Internalname = "LBLUSERIDFILTER";
         edtavCuserid_Internalname = "vCUSERID";
         divUseridfiltercontainer_Internalname = "USERIDFILTERCONTAINER";
         lblLblusernamefilter_Internalname = "LBLUSERNAMEFILTER";
         edtavCusername_Internalname = "vCUSERNAME";
         divUsernamefiltercontainer_Internalname = "USERNAMEFILTERCONTAINER";
         lblLbluserpasswordfilter_Internalname = "LBLUSERPASSWORDFILTER";
         edtavCuserpassword_Internalname = "vCUSERPASSWORD";
         divUserpasswordfiltercontainer_Internalname = "USERPASSWORDFILTERCONTAINER";
         lblLblusercreateddatefilter_Internalname = "LBLUSERCREATEDDATEFILTER";
         edtavCusercreateddate_Internalname = "vCUSERCREATEDDATE";
         divUsercreateddatefiltercontainer_Internalname = "USERCREATEDDATEFILTERCONTAINER";
         lblLblusermodifieddatefilter_Internalname = "LBLUSERMODIFIEDDATEFILTER";
         edtavCusermodifieddate_Internalname = "vCUSERMODIFIEDDATE";
         divUsermodifieddatefiltercontainer_Internalname = "USERMODIFIEDDATEFILTERCONTAINER";
         lblLblroleidfilter_Internalname = "LBLROLEIDFILTER";
         edtavCroleid_Internalname = "vCROLEID";
         divRoleidfiltercontainer_Internalname = "ROLEIDFILTERCONTAINER";
         lblLbluserhashfilter_Internalname = "LBLUSERHASHFILTER";
         edtavCuserhash_Internalname = "vCUSERHASH";
         divUserhashfiltercontainer_Internalname = "USERHASHFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtUserId_Internalname = "USERID";
         edtUserName_Internalname = "USERNAME";
         edtUserPassword_Internalname = "USERPASSWORD";
         edtUserCreatedDate_Internalname = "USERCREATEDDATE";
         edtUserModifiedDate_Internalname = "USERMODIFIEDDATE";
         edtRoleId_Internalname = "ROLEID";
         chkUserActive_Internalname = "USERACTIVE";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         chkUserActive.Caption = "";
         edtRoleId_Jsonclick = "";
         edtUserModifiedDate_Jsonclick = "";
         edtUserCreatedDate_Jsonclick = "";
         edtUserPassword_Jsonclick = "";
         edtUserName_Jsonclick = "";
         edtUserId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCuserhash_Jsonclick = "";
         edtavCuserhash_Enabled = 1;
         edtavCuserhash_Visible = 1;
         edtavCroleid_Jsonclick = "";
         edtavCroleid_Enabled = 1;
         edtavCroleid_Visible = 1;
         edtavCusermodifieddate_Jsonclick = "";
         edtavCusermodifieddate_Enabled = 1;
         edtavCusercreateddate_Jsonclick = "";
         edtavCusercreateddate_Enabled = 1;
         edtavCuserpassword_Jsonclick = "";
         edtavCuserpassword_Enabled = 1;
         edtavCuserpassword_Visible = 1;
         edtavCusername_Jsonclick = "";
         edtavCusername_Enabled = 1;
         edtavCusername_Visible = 1;
         edtavCuserid_Jsonclick = "";
         edtavCuserid_Enabled = 1;
         edtavCuserid_Visible = 1;
         divUserhashfiltercontainer_Class = "AdvancedContainerItem";
         divRoleidfiltercontainer_Class = "AdvancedContainerItem";
         divUsermodifieddatefiltercontainer_Class = "AdvancedContainerItem";
         divUsercreateddatefiltercontainer_Class = "AdvancedContainerItem";
         divUserpasswordfiltercontainer_Class = "AdvancedContainerItem";
         divUsernamefiltercontainer_Class = "AdvancedContainerItem";
         divUseridfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List User";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUserId',fld:'vCUSERID',pic:'ZZZZZ9'},{av:'AV7cUserName',fld:'vCUSERNAME',pic:''},{av:'AV8cUserPassword',fld:'vCUSERPASSWORD',pic:''},{av:'AV9cUserCreatedDate',fld:'vCUSERCREATEDDATE',pic:''},{av:'AV10cUserModifiedDate',fld:'vCUSERMODIFIEDDATE',pic:''},{av:'AV13cRoleId',fld:'vCROLEID',pic:'ZZZZZ9'},{av:'AV14cUserHash',fld:'vCUSERHASH',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E182R1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSERIDFILTER.CLICK","{handler:'E112R1',iparms:[{av:'divUseridfiltercontainer_Class',ctrl:'USERIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERIDFILTER.CLICK",",oparms:[{av:'divUseridfiltercontainer_Class',ctrl:'USERIDFILTERCONTAINER',prop:'Class'},{av:'edtavCuserid_Visible',ctrl:'vCUSERID',prop:'Visible'}]}");
         setEventMetadata("LBLUSERNAMEFILTER.CLICK","{handler:'E122R1',iparms:[{av:'divUsernamefiltercontainer_Class',ctrl:'USERNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERNAMEFILTER.CLICK",",oparms:[{av:'divUsernamefiltercontainer_Class',ctrl:'USERNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCusername_Visible',ctrl:'vCUSERNAME',prop:'Visible'}]}");
         setEventMetadata("LBLUSERPASSWORDFILTER.CLICK","{handler:'E132R1',iparms:[{av:'divUserpasswordfiltercontainer_Class',ctrl:'USERPASSWORDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERPASSWORDFILTER.CLICK",",oparms:[{av:'divUserpasswordfiltercontainer_Class',ctrl:'USERPASSWORDFILTERCONTAINER',prop:'Class'},{av:'edtavCuserpassword_Visible',ctrl:'vCUSERPASSWORD',prop:'Visible'}]}");
         setEventMetadata("LBLUSERCREATEDDATEFILTER.CLICK","{handler:'E142R1',iparms:[{av:'divUsercreateddatefiltercontainer_Class',ctrl:'USERCREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERCREATEDDATEFILTER.CLICK",",oparms:[{av:'divUsercreateddatefiltercontainer_Class',ctrl:'USERCREATEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLUSERMODIFIEDDATEFILTER.CLICK","{handler:'E152R1',iparms:[{av:'divUsermodifieddatefiltercontainer_Class',ctrl:'USERMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERMODIFIEDDATEFILTER.CLICK",",oparms:[{av:'divUsermodifieddatefiltercontainer_Class',ctrl:'USERMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLROLEIDFILTER.CLICK","{handler:'E162R1',iparms:[{av:'divRoleidfiltercontainer_Class',ctrl:'ROLEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLROLEIDFILTER.CLICK",",oparms:[{av:'divRoleidfiltercontainer_Class',ctrl:'ROLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCroleid_Visible',ctrl:'vCROLEID',prop:'Visible'}]}");
         setEventMetadata("LBLUSERHASHFILTER.CLICK","{handler:'E172R1',iparms:[{av:'divUserhashfiltercontainer_Class',ctrl:'USERHASHFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSERHASHFILTER.CLICK",",oparms:[{av:'divUserhashfiltercontainer_Class',ctrl:'USERHASHFILTERCONTAINER',prop:'Class'},{av:'edtavCuserhash_Visible',ctrl:'vCUSERHASH',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E212R2',iparms:[{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pUserId',fld:'vPUSERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUserId',fld:'vCUSERID',pic:'ZZZZZ9'},{av:'AV7cUserName',fld:'vCUSERNAME',pic:''},{av:'AV8cUserPassword',fld:'vCUSERPASSWORD',pic:''},{av:'AV9cUserCreatedDate',fld:'vCUSERCREATEDDATE',pic:''},{av:'AV10cUserModifiedDate',fld:'vCUSERMODIFIEDDATE',pic:''},{av:'AV13cRoleId',fld:'vCROLEID',pic:'ZZZZZ9'},{av:'AV14cUserHash',fld:'vCUSERHASH',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUserId',fld:'vCUSERID',pic:'ZZZZZ9'},{av:'AV7cUserName',fld:'vCUSERNAME',pic:''},{av:'AV8cUserPassword',fld:'vCUSERPASSWORD',pic:''},{av:'AV9cUserCreatedDate',fld:'vCUSERCREATEDDATE',pic:''},{av:'AV10cUserModifiedDate',fld:'vCUSERMODIFIEDDATE',pic:''},{av:'AV13cRoleId',fld:'vCROLEID',pic:'ZZZZZ9'},{av:'AV14cUserHash',fld:'vCUSERHASH',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUserId',fld:'vCUSERID',pic:'ZZZZZ9'},{av:'AV7cUserName',fld:'vCUSERNAME',pic:''},{av:'AV8cUserPassword',fld:'vCUSERPASSWORD',pic:''},{av:'AV9cUserCreatedDate',fld:'vCUSERCREATEDDATE',pic:''},{av:'AV10cUserModifiedDate',fld:'vCUSERMODIFIEDDATE',pic:''},{av:'AV13cRoleId',fld:'vCROLEID',pic:'ZZZZZ9'},{av:'AV14cUserHash',fld:'vCUSERHASH',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUserId',fld:'vCUSERID',pic:'ZZZZZ9'},{av:'AV7cUserName',fld:'vCUSERNAME',pic:''},{av:'AV8cUserPassword',fld:'vCUSERPASSWORD',pic:''},{av:'AV9cUserCreatedDate',fld:'vCUSERCREATEDDATE',pic:''},{av:'AV10cUserModifiedDate',fld:'vCUSERMODIFIEDDATE',pic:''},{av:'AV13cRoleId',fld:'vCROLEID',pic:'ZZZZZ9'},{av:'AV14cUserHash',fld:'vCUSERHASH',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CUSERCREATEDDATE","{handler:'Validv_Cusercreateddate',iparms:[]");
         setEventMetadata("VALIDV_CUSERCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CUSERMODIFIEDDATE","{handler:'Validv_Cusermodifieddate',iparms:[]");
         setEventMetadata("VALIDV_CUSERMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Useractive',iparms:[]");
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
         AV7cUserName = "";
         AV8cUserPassword = "";
         AV9cUserCreatedDate = DateTime.MinValue;
         AV10cUserModifiedDate = DateTime.MinValue;
         AV14cUserHash = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbluseridfilter_Jsonclick = "";
         TempTags = "";
         lblLblusernamefilter_Jsonclick = "";
         lblLbluserpasswordfilter_Jsonclick = "";
         lblLblusercreateddatefilter_Jsonclick = "";
         lblLblusermodifieddatefilter_Jsonclick = "";
         lblLblroleidfilter_Jsonclick = "";
         lblLbluserhashfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV17Linkselection_GXI = "";
         A100UserName = "";
         A101UserPassword = "";
         A102UserCreatedDate = DateTime.MinValue;
         A103UserModifiedDate = DateTime.MinValue;
         scmdbuf = "";
         lV7cUserName = "";
         lV8cUserPassword = "";
         lV14cUserHash = "";
         A109UserHash = "";
         H002R2_A109UserHash = new string[] {""} ;
         H002R2_A111UserActive = new bool[] {false} ;
         H002R2_n111UserActive = new bool[] {false} ;
         H002R2_A104RoleId = new int[1] ;
         H002R2_n104RoleId = new bool[] {false} ;
         H002R2_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002R2_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002R2_A101UserPassword = new string[] {""} ;
         H002R2_A100UserName = new string[] {""} ;
         H002R2_A99UserId = new int[1] ;
         H002R3_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00g0__default(),
            new Object[][] {
                new Object[] {
               H002R2_A109UserHash, H002R2_A111UserActive, H002R2_n111UserActive, H002R2_A104RoleId, H002R2_n104RoleId, H002R2_A103UserModifiedDate, H002R2_A102UserCreatedDate, H002R2_A101UserPassword, H002R2_A100UserName, H002R2_A99UserId
               }
               , new Object[] {
               H002R3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV11pUserId ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV6cUserId ;
      private int AV13cRoleId ;
      private int edtavCuserid_Enabled ;
      private int edtavCuserid_Visible ;
      private int edtavCusername_Visible ;
      private int edtavCusername_Enabled ;
      private int edtavCuserpassword_Visible ;
      private int edtavCuserpassword_Enabled ;
      private int edtavCusercreateddate_Enabled ;
      private int edtavCusermodifieddate_Enabled ;
      private int edtavCroleid_Enabled ;
      private int edtavCroleid_Visible ;
      private int edtavCuserhash_Visible ;
      private int edtavCuserhash_Enabled ;
      private int A99UserId ;
      private int A104RoleId ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divUseridfiltercontainer_Class ;
      private string divUsernamefiltercontainer_Class ;
      private string divUserpasswordfiltercontainer_Class ;
      private string divUsercreateddatefiltercontainer_Class ;
      private string divUsermodifieddatefiltercontainer_Class ;
      private string divRoleidfiltercontainer_Class ;
      private string divUserhashfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divUseridfiltercontainer_Internalname ;
      private string lblLbluseridfilter_Internalname ;
      private string lblLbluseridfilter_Jsonclick ;
      private string edtavCuserid_Internalname ;
      private string TempTags ;
      private string edtavCuserid_Jsonclick ;
      private string divUsernamefiltercontainer_Internalname ;
      private string lblLblusernamefilter_Internalname ;
      private string lblLblusernamefilter_Jsonclick ;
      private string edtavCusername_Internalname ;
      private string edtavCusername_Jsonclick ;
      private string divUserpasswordfiltercontainer_Internalname ;
      private string lblLbluserpasswordfilter_Internalname ;
      private string lblLbluserpasswordfilter_Jsonclick ;
      private string edtavCuserpassword_Internalname ;
      private string edtavCuserpassword_Jsonclick ;
      private string divUsercreateddatefiltercontainer_Internalname ;
      private string lblLblusercreateddatefilter_Internalname ;
      private string lblLblusercreateddatefilter_Jsonclick ;
      private string edtavCusercreateddate_Internalname ;
      private string edtavCusercreateddate_Jsonclick ;
      private string divUsermodifieddatefiltercontainer_Internalname ;
      private string lblLblusermodifieddatefilter_Internalname ;
      private string lblLblusermodifieddatefilter_Jsonclick ;
      private string edtavCusermodifieddate_Internalname ;
      private string edtavCusermodifieddate_Jsonclick ;
      private string divRoleidfiltercontainer_Internalname ;
      private string lblLblroleidfilter_Internalname ;
      private string lblLblroleidfilter_Jsonclick ;
      private string edtavCroleid_Internalname ;
      private string edtavCroleid_Jsonclick ;
      private string divUserhashfiltercontainer_Internalname ;
      private string lblLbluserhashfilter_Internalname ;
      private string lblLbluserhashfilter_Jsonclick ;
      private string edtavCuserhash_Internalname ;
      private string edtavCuserhash_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtUserId_Internalname ;
      private string edtUserName_Internalname ;
      private string edtUserPassword_Internalname ;
      private string edtUserCreatedDate_Internalname ;
      private string edtUserModifiedDate_Internalname ;
      private string edtRoleId_Internalname ;
      private string chkUserActive_Internalname ;
      private string scmdbuf ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtUserId_Jsonclick ;
      private string edtUserName_Jsonclick ;
      private string edtUserPassword_Jsonclick ;
      private string edtUserCreatedDate_Jsonclick ;
      private string edtUserModifiedDate_Jsonclick ;
      private string edtRoleId_Jsonclick ;
      private string GXCCtl ;
      private string subGrid1_Header ;
      private DateTime AV9cUserCreatedDate ;
      private DateTime AV10cUserModifiedDate ;
      private DateTime A102UserCreatedDate ;
      private DateTime A103UserModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n104RoleId ;
      private bool A111UserActive ;
      private bool n111UserActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cUserName ;
      private string AV8cUserPassword ;
      private string AV14cUserHash ;
      private string AV17Linkselection_GXI ;
      private string A100UserName ;
      private string A101UserPassword ;
      private string lV7cUserName ;
      private string lV8cUserPassword ;
      private string lV14cUserHash ;
      private string A109UserHash ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkUserActive ;
      private IDataStoreProvider pr_default ;
      private string[] H002R2_A109UserHash ;
      private bool[] H002R2_A111UserActive ;
      private bool[] H002R2_n111UserActive ;
      private int[] H002R2_A104RoleId ;
      private bool[] H002R2_n104RoleId ;
      private DateTime[] H002R2_A103UserModifiedDate ;
      private DateTime[] H002R2_A102UserCreatedDate ;
      private string[] H002R2_A101UserPassword ;
      private string[] H002R2_A100UserName ;
      private int[] H002R2_A99UserId ;
      private long[] H002R3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pUserId ;
      private GXWebForm Form ;
   }

   public class gx00g0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002R2( IGxContext context ,
                                             string AV7cUserName ,
                                             string AV8cUserPassword ,
                                             DateTime AV9cUserCreatedDate ,
                                             DateTime AV10cUserModifiedDate ,
                                             int AV13cRoleId ,
                                             string AV14cUserHash ,
                                             string A100UserName ,
                                             string A101UserPassword ,
                                             DateTime A102UserCreatedDate ,
                                             DateTime A103UserModifiedDate ,
                                             int A104RoleId ,
                                             string A109UserHash ,
                                             int AV6cUserId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [UserHash], [UserActive], [RoleId], [UserModifiedDate], [UserCreatedDate], [UserPassword], [UserName], [UserId]";
         sFromString = " FROM [User]";
         sOrderString = "";
         AddWhere(sWhereString, "([UserId] >= @AV6cUserId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUserName)) )
         {
            AddWhere(sWhereString, "([UserName] like @lV7cUserName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUserPassword)) )
         {
            AddWhere(sWhereString, "([UserPassword] like @lV8cUserPassword)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cUserCreatedDate) )
         {
            AddWhere(sWhereString, "([UserCreatedDate] >= @AV9cUserCreatedDate)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cUserModifiedDate) )
         {
            AddWhere(sWhereString, "([UserModifiedDate] >= @AV10cUserModifiedDate)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV13cRoleId) )
         {
            AddWhere(sWhereString, "([RoleId] >= @AV13cRoleId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cUserHash)) )
         {
            AddWhere(sWhereString, "([UserHash] like @lV14cUserHash)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [UserId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002R3( IGxContext context ,
                                             string AV7cUserName ,
                                             string AV8cUserPassword ,
                                             DateTime AV9cUserCreatedDate ,
                                             DateTime AV10cUserModifiedDate ,
                                             int AV13cRoleId ,
                                             string AV14cUserHash ,
                                             string A100UserName ,
                                             string A101UserPassword ,
                                             DateTime A102UserCreatedDate ,
                                             DateTime A103UserModifiedDate ,
                                             int A104RoleId ,
                                             string A109UserHash ,
                                             int AV6cUserId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [User]";
         AddWhere(sWhereString, "([UserId] >= @AV6cUserId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUserName)) )
         {
            AddWhere(sWhereString, "([UserName] like @lV7cUserName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUserPassword)) )
         {
            AddWhere(sWhereString, "([UserPassword] like @lV8cUserPassword)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cUserCreatedDate) )
         {
            AddWhere(sWhereString, "([UserCreatedDate] >= @AV9cUserCreatedDate)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cUserModifiedDate) )
         {
            AddWhere(sWhereString, "([UserModifiedDate] >= @AV10cUserModifiedDate)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV13cRoleId) )
         {
            AddWhere(sWhereString, "([RoleId] >= @AV13cRoleId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14cUserHash)) )
         {
            AddWhere(sWhereString, "([UserHash] like @lV14cUserHash)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H002R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          new ParDef("@AV6cUserId",GXType.Int32,6,0) ,
          new ParDef("@lV7cUserName",GXType.NVarChar,20,0) ,
          new ParDef("@lV8cUserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@AV9cUserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV10cUserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@AV13cRoleId",GXType.Int32,6,0) ,
          new ParDef("@lV14cUserHash",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002R3;
          prmH002R3 = new Object[] {
          new ParDef("@AV6cUserId",GXType.Int32,6,0) ,
          new ParDef("@lV7cUserName",GXType.NVarChar,20,0) ,
          new ParDef("@lV8cUserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@AV9cUserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV10cUserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@AV13cRoleId",GXType.Int32,6,0) ,
          new ParDef("@lV14cUserHash",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
