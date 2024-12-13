/*
				   File: type_SdtSDTPermission_SDTPermissionItem
			Description: SDTPermission
				 Author: Nemo 🐠 for C# (.NET) version 18.0.2.169539
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDTPermissionItem")]
	[XmlType(TypeName="SDTPermissionItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTPermission_SDTPermissionItem : GxUserType
	{
		public SdtSDTPermission_SDTPermissionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPermission_SDTPermissionItem_Permissionname = "";

		}

		public SdtSDTPermission_SDTPermissionItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("PermissionId", gxTpr_Permissionid, false);


			AddObjectProperty("PermissionName", gxTpr_Permissionname, false);


			AddObjectProperty("Selected", gxTpr_Selected, false);


			AddObjectProperty("OriginalPosition", gxTpr_Originalposition, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PermissionId")]
		[XmlElement(ElementName="PermissionId")]
		public int gxTpr_Permissionid
		{
			get {
				return gxTv_SdtSDTPermission_SDTPermissionItem_Permissionid; 
			}
			set {
				gxTv_SdtSDTPermission_SDTPermissionItem_Permissionid = value;
				SetDirty("Permissionid");
			}
		}




		[SoapElement(ElementName="PermissionName")]
		[XmlElement(ElementName="PermissionName")]
		public string gxTpr_Permissionname
		{
			get {
				return gxTv_SdtSDTPermission_SDTPermissionItem_Permissionname; 
			}
			set {
				gxTv_SdtSDTPermission_SDTPermissionItem_Permissionname = value;
				SetDirty("Permissionname");
			}
		}




		[SoapElement(ElementName="Selected")]
		[XmlElement(ElementName="Selected")]
		public bool gxTpr_Selected
		{
			get {
				return gxTv_SdtSDTPermission_SDTPermissionItem_Selected; 
			}
			set {
				gxTv_SdtSDTPermission_SDTPermissionItem_Selected = value;
				SetDirty("Selected");
			}
		}




		[SoapElement(ElementName="OriginalPosition")]
		[XmlElement(ElementName="OriginalPosition")]
		public short gxTpr_Originalposition
		{
			get {
				return gxTv_SdtSDTPermission_SDTPermissionItem_Originalposition; 
			}
			set {
				gxTv_SdtSDTPermission_SDTPermissionItem_Originalposition = value;
				SetDirty("Originalposition");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTPermission_SDTPermissionItem_Permissionname = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTPermission_SDTPermissionItem_Permissionid;
		 

		protected string gxTv_SdtSDTPermission_SDTPermissionItem_Permissionname;
		 

		protected bool gxTv_SdtSDTPermission_SDTPermissionItem_Selected;
		 

		protected short gxTv_SdtSDTPermission_SDTPermissionItem_Originalposition;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTPermissionItem", Namespace="mtaKB")]
	public class SdtSDTPermission_SDTPermissionItem_RESTInterface : GxGenericCollectionItem<SdtSDTPermission_SDTPermissionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPermission_SDTPermissionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPermission_SDTPermissionItem_RESTInterface( SdtSDTPermission_SDTPermissionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PermissionId", Order=0)]
		public int gxTpr_Permissionid
		{
			get { 
				return sdt.gxTpr_Permissionid;

			}
			set { 
				sdt.gxTpr_Permissionid = value;
			}
		}

		[DataMember(Name="PermissionName", Order=1)]
		public  string gxTpr_Permissionname
		{
			get { 
				return sdt.gxTpr_Permissionname;

			}
			set { 
				 sdt.gxTpr_Permissionname = value;
			}
		}

		[DataMember(Name="Selected", Order=2)]
		public bool gxTpr_Selected
		{
			get { 
				return sdt.gxTpr_Selected;

			}
			set { 
				sdt.gxTpr_Selected = value;
			}
		}

		[DataMember(Name="OriginalPosition", Order=3)]
		public short gxTpr_Originalposition
		{
			get { 
				return sdt.gxTpr_Originalposition;

			}
			set { 
				sdt.gxTpr_Originalposition = value;
			}
		}


		#endregion

		public SdtSDTPermission_SDTPermissionItem sdt
		{
			get { 
				return (SdtSDTPermission_SDTPermissionItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTPermission_SDTPermissionItem() ;
			}
		}
	}
	#endregion
}