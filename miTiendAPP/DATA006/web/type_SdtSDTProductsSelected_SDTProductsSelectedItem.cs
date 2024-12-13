/*
				   File: type_SdtSDTProductsSelected_SDTProductsSelectedItem
			Description: SDTProductsSelected
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
	[XmlRoot(ElementName="SDTProductsSelectedItem")]
	[XmlType(TypeName="SDTProductsSelectedItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTProductsSelected_SDTProductsSelectedItem : GxUserType
	{
		public SdtSDTProductsSelected_SDTProductsSelectedItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Code = "";

			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Name = "";

			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Sector = "";

			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Supplier = "";

			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Brand = "";

		}

		public SdtSDTProductsSelected_SDTProductsSelectedItem(IGxContext context)
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


			AddObjectProperty("UnitPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Unitprice, 18, 2)), false);


			AddObjectProperty("NewUnitPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Newunitprice, 18, 2)), false);


			AddObjectProperty("Sector", gxTpr_Sector, false);


			AddObjectProperty("Supplier", gxTpr_Supplier, false);


			AddObjectProperty("Brand", gxTpr_Brand, false);


			AddObjectProperty("CostPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costprice, 18, 2)), false);


			AddObjectProperty("NewCostPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Newcostprice, 18, 2)), false);


			AddObjectProperty("RetailProfit", gxTpr_Retailprofit, false);


			AddObjectProperty("NewRetailProfit", gxTpr_Newretailprofit, false);


			AddObjectProperty("RetailPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Retailprice, 18, 2)), false);


			AddObjectProperty("WholesaleProfit", gxTpr_Wholesaleprofit, false);


			AddObjectProperty("NewWholeSaleProfit", gxTpr_Newwholesaleprofit, false);


			AddObjectProperty("WholesalePrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Wholesaleprice, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Id; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Code; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Name; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="UnitPrice")]
		[XmlElement(ElementName="UnitPrice")]
		public string gxTpr_Unitprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Unitprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Unitprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Unitprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Unitprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Unitprice = value;
				SetDirty("Unitprice");
			}
		}



		[SoapElement(ElementName="NewUnitPrice")]
		[XmlElement(ElementName="NewUnitPrice")]
		public string gxTpr_Newunitprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newunitprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newunitprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Newunitprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newunitprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newunitprice = value;
				SetDirty("Newunitprice");
			}
		}




		[SoapElement(ElementName="Sector")]
		[XmlElement(ElementName="Sector")]
		public string gxTpr_Sector
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Sector; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Sector = value;
				SetDirty("Sector");
			}
		}




		[SoapElement(ElementName="Supplier")]
		[XmlElement(ElementName="Supplier")]
		public string gxTpr_Supplier
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Supplier; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Supplier = value;
				SetDirty("Supplier");
			}
		}




		[SoapElement(ElementName="Brand")]
		[XmlElement(ElementName="Brand")]
		public string gxTpr_Brand
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Brand; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Brand = value;
				SetDirty("Brand");
			}
		}



		[SoapElement(ElementName="CostPrice")]
		[XmlElement(ElementName="CostPrice")]
		public string gxTpr_Costprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Costprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Costprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Costprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Costprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Costprice = value;
				SetDirty("Costprice");
			}
		}



		[SoapElement(ElementName="NewCostPrice")]
		[XmlElement(ElementName="NewCostPrice")]
		public string gxTpr_Newcostprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newcostprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newcostprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Newcostprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newcostprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newcostprice = value;
				SetDirty("Newcostprice");
			}
		}



		[SoapElement(ElementName="RetailProfit")]
		[XmlElement(ElementName="RetailProfit")]
		public string gxTpr_Retailprofit_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprofit, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprofit = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Retailprofit
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprofit; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprofit = value;
				SetDirty("Retailprofit");
			}
		}



		[SoapElement(ElementName="NewRetailProfit")]
		[XmlElement(ElementName="NewRetailProfit")]
		public string gxTpr_Newretailprofit_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newretailprofit, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newretailprofit = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Newretailprofit
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newretailprofit; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newretailprofit = value;
				SetDirty("Newretailprofit");
			}
		}



		[SoapElement(ElementName="RetailPrice")]
		[XmlElement(ElementName="RetailPrice")]
		public string gxTpr_Retailprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Retailprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprice = value;
				SetDirty("Retailprice");
			}
		}



		[SoapElement(ElementName="WholesaleProfit")]
		[XmlElement(ElementName="WholesaleProfit")]
		public string gxTpr_Wholesaleprofit_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprofit, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprofit = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Wholesaleprofit
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprofit; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprofit = value;
				SetDirty("Wholesaleprofit");
			}
		}



		[SoapElement(ElementName="NewWholeSaleProfit")]
		[XmlElement(ElementName="NewWholeSaleProfit")]
		public string gxTpr_Newwholesaleprofit_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newwholesaleprofit, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newwholesaleprofit = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Newwholesaleprofit
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newwholesaleprofit; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newwholesaleprofit = value;
				SetDirty("Newwholesaleprofit");
			}
		}



		[SoapElement(ElementName="WholesalePrice")]
		[XmlElement(ElementName="WholesalePrice")]
		public string gxTpr_Wholesaleprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Wholesaleprice
		{
			get {
				return gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprice; 
			}
			set {
				gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprice = value;
				SetDirty("Wholesaleprice");
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
			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Code = "";
			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Name = "";


			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Sector = "";
			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Supplier = "";
			gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Brand = "";








			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Id;
		 

		protected string gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Code;
		 

		protected string gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Name;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Unitprice;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newunitprice;
		 

		protected string gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Sector;
		 

		protected string gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Supplier;
		 

		protected string gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Brand;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Costprice;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newcostprice;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprofit;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newretailprofit;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Retailprice;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprofit;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Newwholesaleprofit;
		 

		protected decimal gxTv_SdtSDTProductsSelected_SDTProductsSelectedItem_Wholesaleprice;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTProductsSelectedItem", Namespace="mtaKB")]
	public class SdtSDTProductsSelected_SDTProductsSelectedItem_RESTInterface : GxGenericCollectionItem<SdtSDTProductsSelected_SDTProductsSelectedItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProductsSelected_SDTProductsSelectedItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProductsSelected_SDTProductsSelectedItem_RESTInterface( SdtSDTProductsSelected_SDTProductsSelectedItem psdt ) : base(psdt)
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

		[DataMember(Name="UnitPrice", Order=3)]
		public  string gxTpr_Unitprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Unitprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Unitprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NewUnitPrice", Order=4)]
		public  string gxTpr_Newunitprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Newunitprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Newunitprice =  NumberUtil.Val( value, ".");
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

		[DataMember(Name="Supplier", Order=6)]
		public  string gxTpr_Supplier
		{
			get { 
				return sdt.gxTpr_Supplier;

			}
			set { 
				 sdt.gxTpr_Supplier = value;
			}
		}

		[DataMember(Name="Brand", Order=7)]
		public  string gxTpr_Brand
		{
			get { 
				return sdt.gxTpr_Brand;

			}
			set { 
				 sdt.gxTpr_Brand = value;
			}
		}

		[DataMember(Name="CostPrice", Order=8)]
		public  string gxTpr_Costprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Costprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NewCostPrice", Order=9)]
		public  string gxTpr_Newcostprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Newcostprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Newcostprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RetailProfit", Order=10)]
		public  string gxTpr_Retailprofit
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Retailprofit, 7, 2));

			}
			set { 
				sdt.gxTpr_Retailprofit =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NewRetailProfit", Order=11)]
		public  string gxTpr_Newretailprofit
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Newretailprofit, 7, 2));

			}
			set { 
				sdt.gxTpr_Newretailprofit =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RetailPrice", Order=12)]
		public  string gxTpr_Retailprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Retailprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Retailprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WholesaleProfit", Order=13)]
		public  string gxTpr_Wholesaleprofit
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Wholesaleprofit, 7, 2));

			}
			set { 
				sdt.gxTpr_Wholesaleprofit =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NewWholeSaleProfit", Order=14)]
		public  string gxTpr_Newwholesaleprofit
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Newwholesaleprofit, 7, 2));

			}
			set { 
				sdt.gxTpr_Newwholesaleprofit =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WholesalePrice", Order=15)]
		public  string gxTpr_Wholesaleprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Wholesaleprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Wholesaleprice =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTProductsSelected_SDTProductsSelectedItem sdt
		{
			get { 
				return (SdtSDTProductsSelected_SDTProductsSelectedItem)Sdt;
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
				sdt = new SdtSDTProductsSelected_SDTProductsSelectedItem() ;
			}
		}
	}
	#endregion
}