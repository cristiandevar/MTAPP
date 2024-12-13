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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class dpstatisticsamountstatement : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("mtaKB", true);
         initialize();
         Gxm2rootcol = new GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem>( context, "SDTStatisticsAccountStatementItem", "mtaKB") ;
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "mtaKB");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "mtaKB");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "mtaKB");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "mtaKB");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTStatisticsAccountStatement");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTStatisticsAccountStatementItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTStatisticsAccountStatement.SDTStatisticsAccountStatementItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTStatisticsAccountStatement.SDTStatisticsAccountStatementItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Date");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:date");
               GXSoapXMLWriter.WriteAttribute("nillable", "true");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ImportRaised");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ImportPurchased");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Year");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Month");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "ReturnValue");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTStatisticsAccountStatement");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:DPStatisticsAmountStatement.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:DPStatisticsAmountStatement.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatementSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"DPStatisticsAmountStatement.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"DPStatisticsAmountStatement.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatementSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"DPStatisticsAmountStatementSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "mtaKBaction/"+"ADPSTATISTICSAMOUNTSTATEMENT.Execute");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatement");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsAmountStatementSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"DPStatisticsAmountStatementSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", ((context.GetHttpSecure( )==1) ? "https://" : "http://")+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"dpstatisticsamountstatement.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + ((context.GetHttpSecure( )==1) ? "https://" : "http://") + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "dpstatisticsamountstatement.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        Gxm2rootcol = new GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem>( context, "SDTStatisticsAccountStatementItem", "mtaKB");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Year") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "mtaKB") == 0 ) )
                              {
                                 AV5Year = (short)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Month") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "mtaKB") == 0 ) )
                              {
                                 AV6Month = (short)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "Execute";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            executePrivate();
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("DPStatisticsAmountStatement.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "mtaKB");
            if ( currSoapErr == 0 )
            {
               if ( Gxm2rootcol != null )
               {
                  Gxm2rootcol.writexmlcollection(GXSoapXMLWriter, "ReturnValue", "mtaKB", "SDTStatisticsAccountStatementItem", "mtaKB");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         cleanup();
      }

      public dpstatisticsamountstatement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpstatisticsamountstatement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Year ,
                           short aP1_Month ,
                           out GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem> aP2_Gxm2rootcol )
      {
         this.AV5Year = aP0_Year;
         this.AV6Month = aP1_Month;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem>( context, "SDTStatisticsAccountStatementItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem> executeUdp( short aP0_Year ,
                                                                                                              short aP1_Month )
      {
         execute(aP0_Year, aP1_Month, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( short aP0_Year ,
                                 short aP1_Month ,
                                 out GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem> aP2_Gxm2rootcol )
      {
         dpstatisticsamountstatement objdpstatisticsamountstatement;
         objdpstatisticsamountstatement = new dpstatisticsamountstatement();
         objdpstatisticsamountstatement.AV5Year = aP0_Year;
         objdpstatisticsamountstatement.AV6Month = aP1_Month;
         objdpstatisticsamountstatement.Gxm2rootcol = new GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem>( context, "SDTStatisticsAccountStatementItem", "mtaKB") ;
         objdpstatisticsamountstatement.context.SetSubmitInitialConfig(context);
         objdpstatisticsamountstatement.initialize();
         Submit( executePrivateCatch,objdpstatisticsamountstatement);
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpstatisticsamountstatement)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV5Year ,
                                              AV6Month ,
                                              A38InvoiceCreatedDate ,
                                              A94InvoiceActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P000D3 */
         pr_default.execute(0, new Object[] {AV5Year, AV6Month});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20InvoiceId = P000D3_A20InvoiceId[0];
            A38InvoiceCreatedDate = P000D3_A38InvoiceCreatedDate[0];
            A94InvoiceActive = P000D3_A94InvoiceActive[0];
            A40000GXC1 = P000D3_A40000GXC1[0];
            n40000GXC1 = P000D3_n40000GXC1[0];
            A40000GXC1 = P000D3_A40000GXC1[0];
            n40000GXC1 = P000D3_n40000GXC1[0];
            Gxm1sdtstatisticsaccountstatement = new SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem(context);
            Gxm2rootcol.Add(Gxm1sdtstatisticsaccountstatement, 0);
            Gxm1sdtstatisticsaccountstatement.gxTpr_Date = A38InvoiceCreatedDate;
            Gxm1sdtstatisticsaccountstatement.gxTpr_Importraised = A40000GXC1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV5Year ,
                                              AV6Month ,
                                              A66PurchaseOrderClosedDate ,
                                              A79PurchaseOrderActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P000D4 */
         pr_default.execute(1, new Object[] {AV5Year, AV6Month});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A66PurchaseOrderClosedDate = P000D4_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P000D4_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P000D4_A79PurchaseOrderActive[0];
            A78PurchaseOrderTotalPaid = P000D4_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P000D4_n78PurchaseOrderTotalPaid[0];
            A50PurchaseOrderId = P000D4_A50PurchaseOrderId[0];
            Gxm1sdtstatisticsaccountstatement = new SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem(context);
            Gxm2rootcol.Add(Gxm1sdtstatisticsaccountstatement, 0);
            Gxm1sdtstatisticsaccountstatement.gxTpr_Date = A66PurchaseOrderClosedDate;
            Gxm1sdtstatisticsaccountstatement.gxTpr_Importpurchased = A78PurchaseOrderTotalPaid;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         scmdbuf = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         P000D3_A20InvoiceId = new int[1] ;
         P000D3_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000D3_A94InvoiceActive = new bool[] {false} ;
         P000D3_A40000GXC1 = new decimal[1] ;
         P000D3_n40000GXC1 = new bool[] {false} ;
         Gxm1sdtstatisticsaccountstatement = new SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem(context);
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         P000D4_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P000D4_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P000D4_A79PurchaseOrderActive = new bool[] {false} ;
         P000D4_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P000D4_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P000D4_A50PurchaseOrderId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpstatisticsamountstatement__default(),
            new Object[][] {
                new Object[] {
               P000D3_A20InvoiceId, P000D3_A38InvoiceCreatedDate, P000D3_A94InvoiceActive, P000D3_A40000GXC1, P000D3_n40000GXC1
               }
               , new Object[] {
               P000D4_A66PurchaseOrderClosedDate, P000D4_n66PurchaseOrderClosedDate, P000D4_A79PurchaseOrderActive, P000D4_A78PurchaseOrderTotalPaid, P000D4_n78PurchaseOrderTotalPaid, P000D4_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private short AV5Year ;
      private short AV6Month ;
      private int A20InvoiceId ;
      private int A50PurchaseOrderId ;
      private decimal A40000GXC1 ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool A94InvoiceActive ;
      private bool n40000GXC1 ;
      private bool A79PurchaseOrderActive ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000D3_A20InvoiceId ;
      private DateTime[] P000D3_A38InvoiceCreatedDate ;
      private bool[] P000D3_A94InvoiceActive ;
      private decimal[] P000D3_A40000GXC1 ;
      private bool[] P000D3_n40000GXC1 ;
      private DateTime[] P000D4_A66PurchaseOrderClosedDate ;
      private bool[] P000D4_n66PurchaseOrderClosedDate ;
      private bool[] P000D4_A79PurchaseOrderActive ;
      private decimal[] P000D4_A78PurchaseOrderTotalPaid ;
      private bool[] P000D4_n78PurchaseOrderTotalPaid ;
      private int[] P000D4_A50PurchaseOrderId ;
      private GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem> aP2_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem> Gxm2rootcol ;
      private SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem Gxm1sdtstatisticsaccountstatement ;
   }

   public class dpstatisticsamountstatement__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000D3( IGxContext context ,
                                             short AV5Year ,
                                             short AV6Month ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[InvoiceId], T1.[InvoiceCreatedDate], T1.[InvoiceActive], COALESCE( T2.[GXC1], 0) AS GXC1 FROM ([Invoice] T1 LEFT JOIN (SELECT SUM(COALESCE( [InvoicePaymentMethodImport], 0) + COALESCE( [InvoicePaymentMethodRechargeIm], 0) - COALESCE( [InvoicePaymentMethodDiscountIm], 0)) AS GXC1, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T2 ON T2.[InvoiceId] = T1.[InvoiceId])";
         AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         if ( ! (0==AV5Year) )
         {
            AddWhere(sWhereString, "(YEAR(T1.[InvoiceCreatedDate]) = @AV5Year)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV6Month) )
         {
            AddWhere(sWhereString, "(MONTH(T1.[InvoiceCreatedDate]) = @AV6Month)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InvoiceId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P000D4( IGxContext context ,
                                             short AV5Year ,
                                             short AV6Month ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             bool A79PurchaseOrderActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PurchaseOrderClosedDate], [PurchaseOrderActive], [PurchaseOrderTotalPaid], [PurchaseOrderId] FROM [PurchaseOrder]";
         AddWhere(sWhereString, "([PurchaseOrderActive] = 1)");
         AddWhere(sWhereString, "(Not ( ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] IS NULL or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         if ( ! (0==AV5Year) )
         {
            AddWhere(sWhereString, "(YEAR([PurchaseOrderClosedDate]) = @AV5Year)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV6Month) )
         {
            AddWhere(sWhereString, "(MONTH([PurchaseOrderClosedDate]) = @AV6Month)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PurchaseOrderId]";
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
                     return conditional_P000D3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (bool)dynConstraints[3] );
               case 1 :
                     return conditional_P000D4(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (bool)dynConstraints[3] );
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
          Object[] prmP000D3;
          prmP000D3 = new Object[] {
          new ParDef("@AV5Year",GXType.Int16,4,0) ,
          new ParDef("@AV6Month",GXType.Int16,4,0)
          };
          Object[] prmP000D4;
          prmP000D4 = new Object[] {
          new ParDef("@AV5Year",GXType.Int16,4,0) ,
          new ParDef("@AV6Month",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
