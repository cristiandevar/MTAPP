/*
				   File: type_SdtSDTProductsFiltered_SDTProductsFilteredItem
			Description: SDTProductsFiltered
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
	[XmlRoot(ElementName="SDTProductsFilteredItem")]
	[XmlType(TypeName="SDTProductsFilteredItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTProductsFiltered_SDTProductsFilteredItem : GxUserType
	{
		public SdtSDTProductsFiltered_SDTProductsFilteredItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Code = "";

			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Name = "";

			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Supplier = "";

			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Brand = "";

			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Sector = "";

		}

		public SdtSDTProductsFiltered_SDTProductsFilteredItem(IGxContext context)
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


			AddObjectProperty("MiniumStock", gxTpr_Miniumstock, false);


			AddObjectProperty("CostPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costprice, 18, 2)), false);


			AddObjectProperty("RetailPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Retailprice, 18, 2)), false);


			AddObjectProperty("WholesalePrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Wholesaleprice, 18, 2)), false);


			AddObjectProperty("MiniumQuantityWholesale", gxTpr_Miniumquantitywholesale, false);


			AddObjectProperty("Supplier", gxTpr_Supplier, false);


			AddObjectProperty("Brand", gxTpr_Brand, false);


			AddObjectProperty("Sector", gxTpr_Sector, false);


			AddObjectProperty("UnitPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Unitprice, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Id; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Code; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Name; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Stock")]
		[XmlElement(ElementName="Stock")]
		public int gxTpr_Stock
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Stock; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Stock = value;
				SetDirty("Stock");
			}
		}




		[SoapElement(ElementName="MiniumStock")]
		[XmlElement(ElementName="MiniumStock")]
		public int gxTpr_Miniumstock
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumstock; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumstock = value;
				SetDirty("Miniumstock");
			}
		}



		[SoapElement(ElementName="CostPrice")]
		[XmlElement(ElementName="CostPrice")]
		public string gxTpr_Costprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Costprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Costprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Costprice
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Costprice; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Costprice = value;
				SetDirty("Costprice");
			}
		}



		[SoapElement(ElementName="RetailPrice")]
		[XmlElement(ElementName="RetailPrice")]
		public string gxTpr_Retailprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Retailprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Retailprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Retailprice
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Retailprice; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Retailprice = value;
				SetDirty("Retailprice");
			}
		}



		[SoapElement(ElementName="WholesalePrice")]
		[XmlElement(ElementName="WholesalePrice")]
		public string gxTpr_Wholesaleprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Wholesaleprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Wholesaleprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Wholesaleprice
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Wholesaleprice; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Wholesaleprice = value;
				SetDirty("Wholesaleprice");
			}
		}




		[SoapElement(ElementName="MiniumQuantityWholesale")]
		[XmlElement(ElementName="MiniumQuantityWholesale")]
		public short gxTpr_Miniumquantitywholesale
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumquantitywholesale; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumquantitywholesale = value;
				SetDirty("Miniumquantitywholesale");
			}
		}




		[SoapElement(ElementName="Supplier")]
		[XmlElement(ElementName="Supplier")]
		public string gxTpr_Supplier
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Supplier; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Supplier = value;
				SetDirty("Supplier");
			}
		}




		[SoapElement(ElementName="Brand")]
		[XmlElement(ElementName="Brand")]
		public string gxTpr_Brand
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Brand; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Brand = value;
				SetDirty("Brand");
			}
		}




		[SoapElement(ElementName="Sector")]
		[XmlElement(ElementName="Sector")]
		public string gxTpr_Sector
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Sector; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Sector = value;
				SetDirty("Sector");
			}
		}



		[SoapElement(ElementName="UnitPrice")]
		[XmlElement(ElementName="UnitPrice")]
		public string gxTpr_Unitprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Unitprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Unitprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Unitprice
		{
			get {
				return gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Unitprice; 
			}
			set {
				gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Unitprice = value;
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
			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Code = "";
			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Name = "";






			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Supplier = "";
			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Brand = "";
			gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Sector = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Id;
		 

		protected string gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Code;
		 

		protected string gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Name;
		 

		protected int gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Stock;
		 

		protected int gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumstock;
		 

		protected decimal gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Costprice;
		 

		protected decimal gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Retailprice;
		 

		protected decimal gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Wholesaleprice;
		 

		protected short gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Miniumquantitywholesale;
		 

		protected string gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Supplier;
		 

		protected string gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Brand;
		 

		protected string gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Sector;
		 

		protected decimal gxTv_SdtSDTProductsFiltered_SDTProductsFilteredItem_Unitprice;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTProductsFilteredItem", Namespace="mtaKB")]
	public class SdtSDTProductsFiltered_SDTProductsFilteredItem_RESTInterface : GxGenericCollectionItem<SdtSDTProductsFiltered_SDTProductsFilteredItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProductsFiltered_SDTProductsFilteredItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProductsFiltered_SDTProductsFilteredItem_RESTInterface( SdtSDTProductsFiltered_SDTProductsFilteredItem psdt ) : base(psdt)
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

		[DataMember(Name="MiniumStock", Order=4)]
		public int gxTpr_Miniumstock
		{
			get { 
				return sdt.gxTpr_Miniumstock;

			}
			set { 
				sdt.gxTpr_Miniumstock = value;
			}
		}

		[DataMember(Name="CostPrice", Order=5)]
		public  string gxTpr_Costprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Costprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RetailPrice", Order=6)]
		public  string gxTpr_Retailprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Retailprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Retailprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WholesalePrice", Order=7)]
		public  string gxTpr_Wholesaleprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Wholesaleprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Wholesaleprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MiniumQuantityWholesale", Order=8)]
		public short gxTpr_Miniumquantitywholesale
		{
			get { 
				return sdt.gxTpr_Miniumquantitywholesale;

			}
			set { 
				sdt.gxTpr_Miniumquantitywholesale = value;
			}
		}

		[DataMember(Name="Supplier", Order=9)]
		public  string gxTpr_Supplier
		{
			get { 
				return sdt.gxTpr_Supplier;

			}
			set { 
				 sdt.gxTpr_Supplier = value;
			}
		}

		[DataMember(Name="Brand", Order=10)]
		public  string gxTpr_Brand
		{
			get { 
				return sdt.gxTpr_Brand;

			}
			set { 
				 sdt.gxTpr_Brand = value;
			}
		}

		[DataMember(Name="Sector", Order=11)]
		public  string gxTpr_Sector
		{
			get { 
				return sdt.gxTpr_Sector;

			}
			set { 
				 sdt.gxTpr_Sector = value;
			}
		}

		[DataMember(Name="UnitPrice", Order=12)]
		public  string gxTpr_Unitprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Unitprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Unitprice =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTProductsFiltered_SDTProductsFilteredItem sdt
		{
			get { 
				return (SdtSDTProductsFiltered_SDTProductsFilteredItem)Sdt;
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
				sdt = new SdtSDTProductsFiltered_SDTProductsFilteredItem() ;
			}
		}
	}
	#endregion
}