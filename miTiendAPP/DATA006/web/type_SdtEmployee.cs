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
   [XmlRoot(ElementName = "Employee" )]
   [XmlType(TypeName =  "Employee" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtEmployee : GxSilentTrnSdt
   {
      public SdtEmployee( )
      {
      }

      public SdtEmployee( IGxContext context )
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

      public void Load( int AV12EmployeeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV12EmployeeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmployeeId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Employee");
         metadata.Set("BT", "Employee");
         metadata.Set("PK", "[ \"EmployeeId\" ]");
         metadata.Set("PKAssigned", "[ \"EmployeeId\" ]");
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
         state.Add("gxTpr_Employeeid_Z");
         state.Add("gxTpr_Employeefirstname_Z");
         state.Add("gxTpr_Employeelastname_Z");
         state.Add("gxTpr_Employeecreateddate_Z_Nullable");
         state.Add("gxTpr_Employeemodifieddate_Z_Nullable");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmployee sdt;
         sdt = (SdtEmployee)(source);
         gxTv_SdtEmployee_Employeeid = sdt.gxTv_SdtEmployee_Employeeid ;
         gxTv_SdtEmployee_Employeefirstname = sdt.gxTv_SdtEmployee_Employeefirstname ;
         gxTv_SdtEmployee_Employeelastname = sdt.gxTv_SdtEmployee_Employeelastname ;
         gxTv_SdtEmployee_Employeecreateddate = sdt.gxTv_SdtEmployee_Employeecreateddate ;
         gxTv_SdtEmployee_Employeemodifieddate = sdt.gxTv_SdtEmployee_Employeemodifieddate ;
         gxTv_SdtEmployee_Mode = sdt.gxTv_SdtEmployee_Mode ;
         gxTv_SdtEmployee_Initialized = sdt.gxTv_SdtEmployee_Initialized ;
         gxTv_SdtEmployee_Employeeid_Z = sdt.gxTv_SdtEmployee_Employeeid_Z ;
         gxTv_SdtEmployee_Employeefirstname_Z = sdt.gxTv_SdtEmployee_Employeefirstname_Z ;
         gxTv_SdtEmployee_Employeelastname_Z = sdt.gxTv_SdtEmployee_Employeelastname_Z ;
         gxTv_SdtEmployee_Employeecreateddate_Z = sdt.gxTv_SdtEmployee_Employeecreateddate_Z ;
         gxTv_SdtEmployee_Employeemodifieddate_Z = sdt.gxTv_SdtEmployee_Employeemodifieddate_Z ;
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
         AddObjectProperty("EmployeeId", gxTv_SdtEmployee_Employeeid, false, includeNonInitialized);
         AddObjectProperty("EmployeeFirstName", gxTv_SdtEmployee_Employeefirstname, false, includeNonInitialized);
         AddObjectProperty("EmployeeLastName", gxTv_SdtEmployee_Employeelastname, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmployeeCreatedDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmployeeModifiedDate", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmployee_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmployee_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmployeeId_Z", gxTv_SdtEmployee_Employeeid_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeFirstName_Z", gxTv_SdtEmployee_Employeefirstname_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeLastName_Z", gxTv_SdtEmployee_Employeelastname_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmployeeCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmployeeModifiedDate_Z", sDateCnv, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmployee sdt )
      {
         if ( sdt.IsDirty("EmployeeId") )
         {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeeid = sdt.gxTv_SdtEmployee_Employeeid ;
         }
         if ( sdt.IsDirty("EmployeeFirstName") )
         {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeefirstname = sdt.gxTv_SdtEmployee_Employeefirstname ;
         }
         if ( sdt.IsDirty("EmployeeLastName") )
         {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeelastname = sdt.gxTv_SdtEmployee_Employeelastname ;
         }
         if ( sdt.IsDirty("EmployeeCreatedDate") )
         {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeecreateddate = sdt.gxTv_SdtEmployee_Employeecreateddate ;
         }
         if ( sdt.IsDirty("EmployeeModifiedDate") )
         {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeemodifieddate = sdt.gxTv_SdtEmployee_Employeemodifieddate ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public int gxTpr_Employeeid
      {
         get {
            return gxTv_SdtEmployee_Employeeid ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            if ( gxTv_SdtEmployee_Employeeid != value )
            {
               gxTv_SdtEmployee_Mode = "INS";
               this.gxTv_SdtEmployee_Employeeid_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeefirstname_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeelastname_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeecreateddate_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeemodifieddate_Z_SetNull( );
            }
            gxTv_SdtEmployee_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeFirstName" )]
      [  XmlElement( ElementName = "EmployeeFirstName"   )]
      public string gxTpr_Employeefirstname
      {
         get {
            return gxTv_SdtEmployee_Employeefirstname ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeefirstname = value;
            SetDirty("Employeefirstname");
         }

      }

      [  SoapElement( ElementName = "EmployeeLastName" )]
      [  XmlElement( ElementName = "EmployeeLastName"   )]
      public string gxTpr_Employeelastname
      {
         get {
            return gxTv_SdtEmployee_Employeelastname ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeelastname = value;
            SetDirty("Employeelastname");
         }

      }

      [  SoapElement( ElementName = "EmployeeCreatedDate" )]
      [  XmlElement( ElementName = "EmployeeCreatedDate"  , IsNullable=true )]
      public string gxTpr_Employeecreateddate_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeecreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeecreateddate).value ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeecreateddate = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeecreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeecreateddate
      {
         get {
            return gxTv_SdtEmployee_Employeecreateddate ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeecreateddate = value;
            SetDirty("Employeecreateddate");
         }

      }

      [  SoapElement( ElementName = "EmployeeModifiedDate" )]
      [  XmlElement( ElementName = "EmployeeModifiedDate"  , IsNullable=true )]
      public string gxTpr_Employeemodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeemodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeemodifieddate).value ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeemodifieddate = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeemodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeemodifieddate
      {
         get {
            return gxTv_SdtEmployee_Employeemodifieddate ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeemodifieddate = value;
            SetDirty("Employeemodifieddate");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmployee_Mode ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmployee_Mode_SetNull( )
      {
         gxTv_SdtEmployee_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmployee_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmployee_Initialized ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmployee_Initialized_SetNull( )
      {
         gxTv_SdtEmployee_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmployee_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeId_Z" )]
      [  XmlElement( ElementName = "EmployeeId_Z"   )]
      public int gxTpr_Employeeid_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeid_Z ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeeid_Z = value;
            SetDirty("Employeeid_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeid_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeid_Z = 0;
         SetDirty("Employeeid_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeFirstName_Z" )]
      [  XmlElement( ElementName = "EmployeeFirstName_Z"   )]
      public string gxTpr_Employeefirstname_Z
      {
         get {
            return gxTv_SdtEmployee_Employeefirstname_Z ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeefirstname_Z = value;
            SetDirty("Employeefirstname_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeefirstname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeefirstname_Z = "";
         SetDirty("Employeefirstname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeefirstname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeLastName_Z" )]
      [  XmlElement( ElementName = "EmployeeLastName_Z"   )]
      public string gxTpr_Employeelastname_Z
      {
         get {
            return gxTv_SdtEmployee_Employeelastname_Z ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeelastname_Z = value;
            SetDirty("Employeelastname_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeelastname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeelastname_Z = "";
         SetDirty("Employeelastname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeelastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeCreatedDate_Z" )]
      [  XmlElement( ElementName = "EmployeeCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Employeecreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeecreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeecreateddate_Z).value ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeecreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeecreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeecreateddate_Z
      {
         get {
            return gxTv_SdtEmployee_Employeecreateddate_Z ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeecreateddate_Z = value;
            SetDirty("Employeecreateddate_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeecreateddate_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeecreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Employeecreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeecreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeModifiedDate_Z" )]
      [  XmlElement( ElementName = "EmployeeModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Employeemodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeemodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeemodifieddate_Z).value ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeemodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeemodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeemodifieddate_Z
      {
         get {
            return gxTv_SdtEmployee_Employeemodifieddate_Z ;
         }

         set {
            gxTv_SdtEmployee_N = 0;
            gxTv_SdtEmployee_Employeemodifieddate_Z = value;
            SetDirty("Employeemodifieddate_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeemodifieddate_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeemodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Employeemodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeemodifieddate_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEmployee_N = 1;
         gxTv_SdtEmployee_Employeefirstname = "";
         gxTv_SdtEmployee_Employeelastname = "";
         gxTv_SdtEmployee_Employeecreateddate = DateTime.MinValue;
         gxTv_SdtEmployee_Employeemodifieddate = DateTime.MinValue;
         gxTv_SdtEmployee_Mode = "";
         gxTv_SdtEmployee_Employeefirstname_Z = "";
         gxTv_SdtEmployee_Employeelastname_Z = "";
         gxTv_SdtEmployee_Employeecreateddate_Z = DateTime.MinValue;
         gxTv_SdtEmployee_Employeemodifieddate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "employee", "GeneXus.Programs.employee_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEmployee_N ;
      }

      private short gxTv_SdtEmployee_N ;
      private short gxTv_SdtEmployee_Initialized ;
      private int gxTv_SdtEmployee_Employeeid ;
      private int gxTv_SdtEmployee_Employeeid_Z ;
      private string gxTv_SdtEmployee_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEmployee_Employeecreateddate ;
      private DateTime gxTv_SdtEmployee_Employeemodifieddate ;
      private DateTime gxTv_SdtEmployee_Employeecreateddate_Z ;
      private DateTime gxTv_SdtEmployee_Employeemodifieddate_Z ;
      private string gxTv_SdtEmployee_Employeefirstname ;
      private string gxTv_SdtEmployee_Employeelastname ;
      private string gxTv_SdtEmployee_Employeefirstname_Z ;
      private string gxTv_SdtEmployee_Employeelastname_Z ;
   }

   [DataContract(Name = @"Employee", Namespace = "mtaKB")]
   public class SdtEmployee_RESTInterface : GxGenericCollectionItem<SdtEmployee>
   {
      public SdtEmployee_RESTInterface( ) : base()
      {
      }

      public SdtEmployee_RESTInterface( SdtEmployee psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmployeeId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Employeeid
      {
         get {
            return sdt.gxTpr_Employeeid ;
         }

         set {
            sdt.gxTpr_Employeeid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EmployeeFirstName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Employeefirstname
      {
         get {
            return sdt.gxTpr_Employeefirstname ;
         }

         set {
            sdt.gxTpr_Employeefirstname = value;
         }

      }

      [DataMember( Name = "EmployeeLastName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Employeelastname
      {
         get {
            return sdt.gxTpr_Employeelastname ;
         }

         set {
            sdt.gxTpr_Employeelastname = value;
         }

      }

      [DataMember( Name = "EmployeeCreatedDate" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Employeecreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Employeecreateddate) ;
         }

         set {
            sdt.gxTpr_Employeecreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "EmployeeModifiedDate" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Employeemodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Employeemodifieddate) ;
         }

         set {
            sdt.gxTpr_Employeemodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      public SdtEmployee sdt
      {
         get {
            return (SdtEmployee)Sdt ;
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
            sdt = new SdtEmployee() ;
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

   [DataContract(Name = @"Employee", Namespace = "mtaKB")]
   public class SdtEmployee_RESTLInterface : GxGenericCollectionItem<SdtEmployee>
   {
      public SdtEmployee_RESTLInterface( ) : base()
      {
      }

      public SdtEmployee_RESTLInterface( SdtEmployee psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmployeeFirstName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Employeefirstname
      {
         get {
            return sdt.gxTpr_Employeefirstname ;
         }

         set {
            sdt.gxTpr_Employeefirstname = value;
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

      public SdtEmployee sdt
      {
         get {
            return (SdtEmployee)Sdt ;
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
            sdt = new SdtEmployee() ;
         }
      }

   }

}
