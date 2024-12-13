/*
				   File: type_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem
			Description: SDTProductsRankingPurchases
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
	[XmlRoot(ElementName="SDTProductsRankingPurchasesItem")]
	[XmlType(TypeName="SDTProductsRankingPurchasesItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem : GxUserType
	{
		public SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Name = "";

		}

		public SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(IGxContext context)
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


			AddObjectProperty("Price", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Price, 18, 2)), false);


			AddObjectProperty("Stock", gxTpr_Stock, false);


			AddObjectProperty("QuantityPurchases", gxTpr_Quantitypurchases, false);


			AddObjectProperty("QuantityUnitsPurchases", gxTpr_Quantityunitspurchases, false);


			AddObjectProperty("Total", gxTpr_Total, false);


			AddObjectProperty("Sector", gxTpr_Sector, false);


			AddObjectProperty("Supplier", gxTpr_Supplier, false);


			AddObjectProperty("Brand", gxTpr_Brand, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Id; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Name; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="Price")]
		[XmlElement(ElementName="Price")]
		public string gxTpr_Price_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Price, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Price = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Price
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Price; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Price = value;
				SetDirty("Price");
			}
		}




		[SoapElement(ElementName="Stock")]
		[XmlElement(ElementName="Stock")]
		public int gxTpr_Stock
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Stock; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Stock = value;
				SetDirty("Stock");
			}
		}




		[SoapElement(ElementName="QuantityPurchases")]
		[XmlElement(ElementName="QuantityPurchases")]
		public short gxTpr_Quantitypurchases
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantitypurchases; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantitypurchases = value;
				SetDirty("Quantitypurchases");
			}
		}




		[SoapElement(ElementName="QuantityUnitsPurchases")]
		[XmlElement(ElementName="QuantityUnitsPurchases")]
		public short gxTpr_Quantityunitspurchases
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantityunitspurchases; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantityunitspurchases = value;
				SetDirty("Quantityunitspurchases");
			}
		}



		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public string gxTpr_Total_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Total, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Total = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Total
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Total; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="Sector")]
		[XmlElement(ElementName="Sector")]
		public int gxTpr_Sector
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Sector; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Sector = value;
				SetDirty("Sector");
			}
		}




		[SoapElement(ElementName="Supplier")]
		[XmlElement(ElementName="Supplier")]
		public int gxTpr_Supplier
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Supplier; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Supplier = value;
				SetDirty("Supplier");
			}
		}




		[SoapElement(ElementName="Brand")]
		[XmlElement(ElementName="Brand")]
		public int gxTpr_Brand
		{
			get {
				return gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Brand; 
			}
			set {
				gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Brand = value;
				SetDirty("Brand");
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
			gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Name = "";








			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Id;
		 

		protected string gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Name;
		 

		protected decimal gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Price;
		 

		protected int gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Stock;
		 

		protected short gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantitypurchases;
		 

		protected short gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Quantityunitspurchases;
		 

		protected decimal gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Total;
		 

		protected int gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Sector;
		 

		protected int gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Supplier;
		 

		protected int gxTv_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_Brand;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTProductsRankingPurchasesItem", Namespace="mtaKB")]
	public class SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_RESTInterface : GxGenericCollectionItem<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem_RESTInterface( SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem psdt ) : base(psdt)
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

		[DataMember(Name="QuantityPurchases", Order=4)]
		public short gxTpr_Quantitypurchases
		{
			get { 
				return sdt.gxTpr_Quantitypurchases;

			}
			set { 
				sdt.gxTpr_Quantitypurchases = value;
			}
		}

		[DataMember(Name="QuantityUnitsPurchases", Order=5)]
		public short gxTpr_Quantityunitspurchases
		{
			get { 
				return sdt.gxTpr_Quantityunitspurchases;

			}
			set { 
				sdt.gxTpr_Quantityunitspurchases = value;
			}
		}

		[DataMember(Name="Total", Order=6)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Total, 10, 2));

			}
			set { 
				sdt.gxTpr_Total =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Sector", Order=7)]
		public int gxTpr_Sector
		{
			get { 
				return sdt.gxTpr_Sector;

			}
			set { 
				sdt.gxTpr_Sector = value;
			}
		}

		[DataMember(Name="Supplier", Order=8)]
		public int gxTpr_Supplier
		{
			get { 
				return sdt.gxTpr_Supplier;

			}
			set { 
				sdt.gxTpr_Supplier = value;
			}
		}

		[DataMember(Name="Brand", Order=9)]
		public int gxTpr_Brand
		{
			get { 
				return sdt.gxTpr_Brand;

			}
			set { 
				sdt.gxTpr_Brand = value;
			}
		}


		#endregion

		public SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem sdt
		{
			get { 
				return (SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)Sdt;
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
				sdt = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem() ;
			}
		}
	}
	#endregion
}