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
   [XmlRoot(ElementName = "Movement" )]
   [XmlType(TypeName =  "Movement" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtMovement : GxSilentTrnSdt
   {
      public SdtMovement( )
      {
      }

      public SdtMovement( IGxContext context )
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

      public void Load( int AV123MovementId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV123MovementId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MovementId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Movement");
         metadata.Set("BT", "Movement");
         metadata.Set("PK", "[ \"MovementId\" ]");
         metadata.Set("PKAssigned", "[ \"MovementId\" ]");
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
         state.Add("gxTpr_Movementid_Z");
         state.Add("gxTpr_Movementtype_Z");
         state.Add("gxTpr_Movementcreateddate_Z_Nullable");
         state.Add("gxTpr_Movementkeyaditional_Z");
         state.Add("gxTpr_Movementdescription_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMovement sdt;
         sdt = (SdtMovement)(source);
         gxTv_SdtMovement_Movementid = sdt.gxTv_SdtMovement_Movementid ;
         gxTv_SdtMovement_Movementtype = sdt.gxTv_SdtMovement_Movementtype ;
         gxTv_SdtMovement_Movementcreateddate = sdt.gxTv_SdtMovement_Movementcreateddate ;
         gxTv_SdtMovement_Movementkeyaditional = sdt.gxTv_SdtMovement_Movementkeyaditional ;
         gxTv_SdtMovement_Movementdescription = sdt.gxTv_SdtMovement_Movementdescription ;
         gxTv_SdtMovement_Mode = sdt.gxTv_SdtMovement_Mode ;
         gxTv_SdtMovement_Initialized = sdt.gxTv_SdtMovement_Initialized ;
         gxTv_SdtMovement_Movementid_Z = sdt.gxTv_SdtMovement_Movementid_Z ;
         gxTv_SdtMovement_Movementtype_Z = sdt.gxTv_SdtMovement_Movementtype_Z ;
         gxTv_SdtMovement_Movementcreateddate_Z = sdt.gxTv_SdtMovement_Movementcreateddate_Z ;
         gxTv_SdtMovement_Movementkeyaditional_Z = sdt.gxTv_SdtMovement_Movementkeyaditional_Z ;
         gxTv_SdtMovement_Movementdescription_Z = sdt.gxTv_SdtMovement_Movementdescription_Z ;
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
         AddObjectProperty("MovementId", gxTv_SdtMovement_Movementid, false, includeNonInitialized);
         AddObjectProperty("MovementType", gxTv_SdtMovement_Movementtype, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMovement_Movementcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMovement_Movementcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMovement_Movementcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MovementCreatedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MovementKeyAditional", gxTv_SdtMovement_Movementkeyaditional, false, includeNonInitialized);
         AddObjectProperty("MovementDescription", gxTv_SdtMovement_Movementdescription, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMovement_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMovement_Initialized, false, includeNonInitialized);
            AddObjectProperty("MovementId_Z", gxTv_SdtMovement_Movementid_Z, false, includeNonInitialized);
            AddObjectProperty("MovementType_Z", gxTv_SdtMovement_Movementtype_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMovement_Movementcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMovement_Movementcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMovement_Movementcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MovementCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MovementKeyAditional_Z", gxTv_SdtMovement_Movementkeyaditional_Z, false, includeNonInitialized);
            AddObjectProperty("MovementDescription_Z", gxTv_SdtMovement_Movementdescription_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMovement sdt )
      {
         if ( sdt.IsDirty("MovementId") )
         {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementid = sdt.gxTv_SdtMovement_Movementid ;
         }
         if ( sdt.IsDirty("MovementType") )
         {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementtype = sdt.gxTv_SdtMovement_Movementtype ;
         }
         if ( sdt.IsDirty("MovementCreatedDate") )
         {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementcreateddate = sdt.gxTv_SdtMovement_Movementcreateddate ;
         }
         if ( sdt.IsDirty("MovementKeyAditional") )
         {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementkeyaditional = sdt.gxTv_SdtMovement_Movementkeyaditional ;
         }
         if ( sdt.IsDirty("MovementDescription") )
         {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementdescription = sdt.gxTv_SdtMovement_Movementdescription ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MovementId" )]
      [  XmlElement( ElementName = "MovementId"   )]
      public int gxTpr_Movementid
      {
         get {
            return gxTv_SdtMovement_Movementid ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            if ( gxTv_SdtMovement_Movementid != value )
            {
               gxTv_SdtMovement_Mode = "INS";
               this.gxTv_SdtMovement_Movementid_Z_SetNull( );
               this.gxTv_SdtMovement_Movementtype_Z_SetNull( );
               this.gxTv_SdtMovement_Movementcreateddate_Z_SetNull( );
               this.gxTv_SdtMovement_Movementkeyaditional_Z_SetNull( );
               this.gxTv_SdtMovement_Movementdescription_Z_SetNull( );
            }
            gxTv_SdtMovement_Movementid = value;
            SetDirty("Movementid");
         }

      }

      [  SoapElement( ElementName = "MovementType" )]
      [  XmlElement( ElementName = "MovementType"   )]
      public short gxTpr_Movementtype
      {
         get {
            return gxTv_SdtMovement_Movementtype ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementtype = value;
            SetDirty("Movementtype");
         }

      }

      [  SoapElement( ElementName = "MovementCreatedDate" )]
      [  XmlElement( ElementName = "MovementCreatedDate"  , IsNullable=true )]
      public string gxTpr_Movementcreateddate_Nullable
      {
         get {
            if ( gxTv_SdtMovement_Movementcreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMovement_Movementcreateddate).value ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMovement_Movementcreateddate = DateTime.MinValue;
            else
               gxTv_SdtMovement_Movementcreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Movementcreateddate
      {
         get {
            return gxTv_SdtMovement_Movementcreateddate ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementcreateddate = value;
            SetDirty("Movementcreateddate");
         }

      }

      [  SoapElement( ElementName = "MovementKeyAditional" )]
      [  XmlElement( ElementName = "MovementKeyAditional"   )]
      public int gxTpr_Movementkeyaditional
      {
         get {
            return gxTv_SdtMovement_Movementkeyaditional ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementkeyaditional = value;
            SetDirty("Movementkeyaditional");
         }

      }

      [  SoapElement( ElementName = "MovementDescription" )]
      [  XmlElement( ElementName = "MovementDescription"   )]
      public string gxTpr_Movementdescription
      {
         get {
            return gxTv_SdtMovement_Movementdescription ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementdescription = value;
            SetDirty("Movementdescription");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMovement_Mode ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMovement_Mode_SetNull( )
      {
         gxTv_SdtMovement_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMovement_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMovement_Initialized ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMovement_Initialized_SetNull( )
      {
         gxTv_SdtMovement_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMovement_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MovementId_Z" )]
      [  XmlElement( ElementName = "MovementId_Z"   )]
      public int gxTpr_Movementid_Z
      {
         get {
            return gxTv_SdtMovement_Movementid_Z ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementid_Z = value;
            SetDirty("Movementid_Z");
         }

      }

      public void gxTv_SdtMovement_Movementid_Z_SetNull( )
      {
         gxTv_SdtMovement_Movementid_Z = 0;
         SetDirty("Movementid_Z");
         return  ;
      }

      public bool gxTv_SdtMovement_Movementid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MovementType_Z" )]
      [  XmlElement( ElementName = "MovementType_Z"   )]
      public short gxTpr_Movementtype_Z
      {
         get {
            return gxTv_SdtMovement_Movementtype_Z ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementtype_Z = value;
            SetDirty("Movementtype_Z");
         }

      }

      public void gxTv_SdtMovement_Movementtype_Z_SetNull( )
      {
         gxTv_SdtMovement_Movementtype_Z = 0;
         SetDirty("Movementtype_Z");
         return  ;
      }

      public bool gxTv_SdtMovement_Movementtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MovementCreatedDate_Z" )]
      [  XmlElement( ElementName = "MovementCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Movementcreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtMovement_Movementcreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMovement_Movementcreateddate_Z).value ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMovement_Movementcreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtMovement_Movementcreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Movementcreateddate_Z
      {
         get {
            return gxTv_SdtMovement_Movementcreateddate_Z ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementcreateddate_Z = value;
            SetDirty("Movementcreateddate_Z");
         }

      }

      public void gxTv_SdtMovement_Movementcreateddate_Z_SetNull( )
      {
         gxTv_SdtMovement_Movementcreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Movementcreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtMovement_Movementcreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MovementKeyAditional_Z" )]
      [  XmlElement( ElementName = "MovementKeyAditional_Z"   )]
      public int gxTpr_Movementkeyaditional_Z
      {
         get {
            return gxTv_SdtMovement_Movementkeyaditional_Z ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementkeyaditional_Z = value;
            SetDirty("Movementkeyaditional_Z");
         }

      }

      public void gxTv_SdtMovement_Movementkeyaditional_Z_SetNull( )
      {
         gxTv_SdtMovement_Movementkeyaditional_Z = 0;
         SetDirty("Movementkeyaditional_Z");
         return  ;
      }

      public bool gxTv_SdtMovement_Movementkeyaditional_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MovementDescription_Z" )]
      [  XmlElement( ElementName = "MovementDescription_Z"   )]
      public string gxTpr_Movementdescription_Z
      {
         get {
            return gxTv_SdtMovement_Movementdescription_Z ;
         }

         set {
            gxTv_SdtMovement_N = 0;
            gxTv_SdtMovement_Movementdescription_Z = value;
            SetDirty("Movementdescription_Z");
         }

      }

      public void gxTv_SdtMovement_Movementdescription_Z_SetNull( )
      {
         gxTv_SdtMovement_Movementdescription_Z = "";
         SetDirty("Movementdescription_Z");
         return  ;
      }

      public bool gxTv_SdtMovement_Movementdescription_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtMovement_N = 1;
         gxTv_SdtMovement_Movementcreateddate = DateTime.MinValue;
         gxTv_SdtMovement_Movementdescription = "";
         gxTv_SdtMovement_Mode = "";
         gxTv_SdtMovement_Movementcreateddate_Z = DateTime.MinValue;
         gxTv_SdtMovement_Movementdescription_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "movement", "GeneXus.Programs.movement_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtMovement_N ;
      }

      private short gxTv_SdtMovement_N ;
      private short gxTv_SdtMovement_Movementtype ;
      private short gxTv_SdtMovement_Initialized ;
      private short gxTv_SdtMovement_Movementtype_Z ;
      private int gxTv_SdtMovement_Movementid ;
      private int gxTv_SdtMovement_Movementkeyaditional ;
      private int gxTv_SdtMovement_Movementid_Z ;
      private int gxTv_SdtMovement_Movementkeyaditional_Z ;
      private string gxTv_SdtMovement_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtMovement_Movementcreateddate ;
      private DateTime gxTv_SdtMovement_Movementcreateddate_Z ;
      private string gxTv_SdtMovement_Movementdescription ;
      private string gxTv_SdtMovement_Movementdescription_Z ;
   }

   [DataContract(Name = @"Movement", Namespace = "mtaKB")]
   public class SdtMovement_RESTInterface : GxGenericCollectionItem<SdtMovement>
   {
      public SdtMovement_RESTInterface( ) : base()
      {
      }

      public SdtMovement_RESTInterface( SdtMovement psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MovementId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Movementid
      {
         get {
            return sdt.gxTpr_Movementid ;
         }

         set {
            sdt.gxTpr_Movementid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MovementType" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Movementtype
      {
         get {
            return sdt.gxTpr_Movementtype ;
         }

         set {
            sdt.gxTpr_Movementtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MovementCreatedDate" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Movementcreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Movementcreateddate) ;
         }

         set {
            sdt.gxTpr_Movementcreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "MovementKeyAditional" , Order = 3 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Movementkeyaditional
      {
         get {
            return sdt.gxTpr_Movementkeyaditional ;
         }

         set {
            sdt.gxTpr_Movementkeyaditional = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MovementDescription" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Movementdescription
      {
         get {
            return sdt.gxTpr_Movementdescription ;
         }

         set {
            sdt.gxTpr_Movementdescription = value;
         }

      }

      public SdtMovement sdt
      {
         get {
            return (SdtMovement)Sdt ;
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
            sdt = new SdtMovement() ;
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

   [DataContract(Name = @"Movement", Namespace = "mtaKB")]
   public class SdtMovement_RESTLInterface : GxGenericCollectionItem<SdtMovement>
   {
      public SdtMovement_RESTLInterface( ) : base()
      {
      }

      public SdtMovement_RESTLInterface( SdtMovement psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MovementType" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Movementtype
      {
         get {
            return sdt.gxTpr_Movementtype ;
         }

         set {
            sdt.gxTpr_Movementtype = (short)(value.HasValue ? value.Value : 0);
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

      public SdtMovement sdt
      {
         get {
            return (SdtMovement)Sdt ;
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
            sdt = new SdtMovement() ;
         }
      }

   }

}
