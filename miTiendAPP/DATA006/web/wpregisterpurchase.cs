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
   public class wpregisterpurchase : GXDataArea
   {
      public wpregisterpurchase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpregisterpurchase( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavSupplier = new GXCombobox();
         cmbavOrderby = new GXCombobox();
         chkavDescending = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUPPLIER") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUPPLIER222( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpurchaseordersfiltered") == 0 )
            {
               gxnrGridpurchaseordersfiltered_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridpurchaseordersfiltered") == 0 )
            {
               gxgrGridpurchaseordersfiltered_refresh_invoke( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridedit") == 0 )
            {
               gxnrFgridedit_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridedit") == 0 )
            {
               gxgrFgridedit_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridposiblenewdetails") == 0 )
            {
               gxnrFgridposiblenewdetails_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridposiblenewdetails") == 0 )
            {
               gxgrFgridposiblenewdetails_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridcancel") == 0 )
            {
               gxnrFgridcancel_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridcancel") == 0 )
            {
               gxgrFgridcancel_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpurchaseordersfiltered_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         AV49Register = GetPar( "Register");
         AV57Edit = GetPar( "Edit");
         AV56Cancel = GetPar( "Cancel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpurchaseordersfiltered_newrow( ) ;
         /* End function gxnrGridpurchaseordersfiltered_newrow_invoke */
      }

      protected void gxgrGridpurchaseordersfiltered_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         AV49Register = GetPar( "Register");
         AV57Edit = GetPar( "Edit");
         AV56Cancel = GetPar( "Cancel");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridpurchaseordersfiltered_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_86 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_86"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_86_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_86_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_86_idx = GetPar( "sGXsfl_86_idx");
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
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrFgridedit_newrow_invoke( )
      {
         nRC_GXsfl_146 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_146"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_146_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_146_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_146_idx = GetPar( "sGXsfl_146_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridedit_newrow( ) ;
         /* End function gxnrFgridedit_newrow_invoke */
      }

      protected void gxgrFgridedit_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridedit_refresh_invoke */
      }

      protected void gxnrFgridposiblenewdetails_newrow_invoke( )
      {
         nRC_GXsfl_190 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_190"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_190_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_190_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_190_idx = GetPar( "sGXsfl_190_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridposiblenewdetails_newrow( ) ;
         /* End function gxnrFgridposiblenewdetails_newrow_invoke */
      }

      protected void gxgrFgridposiblenewdetails_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridposiblenewdetails_refresh_invoke */
      }

      protected void gxnrFgridcancel_newrow_invoke( )
      {
         nRC_GXsfl_240 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_240"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_240_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_240_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_240_idx = GetPar( "sGXsfl_240_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridcancel_newrow( ) ;
         /* End function gxnrFgridcancel_newrow_invoke */
      }

      protected void gxgrFgridcancel_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridcancel_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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
         PA222( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START222( ) ;
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregisterpurchase.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailsregister", AV61DetailsRegister);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailsregister", AV61DetailsRegister);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailsedit", AV59DetailsEdit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailsedit", AV59DetailsEdit);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Posiblesnewdetails", AV65PosiblesNewDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Posiblesnewdetails", AV65PosiblesNewDetails);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailscancel", AV60DetailsCancel);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailscancel", AV60DetailsCancel);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpurchaseordergeneratelist", AV46SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpurchaseordergeneratelist", AV46SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_86", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_86), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_146", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_146), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_190", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_190), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_240", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_240), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55PurchaseOrderId), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILSREGISTER", AV61DetailsRegister);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILSREGISTER", AV61DetailsRegister);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILSEDIT", AV59DetailsEdit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILSEDIT", AV59DetailsEdit);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV54AllOk);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV46SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV46SDTPurchaseOrderGenerateList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPOSIBLESNEWDETAILS", AV65PosiblesNewDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPOSIBLESNEWDETAILS", AV65PosiblesNewDetails);
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Collapsed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADDDETAIL_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttAdddetail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADDDETAIL_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(bttAdddetail_Enabled), 5, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WE222( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT222( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wpregisterpurchase.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegisterPurchase" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRegister Purchase" ;
      }

      protected void WB220( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Register Purchase Orders", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplier_Internalname, "Supplier", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_37_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_WPRegisterPurchase.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, "From Date", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_37_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV26FromDate, "99/99/99"), context.localUtil.Format( AV26FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPRegisterPurchase.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTodate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodate_Internalname, "To Date", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_37_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV27ToDate, "99/99/99"), context.localUtil.Format( AV27ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPRegisterPurchase.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderby_Internalname, "Order By", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderby, cmbavOrderby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0)), 1, cmbavOrderby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_WPRegisterPurchase.htm");
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", (string)(cmbavOrderby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDescending_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDescending_Internalname, "Desc", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_37_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDescending_Internalname, StringUtil.BoolToStr( AV53Descending), "", "Desc", 1, chkavDescending.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridpurchaseordersfilteredContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nEOF", GRIDPURCHASEORDERSFILTERED_nEOF);
               GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
               AV69GXV1 = nGXsfl_37_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseordersfiltered", GridpurchaseordersfilteredContainer, subGridpurchaseordersfiltered_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData", GridpurchaseordersfilteredContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData"+"V", GridpurchaseordersfilteredContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseordersfilteredContainerData"+"V"+"\" value='"+GridpurchaseordersfilteredContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
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
            GxWebStd.gx_div_start( context, divTableregister_Internalname, divTableregister_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonsregister_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotalpaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalpaid_Internalname, "Total Paid", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalpaid_Internalname, StringUtil.LTrim( StringUtil.NToC( AV37TotalPaid, 10, 2, ".", "")), StringUtil.LTrim( ((edtavTotalpaid_Enabled!=0) ? context.localUtil.Format( AV37TotalPaid, "ZZZZZZ9.99") : context.localUtil.Format( AV37TotalPaid, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalpaid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotalpaid_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRegisterorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Register", bttRegisterorder_Jsonclick, 5, "Register", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGISTERORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelregister_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Cancel", bttCancelregister_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELREGISTER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentregister_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Code", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Product", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Curr. Stock", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Min. Stock", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Ordered", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Received", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "C. Price", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Subtotal", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl86( ) ;
         }
         if ( wbEnd == 86 )
         {
            wbEnd = 0;
            nRC_GXsfl_86 = (int)(nGXsfl_86_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV74GXV6 = nGXsfl_86_idx;
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
            GxWebStd.gx_div_start( context, divTableedit_Internalname, divTableedit_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonsedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Confirm Cahanges?", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Confirm", bttConfirm_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Cancel", bttCancel1_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELEDIT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Remove", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Code", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Product", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Curr. Stock", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Min. Stock", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Ordered", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgrideditContainer.SetIsFreestyle(true);
            FgrideditContainer.SetWrapped(nGXWrapped);
            StartGridControl146( ) ;
         }
         if ( wbEnd == 146 )
         {
            wbEnd = 0;
            nRC_GXsfl_146 = (int)(nGXsfl_146_idx-1);
            if ( FgrideditContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV83GXV15 = nGXsfl_146_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridedit", FgrideditContainer, subFgridedit_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgrideditContainerData", FgrideditContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgrideditContainerData"+"V", FgrideditContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgrideditContainerData"+"V"+"\" value='"+FgrideditContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdddetail_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Add Detail", bttAdddetail_Jsonclick, 7, "Add Detail", "", StyleString, ClassString, 1, bttAdddetail_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e11221_client"+"'", TempTags, "", 2, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, divTable2_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Add", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Code", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Product", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Curr. Stock", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Min. Stock", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgridposiblenewdetailsContainer.SetIsFreestyle(true);
            FgridposiblenewdetailsContainer.SetWrapped(nGXWrapped);
            StartGridControl190( ) ;
         }
         if ( wbEnd == 190 )
         {
            wbEnd = 0;
            nRC_GXsfl_190 = (int)(nGXsfl_190_idx-1);
            if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV89GXV21 = nGXsfl_190_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridposiblenewdetails", FgridposiblenewdetailsContainer, subFgridposiblenewdetails_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData", FgridposiblenewdetailsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData"+"V", FgridposiblenewdetailsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridposiblenewdetailsContainerData"+"V"+"\" value='"+FgridposiblenewdetailsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTcancel_Internalname, divTcancel_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonscancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "¿Are You sure to Cancel Purchase Order?", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttYes_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Yes", bttYes_Jsonclick, 5, "Yes", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'YES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttNo_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "No", bttNo_Jsonclick, 5, "No", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentcancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Code", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Product", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Curr. Stock", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Min. Stock", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Ordered", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterPurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgridcancelContainer.SetIsFreestyle(true);
            FgridcancelContainer.SetWrapped(nGXWrapped);
            StartGridControl240( ) ;
         }
         if ( wbEnd == 240 )
         {
            wbEnd = 0;
            nRC_GXsfl_240 = (int)(nGXsfl_240_idx-1);
            if ( FgridcancelContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV94GXV26 = nGXsfl_240_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridcancel", FgridcancelContainer, subFgridcancel_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridcancelContainerData", FgridcancelContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridcancelContainerData"+"V", FgridcancelContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridcancelContainerData"+"V"+"\" value='"+FgridcancelContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nEOF", GRIDPURCHASEORDERSFILTERED_nEOF);
                  GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
                  AV69GXV1 = nGXsfl_37_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseordersfiltered", GridpurchaseordersfilteredContainer, subGridpurchaseordersfiltered_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData", GridpurchaseordersfilteredContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData"+"V", GridpurchaseordersfilteredContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseordersfilteredContainerData"+"V"+"\" value='"+GridpurchaseordersfilteredContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 86 )
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
                  AV74GXV6 = nGXsfl_86_idx;
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
         if ( wbEnd == 146 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgrideditContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV83GXV15 = nGXsfl_146_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridedit", FgrideditContainer, subFgridedit_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgrideditContainerData", FgrideditContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgrideditContainerData"+"V", FgrideditContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgrideditContainerData"+"V"+"\" value='"+FgrideditContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 190 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV89GXV21 = nGXsfl_190_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridposiblenewdetails", FgridposiblenewdetailsContainer, subFgridposiblenewdetails_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData", FgridposiblenewdetailsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData"+"V", FgridposiblenewdetailsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridposiblenewdetailsContainerData"+"V"+"\" value='"+FgridposiblenewdetailsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 240 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgridcancelContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV94GXV26 = nGXsfl_240_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridcancel", FgridcancelContainer, subFgridcancel_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridcancelContainerData", FgridcancelContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridcancelContainerData"+"V", FgridcancelContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridcancelContainerData"+"V"+"\" value='"+FgridcancelContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START222( )
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
            Form.Meta.addItem("description", "WPRegister Purchase", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP220( ) ;
      }

      protected void WS222( )
      {
         START222( ) ;
         EVT222( ) ;
      }

      protected void EVT222( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REGISTERORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RegisterOrder' */
                              E12222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELREGISTER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelRegister' */
                              E13222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELEDIT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelEdit' */
                              E14222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELCANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelCancel' */
                              E15222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Confirm' */
                              E16222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSUPPLIER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFROMDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTODATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORDERBY.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDESCENDING.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'YES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Yes' */
                              E22222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERSFILTEREDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPURCHASEORDERSFILTEREDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridpurchaseordersfiltered_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridpurchaseordersfiltered_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridpurchaseordersfiltered_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridpurchaseordersfiltered_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 39), "CTLQUANTITYRECEIVED.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_86_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
                              SubsflControlProps_866( ) ;
                              AV74GXV6 = nGXsfl_86_idx;
                              if ( ( AV61DetailsRegister.Count >= AV74GXV6 ) && ( AV74GXV6 > 0 ) )
                              {
                                 AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLQUANTITYRECEIVED.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E23222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E25226 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VREMOVEDETAIL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "FGRIDEDIT.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "FGRIDEDIT.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VREMOVEDETAIL.CLICK") == 0 ) )
                           {
                              nGXsfl_146_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
                              SubsflControlProps_1465( ) ;
                              AV83GXV15 = nGXsfl_146_idx;
                              if ( ( AV59DetailsEdit.Count >= AV83GXV15 ) && ( AV83GXV15 > 0 ) )
                              {
                                 AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
                                 AV62RemoveDetail = cgiGet( edtavRemovedetail_Internalname);
                                 AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV106Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_146_Refreshing);
                                 AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VREMOVEDETAIL.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDEDIT.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDEDIT.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28225 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECTTHIS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "FGRIDPOSIBLENEWDETAILS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "FGRIDPOSIBLENEWDETAILS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECTTHIS.CLICK") == 0 ) )
                           {
                              nGXsfl_190_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
                              SubsflControlProps_1904( ) ;
                              AV89GXV21 = nGXsfl_190_idx;
                              if ( ( AV65PosiblesNewDetails.Count >= AV89GXV21 ) && ( AV89GXV21 > 0 ) )
                              {
                                 AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
                                 AV66SelectThis = cgiGet( edtavSelectthis_Internalname);
                                 AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV107Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_190_Refreshing);
                                 AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VSELECTTHIS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E29222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDPOSIBLENEWDETAILS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDPOSIBLENEWDETAILS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E31224 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "FGRIDCANCEL.LOAD") == 0 )
                           {
                              nGXsfl_240_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
                              SubsflControlProps_2403( ) ;
                              AV94GXV26 = nGXsfl_240_idx;
                              if ( ( AV60DetailsCancel.Count >= AV94GXV26 ) && ( AV94GXV26 > 0 ) )
                              {
                                 AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FGRIDCANCEL.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E32223 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VREGISTER.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "VEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VCANCEL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "GRIDPURCHASEORDERSFILTERED.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "VEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VCANCEL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VREGISTER.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
                              if ( ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) && ( AV69GXV1 > 0 ) )
                              {
                                 AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
                                 AV57Edit = cgiGet( edtavEdit_Internalname);
                                 AssignProp("", false, edtavEdit_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV101Edit_GXI : context.convertURL( context.PathToRelativeUrl( AV57Edit))), !bGXsfl_37_Refreshing);
                                 AssignProp("", false, edtavEdit_Internalname, "SrcSet", context.GetImageSrcSet( AV57Edit), true);
                                 AV56Cancel = cgiGet( edtavCancel_Internalname);
                                 AssignProp("", false, edtavCancel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV102Cancel_GXI : context.convertURL( context.PathToRelativeUrl( AV56Cancel))), !bGXsfl_37_Refreshing);
                                 AssignProp("", false, edtavCancel_Internalname, "SrcSet", context.GetImageSrcSet( AV56Cancel), true);
                                 AV49Register = cgiGet( edtavRegister_Internalname);
                                 AssignProp("", false, edtavRegister_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV100Register_GXI : context.convertURL( context.PathToRelativeUrl( AV49Register))), !bGXsfl_37_Refreshing);
                                 AssignProp("", false, edtavRegister_Internalname, "SrcSet", context.GetImageSrcSet( AV49Register), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E33222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VREGISTER.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E34222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEDIT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E35222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCANCEL.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E36222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLSDTVOUCHERLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E37222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLDETAILSLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E38222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERSFILTERED.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E39222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void WE222( )
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

      protected void PA222( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavSupplier_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSUPPLIER222( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data222( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvSUPPLIER_html222( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data222( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSupplier.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSupplier.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUPPLIER_data222( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00222 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00222_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00222_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGridpurchaseordersfiltered_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_37_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridpurchaseordersfilteredContainer)) ;
         /* End function gxnrGridpurchaseordersfiltered_newrow */
      }

      protected void gxnrFgridcancel_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2403( ) ;
         while ( nGXsfl_240_idx <= nRC_GXsfl_240 )
         {
            sendrow_2403( ) ;
            nGXsfl_240_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_240_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_240_idx+1);
            sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
            SubsflControlProps_2403( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgridcancelContainer)) ;
         /* End function gxnrFgridcancel_newrow */
      }

      protected void gxnrFgridposiblenewdetails_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1904( ) ;
         while ( nGXsfl_190_idx <= nRC_GXsfl_190 )
         {
            sendrow_1904( ) ;
            nGXsfl_190_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_190_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_190_idx+1);
            sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
            SubsflControlProps_1904( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgridposiblenewdetailsContainer)) ;
         /* End function gxnrFgridposiblenewdetails_newrow */
      }

      protected void gxnrFgridedit_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1465( ) ;
         while ( nGXsfl_146_idx <= nRC_GXsfl_146 )
         {
            sendrow_1465( ) ;
            nGXsfl_146_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_146_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_idx+1);
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1465( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgrideditContainer)) ;
         /* End function gxnrFgridedit_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_866( ) ;
         while ( nGXsfl_86_idx <= nRC_GXsfl_86 )
         {
            sendrow_866( ) ;
            nGXsfl_86_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_idx+1);
            sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
            SubsflControlProps_866( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGridpurchaseordersfiltered_refresh( int subGridpurchaseordersfiltered_Rows ,
                                                             string AV49Register ,
                                                             string AV57Edit ,
                                                             string AV56Cancel ,
                                                             int AV24Supplier ,
                                                             bool AV53Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPURCHASEORDERSFILTERED_nCurrentRecord = 0;
         RF222( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridpurchaseordersfiltered_refresh */
      }

      protected void gxgrGrid1_refresh( int subGridpurchaseordersfiltered_Rows ,
                                        int AV24Supplier ,
                                        bool AV53Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF226( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrFgridedit_refresh( int subGridpurchaseordersfiltered_Rows ,
                                            int AV24Supplier ,
                                            bool AV53Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDEDIT_nCurrentRecord = 0;
         RF225( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridedit_refresh */
      }

      protected void gxgrFgridposiblenewdetails_refresh( int subGridpurchaseordersfiltered_Rows ,
                                                         int AV24Supplier ,
                                                         bool AV53Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDPOSIBLENEWDETAILS_nCurrentRecord = 0;
         RF224( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridposiblenewdetails_refresh */
      }

      protected void gxgrFgridcancel_refresh( int subGridpurchaseordersfiltered_Rows ,
                                              int AV24Supplier ,
                                              bool AV53Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDCANCEL_nCurrentRecord = 0;
         RF223( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridcancel_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html222( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV24Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24Supplier", StringUtil.LTrimStr( (decimal)(AV24Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
         }
         AV53Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Descending));
         AssignAttri("", false, "AV53Descending", AV53Descending);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF222( ) ;
         RF226( ) ;
         RF225( ) ;
         RF224( ) ;
         RF223( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcurrentstock_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlminiumstock_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlcurrentstock1_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlminiumstock1_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlcurrentstock3_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlminiumstock3_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlcurrentstock2_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlminiumstock2_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlquantityordered2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
      }

      protected void RF222( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridpurchaseordersfilteredContainer.ClearRows();
         }
         wbStart = 37;
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
         GridpurchaseordersfilteredContainer.AddObjectProperty("CmpContext", "");
         GridpurchaseordersfilteredContainer.AddObjectProperty("InMasterPage", "false");
         GridpurchaseordersfilteredContainer.AddObjectProperty("Class", "PromptGrid");
         GridpurchaseordersfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Backcolorstyle), 1, 0, ".", "")));
         GridpurchaseordersfilteredContainer.PageSize = subGridpurchaseordersfiltered_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            E39222 ();
            if ( ( subGridpurchaseordersfiltered_Islastpage == 0 ) && ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord > 0 ) && ( GRIDPURCHASEORDERSFILTERED_nGridOutOfScope == 0 ) && ( nGXsfl_37_idx == 1 ) )
            {
               GRIDPURCHASEORDERSFILTERED_nCurrentRecord = 0;
               GRIDPURCHASEORDERSFILTERED_nGridOutOfScope = 1;
               subgridpurchaseordersfiltered_firstpage( ) ;
               E39222 ();
            }
            wbEnd = 37;
            WB220( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes222( )
      {
      }

      protected void RF223( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgridcancelContainer.ClearRows();
         }
         wbStart = 240;
         nGXsfl_240_idx = 1;
         sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
         SubsflControlProps_2403( ) ;
         bGXsfl_240_Refreshing = true;
         FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
         FgridcancelContainer.AddObjectProperty("CmpContext", "");
         FgridcancelContainer.AddObjectProperty("InMasterPage", "false");
         FgridcancelContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FgridcancelContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FgridcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgridcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgridcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Backcolorstyle), 1, 0, ".", "")));
         FgridcancelContainer.PageSize = subFgridcancel_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2403( ) ;
            E32223 ();
            wbEnd = 240;
            WB220( ) ;
         }
         bGXsfl_240_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes223( )
      {
      }

      protected void RF224( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgridposiblenewdetailsContainer.ClearRows();
         }
         wbStart = 190;
         E30222 ();
         nGXsfl_190_idx = 1;
         sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
         SubsflControlProps_1904( ) ;
         bGXsfl_190_Refreshing = true;
         FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
         FgridposiblenewdetailsContainer.AddObjectProperty("CmpContext", "");
         FgridposiblenewdetailsContainer.AddObjectProperty("InMasterPage", "false");
         FgridposiblenewdetailsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
         FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(30), 9, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Class", "PromptGrid");
         FgridposiblenewdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Backcolorstyle), 1, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Height), 9, 0, ".", "")));
         FgridposiblenewdetailsContainer.PageSize = subFgridposiblenewdetails_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1904( ) ;
            E31224 ();
            wbEnd = 190;
            WB220( ) ;
         }
         bGXsfl_190_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes224( )
      {
      }

      protected void RF225( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgrideditContainer.ClearRows();
         }
         wbStart = 146;
         E27222 ();
         nGXsfl_146_idx = 1;
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1465( ) ;
         bGXsfl_146_Refreshing = true;
         FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
         FgrideditContainer.AddObjectProperty("CmpContext", "");
         FgrideditContainer.AddObjectProperty("InMasterPage", "false");
         FgrideditContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FgrideditContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FgrideditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgrideditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgrideditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Backcolorstyle), 1, 0, ".", "")));
         FgrideditContainer.PageSize = subFgridedit_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1465( ) ;
            E28225 ();
            wbEnd = 146;
            WB220( ) ;
         }
         bGXsfl_146_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes225( )
      {
      }

      protected void RF226( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 86;
         nGXsfl_86_idx = 1;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         bGXsfl_86_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_866( ) ;
            E25226 ();
            wbEnd = 86;
            WB220( ) ;
         }
         bGXsfl_86_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes226( )
      {
      }

      protected int subGridpurchaseordersfiltered_fnc_Pagecount( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( ((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nRecordCount/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nRecordCount/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Recordcount( )
      {
         return AV46SDTPurchaseOrderGenerateList.Count ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridpurchaseordersfiltered_firstpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridpurchaseordersfiltered_nextpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( ( GRIDPURCHASEORDERSFILTERED_nRecordCount >= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) ) && ( GRIDPURCHASEORDERSFILTERED_nEOF == 0 ) )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage+subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDPURCHASEORDERSFILTERED_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridpurchaseordersfiltered_previouspage( )
      {
         if ( GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage >= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage-subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridpurchaseordersfiltered_lastpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( GRIDPURCHASEORDERSFILTERED_nRecordCount > subGridpurchaseordersfiltered_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nRecordCount-subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nRecordCount-((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridpurchaseordersfiltered_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subFgridcancel_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_37_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcurrentstock_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlminiumstock_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlcurrentstock1_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlminiumstock1_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0), !bGXsfl_146_Refreshing);
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlcurrentstock3_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlminiumstock3_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0), !bGXsfl_190_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlcurrentstock2_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlminiumstock2_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         edtavCtlquantityordered2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0), !bGXsfl_240_Refreshing);
         GXVvSUPPLIER_html222( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP220( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E33222 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Detailsregister"), AV61DetailsRegister);
            ajax_req_read_hidden_sdt(cgiGet( "Detailsedit"), AV59DetailsEdit);
            ajax_req_read_hidden_sdt(cgiGet( "Posiblesnewdetails"), AV65PosiblesNewDetails);
            ajax_req_read_hidden_sdt(cgiGet( "Detailscancel"), AV60DetailsCancel);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpurchaseordergeneratelist"), AV46SDTPurchaseOrderGenerateList);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPURCHASEORDERGENERATELIST"), AV46SDTPurchaseOrderGenerateList);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_86 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_86"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_146 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_146"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_190 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_190"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_240 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_240"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDPURCHASEORDERSFILTERED_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridpurchaseordersfiltered_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            bttAdddetail_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ADDDETAIL_Enabled"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_37_fel_idx = 0;
            while ( nGXsfl_37_fel_idx < nRC_GXsfl_37 )
            {
               nGXsfl_37_fel_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_37_fel_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_fel_idx+1);
               sGXsfl_37_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_372( ) ;
               AV69GXV1 = (int)(nGXsfl_37_fel_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
               if ( ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) && ( AV69GXV1 > 0 ) )
               {
                  AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
                  AV57Edit = cgiGet( edtavEdit_Internalname);
                  AV56Cancel = cgiGet( edtavCancel_Internalname);
                  AV49Register = cgiGet( edtavRegister_Internalname);
               }
            }
            if ( nGXsfl_37_fel_idx == 0 )
            {
               nGXsfl_37_idx = 1;
               sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
               SubsflControlProps_372( ) ;
            }
            nGXsfl_37_fel_idx = 1;
            nRC_GXsfl_86 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_86"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_86_fel_idx = 0;
            while ( nGXsfl_86_fel_idx < nRC_GXsfl_86 )
            {
               nGXsfl_86_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_fel_idx+1);
               sGXsfl_86_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_866( ) ;
               AV74GXV6 = nGXsfl_86_fel_idx;
               if ( ( AV61DetailsRegister.Count >= AV74GXV6 ) && ( AV74GXV6 > 0 ) )
               {
                  AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
               }
            }
            if ( nGXsfl_86_fel_idx == 0 )
            {
               nGXsfl_86_idx = 1;
               sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
               SubsflControlProps_866( ) ;
            }
            nGXsfl_86_fel_idx = 1;
            nRC_GXsfl_146 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_146"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_146_fel_idx = 0;
            while ( nGXsfl_146_fel_idx < nRC_GXsfl_146 )
            {
               nGXsfl_146_fel_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_146_fel_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_fel_idx+1);
               sGXsfl_146_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1465( ) ;
               AV83GXV15 = nGXsfl_146_fel_idx;
               if ( ( AV59DetailsEdit.Count >= AV83GXV15 ) && ( AV83GXV15 > 0 ) )
               {
                  AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
                  AV62RemoveDetail = cgiGet( edtavRemovedetail_Internalname);
               }
            }
            if ( nGXsfl_146_fel_idx == 0 )
            {
               nGXsfl_146_idx = 1;
               sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
               SubsflControlProps_1465( ) ;
            }
            nGXsfl_146_fel_idx = 1;
            nRC_GXsfl_190 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_190"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_190_fel_idx = 0;
            while ( nGXsfl_190_fel_idx < nRC_GXsfl_190 )
            {
               nGXsfl_190_fel_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_190_fel_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_190_fel_idx+1);
               sGXsfl_190_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1904( ) ;
               AV89GXV21 = nGXsfl_190_fel_idx;
               if ( ( AV65PosiblesNewDetails.Count >= AV89GXV21 ) && ( AV89GXV21 > 0 ) )
               {
                  AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
                  AV66SelectThis = cgiGet( edtavSelectthis_Internalname);
               }
            }
            if ( nGXsfl_190_fel_idx == 0 )
            {
               nGXsfl_190_idx = 1;
               sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
               SubsflControlProps_1904( ) ;
            }
            nGXsfl_190_fel_idx = 1;
            nRC_GXsfl_240 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_240"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_240_fel_idx = 0;
            while ( nGXsfl_240_fel_idx < nRC_GXsfl_240 )
            {
               nGXsfl_240_fel_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_240_fel_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_240_fel_idx+1);
               sGXsfl_240_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2403( ) ;
               AV94GXV26 = nGXsfl_240_fel_idx;
               if ( ( AV60DetailsCancel.Count >= AV94GXV26 ) && ( AV94GXV26 > 0 ) )
               {
                  AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26));
               }
            }
            if ( nGXsfl_240_fel_idx == 0 )
            {
               nGXsfl_240_idx = 1;
               sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
               SubsflControlProps_2403( ) ;
            }
            nGXsfl_240_fel_idx = 1;
            /* Read variables values. */
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV24Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24Supplier", StringUtil.LTrimStr( (decimal)(AV24Supplier), 6, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"From Date"}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
            }
            else
            {
               AV26FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), 1);
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"To Date"}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
            }
            else
            {
               AV27ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), 1);
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
            }
            cmbavOrderby.Name = cmbavOrderby_Internalname;
            cmbavOrderby.CurrentValue = cgiGet( cmbavOrderby_Internalname);
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
            AV53Descending = StringUtil.StrToBool( cgiGet( chkavDescending_Internalname));
            AssignAttri("", false, "AV53Descending", AV53Descending);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALPAID");
               GX_FocusControl = edtavTotalpaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37TotalPaid = 0;
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
            }
            else
            {
               AV37TotalPaid = context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",");
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E12222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         AV74GXV6 = nGXsfl_86_idx;
         if ( ( AV74GXV6 > 0 ) && ( AV61DetailsRegister.Count >= AV74GXV6 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
         }
         /* 'RegisterOrder' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         /* Execute user subroutine: 'CONTROL' */
         S112 ();
         if (returnInSub) return;
         if ( AV54AllOk )
         {
            GXt_boolean1 = AV54AllOk;
            new purchaseorderregister(context ).execute(  AV55PurchaseOrderId, ref  AV37TotalPaid, ref  AV61DetailsRegister, out  GXt_boolean1) ;
            gx_BV86 = true;
            AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
            AV54AllOk = GXt_boolean1;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            if ( AV54AllOk )
            {
               GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
               new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
               AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
               AssignAttri("", false, "AV53Descending", AV53Descending);
               AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
               gx_BV37 = true;
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
               divTableregister_Visible = 0;
               AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
               AV37TotalPaid = 0;
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
               AV12Order.Load(0);
               AV61DetailsRegister.Clear();
               gx_BV86 = true;
               GX_msglist.addItem("Purchase Register successfull!");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void E13222( )
      {
         /* 'CancelRegister' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
         AV12Order.Load(0);
         AV61DetailsRegister.Clear();
         gx_BV86 = true;
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV86 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
            nGXsfl_86_bak_idx = nGXsfl_86_idx;
            gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_86_idx = nGXsfl_86_bak_idx;
            sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
            SubsflControlProps_866( ) ;
         }
      }

      protected void E14222( )
      {
         /* 'CancelEdit' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
         AV12Order.Load(0);
         AV59DetailsEdit.Clear();
         gx_BV146 = true;
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV146 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
            nGXsfl_146_bak_idx = nGXsfl_146_idx;
            gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_146_idx = nGXsfl_146_bak_idx;
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1465( ) ;
         }
      }

      protected void E15222( )
      {
         /* 'CancelCancel' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
         AV12Order.Load(0);
         AV60DetailsCancel.Clear();
         gx_BV240 = true;
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV240 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_240_bak_idx = nGXsfl_240_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_240_idx = nGXsfl_240_bak_idx;
            sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
            SubsflControlProps_2403( ) ;
         }
      }

      protected void E16222( )
      {
         AV83GXV15 = nGXsfl_146_idx;
         if ( ( AV83GXV15 > 0 ) && ( AV59DetailsEdit.Count >= AV83GXV15 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
         }
         /* 'Confirm' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         /* Execute user subroutine: 'CONTROLEDIT' */
         S122 ();
         if (returnInSub) return;
         if ( AV54AllOk )
         {
            GXt_boolean1 = AV54AllOk;
            new purchaseordermodify(context ).execute(  AV55PurchaseOrderId, ref  AV59DetailsEdit, out  GXt_boolean1) ;
            gx_BV146 = true;
            AV54AllOk = GXt_boolean1;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            if ( AV54AllOk )
            {
               GX_msglist.addItem("Purchase Order Update Successfully");
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
               divTableedit_Visible = 0;
               AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem("Purchase Order Update Failed");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_146_bak_idx = nGXsfl_146_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_146_idx = nGXsfl_146_bak_idx;
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1465( ) ;
      }

      protected void E17222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Supplier_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         /*  Sending Event outputs  */
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void E18222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Fromdate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         /*  Sending Event outputs  */
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void E19222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Todate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         /*  Sending Event outputs  */
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void E20222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Orderby_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         /*  Sending Event outputs  */
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void E21222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Descending_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
         /*  Sending Event outputs  */
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E33222 ();
         if (returnInSub) return;
      }

      protected void E33222( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
         gx_BV37 = true;
         edtavRegister_gximage = "GeneXusUnanimo_featured";
         AssignProp("", false, edtavRegister_Internalname, "gximage", edtavRegister_gximage, !bGXsfl_37_Refreshing);
         AV49Register = context.GetImagePath( "dd1aaecd-7f95-4983-9b3f-9e271796146e", "", context.GetTheme( ));
         AssignProp("", false, edtavRegister_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV100Register_GXI : context.convertURL( context.PathToRelativeUrl( AV49Register))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavRegister_Internalname, "SrcSet", context.GetImageSrcSet( AV49Register), true);
         AV100Register_GXI = GXDbFile.PathToUrl( context.GetImagePath( "dd1aaecd-7f95-4983-9b3f-9e271796146e", "", context.GetTheme( )));
         AssignProp("", false, edtavRegister_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV100Register_GXI : context.convertURL( context.PathToRelativeUrl( AV49Register))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavRegister_Internalname, "SrcSet", context.GetImageSrcSet( AV49Register), true);
         edtavEdit_gximage = "GeneXusUnanimo_edit";
         AssignProp("", false, edtavEdit_Internalname, "gximage", edtavEdit_gximage, !bGXsfl_37_Refreshing);
         AV57Edit = context.GetImagePath( "0262a982-cd0b-446a-a8f5-d714e80dd0f0", "", context.GetTheme( ));
         AssignProp("", false, edtavEdit_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV101Edit_GXI : context.convertURL( context.PathToRelativeUrl( AV57Edit))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavEdit_Internalname, "SrcSet", context.GetImageSrcSet( AV57Edit), true);
         AV101Edit_GXI = GXDbFile.PathToUrl( context.GetImagePath( "0262a982-cd0b-446a-a8f5-d714e80dd0f0", "", context.GetTheme( )));
         AssignProp("", false, edtavEdit_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV101Edit_GXI : context.convertURL( context.PathToRelativeUrl( AV57Edit))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavEdit_Internalname, "SrcSet", context.GetImageSrcSet( AV57Edit), true);
         edtavCancel_gximage = "GeneXusUnanimo_close_ico";
         AssignProp("", false, edtavCancel_Internalname, "gximage", edtavCancel_gximage, !bGXsfl_37_Refreshing);
         AV56Cancel = context.GetImagePath( "4b78ffc9-3fe7-423b-815e-aa116a4d611d", "", context.GetTheme( ));
         AssignProp("", false, edtavCancel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV102Cancel_GXI : context.convertURL( context.PathToRelativeUrl( AV56Cancel))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavCancel_Internalname, "SrcSet", context.GetImageSrcSet( AV56Cancel), true);
         AV102Cancel_GXI = GXDbFile.PathToUrl( context.GetImagePath( "4b78ffc9-3fe7-423b-815e-aa116a4d611d", "", context.GetTheme( )));
         AssignProp("", false, edtavCancel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV102Cancel_GXI : context.convertURL( context.PathToRelativeUrl( AV56Cancel))), !bGXsfl_37_Refreshing);
         AssignProp("", false, edtavCancel_Internalname, "SrcSet", context.GetImageSrcSet( AV56Cancel), true);
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
      }

      protected void E34222( )
      {
         AV74GXV6 = nGXsfl_86_idx;
         if ( ( AV74GXV6 > 0 ) && ( AV61DetailsRegister.Count >= AV74GXV6 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
         }
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Register_Click Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
         AV61DetailsRegister.Clear();
         gx_BV86 = true;
         AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
         AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 = AV61DetailsRegister;
         new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3) ;
         AV61DetailsRegister = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3;
         gx_BV86 = true;
         divTableregister_Visible = 1;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
      }

      protected void E35222( )
      {
         AV89GXV21 = nGXsfl_190_idx;
         if ( ( AV89GXV21 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV89GXV21 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
         }
         AV83GXV15 = nGXsfl_146_idx;
         if ( ( AV83GXV15 > 0 ) && ( AV59DetailsEdit.Count >= AV83GXV15 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
         }
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Edit_Click Routine */
         returnInSub = false;
         AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
         AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 = AV59DetailsEdit;
         new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3) ;
         AV59DetailsEdit = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3;
         gx_BV146 = true;
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 = AV65PosiblesNewDetails;
         new purchaseordercargeposiblenewdetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3) ;
         AV65PosiblesNewDetails = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3;
         gx_BV190 = true;
         AV12Order = new SdtPurchaseOrder(context);
         AV12Order.Load(AV55PurchaseOrderId);
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 1;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         if ( AV65PosiblesNewDetails.Count <= 0 )
         {
            bttAdddetail_Enabled = 0;
            AssignProp("", false, bttAdddetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttAdddetail_Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         if ( gx_BV146 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
            nGXsfl_146_bak_idx = nGXsfl_146_idx;
            gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_146_idx = nGXsfl_146_bak_idx;
            sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
            SubsflControlProps_1465( ) ;
         }
         if ( gx_BV190 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
            nGXsfl_190_bak_idx = nGXsfl_190_idx;
            gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_190_idx = nGXsfl_190_bak_idx;
            sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
            SubsflControlProps_1904( ) ;
         }
      }

      protected void E36222( )
      {
         AV94GXV26 = nGXsfl_240_idx;
         if ( ( AV94GXV26 > 0 ) && ( AV60DetailsCancel.Count >= AV94GXV26 ) )
         {
            AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26));
         }
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Cancel_Click Routine */
         returnInSub = false;
         AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
         AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 = AV60DetailsCancel;
         new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3) ;
         AV60DetailsCancel = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3;
         gx_BV240 = true;
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 1;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV240 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_240_bak_idx = nGXsfl_240_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_240_idx = nGXsfl_240_bak_idx;
            sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
            SubsflControlProps_2403( ) ;
         }
      }

      protected void E37222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Ctlsdtvoucherlink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV48window.Url = formatLink("apurchaseordergenerate.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV48window.SetReturnParms(new Object[] {});
         AV48window.Height = 370;
         AV48window.Width = 500;
         context.NewWindow(AV48window);
         /*  Sending Event outputs  */
      }

      protected void E38222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* Ctldetailslink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV48window.Url = formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV48window.SetReturnParms(new Object[] {});
         AV48window.Height = 370;
         AV48window.Width = 500;
         context.NewWindow(AV48window);
         /*  Sending Event outputs  */
      }

      protected void E23222( )
      {
         AV74GXV6 = nGXsfl_86_idx;
         if ( ( AV74GXV6 > 0 ) && ( AV61DetailsRegister.Count >= AV74GXV6 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
         }
         /* Ctlquantityreceived_Controlvaluechanged Routine */
         returnInSub = false;
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem));
         AV40OneDetail.gxTpr_Subtotal = (decimal)(AV40OneDetail.gxTpr_Newcostprice*AV40OneDetail.gxTpr_Quantityreceived);
         GXt_decimal4 = 0;
         new roundvalue(context ).execute(  AV40OneDetail.gxTpr_Subtotal, out  GXt_decimal4) ;
         ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem)).gxTpr_Subtotal = GXt_decimal4;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
      }

      protected void E24222( )
      {
         AV74GXV6 = nGXsfl_86_idx;
         if ( ( AV74GXV6 > 0 ) && ( AV61DetailsRegister.Count >= AV74GXV6 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
         }
         /* Ctlnewcostprice_Controlvaluechanged Routine */
         returnInSub = false;
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem));
         AV40OneDetail.gxTpr_Subtotal = (decimal)(AV40OneDetail.gxTpr_Newcostprice*AV40OneDetail.gxTpr_Quantityreceived);
         GXt_decimal4 = 0;
         new roundvalue(context ).execute(  AV40OneDetail.gxTpr_Subtotal, out  GXt_decimal4) ;
         ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem)).gxTpr_Subtotal = GXt_decimal4;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
      }

      protected void S132( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
         AV103GXV32 = 1;
         while ( AV103GXV32 <= AV61DetailsRegister.Count )
         {
            AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV103GXV32));
            AV37TotalPaid = (decimal)(AV37TotalPaid+(AV40OneDetail.gxTpr_Subtotal));
            AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
            AV103GXV32 = (int)(AV103GXV32+1);
         }
         GXt_decimal4 = AV37TotalPaid;
         new roundvalue(context ).execute(  AV37TotalPaid, out  GXt_decimal4) ;
         AV37TotalPaid = GXt_decimal4;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 10, 2));
      }

      protected void S112( )
      {
         /* 'CONTROL' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         AV104GXV33 = 1;
         while ( AV104GXV33 <= AV61DetailsRegister.Count )
         {
            AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV104GXV33));
            if ( ( AV40OneDetail.gxTpr_Subtotal < Convert.ToDecimal( 0 )) )
            {
               GX_msglist.addItem("Some Subtotal is invalid!");
               AV54AllOk = false;
               AssignAttri("", false, "AV54AllOk", AV54AllOk);
               if (true) break;
            }
            if ( AV40OneDetail.gxTpr_Quantityreceived < 0 )
            {
               GX_msglist.addItem("Some Quantity Received is invalid!");
               AV54AllOk = false;
               AssignAttri("", false, "AV54AllOk", AV54AllOk);
               if (true) break;
            }
            AV104GXV33 = (int)(AV104GXV33+1);
         }
         if ( AV61DetailsRegister.Count <= 0 )
         {
            GX_msglist.addItem("Choose a Purchase Order First!");
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
         if ( ( AV37TotalPaid < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Total Paid is invalid!");
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
      }

      protected void E22222( )
      {
         AV69GXV1 = (int)(nGXsfl_37_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV69GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
         }
         /* 'Yes' Routine */
         returnInSub = false;
         AV12Order = new SdtPurchaseOrder(context);
         AV12Order.Load(AV55PurchaseOrderId);
         AV12Order.gxTpr_Purchaseorderactive = false;
         AV12Order.Update();
         if ( AV12Order.Success() )
         {
            AV12Order.Load(0);
            AV60DetailsCancel.Clear();
            gx_BV240 = true;
            divTcancel_Visible = 0;
            AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
            GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = AV46SDTPurchaseOrderGenerateList;
            new purchaseordergetfiltered(context ).execute(  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2) ;
            AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
            AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
            AssignAttri("", false, "AV53Descending", AV53Descending);
            AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2;
            gx_BV37 = true;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            GX_msglist.addItem("Purchase Order Canceled Succefully");
            context.CommitDataStores("wpregisterpurchase",pr_default);
         }
         else
         {
            GX_msglist.addItem("Purchase Order has not been Cancel"+AV12Order.GetMessages().ToJSonString(false));
            context.RollbackDataStores("wpregisterpurchase",pr_default);
         }
         /*  Sending Event outputs  */
         if ( gx_BV240 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_240_bak_idx = nGXsfl_240_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
            nGXsfl_240_idx = nGXsfl_240_bak_idx;
            sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
            SubsflControlProps_2403( ) ;
         }
         if ( gx_BV37 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_37_bak_idx = nGXsfl_37_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV49Register, AV57Edit, AV56Cancel, AV24Supplier, AV53Descending) ;
            nGXsfl_37_idx = nGXsfl_37_bak_idx;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'CONTROLEDIT' Routine */
         returnInSub = false;
         if ( AV59DetailsEdit.Count <= 0 )
         {
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            GX_msglist.addItem("The Purchase Order must have at least one product");
         }
         if ( AV54AllOk )
         {
            AV105GXV34 = 1;
            while ( AV105GXV34 <= AV59DetailsEdit.Count )
            {
               AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV105GXV34));
               if ( AV40OneDetail.gxTpr_Quantityordered <= 0 )
               {
                  GX_msglist.addItem("Some Quatity is invalid!");
                  AV54AllOk = false;
                  AssignAttri("", false, "AV54AllOk", AV54AllOk);
                  if (true) break;
               }
               AV105GXV34 = (int)(AV105GXV34+1);
            }
         }
      }

      protected void E29222( )
      {
         AV89GXV21 = nGXsfl_190_idx;
         if ( ( AV89GXV21 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV89GXV21 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
         }
         AV83GXV15 = nGXsfl_146_idx;
         if ( ( AV83GXV15 > 0 ) && ( AV59DetailsEdit.Count >= AV83GXV15 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
         }
         /* Selectthis_Click Routine */
         returnInSub = false;
         AV59DetailsEdit.Add(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV65PosiblesNewDetails.CurrentItem)), 0);
         gx_BV146 = true;
         AV65PosiblesNewDetails.RemoveItem(AV65PosiblesNewDetails.IndexOf(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV65PosiblesNewDetails.CurrentItem))));
         gx_BV190 = true;
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_146_bak_idx = nGXsfl_146_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_146_idx = nGXsfl_146_bak_idx;
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1465( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
         nGXsfl_190_bak_idx = nGXsfl_190_idx;
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_190_idx = nGXsfl_190_bak_idx;
         sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
         SubsflControlProps_1904( ) ;
      }

      protected void E26222( )
      {
         AV83GXV15 = nGXsfl_146_idx;
         if ( ( AV83GXV15 > 0 ) && ( AV59DetailsEdit.Count >= AV83GXV15 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
         }
         AV89GXV21 = nGXsfl_190_idx;
         if ( ( AV89GXV21 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV89GXV21 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
         }
         /* Removedetail_Click Routine */
         returnInSub = false;
         AV65PosiblesNewDetails.Add((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV59DetailsEdit.CurrentItem)).Clone()), 0);
         gx_BV190 = true;
         AV59DetailsEdit.RemoveItem(AV59DetailsEdit.IndexOf(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV59DetailsEdit.CurrentItem))));
         gx_BV146 = true;
         bttAdddetail_Enabled = (int)(!bttAdddetail_Enabled);
         AssignProp("", false, bttAdddetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttAdddetail_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
         nGXsfl_190_bak_idx = nGXsfl_190_idx;
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_190_idx = nGXsfl_190_bak_idx;
         sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
         SubsflControlProps_1904( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_146_bak_idx = nGXsfl_146_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending) ;
         nGXsfl_146_idx = nGXsfl_146_bak_idx;
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1465( ) ;
      }

      protected void E27222( )
      {
         /* Fgridedit_Refresh Routine */
         returnInSub = false;
         edtavRemovedetail_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemovedetail_Internalname, "gximage", edtavRemovedetail_gximage, !bGXsfl_146_Refreshing);
         AV62RemoveDetail = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV106Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
         AV106Removedetail_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV106Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_146_Refreshing);
         AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
         /*  Sending Event outputs  */
      }

      protected void E30222( )
      {
         /* Fgridposiblenewdetails_Refresh Routine */
         returnInSub = false;
         edtavSelectthis_gximage = "GeneXusUnanimo_featured_green";
         AssignProp("", false, edtavSelectthis_Internalname, "gximage", edtavSelectthis_gximage, !bGXsfl_190_Refreshing);
         AV66SelectThis = context.GetImagePath( "af7f81cc-394c-4184-95e4-f6c46e6a69de", "", context.GetTheme( ));
         AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV107Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
         AV107Selectthis_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af7f81cc-394c-4184-95e4-f6c46e6a69de", "", context.GetTheme( )));
         AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV107Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_190_Refreshing);
         AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
         /*  Sending Event outputs  */
      }

      private void E39222( )
      {
         /* Gridpurchaseordersfiltered_Load Routine */
         returnInSub = false;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV46SDTPurchaseOrderGenerateList.Count )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            if ( ( subGridpurchaseordersfiltered_Islastpage == 1 ) || ( 5 == 0 ) || ( ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord >= GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage ) && ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord < GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage + subGridpurchaseordersfiltered_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_372( ) ;
            }
            GRIDPURCHASEORDERSFILTERED_nEOF = (short)(((GRIDPURCHASEORDERSFILTERED_nCurrentRecord<GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage+subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nEOF), 1, 0, ".", "")));
            GRIDPURCHASEORDERSFILTERED_nCurrentRecord = (long)(GRIDPURCHASEORDERSFILTERED_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
            {
               DoAjaxLoad(37, GridpurchaseordersfilteredRow);
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
      }

      private void E32223( )
      {
         /* Fgridcancel_Load Routine */
         returnInSub = false;
         AV94GXV26 = 1;
         while ( AV94GXV26 <= AV60DetailsCancel.Count )
         {
            AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 240;
            }
            sendrow_2403( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_240_Refreshing )
            {
               DoAjaxLoad(240, FgridcancelRow);
            }
            AV94GXV26 = (int)(AV94GXV26+1);
         }
      }

      private void E31224( )
      {
         /* Fgridposiblenewdetails_Load Routine */
         returnInSub = false;
         AV89GXV21 = 1;
         while ( AV89GXV21 <= AV65PosiblesNewDetails.Count )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 190;
            }
            sendrow_1904( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_190_Refreshing )
            {
               DoAjaxLoad(190, FgridposiblenewdetailsRow);
            }
            AV89GXV21 = (int)(AV89GXV21+1);
         }
      }

      private void E28225( )
      {
         /* Fgridedit_Load Routine */
         returnInSub = false;
         AV83GXV15 = 1;
         while ( AV83GXV15 <= AV59DetailsEdit.Count )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 146;
            }
            sendrow_1465( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_146_Refreshing )
            {
               DoAjaxLoad(146, FgrideditRow);
            }
            AV83GXV15 = (int)(AV83GXV15+1);
         }
      }

      private void E25226( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV74GXV6 = 1;
         while ( AV74GXV6 <= AV61DetailsRegister.Count )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 86;
            }
            sendrow_866( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_86_Refreshing )
            {
               DoAjaxLoad(86, Grid1Row);
            }
            AV74GXV6 = (int)(AV74GXV6+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA222( ) ;
         WS222( ) ;
         WE222( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202432421482632", true, true);
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
         context.AddJavascriptSource("wpregisterpurchase.js", "?202432421482632", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtavEdit_Internalname = "vEDIT_"+sGXsfl_37_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_37_idx;
         edtavRegister_Internalname = "vREGISTER_"+sGXsfl_37_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_37_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_37_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_37_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavEdit_Internalname = "vEDIT_"+sGXsfl_37_fel_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_37_fel_idx;
         edtavRegister_Internalname = "vREGISTER_"+sGXsfl_37_fel_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_37_fel_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_37_fel_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_37_fel_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         SubsflControlProps_372( ) ;
         WB220( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_37_idx <= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) * 1 ) )
         {
            GridpurchaseordersfilteredRow = GXWebRow.GetNew(context,GridpurchaseordersfilteredContainer);
            if ( subGridpurchaseordersfiltered_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
               }
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 0;
               subGridpurchaseordersfiltered_Backcolor = subGridpurchaseordersfiltered_Allbackcolor;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Uniform";
               }
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
               }
               subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 1;
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
               {
                  subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Even";
                  }
               }
               else
               {
                  subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
                  }
               }
            }
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavEdit_Enabled!=0)&&(edtavEdit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 38,'',false,'',37)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavEdit_gximage, "")==0) ? "" : "GX_Image_"+edtavEdit_gximage+"_Class");
            StyleString = "";
            AV57Edit_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit))&&String.IsNullOrEmpty(StringUtil.RTrim( AV101Edit_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV101Edit_GXI : context.PathToRelativeUrl( AV57Edit));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEdit_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Edit Order",(string)"Edit Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)5,(string)edtavEdit_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVEDIT.CLICK."+sGXsfl_37_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV57Edit_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCancel_Enabled!=0)&&(edtavCancel_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 39,'',false,'',37)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCancel_gximage, "")==0) ? "" : "GX_Image_"+edtavCancel_gximage+"_Class");
            StyleString = "";
            AV56Cancel_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel))&&String.IsNullOrEmpty(StringUtil.RTrim( AV102Cancel_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV102Cancel_GXI : context.PathToRelativeUrl( AV56Cancel));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCancel_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Cancel Order",(string)"Cancel Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)5,(string)edtavCancel_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVCANCEL.CLICK."+sGXsfl_37_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV56Cancel_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavRegister_Enabled!=0)&&(edtavRegister_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 40,'',false,'',37)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRegister_gximage, "")==0) ? "" : "GX_Image_"+edtavRegister_gximage+"_Class");
            StyleString = "";
            AV49Register_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV49Register))&&String.IsNullOrEmpty(StringUtil.RTrim( AV100Register_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV100Register_GXI : context.PathToRelativeUrl( AV49Register));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRegister_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Register Order",(string)"Register Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)5,(string)edtavRegister_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREGISTER.CLICK."+sGXsfl_37_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV49Register_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcreateddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1)).gxTpr_Createddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1)).gxTpr_Createddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcreateddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcreateddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsuppliername_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1)).gxTpr_Suppliername,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsuppliername_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsuppliername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldetailslink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1)).gxTpr_Detailslink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLDETAILSLINK.CLICK."+sGXsfl_37_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtldetailslink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtldetailslink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsdtvoucherlink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV69GXV1)).gxTpr_Sdtvoucherlink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLSDTVOUCHERLINK.CLICK."+sGXsfl_37_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsdtvoucherlink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsdtvoucherlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes222( ) ;
            GridpurchaseordersfilteredContainer.AddRow(GridpurchaseordersfilteredRow);
            nGXsfl_37_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_37_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void SubsflControlProps_866( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_86_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_86_idx;
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK_"+sGXsfl_86_idx;
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK_"+sGXsfl_86_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_86_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_86_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_86_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_86_idx;
      }

      protected void SubsflControlProps_fel_866( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_86_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_86_fel_idx;
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK_"+sGXsfl_86_fel_idx;
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK_"+sGXsfl_86_fel_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_86_fel_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_86_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_86_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_86_fel_idx;
      }

      protected void sendrow_866( )
      {
         SubsflControlProps_866( ) ;
         WB220( ) ;
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
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_86_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_86_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_86_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlquantityordered_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived_Internalname,(string)"Quantity Received",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 106,'',false,'"+sGXsfl_86_idx+"',86)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Quantityreceived), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Quantityreceived), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityreceived_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,(string)"New Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 109,'',false,'"+sGXsfl_86_idx+"',86)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Newcostprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Newcostprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,109);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,(string)"Subtotal",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Subtotal, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Subtotal, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV74GXV6)).gxTpr_Subtotal, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes226( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_86_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_idx+1);
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         /* End function sendrow_866 */
      }

      protected void SubsflControlProps_1465( )
      {
         edtavRemovedetail_Internalname = "vREMOVEDETAIL_"+sGXsfl_146_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_146_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_146_idx;
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1_"+sGXsfl_146_idx;
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1_"+sGXsfl_146_idx;
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1_"+sGXsfl_146_idx;
      }

      protected void SubsflControlProps_fel_1465( )
      {
         edtavRemovedetail_Internalname = "vREMOVEDETAIL_"+sGXsfl_146_fel_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_146_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_146_fel_idx;
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1_"+sGXsfl_146_fel_idx;
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1_"+sGXsfl_146_fel_idx;
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1_"+sGXsfl_146_fel_idx;
      }

      protected void sendrow_1465( )
      {
         SubsflControlProps_1465( ) ;
         WB220( ) ;
         FgrideditRow = GXWebRow.GetNew(context,FgrideditContainer);
         if ( subFgridedit_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridedit_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Odd";
            }
         }
         else if ( subFgridedit_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridedit_Backstyle = 0;
            subFgridedit_Backcolor = subFgridedit_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Uniform";
            }
         }
         else if ( subFgridedit_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridedit_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Odd";
            }
            subFgridedit_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridedit_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridedit_Backstyle = 1;
            if ( ((int)((nGXsfl_146_idx) % (2))) == 0 )
            {
               subFgridedit_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
               {
                  subFgridedit_Linesclass = subFgridedit_Class+"Even";
               }
            }
            else
            {
               subFgridedit_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
               {
                  subFgridedit_Linesclass = subFgridedit_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgrideditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridedit_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_146_idx+"\">") ;
         }
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_146_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavRemovedetail_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemovedetail_Enabled!=0)&&(edtavRemovedetail_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 152,'',false,'',146)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemovedetail_gximage, "")==0) ? "" : "GX_Image_"+edtavRemovedetail_gximage+"_Class");
         StyleString = "";
         AV62RemoveDetail_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail))&&String.IsNullOrEmpty(StringUtil.RTrim( AV106Removedetail_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV106Removedetail_GXI : context.PathToRelativeUrl( AV62RemoveDetail));
         FgrideditRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemovedetail_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavRemovedetail_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVEDETAIL.CLICK."+sGXsfl_146_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV62RemoveDetail_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode1_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)146,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)146,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock1_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock1_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)146,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock1_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock1_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)146,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered1_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantityordered1_Enabled!=0)&&(edtavCtlquantityordered1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 167,'',false,'"+sGXsfl_146_idx+"',146)\"" : " ");
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV83GXV15)).gxTpr_Quantityordered), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantityordered1_Enabled!=0)&&(edtavCtlquantityordered1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,167);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)146,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes225( ) ;
         /* End of Columns property logic. */
         FgrideditContainer.AddRow(FgrideditRow);
         nGXsfl_146_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_146_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_146_idx+1);
         sGXsfl_146_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_146_idx), 4, 0), 4, "0");
         SubsflControlProps_1465( ) ;
         /* End function sendrow_1465 */
      }

      protected void SubsflControlProps_1904( )
      {
         edtavSelectthis_Internalname = "vSELECTTHIS_"+sGXsfl_190_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_190_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_190_idx;
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3_"+sGXsfl_190_idx;
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3_"+sGXsfl_190_idx;
      }

      protected void SubsflControlProps_fel_1904( )
      {
         edtavSelectthis_Internalname = "vSELECTTHIS_"+sGXsfl_190_fel_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_190_fel_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_190_fel_idx;
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3_"+sGXsfl_190_fel_idx;
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3_"+sGXsfl_190_fel_idx;
      }

      protected void sendrow_1904( )
      {
         SubsflControlProps_1904( ) ;
         WB220( ) ;
         FgridposiblenewdetailsRow = GXWebRow.GetNew(context,FgridposiblenewdetailsContainer);
         if ( subFgridposiblenewdetails_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
            }
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 0;
            subFgridposiblenewdetails_Backcolor = subFgridposiblenewdetails_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Uniform";
            }
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
            }
            subFgridposiblenewdetails_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 1;
            if ( ((int)((nGXsfl_190_idx) % (2))) == 0 )
            {
               subFgridposiblenewdetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
               {
                  subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Even";
               }
            }
            else
            {
               subFgridposiblenewdetails_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
               {
                  subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridposiblenewdetails_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_190_idx+"\">") ;
         }
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_190_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Select This",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavSelectthis_Enabled!=0)&&(edtavSelectthis_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 195,'',false,'',190)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavSelectthis_gximage, "")==0) ? "" : "GX_Image_"+edtavSelectthis_gximage+"_Class");
         StyleString = "";
         AV66SelectThis_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis))&&String.IsNullOrEmpty(StringUtil.RTrim( AV107Selectthis_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV107Selectthis_GXI : context.PathToRelativeUrl( AV66SelectThis));
         FgridposiblenewdetailsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelectthis_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavSelectthis_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVSELECTTHIS.CLICK."+sGXsfl_190_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV66SelectThis_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode3_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)190,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname3_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)190,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock3_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock3_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock3_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock3_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)190,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock3_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock3_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock3_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV89GXV21)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock3_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)190,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes224( ) ;
         /* End of Columns property logic. */
         FgridposiblenewdetailsContainer.AddRow(FgridposiblenewdetailsRow);
         nGXsfl_190_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_190_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_190_idx+1);
         sGXsfl_190_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_190_idx), 4, 0), 4, "0");
         SubsflControlProps_1904( ) ;
         /* End function sendrow_1904 */
      }

      protected void SubsflControlProps_2403( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_240_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_240_idx;
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2_"+sGXsfl_240_idx;
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2_"+sGXsfl_240_idx;
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2_"+sGXsfl_240_idx;
      }

      protected void SubsflControlProps_fel_2403( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_240_fel_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_240_fel_idx;
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2_"+sGXsfl_240_fel_idx;
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2_"+sGXsfl_240_fel_idx;
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2_"+sGXsfl_240_fel_idx;
      }

      protected void sendrow_2403( )
      {
         SubsflControlProps_2403( ) ;
         WB220( ) ;
         FgridcancelRow = GXWebRow.GetNew(context,FgridcancelContainer);
         if ( subFgridcancel_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridcancel_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
            }
         }
         else if ( subFgridcancel_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridcancel_Backstyle = 0;
            subFgridcancel_Backcolor = subFgridcancel_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Uniform";
            }
         }
         else if ( subFgridcancel_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridcancel_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
            }
            subFgridcancel_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridcancel_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridcancel_Backstyle = 1;
            if ( ((int)((nGXsfl_240_idx) % (2))) == 0 )
            {
               subFgridcancel_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
               {
                  subFgridcancel_Linesclass = subFgridcancel_Class+"Even";
               }
            }
            else
            {
               subFgridcancel_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
               {
                  subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgridcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridcancel_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_240_idx+"\">") ;
         }
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table2_Internalname+"_"+sGXsfl_240_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode2_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)240,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)240,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock2_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)240,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock2_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)240,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered2_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV94GXV26)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlquantityordered2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)240,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes223( ) ;
         /* End of Columns property logic. */
         FgridcancelContainer.AddRow(FgridcancelRow);
         nGXsfl_240_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_240_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_240_idx+1);
         sGXsfl_240_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_240_idx), 4, 0), 4, "0");
         SubsflControlProps_2403( ) ;
         /* End function sendrow_2403 */
      }

      protected void init_web_controls( )
      {
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         cmbavOrderby.Name = "vORDERBY";
         cmbavOrderby.WebTags = "";
         cmbavOrderby.addItem("1", "Supplier", 0);
         cmbavOrderby.addItem("2", "Created", 0);
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         }
         chkavDescending.Name = "vDESCENDING";
         chkavDescending.WebTags = "";
         chkavDescending.Caption = "";
         AssignProp("", false, chkavDescending_Internalname, "TitleCaption", chkavDescending.Caption, true);
         chkavDescending.CheckedValue = "false";
         AV53Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Descending));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            if ( subGridpurchaseordersfiltered_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridpurchaseordersfiltered_Internalname, subGridpurchaseordersfiltered_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridpurchaseordersfiltered_Backcolorstyle == 0 )
            {
               subGridpurchaseordersfiltered_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Title";
               }
            }
            else
            {
               subGridpurchaseordersfiltered_Titlebackstyle = 1;
               if ( subGridpurchaseordersfiltered_Backcolorstyle == 1 )
               {
                  subGridpurchaseordersfiltered_Titlebackcolor = subGridpurchaseordersfiltered_Allbackcolor;
                  if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavEdit_gximage, "")==0) ? "" : "GX_Image_"+edtavEdit_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCancel_gximage, "")==0) ? "" : "GX_Image_"+edtavCancel_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavRegister_gximage, "")==0) ? "" : "GX_Image_"+edtavRegister_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Details") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Voucher") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
         }
         else
         {
            GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
            GridpurchaseordersfilteredContainer.AddObjectProperty("Header", subGridpurchaseordersfiltered_Header);
            GridpurchaseordersfilteredContainer.AddObjectProperty("Class", "PromptGrid");
            GridpurchaseordersfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Backcolorstyle), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("CmpContext", "");
            GridpurchaseordersfilteredContainer.AddObjectProperty("InMasterPage", "false");
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV57Edit));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV56Cancel));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV49Register));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcreateddate_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsuppliername_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtldetailslink_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Selectedindex), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowselection), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Selectioncolor), 9, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowhovering), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Hoveringcolor), 9, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowcollapsing), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl86( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"86\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
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

      protected void StartGridControl146( )
      {
         if ( FgrideditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"DivS\" data-gxgridid=\"146\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFgridedit_Internalname, subFgridedit_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
         }
         else
         {
            FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
            FgrideditContainer.AddObjectProperty("Header", subFgridedit_Header);
            FgrideditContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FgrideditContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FgrideditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Backcolorstyle), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("CmpContext", "");
            FgrideditContainer.AddObjectProperty("InMasterPage", "false");
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Value", context.convertURL( AV62RemoveDetail));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Selectedindex), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowselection), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Selectioncolor), 9, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowhovering), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Hoveringcolor), 9, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowcollapsing), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl190( )
      {
         if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"DivS\" data-gxgridid=\"190\">") ;
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(30), 10, 0) + "" + ";";
            GxWebStd.gx_table_start( context, subFgridposiblenewdetails_Internalname, subFgridposiblenewdetails_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
         }
         else
         {
            FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
            FgridposiblenewdetailsContainer.AddObjectProperty("Header", subFgridposiblenewdetails_Header);
            FgridposiblenewdetailsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
            FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(30), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Class", "PromptGrid");
            FgridposiblenewdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Backcolorstyle), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Height), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("CmpContext", "");
            FgridposiblenewdetailsContainer.AddObjectProperty("InMasterPage", "false");
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Value", context.convertURL( AV66SelectThis));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Selectedindex), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowselection), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Selectioncolor), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowhovering), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Hoveringcolor), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowcollapsing), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl240( )
      {
         if ( FgridcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"DivS\" data-gxgridid=\"240\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFgridcancel_Internalname, subFgridcancel_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
         }
         else
         {
            FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
            FgridcancelContainer.AddObjectProperty("Header", subFgridcancel_Header);
            FgridcancelContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FgridcancelContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FgridcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Backcolorstyle), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("CmpContext", "");
            FgridcancelContainer.AddObjectProperty("InMasterPage", "false");
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Selectedindex), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowselection), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Selectioncolor), 9, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowhovering), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Hoveringcolor), 9, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowcollapsing), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavSupplier_Internalname = "vSUPPLIER";
         edtavFromdate_Internalname = "vFROMDATE";
         edtavTodate_Internalname = "vTODATE";
         cmbavOrderby_Internalname = "vORDERBY";
         chkavDescending_Internalname = "vDESCENDING";
         edtavEdit_Internalname = "vEDIT";
         edtavCancel_Internalname = "vCANCEL";
         edtavRegister_Internalname = "vREGISTER";
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE";
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME";
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK";
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK";
         divTable1_Internalname = "TABLE1";
         edtavTotalpaid_Internalname = "vTOTALPAID";
         bttRegisterorder_Internalname = "REGISTERORDER";
         bttCancelregister_Internalname = "CANCELREGISTER";
         divTablebuttonsregister_Internalname = "TABLEBUTTONSREGISTER";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK";
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK";
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED";
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divGrid1table_Internalname = "GRID1TABLE";
         divTablecontentregister_Internalname = "TABLECONTENTREGISTER";
         divTableregister_Internalname = "TABLEREGISTER";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel1_Internalname = "CANCEL1";
         divTablebuttonsedit_Internalname = "TABLEBUTTONSEDIT";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtavRemovedetail_Internalname = "vREMOVEDETAIL";
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1";
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1";
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1";
         divGrid1table1_Internalname = "GRID1TABLE1";
         bttAdddetail_Internalname = "ADDDETAIL";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtavSelectthis_Internalname = "vSELECTTHIS";
         edtavCtlcode3_Internalname = "CTLCODE3";
         edtavCtlname3_Internalname = "CTLNAME3";
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3";
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3";
         divGrid2table_Internalname = "GRID2TABLE";
         divTable2_Internalname = "TABLE2";
         divTablecontentedit_Internalname = "TABLECONTENTEDIT";
         divTableedit_Internalname = "TABLEEDIT";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         bttYes_Internalname = "YES";
         bttNo_Internalname = "NO";
         divTablebuttonscancel_Internalname = "TABLEBUTTONSCANCEL";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtavCtlcode2_Internalname = "CTLCODE2";
         edtavCtlname2_Internalname = "CTLNAME2";
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2";
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2";
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2";
         divGrid1table2_Internalname = "GRID1TABLE2";
         divTablecontentcancel_Internalname = "TABLECONTENTCANCEL";
         divTcancel_Internalname = "TCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpurchaseordersfiltered_Internalname = "GRIDPURCHASEORDERSFILTERED";
         subGrid1_Internalname = "GRID1";
         subFgridedit_Internalname = "FGRIDEDIT";
         subFgridposiblenewdetails_Internalname = "FGRIDPOSIBLENEWDETAILS";
         subFgridcancel_Internalname = "FGRIDCANCEL";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subFgridcancel_Allowcollapsing = 0;
         subFgridposiblenewdetails_Allowcollapsing = 0;
         subFgridedit_Allowcollapsing = 0;
         subGrid1_Allowcollapsing = 0;
         subGridpurchaseordersfiltered_Allowcollapsing = 1;
         subGridpurchaseordersfiltered_Allowselection = 0;
         subGridpurchaseordersfiltered_Header = "";
         chkavDescending.Caption = "Desc";
         edtavCtlquantityordered2_Jsonclick = "";
         edtavCtlquantityordered2_Enabled = 0;
         edtavCtlminiumstock2_Jsonclick = "";
         edtavCtlminiumstock2_Enabled = 0;
         edtavCtlcurrentstock2_Jsonclick = "";
         edtavCtlcurrentstock2_Enabled = 0;
         edtavCtlname2_Jsonclick = "";
         edtavCtlname2_Enabled = 0;
         edtavCtlcode2_Jsonclick = "";
         edtavCtlcode2_Enabled = 0;
         subFgridcancel_Class = "FreeStyleGrid";
         edtavCtlminiumstock3_Jsonclick = "";
         edtavCtlminiumstock3_Enabled = 0;
         edtavCtlcurrentstock3_Jsonclick = "";
         edtavCtlcurrentstock3_Enabled = 0;
         edtavCtlname3_Jsonclick = "";
         edtavCtlname3_Enabled = 0;
         edtavCtlcode3_Jsonclick = "";
         edtavCtlcode3_Enabled = 0;
         edtavSelectthis_Jsonclick = "";
         edtavSelectthis_Visible = 1;
         edtavSelectthis_Enabled = 1;
         subFgridposiblenewdetails_Class = "PromptGrid";
         edtavCtlquantityordered1_Jsonclick = "";
         edtavCtlquantityordered1_Visible = 1;
         edtavCtlquantityordered1_Enabled = 1;
         edtavCtlminiumstock1_Jsonclick = "";
         edtavCtlminiumstock1_Enabled = 0;
         edtavCtlcurrentstock1_Jsonclick = "";
         edtavCtlcurrentstock1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavCtlcode1_Jsonclick = "";
         edtavCtlcode1_Enabled = 0;
         edtavRemovedetail_Jsonclick = "";
         edtavRemovedetail_Visible = 1;
         edtavRemovedetail_Enabled = 1;
         subFgridedit_Class = "FreeStyleGrid";
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = 1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlquantityreceived_Jsonclick = "";
         edtavCtlquantityreceived_Visible = 1;
         edtavCtlquantityreceived_Enabled = 1;
         edtavCtlquantityordered_Jsonclick = "";
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlminiumstock_Jsonclick = "";
         edtavCtlminiumstock_Enabled = 0;
         edtavCtlcurrentstock_Jsonclick = "";
         edtavCtlcurrentstock_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subGrid1_Class = "FreeStyleGrid";
         edtavCtlsdtvoucherlink_Jsonclick = "";
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtldetailslink_Jsonclick = "";
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsuppliername_Jsonclick = "";
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlcreateddate_Jsonclick = "";
         edtavCtlcreateddate_Enabled = 0;
         edtavRegister_Jsonclick = "";
         edtavRegister_Visible = -1;
         edtavRegister_Enabled = 1;
         edtavCancel_Jsonclick = "";
         edtavCancel_Visible = -1;
         edtavCancel_Enabled = 1;
         edtavEdit_Jsonclick = "";
         edtavEdit_Visible = -1;
         edtavEdit_Enabled = 1;
         subGridpurchaseordersfiltered_Class = "PromptGrid";
         subGridpurchaseordersfiltered_Backcolorstyle = 0;
         edtavSelectthis_gximage = "";
         edtavRemovedetail_gximage = "";
         edtavCancel_gximage = "";
         edtavEdit_gximage = "";
         edtavRegister_gximage = "";
         subGrid1_Backcolorstyle = 0;
         subFgridedit_Backcolorstyle = 0;
         subFgridposiblenewdetails_Height = 30;
         subFgridposiblenewdetails_Backcolorstyle = 0;
         subFgridcancel_Backcolorstyle = 0;
         edtavCtlquantityordered2_Enabled = -1;
         edtavCtlminiumstock2_Enabled = -1;
         edtavCtlcurrentstock2_Enabled = -1;
         edtavCtlname2_Enabled = -1;
         edtavCtlcode2_Enabled = -1;
         edtavCtlminiumstock3_Enabled = -1;
         edtavCtlcurrentstock3_Enabled = -1;
         edtavCtlname3_Enabled = -1;
         edtavCtlcode3_Enabled = -1;
         edtavCtlminiumstock1_Enabled = -1;
         edtavCtlcurrentstock1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlcode1_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlquantityordered_Enabled = -1;
         edtavCtlminiumstock_Enabled = -1;
         edtavCtlcurrentstock_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlsdtvoucherlink_Enabled = -1;
         edtavCtldetailslink_Enabled = -1;
         edtavCtlsuppliername_Enabled = -1;
         edtavCtlcreateddate_Enabled = -1;
         divTcancel_Visible = 1;
         divTable2_Visible = 1;
         bttAdddetail_Enabled = 1;
         divTableedit_Visible = 1;
         edtavTotalpaid_Jsonclick = "";
         edtavTotalpaid_Enabled = 1;
         divTableregister_Visible = 1;
         chkavDescending.Enabled = 1;
         cmbavOrderby_Jsonclick = "";
         cmbavOrderby.Enabled = 1;
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         dynavSupplier_Jsonclick = "";
         dynavSupplier.Enabled = 1;
         subGridpurchaseordersfiltered_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRegister Purchase";
         subGridpurchaseordersfiltered_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'REGISTERORDER'","{handler:'E12222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nEOF'}]");
         setEventMetadata("'REGISTERORDER'",",oparms:[{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'}]}");
         setEventMetadata("'CANCELREGISTER'","{handler:'E13222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("'CANCELREGISTER'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'}]}");
         setEventMetadata("'CANCELEDIT'","{handler:'E14222',iparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("'CANCELEDIT'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'}]}");
         setEventMetadata("'CANCELCANCEL'","{handler:'E15222',iparms:[{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nEOF'},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("'CANCELCANCEL'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'}]}");
         setEventMetadata("'CONFIRM'","{handler:'E16222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("'CONFIRM'",",oparms:[{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'}]}");
         setEventMetadata("VSUPPLIER.CONTROLVALUECHANGED","{handler:'E17222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("VSUPPLIER.CONTROLVALUECHANGED",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("VFROMDATE.CONTROLVALUECHANGED","{handler:'E18222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("VFROMDATE.CONTROLVALUECHANGED",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("VTODATE.CONTROLVALUECHANGED","{handler:'E19222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("VTODATE.CONTROLVALUECHANGED",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("VORDERBY.CONTROLVALUECHANGED","{handler:'E20222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("VORDERBY.CONTROLVALUECHANGED",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("VDESCENDING.CONTROLVALUECHANGED","{handler:'E21222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("VDESCENDING.CONTROLVALUECHANGED",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("VREGISTER.CLICK","{handler:'E34222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("VREGISTER.CLICK",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'}]}");
         setEventMetadata("VEDIT.CLICK","{handler:'E35222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("VEDIT.CLICK",",oparms:[{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{ctrl:'ADDDETAIL',prop:'Enabled'}]}");
         setEventMetadata("VCANCEL.CLICK","{handler:'E36222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nEOF'},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("VCANCEL.CLICK",",oparms:[{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'}]}");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK","{handler:'E37222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37}]");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLDETAILSLINK.CLICK","{handler:'E38222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37}]");
         setEventMetadata("CTLDETAILSLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLQUANTITYRECEIVED.CONTROLVALUECHANGED","{handler:'E23222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("CTLQUANTITYRECEIVED.CONTROLVALUECHANGED",",oparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'}]}");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED","{handler:'E24222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED",",oparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZ9.99'}]}");
         setEventMetadata("'YES'","{handler:'E22222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86}]");
         setEventMetadata("'YES'",",oparms:[{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("'ADDDETAIL'","{handler:'E11221',iparms:[]");
         setEventMetadata("'ADDDETAIL'",",oparms:[{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'}]}");
         setEventMetadata("VSELECTTHIS.CLICK","{handler:'E29222',iparms:[{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("VSELECTTHIS.CLICK",",oparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'}]}");
         setEventMetadata("VREMOVEDETAIL.CLICK","{handler:'E26222',iparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{ctrl:'ADDDETAIL',prop:'Enabled'},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:240,pic:''},{av:'nGXsfl_240_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:240},{av:'nRC_GXsfl_240',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:240},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("VREMOVEDETAIL.CLICK",",oparms:[{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:190,pic:''},{av:'nGXsfl_190_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:190},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_190',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:190},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:146,pic:''},{av:'nGXsfl_146_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:146},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_146',ctrl:'FGRIDEDIT',prop:'GridRC',grid:146},{ctrl:'ADDDETAIL',prop:'Enabled'}]}");
         setEventMetadata("FGRIDEDIT.REFRESH","{handler:'E27222',iparms:[]");
         setEventMetadata("FGRIDEDIT.REFRESH",",oparms:[{av:'AV62RemoveDetail',fld:'vREMOVEDETAIL',pic:''}]}");
         setEventMetadata("FGRIDPOSIBLENEWDETAILS.REFRESH","{handler:'E30222',iparms:[]");
         setEventMetadata("FGRIDPOSIBLENEWDETAILS.REFRESH",",oparms:[{av:'AV66SelectThis',fld:'vSELECTTHIS',pic:''}]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_FIRSTPAGE","{handler:'subgridpurchaseordersfiltered_firstpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_PREVPAGE","{handler:'subgridpurchaseordersfiltered_previouspage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_NEXTPAGE","{handler:'subgridpurchaseordersfiltered_nextpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_LASTPAGE","{handler:'subgridpurchaseordersfiltered_lastpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:37,pic:''},{av:'nGXsfl_37_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:37},{av:'nRC_GXsfl_37',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:37},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV49Register',fld:'vREGISTER',pic:''},{av:'AV57Edit',fld:'vEDIT',pic:''},{av:'AV56Cancel',fld:'vCANCEL',pic:''},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_FROMDATE","{handler:'Validv_Fromdate',iparms:[]");
         setEventMetadata("VALIDV_FROMDATE",",oparms:[]}");
         setEventMetadata("VALIDV_TODATE","{handler:'Validv_Todate',iparms:[]");
         setEventMetadata("VALIDV_TODATE",",oparms:[]}");
         setEventMetadata("VALIDV_ORDERBY","{handler:'Validv_Orderby',iparms:[]");
         setEventMetadata("VALIDV_ORDERBY",",oparms:[]}");
         setEventMetadata("VALIDV_TOTALPAID","{handler:'Validv_Totalpaid',iparms:[]");
         setEventMetadata("VALIDV_TOTALPAID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv5',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV13","{handler:'Validv_Gxv13',iparms:[]");
         setEventMetadata("VALIDV_GXV13",",oparms:[]}");
         setEventMetadata("VALIDV_GXV14","{handler:'Validv_Gxv14',iparms:[]");
         setEventMetadata("VALIDV_GXV14",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv20',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv25',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv31',iparms:[]");
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
         AV49Register = "";
         AV57Edit = "";
         AV56Cancel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV61DetailsRegister = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV59DetailsEdit = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV65PosiblesNewDetails = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV60DetailsCancel = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV46SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV26FromDate = DateTime.MinValue;
         AV27ToDate = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         GridpurchaseordersfilteredContainer = new GXWebGrid( context);
         sStyleString = "";
         bttRegisterorder_Jsonclick = "";
         bttCancelregister_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         lblTextblock21_Jsonclick = "";
         bttConfirm_Jsonclick = "";
         bttCancel1_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         FgrideditContainer = new GXWebGrid( context);
         bttAdddetail_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         FgridposiblenewdetailsContainer = new GXWebGrid( context);
         lblTextblock15_Jsonclick = "";
         bttYes_Jsonclick = "";
         bttNo_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         FgridcancelContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV62RemoveDetail = "";
         AV106Removedetail_GXI = "";
         AV66SelectThis = "";
         AV107Selectthis_GXI = "";
         AV101Edit_GXI = "";
         AV102Cancel_GXI = "";
         AV100Register_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00222_A4SupplierId = new int[1] ;
         H00222_A5SupplierName = new string[] {""} ;
         AV12Order = new SdtPurchaseOrder(context);
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV48window = new GXWindow();
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         GridpurchaseordersfilteredRow = new GXWebRow();
         FgridcancelRow = new GXWebRow();
         FgridposiblenewdetailsRow = new GXWebRow();
         FgrideditRow = new GXWebRow();
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridpurchaseordersfiltered_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         subGrid1_Linesclass = "";
         subFgridedit_Linesclass = "";
         subFgridposiblenewdetails_Linesclass = "";
         subFgridcancel_Linesclass = "";
         GridpurchaseordersfilteredColumn = new GXWebColumn();
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         subFgridedit_Header = "";
         FgrideditColumn = new GXWebColumn();
         subFgridposiblenewdetails_Header = "";
         FgridposiblenewdetailsColumn = new GXWebColumn();
         subFgridcancel_Header = "";
         FgridcancelColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregisterpurchase__default(),
            new Object[][] {
                new Object[] {
               H00222_A4SupplierId, H00222_A5SupplierName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcreateddate_Enabled = 0;
         edtavCtlsuppliername_Enabled = 0;
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlcurrentstock_Enabled = 0;
         edtavCtlminiumstock_Enabled = 0;
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlcode1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlcurrentstock1_Enabled = 0;
         edtavCtlminiumstock1_Enabled = 0;
         edtavCtlcode3_Enabled = 0;
         edtavCtlname3_Enabled = 0;
         edtavCtlcurrentstock3_Enabled = 0;
         edtavCtlminiumstock3_Enabled = 0;
         edtavCtlcode2_Enabled = 0;
         edtavCtlname2_Enabled = 0;
         edtavCtlcurrentstock2_Enabled = 0;
         edtavCtlminiumstock2_Enabled = 0;
         edtavCtlquantityordered2_Enabled = 0;
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GRIDPURCHASEORDERSFILTERED_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subGridpurchaseordersfiltered_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short AV52OrderBy ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridpurchaseordersfiltered_Backcolorstyle ;
      private short subFgridcancel_Backcolorstyle ;
      private short subFgridposiblenewdetails_Backcolorstyle ;
      private short subFgridedit_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short FGRIDCANCEL_nEOF ;
      private short FGRIDPOSIBLENEWDETAILS_nEOF ;
      private short FGRIDEDIT_nEOF ;
      private short GRID1_nEOF ;
      private short nGXWrapped ;
      private short subGridpurchaseordersfiltered_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subFgridedit_Backstyle ;
      private short subFgridposiblenewdetails_Backstyle ;
      private short subFgridcancel_Backstyle ;
      private short subGridpurchaseordersfiltered_Titlebackstyle ;
      private short subGridpurchaseordersfiltered_Allowselection ;
      private short subGridpurchaseordersfiltered_Allowhovering ;
      private short subGridpurchaseordersfiltered_Allowcollapsing ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subFgridedit_Allowselection ;
      private short subFgridedit_Allowhovering ;
      private short subFgridedit_Allowcollapsing ;
      private short subFgridedit_Collapsed ;
      private short subFgridposiblenewdetails_Allowselection ;
      private short subFgridposiblenewdetails_Allowhovering ;
      private short subFgridposiblenewdetails_Allowcollapsing ;
      private short subFgridposiblenewdetails_Collapsed ;
      private short subFgridcancel_Allowselection ;
      private short subFgridcancel_Allowhovering ;
      private short subFgridcancel_Allowcollapsing ;
      private short subFgridcancel_Collapsed ;
      private int bttAdddetail_Enabled ;
      private int nRC_GXsfl_37 ;
      private int nRC_GXsfl_86 ;
      private int nRC_GXsfl_146 ;
      private int nRC_GXsfl_190 ;
      private int nRC_GXsfl_240 ;
      private int subGridpurchaseordersfiltered_Rows ;
      private int nGXsfl_37_idx=1 ;
      private int AV24Supplier ;
      private int nGXsfl_86_idx=1 ;
      private int nGXsfl_146_idx=1 ;
      private int nGXsfl_190_idx=1 ;
      private int nGXsfl_240_idx=1 ;
      private int AV55PurchaseOrderId ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int AV69GXV1 ;
      private int divTableregister_Visible ;
      private int edtavTotalpaid_Enabled ;
      private int AV74GXV6 ;
      private int divTableedit_Visible ;
      private int AV83GXV15 ;
      private int divTable2_Visible ;
      private int AV89GXV21 ;
      private int divTcancel_Visible ;
      private int AV94GXV26 ;
      private int gxdynajaxindex ;
      private int subGridpurchaseordersfiltered_Islastpage ;
      private int subFgridcancel_Islastpage ;
      private int subFgridposiblenewdetails_Islastpage ;
      private int subFgridedit_Islastpage ;
      private int subGrid1_Islastpage ;
      private int edtavCtlcreateddate_Enabled ;
      private int edtavCtlsuppliername_Enabled ;
      private int edtavCtldetailslink_Enabled ;
      private int edtavCtlsdtvoucherlink_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlcurrentstock_Enabled ;
      private int edtavCtlminiumstock_Enabled ;
      private int edtavCtlquantityordered_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlcurrentstock1_Enabled ;
      private int edtavCtlminiumstock1_Enabled ;
      private int edtavCtlcode3_Enabled ;
      private int edtavCtlname3_Enabled ;
      private int edtavCtlcurrentstock3_Enabled ;
      private int edtavCtlminiumstock3_Enabled ;
      private int edtavCtlcode2_Enabled ;
      private int edtavCtlname2_Enabled ;
      private int edtavCtlcurrentstock2_Enabled ;
      private int edtavCtlminiumstock2_Enabled ;
      private int edtavCtlquantityordered2_Enabled ;
      private int GRIDPURCHASEORDERSFILTERED_nGridOutOfScope ;
      private int subFgridposiblenewdetails_Height ;
      private int nGXsfl_37_fel_idx=1 ;
      private int nGXsfl_86_fel_idx=1 ;
      private int nGXsfl_146_fel_idx=1 ;
      private int nGXsfl_190_fel_idx=1 ;
      private int nGXsfl_240_fel_idx=1 ;
      private int nGXsfl_86_bak_idx=1 ;
      private int nGXsfl_37_bak_idx=1 ;
      private int nGXsfl_146_bak_idx=1 ;
      private int nGXsfl_240_bak_idx=1 ;
      private int nGXsfl_190_bak_idx=1 ;
      private int AV103GXV32 ;
      private int AV104GXV33 ;
      private int AV105GXV34 ;
      private int idxLst ;
      private int subGridpurchaseordersfiltered_Backcolor ;
      private int subGridpurchaseordersfiltered_Allbackcolor ;
      private int edtavEdit_Enabled ;
      private int edtavEdit_Visible ;
      private int edtavCancel_Enabled ;
      private int edtavCancel_Visible ;
      private int edtavRegister_Enabled ;
      private int edtavRegister_Visible ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlquantityreceived_Enabled ;
      private int edtavCtlquantityreceived_Visible ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subFgridedit_Backcolor ;
      private int subFgridedit_Allbackcolor ;
      private int edtavRemovedetail_Enabled ;
      private int edtavRemovedetail_Visible ;
      private int edtavCtlquantityordered1_Enabled ;
      private int edtavCtlquantityordered1_Visible ;
      private int subFgridposiblenewdetails_Backcolor ;
      private int subFgridposiblenewdetails_Allbackcolor ;
      private int edtavSelectthis_Enabled ;
      private int edtavSelectthis_Visible ;
      private int subFgridcancel_Backcolor ;
      private int subFgridcancel_Allbackcolor ;
      private int subGridpurchaseordersfiltered_Titlebackcolor ;
      private int subGridpurchaseordersfiltered_Selectedindex ;
      private int subGridpurchaseordersfiltered_Selectioncolor ;
      private int subGridpurchaseordersfiltered_Hoveringcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subFgridedit_Selectedindex ;
      private int subFgridedit_Selectioncolor ;
      private int subFgridedit_Hoveringcolor ;
      private int subFgridposiblenewdetails_Selectedindex ;
      private int subFgridposiblenewdetails_Selectioncolor ;
      private int subFgridposiblenewdetails_Hoveringcolor ;
      private int subFgridcancel_Selectedindex ;
      private int subFgridcancel_Selectioncolor ;
      private int subFgridcancel_Hoveringcolor ;
      private long GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage ;
      private long GRIDPURCHASEORDERSFILTERED_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long FGRIDEDIT_nCurrentRecord ;
      private long FGRIDPOSIBLENEWDETAILS_nCurrentRecord ;
      private long FGRIDCANCEL_nCurrentRecord ;
      private long GRIDPURCHASEORDERSFILTERED_nRecordCount ;
      private long FGRIDCANCEL_nFirstRecordOnPage ;
      private long FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage ;
      private long FGRIDEDIT_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal AV37TotalPaid ;
      private decimal GXt_decimal4 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string sGXsfl_86_idx="0001" ;
      private string sGXsfl_146_idx="0001" ;
      private string sGXsfl_190_idx="0001" ;
      private string sGXsfl_240_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable1_Internalname ;
      private string dynavSupplier_Internalname ;
      private string TempTags ;
      private string dynavSupplier_Jsonclick ;
      private string edtavFromdate_Internalname ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
      private string cmbavOrderby_Internalname ;
      private string cmbavOrderby_Jsonclick ;
      private string chkavDescending_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGridpurchaseordersfiltered_Internalname ;
      private string divTableregister_Internalname ;
      private string divTablebuttonsregister_Internalname ;
      private string edtavTotalpaid_Internalname ;
      private string edtavTotalpaid_Jsonclick ;
      private string bttRegisterorder_Internalname ;
      private string bttRegisterorder_Jsonclick ;
      private string bttCancelregister_Internalname ;
      private string bttCancelregister_Jsonclick ;
      private string divTablecontentregister_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string subGrid1_Internalname ;
      private string divTableedit_Internalname ;
      private string divTablebuttonsedit_Internalname ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel1_Internalname ;
      private string bttCancel1_Jsonclick ;
      private string divTablecontentedit_Internalname ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string subFgridedit_Internalname ;
      private string bttAdddetail_Internalname ;
      private string bttAdddetail_Jsonclick ;
      private string divTable2_Internalname ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string subFgridposiblenewdetails_Internalname ;
      private string divTcancel_Internalname ;
      private string divTablebuttonscancel_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string bttYes_Internalname ;
      private string bttYes_Jsonclick ;
      private string bttNo_Internalname ;
      private string bttNo_Jsonclick ;
      private string divTablecontentcancel_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string subFgridcancel_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavRemovedetail_Internalname ;
      private string edtavSelectthis_Internalname ;
      private string edtavEdit_Internalname ;
      private string edtavCancel_Internalname ;
      private string edtavRegister_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlcreateddate_Internalname ;
      private string edtavCtlsuppliername_Internalname ;
      private string edtavCtldetailslink_Internalname ;
      private string edtavCtlsdtvoucherlink_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlcurrentstock_Internalname ;
      private string edtavCtlminiumstock_Internalname ;
      private string edtavCtlquantityordered_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlcode1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlcurrentstock1_Internalname ;
      private string edtavCtlminiumstock1_Internalname ;
      private string edtavCtlcode3_Internalname ;
      private string edtavCtlname3_Internalname ;
      private string edtavCtlcurrentstock3_Internalname ;
      private string edtavCtlminiumstock3_Internalname ;
      private string edtavCtlcode2_Internalname ;
      private string edtavCtlname2_Internalname ;
      private string edtavCtlcurrentstock2_Internalname ;
      private string edtavCtlminiumstock2_Internalname ;
      private string edtavCtlquantityordered2_Internalname ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string sGXsfl_86_fel_idx="0001" ;
      private string sGXsfl_146_fel_idx="0001" ;
      private string sGXsfl_190_fel_idx="0001" ;
      private string sGXsfl_240_fel_idx="0001" ;
      private string edtavRegister_gximage ;
      private string edtavEdit_gximage ;
      private string edtavCancel_gximage ;
      private string edtavRemovedetail_gximage ;
      private string edtavSelectthis_gximage ;
      private string subGridpurchaseordersfiltered_Class ;
      private string subGridpurchaseordersfiltered_Linesclass ;
      private string sImgUrl ;
      private string edtavEdit_Jsonclick ;
      private string edtavCancel_Jsonclick ;
      private string edtavRegister_Jsonclick ;
      private string ROClassString ;
      private string edtavCtlcreateddate_Jsonclick ;
      private string edtavCtlsuppliername_Jsonclick ;
      private string edtavCtldetailslink_Jsonclick ;
      private string edtavCtlsdtvoucherlink_Jsonclick ;
      private string edtavCtlquantityreceived_Internalname ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlcurrentstock_Jsonclick ;
      private string edtavCtlminiumstock_Jsonclick ;
      private string edtavCtlquantityordered_Jsonclick ;
      private string edtavCtlquantityreceived_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string edtavCtlquantityordered1_Internalname ;
      private string subFgridedit_Class ;
      private string subFgridedit_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string edtavRemovedetail_Jsonclick ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlcurrentstock1_Jsonclick ;
      private string edtavCtlminiumstock1_Jsonclick ;
      private string edtavCtlquantityordered1_Jsonclick ;
      private string subFgridposiblenewdetails_Class ;
      private string subFgridposiblenewdetails_Linesclass ;
      private string divGrid2table_Internalname ;
      private string edtavSelectthis_Jsonclick ;
      private string edtavCtlcode3_Jsonclick ;
      private string edtavCtlname3_Jsonclick ;
      private string edtavCtlcurrentstock3_Jsonclick ;
      private string edtavCtlminiumstock3_Jsonclick ;
      private string subFgridcancel_Class ;
      private string subFgridcancel_Linesclass ;
      private string divGrid1table2_Internalname ;
      private string edtavCtlcode2_Jsonclick ;
      private string edtavCtlname2_Jsonclick ;
      private string edtavCtlcurrentstock2_Jsonclick ;
      private string edtavCtlminiumstock2_Jsonclick ;
      private string edtavCtlquantityordered2_Jsonclick ;
      private string subGridpurchaseordersfiltered_Header ;
      private string subGrid1_Header ;
      private string subFgridedit_Header ;
      private string subFgridposiblenewdetails_Header ;
      private string subFgridcancel_Header ;
      private DateTime AV26FromDate ;
      private DateTime AV27ToDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV53Descending ;
      private bool AV54AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_146_Refreshing=false ;
      private bool bGXsfl_190_Refreshing=false ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_86_Refreshing=false ;
      private bool bGXsfl_240_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV86 ;
      private bool gx_BV37 ;
      private bool gx_BV146 ;
      private bool gx_BV240 ;
      private bool GXt_boolean1 ;
      private bool gx_BV190 ;
      private bool AV57Edit_IsBlob ;
      private bool AV56Cancel_IsBlob ;
      private bool AV49Register_IsBlob ;
      private bool AV62RemoveDetail_IsBlob ;
      private bool AV66SelectThis_IsBlob ;
      private string AV106Removedetail_GXI ;
      private string AV107Selectthis_GXI ;
      private string AV101Edit_GXI ;
      private string AV102Cancel_GXI ;
      private string AV100Register_GXI ;
      private string AV49Register ;
      private string AV57Edit ;
      private string AV56Cancel ;
      private string AV62RemoveDetail ;
      private string AV66SelectThis ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridpurchaseordersfilteredContainer ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid FgrideditContainer ;
      private GXWebGrid FgridposiblenewdetailsContainer ;
      private GXWebGrid FgridcancelContainer ;
      private GXWebRow GridpurchaseordersfilteredRow ;
      private GXWebRow FgridcancelRow ;
      private GXWebRow FgridposiblenewdetailsRow ;
      private GXWebRow FgrideditRow ;
      private GXWebRow Grid1Row ;
      private GXWebColumn GridpurchaseordersfilteredColumn ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn FgrideditColumn ;
      private GXWebColumn FgridposiblenewdetailsColumn ;
      private GXWebColumn FgridcancelColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox cmbavOrderby ;
      private GXCheckbox chkavDescending ;
      private IDataStoreProvider pr_default ;
      private int[] H00222_A4SupplierId ;
      private string[] H00222_A5SupplierName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV61DetailsRegister ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV59DetailsEdit ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV65PosiblesNewDetails ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV60DetailsCancel ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem3 ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV46SDTPurchaseOrderGenerateList ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem2 ;
      private GXWebForm Form ;
      private GXWindow AV48window ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV40OneDetail ;
      private SdtPurchaseOrder AV12Order ;
   }

   public class wpregisterpurchase__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00222;
          prmH00222 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00222", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00222,0, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
