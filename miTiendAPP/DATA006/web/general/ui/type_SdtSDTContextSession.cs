/*
				   File: type_SdtSDTContextSession
			Description: SDTContextSession
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

using GeneXus.Programs;
using GeneXus.Programs.general;
namespace GeneXus.Programs.general.ui
{
	[XmlRoot(ElementName="SDTContextSession")]
	[XmlType(TypeName="SDTContextSession" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTContextSession : GxUserType
	{
		public SdtSDTContextSession( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTContextSession_Username = "";

		}

		public SdtSDTContextSession(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="UserId")]
		[XmlElement(ElementName="UserId")]
		public int gxTpr_Userid
		{
			get {
				return gxTv_SdtSDTContextSession_Userid; 
			}
			set {
				gxTv_SdtSDTContextSession_Userid = value;
				SetDirty("Userid");
			}
		}




		[SoapElement(ElementName="UserName")]
		[XmlElement(ElementName="UserName")]
		public string gxTpr_Username
		{
			get {
				return gxTv_SdtSDTContextSession_Username; 
			}
			set {
				gxTv_SdtSDTContextSession_Username = value;
				SetDirty("Username");
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
			gxTv_SdtSDTContextSession_Username = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTContextSession_Userid;
		 

		protected string gxTv_SdtSDTContextSession_Username;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTContextSession", Namespace="mtaKB")]
	public class SdtSDTContextSession_RESTInterface : GxGenericCollectionItem<SdtSDTContextSession>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTContextSession_RESTInterface( ) : base()
		{	
		}

		public SdtSDTContextSession_RESTInterface( SdtSDTContextSession psdt ) : base(psdt)
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


		#endregion

		public SdtSDTContextSession sdt
		{
			get { 
				return (SdtSDTContextSession)Sdt;
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
				sdt = new SdtSDTContextSession() ;
			}
		}
	}
	#endregion
}