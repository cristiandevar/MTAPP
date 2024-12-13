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
   [XmlRoot(ElementName = "Invoice" )]
   [XmlType(TypeName =  "Invoice" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtInvoice : GxSilentTrnSdt
   {
      public SdtInvoice( )
      {
      }

      public SdtInvoice( IGxContext context )
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

      public void Load( int AV20InvoiceId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV20InvoiceId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InvoiceId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Invoice");
         metadata.Set("BT", "Invoice");
         metadata.Set("PK", "[ \"InvoiceId\" ]");
         metadata.Set("PKAssigned", "[ \"InvoiceId\" ]");
         metadata.Set("Levels", "[ \"Detail\",\"PaymentMethod\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"UserId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Invoiceid_Z");
         state.Add("gxTpr_Invoicecreateddate_Z_Nullable");
         state.Add("gxTpr_Userid_Z");
         state.Add("gxTpr_Username_Z");
         state.Add("gxTpr_Invoicemodifieddate_Z_Nullable");
         state.Add("gxTpr_Invoiceactive_Z");
         state.Add("gxTpr_Invoicetotalreceivable_Z");
         state.Add("gxTpr_Invoiceproductquantity_Z");
         state.Add("gxTpr_Invoicelastdetailid_Z");
         state.Add("gxTpr_Invoicelastpaymentmethodid_Z");
         state.Add("gxTpr_Invoicemodifieddate_N");
         state.Add("gxTpr_Invoicetotalreceivable_N");
         state.Add("gxTpr_Invoicelastpaymentmethodid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInvoice sdt;
         sdt = (SdtInvoice)(source);
         gxTv_SdtInvoice_Invoiceid = sdt.gxTv_SdtInvoice_Invoiceid ;
         gxTv_SdtInvoice_Invoicecreateddate = sdt.gxTv_SdtInvoice_Invoicecreateddate ;
         gxTv_SdtInvoice_Userid = sdt.gxTv_SdtInvoice_Userid ;
         gxTv_SdtInvoice_Username = sdt.gxTv_SdtInvoice_Username ;
         gxTv_SdtInvoice_Invoicemodifieddate = sdt.gxTv_SdtInvoice_Invoicemodifieddate ;
         gxTv_SdtInvoice_Invoiceactive = sdt.gxTv_SdtInvoice_Invoiceactive ;
         gxTv_SdtInvoice_Invoicetotalreceivable = sdt.gxTv_SdtInvoice_Invoicetotalreceivable ;
         gxTv_SdtInvoice_Invoiceproductquantity = sdt.gxTv_SdtInvoice_Invoiceproductquantity ;
         gxTv_SdtInvoice_Invoicelastdetailid = sdt.gxTv_SdtInvoice_Invoicelastdetailid ;
         gxTv_SdtInvoice_Invoicelastpaymentmethodid = sdt.gxTv_SdtInvoice_Invoicelastpaymentmethodid ;
         gxTv_SdtInvoice_Detail = sdt.gxTv_SdtInvoice_Detail ;
         gxTv_SdtInvoice_Paymentmethod = sdt.gxTv_SdtInvoice_Paymentmethod ;
         gxTv_SdtInvoice_Mode = sdt.gxTv_SdtInvoice_Mode ;
         gxTv_SdtInvoice_Initialized = sdt.gxTv_SdtInvoice_Initialized ;
         gxTv_SdtInvoice_Invoiceid_Z = sdt.gxTv_SdtInvoice_Invoiceid_Z ;
         gxTv_SdtInvoice_Invoicecreateddate_Z = sdt.gxTv_SdtInvoice_Invoicecreateddate_Z ;
         gxTv_SdtInvoice_Userid_Z = sdt.gxTv_SdtInvoice_Userid_Z ;
         gxTv_SdtInvoice_Username_Z = sdt.gxTv_SdtInvoice_Username_Z ;
         gxTv_SdtInvoice_Invoicemodifieddate_Z = sdt.gxTv_SdtInvoice_Invoicemodifieddate_Z ;
         gxTv_SdtInvoice_Invoiceactive_Z = sdt.gxTv_SdtInvoice_Invoiceactive_Z ;
         gxTv_SdtInvoice_Invoicetotalreceivable_Z = sdt.gxTv_SdtInvoice_Invoicetotalreceivable_Z ;
         gxTv_SdtInvoice_Invoiceproductquantity_Z = sdt.gxTv_SdtInvoice_Invoiceproductquantity_Z ;
         gxTv_SdtInvoice_Invoicelastdetailid_Z = sdt.gxTv_SdtInvoice_Invoicelastdetailid_Z ;
         gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z = sdt.gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z ;
         gxTv_SdtInvoice_Invoicemodifieddate_N = sdt.gxTv_SdtInvoice_Invoicemodifieddate_N ;
         gxTv_SdtInvoice_Invoicetotalreceivable_N = sdt.gxTv_SdtInvoice_Invoicetotalreceivable_N ;
         gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = sdt.gxTv_SdtInvoice_Invoicelastpaymentmethodid_N ;
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
         AddObjectProperty("InvoiceId", gxTv_SdtInvoice_Invoiceid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvoice_Invoicecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvoice_Invoicecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvoice_Invoicecreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("InvoiceCreatedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UserId", gxTv_SdtInvoice_Userid, false, includeNonInitialized);
         AddObjectProperty("UserName", gxTv_SdtInvoice_Username, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvoice_Invoicemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvoice_Invoicemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvoice_Invoicemodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("InvoiceModifiedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("InvoiceModifiedDate_N", gxTv_SdtInvoice_Invoicemodifieddate_N, false, includeNonInitialized);
         AddObjectProperty("InvoiceActive", gxTv_SdtInvoice_Invoiceactive, false, includeNonInitialized);
         AddObjectProperty("InvoiceTotalReceivable", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_Invoicetotalreceivable, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InvoiceTotalReceivable_N", gxTv_SdtInvoice_Invoicetotalreceivable_N, false, includeNonInitialized);
         AddObjectProperty("InvoiceProductQuantity", gxTv_SdtInvoice_Invoiceproductquantity, false, includeNonInitialized);
         AddObjectProperty("InvoiceLastDetailId", gxTv_SdtInvoice_Invoicelastdetailid, false, includeNonInitialized);
         AddObjectProperty("InvoiceLastPaymentMethodId", gxTv_SdtInvoice_Invoicelastpaymentmethodid, false, includeNonInitialized);
         AddObjectProperty("InvoiceLastPaymentMethodId_N", gxTv_SdtInvoice_Invoicelastpaymentmethodid_N, false, includeNonInitialized);
         if ( gxTv_SdtInvoice_Detail != null )
         {
            AddObjectProperty("Detail", gxTv_SdtInvoice_Detail, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtInvoice_Paymentmethod != null )
         {
            AddObjectProperty("PaymentMethod", gxTv_SdtInvoice_Paymentmethod, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInvoice_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInvoice_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvoiceId_Z", gxTv_SdtInvoice_Invoiceid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvoice_Invoicecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvoice_Invoicecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvoice_Invoicecreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("InvoiceCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("UserId_Z", gxTv_SdtInvoice_Userid_Z, false, includeNonInitialized);
            AddObjectProperty("UserName_Z", gxTv_SdtInvoice_Username_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtInvoice_Invoicemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtInvoice_Invoicemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtInvoice_Invoicemodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("InvoiceModifiedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("InvoiceActive_Z", gxTv_SdtInvoice_Invoiceactive_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceTotalReceivable_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtInvoice_Invoicetotalreceivable_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("InvoiceProductQuantity_Z", gxTv_SdtInvoice_Invoiceproductquantity_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceLastDetailId_Z", gxTv_SdtInvoice_Invoicelastdetailid_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceLastPaymentMethodId_Z", gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceModifiedDate_N", gxTv_SdtInvoice_Invoicemodifieddate_N, false, includeNonInitialized);
            AddObjectProperty("InvoiceTotalReceivable_N", gxTv_SdtInvoice_Invoicetotalreceivable_N, false, includeNonInitialized);
            AddObjectProperty("InvoiceLastPaymentMethodId_N", gxTv_SdtInvoice_Invoicelastpaymentmethodid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInvoice sdt )
      {
         if ( sdt.IsDirty("InvoiceId") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceid = sdt.gxTv_SdtInvoice_Invoiceid ;
         }
         if ( sdt.IsDirty("InvoiceCreatedDate") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicecreateddate = sdt.gxTv_SdtInvoice_Invoicecreateddate ;
         }
         if ( sdt.IsDirty("UserId") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Userid = sdt.gxTv_SdtInvoice_Userid ;
         }
         if ( sdt.IsDirty("UserName") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Username = sdt.gxTv_SdtInvoice_Username ;
         }
         if ( sdt.IsDirty("InvoiceModifiedDate") )
         {
            gxTv_SdtInvoice_Invoicemodifieddate_N = (short)(sdt.gxTv_SdtInvoice_Invoicemodifieddate_N);
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicemodifieddate = sdt.gxTv_SdtInvoice_Invoicemodifieddate ;
         }
         if ( sdt.IsDirty("InvoiceActive") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceactive = sdt.gxTv_SdtInvoice_Invoiceactive ;
         }
         if ( sdt.IsDirty("InvoiceTotalReceivable") )
         {
            gxTv_SdtInvoice_Invoicetotalreceivable_N = (short)(sdt.gxTv_SdtInvoice_Invoicetotalreceivable_N);
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicetotalreceivable = sdt.gxTv_SdtInvoice_Invoicetotalreceivable ;
         }
         if ( sdt.IsDirty("InvoiceProductQuantity") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceproductquantity = sdt.gxTv_SdtInvoice_Invoiceproductquantity ;
         }
         if ( sdt.IsDirty("InvoiceLastDetailId") )
         {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastdetailid = sdt.gxTv_SdtInvoice_Invoicelastdetailid ;
         }
         if ( sdt.IsDirty("InvoiceLastPaymentMethodId") )
         {
            gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = (short)(sdt.gxTv_SdtInvoice_Invoicelastpaymentmethodid_N);
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastpaymentmethodid = sdt.gxTv_SdtInvoice_Invoicelastpaymentmethodid ;
         }
         if ( gxTv_SdtInvoice_Detail != null )
         {
            GXBCLevelCollection<SdtInvoice_Detail> newCollectionDetail = sdt.gxTpr_Detail;
            SdtInvoice_Detail currItemDetail;
            SdtInvoice_Detail newItemDetail;
            short idx = 1;
            while ( idx <= newCollectionDetail.Count )
            {
               newItemDetail = ((SdtInvoice_Detail)newCollectionDetail.Item(idx));
               currItemDetail = gxTv_SdtInvoice_Detail.GetByKey(newItemDetail.gxTpr_Invoicedetailid);
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
                  gxTv_SdtInvoice_Detail.Add(newItemDetail, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtInvoice_Paymentmethod != null )
         {
            GXBCLevelCollection<SdtInvoice_PaymentMethod> newCollectionPaymentmethod = sdt.gxTpr_Paymentmethod;
            SdtInvoice_PaymentMethod currItemPaymentmethod;
            SdtInvoice_PaymentMethod newItemPaymentmethod;
            short idx = 1;
            while ( idx <= newCollectionPaymentmethod.Count )
            {
               newItemPaymentmethod = ((SdtInvoice_PaymentMethod)newCollectionPaymentmethod.Item(idx));
               currItemPaymentmethod = gxTv_SdtInvoice_Paymentmethod.GetByKey(newItemPaymentmethod.gxTpr_Invoicepaymentmethodid);
               if ( StringUtil.StrCmp(currItemPaymentmethod.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemPaymentmethod.UpdateDirties(newItemPaymentmethod);
                  if ( StringUtil.StrCmp(newItemPaymentmethod.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemPaymentmethod.gxTpr_Mode = "DLT";
                  }
                  currItemPaymentmethod.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtInvoice_Paymentmethod.Add(newItemPaymentmethod, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvoiceId" )]
      [  XmlElement( ElementName = "InvoiceId"   )]
      public int gxTpr_Invoiceid
      {
         get {
            return gxTv_SdtInvoice_Invoiceid ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            if ( gxTv_SdtInvoice_Invoiceid != value )
            {
               gxTv_SdtInvoice_Mode = "INS";
               this.gxTv_SdtInvoice_Invoiceid_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoicecreateddate_Z_SetNull( );
               this.gxTv_SdtInvoice_Userid_Z_SetNull( );
               this.gxTv_SdtInvoice_Username_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoicemodifieddate_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoiceactive_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoicetotalreceivable_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoiceproductquantity_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoicelastdetailid_Z_SetNull( );
               this.gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z_SetNull( );
               if ( gxTv_SdtInvoice_Detail != null )
               {
                  GXBCLevelCollection<SdtInvoice_Detail> collectionDetail = gxTv_SdtInvoice_Detail;
                  SdtInvoice_Detail currItemDetail;
                  short idx = 1;
                  while ( idx <= collectionDetail.Count )
                  {
                     currItemDetail = ((SdtInvoice_Detail)collectionDetail.Item(idx));
                     currItemDetail.gxTpr_Mode = "INS";
                     currItemDetail.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtInvoice_Paymentmethod != null )
               {
                  GXBCLevelCollection<SdtInvoice_PaymentMethod> collectionPaymentmethod = gxTv_SdtInvoice_Paymentmethod;
                  SdtInvoice_PaymentMethod currItemPaymentmethod;
                  short idx = 1;
                  while ( idx <= collectionPaymentmethod.Count )
                  {
                     currItemPaymentmethod = ((SdtInvoice_PaymentMethod)collectionPaymentmethod.Item(idx));
                     currItemPaymentmethod.gxTpr_Mode = "INS";
                     currItemPaymentmethod.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtInvoice_Invoiceid = value;
            SetDirty("Invoiceid");
         }

      }

      [  SoapElement( ElementName = "InvoiceCreatedDate" )]
      [  XmlElement( ElementName = "InvoiceCreatedDate"  , IsNullable=true )]
      public string gxTpr_Invoicecreateddate_Nullable
      {
         get {
            if ( gxTv_SdtInvoice_Invoicecreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvoice_Invoicecreateddate).value ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvoice_Invoicecreateddate = DateTime.MinValue;
            else
               gxTv_SdtInvoice_Invoicecreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicecreateddate
      {
         get {
            return gxTv_SdtInvoice_Invoicecreateddate ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicecreateddate = value;
            SetDirty("Invoicecreateddate");
         }

      }

      [  SoapElement( ElementName = "UserId" )]
      [  XmlElement( ElementName = "UserId"   )]
      public int gxTpr_Userid
      {
         get {
            return gxTv_SdtInvoice_Userid ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Userid = value;
            SetDirty("Userid");
         }

      }

      [  SoapElement( ElementName = "UserName" )]
      [  XmlElement( ElementName = "UserName"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtInvoice_Username ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "InvoiceModifiedDate" )]
      [  XmlElement( ElementName = "InvoiceModifiedDate"  , IsNullable=true )]
      public string gxTpr_Invoicemodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtInvoice_Invoicemodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvoice_Invoicemodifieddate).value ;
         }

         set {
            gxTv_SdtInvoice_Invoicemodifieddate_N = 0;
            gxTv_SdtInvoice_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvoice_Invoicemodifieddate = DateTime.MinValue;
            else
               gxTv_SdtInvoice_Invoicemodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicemodifieddate
      {
         get {
            return gxTv_SdtInvoice_Invoicemodifieddate ;
         }

         set {
            gxTv_SdtInvoice_Invoicemodifieddate_N = 0;
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicemodifieddate = value;
            SetDirty("Invoicemodifieddate");
         }

      }

      public void gxTv_SdtInvoice_Invoicemodifieddate_SetNull( )
      {
         gxTv_SdtInvoice_Invoicemodifieddate_N = 1;
         gxTv_SdtInvoice_Invoicemodifieddate = (DateTime)(DateTime.MinValue);
         SetDirty("Invoicemodifieddate");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicemodifieddate_IsNull( )
      {
         return (gxTv_SdtInvoice_Invoicemodifieddate_N==1) ;
      }

      [  SoapElement( ElementName = "InvoiceActive" )]
      [  XmlElement( ElementName = "InvoiceActive"   )]
      public bool gxTpr_Invoiceactive
      {
         get {
            return gxTv_SdtInvoice_Invoiceactive ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceactive = value;
            SetDirty("Invoiceactive");
         }

      }

      [  SoapElement( ElementName = "InvoiceTotalReceivable" )]
      [  XmlElement( ElementName = "InvoiceTotalReceivable"   )]
      public decimal gxTpr_Invoicetotalreceivable
      {
         get {
            return gxTv_SdtInvoice_Invoicetotalreceivable ;
         }

         set {
            gxTv_SdtInvoice_Invoicetotalreceivable_N = 0;
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicetotalreceivable = value;
            SetDirty("Invoicetotalreceivable");
         }

      }

      public void gxTv_SdtInvoice_Invoicetotalreceivable_SetNull( )
      {
         gxTv_SdtInvoice_Invoicetotalreceivable_N = 1;
         gxTv_SdtInvoice_Invoicetotalreceivable = 0;
         SetDirty("Invoicetotalreceivable");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicetotalreceivable_IsNull( )
      {
         return (gxTv_SdtInvoice_Invoicetotalreceivable_N==1) ;
      }

      [  SoapElement( ElementName = "InvoiceProductQuantity" )]
      [  XmlElement( ElementName = "InvoiceProductQuantity"   )]
      public short gxTpr_Invoiceproductquantity
      {
         get {
            return gxTv_SdtInvoice_Invoiceproductquantity ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceproductquantity = value;
            SetDirty("Invoiceproductquantity");
         }

      }

      public void gxTv_SdtInvoice_Invoiceproductquantity_SetNull( )
      {
         gxTv_SdtInvoice_Invoiceproductquantity = 0;
         SetDirty("Invoiceproductquantity");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoiceproductquantity_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceLastDetailId" )]
      [  XmlElement( ElementName = "InvoiceLastDetailId"   )]
      public int gxTpr_Invoicelastdetailid
      {
         get {
            return gxTv_SdtInvoice_Invoicelastdetailid ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastdetailid = value;
            SetDirty("Invoicelastdetailid");
         }

      }

      public void gxTv_SdtInvoice_Invoicelastdetailid_SetNull( )
      {
         gxTv_SdtInvoice_Invoicelastdetailid = 0;
         SetDirty("Invoicelastdetailid");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicelastdetailid_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceLastPaymentMethodId" )]
      [  XmlElement( ElementName = "InvoiceLastPaymentMethodId"   )]
      public int gxTpr_Invoicelastpaymentmethodid
      {
         get {
            return gxTv_SdtInvoice_Invoicelastpaymentmethodid ;
         }

         set {
            gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = 0;
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastpaymentmethodid = value;
            SetDirty("Invoicelastpaymentmethodid");
         }

      }

      public void gxTv_SdtInvoice_Invoicelastpaymentmethodid_SetNull( )
      {
         gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = 1;
         gxTv_SdtInvoice_Invoicelastpaymentmethodid = 0;
         SetDirty("Invoicelastpaymentmethodid");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicelastpaymentmethodid_IsNull( )
      {
         return (gxTv_SdtInvoice_Invoicelastpaymentmethodid_N==1) ;
      }

      [  SoapElement( ElementName = "Detail" )]
      [  XmlArray( ElementName = "Detail"  )]
      [  XmlArrayItemAttribute( ElementName= "Invoice.Detail"  , IsNullable=false)]
      public GXBCLevelCollection<SdtInvoice_Detail> gxTpr_Detail_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtInvoice_Detail == null )
            {
               gxTv_SdtInvoice_Detail = new GXBCLevelCollection<SdtInvoice_Detail>( context, "Invoice.Detail", "mtaKB");
            }
            return gxTv_SdtInvoice_Detail ;
         }

         set {
            if ( gxTv_SdtInvoice_Detail == null )
            {
               gxTv_SdtInvoice_Detail = new GXBCLevelCollection<SdtInvoice_Detail>( context, "Invoice.Detail", "mtaKB");
            }
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Detail = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtInvoice_Detail> gxTpr_Detail
      {
         get {
            if ( gxTv_SdtInvoice_Detail == null )
            {
               gxTv_SdtInvoice_Detail = new GXBCLevelCollection<SdtInvoice_Detail>( context, "Invoice.Detail", "mtaKB");
            }
            gxTv_SdtInvoice_N = 0;
            return gxTv_SdtInvoice_Detail ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Detail = value;
            SetDirty("Detail");
         }

      }

      public void gxTv_SdtInvoice_Detail_SetNull( )
      {
         gxTv_SdtInvoice_Detail = null;
         SetDirty("Detail");
         return  ;
      }

      public bool gxTv_SdtInvoice_Detail_IsNull( )
      {
         if ( gxTv_SdtInvoice_Detail == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "PaymentMethod" )]
      [  XmlArray( ElementName = "PaymentMethod"  )]
      [  XmlArrayItemAttribute( ElementName= "Invoice.PaymentMethod"  , IsNullable=false)]
      public GXBCLevelCollection<SdtInvoice_PaymentMethod> gxTpr_Paymentmethod_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtInvoice_Paymentmethod == null )
            {
               gxTv_SdtInvoice_Paymentmethod = new GXBCLevelCollection<SdtInvoice_PaymentMethod>( context, "Invoice.PaymentMethod", "mtaKB");
            }
            return gxTv_SdtInvoice_Paymentmethod ;
         }

         set {
            if ( gxTv_SdtInvoice_Paymentmethod == null )
            {
               gxTv_SdtInvoice_Paymentmethod = new GXBCLevelCollection<SdtInvoice_PaymentMethod>( context, "Invoice.PaymentMethod", "mtaKB");
            }
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Paymentmethod = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtInvoice_PaymentMethod> gxTpr_Paymentmethod
      {
         get {
            if ( gxTv_SdtInvoice_Paymentmethod == null )
            {
               gxTv_SdtInvoice_Paymentmethod = new GXBCLevelCollection<SdtInvoice_PaymentMethod>( context, "Invoice.PaymentMethod", "mtaKB");
            }
            gxTv_SdtInvoice_N = 0;
            return gxTv_SdtInvoice_Paymentmethod ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Paymentmethod = value;
            SetDirty("Paymentmethod");
         }

      }

      public void gxTv_SdtInvoice_Paymentmethod_SetNull( )
      {
         gxTv_SdtInvoice_Paymentmethod = null;
         SetDirty("Paymentmethod");
         return  ;
      }

      public bool gxTv_SdtInvoice_Paymentmethod_IsNull( )
      {
         if ( gxTv_SdtInvoice_Paymentmethod == null )
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
            return gxTv_SdtInvoice_Mode ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInvoice_Mode_SetNull( )
      {
         gxTv_SdtInvoice_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInvoice_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInvoice_Initialized ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInvoice_Initialized_SetNull( )
      {
         gxTv_SdtInvoice_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInvoice_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceId_Z" )]
      [  XmlElement( ElementName = "InvoiceId_Z"   )]
      public int gxTpr_Invoiceid_Z
      {
         get {
            return gxTv_SdtInvoice_Invoiceid_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceid_Z = value;
            SetDirty("Invoiceid_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoiceid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoiceid_Z = 0;
         SetDirty("Invoiceid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoiceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceCreatedDate_Z" )]
      [  XmlElement( ElementName = "InvoiceCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Invoicecreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtInvoice_Invoicecreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvoice_Invoicecreateddate_Z).value ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvoice_Invoicecreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtInvoice_Invoicecreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicecreateddate_Z
      {
         get {
            return gxTv_SdtInvoice_Invoicecreateddate_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicecreateddate_Z = value;
            SetDirty("Invoicecreateddate_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoicecreateddate_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoicecreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Invoicecreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicecreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserId_Z" )]
      [  XmlElement( ElementName = "UserId_Z"   )]
      public int gxTpr_Userid_Z
      {
         get {
            return gxTv_SdtInvoice_Userid_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Userid_Z = value;
            SetDirty("Userid_Z");
         }

      }

      public void gxTv_SdtInvoice_Userid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Userid_Z = 0;
         SetDirty("Userid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Userid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserName_Z" )]
      [  XmlElement( ElementName = "UserName_Z"   )]
      public string gxTpr_Username_Z
      {
         get {
            return gxTv_SdtInvoice_Username_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Username_Z = value;
            SetDirty("Username_Z");
         }

      }

      public void gxTv_SdtInvoice_Username_Z_SetNull( )
      {
         gxTv_SdtInvoice_Username_Z = "";
         SetDirty("Username_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Username_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceModifiedDate_Z" )]
      [  XmlElement( ElementName = "InvoiceModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Invoicemodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtInvoice_Invoicemodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtInvoice_Invoicemodifieddate_Z).value ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtInvoice_Invoicemodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtInvoice_Invoicemodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicemodifieddate_Z
      {
         get {
            return gxTv_SdtInvoice_Invoicemodifieddate_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicemodifieddate_Z = value;
            SetDirty("Invoicemodifieddate_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoicemodifieddate_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoicemodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Invoicemodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicemodifieddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceActive_Z" )]
      [  XmlElement( ElementName = "InvoiceActive_Z"   )]
      public bool gxTpr_Invoiceactive_Z
      {
         get {
            return gxTv_SdtInvoice_Invoiceactive_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceactive_Z = value;
            SetDirty("Invoiceactive_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoiceactive_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoiceactive_Z = false;
         SetDirty("Invoiceactive_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoiceactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceTotalReceivable_Z" )]
      [  XmlElement( ElementName = "InvoiceTotalReceivable_Z"   )]
      public decimal gxTpr_Invoicetotalreceivable_Z
      {
         get {
            return gxTv_SdtInvoice_Invoicetotalreceivable_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicetotalreceivable_Z = value;
            SetDirty("Invoicetotalreceivable_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoicetotalreceivable_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoicetotalreceivable_Z = 0;
         SetDirty("Invoicetotalreceivable_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicetotalreceivable_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceProductQuantity_Z" )]
      [  XmlElement( ElementName = "InvoiceProductQuantity_Z"   )]
      public short gxTpr_Invoiceproductquantity_Z
      {
         get {
            return gxTv_SdtInvoice_Invoiceproductquantity_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoiceproductquantity_Z = value;
            SetDirty("Invoiceproductquantity_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoiceproductquantity_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoiceproductquantity_Z = 0;
         SetDirty("Invoiceproductquantity_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoiceproductquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceLastDetailId_Z" )]
      [  XmlElement( ElementName = "InvoiceLastDetailId_Z"   )]
      public int gxTpr_Invoicelastdetailid_Z
      {
         get {
            return gxTv_SdtInvoice_Invoicelastdetailid_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastdetailid_Z = value;
            SetDirty("Invoicelastdetailid_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoicelastdetailid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoicelastdetailid_Z = 0;
         SetDirty("Invoicelastdetailid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicelastdetailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceLastPaymentMethodId_Z" )]
      [  XmlElement( ElementName = "InvoiceLastPaymentMethodId_Z"   )]
      public int gxTpr_Invoicelastpaymentmethodid_Z
      {
         get {
            return gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z = value;
            SetDirty("Invoicelastpaymentmethodid_Z");
         }

      }

      public void gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z_SetNull( )
      {
         gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z = 0;
         SetDirty("Invoicelastpaymentmethodid_Z");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceModifiedDate_N" )]
      [  XmlElement( ElementName = "InvoiceModifiedDate_N"   )]
      public short gxTpr_Invoicemodifieddate_N
      {
         get {
            return gxTv_SdtInvoice_Invoicemodifieddate_N ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicemodifieddate_N = value;
            SetDirty("Invoicemodifieddate_N");
         }

      }

      public void gxTv_SdtInvoice_Invoicemodifieddate_N_SetNull( )
      {
         gxTv_SdtInvoice_Invoicemodifieddate_N = 0;
         SetDirty("Invoicemodifieddate_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicemodifieddate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceTotalReceivable_N" )]
      [  XmlElement( ElementName = "InvoiceTotalReceivable_N"   )]
      public short gxTpr_Invoicetotalreceivable_N
      {
         get {
            return gxTv_SdtInvoice_Invoicetotalreceivable_N ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicetotalreceivable_N = value;
            SetDirty("Invoicetotalreceivable_N");
         }

      }

      public void gxTv_SdtInvoice_Invoicetotalreceivable_N_SetNull( )
      {
         gxTv_SdtInvoice_Invoicetotalreceivable_N = 0;
         SetDirty("Invoicetotalreceivable_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicetotalreceivable_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceLastPaymentMethodId_N" )]
      [  XmlElement( ElementName = "InvoiceLastPaymentMethodId_N"   )]
      public short gxTpr_Invoicelastpaymentmethodid_N
      {
         get {
            return gxTv_SdtInvoice_Invoicelastpaymentmethodid_N ;
         }

         set {
            gxTv_SdtInvoice_N = 0;
            gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = value;
            SetDirty("Invoicelastpaymentmethodid_N");
         }

      }

      public void gxTv_SdtInvoice_Invoicelastpaymentmethodid_N_SetNull( )
      {
         gxTv_SdtInvoice_Invoicelastpaymentmethodid_N = 0;
         SetDirty("Invoicelastpaymentmethodid_N");
         return  ;
      }

      public bool gxTv_SdtInvoice_Invoicelastpaymentmethodid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtInvoice_N = 1;
         gxTv_SdtInvoice_Invoicecreateddate = DateTime.MinValue;
         gxTv_SdtInvoice_Username = "";
         gxTv_SdtInvoice_Invoicemodifieddate = DateTime.MinValue;
         gxTv_SdtInvoice_Mode = "";
         gxTv_SdtInvoice_Invoicecreateddate_Z = DateTime.MinValue;
         gxTv_SdtInvoice_Username_Z = "";
         gxTv_SdtInvoice_Invoicemodifieddate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "invoice", "GeneXus.Programs.invoice_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtInvoice_N ;
      }

      private short gxTv_SdtInvoice_N ;
      private short gxTv_SdtInvoice_Invoiceproductquantity ;
      private short gxTv_SdtInvoice_Initialized ;
      private short gxTv_SdtInvoice_Invoiceproductquantity_Z ;
      private short gxTv_SdtInvoice_Invoicemodifieddate_N ;
      private short gxTv_SdtInvoice_Invoicetotalreceivable_N ;
      private short gxTv_SdtInvoice_Invoicelastpaymentmethodid_N ;
      private int gxTv_SdtInvoice_Invoiceid ;
      private int gxTv_SdtInvoice_Userid ;
      private int gxTv_SdtInvoice_Invoicelastdetailid ;
      private int gxTv_SdtInvoice_Invoicelastpaymentmethodid ;
      private int gxTv_SdtInvoice_Invoiceid_Z ;
      private int gxTv_SdtInvoice_Userid_Z ;
      private int gxTv_SdtInvoice_Invoicelastdetailid_Z ;
      private int gxTv_SdtInvoice_Invoicelastpaymentmethodid_Z ;
      private decimal gxTv_SdtInvoice_Invoicetotalreceivable ;
      private decimal gxTv_SdtInvoice_Invoicetotalreceivable_Z ;
      private string gxTv_SdtInvoice_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtInvoice_Invoicecreateddate ;
      private DateTime gxTv_SdtInvoice_Invoicemodifieddate ;
      private DateTime gxTv_SdtInvoice_Invoicecreateddate_Z ;
      private DateTime gxTv_SdtInvoice_Invoicemodifieddate_Z ;
      private bool gxTv_SdtInvoice_Invoiceactive ;
      private bool gxTv_SdtInvoice_Invoiceactive_Z ;
      private string gxTv_SdtInvoice_Username ;
      private string gxTv_SdtInvoice_Username_Z ;
      private GXBCLevelCollection<SdtInvoice_Detail> gxTv_SdtInvoice_Detail=null ;
      private GXBCLevelCollection<SdtInvoice_PaymentMethod> gxTv_SdtInvoice_Paymentmethod=null ;
   }

   [DataContract(Name = @"Invoice", Namespace = "mtaKB")]
   public class SdtInvoice_RESTInterface : GxGenericCollectionItem<SdtInvoice>
   {
      public SdtInvoice_RESTInterface( ) : base()
      {
      }

      public SdtInvoice_RESTInterface( SdtInvoice psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoiceId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoiceid
      {
         get {
            return sdt.gxTpr_Invoiceid ;
         }

         set {
            sdt.gxTpr_Invoiceid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceCreatedDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Invoicecreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Invoicecreateddate) ;
         }

         set {
            sdt.gxTpr_Invoicecreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UserId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Userid
      {
         get {
            return sdt.gxTpr_Userid ;
         }

         set {
            sdt.gxTpr_Userid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UserName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Username
      {
         get {
            return sdt.gxTpr_Username ;
         }

         set {
            sdt.gxTpr_Username = value;
         }

      }

      [DataMember( Name = "InvoiceModifiedDate" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Invoicemodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Invoicemodifieddate) ;
         }

         set {
            sdt.gxTpr_Invoicemodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "InvoiceActive" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Invoiceactive
      {
         get {
            return sdt.gxTpr_Invoiceactive ;
         }

         set {
            sdt.gxTpr_Invoiceactive = value;
         }

      }

      [DataMember( Name = "InvoiceTotalReceivable" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Invoicetotalreceivable
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicetotalreceivable, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicetotalreceivable = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoiceProductQuantity" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invoiceproductquantity
      {
         get {
            return sdt.gxTpr_Invoiceproductquantity ;
         }

         set {
            sdt.gxTpr_Invoiceproductquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceLastDetailId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoicelastdetailid
      {
         get {
            return sdt.gxTpr_Invoicelastdetailid ;
         }

         set {
            sdt.gxTpr_Invoicelastdetailid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceLastPaymentMethodId" , Order = 9 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Invoicelastpaymentmethodid
      {
         get {
            return sdt.gxTpr_Invoicelastpaymentmethodid ;
         }

         set {
            sdt.gxTpr_Invoicelastpaymentmethodid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Detail" , Order = 10 )]
      public GxGenericCollection<SdtInvoice_Detail_RESTInterface> gxTpr_Detail
      {
         get {
            return new GxGenericCollection<SdtInvoice_Detail_RESTInterface>(sdt.gxTpr_Detail) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Detail);
         }

      }

      [DataMember( Name = "PaymentMethod" , Order = 11 )]
      public GxGenericCollection<SdtInvoice_PaymentMethod_RESTInterface> gxTpr_Paymentmethod
      {
         get {
            return new GxGenericCollection<SdtInvoice_PaymentMethod_RESTInterface>(sdt.gxTpr_Paymentmethod) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Paymentmethod);
         }

      }

      public SdtInvoice sdt
      {
         get {
            return (SdtInvoice)Sdt ;
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
            sdt = new SdtInvoice() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 12 )]
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

   [DataContract(Name = @"Invoice", Namespace = "mtaKB")]
   public class SdtInvoice_RESTLInterface : GxGenericCollectionItem<SdtInvoice>
   {
      public SdtInvoice_RESTLInterface( ) : base()
      {
      }

      public SdtInvoice_RESTLInterface( SdtInvoice psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoiceCreatedDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Invoicecreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Invoicecreateddate) ;
         }

         set {
            sdt.gxTpr_Invoicecreateddate = DateTimeUtil.CToD2( value);
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

      public SdtInvoice sdt
      {
         get {
            return (SdtInvoice)Sdt ;
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
            sdt = new SdtInvoice() ;
         }
      }

   }

}
