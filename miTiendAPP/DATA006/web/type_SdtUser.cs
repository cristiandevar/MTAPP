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
   [XmlRoot(ElementName = "User" )]
   [XmlType(TypeName =  "User" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtUser : GxSilentTrnSdt
   {
      public SdtUser( )
      {
      }

      public SdtUser( IGxContext context )
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

      public void Load( int AV99UserId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV99UserId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UserId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "User");
         metadata.Set("BT", "User");
         metadata.Set("PK", "[ \"UserId\" ]");
         metadata.Set("PKAssigned", "[ \"UserId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RoleId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Userid_Z");
         state.Add("gxTpr_Useremail_Z");
         state.Add("gxTpr_Username_Z");
         state.Add("gxTpr_Userpassword_Z");
         state.Add("gxTpr_Userhash_Z");
         state.Add("gxTpr_Usercreateddate_Z_Nullable");
         state.Add("gxTpr_Usermodifieddate_Z_Nullable");
         state.Add("gxTpr_Roleid_Z");
         state.Add("gxTpr_Rolename_Z");
         state.Add("gxTpr_Useractive_Z");
         state.Add("gxTpr_Useremail_N");
         state.Add("gxTpr_Roleid_N");
         state.Add("gxTpr_Useractive_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUser sdt;
         sdt = (SdtUser)(source);
         gxTv_SdtUser_Userid = sdt.gxTv_SdtUser_Userid ;
         gxTv_SdtUser_Useremail = sdt.gxTv_SdtUser_Useremail ;
         gxTv_SdtUser_Username = sdt.gxTv_SdtUser_Username ;
         gxTv_SdtUser_Userpassword = sdt.gxTv_SdtUser_Userpassword ;
         gxTv_SdtUser_Userhash = sdt.gxTv_SdtUser_Userhash ;
         gxTv_SdtUser_Usercreateddate = sdt.gxTv_SdtUser_Usercreateddate ;
         gxTv_SdtUser_Usermodifieddate = sdt.gxTv_SdtUser_Usermodifieddate ;
         gxTv_SdtUser_Roleid = sdt.gxTv_SdtUser_Roleid ;
         gxTv_SdtUser_Rolename = sdt.gxTv_SdtUser_Rolename ;
         gxTv_SdtUser_Useractive = sdt.gxTv_SdtUser_Useractive ;
         gxTv_SdtUser_Mode = sdt.gxTv_SdtUser_Mode ;
         gxTv_SdtUser_Initialized = sdt.gxTv_SdtUser_Initialized ;
         gxTv_SdtUser_Userid_Z = sdt.gxTv_SdtUser_Userid_Z ;
         gxTv_SdtUser_Useremail_Z = sdt.gxTv_SdtUser_Useremail_Z ;
         gxTv_SdtUser_Username_Z = sdt.gxTv_SdtUser_Username_Z ;
         gxTv_SdtUser_Userpassword_Z = sdt.gxTv_SdtUser_Userpassword_Z ;
         gxTv_SdtUser_Userhash_Z = sdt.gxTv_SdtUser_Userhash_Z ;
         gxTv_SdtUser_Usercreateddate_Z = sdt.gxTv_SdtUser_Usercreateddate_Z ;
         gxTv_SdtUser_Usermodifieddate_Z = sdt.gxTv_SdtUser_Usermodifieddate_Z ;
         gxTv_SdtUser_Roleid_Z = sdt.gxTv_SdtUser_Roleid_Z ;
         gxTv_SdtUser_Rolename_Z = sdt.gxTv_SdtUser_Rolename_Z ;
         gxTv_SdtUser_Useractive_Z = sdt.gxTv_SdtUser_Useractive_Z ;
         gxTv_SdtUser_Useremail_N = sdt.gxTv_SdtUser_Useremail_N ;
         gxTv_SdtUser_Roleid_N = sdt.gxTv_SdtUser_Roleid_N ;
         gxTv_SdtUser_Useractive_N = sdt.gxTv_SdtUser_Useractive_N ;
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
         AddObjectProperty("UserId", gxTv_SdtUser_Userid, false, includeNonInitialized);
         AddObjectProperty("UserEmail", gxTv_SdtUser_Useremail, false, includeNonInitialized);
         AddObjectProperty("UserEmail_N", gxTv_SdtUser_Useremail_N, false, includeNonInitialized);
         AddObjectProperty("UserName", gxTv_SdtUser_Username, false, includeNonInitialized);
         AddObjectProperty("UserPassword", gxTv_SdtUser_Userpassword, false, includeNonInitialized);
         AddObjectProperty("UserHash", gxTv_SdtUser_Userhash, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUser_Usercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUser_Usercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUser_Usercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UserCreatedDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUser_Usermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUser_Usermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUser_Usermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UserModifiedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("RoleId", gxTv_SdtUser_Roleid, false, includeNonInitialized);
         AddObjectProperty("RoleId_N", gxTv_SdtUser_Roleid_N, false, includeNonInitialized);
         AddObjectProperty("RoleName", gxTv_SdtUser_Rolename, false, includeNonInitialized);
         AddObjectProperty("UserActive", gxTv_SdtUser_Useractive, false, includeNonInitialized);
         AddObjectProperty("UserActive_N", gxTv_SdtUser_Useractive_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUser_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUser_Initialized, false, includeNonInitialized);
            AddObjectProperty("UserId_Z", gxTv_SdtUser_Userid_Z, false, includeNonInitialized);
            AddObjectProperty("UserEmail_Z", gxTv_SdtUser_Useremail_Z, false, includeNonInitialized);
            AddObjectProperty("UserName_Z", gxTv_SdtUser_Username_Z, false, includeNonInitialized);
            AddObjectProperty("UserPassword_Z", gxTv_SdtUser_Userpassword_Z, false, includeNonInitialized);
            AddObjectProperty("UserHash_Z", gxTv_SdtUser_Userhash_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUser_Usercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUser_Usercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUser_Usercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UserCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUser_Usermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUser_Usermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUser_Usermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("UserModifiedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("RoleId_Z", gxTv_SdtUser_Roleid_Z, false, includeNonInitialized);
            AddObjectProperty("RoleName_Z", gxTv_SdtUser_Rolename_Z, false, includeNonInitialized);
            AddObjectProperty("UserActive_Z", gxTv_SdtUser_Useractive_Z, false, includeNonInitialized);
            AddObjectProperty("UserEmail_N", gxTv_SdtUser_Useremail_N, false, includeNonInitialized);
            AddObjectProperty("RoleId_N", gxTv_SdtUser_Roleid_N, false, includeNonInitialized);
            AddObjectProperty("UserActive_N", gxTv_SdtUser_Useractive_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUser sdt )
      {
         if ( sdt.IsDirty("UserId") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userid = sdt.gxTv_SdtUser_Userid ;
         }
         if ( sdt.IsDirty("UserEmail") )
         {
            gxTv_SdtUser_Useremail_N = (short)(sdt.gxTv_SdtUser_Useremail_N);
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useremail = sdt.gxTv_SdtUser_Useremail ;
         }
         if ( sdt.IsDirty("UserName") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Username = sdt.gxTv_SdtUser_Username ;
         }
         if ( sdt.IsDirty("UserPassword") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userpassword = sdt.gxTv_SdtUser_Userpassword ;
         }
         if ( sdt.IsDirty("UserHash") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userhash = sdt.gxTv_SdtUser_Userhash ;
         }
         if ( sdt.IsDirty("UserCreatedDate") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usercreateddate = sdt.gxTv_SdtUser_Usercreateddate ;
         }
         if ( sdt.IsDirty("UserModifiedDate") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usermodifieddate = sdt.gxTv_SdtUser_Usermodifieddate ;
         }
         if ( sdt.IsDirty("RoleId") )
         {
            gxTv_SdtUser_Roleid_N = (short)(sdt.gxTv_SdtUser_Roleid_N);
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Roleid = sdt.gxTv_SdtUser_Roleid ;
         }
         if ( sdt.IsDirty("RoleName") )
         {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Rolename = sdt.gxTv_SdtUser_Rolename ;
         }
         if ( sdt.IsDirty("UserActive") )
         {
            gxTv_SdtUser_Useractive_N = (short)(sdt.gxTv_SdtUser_Useractive_N);
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useractive = sdt.gxTv_SdtUser_Useractive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UserId" )]
      [  XmlElement( ElementName = "UserId"   )]
      public int gxTpr_Userid
      {
         get {
            return gxTv_SdtUser_Userid ;
         }

         set {
            gxTv_SdtUser_N = 0;
            if ( gxTv_SdtUser_Userid != value )
            {
               gxTv_SdtUser_Mode = "INS";
               this.gxTv_SdtUser_Userid_Z_SetNull( );
               this.gxTv_SdtUser_Useremail_Z_SetNull( );
               this.gxTv_SdtUser_Username_Z_SetNull( );
               this.gxTv_SdtUser_Userpassword_Z_SetNull( );
               this.gxTv_SdtUser_Userhash_Z_SetNull( );
               this.gxTv_SdtUser_Usercreateddate_Z_SetNull( );
               this.gxTv_SdtUser_Usermodifieddate_Z_SetNull( );
               this.gxTv_SdtUser_Roleid_Z_SetNull( );
               this.gxTv_SdtUser_Rolename_Z_SetNull( );
               this.gxTv_SdtUser_Useractive_Z_SetNull( );
            }
            gxTv_SdtUser_Userid = value;
            SetDirty("Userid");
         }

      }

      [  SoapElement( ElementName = "UserEmail" )]
      [  XmlElement( ElementName = "UserEmail"   )]
      public string gxTpr_Useremail
      {
         get {
            return gxTv_SdtUser_Useremail ;
         }

         set {
            gxTv_SdtUser_Useremail_N = 0;
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useremail = value;
            SetDirty("Useremail");
         }

      }

      public void gxTv_SdtUser_Useremail_SetNull( )
      {
         gxTv_SdtUser_Useremail_N = 1;
         gxTv_SdtUser_Useremail = "";
         SetDirty("Useremail");
         return  ;
      }

      public bool gxTv_SdtUser_Useremail_IsNull( )
      {
         return (gxTv_SdtUser_Useremail_N==1) ;
      }

      [  SoapElement( ElementName = "UserName" )]
      [  XmlElement( ElementName = "UserName"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtUser_Username ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "UserPassword" )]
      [  XmlElement( ElementName = "UserPassword"   )]
      public string gxTpr_Userpassword
      {
         get {
            return gxTv_SdtUser_Userpassword ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userpassword = value;
            SetDirty("Userpassword");
         }

      }

      [  SoapElement( ElementName = "UserHash" )]
      [  XmlElement( ElementName = "UserHash"   )]
      public string gxTpr_Userhash
      {
         get {
            return gxTv_SdtUser_Userhash ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userhash = value;
            SetDirty("Userhash");
         }

      }

      [  SoapElement( ElementName = "UserCreatedDate" )]
      [  XmlElement( ElementName = "UserCreatedDate"  , IsNullable=true )]
      public string gxTpr_Usercreateddate_Nullable
      {
         get {
            if ( gxTv_SdtUser_Usercreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUser_Usercreateddate).value ;
         }

         set {
            gxTv_SdtUser_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUser_Usercreateddate = DateTime.MinValue;
            else
               gxTv_SdtUser_Usercreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usercreateddate
      {
         get {
            return gxTv_SdtUser_Usercreateddate ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usercreateddate = value;
            SetDirty("Usercreateddate");
         }

      }

      [  SoapElement( ElementName = "UserModifiedDate" )]
      [  XmlElement( ElementName = "UserModifiedDate"  , IsNullable=true )]
      public string gxTpr_Usermodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtUser_Usermodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUser_Usermodifieddate).value ;
         }

         set {
            gxTv_SdtUser_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUser_Usermodifieddate = DateTime.MinValue;
            else
               gxTv_SdtUser_Usermodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usermodifieddate
      {
         get {
            return gxTv_SdtUser_Usermodifieddate ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usermodifieddate = value;
            SetDirty("Usermodifieddate");
         }

      }

      [  SoapElement( ElementName = "RoleId" )]
      [  XmlElement( ElementName = "RoleId"   )]
      public int gxTpr_Roleid
      {
         get {
            return gxTv_SdtUser_Roleid ;
         }

         set {
            gxTv_SdtUser_Roleid_N = 0;
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Roleid = value;
            SetDirty("Roleid");
         }

      }

      public void gxTv_SdtUser_Roleid_SetNull( )
      {
         gxTv_SdtUser_Roleid_N = 1;
         gxTv_SdtUser_Roleid = 0;
         SetDirty("Roleid");
         return  ;
      }

      public bool gxTv_SdtUser_Roleid_IsNull( )
      {
         return (gxTv_SdtUser_Roleid_N==1) ;
      }

      [  SoapElement( ElementName = "RoleName" )]
      [  XmlElement( ElementName = "RoleName"   )]
      public string gxTpr_Rolename
      {
         get {
            return gxTv_SdtUser_Rolename ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Rolename = value;
            SetDirty("Rolename");
         }

      }

      [  SoapElement( ElementName = "UserActive" )]
      [  XmlElement( ElementName = "UserActive"   )]
      public bool gxTpr_Useractive
      {
         get {
            return gxTv_SdtUser_Useractive ;
         }

         set {
            gxTv_SdtUser_Useractive_N = 0;
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useractive = value;
            SetDirty("Useractive");
         }

      }

      public void gxTv_SdtUser_Useractive_SetNull( )
      {
         gxTv_SdtUser_Useractive_N = 1;
         gxTv_SdtUser_Useractive = false;
         SetDirty("Useractive");
         return  ;
      }

      public bool gxTv_SdtUser_Useractive_IsNull( )
      {
         return (gxTv_SdtUser_Useractive_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUser_Mode ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUser_Mode_SetNull( )
      {
         gxTv_SdtUser_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUser_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUser_Initialized ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUser_Initialized_SetNull( )
      {
         gxTv_SdtUser_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUser_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserId_Z" )]
      [  XmlElement( ElementName = "UserId_Z"   )]
      public int gxTpr_Userid_Z
      {
         get {
            return gxTv_SdtUser_Userid_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userid_Z = value;
            SetDirty("Userid_Z");
         }

      }

      public void gxTv_SdtUser_Userid_Z_SetNull( )
      {
         gxTv_SdtUser_Userid_Z = 0;
         SetDirty("Userid_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Userid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserEmail_Z" )]
      [  XmlElement( ElementName = "UserEmail_Z"   )]
      public string gxTpr_Useremail_Z
      {
         get {
            return gxTv_SdtUser_Useremail_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useremail_Z = value;
            SetDirty("Useremail_Z");
         }

      }

      public void gxTv_SdtUser_Useremail_Z_SetNull( )
      {
         gxTv_SdtUser_Useremail_Z = "";
         SetDirty("Useremail_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Useremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserName_Z" )]
      [  XmlElement( ElementName = "UserName_Z"   )]
      public string gxTpr_Username_Z
      {
         get {
            return gxTv_SdtUser_Username_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Username_Z = value;
            SetDirty("Username_Z");
         }

      }

      public void gxTv_SdtUser_Username_Z_SetNull( )
      {
         gxTv_SdtUser_Username_Z = "";
         SetDirty("Username_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Username_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserPassword_Z" )]
      [  XmlElement( ElementName = "UserPassword_Z"   )]
      public string gxTpr_Userpassword_Z
      {
         get {
            return gxTv_SdtUser_Userpassword_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userpassword_Z = value;
            SetDirty("Userpassword_Z");
         }

      }

      public void gxTv_SdtUser_Userpassword_Z_SetNull( )
      {
         gxTv_SdtUser_Userpassword_Z = "";
         SetDirty("Userpassword_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Userpassword_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserHash_Z" )]
      [  XmlElement( ElementName = "UserHash_Z"   )]
      public string gxTpr_Userhash_Z
      {
         get {
            return gxTv_SdtUser_Userhash_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Userhash_Z = value;
            SetDirty("Userhash_Z");
         }

      }

      public void gxTv_SdtUser_Userhash_Z_SetNull( )
      {
         gxTv_SdtUser_Userhash_Z = "";
         SetDirty("Userhash_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Userhash_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserCreatedDate_Z" )]
      [  XmlElement( ElementName = "UserCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Usercreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtUser_Usercreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUser_Usercreateddate_Z).value ;
         }

         set {
            gxTv_SdtUser_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUser_Usercreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtUser_Usercreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usercreateddate_Z
      {
         get {
            return gxTv_SdtUser_Usercreateddate_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usercreateddate_Z = value;
            SetDirty("Usercreateddate_Z");
         }

      }

      public void gxTv_SdtUser_Usercreateddate_Z_SetNull( )
      {
         gxTv_SdtUser_Usercreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usercreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Usercreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserModifiedDate_Z" )]
      [  XmlElement( ElementName = "UserModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Usermodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtUser_Usermodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUser_Usermodifieddate_Z).value ;
         }

         set {
            gxTv_SdtUser_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUser_Usermodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtUser_Usermodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usermodifieddate_Z
      {
         get {
            return gxTv_SdtUser_Usermodifieddate_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Usermodifieddate_Z = value;
            SetDirty("Usermodifieddate_Z");
         }

      }

      public void gxTv_SdtUser_Usermodifieddate_Z_SetNull( )
      {
         gxTv_SdtUser_Usermodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usermodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Usermodifieddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleId_Z" )]
      [  XmlElement( ElementName = "RoleId_Z"   )]
      public int gxTpr_Roleid_Z
      {
         get {
            return gxTv_SdtUser_Roleid_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Roleid_Z = value;
            SetDirty("Roleid_Z");
         }

      }

      public void gxTv_SdtUser_Roleid_Z_SetNull( )
      {
         gxTv_SdtUser_Roleid_Z = 0;
         SetDirty("Roleid_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Roleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleName_Z" )]
      [  XmlElement( ElementName = "RoleName_Z"   )]
      public string gxTpr_Rolename_Z
      {
         get {
            return gxTv_SdtUser_Rolename_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Rolename_Z = value;
            SetDirty("Rolename_Z");
         }

      }

      public void gxTv_SdtUser_Rolename_Z_SetNull( )
      {
         gxTv_SdtUser_Rolename_Z = "";
         SetDirty("Rolename_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Rolename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserActive_Z" )]
      [  XmlElement( ElementName = "UserActive_Z"   )]
      public bool gxTpr_Useractive_Z
      {
         get {
            return gxTv_SdtUser_Useractive_Z ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useractive_Z = value;
            SetDirty("Useractive_Z");
         }

      }

      public void gxTv_SdtUser_Useractive_Z_SetNull( )
      {
         gxTv_SdtUser_Useractive_Z = false;
         SetDirty("Useractive_Z");
         return  ;
      }

      public bool gxTv_SdtUser_Useractive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserEmail_N" )]
      [  XmlElement( ElementName = "UserEmail_N"   )]
      public short gxTpr_Useremail_N
      {
         get {
            return gxTv_SdtUser_Useremail_N ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useremail_N = value;
            SetDirty("Useremail_N");
         }

      }

      public void gxTv_SdtUser_Useremail_N_SetNull( )
      {
         gxTv_SdtUser_Useremail_N = 0;
         SetDirty("Useremail_N");
         return  ;
      }

      public bool gxTv_SdtUser_Useremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleId_N" )]
      [  XmlElement( ElementName = "RoleId_N"   )]
      public short gxTpr_Roleid_N
      {
         get {
            return gxTv_SdtUser_Roleid_N ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Roleid_N = value;
            SetDirty("Roleid_N");
         }

      }

      public void gxTv_SdtUser_Roleid_N_SetNull( )
      {
         gxTv_SdtUser_Roleid_N = 0;
         SetDirty("Roleid_N");
         return  ;
      }

      public bool gxTv_SdtUser_Roleid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserActive_N" )]
      [  XmlElement( ElementName = "UserActive_N"   )]
      public short gxTpr_Useractive_N
      {
         get {
            return gxTv_SdtUser_Useractive_N ;
         }

         set {
            gxTv_SdtUser_N = 0;
            gxTv_SdtUser_Useractive_N = value;
            SetDirty("Useractive_N");
         }

      }

      public void gxTv_SdtUser_Useractive_N_SetNull( )
      {
         gxTv_SdtUser_Useractive_N = 0;
         SetDirty("Useractive_N");
         return  ;
      }

      public bool gxTv_SdtUser_Useractive_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtUser_N = 1;
         gxTv_SdtUser_Useremail = "";
         gxTv_SdtUser_Username = "";
         gxTv_SdtUser_Userpassword = "";
         gxTv_SdtUser_Userhash = "";
         gxTv_SdtUser_Usercreateddate = DateTime.MinValue;
         gxTv_SdtUser_Usermodifieddate = DateTime.MinValue;
         gxTv_SdtUser_Rolename = "";
         gxTv_SdtUser_Mode = "";
         gxTv_SdtUser_Useremail_Z = "";
         gxTv_SdtUser_Username_Z = "";
         gxTv_SdtUser_Userpassword_Z = "";
         gxTv_SdtUser_Userhash_Z = "";
         gxTv_SdtUser_Usercreateddate_Z = DateTime.MinValue;
         gxTv_SdtUser_Usermodifieddate_Z = DateTime.MinValue;
         gxTv_SdtUser_Rolename_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "user", "GeneXus.Programs.user_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtUser_N ;
      }

      private short gxTv_SdtUser_N ;
      private short gxTv_SdtUser_Initialized ;
      private short gxTv_SdtUser_Useremail_N ;
      private short gxTv_SdtUser_Roleid_N ;
      private short gxTv_SdtUser_Useractive_N ;
      private int gxTv_SdtUser_Userid ;
      private int gxTv_SdtUser_Roleid ;
      private int gxTv_SdtUser_Userid_Z ;
      private int gxTv_SdtUser_Roleid_Z ;
      private string gxTv_SdtUser_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtUser_Usercreateddate ;
      private DateTime gxTv_SdtUser_Usermodifieddate ;
      private DateTime gxTv_SdtUser_Usercreateddate_Z ;
      private DateTime gxTv_SdtUser_Usermodifieddate_Z ;
      private bool gxTv_SdtUser_Useractive ;
      private bool gxTv_SdtUser_Useractive_Z ;
      private string gxTv_SdtUser_Useremail ;
      private string gxTv_SdtUser_Username ;
      private string gxTv_SdtUser_Userpassword ;
      private string gxTv_SdtUser_Userhash ;
      private string gxTv_SdtUser_Rolename ;
      private string gxTv_SdtUser_Useremail_Z ;
      private string gxTv_SdtUser_Username_Z ;
      private string gxTv_SdtUser_Userpassword_Z ;
      private string gxTv_SdtUser_Userhash_Z ;
      private string gxTv_SdtUser_Rolename_Z ;
   }

   [DataContract(Name = @"User", Namespace = "mtaKB")]
   public class SdtUser_RESTInterface : GxGenericCollectionItem<SdtUser>
   {
      public SdtUser_RESTInterface( ) : base()
      {
      }

      public SdtUser_RESTInterface( SdtUser psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Userid
      {
         get {
            return sdt.gxTpr_Userid ;
         }

         set {
            sdt.gxTpr_Userid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UserEmail" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Useremail
      {
         get {
            return sdt.gxTpr_Useremail ;
         }

         set {
            sdt.gxTpr_Useremail = value;
         }

      }

      [DataMember( Name = "UserName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Username
      {
         get {
            return sdt.gxTpr_Username ;
         }

         set {
            sdt.gxTpr_Username = value;
         }

      }

      [DataMember( Name = "UserPassword" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Userpassword
      {
         get {
            return sdt.gxTpr_Userpassword ;
         }

         set {
            sdt.gxTpr_Userpassword = value;
         }

      }

      [DataMember( Name = "UserHash" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Userhash
      {
         get {
            return sdt.gxTpr_Userhash ;
         }

         set {
            sdt.gxTpr_Userhash = value;
         }

      }

      [DataMember( Name = "UserCreatedDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Usercreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usercreateddate) ;
         }

         set {
            sdt.gxTpr_Usercreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UserModifiedDate" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Usermodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usermodifieddate) ;
         }

         set {
            sdt.gxTpr_Usermodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "RoleId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Roleid
      {
         get {
            return sdt.gxTpr_Roleid ;
         }

         set {
            sdt.gxTpr_Roleid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RoleName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Rolename
      {
         get {
            return sdt.gxTpr_Rolename ;
         }

         set {
            sdt.gxTpr_Rolename = value;
         }

      }

      [DataMember( Name = "UserActive" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Useractive
      {
         get {
            return sdt.gxTpr_Useractive ;
         }

         set {
            sdt.gxTpr_Useractive = value;
         }

      }

      public SdtUser sdt
      {
         get {
            return (SdtUser)Sdt ;
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
            sdt = new SdtUser() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"User", Namespace = "mtaKB")]
   public class SdtUser_RESTLInterface : GxGenericCollectionItem<SdtUser>
   {
      public SdtUser_RESTLInterface( ) : base()
      {
      }

      public SdtUser_RESTLInterface( SdtUser psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserEmail" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Useremail
      {
         get {
            return sdt.gxTpr_Useremail ;
         }

         set {
            sdt.gxTpr_Useremail = value;
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

      public SdtUser sdt
      {
         get {
            return (SdtUser)Sdt ;
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
            sdt = new SdtUser() ;
         }
      }

   }

}
