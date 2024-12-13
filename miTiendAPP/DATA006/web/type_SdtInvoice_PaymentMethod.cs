using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Invoice.PaymentMethod" )]
   [XmlType(TypeName =  "Invoice.PaymentMethod" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtInvoice_PaymentMethod : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtInvoice_PaymentMethod( )
      {
      }

      public SdtInvoice_PaymentMethod( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InvoicePaymentMethodId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PaymentMethod");
         metadata.Set("BT", "InvoicePaymentMethod");
         metadata.Set("PK", "[ \"InvoicePaymentMethodId\" ]");
         metadata.Set("PKAssigned", "[ \"InvoicePaymentMethodId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"InvoiceId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PaymentMethodId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Invoicepaymentmethodid_Z");
         state.Add("gxTpr_Paymentmethodid_Z");
         state.Add("gxTpr_Paymentmethoddescription_Z");
         state.Add("gxTpr_Paymentmethoddiscount_Z");
         state.Add("gxTpr_Paymentmethodrecarge_Z");
         state.Add("gxTpr_Invoicepaymentmethodimport_Z");
         state.Add("gxTpr_Invoicepaymentmethodrechargeimport_Z");
         state.Add("gxTpr_Invoicepaymentmethoddiscountimport_Z");
         state.Add("gxTpr_Paymentmethodid_N");
         state.Add("gxTpr_Invoicepaymentmethodimport_N");
         state.Add("gxTpr_Invoicepaymentmethodrechargeimport_N");
         state.Add("gxTpr_Invoicepaymentmethoddiscountimport_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvoice_PaymentMethod sdt;
         sdt = (SdtInvoice_PaymentMethod)(source);
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodid ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport ;
         gxTv_SdtInvoice_PaymentMethod_Mode = sdt.gxTv_SdtInvoice_PaymentMethod_Mode ;
         gxTv_SdtInvoice_PaymentMethod_Modified = sdt.gxTv_SdtInvoice_PaymentMethod_Modified ;
         gxTv_SdtInvoice_PaymentMethod_Initialized = sdt.gxTv_SdtInvoice_PaymentMethod_Initialized ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z ;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N ;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("InvoicePaymentMethodId", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodId", gxTv_SdtInvoice_PaymentMethod_Paymentmethodid, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodId_N", gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodDescription", gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodDiscount", gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodRecarge", gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge, false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodImport", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N, false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodRechargeImport", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodRechargeImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N, false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodDiscountImport", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InvoicePaymentMethodDiscountImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvoice_PaymentMethod_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtInvoice_PaymentMethod_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvoice_PaymentMethod_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodId_Z", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodId_Z", gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodDescription_Z", gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodDiscount_Z", gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodRecarge_Z", gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z, false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodImport_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodRechargeImport_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodDiscountImport_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PaymentMethodId_N", gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N, false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N, false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodRechargeImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N, false, includeNonInitialized);
            AddObjectProperty("InvoicePaymentMethodDiscountImport_N", gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvoice_PaymentMethod sdt )
      {
         if ( sdt.IsDirty("InvoicePaymentMethodId") )
         {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid ;
         }
         if ( sdt.IsDirty("PaymentMethodId") )
         {
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = (short)(sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N);
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodid ;
         }
         if ( sdt.IsDirty("PaymentMethodDescription") )
         {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription ;
         }
         if ( sdt.IsDirty("PaymentMethodDiscount") )
         {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount ;
         }
         if ( sdt.IsDirty("PaymentMethodRecarge") )
         {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge = sdt.gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge ;
         }
         if ( sdt.IsDirty("InvoicePaymentMethodImport") )
         {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = (short)(sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N);
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport ;
         }
         if ( sdt.IsDirty("InvoicePaymentMethodRechargeImport") )
         {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = (short)(sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N);
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport ;
         }
         if ( sdt.IsDirty("InvoicePaymentMethodDiscountImport") )
         {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = (short)(sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N);
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport = sdt.gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodId" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodId"   )]
      public int gxTpr_Invoicepaymentmethodid
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodid");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodId" )]
      [  XmlElement( ElementName = "PaymentMethodId"   )]
      public int gxTpr_Paymentmethodid
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethodid ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = 0;
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethodid");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = 1;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid = 0;
         SetDirty("Paymentmethodid");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_IsNull( )
      {
         return (gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N==1) ;
      }

      [  SoapElement( ElementName = "PaymentMethodDescription" )]
      [  XmlElement( ElementName = "PaymentMethodDescription"   )]
      public string gxTpr_Paymentmethoddescription
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethoddescription");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodDiscount" )]
      [  XmlElement( ElementName = "PaymentMethodDiscount"   )]
      public decimal gxTpr_Paymentmethoddiscount
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethoddiscount");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodRecarge" )]
      [  XmlElement( ElementName = "PaymentMethodRecarge"   )]
      public decimal gxTpr_Paymentmethodrecarge
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethodrecarge");
         }

      }

      [  SoapElement( ElementName = "InvoicePaymentMethodImport" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodImport"   )]
      public decimal gxTpr_Invoicepaymentmethodimport
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = 0;
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodimport");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = 1;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport = 0;
         SetDirty("Invoicepaymentmethodimport");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_IsNull( )
      {
         return (gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N==1) ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodRechargeImport" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodRechargeImport"   )]
      public decimal gxTpr_Invoicepaymentmethodrechargeimport
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = 0;
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodrechargeimport");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = 1;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport = 0;
         SetDirty("Invoicepaymentmethodrechargeimport");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_IsNull( )
      {
         return (gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N==1) ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodDiscountImport" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodDiscountImport"   )]
      public decimal gxTpr_Invoicepaymentmethoddiscountimport
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = 0;
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethoddiscountimport");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = 1;
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport = 0;
         SetDirty("Invoicepaymentmethoddiscountimport");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_IsNull( )
      {
         return (gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Mode ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Mode_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Modified ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Modified_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Initialized ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Initialized = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Initialized_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodId_Z" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodId_Z"   )]
      public int gxTpr_Invoicepaymentmethodid_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodid_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z = 0;
         SetDirty("Invoicepaymentmethodid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodId_Z" )]
      [  XmlElement( ElementName = "PaymentMethodId_Z"   )]
      public int gxTpr_Paymentmethodid_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethodid_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z = 0;
         SetDirty("Paymentmethodid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodDescription_Z" )]
      [  XmlElement( ElementName = "PaymentMethodDescription_Z"   )]
      public string gxTpr_Paymentmethoddescription_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethoddescription_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z = "";
         SetDirty("Paymentmethoddescription_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodDiscount_Z" )]
      [  XmlElement( ElementName = "PaymentMethodDiscount_Z"   )]
      public decimal gxTpr_Paymentmethoddiscount_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethoddiscount_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z = 0;
         SetDirty("Paymentmethoddiscount_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodRecarge_Z" )]
      [  XmlElement( ElementName = "PaymentMethodRecarge_Z"   )]
      public decimal gxTpr_Paymentmethodrecarge_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethodrecarge_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z = 0;
         SetDirty("Paymentmethodrecarge_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodImport_Z" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodImport_Z"   )]
      public decimal gxTpr_Invoicepaymentmethodimport_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodimport_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z = 0;
         SetDirty("Invoicepaymentmethodimport_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodRechargeImport_Z" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodRechargeImport_Z"   )]
      public decimal gxTpr_Invoicepaymentmethodrechargeimport_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodrechargeimport_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z = 0;
         SetDirty("Invoicepaymentmethodrechargeimport_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodDiscountImport_Z" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodDiscountImport_Z"   )]
      public decimal gxTpr_Invoicepaymentmethoddiscountimport_Z
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethoddiscountimport_Z");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z = 0;
         SetDirty("Invoicepaymentmethoddiscountimport_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodId_N" )]
      [  XmlElement( ElementName = "PaymentMethodId_N"   )]
      public short gxTpr_Paymentmethodid_N
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Paymentmethodid_N");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N = 0;
         SetDirty("Paymentmethodid_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodImport_N" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodImport_N"   )]
      public short gxTpr_Invoicepaymentmethodimport_N
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodimport_N");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N = 0;
         SetDirty("Invoicepaymentmethodimport_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodRechargeImport_N" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodRechargeImport_N"   )]
      public short gxTpr_Invoicepaymentmethodrechargeimport_N
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethodrechargeimport_N");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N = 0;
         SetDirty("Invoicepaymentmethodrechargeimport_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoicePaymentMethodDiscountImport_N" )]
      [  XmlElement( ElementName = "InvoicePaymentMethodDiscountImport_N"   )]
      public short gxTpr_Invoicepaymentmethoddiscountimport_N
      {
         get {
            return gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N ;
         }

         set {
            gxTv_SdtInvoice_PaymentMethod_N = 0;
            gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = value;
            gxTv_SdtInvoice_PaymentMethod_Modified = 1;
            SetDirty("Invoicepaymentmethoddiscountimport_N");
         }

      }

      public void gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N_SetNull( )
      {
         gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N = 0;
         SetDirty("Invoicepaymentmethoddiscountimport_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtInvoice_PaymentMethod_N = 1;
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription = "";
         gxTv_SdtInvoice_PaymentMethod_Mode = "";
         gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtInvoice_PaymentMethod_N ;
      }

      private short gxTv_SdtInvoice_PaymentMethod_N ;
      private short gxTv_SdtInvoice_PaymentMethod_Modified ;
      private short gxTv_SdtInvoice_PaymentMethod_Initialized ;
      private short gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_N ;
      private short gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_N ;
      private short gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_N ;
      private short gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_N ;
      private int gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid ;
      private int gxTv_SdtInvoice_PaymentMethod_Paymentmethodid ;
      private int gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodid_Z ;
      private int gxTv_SdtInvoice_PaymentMethod_Paymentmethodid_Z ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Paymentmethoddiscount_Z ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Paymentmethodrecarge_Z ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodimport_Z ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethodrechargeimport_Z ;
      private decimal gxTv_SdtInvoice_PaymentMethod_Invoicepaymentmethoddiscountimport_Z ;
      private string gxTv_SdtInvoice_PaymentMethod_Mode ;
      private string gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription ;
      private string gxTv_SdtInvoice_PaymentMethod_Paymentmethoddescription_Z ;
   }

   [DataContract(Name = @"Invoice.PaymentMethod", Namespace = "mtaKB")]
   public class SdtInvoice_PaymentMethod_RESTInterface : GxGenericCollectionItem<SdtInvoice_PaymentMethod>
   {
      public SdtInvoice_PaymentMethod_RESTInterface( ) : base()
      {
      }

      public SdtInvoice_PaymentMethod_RESTInterface( SdtInvoice_PaymentMethod psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoicePaymentMethodId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoicepaymentmethodid
      {
         get {
            return sdt.gxTpr_Invoicepaymentmethodid ;
         }

         set {
            sdt.gxTpr_Invoicepaymentmethodid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaymentMethodId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Paymentmethodid
      {
         get {
            return sdt.gxTpr_Paymentmethodid ;
         }

         set {
            sdt.gxTpr_Paymentmethodid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaymentMethodDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Paymentmethoddescription
      {
         get {
            return sdt.gxTpr_Paymentmethoddescription ;
         }

         set {
            sdt.gxTpr_Paymentmethoddescription = value;
         }

      }

      [DataMember( Name = "PaymentMethodDiscount" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Paymentmethoddiscount
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Paymentmethoddiscount, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Paymentmethoddiscount = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PaymentMethodRecarge" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Paymentmethodrecarge
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Paymentmethodrecarge, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Paymentmethodrecarge = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoicePaymentMethodImport" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Invoicepaymentmethodimport
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicepaymentmethodimport, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicepaymentmethodimport = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoicePaymentMethodRechargeImport" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Invoicepaymentmethodrechargeimport
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicepaymentmethodrechargeimport, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicepaymentmethodrechargeimport = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoicePaymentMethodDiscountImport" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Invoicepaymentmethoddiscountimport
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicepaymentmethoddiscountimport, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicepaymentmethoddiscountimport = NumberUtil.Val( value, ".");
         }

      }

      public SdtInvoice_PaymentMethod sdt
      {
         get {
            return (SdtInvoice_PaymentMethod)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtInvoice_PaymentMethod() ;
         }
      }

   }

   [DataContract(Name = @"Invoice.PaymentMethod", Namespace = "mtaKB")]
   public class SdtInvoice_PaymentMethod_RESTLInterface : GxGenericCollectionItem<SdtInvoice_PaymentMethod>
   {
      public SdtInvoice_PaymentMethod_RESTLInterface( ) : base()
      {
      }

      public SdtInvoice_PaymentMethod_RESTLInterface( SdtInvoice_PaymentMethod psdt ) : base(psdt)
      {
      }

      public SdtInvoice_PaymentMethod sdt
      {
         get {
            return (SdtInvoice_PaymentMethod)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtInvoice_PaymentMethod() ;
         }
      }

   }

}
