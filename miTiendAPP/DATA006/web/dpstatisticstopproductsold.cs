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
   public class dpstatisticstopproductsold : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("mtaKB", true);
         initialize();
         Gxm2rootcol = new GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem>( context, "SDTInvoiceStatisticsTopItem", "mtaKB") ;
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
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold");
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
               GXSoapXMLWriter.WriteAttribute("name", "SDTInvoiceStatisticsTop");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "SDTInvoiceStatisticsTopItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTInvoiceStatisticsTop.SDTInvoiceStatisticsTopItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "SDTInvoiceStatisticsTop.SDTInvoiceStatisticsTopItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ProductId");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ProductName");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Count");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Total");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "QtySold");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "TotalRaised");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "TotalDetail");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:double");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "ReturnValue");
               GXSoapXMLWriter.WriteAttribute("type", "tns:SDTInvoiceStatisticsTop");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:DPStatisticsTopProductSold.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:DPStatisticsTopProductSold.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSoldSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"DPStatisticsTopProductSold.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"DPStatisticsTopProductSold.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSoldSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"DPStatisticsTopProductSoldSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "mtaKBaction/"+"ADPSTATISTICSTOPPRODUCTSOLD.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSold");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "DPStatisticsTopProductSoldSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"DPStatisticsTopProductSoldSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", ((context.GetHttpSecure( )==1) ? "https://" : "http://")+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"dpstatisticstopproductsold.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + ((context.GetHttpSecure( )==1) ? "https://" : "http://") + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "dpstatisticstopproductsold.aspx" + "?wsdl to get the WSDL.";
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
                        Gxm2rootcol = new GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem>( context, "SDTInvoiceStatisticsTopItem", "mtaKB");
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
            GXSoapXMLWriter.WriteStartElement("DPStatisticsTopProductSold.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "mtaKB");
            if ( currSoapErr == 0 )
            {
               if ( Gxm2rootcol != null )
               {
                  Gxm2rootcol.writexmlcollection(GXSoapXMLWriter, "ReturnValue", "mtaKB", "SDTInvoiceStatisticsTopItem", "mtaKB");
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

      public dpstatisticstopproductsold( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpstatisticstopproductsold( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Year ,
                           short aP1_Month ,
                           out GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem> aP2_Gxm2rootcol )
      {
         this.AV5Year = aP0_Year;
         this.AV6Month = aP1_Month;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem>( context, "SDTInvoiceStatisticsTopItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem> executeUdp( short aP0_Year ,
                                                                                                  short aP1_Month )
      {
         execute(aP0_Year, aP1_Month, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( short aP0_Year ,
                                 short aP1_Month ,
                                 out GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem> aP2_Gxm2rootcol )
      {
         dpstatisticstopproductsold objdpstatisticstopproductsold;
         objdpstatisticstopproductsold = new dpstatisticstopproductsold();
         objdpstatisticstopproductsold.AV5Year = aP0_Year;
         objdpstatisticstopproductsold.AV6Month = aP1_Month;
         objdpstatisticstopproductsold.Gxm2rootcol = new GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem>( context, "SDTInvoiceStatisticsTopItem", "mtaKB") ;
         objdpstatisticstopproductsold.context.SetSubmitInitialConfig(context);
         objdpstatisticstopproductsold.initialize();
         Submit( executePrivateCatch,objdpstatisticstopproductsold);
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpstatisticstopproductsold)stateInfo).executePrivate();
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
         /* Using cursor P000B4 */
         pr_default.execute(0, new Object[] {AV5Year, AV6Month});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20InvoiceId = P000B4_A20InvoiceId[0];
            A94InvoiceActive = P000B4_A94InvoiceActive[0];
            A38InvoiceCreatedDate = P000B4_A38InvoiceCreatedDate[0];
            A15ProductId = P000B4_A15ProductId[0];
            n15ProductId = P000B4_n15ProductId[0];
            A16ProductName = P000B4_A16ProductName[0];
            A40000GXC1 = P000B4_A40000GXC1[0];
            n40000GXC1 = P000B4_n40000GXC1[0];
            A40001GXC2 = P000B4_A40001GXC2[0];
            n40001GXC2 = P000B4_n40001GXC2[0];
            A40002GXC3 = P000B4_A40002GXC3[0];
            n40002GXC3 = P000B4_n40002GXC3[0];
            A94InvoiceActive = P000B4_A94InvoiceActive[0];
            A38InvoiceCreatedDate = P000B4_A38InvoiceCreatedDate[0];
            A40001GXC2 = P000B4_A40001GXC2[0];
            n40001GXC2 = P000B4_n40001GXC2[0];
            A16ProductName = P000B4_A16ProductName[0];
            A40000GXC1 = P000B4_A40000GXC1[0];
            n40000GXC1 = P000B4_n40000GXC1[0];
            A40002GXC3 = P000B4_A40002GXC3[0];
            n40002GXC3 = P000B4_n40002GXC3[0];
            Gxm1sdtinvoicestatisticstop = new SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem(context);
            Gxm2rootcol.Add(Gxm1sdtinvoicestatisticstop, 0);
            Gxm1sdtinvoicestatisticstop.gxTpr_Productid = A15ProductId;
            Gxm1sdtinvoicestatisticstop.gxTpr_Productname = A16ProductName;
            Gxm1sdtinvoicestatisticstop.gxTpr_Qtysold = (short)(A40000GXC1);
            Gxm1sdtinvoicestatisticstop.gxTpr_Totalraised = A40001GXC2;
            Gxm1sdtinvoicestatisticstop.gxTpr_Totaldetail = A40002GXC3;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P000B4_A20InvoiceId = new int[1] ;
         P000B4_A94InvoiceActive = new bool[] {false} ;
         P000B4_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000B4_A15ProductId = new int[1] ;
         P000B4_n15ProductId = new bool[] {false} ;
         P000B4_A16ProductName = new string[] {""} ;
         P000B4_A40000GXC1 = new int[1] ;
         P000B4_n40000GXC1 = new bool[] {false} ;
         P000B4_A40001GXC2 = new decimal[1] ;
         P000B4_n40001GXC2 = new bool[] {false} ;
         P000B4_A40002GXC3 = new decimal[1] ;
         P000B4_n40002GXC3 = new bool[] {false} ;
         A16ProductName = "";
         Gxm1sdtinvoicestatisticstop = new SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpstatisticstopproductsold__default(),
            new Object[][] {
                new Object[] {
               P000B4_A20InvoiceId, P000B4_A94InvoiceActive, P000B4_A38InvoiceCreatedDate, P000B4_A15ProductId, P000B4_n15ProductId, P000B4_A16ProductName, P000B4_A40000GXC1, P000B4_n40000GXC1, P000B4_A40001GXC2, P000B4_n40001GXC2,
               P000B4_A40002GXC3, P000B4_n40002GXC3
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
      private int A15ProductId ;
      private int A40000GXC1 ;
      private decimal A40001GXC2 ;
      private decimal A40002GXC3 ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool A94InvoiceActive ;
      private bool n15ProductId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private string A16ProductName ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000B4_A20InvoiceId ;
      private bool[] P000B4_A94InvoiceActive ;
      private DateTime[] P000B4_A38InvoiceCreatedDate ;
      private int[] P000B4_A15ProductId ;
      private bool[] P000B4_n15ProductId ;
      private string[] P000B4_A16ProductName ;
      private int[] P000B4_A40000GXC1 ;
      private bool[] P000B4_n40000GXC1 ;
      private decimal[] P000B4_A40001GXC2 ;
      private bool[] P000B4_n40001GXC2 ;
      private decimal[] P000B4_A40002GXC3 ;
      private bool[] P000B4_n40002GXC3 ;
      private GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem> aP2_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem> Gxm2rootcol ;
      private SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem Gxm1sdtinvoicestatisticstop ;
   }

   public class dpstatisticstopproductsold__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000B4( IGxContext context ,
                                             short AV5Year ,
                                             short AV6Month ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [InvoiceId], NULL AS [InvoiceActive], NULL AS [InvoiceCreatedDate], [ProductId], [ProductName], [GXC1], [GXC2], [GXC3] FROM ( SELECT TOP(100) PERCENT T1.[InvoiceId], T2.[InvoiceActive], T2.[InvoiceCreatedDate], T1.[ProductId], T4.[ProductName], COALESCE( T5.[GXC1], 0) AS GXC1, COALESCE( T3.[GXC2], 0) AS GXC2, COALESCE( T5.[GXC3], 0) AS GXC3 FROM (((([InvoiceDetail] T1 INNER JOIN [Invoice] T2 ON T2.[InvoiceId] = T1.[InvoiceId]) LEFT JOIN (SELECT SUM(COALESCE( [InvoicePaymentMethodImport], 0) + COALESCE( [InvoicePaymentMethodRechargeIm], 0) - COALESCE( [InvoicePaymentMethodDiscountIm], 0)) AS GXC2, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = T1.[InvoiceId]) INNER JOIN [Product] T4 ON T4.[ProductId] = T1.[ProductId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, T6.[ProductId], T7.[ProductName], SUM(T6.[InvoiceDetailQuantity] * CAST(T6.[InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC3 FROM ([InvoiceDetail] T6 INNER JOIN [Product] T7 ON T7.[ProductId] = T6.[ProductId]) GROUP BY T6.[ProductId], T7.[ProductName] ) T5 ON T5.[ProductId] = T1.[ProductId] AND T5.[ProductName] = T4.[ProductName])";
         AddWhere(sWhereString, "(T2.[InvoiceActive] = 1)");
         if ( ! (0==AV5Year) )
         {
            AddWhere(sWhereString, "(YEAR(T2.[InvoiceCreatedDate]) = @AV5Year)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV6Month) )
         {
            AddWhere(sWhereString, "(MONTH(T2.[InvoiceCreatedDate]) = @AV6Month)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InvoiceId]";
         scmdbuf += ") DistinctT";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000B4(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (bool)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000B4;
          prmP000B4 = new Object[] {
          new ParDef("@AV5Year",GXType.Int16,4,0) ,
          new ParDef("@AV6Month",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000B4,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
