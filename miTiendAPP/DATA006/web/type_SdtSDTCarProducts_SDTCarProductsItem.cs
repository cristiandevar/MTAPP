/*
				   File: type_SdtSDTCarProducts_SDTCarProductsItem
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
	[XmlRoot(ElementName="SDTCarProductsItem")]
	[XmlType(TypeName="SDTCarProductsItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTCarProducts_SDTCarProductsItem : GxUserType
	{
		public SdtSDTCarProducts_SDTCarProductsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCarProducts_SDTCarProductsItem_Code = "";

			gxTv_SdtSDTCarProducts_SDTCarProductsItem_Name = "";

		}

		public SdtSDTCarProducts_SDTCarProductsItem(IGxContext context)
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


			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Stock", gxTpr_Stock, false);


			AddObjectProperty("Quantity", gxTpr_Quantity, false);


			AddObjectProperty("UnitPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Unitprice, 18, 2)), false);


			AddObjectProperty("Subtotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Subtotal, 18, 2)), false);


			AddObjectProperty("RetailPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Retailprice, 18, 2)), false);


			AddObjectProperty("WholesalePrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Wholesaleprice, 18, 2)), false);


			AddObjectProperty("ProductMiniumQuantityWholesale", gxTpr_Productminiumquantitywholesale, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Id; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Code; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Name; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Stock")]
		[XmlElement(ElementName="Stock")]
		public int gxTpr_Stock
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Stock; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Stock = value;
				SetDirty("Stock");
			}
		}




		[SoapElement(ElementName="Quantity")]
		[XmlElement(ElementName="Quantity")]
		public int gxTpr_Quantity
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Quantity; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Quantity = value;
				SetDirty("Quantity");
			}
		}



		[SoapElement(ElementName="UnitPrice")]
		[XmlElement(ElementName="UnitPrice")]
		public string gxTpr_Unitprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarProducts_SDTCarProductsItem_Unitprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Unitprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Unitprice
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Unitprice; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Unitprice = value;
				SetDirty("Unitprice");
			}
		}



		[SoapElement(ElementName="Subtotal")]
		[XmlElement(ElementName="Subtotal")]
		public string gxTpr_Subtotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarProducts_SDTCarProductsItem_Subtotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Subtotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Subtotal
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Subtotal; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Subtotal = value;
				SetDirty("Subtotal");
			}
		}



		[SoapElement(ElementName="RetailPrice")]
		[XmlElement(ElementName="RetailPrice")]
		public string gxTpr_Retailprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarProducts_SDTCarProductsItem_Retailprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Retailprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Retailprice
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Retailprice; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Retailprice = value;
				SetDirty("Retailprice");
			}
		}



		[SoapElement(ElementName="WholesalePrice")]
		[XmlElement(ElementName="WholesalePrice")]
		public string gxTpr_Wholesaleprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTCarProducts_SDTCarProductsItem_Wholesaleprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Wholesaleprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Wholesaleprice
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Wholesaleprice; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Wholesaleprice = value;
				SetDirty("Wholesaleprice");
			}
		}




		[SoapElement(ElementName="ProductMiniumQuantityWholesale")]
		[XmlElement(ElementName="ProductMiniumQuantityWholesale")]
		public short gxTpr_Productminiumquantitywholesale
		{
			get {
				return gxTv_SdtSDTCarProducts_SDTCarProductsItem_Productminiumquantitywholesale; 
			}
			set {
				gxTv_SdtSDTCarProducts_SDTCarProductsItem_Productminiumquantitywholesale = value;
				SetDirty("Productminiumquantitywholesale");
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
			gxTv_SdtSDTCarProducts_SDTCarProductsItem_Code = "";
			gxTv_SdtSDTCarProducts_SDTCarProductsItem_Name = "";







			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTCarProducts_SDTCarProductsItem_Id;
		 

		protected string gxTv_SdtSDTCarProducts_SDTCarProductsItem_Code;
		 

		protected string gxTv_SdtSDTCarProducts_SDTCarProductsItem_Name;
		 

		protected int gxTv_SdtSDTCarProducts_SDTCarProductsItem_Stock;
		 

		protected int gxTv_SdtSDTCarProducts_SDTCarProductsItem_Quantity;
		 

		protected decimal gxTv_SdtSDTCarProducts_SDTCarProductsItem_Unitprice;
		 

		protected decimal gxTv_SdtSDTCarProducts_SDTCarProductsItem_Subtotal;
		 

		protected decimal gxTv_SdtSDTCarProducts_SDTCarProductsItem_Retailprice;
		 

		protected decimal gxTv_SdtSDTCarProducts_SDTCarProductsItem_Wholesaleprice;
		 

		protected short gxTv_SdtSDTCarProducts_SDTCarProductsItem_Productminiumquantitywholesale;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTCarProductsItem", Namespace="mtaKB")]
	public class SdtSDTCarProducts_SDTCarProductsItem_RESTInterface : GxGenericCollectionItem<SdtSDTCarProducts_SDTCarProductsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCarProducts_SDTCarProductsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCarProducts_SDTCarProductsItem_RESTInterface( SdtSDTCarProducts_SDTCarProductsItem psdt ) : base(psdt)
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

		[DataMember(Name="Code", Order=1)]
		public  string gxTpr_Code
		{
			get { 
				return sdt.gxTpr_Code;

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Name", Order=2)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Stock", Order=3)]
		public int gxTpr_Stock
		{
			get { 
				return sdt.gxTpr_Stock;

			}
			set { 
				sdt.gxTpr_Stock = value;
			}
		}

		[DataMember(Name="Quantity", Order=4)]
		public int gxTpr_Quantity
		{
			get { 
				return sdt.gxTpr_Quantity;

			}
			set { 
				sdt.gxTpr_Quantity = value;
			}
		}

		[DataMember(Name="UnitPrice", Order=5)]
		public  string gxTpr_Unitprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Unitprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Unitprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Subtotal", Order=6)]
		public  string gxTpr_Subtotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Subtotal, 18, 2));

			}
			set { 
				sdt.gxTpr_Subtotal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RetailPrice", Order=7)]
		public  string gxTpr_Retailprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Retailprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Retailprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WholesalePrice", Order=8)]
		public  string gxTpr_Wholesaleprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Wholesaleprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Wholesaleprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductMiniumQuantityWholesale", Order=9)]
		public short gxTpr_Productminiumquantitywholesale
		{
			get { 
				return sdt.gxTpr_Productminiumquantitywholesale;

			}
			set { 
				sdt.gxTpr_Productminiumquantitywholesale = value;
			}
		}


		#endregion

		public SdtSDTCarProducts_SDTCarProductsItem sdt
		{
			get { 
				return (SdtSDTCarProducts_SDTCarProductsItem)Sdt;
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
				sdt = new SdtSDTCarProducts_SDTCarProductsItem() ;
			}
		}
	}
	#endregion
}