using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "PurchaseOrder" )]
   [XmlType(TypeName =  "PurchaseOrder" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtPurchaseOrder : GxSilentTrnSdt
   {
      public SdtPurchaseOrder( )
      {
      }

      public SdtPurchaseOrder( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV50PurchaseOrderId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV50PurchaseOrderId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PurchaseOrderId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PurchaseOrder");
         metadata.Set("BT", "PurchaseOrder");
         metadata.Set("PK", "[ \"PurchaseOrderId\" ]");
         metadata.Set("PKAssigned", "[ \"PurchaseOrderId\" ]");
         metadata.Set("Levels", "[ \"Detail\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SupplierId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Purchaseorderid_Z");
         state.Add("gxTpr_Supplierid_Z");
         state.Add("gxTpr_Suppliername_Z");
         state.Add("gxTpr_Purchaseordercreateddate_Z_Nullable");
         state.Add("gxTpr_Purchaseordertotalpaid_Z");
         state.Add("gxTpr_Purchaseordercloseddate_Z_Nullable");
         state.Add("gxTpr_Purchaseordermodifieddate_Z_Nullable");
         state.Add("gxTpr_Purchaseorderconfirmateddate_Z_Nullable");
         state.Add("gxTpr_Purchaseorderactive_Z");
         state.Add("gxTpr_Purchaseordercanceleddescription_Z");
         state.Add("gxTpr_Purchaseorderwaspaid_Z");
         state.Add("gxTpr_Purchaseorderpaiddate_Z_Nullable");
         state.Add("gxTpr_Purchaseorderdetailsquantity_Z");
         state.Add("gxTpr_Purchaseorderlastdetailid_Z");
         state.Add("gxTpr_Purchaseordertotalpaid_N");
         state.Add("gxTpr_Purchaseordercloseddate_N");
         state.Add("gxTpr_Purchaseordermodifieddate_N");
         state.Add("gxTpr_Purchaseorderconfirmateddate_N");
         state.Add("gxTpr_Purchaseordercanceleddescription_N");
         state.Add("gxTpr_Purchaseorderwaspaid_N");
         state.Add("gxTpr_Purchaseorderpaiddate_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPurchaseOrder sdt;
         sdt = (SdtPurchaseOrder)(source);
         gxTv_SdtPurchaseOrder_Purchaseorderid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderid ;
         gxTv_SdtPurchaseOrder_Supplierid = sdt.gxTv_SdtPurchaseOrder_Supplierid ;
         gxTv_SdtPurchaseOrder_Suppliername = sdt.gxTv_SdtPurchaseOrder_Suppliername ;
         gxTv_SdtPurchaseOrder_Purchaseordercreateddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordercreateddate ;
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid = sdt.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid ;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordercloseddate ;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate ;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = sdt.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate ;
         gxTv_SdtPurchaseOrder_Purchaseorderactive = sdt.gxTv_SdtPurchaseOrder_Purchaseorderactive ;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription = sdt.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription ;
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid ;
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = sdt.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate ;
         gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity = sdt.gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity ;
         gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid ;
         gxTv_SdtPurchaseOrder_Detail = sdt.gxTv_SdtPurchaseOrder_Detail ;
         gxTv_SdtPurchaseOrder_Mode = sdt.gxTv_SdtPurchaseOrder_Mode ;
         gxTv_SdtPurchaseOrder_Initialized = sdt.gxTv_SdtPurchaseOrder_Initialized ;
         gxTv_SdtPurchaseOrder_Purchaseorderid_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderid_Z ;
         gxTv_SdtPurchaseOrder_Supplierid_Z = sdt.gxTv_SdtPurchaseOrder_Supplierid_Z ;
         gxTv_SdtPurchaseOrder_Suppliername_Z = sdt.gxTv_SdtPurchaseOrder_Suppliername_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderactive_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderactive_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z ;
         gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z = sdt.gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z ;
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = sdt.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N ;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = sdt.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N ;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = sdt.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N ;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = sdt.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N ;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = sdt.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N ;
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = sdt.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N ;
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = sdt.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("PurchaseOrderId", gxTv_SdtPurchaseOrder_Purchaseorderid, false, includeNonInitialized);
         AddObjectProperty("SupplierId", gxTv_SdtPurchaseOrder_Supplierid, false, includeNonInitialized);
         AddObjectProperty("SupplierName", gxTv_SdtPurchaseOrder_Suppliername, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PurchaseOrderCreatedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderTotalPaid", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPurchaseOrder_Purchaseordertotalpaid, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderTotalPaid_N", gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordercloseddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordercloseddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordercloseddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PurchaseOrderClosedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderClosedDate_N", gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PurchaseOrderModifiedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderModifiedDate_N", gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PurchaseOrderConfirmatedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderConfirmatedDate_N", gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderActive", gxTv_SdtPurchaseOrder_Purchaseorderactive, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderCanceledDescription", gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderCanceledDescription_N", gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderWasPaid", gxTv_SdtPurchaseOrder_Purchaseorderwaspaid, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderWasPaid_N", gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PurchaseOrderPaidDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderPaidDate_N", gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderDetailsQuantity", gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity, false, includeNonInitialized);
         AddObjectProperty("PurchaseOrderLastDetailId", gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid, false, includeNonInitialized);
         if ( gxTv_SdtPurchaseOrder_Detail != null )
         {
            AddObjectProperty("Detail", gxTv_SdtPurchaseOrder_Detail, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPurchaseOrder_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPurchaseOrder_Initialized, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderId_Z", gxTv_SdtPurchaseOrder_Purchaseorderid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierId_Z", gxTv_SdtPurchaseOrder_Supplierid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierName_Z", gxTv_SdtPurchaseOrder_Suppliername_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PurchaseOrderCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderTotalPaid_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z, 18, 2)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PurchaseOrderClosedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PurchaseOrderModifiedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PurchaseOrderConfirmatedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderActive_Z", gxTv_SdtPurchaseOrder_Purchaseorderactive_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderCanceledDescription_Z", gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderWasPaid_Z", gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PurchaseOrderPaidDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderDetailsQuantity_Z", gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderLastDetailId_Z", gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderTotalPaid_N", gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderClosedDate_N", gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderModifiedDate_N", gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderConfirmatedDate_N", gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderCanceledDescription_N", gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderWasPaid_N", gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N, false, includeNonInitialized);
            AddObjectProperty("PurchaseOrderPaidDate_N", gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPurchaseOrder sdt )
      {
         if ( sdt.IsDirty("PurchaseOrderId") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderid ;
         }
         if ( sdt.IsDirty("SupplierId") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Supplierid = sdt.gxTv_SdtPurchaseOrder_Supplierid ;
         }
         if ( sdt.IsDirty("SupplierName") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Suppliername = sdt.gxTv_SdtPurchaseOrder_Suppliername ;
         }
         if ( sdt.IsDirty("PurchaseOrderCreatedDate") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercreateddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordercreateddate ;
         }
         if ( sdt.IsDirty("PurchaseOrderTotalPaid") )
         {
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid = sdt.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid ;
         }
         if ( sdt.IsDirty("PurchaseOrderClosedDate") )
         {
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordercloseddate ;
         }
         if ( sdt.IsDirty("PurchaseOrderModifiedDate") )
         {
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = sdt.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate ;
         }
         if ( sdt.IsDirty("PurchaseOrderConfirmatedDate") )
         {
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = sdt.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate ;
         }
         if ( sdt.IsDirty("PurchaseOrderActive") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderactive = sdt.gxTv_SdtPurchaseOrder_Purchaseorderactive ;
         }
         if ( sdt.IsDirty("PurchaseOrderCanceledDescription") )
         {
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription = sdt.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription ;
         }
         if ( sdt.IsDirty("PurchaseOrderWasPaid") )
         {
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid ;
         }
         if ( sdt.IsDirty("PurchaseOrderPaidDate") )
         {
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = (short)(sdt.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N);
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = sdt.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate ;
         }
         if ( sdt.IsDirty("PurchaseOrderDetailsQuantity") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity = sdt.gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity ;
         }
         if ( sdt.IsDirty("PurchaseOrderLastDetailId") )
         {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid = sdt.gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid ;
         }
         if ( gxTv_SdtPurchaseOrder_Detail != null )
         {
            GXBCLevelCollection<SdtPurchaseOrder_Detail> newCollectionDetail = sdt.gxTpr_Detail;
            SdtPurchaseOrder_Detail currItemDetail;
            SdtPurchaseOrder_Detail newItemDetail;
            short idx = 1;
            while ( idx <= newCollectionDetail.Count )
            {
               newItemDetail = ((SdtPurchaseOrder_Detail)newCollectionDetail.Item(idx));
               currItemDetail = gxTv_SdtPurchaseOrder_Detail.GetByKey(newItemDetail.gxTpr_Purchaseorderdetailid);
               if ( StringUtil.StrCmp(currItemDetail.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemDetail.UpdateDirties(newItemDetail);
                  if ( StringUtil.StrCmp(newItemDetail.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemDetail.gxTpr_Mode = "DLT";
                  }
                  currItemDetail.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPurchaseOrder_Detail.Add(newItemDetail, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "PurchaseOrderId" )]
      [  XmlElement( ElementName = "PurchaseOrderId"   )]
      public int gxTpr_Purchaseorderid
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderid ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if ( gxTv_SdtPurchaseOrder_Purchaseorderid != value )
            {
               gxTv_SdtPurchaseOrder_Mode = "INS";
               this.gxTv_SdtPurchaseOrder_Purchaseorderid_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Supplierid_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Suppliername_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderactive_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z_SetNull( );
               this.gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z_SetNull( );
               if ( gxTv_SdtPurchaseOrder_Detail != null )
               {
                  GXBCLevelCollection<SdtPurchaseOrder_Detail> collectionDetail = gxTv_SdtPurchaseOrder_Detail;
                  SdtPurchaseOrder_Detail currItemDetail;
                  short idx = 1;
                  while ( idx <= collectionDetail.Count )
                  {
                     currItemDetail = ((SdtPurchaseOrder_Detail)collectionDetail.Item(idx));
                     currItemDetail.gxTpr_Mode = "INS";
                     currItemDetail.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtPurchaseOrder_Purchaseorderid = value;
            SetDirty("Purchaseorderid");
         }

      }

      [  SoapElement( ElementName = "SupplierId" )]
      [  XmlElement( ElementName = "SupplierId"   )]
      public int gxTpr_Supplierid
      {
         get {
            return gxTv_SdtPurchaseOrder_Supplierid ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Supplierid = value;
            SetDirty("Supplierid");
         }

      }

      [  SoapElement( ElementName = "SupplierName" )]
      [  XmlElement( ElementName = "SupplierName"   )]
      public string gxTpr_Suppliername
      {
         get {
            return gxTv_SdtPurchaseOrder_Suppliername ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Suppliername = value;
            SetDirty("Suppliername");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderCreatedDate" )]
      [  XmlElement( ElementName = "PurchaseOrderCreatedDate"  , IsNullable=true )]
      public string gxTpr_Purchaseordercreateddate_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordercreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordercreateddate).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordercreateddate = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordercreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordercreateddate
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercreateddate ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercreateddate = value;
            SetDirty("Purchaseordercreateddate");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderTotalPaid" )]
      [  XmlElement( ElementName = "PurchaseOrderTotalPaid"   )]
      public decimal gxTpr_Purchaseordertotalpaid
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordertotalpaid ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid = value;
            SetDirty("Purchaseordertotalpaid");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid = 0;
         SetDirty("Purchaseordertotalpaid");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderClosedDate" )]
      [  XmlElement( ElementName = "PurchaseOrderClosedDate"  , IsNullable=true )]
      public string gxTpr_Purchaseordercloseddate_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordercloseddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordercloseddate).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordercloseddate = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordercloseddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordercloseddate
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercloseddate ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate = value;
            SetDirty("Purchaseordercloseddate");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercloseddate_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseordercloseddate");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercloseddate_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderModifiedDate" )]
      [  XmlElement( ElementName = "PurchaseOrderModifiedDate"  , IsNullable=true )]
      public string gxTpr_Purchaseordermodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordermodifieddate).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordermodifieddate
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordermodifieddate ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = value;
            SetDirty("Purchaseordermodifieddate");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseordermodifieddate");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderConfirmatedDate" )]
      [  XmlElement( ElementName = "PurchaseOrderConfirmatedDate"  , IsNullable=true )]
      public string gxTpr_Purchaseorderconfirmateddate_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseorderconfirmateddate
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = value;
            SetDirty("Purchaseorderconfirmateddate");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseorderconfirmateddate");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderActive" )]
      [  XmlElement( ElementName = "PurchaseOrderActive"   )]
      public bool gxTpr_Purchaseorderactive
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderactive ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderactive = value;
            SetDirty("Purchaseorderactive");
         }

      }

      [  SoapElement( ElementName = "PurchaseOrderCanceledDescription" )]
      [  XmlElement( ElementName = "PurchaseOrderCanceledDescription"   )]
      public string gxTpr_Purchaseordercanceleddescription
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription = value;
            SetDirty("Purchaseordercanceleddescription");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription = "";
         SetDirty("Purchaseordercanceleddescription");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderWasPaid" )]
      [  XmlElement( ElementName = "PurchaseOrderWasPaid"   )]
      public bool gxTpr_Purchaseorderwaspaid
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderwaspaid ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid = value;
            SetDirty("Purchaseorderwaspaid");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid = false;
         SetDirty("Purchaseorderwaspaid");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderPaidDate" )]
      [  XmlElement( ElementName = "PurchaseOrderPaidDate"  , IsNullable=true )]
      public string gxTpr_Purchaseorderpaiddate_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseorderpaiddate).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseorderpaiddate
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderpaiddate ;
         }

         set {
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = 0;
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = value;
            SetDirty("Purchaseorderpaiddate");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = 1;
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseorderpaiddate");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_IsNull( )
      {
         return (gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N==1) ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailsQuantity" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailsQuantity"   )]
      public short gxTpr_Purchaseorderdetailsquantity
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity = value;
            SetDirty("Purchaseorderdetailsquantity");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity = 0;
         SetDirty("Purchaseorderdetailsquantity");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderLastDetailId" )]
      [  XmlElement( ElementName = "PurchaseOrderLastDetailId"   )]
      public int gxTpr_Purchaseorderlastdetailid
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid = value;
            SetDirty("Purchaseorderlastdetailid");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid = 0;
         SetDirty("Purchaseorderlastdetailid");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Detail" )]
      [  XmlArray( ElementName = "Detail"  )]
      [  XmlArrayItemAttribute( ElementName= "PurchaseOrder.Detail"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPurchaseOrder_Detail> gxTpr_Detail_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Detail == null )
            {
               gxTv_SdtPurchaseOrder_Detail = new GXBCLevelCollection<SdtPurchaseOrder_Detail>( context, "PurchaseOrder.Detail", "mtaKB");
            }
            return gxTv_SdtPurchaseOrder_Detail ;
         }

         set {
            if ( gxTv_SdtPurchaseOrder_Detail == null )
            {
               gxTv_SdtPurchaseOrder_Detail = new GXBCLevelCollection<SdtPurchaseOrder_Detail>( context, "PurchaseOrder.Detail", "mtaKB");
            }
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Detail = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtPurchaseOrder_Detail> gxTpr_Detail
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Detail == null )
            {
               gxTv_SdtPurchaseOrder_Detail = new GXBCLevelCollection<SdtPurchaseOrder_Detail>( context, "PurchaseOrder.Detail", "mtaKB");
            }
            gxTv_SdtPurchaseOrder_N = 0;
            return gxTv_SdtPurchaseOrder_Detail ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Detail = value;
            SetDirty("Detail");
         }

      }

      public void gxTv_SdtPurchaseOrder_Detail_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Detail = null;
         SetDirty("Detail");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Detail_IsNull( )
      {
         if ( gxTv_SdtPurchaseOrder_Detail == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPurchaseOrder_Mode ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPurchaseOrder_Mode_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPurchaseOrder_Initialized ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPurchaseOrder_Initialized_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderId_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderId_Z"   )]
      public int gxTpr_Purchaseorderid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderid_Z = value;
            SetDirty("Purchaseorderid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderid_Z = 0;
         SetDirty("Purchaseorderid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierId_Z" )]
      [  XmlElement( ElementName = "SupplierId_Z"   )]
      public int gxTpr_Supplierid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Supplierid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Supplierid_Z = value;
            SetDirty("Supplierid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Supplierid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Supplierid_Z = 0;
         SetDirty("Supplierid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Supplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierName_Z" )]
      [  XmlElement( ElementName = "SupplierName_Z"   )]
      public string gxTpr_Suppliername_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Suppliername_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Suppliername_Z = value;
            SetDirty("Suppliername_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Suppliername_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Suppliername_Z = "";
         SetDirty("Suppliername_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Suppliername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderCreatedDate_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Purchaseordercreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordercreateddate_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = value;
            SetDirty("Purchaseordercreateddate_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseordercreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderTotalPaid_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderTotalPaid_Z"   )]
      public decimal gxTpr_Purchaseordertotalpaid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z = value;
            SetDirty("Purchaseordertotalpaid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z = 0;
         SetDirty("Purchaseordertotalpaid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderClosedDate_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderClosedDate_Z"  , IsNullable=true )]
      public string gxTpr_Purchaseordercloseddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordercloseddate_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = value;
            SetDirty("Purchaseordercloseddate_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseordercloseddate_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderModifiedDate_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Purchaseordermodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseordermodifieddate_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = value;
            SetDirty("Purchaseordermodifieddate_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseordermodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderConfirmatedDate_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderConfirmatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Purchaseorderconfirmateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseorderconfirmateddate_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = value;
            SetDirty("Purchaseorderconfirmateddate_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseorderconfirmateddate_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderActive_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderActive_Z"   )]
      public bool gxTpr_Purchaseorderactive_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderactive_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderactive_Z = value;
            SetDirty("Purchaseorderactive_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderactive_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderactive_Z = false;
         SetDirty("Purchaseorderactive_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderCanceledDescription_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderCanceledDescription_Z"   )]
      public string gxTpr_Purchaseordercanceleddescription_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z = value;
            SetDirty("Purchaseordercanceleddescription_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z = "";
         SetDirty("Purchaseordercanceleddescription_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderWasPaid_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderWasPaid_Z"   )]
      public bool gxTpr_Purchaseorderwaspaid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z = value;
            SetDirty("Purchaseorderwaspaid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z = false;
         SetDirty("Purchaseorderwaspaid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderPaidDate_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderPaidDate_Z"  , IsNullable=true )]
      public string gxTpr_Purchaseorderpaiddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z).value ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = DateTime.MinValue;
            else
               gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Purchaseorderpaiddate_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = value;
            SetDirty("Purchaseorderpaiddate_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Purchaseorderpaiddate_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderDetailsQuantity_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderDetailsQuantity_Z"   )]
      public short gxTpr_Purchaseorderdetailsquantity_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z = value;
            SetDirty("Purchaseorderdetailsquantity_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z = 0;
         SetDirty("Purchaseorderdetailsquantity_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderLastDetailId_Z" )]
      [  XmlElement( ElementName = "PurchaseOrderLastDetailId_Z"   )]
      public int gxTpr_Purchaseorderlastdetailid_Z
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z = value;
            SetDirty("Purchaseorderlastdetailid_Z");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z = 0;
         SetDirty("Purchaseorderlastdetailid_Z");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderTotalPaid_N" )]
      [  XmlElement( ElementName = "PurchaseOrderTotalPaid_N"   )]
      public short gxTpr_Purchaseordertotalpaid_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = value;
            SetDirty("Purchaseordertotalpaid_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N = 0;
         SetDirty("Purchaseordertotalpaid_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderClosedDate_N" )]
      [  XmlElement( ElementName = "PurchaseOrderClosedDate_N"   )]
      public short gxTpr_Purchaseordercloseddate_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = value;
            SetDirty("Purchaseordercloseddate_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N = 0;
         SetDirty("Purchaseordercloseddate_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderModifiedDate_N" )]
      [  XmlElement( ElementName = "PurchaseOrderModifiedDate_N"   )]
      public short gxTpr_Purchaseordermodifieddate_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = value;
            SetDirty("Purchaseordermodifieddate_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N = 0;
         SetDirty("Purchaseordermodifieddate_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderConfirmatedDate_N" )]
      [  XmlElement( ElementName = "PurchaseOrderConfirmatedDate_N"   )]
      public short gxTpr_Purchaseorderconfirmateddate_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = value;
            SetDirty("Purchaseorderconfirmateddate_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N = 0;
         SetDirty("Purchaseorderconfirmateddate_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderCanceledDescription_N" )]
      [  XmlElement( ElementName = "PurchaseOrderCanceledDescription_N"   )]
      public short gxTpr_Purchaseordercanceleddescription_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = value;
            SetDirty("Purchaseordercanceleddescription_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N = 0;
         SetDirty("Purchaseordercanceleddescription_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderWasPaid_N" )]
      [  XmlElement( ElementName = "PurchaseOrderWasPaid_N"   )]
      public short gxTpr_Purchaseorderwaspaid_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = value;
            SetDirty("Purchaseorderwaspaid_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N = 0;
         SetDirty("Purchaseorderwaspaid_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PurchaseOrderPaidDate_N" )]
      [  XmlElement( ElementName = "PurchaseOrderPaidDate_N"   )]
      public short gxTpr_Purchaseorderpaiddate_N
      {
         get {
            return gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N ;
         }

         set {
            gxTv_SdtPurchaseOrder_N = 0;
            gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = value;
            SetDirty("Purchaseorderpaiddate_N");
         }

      }

      public void gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N_SetNull( )
      {
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N = 0;
         SetDirty("Purchaseorderpaiddate_N");
         return  ;
      }

      public bool gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPurchaseOrder_N = 1;
         gxTv_SdtPurchaseOrder_Suppliername = "";
         gxTv_SdtPurchaseOrder_Purchaseordercreateddate = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseorderactive = true;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription = "";
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Mode = "";
         gxTv_SdtPurchaseOrder_Suppliername_Z = "";
         gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z = DateTime.MinValue;
         gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z = "";
         gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "purchaseorder", "GeneXus.Programs.purchaseorder_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPurchaseOrder_N ;
      }

      private short gxTv_SdtPurchaseOrder_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity ;
      private short gxTv_SdtPurchaseOrder_Initialized ;
      private short gxTv_SdtPurchaseOrder_Purchaseorderdetailsquantity_Z ;
      private short gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseordercloseddate_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_N ;
      private short gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_N ;
      private int gxTv_SdtPurchaseOrder_Purchaseorderid ;
      private int gxTv_SdtPurchaseOrder_Supplierid ;
      private int gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid ;
      private int gxTv_SdtPurchaseOrder_Purchaseorderid_Z ;
      private int gxTv_SdtPurchaseOrder_Supplierid_Z ;
      private int gxTv_SdtPurchaseOrder_Purchaseorderlastdetailid_Z ;
      private decimal gxTv_SdtPurchaseOrder_Purchaseordertotalpaid ;
      private decimal gxTv_SdtPurchaseOrder_Purchaseordertotalpaid_Z ;
      private string gxTv_SdtPurchaseOrder_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordercreateddate ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordercloseddate ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordermodifieddate ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseorderpaiddate ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordercreateddate_Z ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordercloseddate_Z ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseordermodifieddate_Z ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseorderconfirmateddate_Z ;
      private DateTime gxTv_SdtPurchaseOrder_Purchaseorderpaiddate_Z ;
      private bool gxTv_SdtPurchaseOrder_Purchaseorderactive ;
      private bool gxTv_SdtPurchaseOrder_Purchaseorderwaspaid ;
      private bool gxTv_SdtPurchaseOrder_Purchaseorderactive_Z ;
      private bool gxTv_SdtPurchaseOrder_Purchaseorderwaspaid_Z ;
      private string gxTv_SdtPurchaseOrder_Suppliername ;
      private string gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription ;
      private string gxTv_SdtPurchaseOrder_Suppliername_Z ;
      private string gxTv_SdtPurchaseOrder_Purchaseordercanceleddescription_Z ;
      private GXBCLevelCollection<SdtPurchaseOrder_Detail> gxTv_SdtPurchaseOrder_Detail=null ;
   }

   [DataContract(Name = @"PurchaseOrder", Namespace = "mtaKB")]
   public class SdtPurchaseOrder_RESTInterface : GxGenericCollectionItem<SdtPurchaseOrder>
   {
      public SdtPurchaseOrder_RESTInterface( ) : base()
      {
      }

      public SdtPurchaseOrder_RESTInterface( SdtPurchaseOrder psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PurchaseOrderId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Purchaseorderid
      {
         get {
            return sdt.gxTpr_Purchaseorderid ;
         }

         set {
            sdt.gxTpr_Purchaseorderid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SupplierId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Supplierid
      {
         get {
            return sdt.gxTpr_Supplierid ;
         }

         set {
            sdt.gxTpr_Supplierid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SupplierName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Suppliername
      {
         get {
            return sdt.gxTpr_Suppliername ;
         }

         set {
            sdt.gxTpr_Suppliername = value;
         }

      }

      [DataMember( Name = "PurchaseOrderCreatedDate" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordercreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseordercreateddate) ;
         }

         set {
            sdt.gxTpr_Purchaseordercreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PurchaseOrderTotalPaid" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordertotalpaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Purchaseordertotalpaid, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Purchaseordertotalpaid = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PurchaseOrderClosedDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordercloseddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseordercloseddate) ;
         }

         set {
            sdt.gxTpr_Purchaseordercloseddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PurchaseOrderModifiedDate" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordermodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseordermodifieddate) ;
         }

         set {
            sdt.gxTpr_Purchaseordermodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PurchaseOrderConfirmatedDate" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Purchaseorderconfirmateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseorderconfirmateddate) ;
         }

         set {
            sdt.gxTpr_Purchaseorderconfirmateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PurchaseOrderActive" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Purchaseorderactive
      {
         get {
            return sdt.gxTpr_Purchaseorderactive ;
         }

         set {
            sdt.gxTpr_Purchaseorderactive = value;
         }

      }

      [DataMember( Name = "PurchaseOrderCanceledDescription" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordercanceleddescription
      {
         get {
            return sdt.gxTpr_Purchaseordercanceleddescription ;
         }

         set {
            sdt.gxTpr_Purchaseordercanceleddescription = value;
         }

      }

      [DataMember( Name = "PurchaseOrderWasPaid" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Purchaseorderwaspaid
      {
         get {
            return sdt.gxTpr_Purchaseorderwaspaid ;
         }

         set {
            sdt.gxTpr_Purchaseorderwaspaid = value;
         }

      }

      [DataMember( Name = "PurchaseOrderPaidDate" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Purchaseorderpaiddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseorderpaiddate) ;
         }

         set {
            sdt.gxTpr_Purchaseorderpaiddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PurchaseOrderDetailsQuantity" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Purchaseorderdetailsquantity
      {
         get {
            return sdt.gxTpr_Purchaseorderdetailsquantity ;
         }

         set {
            sdt.gxTpr_Purchaseorderdetailsquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PurchaseOrderLastDetailId" , Order = 13 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Purchaseorderlastdetailid
      {
         get {
            return sdt.gxTpr_Purchaseorderlastdetailid ;
         }

         set {
            sdt.gxTpr_Purchaseorderlastdetailid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Detail" , Order = 14 )]
      public GxGenericCollection<SdtPurchaseOrder_Detail_RESTInterface> gxTpr_Detail
      {
         get {
            return new GxGenericCollection<SdtPurchaseOrder_Detail_RESTInterface>(sdt.gxTpr_Detail) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Detail);
         }

      }

      public SdtPurchaseOrder sdt
      {
         get {
            return (SdtPurchaseOrder)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPurchaseOrder() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"PurchaseOrder", Namespace = "mtaKB")]
   public class SdtPurchaseOrder_RESTLInterface : GxGenericCollectionItem<SdtPurchaseOrder>
   {
      public SdtPurchaseOrder_RESTLInterface( ) : base()
      {
      }

      public SdtPurchaseOrder_RESTLInterface( SdtPurchaseOrder psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PurchaseOrderCreatedDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Purchaseordercreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Purchaseordercreateddate) ;
         }

         set {
            sdt.gxTpr_Purchaseordercreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtPurchaseOrder sdt
      {
         get {
            return (SdtPurchaseOrder)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPurchaseOrder() ;
         }
      }

   }

}
