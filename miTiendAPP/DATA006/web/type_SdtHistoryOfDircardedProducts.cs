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
   [XmlRoot(ElementName = "HistoryOfDircardedProducts" )]
   [XmlType(TypeName =  "HistoryOfDircardedProducts" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtHistoryOfDircardedProducts : GxSilentTrnSdt
   {
      public SdtHistoryOfDircardedProducts( )
      {
      }

      public SdtHistoryOfDircardedProducts( IGxContext context )
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

      public void Load( int AV81HistoryOfDircardedProductsId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV81HistoryOfDircardedProductsId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"HistoryOfDircardedProductsId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "HistoryOfDircardedProducts");
         metadata.Set("BT", "HistoryOfDircardedProducts");
         metadata.Set("PK", "[ \"HistoryOfDircardedProductsId\" ]");
         metadata.Set("PKAssigned", "[ \"HistoryOfDircardedProductsId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Historyofdircardedproductsid_Z");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productstock_Z");
         state.Add("gxTpr_Historyofdircardedproductsdescription_Z");
         state.Add("gxTpr_Historyofdircardedproductsdate_Z_Nullable");
         state.Add("gxTpr_Historyofdircardedproductsquantity_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtHistoryOfDircardedProducts sdt;
         sdt = (SdtHistoryOfDircardedProducts)(source);
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid ;
         gxTv_SdtHistoryOfDircardedProducts_Productid = sdt.gxTv_SdtHistoryOfDircardedProducts_Productid ;
         gxTv_SdtHistoryOfDircardedProducts_Productname = sdt.gxTv_SdtHistoryOfDircardedProducts_Productname ;
         gxTv_SdtHistoryOfDircardedProducts_Productstock = sdt.gxTv_SdtHistoryOfDircardedProducts_Productstock ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity ;
         gxTv_SdtHistoryOfDircardedProducts_Mode = sdt.gxTv_SdtHistoryOfDircardedProducts_Mode ;
         gxTv_SdtHistoryOfDircardedProducts_Initialized = sdt.gxTv_SdtHistoryOfDircardedProducts_Initialized ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Productid_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Productid_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Productname_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Productname_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Productstock_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Productstock_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z ;
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z ;
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
         AddObjectProperty("HistoryOfDircardedProductsId", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid, false, includeNonInitialized);
         AddObjectProperty("ProductId", gxTv_SdtHistoryOfDircardedProducts_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtHistoryOfDircardedProducts_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductStock", gxTv_SdtHistoryOfDircardedProducts_Productstock, false, includeNonInitialized);
         AddObjectProperty("HistoryOfDircardedProductsDescription", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("HistoryOfDircardedProductsDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("HistoryOfDircardedProductsQuantity", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtHistoryOfDircardedProducts_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtHistoryOfDircardedProducts_Initialized, false, includeNonInitialized);
            AddObjectProperty("HistoryOfDircardedProductsId_Z", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtHistoryOfDircardedProducts_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtHistoryOfDircardedProducts_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductStock_Z", gxTv_SdtHistoryOfDircardedProducts_Productstock_Z, false, includeNonInitialized);
            AddObjectProperty("HistoryOfDircardedProductsDescription_Z", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("HistoryOfDircardedProductsDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("HistoryOfDircardedProductsQuantity_Z", gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtHistoryOfDircardedProducts sdt )
      {
         if ( sdt.IsDirty("HistoryOfDircardedProductsId") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid ;
         }
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productid = sdt.gxTv_SdtHistoryOfDircardedProducts_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productname = sdt.gxTv_SdtHistoryOfDircardedProducts_Productname ;
         }
         if ( sdt.IsDirty("ProductStock") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productstock = sdt.gxTv_SdtHistoryOfDircardedProducts_Productstock ;
         }
         if ( sdt.IsDirty("HistoryOfDircardedProductsDescription") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription ;
         }
         if ( sdt.IsDirty("HistoryOfDircardedProductsDate") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate ;
         }
         if ( sdt.IsDirty("HistoryOfDircardedProductsQuantity") )
         {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity = sdt.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsId" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsId"   )]
      public int gxTpr_Historyofdircardedproductsid
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            if ( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid != value )
            {
               gxTv_SdtHistoryOfDircardedProducts_Mode = "INS";
               this.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Productid_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Productname_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Productstock_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z_SetNull( );
               this.gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z_SetNull( );
            }
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid = value;
            SetDirty("Historyofdircardedproductsid");
         }

      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public int gxTpr_Productid
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productid ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productid = value;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productname ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductStock" )]
      [  XmlElement( ElementName = "ProductStock"   )]
      public int gxTpr_Productstock
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productstock ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productstock = value;
            SetDirty("Productstock");
         }

      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsDescription" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsDescription"   )]
      public string gxTpr_Historyofdircardedproductsdescription
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription = value;
            SetDirty("Historyofdircardedproductsdescription");
         }

      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsDate" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsDate"  , IsNullable=true )]
      public string gxTpr_Historyofdircardedproductsdate_Nullable
      {
         get {
            if ( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate).value ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = DateTime.MinValue;
            else
               gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Historyofdircardedproductsdate
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = value;
            SetDirty("Historyofdircardedproductsdate");
         }

      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsQuantity" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsQuantity"   )]
      public short gxTpr_Historyofdircardedproductsquantity
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity = value;
            SetDirty("Historyofdircardedproductsquantity");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Mode ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Mode_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Initialized ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Initialized_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsId_Z" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsId_Z"   )]
      public int gxTpr_Historyofdircardedproductsid_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z = value;
            SetDirty("Historyofdircardedproductsid_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z = 0;
         SetDirty("Historyofdircardedproductsid_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public int gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productid_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productid_Z = value;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Productid_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productname_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productname_Z = value;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Productname_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_Z" )]
      [  XmlElement( ElementName = "ProductStock_Z"   )]
      public int gxTpr_Productstock_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Productstock_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Productstock_Z = value;
            SetDirty("Productstock_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Productstock_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Productstock_Z = 0;
         SetDirty("Productstock_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Productstock_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsDescription_Z" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsDescription_Z"   )]
      public string gxTpr_Historyofdircardedproductsdescription_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z = value;
            SetDirty("Historyofdircardedproductsdescription_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z = "";
         SetDirty("Historyofdircardedproductsdescription_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsDate_Z" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsDate_Z"  , IsNullable=true )]
      public string gxTpr_Historyofdircardedproductsdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z).value ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = DateTime.MinValue;
            else
               gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Historyofdircardedproductsdate_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = value;
            SetDirty("Historyofdircardedproductsdate_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Historyofdircardedproductsdate_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HistoryOfDircardedProductsQuantity_Z" )]
      [  XmlElement( ElementName = "HistoryOfDircardedProductsQuantity_Z"   )]
      public short gxTpr_Historyofdircardedproductsquantity_Z
      {
         get {
            return gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z ;
         }

         set {
            gxTv_SdtHistoryOfDircardedProducts_N = 0;
            gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z = value;
            SetDirty("Historyofdircardedproductsquantity_Z");
         }

      }

      public void gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z_SetNull( )
      {
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z = 0;
         SetDirty("Historyofdircardedproductsquantity_Z");
         return  ;
      }

      public bool gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtHistoryOfDircardedProducts_N = 1;
         gxTv_SdtHistoryOfDircardedProducts_Productname = "";
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription = "";
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate = DateTime.MinValue;
         gxTv_SdtHistoryOfDircardedProducts_Mode = "";
         gxTv_SdtHistoryOfDircardedProducts_Productname_Z = "";
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z = "";
         gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "historyofdircardedproducts", "GeneXus.Programs.historyofdircardedproducts_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtHistoryOfDircardedProducts_N ;
      }

      private short gxTv_SdtHistoryOfDircardedProducts_N ;
      private short gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity ;
      private short gxTv_SdtHistoryOfDircardedProducts_Initialized ;
      private short gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsquantity_Z ;
      private int gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid ;
      private int gxTv_SdtHistoryOfDircardedProducts_Productid ;
      private int gxTv_SdtHistoryOfDircardedProducts_Productstock ;
      private int gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsid_Z ;
      private int gxTv_SdtHistoryOfDircardedProducts_Productid_Z ;
      private int gxTv_SdtHistoryOfDircardedProducts_Productstock_Z ;
      private string gxTv_SdtHistoryOfDircardedProducts_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate ;
      private DateTime gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdate_Z ;
      private string gxTv_SdtHistoryOfDircardedProducts_Productname ;
      private string gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription ;
      private string gxTv_SdtHistoryOfDircardedProducts_Productname_Z ;
      private string gxTv_SdtHistoryOfDircardedProducts_Historyofdircardedproductsdescription_Z ;
   }

   [DataContract(Name = @"HistoryOfDircardedProducts", Namespace = "mtaKB")]
   public class SdtHistoryOfDircardedProducts_RESTInterface : GxGenericCollectionItem<SdtHistoryOfDircardedProducts>
   {
      public SdtHistoryOfDircardedProducts_RESTInterface( ) : base()
      {
      }

      public SdtHistoryOfDircardedProducts_RESTInterface( SdtHistoryOfDircardedProducts psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "HistoryOfDircardedProductsId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Historyofdircardedproductsid
      {
         get {
            return sdt.gxTpr_Historyofdircardedproductsid ;
         }

         set {
            sdt.gxTpr_Historyofdircardedproductsid = (int)(value.HasValue ? value.Value : 0);
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

      [DataMember( Name = "HistoryOfDircardedProductsDescription" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Historyofdircardedproductsdescription
      {
         get {
            return sdt.gxTpr_Historyofdircardedproductsdescription ;
         }

         set {
            sdt.gxTpr_Historyofdircardedproductsdescription = value;
         }

      }

      [DataMember( Name = "HistoryOfDircardedProductsDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Historyofdircardedproductsdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Historyofdircardedproductsdate) ;
         }

         set {
            sdt.gxTpr_Historyofdircardedproductsdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "HistoryOfDircardedProductsQuantity" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Historyofdircardedproductsquantity
      {
         get {
            return sdt.gxTpr_Historyofdircardedproductsquantity ;
         }

         set {
            sdt.gxTpr_Historyofdircardedproductsquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtHistoryOfDircardedProducts sdt
      {
         get {
            return (SdtHistoryOfDircardedProducts)Sdt ;
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
            sdt = new SdtHistoryOfDircardedProducts() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"HistoryOfDircardedProducts", Namespace = "mtaKB")]
   public class SdtHistoryOfDircardedProducts_RESTLInterface : GxGenericCollectionItem<SdtHistoryOfDircardedProducts>
   {
      public SdtHistoryOfDircardedProducts_RESTLInterface( ) : base()
      {
      }

      public SdtHistoryOfDircardedProducts_RESTLInterface( SdtHistoryOfDircardedProducts psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "HistoryOfDircardedProductsDescription" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Historyofdircardedproductsdescription
      {
         get {
            return sdt.gxTpr_Historyofdircardedproductsdescription ;
         }

         set {
            sdt.gxTpr_Historyofdircardedproductsdescription = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtHistoryOfDircardedProducts sdt
      {
         get {
            return (SdtHistoryOfDircardedProducts)Sdt ;
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
            sdt = new SdtHistoryOfDircardedProducts() ;
         }
      }

   }

}
