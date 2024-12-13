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
   [XmlRoot(ElementName = "Permission" )]
   [XmlType(TypeName =  "Permission" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtPermission : GxSilentTrnSdt
   {
      public SdtPermission( )
      {
      }

      public SdtPermission( IGxContext context )
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

      public void Load( int AV106PermissionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV106PermissionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PermissionId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Permission");
         metadata.Set("BT", "Permission");
         metadata.Set("PK", "[ \"PermissionId\" ]");
         metadata.Set("PKAssigned", "[ \"PermissionId\" ]");
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
         state.Add("gxTpr_Permissionid_Z");
         state.Add("gxTpr_Permissionname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPermission sdt;
         sdt = (SdtPermission)(source);
         gxTv_SdtPermission_Permissionid = sdt.gxTv_SdtPermission_Permissionid ;
         gxTv_SdtPermission_Permissionname = sdt.gxTv_SdtPermission_Permissionname ;
         gxTv_SdtPermission_Mode = sdt.gxTv_SdtPermission_Mode ;
         gxTv_SdtPermission_Initialized = sdt.gxTv_SdtPermission_Initialized ;
         gxTv_SdtPermission_Permissionid_Z = sdt.gxTv_SdtPermission_Permissionid_Z ;
         gxTv_SdtPermission_Permissionname_Z = sdt.gxTv_SdtPermission_Permissionname_Z ;
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
         AddObjectProperty("PermissionId", gxTv_SdtPermission_Permissionid, false, includeNonInitialized);
         AddObjectProperty("PermissionName", gxTv_SdtPermission_Permissionname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPermission_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPermission_Initialized, false, includeNonInitialized);
            AddObjectProperty("PermissionId_Z", gxTv_SdtPermission_Permissionid_Z, false, includeNonInitialized);
            AddObjectProperty("PermissionName_Z", gxTv_SdtPermission_Permissionname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPermission sdt )
      {
         if ( sdt.IsDirty("PermissionId") )
         {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Permissionid = sdt.gxTv_SdtPermission_Permissionid ;
         }
         if ( sdt.IsDirty("PermissionName") )
         {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Permissionname = sdt.gxTv_SdtPermission_Permissionname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PermissionId" )]
      [  XmlElement( ElementName = "PermissionId"   )]
      public int gxTpr_Permissionid
      {
         get {
            return gxTv_SdtPermission_Permissionid ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            if ( gxTv_SdtPermission_Permissionid != value )
            {
               gxTv_SdtPermission_Mode = "INS";
               this.gxTv_SdtPermission_Permissionid_Z_SetNull( );
               this.gxTv_SdtPermission_Permissionname_Z_SetNull( );
            }
            gxTv_SdtPermission_Permissionid = value;
            SetDirty("Permissionid");
         }

      }

      [  SoapElement( ElementName = "PermissionName" )]
      [  XmlElement( ElementName = "PermissionName"   )]
      public string gxTpr_Permissionname
      {
         get {
            return gxTv_SdtPermission_Permissionname ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Permissionname = value;
            SetDirty("Permissionname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPermission_Mode ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPermission_Mode_SetNull( )
      {
         gxTv_SdtPermission_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPermission_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPermission_Initialized ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPermission_Initialized_SetNull( )
      {
         gxTv_SdtPermission_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPermission_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PermissionId_Z" )]
      [  XmlElement( ElementName = "PermissionId_Z"   )]
      public int gxTpr_Permissionid_Z
      {
         get {
            return gxTv_SdtPermission_Permissionid_Z ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Permissionid_Z = value;
            SetDirty("Permissionid_Z");
         }

      }

      public void gxTv_SdtPermission_Permissionid_Z_SetNull( )
      {
         gxTv_SdtPermission_Permissionid_Z = 0;
         SetDirty("Permissionid_Z");
         return  ;
      }

      public bool gxTv_SdtPermission_Permissionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PermissionName_Z" )]
      [  XmlElement( ElementName = "PermissionName_Z"   )]
      public string gxTpr_Permissionname_Z
      {
         get {
            return gxTv_SdtPermission_Permissionname_Z ;
         }

         set {
            gxTv_SdtPermission_N = 0;
            gxTv_SdtPermission_Permissionname_Z = value;
            SetDirty("Permissionname_Z");
         }

      }

      public void gxTv_SdtPermission_Permissionname_Z_SetNull( )
      {
         gxTv_SdtPermission_Permissionname_Z = "";
         SetDirty("Permissionname_Z");
         return  ;
      }

      public bool gxTv_SdtPermission_Permissionname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPermission_N = 1;
         gxTv_SdtPermission_Permissionname = "";
         gxTv_SdtPermission_Mode = "";
         gxTv_SdtPermission_Permissionname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "permission", "GeneXus.Programs.permission_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPermission_N ;
      }

      private short gxTv_SdtPermission_N ;
      private short gxTv_SdtPermission_Initialized ;
      private int gxTv_SdtPermission_Permissionid ;
      private int gxTv_SdtPermission_Permissionid_Z ;
      private string gxTv_SdtPermission_Mode ;
      private string gxTv_SdtPermission_Permissionname ;
      private string gxTv_SdtPermission_Permissionname_Z ;
   }

   [DataContract(Name = @"Permission", Namespace = "mtaKB")]
   public class SdtPermission_RESTInterface : GxGenericCollectionItem<SdtPermission>
   {
      public SdtPermission_RESTInterface( ) : base()
      {
      }

      public SdtPermission_RESTInterface( SdtPermission psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PermissionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Permissionid
      {
         get {
            return sdt.gxTpr_Permissionid ;
         }

         set {
            sdt.gxTpr_Permissionid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PermissionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Permissionname
      {
         get {
            return sdt.gxTpr_Permissionname ;
         }

         set {
            sdt.gxTpr_Permissionname = value;
         }

      }

      public SdtPermission sdt
      {
         get {
            return (SdtPermission)Sdt ;
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
            sdt = new SdtPermission() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"Permission", Namespace = "mtaKB")]
   public class SdtPermission_RESTLInterface : GxGenericCollectionItem<SdtPermission>
   {
      public SdtPermission_RESTLInterface( ) : base()
      {
      }

      public SdtPermission_RESTLInterface( SdtPermission psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PermissionName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Permissionname
      {
         get {
            return sdt.gxTpr_Permissionname ;
         }

         set {
            sdt.gxTpr_Permissionname = value;
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

      public SdtPermission sdt
      {
         get {
            return (SdtPermission)Sdt ;
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
            sdt = new SdtPermission() ;
         }
      }

   }

}
