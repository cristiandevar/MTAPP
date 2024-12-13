/*
				   File: type_SdtTimeSerie_Category
			Description: TimeSerie
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
	[XmlRoot(ElementName="Category")]
	[XmlType(TypeName="Category" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtTimeSerie_Category : GxUserType
	{
		public SdtTimeSerie_Category( )
		{
			/* Constructor for serialization */
			gxTv_SdtTimeSerie_Category_Name = "";

		}

		public SdtTimeSerie_Category(IGxContext context)
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



			AddObjectProperty("X", gxTpr_X, false);


			AddObjectProperty("Y", gxTpr_Y, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtTimeSerie_Category_Name; 
			}
			set {
				gxTv_SdtTimeSerie_Category_Name = value;
				SetDirty("Name");
			}
		}



		[SoapElement(ElementName="Date")]
		[XmlElement(ElementName="Date" , IsNullable=true)]
		public string gxTpr_Date_Nullable
		{
			get {
				if ( gxTv_SdtTimeSerie_Category_Date == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtTimeSerie_Category_Date).value ;
			}
			set {
				gxTv_SdtTimeSerie_Category_Date = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Date
		{
			get {
				return gxTv_SdtTimeSerie_Category_Date; 
			}
			set {
				gxTv_SdtTimeSerie_Category_Date = value;
				SetDirty("Date");
			}
		}



		[SoapElement(ElementName="X")]
		[XmlElement(ElementName="X")]
		public short gxTpr_X
		{
			get {
				return gxTv_SdtTimeSerie_Category_X; 
			}
			set {
				gxTv_SdtTimeSerie_Category_X = value;
				SetDirty("X");
			}
		}




		[SoapElement(ElementName="Y")]
		[XmlElement(ElementName="Y")]
		public short gxTpr_Y
		{
			get {
				return gxTv_SdtTimeSerie_Category_Y; 
			}
			set {
				gxTv_SdtTimeSerie_Category_Y = value;
				SetDirty("Y");
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
			gxTv_SdtTimeSerie_Category_Name = "";



			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtTimeSerie_Category_Name;
		 

		protected DateTime gxTv_SdtTimeSerie_Category_Date;
		 

		protected short gxTv_SdtTimeSerie_Category_X;
		 

		protected short gxTv_SdtTimeSerie_Category_Y;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Category", Namespace="mtaKB")]
	public class SdtTimeSerie_Category_RESTInterface : GxGenericCollectionItem<SdtTimeSerie_Category>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTimeSerie_Category_RESTInterface( ) : base()
		{	
		}

		public SdtTimeSerie_Category_RESTInterface( SdtTimeSerie_Category psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Date", Order=1)]
		public  string gxTpr_Date
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Date);

			}
			set { 
				sdt.gxTpr_Date = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="X", Order=2)]
		public short gxTpr_X
		{
			get { 
				return sdt.gxTpr_X;

			}
			set { 
				sdt.gxTpr_X = value;
			}
		}

		[DataMember(Name="Y", Order=3)]
		public short gxTpr_Y
		{
			get { 
				return sdt.gxTpr_Y;

			}
			set { 
				sdt.gxTpr_Y = value;
			}
		}


		#endregion

		public SdtTimeSerie_Category sdt
		{
			get { 
				return (SdtTimeSerie_Category)Sdt;
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
				sdt = new SdtTimeSerie_Category() ;
			}
		}
	}
	#endregion
}