/*
				   File: type_SdtSDTUser_SDTUserItem
			Description: SDTUser
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
	[XmlRoot(ElementName="SDTUserItem")]
	[XmlType(TypeName="SDTUserItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTUser_SDTUserItem : GxUserType
	{
		public SdtSDTUser_SDTUserItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTUser_SDTUserItem_Username = "";

		}

		public SdtSDTUser_SDTUserItem(IGxContext context)
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
			AddObjectProperty("UserId", gxTpr_Userid, false);


			AddObjectProperty("UserName", gxTpr_Username, false);


			AddObjectProperty("Selected", gxTpr_Selected, false);


			AddObjectProperty("OriginalPosition", gxTpr_Originalposition, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public int gxTpr_Userid
		{
			get {
				return gxTv_SdtSDTUser_SDTUserItem_Userid; 
			}
			set {
				gxTv_SdtSDTUser_SDTUserItem_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get {
				return gxTv_SdtSDTUser_SDTUserItem_Username; 
			}
			set {
				gxTv_SdtSDTUser_SDTUserItem_Username = value;
				SetDirty("Username");
			}
		}




		[SoapElement(ElementName="Selected")]
		[XmlElement(ElementName="Selected")]
		public bool gxTpr_Selected
		{
			get {
				return gxTv_SdtSDTUser_SDTUserItem_Selected; 
			}
			set {
				gxTv_SdtSDTUser_SDTUserItem_Selected = value;
				SetDirty("Selected");
			}
		}




		[SoapElement(ElementName="OriginalPosition")]
		[XmlElement(ElementName="OriginalPosition")]
		public short gxTpr_Originalposition
		{
			get {
				return gxTv_SdtSDTUser_SDTUserItem_Originalposition; 
			}
			set {
				gxTv_SdtSDTUser_SDTUserItem_Originalposition = value;
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
			gxTv_SdtSDTUser_SDTUserItem_Username = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTUser_SDTUserItem_Userid;
		 

		protected string gxTv_SdtSDTUser_SDTUserItem_Username;
		 

		protected bool gxTv_SdtSDTUser_SDTUserItem_Selected;
		 

		protected short gxTv_SdtSDTUser_SDTUserItem_Originalposition;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTUserItem", Namespace="mtaKB")]
	public class SdtSDTUser_SDTUserItem_RESTInterface : GxGenericCollectionItem<SdtSDTUser_SDTUserItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTUser_SDTUserItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTUser_SDTUserItem_RESTInterface( SdtSDTUser_SDTUserItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="UserId", Order=0)]
		public int gxTpr_Userid
		{
			get { 
				return sdt.gxTpr_Userid;

			}
			set { 
				sdt.gxTpr_Userid = value;
			}
		}

		[DataMember(Name="UserName", Order=1)]
		public  string gxTpr_Username
		{
			get { 
				return sdt.gxTpr_Username;

			}
			set { 
				 sdt.gxTpr_Username = value;
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

		public SdtSDTUser_SDTUserItem sdt
		{
			get { 
				return (SdtSDTUser_SDTUserItem)Sdt;
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
				sdt = new SdtSDTUser_SDTUserItem() ;
			}
		}
	}
	#endregion
}