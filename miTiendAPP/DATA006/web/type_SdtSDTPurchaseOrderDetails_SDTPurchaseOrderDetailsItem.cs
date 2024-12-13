/*
				   File: type_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem
			Description: SDTPurchaseOrderDetails
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
	[XmlRoot(ElementName="SDTPurchaseOrderDetailsItem")]
	[XmlType(TypeName="SDTPurchaseOrderDetailsItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem : GxUserType
	{
		public SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Code = "";

			gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Name = "";

		}

		public SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(IGxContext context)
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


			AddObjectProperty("CurrentStock", gxTpr_Currentstock, false);


			AddObjectProperty("MiniumStock", gxTpr_Miniumstock, false);


			AddObjectProperty("QuantityOrdered", gxTpr_Quantityordered, false);


			AddObjectProperty("QuantityReceived", gxTpr_Quantityreceived, false);


			AddObjectProperty("ProductCostPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productcostprice, 18, 2)), false);


			AddObjectProperty("NewCostPrice", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Newcostprice, 18, 2)), false);


			AddObjectProperty("Subtotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Subtotal, 18, 2)), false);


			AddObjectProperty("PurchaseOrderDetailId", gxTpr_Purchaseorderdetailid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public int gxTpr_Id
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Id; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Code; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Name; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="CurrentStock")]
		[XmlElement(ElementName="CurrentStock")]
		public int gxTpr_Currentstock
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Currentstock; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Currentstock = value;
				SetDirty("Currentstock");
			}
		}




		[SoapElement(ElementName="MiniumStock")]
		[XmlElement(ElementName="MiniumStock")]
		public int gxTpr_Miniumstock
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Miniumstock; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Miniumstock = value;
				SetDirty("Miniumstock");
			}
		}




		[SoapElement(ElementName="QuantityOrdered")]
		[XmlElement(ElementName="QuantityOrdered")]
		public int gxTpr_Quantityordered
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityordered; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityordered = value;
				SetDirty("Quantityordered");
			}
		}




		[SoapElement(ElementName="QuantityReceived")]
		[XmlElement(ElementName="QuantityReceived")]
		public int gxTpr_Quantityreceived
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityreceived; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityreceived = value;
				SetDirty("Quantityreceived");
			}
		}



		[SoapElement(ElementName="ProductCostPrice")]
		[XmlElement(ElementName="ProductCostPrice")]
		public string gxTpr_Productcostprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Productcostprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Productcostprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Productcostprice
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Productcostprice; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Productcostprice = value;
				SetDirty("Productcostprice");
			}
		}



		[SoapElement(ElementName="NewCostPrice")]
		[XmlElement(ElementName="NewCostPrice")]
		public string gxTpr_Newcostprice_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Newcostprice, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Newcostprice = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Newcostprice
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Newcostprice; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Newcostprice = value;
				SetDirty("Newcostprice");
			}
		}



		[SoapElement(ElementName="Subtotal")]
		[XmlElement(ElementName="Subtotal")]
		public string gxTpr_Subtotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Subtotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Subtotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Subtotal
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Subtotal; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Subtotal = value;
				SetDirty("Subtotal");
			}
		}




		[SoapElement(ElementName="PurchaseOrderDetailId")]
		[XmlElement(ElementName="PurchaseOrderDetailId")]
		public int gxTpr_Purchaseorderdetailid
		{
			get {
				return gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Purchaseorderdetailid; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Purchaseorderdetailid = value;
				SetDirty("Purchaseorderdetailid");
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
			gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Code = "";
			gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Name = "";








			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Id;
		 

		protected string gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Code;
		 

		protected string gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Name;
		 

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Currentstock;
		 

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Miniumstock;
		 

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityordered;
		 

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Quantityreceived;
		 

		protected decimal gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Productcostprice;
		 

		protected decimal gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Newcostprice;
		 

		protected decimal gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Subtotal;
		 

		protected int gxTv_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_Purchaseorderdetailid;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTPurchaseOrderDetailsItem", Namespace="mtaKB")]
	public class SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_RESTInterface : GxGenericCollectionItem<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem_RESTInterface( SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem psdt ) : base(psdt)
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

		[DataMember(Name="CurrentStock", Order=3)]
		public int gxTpr_Currentstock
		{
			get { 
				return sdt.gxTpr_Currentstock;

			}
			set { 
				sdt.gxTpr_Currentstock = value;
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

		[DataMember(Name="QuantityOrdered", Order=5)]
		public int gxTpr_Quantityordered
		{
			get { 
				return sdt.gxTpr_Quantityordered;

			}
			set { 
				sdt.gxTpr_Quantityordered = value;
			}
		}

		[DataMember(Name="QuantityReceived", Order=6)]
		public int gxTpr_Quantityreceived
		{
			get { 
				return sdt.gxTpr_Quantityreceived;

			}
			set { 
				sdt.gxTpr_Quantityreceived = value;
			}
		}

		[DataMember(Name="ProductCostPrice", Order=7)]
		public  string gxTpr_Productcostprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Productcostprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Productcostprice =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NewCostPrice", Order=8)]
		public  string gxTpr_Newcostprice
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Newcostprice, 18, 2));

			}
			set { 
				sdt.gxTpr_Newcostprice =  NumberUtil.Val( value, ".");
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

		[DataMember(Name="PurchaseOrderDetailId", Order=10)]
		public int gxTpr_Purchaseorderdetailid
		{
			get { 
				return sdt.gxTpr_Purchaseorderdetailid;

			}
			set { 
				sdt.gxTpr_Purchaseorderdetailid = value;
			}
		}


		#endregion

		public SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem sdt
		{
			get { 
				return (SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)Sdt;
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
				sdt = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem() ;
			}
		}
	}
	#endregion
}