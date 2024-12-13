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
   [XmlRoot(ElementName = "Role" )]
   [XmlType(TypeName =  "Role" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtRole : GxSilentTrnSdt
   {
      public SdtRole( )
      {
      }

      public SdtRole( IGxContext context )
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

      public void Load( int AV104RoleId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV104RoleId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RoleId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Role");
         metadata.Set("BT", "Role");
         metadata.Set("PK", "[ \"RoleId\" ]");
         metadata.Set("PKAssigned", "[ \"RoleId\" ]");
         metadata.Set("Levels", "[ \"Permission\" ]");
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
         state.Add("gxTpr_Roleid_Z");
         state.Add("gxTpr_Rolename_Z");
         state.Add("gxTpr_Roleid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRole sdt;
         sdt = (SdtRole)(source);
         gxTv_SdtRole_Roleid = sdt.gxTv_SdtRole_Roleid ;
         gxTv_SdtRole_Rolename = sdt.gxTv_SdtRole_Rolename ;
         gxTv_SdtRole_Permission = sdt.gxTv_SdtRole_Permission ;
         gxTv_SdtRole_Mode = sdt.gxTv_SdtRole_Mode ;
         gxTv_SdtRole_Initialized = sdt.gxTv_SdtRole_Initialized ;
         gxTv_SdtRole_Roleid_Z = sdt.gxTv_SdtRole_Roleid_Z ;
         gxTv_SdtRole_Rolename_Z = sdt.gxTv_SdtRole_Rolename_Z ;
         gxTv_SdtRole_Roleid_N = sdt.gxTv_SdtRole_Roleid_N ;
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
         AddObjectProperty("RoleId", gxTv_SdtRole_Roleid, false, includeNonInitialized);
         AddObjectProperty("RoleId_N", gxTv_SdtRole_Roleid_N, false, includeNonInitialized);
         AddObjectProperty("RoleName", gxTv_SdtRole_Rolename, false, includeNonInitialized);
         if ( gxTv_SdtRole_Permission != null )
         {
            AddObjectProperty("Permission", gxTv_SdtRole_Permission, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRole_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRole_Initialized, false, includeNonInitialized);
            AddObjectProperty("RoleId_Z", gxTv_SdtRole_Roleid_Z, false, includeNonInitialized);
            AddObjectProperty("RoleName_Z", gxTv_SdtRole_Rolename_Z, false, includeNonInitialized);
            AddObjectProperty("RoleId_N", gxTv_SdtRole_Roleid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRole sdt )
      {
         if ( sdt.IsDirty("RoleId") )
         {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Roleid = sdt.gxTv_SdtRole_Roleid ;
         }
         if ( sdt.IsDirty("RoleName") )
         {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Rolename = sdt.gxTv_SdtRole_Rolename ;
         }
         if ( gxTv_SdtRole_Permission != null )
         {
            GXBCLevelCollection<SdtRole_Permission> newCollectionPermission = sdt.gxTpr_Permission;
            SdtRole_Permission currItemPermission;
            SdtRole_Permission newItemPermission;
            short idx = 1;
            while ( idx <= newCollectionPermission.Count )
            {
               newItemPermission = ((SdtRole_Permission)newCollectionPermission.Item(idx));
               currItemPermission = gxTv_SdtRole_Permission.GetByKey(newItemPermission.gxTpr_Permissionid);
               if ( StringUtil.StrCmp(currItemPermission.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemPermission.UpdateDirties(newItemPermission);
                  if ( StringUtil.StrCmp(newItemPermission.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemPermission.gxTpr_Mode = "DLT";
                  }
                  currItemPermission.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtRole_Permission.Add(newItemPermission, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "RoleId" )]
      [  XmlElement( ElementName = "RoleId"   )]
      public int gxTpr_Roleid
      {
         get {
            return gxTv_SdtRole_Roleid ;
         }

         set {
            gxTv_SdtRole_N = 0;
            if ( gxTv_SdtRole_Roleid != value )
            {
               gxTv_SdtRole_Mode = "INS";
               this.gxTv_SdtRole_Roleid_Z_SetNull( );
               this.gxTv_SdtRole_Rolename_Z_SetNull( );
               if ( gxTv_SdtRole_Permission != null )
               {
                  GXBCLevelCollection<SdtRole_Permission> collectionPermission = gxTv_SdtRole_Permission;
                  SdtRole_Permission currItemPermission;
                  short idx = 1;
                  while ( idx <= collectionPermission.Count )
                  {
                     currItemPermission = ((SdtRole_Permission)collectionPermission.Item(idx));
                     currItemPermission.gxTpr_Mode = "INS";
                     currItemPermission.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtRole_Roleid = value;
            SetDirty("Roleid");
         }

      }

      [  SoapElement( ElementName = "RoleName" )]
      [  XmlElement( ElementName = "RoleName"   )]
      public string gxTpr_Rolename
      {
         get {
            return gxTv_SdtRole_Rolename ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Rolename = value;
            SetDirty("Rolename");
         }

      }

      [  SoapElement( ElementName = "Permission" )]
      [  XmlArray( ElementName = "Permission"  )]
      [  XmlArrayItemAttribute( ElementName= "Role.Permission"  , IsNullable=false)]
      public GXBCLevelCollection<SdtRole_Permission> gxTpr_Permission_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtRole_Permission == null )
            {
               gxTv_SdtRole_Permission = new GXBCLevelCollection<SdtRole_Permission>( context, "Role.Permission", "mtaKB");
            }
            return gxTv_SdtRole_Permission ;
         }

         set {
            if ( gxTv_SdtRole_Permission == null )
            {
               gxTv_SdtRole_Permission = new GXBCLevelCollection<SdtRole_Permission>( context, "Role.Permission", "mtaKB");
            }
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Permission = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtRole_Permission> gxTpr_Permission
      {
         get {
            if ( gxTv_SdtRole_Permission == null )
            {
               gxTv_SdtRole_Permission = new GXBCLevelCollection<SdtRole_Permission>( context, "Role.Permission", "mtaKB");
            }
            gxTv_SdtRole_N = 0;
            return gxTv_SdtRole_Permission ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Permission = value;
            SetDirty("Permission");
         }

      }

      public void gxTv_SdtRole_Permission_SetNull( )
      {
         gxTv_SdtRole_Permission = null;
         SetDirty("Permission");
         return  ;
      }

      public bool gxTv_SdtRole_Permission_IsNull( )
      {
         if ( gxTv_SdtRole_Permission == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRole_Mode ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRole_Mode_SetNull( )
      {
         gxTv_SdtRole_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRole_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRole_Initialized ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRole_Initialized_SetNull( )
      {
         gxTv_SdtRole_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRole_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleId_Z" )]
      [  XmlElement( ElementName = "RoleId_Z"   )]
      public int gxTpr_Roleid_Z
      {
         get {
            return gxTv_SdtRole_Roleid_Z ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Roleid_Z = value;
            SetDirty("Roleid_Z");
         }

      }

      public void gxTv_SdtRole_Roleid_Z_SetNull( )
      {
         gxTv_SdtRole_Roleid_Z = 0;
         SetDirty("Roleid_Z");
         return  ;
      }

      public bool gxTv_SdtRole_Roleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleName_Z" )]
      [  XmlElement( ElementName = "RoleName_Z"   )]
      public string gxTpr_Rolename_Z
      {
         get {
            return gxTv_SdtRole_Rolename_Z ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Rolename_Z = value;
            SetDirty("Rolename_Z");
         }

      }

      public void gxTv_SdtRole_Rolename_Z_SetNull( )
      {
         gxTv_SdtRole_Rolename_Z = "";
         SetDirty("Rolename_Z");
         return  ;
      }

      public bool gxTv_SdtRole_Rolename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RoleId_N" )]
      [  XmlElement( ElementName = "RoleId_N"   )]
      public short gxTpr_Roleid_N
      {
         get {
            return gxTv_SdtRole_Roleid_N ;
         }

         set {
            gxTv_SdtRole_N = 0;
            gxTv_SdtRole_Roleid_N = value;
            SetDirty("Roleid_N");
         }

      }

      public void gxTv_SdtRole_Roleid_N_SetNull( )
      {
         gxTv_SdtRole_Roleid_N = 0;
         SetDirty("Roleid_N");
         return  ;
      }

      public bool gxTv_SdtRole_Roleid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRole_N = 1;
         gxTv_SdtRole_Rolename = "";
         gxTv_SdtRole_Mode = "";
         gxTv_SdtRole_Rolename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "role", "GeneXus.Programs.role_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRole_N ;
      }

      private short gxTv_SdtRole_N ;
      private short gxTv_SdtRole_Initialized ;
      private short gxTv_SdtRole_Roleid_N ;
      private int gxTv_SdtRole_Roleid ;
      private int gxTv_SdtRole_Roleid_Z ;
      private string gxTv_SdtRole_Mode ;
      private string gxTv_SdtRole_Rolename ;
      private string gxTv_SdtRole_Rolename_Z ;
      private GXBCLevelCollection<SdtRole_Permission> gxTv_SdtRole_Permission=null ;
   }

   [DataContract(Name = @"Role", Namespace = "mtaKB")]
   public class SdtRole_RESTInterface : GxGenericCollectionItem<SdtRole>
   {
      public SdtRole_RESTInterface( ) : base()
      {
      }

      public SdtRole_RESTInterface( SdtRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RoleId" , Order = 0 )]
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

      [DataMember( Name = "RoleName" , Order = 1 )]
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

      [DataMember( Name = "Permission" , Order = 2 )]
      public GxGenericCollection<SdtRole_Permission_RESTInterface> gxTpr_Permission
      {
         get {
            return new GxGenericCollection<SdtRole_Permission_RESTInterface>(sdt.gxTpr_Permission) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Permission);
         }

      }

      public SdtRole sdt
      {
         get {
            return (SdtRole)Sdt ;
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
            sdt = new SdtRole() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Role", Namespace = "mtaKB")]
   public class SdtRole_RESTLInterface : GxGenericCollectionItem<SdtRole>
   {
      public SdtRole_RESTLInterface( ) : base()
      {
      }

      public SdtRole_RESTLInterface( SdtRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RoleName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtRole sdt
      {
         get {
            return (SdtRole)Sdt ;
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
            sdt = new SdtRole() ;
         }
      }

   }

}
