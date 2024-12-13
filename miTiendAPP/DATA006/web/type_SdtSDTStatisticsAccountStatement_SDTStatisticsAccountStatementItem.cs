/*
				   File: type_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem
			Description: SDTStatisticsAccountStatement
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
	[XmlRoot(ElementName="SDTStatisticsAccountStatementItem")]
	[XmlType(TypeName="SDTStatisticsAccountStatementItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem : GxUserType
	{
		public SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem(IGxContext context)
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
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Date", sDateCnv, false);



			AddObjectProperty("ImportRaised", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Importraised, 18, 2)), false);


			AddObjectProperty("ImportPurchased", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Importpurchased, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Date")]
		[XmlElement(ElementName="Date" , IsNullable=true)]
		public string gxTpr_Date_Nullable
		{
			get {
				if ( gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date).value ;
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Date
		{
			get {
				return gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date; 
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date = value;
				SetDirty("Date");
			}
		}


		[SoapElement(ElementName="ImportRaised")]
		[XmlElement(ElementName="ImportRaised")]
		public string gxTpr_Importraised_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importraised, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importraised = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importraised
		{
			get {
				return gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importraised; 
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importraised = value;
				SetDirty("Importraised");
			}
		}



		[SoapElement(ElementName="ImportPurchased")]
		[XmlElement(ElementName="ImportPurchased")]
		public string gxTpr_Importpurchased_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importpurchased, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importpurchased = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importpurchased
		{
			get {
				return gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importpurchased; 
			}
			set {
				gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importpurchased = value;
				SetDirty("Importpurchased");
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
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Date;
		 

		protected decimal gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importraised;
		 

		protected decimal gxTv_SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_Importpurchased;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTStatisticsAccountStatementItem", Namespace="mtaKB")]
	public class SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_RESTInterface : GxGenericCollectionItem<SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem_RESTInterface( SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Date", Order=0)]
		public  string gxTpr_Date
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Date);

			}
			set { 
				sdt.gxTpr_Date = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ImportRaised", Order=1)]
		public  string gxTpr_Importraised
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importraised, 18, 2));

			}
			set { 
				sdt.gxTpr_Importraised =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ImportPurchased", Order=2)]
		public  string gxTpr_Importpurchased
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importpurchased, 18, 2));

			}
			set { 
				sdt.gxTpr_Importpurchased =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem sdt
		{
			get { 
				return (SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem)Sdt;
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
				sdt = new SdtSDTStatisticsAccountStatement_SDTStatisticsAccountStatementItem() ;
			}
		}
	}
	#endregion
}