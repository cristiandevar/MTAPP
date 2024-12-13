/*
				   File: type_SdtSDTCarProducts
			Description: SDTCarProducts
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
	[XmlRoot(ElementName="SDTCarProducts")]
	[XmlType(TypeName="SDTCarProducts" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTCarProducts : GxUserType
	{
		public SdtSDTCarProducts( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCarProducts_Name = "";

		}

		public SdtSDTCarProducts(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Quantity", gxTpr_Quantity, false);


			AddObjectProperty("UnitPrice", gxTpr_Unitprice, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTCarProducts_Id; 
			}
			set {
				gxTv_SdtSDTCarProducts_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTCarProducts_Name; 
			}
			set {
				gxTv_SdtSDTCarProducts_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Quantity")]
		[XmlElement(ElementName="Quantity")]
		public int gxTpr_Quantity
		{
			get {
				return gxTv_SdtSDTCarProducts_Quantity; 
			}
			set {
				gxTv_SdtSDTCarProducts_Quantity = value;
				SetDirty("Quantity");
			}
		}



		[SoapElement(ElementName="UnitPrice")]
		[XmlElement(ElementName="UnitPrice")]
		public string gxTpr_Unitprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarProducts_Unitprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarProducts_Unitprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Unitprice
		{
			get {
				return gxTv_SdtSDTCarProducts_Unitprice; 
			}
			set {
				gxTv_SdtSDTCarProducts_Unitprice = value;
				SetDirty("Unitprice");
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
			gxTv_SdtSDTCarProducts_Name = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTCarProducts_Id;
		 

		protected string gxTv_SdtSDTCarProducts_Name;
		 

		protected int gxTv_SdtSDTCarProducts_Quantity;
		 

		protected decimal gxTv_SdtSDTCarProducts_Unitprice;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"SDTCarProducts", Namespace="mtaKB")]
	public class SdtSDTCarProducts_RESTInterface : GxGenericCollectionItem<SdtSDTCarProducts>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCarProducts_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCarProducts_RESTInterface( SdtSDTCarProducts psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public int gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Quantity", Order=2)]
		public int gxTpr_Quantity
		{
			get { 
				return sdt.gxTpr_Quantity;

			}
			set { 
				sdt.gxTpr_Quantity = value;
			}
		}

		[DataMember(Name="UnitPrice", Order=3)]
		public  string gxTpr_Unitprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Unitprice, 10, 2));

			}
			set { 
				sdt.gxTpr_Unitprice =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTCarProducts sdt
		{
			get { 
				return (SdtSDTCarProducts)Sdt;
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
				sdt = new SdtSDTCarProducts() ;
			}
		}
	}
	#endregion
}