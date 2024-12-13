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
   [XmlRoot(ElementName = "Invoice.Detail" )]
   [XmlType(TypeName =  "Invoice.Detail" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtInvoice_Detail : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtInvoice_Detail( )
      {
      }

      public SdtInvoice_Detail( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"InvoiceDetailId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Detail");
         metadata.Set("BT", "InvoiceDetail");
         metadata.Set("PK", "[ \"InvoiceDetailId\" ]");
         metadata.Set("PKAssigned", "[ \"InvoiceDetailId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"InvoiceId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProductId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Invoicedetailid_Z");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productstock_Z");
         state.Add("gxTpr_Invoicedetailquantity_Z");
         state.Add("gxTpr_Invoicedetailhistoricprice_Z");
         state.Add("gxTpr_Invoicedetailiswholesale_Z");
         state.Add("gxTpr_Productstock_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvoice_Detail sdt;
         sdt = (SdtInvoice_Detail)(source);
         gxTv_SdtInvoice_Detail_Invoicedetailid = sdt.gxTv_SdtInvoice_Detail_Invoicedetailid ;
         gxTv_SdtInvoice_Detail_Productid = sdt.gxTv_SdtInvoice_Detail_Productid ;
         gxTv_SdtInvoice_Detail_Productname = sdt.gxTv_SdtInvoice_Detail_Productname ;
         gxTv_SdtInvoice_Detail_Productstock = sdt.gxTv_SdtInvoice_Detail_Productstock ;
         gxTv_SdtInvoice_Detail_Invoicedetailquantity = sdt.gxTv_SdtInvoice_Detail_Invoicedetailquantity ;
         gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice = sdt.gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice ;
         gxTv_SdtInvoice_Detail_Invoicedetailiswholesale = sdt.gxTv_SdtInvoice_Detail_Invoicedetailiswholesale ;
         gxTv_SdtInvoice_Detail_Mode = sdt.gxTv_SdtInvoice_Detail_Mode ;
         gxTv_SdtInvoice_Detail_Modified = sdt.gxTv_SdtInvoice_Detail_Modified ;
         gxTv_SdtInvoice_Detail_Initialized = sdt.gxTv_SdtInvoice_Detail_Initialized ;
         gxTv_SdtInvoice_Detail_Invoicedetailid_Z = sdt.gxTv_SdtInvoice_Detail_Invoicedetailid_Z ;
         gxTv_SdtInvoice_Detail_Productid_Z = sdt.gxTv_SdtInvoice_Detail_Productid_Z ;
         gxTv_SdtInvoice_Detail_Productname_Z = sdt.gxTv_SdtInvoice_Detail_Productname_Z ;
         gxTv_SdtInvoice_Detail_Productstock_Z = sdt.gxTv_SdtInvoice_Detail_Productstock_Z ;
         gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z = sdt.gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z ;
         gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z = sdt.gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z ;
         gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z = sdt.gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z ;
         gxTv_SdtInvoice_Detail_Productstock_N = sdt.gxTv_SdtInvoice_Detail_Productstock_N ;
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
         AddObjectProperty("InvoiceDetailId", gxTv_SdtInvoice_Detail_Invoicedetailid, false, includeNonInitialized);
         AddObjectProperty("ProductId", gxTv_SdtInvoice_Detail_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtInvoice_Detail_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductStock", gxTv_SdtInvoice_Detail_Productstock, false, includeNonInitialized);
         AddObjectProperty("ProductStock_N", gxTv_SdtInvoice_Detail_Productstock_N, false, includeNonInitialized);
         AddObjectProperty("InvoiceDetailQuantity", gxTv_SdtInvoice_Detail_Invoicedetailquantity, false, includeNonInitialized);
         AddObjectProperty("InvoiceDetailHistoricPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InvoiceDetailIsWholesale", gxTv_SdtInvoice_Detail_Invoicedetailiswholesale, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvoice_Detail_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtInvoice_Detail_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvoice_Detail_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvoiceDetailId_Z", gxTv_SdtInvoice_Detail_Invoicedetailid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtInvoice_Detail_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtInvoice_Detail_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductStock_Z", gxTv_SdtInvoice_Detail_Productstock_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceDetailQuantity_Z", gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceDetailHistoricPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("InvoiceDetailIsWholesale_Z", gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z, false, includeNonInitialized);
            AddObjectProperty("ProductStock_N", gxTv_SdtInvoice_Detail_Productstock_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvoice_Detail sdt )
      {
         if ( sdt.IsDirty("InvoiceDetailId") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailid = sdt.gxTv_SdtInvoice_Detail_Invoicedetailid ;
         }
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productid = sdt.gxTv_SdtInvoice_Detail_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productname = sdt.gxTv_SdtInvoice_Detail_Productname ;
         }
         if ( sdt.IsDirty("ProductStock") )
         {
            gxTv_SdtInvoice_Detail_Productstock_N = (short)(sdt.gxTv_SdtInvoice_Detail_Productstock_N);
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productstock = sdt.gxTv_SdtInvoice_Detail_Productstock ;
         }
         if ( sdt.IsDirty("InvoiceDetailQuantity") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailquantity = sdt.gxTv_SdtInvoice_Detail_Invoicedetailquantity ;
         }
         if ( sdt.IsDirty("InvoiceDetailHistoricPrice") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice = sdt.gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice ;
         }
         if ( sdt.IsDirty("InvoiceDetailIsWholesale") )
         {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailiswholesale = sdt.gxTv_SdtInvoice_Detail_Invoicedetailiswholesale ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvoiceDetailId" )]
      [  XmlElement( ElementName = "InvoiceDetailId"   )]
      public int gxTpr_Invoicedetailid
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailid ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailid = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailid");
         }

      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public int gxTpr_Productid
      {
         get {
            return gxTv_SdtInvoice_Detail_Productid ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productid = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtInvoice_Detail_Productname ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productname = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductStock" )]
      [  XmlElement( ElementName = "ProductStock"   )]
      public int gxTpr_Productstock
      {
         get {
            return gxTv_SdtInvoice_Detail_Productstock ;
         }

         set {
            gxTv_SdtInvoice_Detail_Productstock_N = 0;
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productstock = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productstock");
         }

      }

      public void gxTv_SdtInvoice_Detail_Productstock_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Productstock_N = 1;
         gxTv_SdtInvoice_Detail_Productstock = 0;
         SetDirty("Productstock");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Productstock_IsNull( )
      {
         return (gxTv_SdtInvoice_Detail_Productstock_N==1) ;
      }

      [  SoapElement( ElementName = "InvoiceDetailQuantity" )]
      [  XmlElement( ElementName = "InvoiceDetailQuantity"   )]
      public int gxTpr_Invoicedetailquantity
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailquantity ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailquantity = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailquantity");
         }

      }

      [  SoapElement( ElementName = "InvoiceDetailHistoricPrice" )]
      [  XmlElement( ElementName = "InvoiceDetailHistoricPrice"   )]
      public decimal gxTpr_Invoicedetailhistoricprice
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailhistoricprice");
         }

      }

      [  SoapElement( ElementName = "InvoiceDetailIsWholesale" )]
      [  XmlElement( ElementName = "InvoiceDetailIsWholesale"   )]
      public bool gxTpr_Invoicedetailiswholesale
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailiswholesale ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailiswholesale = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailiswholesale");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInvoice_Detail_Mode ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvoice_Detail_Mode_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtInvoice_Detail_Modified ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtInvoice_Detail_Modified_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvoice_Detail_Initialized ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Initialized = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvoice_Detail_Initialized_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceDetailId_Z" )]
      [  XmlElement( ElementName = "InvoiceDetailId_Z"   )]
      public int gxTpr_Invoicedetailid_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailid_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailid_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailid_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Invoicedetailid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Invoicedetailid_Z = 0;
         SetDirty("Invoicedetailid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Invoicedetailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public int gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Productid_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productid_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Productid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Productname_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productname_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Productname_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_Z" )]
      [  XmlElement( ElementName = "ProductStock_Z"   )]
      public int gxTpr_Productstock_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Productstock_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productstock_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productstock_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Productstock_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Productstock_Z = 0;
         SetDirty("Productstock_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Productstock_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceDetailQuantity_Z" )]
      [  XmlElement( ElementName = "InvoiceDetailQuantity_Z"   )]
      public int gxTpr_Invoicedetailquantity_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailquantity_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z = 0;
         SetDirty("Invoicedetailquantity_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceDetailHistoricPrice_Z" )]
      [  XmlElement( ElementName = "InvoiceDetailHistoricPrice_Z"   )]
      public decimal gxTpr_Invoicedetailhistoricprice_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailhistoricprice_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z = 0;
         SetDirty("Invoicedetailhistoricprice_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceDetailIsWholesale_Z" )]
      [  XmlElement( ElementName = "InvoiceDetailIsWholesale_Z"   )]
      public bool gxTpr_Invoicedetailiswholesale_Z
      {
         get {
            return gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Invoicedetailiswholesale_Z");
         }

      }

      public void gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z = false;
         SetDirty("Invoicedetailiswholesale_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_N" )]
      [  XmlElement( ElementName = "ProductStock_N"   )]
      public short gxTpr_Productstock_N
      {
         get {
            return gxTv_SdtInvoice_Detail_Productstock_N ;
         }

         set {
            gxTv_SdtInvoice_Detail_N = 0;
            gxTv_SdtInvoice_Detail_Productstock_N = value;
            gxTv_SdtInvoice_Detail_Modified = 1;
            SetDirty("Productstock_N");
         }

      }

      public void gxTv_SdtInvoice_Detail_Productstock_N_SetNull( )
      {
         gxTv_SdtInvoice_Detail_Productstock_N = 0;
         SetDirty("Productstock_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_Productstock_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtInvoice_Detail_N = 1;
         gxTv_SdtInvoice_Detail_Productname = "";
         gxTv_SdtInvoice_Detail_Mode = "";
         gxTv_SdtInvoice_Detail_Productname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtInvoice_Detail_N ;
      }

      private short gxTv_SdtInvoice_Detail_N ;
      private short gxTv_SdtInvoice_Detail_Modified ;
      private short gxTv_SdtInvoice_Detail_Initialized ;
      private short gxTv_SdtInvoice_Detail_Productstock_N ;
      private int gxTv_SdtInvoice_Detail_Invoicedetailid ;
      private int gxTv_SdtInvoice_Detail_Productid ;
      private int gxTv_SdtInvoice_Detail_Productstock ;
      private int gxTv_SdtInvoice_Detail_Invoicedetailquantity ;
      private int gxTv_SdtInvoice_Detail_Invoicedetailid_Z ;
      private int gxTv_SdtInvoice_Detail_Productid_Z ;
      private int gxTv_SdtInvoice_Detail_Productstock_Z ;
      private int gxTv_SdtInvoice_Detail_Invoicedetailquantity_Z ;
      private decimal gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice ;
      private decimal gxTv_SdtInvoice_Detail_Invoicedetailhistoricprice_Z ;
      private string gxTv_SdtInvoice_Detail_Mode ;
      private bool gxTv_SdtInvoice_Detail_Invoicedetailiswholesale ;
      private bool gxTv_SdtInvoice_Detail_Invoicedetailiswholesale_Z ;
      private string gxTv_SdtInvoice_Detail_Productname ;
      private string gxTv_SdtInvoice_Detail_Productname_Z ;
   }

   [DataContract(Name = @"Invoice.Detail", Namespace = "mtaKB")]
   public class SdtInvoice_Detail_RESTInterface : GxGenericCollectionItem<SdtInvoice_Detail>
   {
      public SdtInvoice_Detail_RESTInterface( ) : base()
      {
      }

      public SdtInvoice_Detail_RESTInterface( SdtInvoice_Detail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoiceDetailId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoicedetailid
      {
         get {
            return sdt.gxTpr_Invoicedetailid ;
         }

         set {
            sdt.gxTpr_Invoicedetailid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Productid
      {
         get {
            return sdt.gxTpr_Productid ;
         }

         set {
            sdt.gxTpr_Productid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return sdt.gxTpr_Productname ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductStock" , Order = 3 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Productstock
      {
         get {
            return sdt.gxTpr_Productstock ;
         }

         set {
            sdt.gxTpr_Productstock = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceDetailQuantity" , Order = 4 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoicedetailquantity
      {
         get {
            return sdt.gxTpr_Invoicedetailquantity ;
         }

         set {
            sdt.gxTpr_Invoicedetailquantity = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceDetailHistoricPrice" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Invoicedetailhistoricprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicedetailhistoricprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicedetailhistoricprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoiceDetailIsWholesale" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Invoicedetailiswholesale
      {
         get {
            return sdt.gxTpr_Invoicedetailiswholesale ;
         }

         set {
            sdt.gxTpr_Invoicedetailiswholesale = value;
         }

      }

      public SdtInvoice_Detail sdt
      {
         get {
            return (SdtInvoice_Detail)Sdt ;
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
            sdt = new SdtInvoice_Detail() ;
         }
      }

   }

   [DataContract(Name = @"Invoice.Detail", Namespace = "mtaKB")]
   public class SdtInvoice_Detail_RESTLInterface : GxGenericCollectionItem<SdtInvoice_Detail>
   {
      public SdtInvoice_Detail_RESTLInterface( ) : base()
      {
      }

      public SdtInvoice_Detail_RESTLInterface( SdtInvoice_Detail psdt ) : base(psdt)
      {
      }

      public SdtInvoice_Detail sdt
      {
         get {
            return (SdtInvoice_Detail)Sdt ;
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
            sdt = new SdtInvoice_Detail() ;
         }
      }

   }

}
