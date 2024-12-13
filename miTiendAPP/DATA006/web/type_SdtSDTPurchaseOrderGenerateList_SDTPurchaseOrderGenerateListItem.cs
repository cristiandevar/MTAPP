/*
				   File: type_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem
			Description: SDTPurchaseOrderGenerateList
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
	[XmlRoot(ElementName="SDTPurchaseOrderGenerateListItem")]
	[XmlType(TypeName="SDTPurchaseOrderGenerateListItem" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem : GxUserType
	{
		public SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Suppliername = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Detailslink = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Sdtvoucherlink = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage_gxi = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage_gxi = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage_gxi = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage_gxi = "";
		}

		public SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(IGxContext context)
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
			AddObjectProperty("PurchaseOrderId", gxTpr_Purchaseorderid, false);


			AddObjectProperty("SupplierName", gxTpr_Suppliername, false);


			AddObjectProperty("PurchaseOrderDetailsQuantity", gxTpr_Purchaseorderdetailsquantity, false);


			AddObjectProperty("DetailsLink", gxTpr_Detailslink, false);


			AddObjectProperty("SDTVoucherLink", gxTpr_Sdtvoucherlink, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Createddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Createddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Createddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("CreatedDate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Closeddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Closeddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Closeddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ClosedDate", sDateCnv, false);



			AddObjectProperty("AddImage", gxTpr_Addimage, false);
			AddObjectProperty("AddImage_GXI", gxTpr_Addimage_gxi, false);



			AddObjectProperty("CanAdd", gxTpr_Canadd, false);


			AddObjectProperty("DeleteImage", gxTpr_Deleteimage, false);
			AddObjectProperty("DeleteImage_GXI", gxTpr_Deleteimage_gxi, false);



			AddObjectProperty("CanDelete", gxTpr_Candelete, false);


			AddObjectProperty("ModifyImage", gxTpr_Modifyimage, false);
			AddObjectProperty("ModifyImage_GXI", gxTpr_Modifyimage_gxi, false);



			AddObjectProperty("CanModify", gxTpr_Canmodify, false);


			AddObjectProperty("PaidImage", gxTpr_Paidimage, false);
			AddObjectProperty("PaidImage_GXI", gxTpr_Paidimage_gxi, false);



			AddObjectProperty("CanPay", gxTpr_Canpay, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Purchaseorderconfirmateddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Purchaseorderconfirmateddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Purchaseorderconfirmateddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PurchaseOrderConfirmatedDate", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PurchaseOrderId")]
		[XmlElement(ElementName="PurchaseOrderId")]
		public int gxTpr_Purchaseorderid
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderid; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderid = value;
				SetDirty("Purchaseorderid");
			}
		}




		[SoapElement(ElementName="SupplierName")]
		[XmlElement(ElementName="SupplierName")]
		public string gxTpr_Suppliername
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Suppliername; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Suppliername = value;
				SetDirty("Suppliername");
			}
		}




		[SoapElement(ElementName="PurchaseOrderDetailsQuantity")]
		[XmlElement(ElementName="PurchaseOrderDetailsQuantity")]
		public short gxTpr_Purchaseorderdetailsquantity
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderdetailsquantity; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderdetailsquantity = value;
				SetDirty("Purchaseorderdetailsquantity");
			}
		}




		[SoapElement(ElementName="DetailsLink")]
		[XmlElement(ElementName="DetailsLink")]
		public string gxTpr_Detailslink
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Detailslink; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Detailslink = value;
				SetDirty("Detailslink");
			}
		}




		[SoapElement(ElementName="SDTVoucherLink")]
		[XmlElement(ElementName="SDTVoucherLink")]
		public string gxTpr_Sdtvoucherlink
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Sdtvoucherlink; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Sdtvoucherlink = value;
				SetDirty("Sdtvoucherlink");
			}
		}



		[SoapElement(ElementName="CreatedDate")]
		[XmlElement(ElementName="CreatedDate" , IsNullable=true)]
		public string gxTpr_Createddate_Nullable
		{
			get {
				if ( gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate).value ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Createddate
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate = value;
				SetDirty("Createddate");
			}
		}


		[SoapElement(ElementName="ClosedDate")]
		[XmlElement(ElementName="ClosedDate" , IsNullable=true)]
		public string gxTpr_Closeddate_Nullable
		{
			get {
				if ( gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate).value ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Closeddate
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate = value;
				SetDirty("Closeddate");
			}
		}



		[SoapElement(ElementName="AddImage")]
		[XmlElement(ElementName="AddImage")]
		[GxUpload()]

		public string gxTpr_Addimage
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage = value;
				SetDirty("Addimage");
			}
		}


		[SoapElement(ElementName="AddImage_GXI" )]
		[XmlElement(ElementName="AddImage_GXI" )]
		public string gxTpr_Addimage_gxi
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage_gxi ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage_gxi = value;
				SetDirty("Addimage_gxi");
			}
		}

		[SoapElement(ElementName="CanAdd")]
		[XmlElement(ElementName="CanAdd")]
		public bool gxTpr_Canadd
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canadd; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canadd = value;
				SetDirty("Canadd");
			}
		}




		[SoapElement(ElementName="DeleteImage")]
		[XmlElement(ElementName="DeleteImage")]
		[GxUpload()]

		public string gxTpr_Deleteimage
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage = value;
				SetDirty("Deleteimage");
			}
		}


		[SoapElement(ElementName="DeleteImage_GXI" )]
		[XmlElement(ElementName="DeleteImage_GXI" )]
		public string gxTpr_Deleteimage_gxi
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage_gxi ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage_gxi = value;
				SetDirty("Deleteimage_gxi");
			}
		}

		[SoapElement(ElementName="CanDelete")]
		[XmlElement(ElementName="CanDelete")]
		public bool gxTpr_Candelete
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Candelete; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Candelete = value;
				SetDirty("Candelete");
			}
		}




		[SoapElement(ElementName="ModifyImage")]
		[XmlElement(ElementName="ModifyImage")]
		[GxUpload()]

		public string gxTpr_Modifyimage
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage = value;
				SetDirty("Modifyimage");
			}
		}


		[SoapElement(ElementName="ModifyImage_GXI" )]
		[XmlElement(ElementName="ModifyImage_GXI" )]
		public string gxTpr_Modifyimage_gxi
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage_gxi ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage_gxi = value;
				SetDirty("Modifyimage_gxi");
			}
		}

		[SoapElement(ElementName="CanModify")]
		[XmlElement(ElementName="CanModify")]
		public bool gxTpr_Canmodify
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canmodify; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canmodify = value;
				SetDirty("Canmodify");
			}
		}




		[SoapElement(ElementName="PaidImage")]
		[XmlElement(ElementName="PaidImage")]
		[GxUpload()]

		public string gxTpr_Paidimage
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage = value;
				SetDirty("Paidimage");
			}
		}


		[SoapElement(ElementName="PaidImage_GXI" )]
		[XmlElement(ElementName="PaidImage_GXI" )]
		public string gxTpr_Paidimage_gxi
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage_gxi ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage_gxi = value;
				SetDirty("Paidimage_gxi");
			}
		}

		[SoapElement(ElementName="CanPay")]
		[XmlElement(ElementName="CanPay")]
		public bool gxTpr_Canpay
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canpay; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canpay = value;
				SetDirty("Canpay");
			}
		}



		[SoapElement(ElementName="PurchaseOrderConfirmatedDate")]
		[XmlElement(ElementName="PurchaseOrderConfirmatedDate" , IsNullable=true)]
		public string gxTpr_Purchaseorderconfirmateddate_Nullable
		{
			get {
				if ( gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate).value ;
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Purchaseorderconfirmateddate
		{
			get {
				return gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate; 
			}
			set {
				gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate = value;
				SetDirty("Purchaseorderconfirmateddate");
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
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Suppliername = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Detailslink = "";
			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Sdtvoucherlink = "";


			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage = "";gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage_gxi = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage = "";gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage_gxi = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage = "";gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage_gxi = "";

			gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage = "";gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage_gxi = "";


			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected int gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderid;
		 

		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Suppliername;
		 

		protected short gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderdetailsquantity;
		 

		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Detailslink;
		 

		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Sdtvoucherlink;
		 

		protected DateTime gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Createddate;
		 

		protected DateTime gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Closeddate;
		 
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage_gxi;
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Addimage;
		 

		protected bool gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canadd;
		 
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage_gxi;
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Deleteimage;
		 

		protected bool gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Candelete;
		 
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage_gxi;
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Modifyimage;
		 

		protected bool gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canmodify;
		 
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage_gxi;
		protected string gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Paidimage;
		 

		protected bool gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Canpay;
		 

		protected DateTime gxTv_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_Purchaseorderconfirmateddate;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTPurchaseOrderGenerateListItem", Namespace="mtaKB")]
	public class SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_RESTInterface : GxGenericCollectionItem<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem_RESTInterface( SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PurchaseOrderId", Order=0)]
		public int gxTpr_Purchaseorderid
		{
			get { 
				return sdt.gxTpr_Purchaseorderid;

			}
			set { 
				sdt.gxTpr_Purchaseorderid = value;
			}
		}

		[DataMember(Name="SupplierName", Order=1)]
		public  string gxTpr_Suppliername
		{
			get { 
				return sdt.gxTpr_Suppliername;

			}
			set { 
				 sdt.gxTpr_Suppliername = value;
			}
		}

		[DataMember(Name="PurchaseOrderDetailsQuantity", Order=2)]
		public short gxTpr_Purchaseorderdetailsquantity
		{
			get { 
				return sdt.gxTpr_Purchaseorderdetailsquantity;

			}
			set { 
				sdt.gxTpr_Purchaseorderdetailsquantity = value;
			}
		}

		[DataMember(Name="DetailsLink", Order=3)]
		public  string gxTpr_Detailslink
		{
			get { 
				return sdt.gxTpr_Detailslink;

			}
			set { 
				 sdt.gxTpr_Detailslink = value;
			}
		}

		[DataMember(Name="SDTVoucherLink", Order=4)]
		public  string gxTpr_Sdtvoucherlink
		{
			get { 
				return sdt.gxTpr_Sdtvoucherlink;

			}
			set { 
				 sdt.gxTpr_Sdtvoucherlink = value;
			}
		}

		[DataMember(Name="CreatedDate", Order=5)]
		public  string gxTpr_Createddate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Createddate);

			}
			set { 
				sdt.gxTpr_Createddate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ClosedDate", Order=6)]
		public  string gxTpr_Closeddate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Closeddate);

			}
			set { 
				sdt.gxTpr_Closeddate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="AddImage", Order=7)]
		[GxUpload()]
		public  string gxTpr_Addimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Addimage)) ? PathUtil.RelativePath( sdt.gxTpr_Addimage) : StringUtil.RTrim( sdt.gxTpr_Addimage_gxi));

			}
			set { 
				 sdt.gxTpr_Addimage = value;
			}
		}

		[DataMember(Name="CanAdd", Order=8)]
		public bool gxTpr_Canadd
		{
			get { 
				return sdt.gxTpr_Canadd;

			}
			set { 
				sdt.gxTpr_Canadd = value;
			}
		}

		[DataMember(Name="DeleteImage", Order=9)]
		[GxUpload()]
		public  string gxTpr_Deleteimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Deleteimage)) ? PathUtil.RelativePath( sdt.gxTpr_Deleteimage) : StringUtil.RTrim( sdt.gxTpr_Deleteimage_gxi));

			}
			set { 
				 sdt.gxTpr_Deleteimage = value;
			}
		}

		[DataMember(Name="CanDelete", Order=10)]
		public bool gxTpr_Candelete
		{
			get { 
				return sdt.gxTpr_Candelete;

			}
			set { 
				sdt.gxTpr_Candelete = value;
			}
		}

		[DataMember(Name="ModifyImage", Order=11)]
		[GxUpload()]
		public  string gxTpr_Modifyimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Modifyimage)) ? PathUtil.RelativePath( sdt.gxTpr_Modifyimage) : StringUtil.RTrim( sdt.gxTpr_Modifyimage_gxi));

			}
			set { 
				 sdt.gxTpr_Modifyimage = value;
			}
		}

		[DataMember(Name="CanModify", Order=12)]
		public bool gxTpr_Canmodify
		{
			get { 
				return sdt.gxTpr_Canmodify;

			}
			set { 
				sdt.gxTpr_Canmodify = value;
			}
		}

		[DataMember(Name="PaidImage", Order=13)]
		[GxUpload()]
		public  string gxTpr_Paidimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Paidimage)) ? PathUtil.RelativePath( sdt.gxTpr_Paidimage) : StringUtil.RTrim( sdt.gxTpr_Paidimage_gxi));

			}
			set { 
				 sdt.gxTpr_Paidimage = value;
			}
		}

		[DataMember(Name="CanPay", Order=14)]
		public bool gxTpr_Canpay
		{
			get { 
				return sdt.gxTpr_Canpay;

			}
			set { 
				sdt.gxTpr_Canpay = value;
			}
		}

		[DataMember(Name="PurchaseOrderConfirmatedDate", Order=15)]
		public  string gxTpr_Purchaseorderconfirmateddate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseorderconfirmateddate);

			}
			set { 
				sdt.gxTpr_Purchaseorderconfirmateddate = DateTimeUtil.CToD2(value);
			}
		}


		#endregion

		public SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem sdt
		{
			get { 
				return (SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)Sdt;
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
				sdt = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem() ;
			}
		}
	}
	#endregion
}