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
   [XmlRoot(ElementName = "Role.Permission" )]
   [XmlType(TypeName =  "Role.Permission" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtRole_Permission : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtRole_Permission( )
      {
      }

      public SdtRole_Permission( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"PermissionId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Permission");
         metadata.Set("BT", "RolePermission");
         metadata.Set("PK", "[ \"PermissionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PermissionId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RoleId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Permissionid_Z");
         state.Add("gxTpr_Permissionname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRole_Permission sdt;
         sdt = (SdtRole_Permission)(source);
         gxTv_SdtRole_Permission_Permissionid = sdt.gxTv_SdtRole_Permission_Permissionid ;
         gxTv_SdtRole_Permission_Permissionname = sdt.gxTv_SdtRole_Permission_Permissionname ;
         gxTv_SdtRole_Permission_Mode = sdt.gxTv_SdtRole_Permission_Mode ;
         gxTv_SdtRole_Permission_Modified = sdt.gxTv_SdtRole_Permission_Modified ;
         gxTv_SdtRole_Permission_Initialized = sdt.gxTv_SdtRole_Permission_Initialized ;
         gxTv_SdtRole_Permission_Permissionid_Z = sdt.gxTv_SdtRole_Permission_Permissionid_Z ;
         gxTv_SdtRole_Permission_Permissionname_Z = sdt.gxTv_SdtRole_Permission_Permissionname_Z ;
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
         AddObjectProperty("PermissionId", gxTv_SdtRole_Permission_Permissionid, false, includeNonInitialized);
         AddObjectProperty("PermissionName", gxTv_SdtRole_Permission_Permissionname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRole_Permission_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtRole_Permission_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRole_Permission_Initialized, false, includeNonInitialized);
            AddObjectProperty("PermissionId_Z", gxTv_SdtRole_Permission_Permissionid_Z, false, includeNonInitialized);
            AddObjectProperty("PermissionName_Z", gxTv_SdtRole_Permission_Permissionname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRole_Permission sdt )
      {
         if ( sdt.IsDirty("PermissionId") )
         {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionid = sdt.gxTv_SdtRole_Permission_Permissionid ;
         }
         if ( sdt.IsDirty("PermissionName") )
         {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionname = sdt.gxTv_SdtRole_Permission_Permissionname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PermissionId" )]
      [  XmlElement( ElementName = "PermissionId"   )]
      public int gxTpr_Permissionid
      {
         get {
            return gxTv_SdtRole_Permission_Permissionid ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionid = value;
            gxTv_SdtRole_Permission_Modified = 1;
            SetDirty("Permissionid");
         }

      }

      [  SoapElement( ElementName = "PermissionName" )]
      [  XmlElement( ElementName = "PermissionName"   )]
      public string gxTpr_Permissionname
      {
         get {
            return gxTv_SdtRole_Permission_Permissionname ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionname = value;
            gxTv_SdtRole_Permission_Modified = 1;
            SetDirty("Permissionname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRole_Permission_Mode ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRole_Permission_Mode_SetNull( )
      {
         gxTv_SdtRole_Permission_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtRole_Permission_Modified ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtRole_Permission_Modified_SetNull( )
      {
         gxTv_SdtRole_Permission_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRole_Permission_Initialized ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Initialized = value;
            gxTv_SdtRole_Permission_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRole_Permission_Initialized_SetNull( )
      {
         gxTv_SdtRole_Permission_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PermissionId_Z" )]
      [  XmlElement( ElementName = "PermissionId_Z"   )]
      public int gxTpr_Permissionid_Z
      {
         get {
            return gxTv_SdtRole_Permission_Permissionid_Z ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionid_Z = value;
            gxTv_SdtRole_Permission_Modified = 1;
            SetDirty("Permissionid_Z");
         }

      }

      public void gxTv_SdtRole_Permission_Permissionid_Z_SetNull( )
      {
         gxTv_SdtRole_Permission_Permissionid_Z = 0;
         SetDirty("Permissionid_Z");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_Permissionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PermissionName_Z" )]
      [  XmlElement( ElementName = "PermissionName_Z"   )]
      public string gxTpr_Permissionname_Z
      {
         get {
            return gxTv_SdtRole_Permission_Permissionname_Z ;
         }

         set {
            gxTv_SdtRole_Permission_N = 0;
            gxTv_SdtRole_Permission_Permissionname_Z = value;
            gxTv_SdtRole_Permission_Modified = 1;
            SetDirty("Permissionname_Z");
         }

      }

      public void gxTv_SdtRole_Permission_Permissionname_Z_SetNull( )
      {
         gxTv_SdtRole_Permission_Permissionname_Z = "";
         SetDirty("Permissionname_Z");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_Permissionname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRole_Permission_N = 1;
         gxTv_SdtRole_Permission_Permissionname = "";
         gxTv_SdtRole_Permission_Mode = "";
         gxTv_SdtRole_Permission_Permissionname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRole_Permission_N ;
      }

      private short gxTv_SdtRole_Permission_N ;
      private short gxTv_SdtRole_Permission_Modified ;
      private short gxTv_SdtRole_Permission_Initialized ;
      private int gxTv_SdtRole_Permission_Permissionid ;
      private int gxTv_SdtRole_Permission_Permissionid_Z ;
      private string gxTv_SdtRole_Permission_Mode ;
      private string gxTv_SdtRole_Permission_Permissionname ;
      private string gxTv_SdtRole_Permission_Permissionname_Z ;
   }

   [DataContract(Name = @"Role.Permission", Namespace = "mtaKB")]
   public class SdtRole_Permission_RESTInterface : GxGenericCollectionItem<SdtRole_Permission>
   {
      public SdtRole_Permission_RESTInterface( ) : base()
      {
      }

      public SdtRole_Permission_RESTInterface( SdtRole_Permission psdt ) : base(psdt)
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

      public SdtRole_Permission sdt
      {
         get {
            return (SdtRole_Permission)Sdt ;
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
            sdt = new SdtRole_Permission() ;
         }
      }

   }

   [DataContract(Name = @"Role.Permission", Namespace = "mtaKB")]
   public class SdtRole_Permission_RESTLInterface : GxGenericCollectionItem<SdtRole_Permission>
   {
      public SdtRole_Permission_RESTLInterface( ) : base()
      {
      }

      public SdtRole_Permission_RESTLInterface( SdtRole_Permission psdt ) : base(psdt)
      {
      }

      public SdtRole_Permission sdt
      {
         get {
            return (SdtRole_Permission)Sdt ;
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
            sdt = new SdtRole_Permission() ;
         }
      }

   }

}
