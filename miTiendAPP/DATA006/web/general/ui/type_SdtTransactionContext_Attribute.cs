/*
				   File: type_SdtTransactionContext_Attribute
			Description: Attributes
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
	[XmlRoot(ElementName="TransactionContext.Attribute")]
	[XmlType(TypeName="TransactionContext.Attribute" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtTransactionContext_Attribute : GxUserType
	{
		public SdtTransactionContext_Attribute( )
		{
			/* Constructor for serialization */
			gxTv_SdtTransactionContext_Attribute_Attributename = "";

			gxTv_SdtTransactionContext_Attribute_Attributevalue = "";

		}

		public SdtTransactionContext_Attribute(IGxContext context)
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
			AddObjectProperty("AttributeName", gxTpr_Attributename, false);


			AddObjectProperty("AttributeValue", gxTpr_Attributevalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AttributeName")]
		[XmlElement(ElementName="AttributeName")]
		public string gxTpr_Attributename
		{
			get {
				return gxTv_SdtTransactionContext_Attribute_Attributename; 
			}
			set {
				gxTv_SdtTransactionContext_Attribute_Attributename = value;
				SetDirty("Attributename");
			}
		}




		[SoapElement(ElementName="AttributeValue")]
		[XmlElement(ElementName="AttributeValue")]
		public string gxTpr_Attributevalue
		{
			get {
				return gxTv_SdtTransactionContext_Attribute_Attributevalue; 
			}
			set {
				gxTv_SdtTransactionContext_Attribute_Attributevalue = value;
				SetDirty("Attributevalue");
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
			gxTv_SdtTransactionContext_Attribute_Attributename = "";
			gxTv_SdtTransactionContext_Attribute_Attributevalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtTransactionContext_Attribute_Attributename;
		 

		protected string gxTv_SdtTransactionContext_Attribute_Attributevalue;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TransactionContext.Attribute", Namespace="mtaKB")]
	public class SdtTransactionContext_Attribute_RESTInterface : GxGenericCollectionItem<SdtTransactionContext_Attribute>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTransactionContext_Attribute_RESTInterface( ) : base()
		{	
		}

		public SdtTransactionContext_Attribute_RESTInterface( SdtTransactionContext_Attribute psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AttributeName", Order=0)]
		public  string gxTpr_Attributename
		{
			get { 
				return sdt.gxTpr_Attributename;

			}
			set { 
				 sdt.gxTpr_Attributename = value;
			}
		}

		[DataMember(Name="AttributeValue", Order=1)]
		public  string gxTpr_Attributevalue
		{
			get { 
				return sdt.gxTpr_Attributevalue;

			}
			set { 
				 sdt.gxTpr_Attributevalue = value;
			}
		}


		#endregion

		public SdtTransactionContext_Attribute sdt
		{
			get { 
				return (SdtTransactionContext_Attribute)Sdt;
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
				sdt = new SdtTransactionContext_Attribute() ;
			}
		}
	}
	#endregion
}