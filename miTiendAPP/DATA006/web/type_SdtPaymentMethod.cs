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
   [XmlRoot(ElementName = "PaymentMethod" )]
   [XmlType(TypeName =  "PaymentMethod" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtPaymentMethod : GxSilentTrnSdt
   {
      public SdtPaymentMethod( )
      {
      }

      public SdtPaymentMethod( IGxContext context )
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

      public void Load( int AV115PaymentMethodId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV115PaymentMethodId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaymentMethodId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PaymentMethod");
         metadata.Set("BT", "PaymentMethod");
         metadata.Set("PK", "[ \"PaymentMethodId\" ]");
         metadata.Set("PKAssigned", "[ \"PaymentMethodId\" ]");
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
         state.Add("gxTpr_Paymentmethodid_Z");
         state.Add("gxTpr_Paymentmethoddescription_Z");
         state.Add("gxTpr_Paymentmethodactive_Z");
         state.Add("gxTpr_Paymentmethoddiscount_Z");
         state.Add("gxTpr_Paymentmethodrecarge_Z");
         state.Add("gxTpr_Paymentmethodid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPaymentMethod sdt;
         sdt = (SdtPaymentMethod)(source);
         gxTv_SdtPaymentMethod_Paymentmethodid = sdt.gxTv_SdtPaymentMethod_Paymentmethodid ;
         gxTv_SdtPaymentMethod_Paymentmethoddescription = sdt.gxTv_SdtPaymentMethod_Paymentmethoddescription ;
         gxTv_SdtPaymentMethod_Paymentmethodactive = sdt.gxTv_SdtPaymentMethod_Paymentmethodactive ;
         gxTv_SdtPaymentMethod_Paymentmethoddiscount = sdt.gxTv_SdtPaymentMethod_Paymentmethoddiscount ;
         gxTv_SdtPaymentMethod_Paymentmethodrecarge = sdt.gxTv_SdtPaymentMethod_Paymentmethodrecarge ;
         gxTv_SdtPaymentMethod_Mode = sdt.gxTv_SdtPaymentMethod_Mode ;
         gxTv_SdtPaymentMethod_Initialized = sdt.gxTv_SdtPaymentMethod_Initialized ;
         gxTv_SdtPaymentMethod_Paymentmethodid_Z = sdt.gxTv_SdtPaymentMethod_Paymentmethodid_Z ;
         gxTv_SdtPaymentMethod_Paymentmethoddescription_Z = sdt.gxTv_SdtPaymentMethod_Paymentmethoddescription_Z ;
         gxTv_SdtPaymentMethod_Paymentmethodactive_Z = sdt.gxTv_SdtPaymentMethod_Paymentmethodactive_Z ;
         gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z = sdt.gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z ;
         gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z = sdt.gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z ;
         gxTv_SdtPaymentMethod_Paymentmethodid_N = sdt.gxTv_SdtPaymentMethod_Paymentmethodid_N ;
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
         AddObjectProperty("PaymentMethodId", gxTv_SdtPaymentMethod_Paymentmethodid, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodId_N", gxTv_SdtPaymentMethod_Paymentmethodid_N, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodDescription", gxTv_SdtPaymentMethod_Paymentmethoddescription, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodActive", gxTv_SdtPaymentMethod_Paymentmethodactive, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodDiscount", gxTv_SdtPaymentMethod_Paymentmethoddiscount, false, includeNonInitialized);
         AddObjectProperty("PaymentMethodRecarge", gxTv_SdtPaymentMethod_Paymentmethodrecarge, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPaymentMethod_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPaymentMethod_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodId_Z", gxTv_SdtPaymentMethod_Paymentmethodid_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodDescription_Z", gxTv_SdtPaymentMethod_Paymentmethoddescription_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodActive_Z", gxTv_SdtPaymentMethod_Paymentmethodactive_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodDiscount_Z", gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodRecarge_Z", gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z, false, includeNonInitialized);
            AddObjectProperty("PaymentMethodId_N", gxTv_SdtPaymentMethod_Paymentmethodid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPaymentMethod sdt )
      {
         if ( sdt.IsDirty("PaymentMethodId") )
         {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodid = sdt.gxTv_SdtPaymentMethod_Paymentmethodid ;
         }
         if ( sdt.IsDirty("PaymentMethodDescription") )
         {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddescription = sdt.gxTv_SdtPaymentMethod_Paymentmethoddescription ;
         }
         if ( sdt.IsDirty("PaymentMethodActive") )
         {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodactive = sdt.gxTv_SdtPaymentMethod_Paymentmethodactive ;
         }
         if ( sdt.IsDirty("PaymentMethodDiscount") )
         {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddiscount = sdt.gxTv_SdtPaymentMethod_Paymentmethoddiscount ;
         }
         if ( sdt.IsDirty("PaymentMethodRecarge") )
         {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodrecarge = sdt.gxTv_SdtPaymentMethod_Paymentmethodrecarge ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaymentMethodId" )]
      [  XmlElement( ElementName = "PaymentMethodId"   )]
      public int gxTpr_Paymentmethodid
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodid ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            if ( gxTv_SdtPaymentMethod_Paymentmethodid != value )
            {
               gxTv_SdtPaymentMethod_Mode = "INS";
               this.gxTv_SdtPaymentMethod_Paymentmethodid_Z_SetNull( );
               this.gxTv_SdtPaymentMethod_Paymentmethoddescription_Z_SetNull( );
               this.gxTv_SdtPaymentMethod_Paymentmethodactive_Z_SetNull( );
               this.gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z_SetNull( );
               this.gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z_SetNull( );
            }
            gxTv_SdtPaymentMethod_Paymentmethodid = value;
            SetDirty("Paymentmethodid");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodDescription" )]
      [  XmlElement( ElementName = "PaymentMethodDescription"   )]
      public string gxTpr_Paymentmethoddescription
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethoddescription ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddescription = value;
            SetDirty("Paymentmethoddescription");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodActive" )]
      [  XmlElement( ElementName = "PaymentMethodActive"   )]
      public bool gxTpr_Paymentmethodactive
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodactive ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodactive = value;
            SetDirty("Paymentmethodactive");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodDiscount" )]
      [  XmlElement( ElementName = "PaymentMethodDiscount"   )]
      public decimal gxTpr_Paymentmethoddiscount
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethoddiscount ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddiscount = value;
            SetDirty("Paymentmethoddiscount");
         }

      }

      [  SoapElement( ElementName = "PaymentMethodRecarge" )]
      [  XmlElement( ElementName = "PaymentMethodRecarge"   )]
      public decimal gxTpr_Paymentmethodrecarge
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodrecarge ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodrecarge = value;
            SetDirty("Paymentmethodrecarge");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPaymentMethod_Mode ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPaymentMethod_Mode_SetNull( )
      {
         gxTv_SdtPaymentMethod_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPaymentMethod_Initialized ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPaymentMethod_Initialized_SetNull( )
      {
         gxTv_SdtPaymentMethod_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodId_Z" )]
      [  XmlElement( ElementName = "PaymentMethodId_Z"   )]
      public int gxTpr_Paymentmethodid_Z
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodid_Z ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodid_Z = value;
            SetDirty("Paymentmethodid_Z");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethodid_Z_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethodid_Z = 0;
         SetDirty("Paymentmethodid_Z");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethodid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodDescription_Z" )]
      [  XmlElement( ElementName = "PaymentMethodDescription_Z"   )]
      public string gxTpr_Paymentmethoddescription_Z
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethoddescription_Z ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddescription_Z = value;
            SetDirty("Paymentmethoddescription_Z");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethoddescription_Z_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethoddescription_Z = "";
         SetDirty("Paymentmethoddescription_Z");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethoddescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodActive_Z" )]
      [  XmlElement( ElementName = "PaymentMethodActive_Z"   )]
      public bool gxTpr_Paymentmethodactive_Z
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodactive_Z ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodactive_Z = value;
            SetDirty("Paymentmethodactive_Z");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethodactive_Z_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethodactive_Z = false;
         SetDirty("Paymentmethodactive_Z");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethodactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodDiscount_Z" )]
      [  XmlElement( ElementName = "PaymentMethodDiscount_Z"   )]
      public decimal gxTpr_Paymentmethoddiscount_Z
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z = value;
            SetDirty("Paymentmethoddiscount_Z");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z = 0;
         SetDirty("Paymentmethoddiscount_Z");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodRecarge_Z" )]
      [  XmlElement( ElementName = "PaymentMethodRecarge_Z"   )]
      public decimal gxTpr_Paymentmethodrecarge_Z
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z = value;
            SetDirty("Paymentmethodrecarge_Z");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z = 0;
         SetDirty("Paymentmethodrecarge_Z");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethodId_N" )]
      [  XmlElement( ElementName = "PaymentMethodId_N"   )]
      public short gxTpr_Paymentmethodid_N
      {
         get {
            return gxTv_SdtPaymentMethod_Paymentmethodid_N ;
         }

         set {
            gxTv_SdtPaymentMethod_N = 0;
            gxTv_SdtPaymentMethod_Paymentmethodid_N = value;
            SetDirty("Paymentmethodid_N");
         }

      }

      public void gxTv_SdtPaymentMethod_Paymentmethodid_N_SetNull( )
      {
         gxTv_SdtPaymentMethod_Paymentmethodid_N = 0;
         SetDirty("Paymentmethodid_N");
         return  ;
      }

      public bool gxTv_SdtPaymentMethod_Paymentmethodid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPaymentMethod_N = 1;
         gxTv_SdtPaymentMethod_Paymentmethoddescription = "";
         gxTv_SdtPaymentMethod_Mode = "";
         gxTv_SdtPaymentMethod_Paymentmethoddescription_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "paymentmethod", "GeneXus.Programs.paymentmethod_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPaymentMethod_N ;
      }

      private short gxTv_SdtPaymentMethod_N ;
      private short gxTv_SdtPaymentMethod_Initialized ;
      private short gxTv_SdtPaymentMethod_Paymentmethodid_N ;
      private int gxTv_SdtPaymentMethod_Paymentmethodid ;
      private int gxTv_SdtPaymentMethod_Paymentmethodid_Z ;
      private decimal gxTv_SdtPaymentMethod_Paymentmethoddiscount ;
      private decimal gxTv_SdtPaymentMethod_Paymentmethodrecarge ;
      private decimal gxTv_SdtPaymentMethod_Paymentmethoddiscount_Z ;
      private decimal gxTv_SdtPaymentMethod_Paymentmethodrecarge_Z ;
      private string gxTv_SdtPaymentMethod_Mode ;
      private bool gxTv_SdtPaymentMethod_Paymentmethodactive ;
      private bool gxTv_SdtPaymentMethod_Paymentmethodactive_Z ;
      private string gxTv_SdtPaymentMethod_Paymentmethoddescription ;
      private string gxTv_SdtPaymentMethod_Paymentmethoddescription_Z ;
   }

   [DataContract(Name = @"PaymentMethod", Namespace = "mtaKB")]
   public class SdtPaymentMethod_RESTInterface : GxGenericCollectionItem<SdtPaymentMethod>
   {
      public SdtPaymentMethod_RESTInterface( ) : base()
      {
      }

      public SdtPaymentMethod_RESTInterface( SdtPaymentMethod psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaymentMethodId" , Order = 0 )]
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

      [DataMember( Name = "PaymentMethodDescription" , Order = 1 )]
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

      [DataMember( Name = "PaymentMethodActive" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Paymentmethodactive
      {
         get {
            return sdt.gxTpr_Paymentmethodactive ;
         }

         set {
            sdt.gxTpr_Paymentmethodactive = value;
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

      public SdtPaymentMethod sdt
      {
         get {
            return (SdtPaymentMethod)Sdt ;
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
            sdt = new SdtPaymentMethod() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"PaymentMethod", Namespace = "mtaKB")]
   public class SdtPaymentMethod_RESTLInterface : GxGenericCollectionItem<SdtPaymentMethod>
   {
      public SdtPaymentMethod_RESTLInterface( ) : base()
      {
      }

      public SdtPaymentMethod_RESTLInterface( SdtPaymentMethod psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaymentMethodDescription" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtPaymentMethod sdt
      {
         get {
            return (SdtPaymentMethod)Sdt ;
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
            sdt = new SdtPaymentMethod() ;
         }
      }

   }

}
