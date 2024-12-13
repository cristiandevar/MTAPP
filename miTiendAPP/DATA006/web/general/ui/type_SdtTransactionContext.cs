/*
				   File: type_SdtTransactionContext
			Description: TransactionContext
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
	[XmlRoot(ElementName="TransactionContext")]
	[XmlType(TypeName="TransactionContext" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtTransactionContext : GxUserType
	{
		public SdtTransactionContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtTransactionContext_Callerobject = "";

			gxTv_SdtTransactionContext_Callerurl = "";

			gxTv_SdtTransactionContext_Transactionname = "";

		}

		public SdtTransactionContext(IGxContext context)
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
			AddObjectProperty("CallerObject", gxTpr_Callerobject, false);


			AddObjectProperty("CallerOnDelete", gxTpr_Callerondelete, false);


			AddObjectProperty("CallerURL", gxTpr_Callerurl, false);


			AddObjectProperty("TransactionName", gxTpr_Transactionname, false);

			if (gxTv_SdtTransactionContext_Attributes != null)
			{
				AddObjectProperty("Attributes", gxTv_SdtTransactionContext_Attributes, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CallerObject")]
		[XmlElement(ElementName="CallerObject")]
		public string gxTpr_Callerobject
		{
			get {
				return gxTv_SdtTransactionContext_Callerobject; 
			}
			set {
				gxTv_SdtTransactionContext_Callerobject = value;
				SetDirty("Callerobject");
			}
		}




		[SoapElement(ElementName="CallerOnDelete")]
		[XmlElement(ElementName="CallerOnDelete")]
		public bool gxTpr_Callerondelete
		{
			get {
				return gxTv_SdtTransactionContext_Callerondelete; 
			}
			set {
				gxTv_SdtTransactionContext_Callerondelete = value;
				SetDirty("Callerondelete");
			}
		}




		[SoapElement(ElementName="CallerURL")]
		[XmlElement(ElementName="CallerURL")]
		public string gxTpr_Callerurl
		{
			get {
				return gxTv_SdtTransactionContext_Callerurl; 
			}
			set {
				gxTv_SdtTransactionContext_Callerurl = value;
				SetDirty("Callerurl");
			}
		}




		[SoapElement(ElementName="TransactionName")]
		[XmlElement(ElementName="TransactionName")]
		public string gxTpr_Transactionname
		{
			get {
				return gxTv_SdtTransactionContext_Transactionname; 
			}
			set {
				gxTv_SdtTransactionContext_Transactionname = value;
				SetDirty("Transactionname");
			}
		}




		[SoapElement(ElementName="Attributes" )]
		[XmlArray(ElementName="Attributes"  )]
		[XmlArrayItemAttribute(ElementName="Attribute" , IsNullable=false )]
		public GXBaseCollection<SdtTransactionContext_Attribute> gxTpr_Attributes
		{
			get {
				if ( gxTv_SdtTransactionContext_Attributes == null )
				{
					gxTv_SdtTransactionContext_Attributes = new GXBaseCollection<SdtTransactionContext_Attribute>( context, "TransactionContext.Attribute", "");
				}
				return gxTv_SdtTransactionContext_Attributes;
			}
			set {
				gxTv_SdtTransactionContext_Attributes_N = false;
				gxTv_SdtTransactionContext_Attributes = value;
				SetDirty("Attributes");
			}
		}

		public void gxTv_SdtTransactionContext_Attributes_SetNull()
		{
			gxTv_SdtTransactionContext_Attributes_N = true;
			gxTv_SdtTransactionContext_Attributes = null;
		}

		public bool gxTv_SdtTransactionContext_Attributes_IsNull()
		{
			return gxTv_SdtTransactionContext_Attributes == null;
		}
		public bool ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json()
		{
			return gxTv_SdtTransactionContext_Attributes != null && gxTv_SdtTransactionContext_Attributes.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTransactionContext_Callerobject = "";

			gxTv_SdtTransactionContext_Callerurl = "";
			gxTv_SdtTransactionContext_Transactionname = "";

			gxTv_SdtTransactionContext_Attributes_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtTransactionContext_Callerobject;
		 

		protected bool gxTv_SdtTransactionContext_Callerondelete;
		 

		protected string gxTv_SdtTransactionContext_Callerurl;
		 

		protected string gxTv_SdtTransactionContext_Transactionname;
		 
		protected bool gxTv_SdtTransactionContext_Attributes_N;
		protected GXBaseCollection<SdtTransactionContext_Attribute> gxTv_SdtTransactionContext_Attributes = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"TransactionContext", Namespace="mtaKB")]
	public class SdtTransactionContext_RESTInterface : GxGenericCollectionItem<SdtTransactionContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTransactionContext_RESTInterface( ) : base()
		{	
		}

		public SdtTransactionContext_RESTInterface( SdtTransactionContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CallerObject", Order=0)]
		public  string gxTpr_Callerobject
		{
			get { 
				return sdt.gxTpr_Callerobject;

			}
			set { 
				 sdt.gxTpr_Callerobject = value;
			}
		}

		[DataMember(Name="CallerOnDelete", Order=1)]
		public bool gxTpr_Callerondelete
		{
			get { 
				return sdt.gxTpr_Callerondelete;

			}
			set { 
				sdt.gxTpr_Callerondelete = value;
			}
		}

		[DataMember(Name="CallerURL", Order=2)]
		public  string gxTpr_Callerurl
		{
			get { 
				return sdt.gxTpr_Callerurl;

			}
			set { 
				 sdt.gxTpr_Callerurl = value;
			}
		}

		[DataMember(Name="TransactionName", Order=3)]
		public  string gxTpr_Transactionname
		{
			get { 
				return sdt.gxTpr_Transactionname;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="Attributes", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtTransactionContext_Attribute_RESTInterface> gxTpr_Attributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtTransactionContext_Attribute_RESTInterface>(sdt.gxTpr_Attributes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attributes);
			}
		}


		#endregion

		public SdtTransactionContext sdt
		{
			get { 
				return (SdtTransactionContext)Sdt;
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
				sdt = new SdtTransactionContext() ;
			}
		}
	}
	#endregion
}