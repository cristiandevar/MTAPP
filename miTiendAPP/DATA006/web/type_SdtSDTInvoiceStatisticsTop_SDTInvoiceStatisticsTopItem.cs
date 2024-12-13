/*
				   File: type_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem
			Description: SDTInvoiceStatisticsTop
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
	[XmlRoot(ElementName="SDTInvoiceStatisticsTopItem")]
	[XmlType(TypeName="SDTInvoiceStatisticsTopItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem : GxUserType
	{
		public SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productname = "";

		}

		public SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem(IGxContext context)
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
			AddObjectProperty("ProductId", gxTpr_Productid, false);


			AddObjectProperty("ProductName", gxTpr_Productname, false);


			AddObjectProperty("Count", gxTpr_Count, false);


			AddObjectProperty("Total", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Total, 18, 2)), false);


			AddObjectProperty("QtySold", gxTpr_Qtysold, false);


			AddObjectProperty("TotalRaised", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalraised, 18, 2)), false);


			AddObjectProperty("TotalDetail", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totaldetail, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductId")]
		[XmlElement(ElementName="ProductId")]
		public int gxTpr_Productid
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productid; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productid = value;
				SetDirty("Productid");
			}
		}




		[SoapElement(ElementName="ProductName")]
		[XmlElement(ElementName="ProductName")]
		public string gxTpr_Productname
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productname; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productname = value;
				SetDirty("Productname");
			}
		}




		[SoapElement(ElementName="Count")]
		[XmlElement(ElementName="Count")]
		public short gxTpr_Count
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Count; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Count = value;
				SetDirty("Count");
			}
		}



		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public string gxTpr_Total_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Total, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Total = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Total
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Total; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="QtySold")]
		[XmlElement(ElementName="QtySold")]
		public short gxTpr_Qtysold
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Qtysold; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Qtysold = value;
				SetDirty("Qtysold");
			}
		}



		[SoapElement(ElementName="TotalRaised")]
		[XmlElement(ElementName="TotalRaised")]
		public string gxTpr_Totalraised_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totalraised, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totalraised = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalraised
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totalraised; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totalraised = value;
				SetDirty("Totalraised");
			}
		}



		[SoapElement(ElementName="TotalDetail")]
		[XmlElement(ElementName="TotalDetail")]
		public string gxTpr_Totaldetail_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totaldetail, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totaldetail = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totaldetail
		{
			get {
				return gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totaldetail; 
			}
			set {
				gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totaldetail = value;
				SetDirty("Totaldetail");
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
			gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productname = "";





			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productid;
		 

		protected string gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Productname;
		 

		protected short gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Count;
		 

		protected decimal gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Total;
		 

		protected short gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Qtysold;
		 

		protected decimal gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totalraised;
		 

		protected decimal gxTv_SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_Totaldetail;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTInvoiceStatisticsTopItem", Namespace="mtaKB")]
	public class SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_RESTInterface : GxGenericCollectionItem<SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem_RESTInterface( SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductId", Order=0)]
		public int gxTpr_Productid
		{
			get { 
				return sdt.gxTpr_Productid;

			}
			set { 
				sdt.gxTpr_Productid = value;
			}
		}

		[DataMember(Name="ProductName", Order=1)]
		public  string gxTpr_Productname
		{
			get { 
				return sdt.gxTpr_Productname;

			}
			set { 
				 sdt.gxTpr_Productname = value;
			}
		}

		[DataMember(Name="Count", Order=2)]
		public short gxTpr_Count
		{
			get { 
				return sdt.gxTpr_Count;

			}
			set { 
				sdt.gxTpr_Count = value;
			}
		}

		[DataMember(Name="Total", Order=3)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Total, 18, 2));

			}
			set { 
				sdt.gxTpr_Total =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="QtySold", Order=4)]
		public short gxTpr_Qtysold
		{
			get { 
				return sdt.gxTpr_Qtysold;

			}
			set { 
				sdt.gxTpr_Qtysold = value;
			}
		}

		[DataMember(Name="TotalRaised", Order=5)]
		public  string gxTpr_Totalraised
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalraised, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalraised =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalDetail", Order=6)]
		public  string gxTpr_Totaldetail
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totaldetail, 18, 2));

			}
			set { 
				sdt.gxTpr_Totaldetail =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem sdt
		{
			get { 
				return (SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem)Sdt;
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
				sdt = new SdtSDTInvoiceStatisticsTop_SDTInvoiceStatisticsTopItem() ;
			}
		}
	}
	#endregion
}