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
   [XmlRoot(ElementName = "PurchaseOrder.Detail" )]
   [XmlType(TypeName =  "PurchaseOrder.Detail" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtPurchaseOrder_Detail : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPurchaseOrder_Detail( )
      {
      }

      public SdtPurchaseOrder_Detail( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"PurchaseOrderDetailId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Detail");
         metadata.Set("BT", "PurchaseOrderDetail");
         metadata.Set("PK", "[ \"PurchaseOrderDetailId\" ]");
         metadata.Set("PKAssigned", "[ \"PurchaseOrderDetailId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PurchaseOrderId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Purchaseorderdetailid_Z");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Purchaseorderdetailquantityordered_Z");
         state.Add("gxTpr_Purchaseorderdetailquantityreceived_Z");
         state.Add("gxTpr_Purchaseorderdetailsuggestedprice_Z");
         state.Add("gxTpr_Purchaseorderdetailsuggestedprice_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPurchaseOrder_Detail sdt;
         sdt = (SdtPurchaseOrder_Detail)(source);
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid ;
         gxTv_SdtPurchaseOrder_Detail_Productid = sdt.gxTv_SdtPurchaseOrder_Detail_Productid ;
         gxTv_SdtPurchaseOrder_Detail_Productname = sdt.gxTv_SdtPurchaseOrder_Detail_Productname ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice ;
         gxTv_SdtPurchaseOrder_Detail_Mode = sdt.gxTv_SdtPurchaseOrder_Detail_Mode ;
         gxTv_SdtPurchaseOrder_Detail_Modified = sdt.gxTv_SdtPurchaseOrder_Detail_Modified ;
         gxTv_SdtPurchaseOrder_Detail_Initialized = sdt.gxTv_SdtPurchaseOrder_Detail_Initialized ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z ;
         gxTv_SdtPurchaseOrder_Detail_Productid_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Productid_Z ;
         gxTv_SdtPurchaseOrder_Detail_Productname_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Productname_Z ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z ;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N ;
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
         AddObjectProperty("PurchaseOrderDetailId", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid, false, includeNonInitialized);
         AddObjectProperty("ProductId", gxTv_SdtPurchaseOrder_Detail_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtPurchaseOrder_Detail_Productname, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderDetailQuantityOrdered", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderDetailQuantityReceived", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderDetailSuggestedPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderDetailSuggestedPrice_N", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPurchaseOrder_Detail_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPurchaseOrder_Detail_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPurchaseOrder_Detail_Initialized, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailId_Z", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtPurchaseOrder_Detail_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtPurchaseOrder_Detail_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailQuantityOrdered_Z", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailQuantityReceived_Z", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailSuggestedPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailSuggestedPrice_N", gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPurchaseOrder_Detail sdt )
      {
         if ( sdt.IsDirty("PurchaseOrderDetailId") )
         {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid ;
         }
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productid = sdt.gxTv_SdtPurchaseOrder_Detail_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productname = sdt.gxTv_SdtPurchaseOrder_Detail_Productname ;
         }
         if ( sdt.IsDirty("PurchaseOrderDetailQuantityOrdered") )
         {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered ;
         }
         if ( sdt.IsDirty("PurchaseOrderDetailQuantityReceived") )
         {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived ;
         }
         if ( sdt.IsDirty("PurchaseOrderDetailSuggestedPrice") )
         {
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = (short)(sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N);
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice = sdt.gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailId" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailId"   )]
      public int gxTpr_Purchaseorderdetailid
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailid");
         }

      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public int gxTpr_Productid
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Productid ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productid = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Productname ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productname = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderDetailQuantityOrdered" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailQuantityOrdered"   )]
      public int gxTpr_Purchaseorderdetailquantityordered
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailquantityordered");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderDetailQuantityReceived" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailQuantityReceived"   )]
      public int gxTpr_Purchaseorderdetailquantityreceived
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailquantityreceived");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderDetailSuggestedPrice" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailSuggestedPrice"   )]
      public decimal gxTpr_Purchaseorderdetailsuggestedprice
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = 0;
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailsuggestedprice");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = 1;
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice = 0;
         SetDirty("Purchaseorderdetailsuggestedprice");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Mode ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Mode_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Modified ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Modified_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Initialized ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Initialized = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Initialized_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailId_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailId_Z"   )]
      public int gxTpr_Purchaseorderdetailid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z = 0;
         SetDirty("Purchaseorderdetailid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public int gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Productid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productid_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Productid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Productname_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Productname_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Productname_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailQuantityOrdered_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailQuantityOrdered_Z"   )]
      public int gxTpr_Purchaseorderdetailquantityordered_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailquantityordered_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z = 0;
         SetDirty("Purchaseorderdetailquantityordered_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailQuantityReceived_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailQuantityReceived_Z"   )]
      public int gxTpr_Purchaseorderdetailquantityreceived_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailquantityreceived_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z = 0;
         SetDirty("Purchaseorderdetailquantityreceived_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailSuggestedPrice_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailSuggestedPrice_Z"   )]
      public decimal gxTpr_Purchaseorderdetailsuggestedprice_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailsuggestedprice_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z = 0;
         SetDirty("Purchaseorderdetailsuggestedprice_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailSuggestedPrice_N" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailSuggestedPrice_N"   )]
      public short gxTpr_Purchaseorderdetailsuggestedprice_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_Detail_N = 0;
            gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = value;
            gxTv_SdtPurchaseOrder_Detail_Modified = 1;
            SetDirty("Purchaseorderdetailsuggestedprice_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N = 0;
         SetDirty("Purchaseorderdetailsuggestedprice_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPurchaseOrder_Detail_N = 1;
         gxTv_SdtPurchaseOrder_Detail_Productname = "";
         gxTv_SdtPurchaseOrder_Detail_Mode = "";
         gxTv_SdtPurchaseOrder_Detail_Productname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPurchaseOrder_Detail_N ;
      }

      private short gxTv_SdtPurchaseOrder_Detail_N ;
      private short gxTv_SdtPurchaseOrder_Detail_Modified ;
      private short gxTv_SdtPurchaseOrder_Detail_Initialized ;
      private short gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_N ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid ;
      private int gxTv_SdtPurchaseOrder_Detail_Productid ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailid_Z ;
      private int gxTv_SdtPurchaseOrder_Detail_Productid_Z ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityordered_Z ;
      private int gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailquantityreceived_Z ;
      private decimal gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice ;
      private decimal gxTv_SdtPurchaseOrder_Detail_Purchaseorderdetailsuggestedprice_Z ;
      private string gxTv_SdtPurchaseOrder_Detail_Mode ;
      private string gxTv_SdtPurchaseOrder_Detail_Productname ;
      private string gxTv_SdtPurchaseOrder_Detail_Productname_Z ;
   }

   [DataContract(Name = @"PurchaseOrder.Detail", Namespace = "mtaKB")]
   public class SdtPurchaseOrder_Detail_RESTInterface : GxGenericCollectionItem<SdtPurchaseOrder_Detail>
   {
      public SdtPurchaseOrder_Detail_RESTInterface( ) : base()
      {
      }

      public SdtPurchaseOrder_Detail_RESTInterface( SdtPurchaseOrder_Detail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PurchaseOrderDetailId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Purchaseorderdetailid
      {
         get {
            return sdt.gxTpr_Purchaseorderdetailid ;
         }

         set {
            sdt.gxTpr_Purchaseorderdetailid = (int)(value.HasValue ? value.Value : 0);
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

      [DataMember( Name = "PurchaseOrderDetailQuantityOrdered" , Order = 3 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Purchaseorderdetailquantityordered
      {
         get {
            return sdt.gxTpr_Purchaseorderdetailquantityordered ;
         }

         set {
            sdt.gxTpr_Purchaseorderdetailquantityordered = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PurchaseOrderDetailQuantityReceived" , Order = 4 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Purchaseorderdetailquantityreceived
      {
         get {
            return sdt.gxTpr_Purchaseorderdetailquantityreceived ;
         }

         set {
            sdt.gxTpr_Purchaseorderdetailquantityreceived = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PurchaseOrderDetailSuggestedPrice" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Purchaseorderdetailsuggestedprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Purchaseorderdetailsuggestedprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Purchaseorderdetailsuggestedprice = NumberUtil.Val( value, ".");
         }

      }

      public SdtPurchaseOrder_Detail sdt
      {
         get {
            return (SdtPurchaseOrder_Detail)Sdt ;
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
            sdt = new SdtPurchaseOrder_Detail() ;
         }
      }

   }

   [DataContract(Name = @"PurchaseOrder.Detail", Namespace = "mtaKB")]
   public class SdtPurchaseOrder_Detail_RESTLInterface : GxGenericCollectionItem<SdtPurchaseOrder_Detail>
   {
      public SdtPurchaseOrder_Detail_RESTLInterface( ) : base()
      {
      }

      public SdtPurchaseOrder_Detail_RESTLInterface( SdtPurchaseOrder_Detail psdt ) : base(psdt)
      {
      }

      public SdtPurchaseOrder_Detail sdt
      {
         get {
            return (SdtPurchaseOrder_Detail)Sdt ;
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
            sdt = new SdtPurchaseOrder_Detail() ;
         }
      }

   }

}
