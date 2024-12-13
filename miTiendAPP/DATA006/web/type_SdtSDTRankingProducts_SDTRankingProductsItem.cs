/*
				   File: type_SdtSDTRankingProducts_SDTRankingProductsItem
			Description: SDTRankingProducts
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
	[XmlRoot(ElementName="SDTRankingProductsItem")]
	[XmlType(TypeName="SDTRankingProductsItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTRankingProducts_SDTRankingProductsItem : GxUserType
	{
		public SdtSDTRankingProducts_SDTRankingProductsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Name = "";

			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Supplier = "";

			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Sector = "";

			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Brand = "";

		}

		public SdtSDTRankingProducts_SDTRankingProductsItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Price", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Price, 18, 2)), false);


			AddObjectProperty("Stock", gxTpr_Stock, false);


			AddObjectProperty("Supplier", gxTpr_Supplier, false);


			AddObjectProperty("Sector", gxTpr_Sector, false);


			AddObjectProperty("Brand", gxTpr_Brand, false);


			AddObjectProperty("QuantitySales", gxTpr_Quantitysales, false);


			AddObjectProperty("QuantityUnitsSale", gxTpr_Quantityunitssale, false);


			AddObjectProperty("Subtotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Subtotal, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Name; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Id; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Id = value;
				SetDirty("Id");
			}
		}



		[SoapElement(ElementName="Price")]
		[XmlElement(ElementName="Price")]
		public string gxTpr_Price_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Price, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Price = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Price
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Price; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Price = value;
				SetDirty("Price");
			}
		}




		[SoapElement(ElementName="Stock")]
		[XmlElement(ElementName="Stock")]
		public int gxTpr_Stock
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Stock; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Stock = value;
				SetDirty("Stock");
			}
		}




		[SoapElement(ElementName="Supplier")]
		[XmlElement(ElementName="Supplier")]
		public string gxTpr_Supplier
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Supplier; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Supplier = value;
				SetDirty("Supplier");
			}
		}




		[SoapElement(ElementName="Sector")]
		[XmlElement(ElementName="Sector")]
		public string gxTpr_Sector
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Sector; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Sector = value;
				SetDirty("Sector");
			}
		}




		[SoapElement(ElementName="Brand")]
		[XmlElement(ElementName="Brand")]
		public string gxTpr_Brand
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Brand; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Brand = value;
				SetDirty("Brand");
			}
		}




		[SoapElement(ElementName="QuantitySales")]
		[XmlElement(ElementName="QuantitySales")]
		public int gxTpr_Quantitysales
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantitysales; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantitysales = value;
				SetDirty("Quantitysales");
			}
		}




		[SoapElement(ElementName="QuantityUnitsSale")]
		[XmlElement(ElementName="QuantityUnitsSale")]
		public int gxTpr_Quantityunitssale
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantityunitssale; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantityunitssale = value;
				SetDirty("Quantityunitssale");
			}
		}



		[SoapElement(ElementName="Subtotal")]
		[XmlElement(ElementName="Subtotal")]
		public string gxTpr_Subtotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Subtotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Subtotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Subtotal
		{
			get {
				return gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Subtotal; 
			}
			set {
				gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Subtotal = value;
				SetDirty("Subtotal");
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
			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Name = "";



			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Supplier = "";
			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Sector = "";
			gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Brand = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Name;
		 

		protected int gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Id;
		 

		protected decimal gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Price;
		 

		protected int gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Stock;
		 

		protected string gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Supplier;
		 

		protected string gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Sector;
		 

		protected string gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Brand;
		 

		protected int gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantitysales;
		 

		protected int gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Quantityunitssale;
		 

		protected decimal gxTv_SdtSDTRankingProducts_SDTRankingProductsItem_Subtotal;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTRankingProductsItem", Namespace="mtaKB")]
	public class SdtSDTRankingProducts_SDTRankingProductsItem_RESTInterface : GxGenericCollectionItem<SdtSDTRankingProducts_SDTRankingProductsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRankingProducts_SDTRankingProductsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRankingProducts_SDTRankingProductsItem_RESTInterface( SdtSDTRankingProducts_SDTRankingProductsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Id", Order=1)]
		public int gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Price", Order=2)]
		public  string gxTpr_Price
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Price, 18, 2));

			}
			set { 
				sdt.gxTpr_Price =  NumberUtil.Val( value, ".");
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

		[DataMember(Name="Supplier", Order=4)]
		public  string gxTpr_Supplier
		{
			get { 
				return sdt.gxTpr_Supplier;

			}
			set { 
				 sdt.gxTpr_Supplier = value;
			}
		}

		[DataMember(Name="Sector", Order=5)]
		public  string gxTpr_Sector
		{
			get { 
				return sdt.gxTpr_Sector;

			}
			set { 
				 sdt.gxTpr_Sector = value;
			}
		}

		[DataMember(Name="Brand", Order=6)]
		public  string gxTpr_Brand
		{
			get { 
				return sdt.gxTpr_Brand;

			}
			set { 
				 sdt.gxTpr_Brand = value;
			}
		}

		[DataMember(Name="QuantitySales", Order=7)]
		public int gxTpr_Quantitysales
		{
			get { 
				return sdt.gxTpr_Quantitysales;

			}
			set { 
				sdt.gxTpr_Quantitysales = value;
			}
		}

		[DataMember(Name="QuantityUnitsSale", Order=8)]
		public int gxTpr_Quantityunitssale
		{
			get { 
				return sdt.gxTpr_Quantityunitssale;

			}
			set { 
				sdt.gxTpr_Quantityunitssale = value;
			}
		}

		[DataMember(Name="Subtotal", Order=9)]
		public  string gxTpr_Subtotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Subtotal, 18, 2));

			}
			set { 
				sdt.gxTpr_Subtotal =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTRankingProducts_SDTRankingProductsItem sdt
		{
			get { 
				return (SdtSDTRankingProducts_SDTRankingProductsItem)Sdt;
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
				sdt = new SdtSDTRankingProducts_SDTRankingProductsItem() ;
			}
		}
	}
	#endregion
}