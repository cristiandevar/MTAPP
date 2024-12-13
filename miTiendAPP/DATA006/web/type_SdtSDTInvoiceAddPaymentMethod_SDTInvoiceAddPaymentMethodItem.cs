/*
				   File: type_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem
			Description: SDTInvoiceAddPaymentMethod
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
	[XmlRoot(ElementName="SDTInvoiceAddPaymentMethodItem")]
	[XmlType(TypeName="SDTInvoiceAddPaymentMethodItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem : GxUserType
	{
		public SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddescription = "";

		}

		public SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(IGxContext context)
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
			AddObjectProperty("PaymentMethodId", gxTpr_Paymentmethodid, false);


			AddObjectProperty("PaymentMethodDescription", gxTpr_Paymentmethoddescription, false);


			AddObjectProperty("PaymentMethodDiscount", gxTpr_Paymentmethoddiscount, false);


			AddObjectProperty("PaymentMethodRecarge", gxTpr_Paymentmethodrecarge, false);


			AddObjectProperty("InvoicePaymentMethodImport", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Invoicepaymentmethodimport, 18, 2)), false);


			AddObjectProperty("InvoicePaymentMethodDiscountImport", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Invoicepaymentmethoddiscountimport, 18, 2)), false);


			AddObjectProperty("InvoicePaymentMethodRechargeImport", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Invoicepaymentmethodrechargeimport, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PaymentMethodId")]
		[XmlElement(ElementName="PaymentMethodId")]
		public int gxTpr_Paymentmethodid
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodid; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodid = value;
				SetDirty("Paymentmethodid");
			}
		}




		[SoapElement(ElementName="PaymentMethodDescription")]
		[XmlElement(ElementName="PaymentMethodDescription")]
		public string gxTpr_Paymentmethoddescription
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddescription; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddescription = value;
				SetDirty("Paymentmethoddescription");
			}
		}



		[SoapElement(ElementName="PaymentMethodDiscount")]
		[XmlElement(ElementName="PaymentMethodDiscount")]
		public string gxTpr_Paymentmethoddiscount_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddiscount, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddiscount = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Paymentmethoddiscount
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddiscount; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddiscount = value;
				SetDirty("Paymentmethoddiscount");
			}
		}



		[SoapElement(ElementName="PaymentMethodRecarge")]
		[XmlElement(ElementName="PaymentMethodRecarge")]
		public string gxTpr_Paymentmethodrecarge_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodrecarge, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodrecarge = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Paymentmethodrecarge
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodrecarge; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodrecarge = value;
				SetDirty("Paymentmethodrecarge");
			}
		}



		[SoapElement(ElementName="InvoicePaymentMethodImport")]
		[XmlElement(ElementName="InvoicePaymentMethodImport")]
		public string gxTpr_Invoicepaymentmethodimport_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodimport, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodimport = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Invoicepaymentmethodimport
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodimport; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodimport = value;
				SetDirty("Invoicepaymentmethodimport");
			}
		}



		[SoapElement(ElementName="InvoicePaymentMethodDiscountImport")]
		[XmlElement(ElementName="InvoicePaymentMethodDiscountImport")]
		public string gxTpr_Invoicepaymentmethoddiscountimport_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethoddiscountimport, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethoddiscountimport = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Invoicepaymentmethoddiscountimport
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethoddiscountimport; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethoddiscountimport = value;
				SetDirty("Invoicepaymentmethoddiscountimport");
			}
		}



		[SoapElement(ElementName="InvoicePaymentMethodRechargeImport")]
		[XmlElement(ElementName="InvoicePaymentMethodRechargeImport")]
		public string gxTpr_Invoicepaymentmethodrechargeimport_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodrechargeimport, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodrechargeimport = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Invoicepaymentmethodrechargeimport
		{
			get {
				return gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodrechargeimport; 
			}
			set {
				gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodrechargeimport = value;
				SetDirty("Invoicepaymentmethodrechargeimport");
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
			gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddescription = "";





			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodid;
		 

		protected string gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddescription;
		 

		protected decimal gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethoddiscount;
		 

		protected decimal gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Paymentmethodrecarge;
		 

		protected decimal gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodimport;
		 

		protected decimal gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethoddiscountimport;
		 

		protected decimal gxTv_SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_Invoicepaymentmethodrechargeimport;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTInvoiceAddPaymentMethodItem", Namespace="mtaKB")]
	public class SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_RESTInterface : GxGenericCollectionItem<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem_RESTInterface( SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PaymentMethodId", Order=0)]
		public int gxTpr_Paymentmethodid
		{
			get { 
				return sdt.gxTpr_Paymentmethodid;

			}
			set { 
				sdt.gxTpr_Paymentmethodid = value;
			}
		}

		[DataMember(Name="PaymentMethodDescription", Order=1)]
		public  string gxTpr_Paymentmethoddescription
		{
			get { 
				return sdt.gxTpr_Paymentmethoddescription;

			}
			set { 
				 sdt.gxTpr_Paymentmethoddescription = value;
			}
		}

		[DataMember(Name="PaymentMethodDiscount", Order=2)]
		public  string gxTpr_Paymentmethoddiscount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Paymentmethoddiscount, 8, 2));

			}
			set { 
				sdt.gxTpr_Paymentmethoddiscount =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PaymentMethodRecarge", Order=3)]
		public  string gxTpr_Paymentmethodrecarge
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Paymentmethodrecarge, 8, 2));

			}
			set { 
				sdt.gxTpr_Paymentmethodrecarge =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InvoicePaymentMethodImport", Order=4)]
		public  string gxTpr_Invoicepaymentmethodimport
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Invoicepaymentmethodimport, 18, 2));

			}
			set { 
				sdt.gxTpr_Invoicepaymentmethodimport =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InvoicePaymentMethodDiscountImport", Order=5)]
		public  string gxTpr_Invoicepaymentmethoddiscountimport
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Invoicepaymentmethoddiscountimport, 18, 2));

			}
			set { 
				sdt.gxTpr_Invoicepaymentmethoddiscountimport =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="InvoicePaymentMethodRechargeImport", Order=6)]
		public  string gxTpr_Invoicepaymentmethodrechargeimport
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Invoicepaymentmethodrechargeimport, 18, 2));

			}
			set { 
				sdt.gxTpr_Invoicepaymentmethodrechargeimport =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem sdt
		{
			get { 
				return (SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)Sdt;
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
				sdt = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem() ;
			}
		}
	}
	#endregion
}