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
   [XmlRoot(ElementName = "Product" )]
   [XmlType(TypeName =  "Product" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtProduct : GxSilentTrnSdt
   {
      public SdtProduct( )
      {
      }

      public SdtProduct( IGxContext context )
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

      public void Load( int AV15ProductId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV15ProductId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "Product");
         metadata.Set("PK", "[ \"ProductId\" ]");
         metadata.Set("PKAssigned", "[ \"ProductId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BrandId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SectorId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SupplierId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productcode_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productcostprice_Z");
         state.Add("gxTpr_Productretailprofit_Z");
         state.Add("gxTpr_Productretailprice_Z");
         state.Add("gxTpr_Productwholesaleprofit_Z");
         state.Add("gxTpr_Productwholesaleprice_Z");
         state.Add("gxTpr_Brandid_Z");
         state.Add("gxTpr_Brandname_Z");
         state.Add("gxTpr_Supplierid_Z");
         state.Add("gxTpr_Suppliername_Z");
         state.Add("gxTpr_Sectorid_Z");
         state.Add("gxTpr_Sectorname_Z");
         state.Add("gxTpr_Productstock_Z");
         state.Add("gxTpr_Productminiumstock_Z");
         state.Add("gxTpr_Productdescription_Z");
         state.Add("gxTpr_Productcreateddate_Z_Nullable");
         state.Add("gxTpr_Productmodifieddate_Z_Nullable");
         state.Add("gxTpr_Productminiumquantitywholesale_Z");
         state.Add("gxTpr_Productactive_Z");
         state.Add("gxTpr_Productcode_N");
         state.Add("gxTpr_Productcostprice_N");
         state.Add("gxTpr_Productretailprofit_N");
         state.Add("gxTpr_Productwholesaleprofit_N");
         state.Add("gxTpr_Brandid_N");
         state.Add("gxTpr_Sectorid_N");
         state.Add("gxTpr_Productstock_N");
         state.Add("gxTpr_Productminiumstock_N");
         state.Add("gxTpr_Productdescription_N");
         state.Add("gxTpr_Productminiumquantitywholesale_N");
         state.Add("gxTpr_Productactive_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProduct sdt;
         sdt = (SdtProduct)(source);
         gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         gxTv_SdtProduct_Productcode = sdt.gxTv_SdtProduct_Productcode ;
         gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         gxTv_SdtProduct_Productcostprice = sdt.gxTv_SdtProduct_Productcostprice ;
         gxTv_SdtProduct_Productretailprofit = sdt.gxTv_SdtProduct_Productretailprofit ;
         gxTv_SdtProduct_Productretailprice = sdt.gxTv_SdtProduct_Productretailprice ;
         gxTv_SdtProduct_Productwholesaleprofit = sdt.gxTv_SdtProduct_Productwholesaleprofit ;
         gxTv_SdtProduct_Productwholesaleprice = sdt.gxTv_SdtProduct_Productwholesaleprice ;
         gxTv_SdtProduct_Brandid = sdt.gxTv_SdtProduct_Brandid ;
         gxTv_SdtProduct_Brandname = sdt.gxTv_SdtProduct_Brandname ;
         gxTv_SdtProduct_Supplierid = sdt.gxTv_SdtProduct_Supplierid ;
         gxTv_SdtProduct_Suppliername = sdt.gxTv_SdtProduct_Suppliername ;
         gxTv_SdtProduct_Sectorid = sdt.gxTv_SdtProduct_Sectorid ;
         gxTv_SdtProduct_Sectorname = sdt.gxTv_SdtProduct_Sectorname ;
         gxTv_SdtProduct_Productstock = sdt.gxTv_SdtProduct_Productstock ;
         gxTv_SdtProduct_Productminiumstock = sdt.gxTv_SdtProduct_Productminiumstock ;
         gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         gxTv_SdtProduct_Productcreateddate = sdt.gxTv_SdtProduct_Productcreateddate ;
         gxTv_SdtProduct_Productmodifieddate = sdt.gxTv_SdtProduct_Productmodifieddate ;
         gxTv_SdtProduct_Productminiumquantitywholesale = sdt.gxTv_SdtProduct_Productminiumquantitywholesale ;
         gxTv_SdtProduct_Productactive = sdt.gxTv_SdtProduct_Productactive ;
         gxTv_SdtProduct_Mode = sdt.gxTv_SdtProduct_Mode ;
         gxTv_SdtProduct_Initialized = sdt.gxTv_SdtProduct_Initialized ;
         gxTv_SdtProduct_Productid_Z = sdt.gxTv_SdtProduct_Productid_Z ;
         gxTv_SdtProduct_Productcode_Z = sdt.gxTv_SdtProduct_Productcode_Z ;
         gxTv_SdtProduct_Productname_Z = sdt.gxTv_SdtProduct_Productname_Z ;
         gxTv_SdtProduct_Productcostprice_Z = sdt.gxTv_SdtProduct_Productcostprice_Z ;
         gxTv_SdtProduct_Productretailprofit_Z = sdt.gxTv_SdtProduct_Productretailprofit_Z ;
         gxTv_SdtProduct_Productretailprice_Z = sdt.gxTv_SdtProduct_Productretailprice_Z ;
         gxTv_SdtProduct_Productwholesaleprofit_Z = sdt.gxTv_SdtProduct_Productwholesaleprofit_Z ;
         gxTv_SdtProduct_Productwholesaleprice_Z = sdt.gxTv_SdtProduct_Productwholesaleprice_Z ;
         gxTv_SdtProduct_Brandid_Z = sdt.gxTv_SdtProduct_Brandid_Z ;
         gxTv_SdtProduct_Brandname_Z = sdt.gxTv_SdtProduct_Brandname_Z ;
         gxTv_SdtProduct_Supplierid_Z = sdt.gxTv_SdtProduct_Supplierid_Z ;
         gxTv_SdtProduct_Suppliername_Z = sdt.gxTv_SdtProduct_Suppliername_Z ;
         gxTv_SdtProduct_Sectorid_Z = sdt.gxTv_SdtProduct_Sectorid_Z ;
         gxTv_SdtProduct_Sectorname_Z = sdt.gxTv_SdtProduct_Sectorname_Z ;
         gxTv_SdtProduct_Productstock_Z = sdt.gxTv_SdtProduct_Productstock_Z ;
         gxTv_SdtProduct_Productminiumstock_Z = sdt.gxTv_SdtProduct_Productminiumstock_Z ;
         gxTv_SdtProduct_Productdescription_Z = sdt.gxTv_SdtProduct_Productdescription_Z ;
         gxTv_SdtProduct_Productcreateddate_Z = sdt.gxTv_SdtProduct_Productcreateddate_Z ;
         gxTv_SdtProduct_Productmodifieddate_Z = sdt.gxTv_SdtProduct_Productmodifieddate_Z ;
         gxTv_SdtProduct_Productminiumquantitywholesale_Z = sdt.gxTv_SdtProduct_Productminiumquantitywholesale_Z ;
         gxTv_SdtProduct_Productactive_Z = sdt.gxTv_SdtProduct_Productactive_Z ;
         gxTv_SdtProduct_Productcode_N = sdt.gxTv_SdtProduct_Productcode_N ;
         gxTv_SdtProduct_Productcostprice_N = sdt.gxTv_SdtProduct_Productcostprice_N ;
         gxTv_SdtProduct_Productretailprofit_N = sdt.gxTv_SdtProduct_Productretailprofit_N ;
         gxTv_SdtProduct_Productwholesaleprofit_N = sdt.gxTv_SdtProduct_Productwholesaleprofit_N ;
         gxTv_SdtProduct_Brandid_N = sdt.gxTv_SdtProduct_Brandid_N ;
         gxTv_SdtProduct_Sectorid_N = sdt.gxTv_SdtProduct_Sectorid_N ;
         gxTv_SdtProduct_Productstock_N = sdt.gxTv_SdtProduct_Productstock_N ;
         gxTv_SdtProduct_Productminiumstock_N = sdt.gxTv_SdtProduct_Productminiumstock_N ;
         gxTv_SdtProduct_Productdescription_N = sdt.gxTv_SdtProduct_Productdescription_N ;
         gxTv_SdtProduct_Productminiumquantitywholesale_N = sdt.gxTv_SdtProduct_Productminiumquantitywholesale_N ;
         gxTv_SdtProduct_Productactive_N = sdt.gxTv_SdtProduct_Productactive_N ;
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
         AddObjectProperty("ProductId", gxTv_SdtProduct_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductCode", gxTv_SdtProduct_Productcode, false, includeNonInitialized);
         AddObjectProperty("ProductCode_N", gxTv_SdtProduct_Productcode_N, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtProduct_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductCostPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productcostprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProductCostPrice_N", gxTv_SdtProduct_Productcostprice_N, false, includeNonInitialized);
         AddObjectProperty("ProductRetailProfit", gxTv_SdtProduct_Productretailprofit, false, includeNonInitialized);
         AddObjectProperty("ProductRetailProfit_N", gxTv_SdtProduct_Productretailprofit_N, false, includeNonInitialized);
         AddObjectProperty("ProductRetailPrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productretailprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProductWholesaleProfit", gxTv_SdtProduct_Productwholesaleprofit, false, includeNonInitialized);
         AddObjectProperty("ProductWholesaleProfit_N", gxTv_SdtProduct_Productwholesaleprofit_N, false, includeNonInitialized);
         AddObjectProperty("ProductWholesalePrice", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productwholesaleprice, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BrandId", gxTv_SdtProduct_Brandid, false, includeNonInitialized);
         AddObjectProperty("BrandId_N", gxTv_SdtProduct_Brandid_N, false, includeNonInitialized);
         AddObjectProperty("BrandName", gxTv_SdtProduct_Brandname, false, includeNonInitialized);
         AddObjectProperty("SupplierId", gxTv_SdtProduct_Supplierid, false, includeNonInitialized);
         AddObjectProperty("SupplierName", gxTv_SdtProduct_Suppliername, false, includeNonInitialized);
         AddObjectProperty("SectorId", gxTv_SdtProduct_Sectorid, false, includeNonInitialized);
         AddObjectProperty("SectorId_N", gxTv_SdtProduct_Sectorid_N, false, includeNonInitialized);
         AddObjectProperty("SectorName", gxTv_SdtProduct_Sectorname, false, includeNonInitialized);
         AddObjectProperty("ProductStock", gxTv_SdtProduct_Productstock, false, includeNonInitialized);
         AddObjectProperty("ProductStock_N", gxTv_SdtProduct_Productstock_N, false, includeNonInitialized);
         AddObjectProperty("ProductMiniumStock", gxTv_SdtProduct_Productminiumstock, false, includeNonInitialized);
         AddObjectProperty("ProductMiniumStock_N", gxTv_SdtProduct_Productminiumstock_N, false, includeNonInitialized);
         AddObjectProperty("ProductDescription", gxTv_SdtProduct_Productdescription, false, includeNonInitialized);
         AddObjectProperty("ProductDescription_N", gxTv_SdtProduct_Productdescription_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduct_Productcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduct_Productcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduct_Productcreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProductCreatedDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduct_Productmodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduct_Productmodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduct_Productmodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProductModifiedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProductMiniumQuantityWholesale", gxTv_SdtProduct_Productminiumquantitywholesale, false, includeNonInitialized);
         AddObjectProperty("ProductMiniumQuantityWholesale_N", gxTv_SdtProduct_Productminiumquantitywholesale_N, false, includeNonInitialized);
         AddObjectProperty("ProductActive", gxTv_SdtProduct_Productactive, false, includeNonInitialized);
         AddObjectProperty("ProductActive_N", gxTv_SdtProduct_Productactive_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProduct_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduct_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductId_Z", gxTv_SdtProduct_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCode_Z", gxTv_SdtProduct_Productcode_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtProduct_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCostPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productcostprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProductRetailProfit_Z", gxTv_SdtProduct_Productretailprofit_Z, false, includeNonInitialized);
            AddObjectProperty("ProductRetailPrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productretailprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProductWholesaleProfit_Z", gxTv_SdtProduct_Productwholesaleprofit_Z, false, includeNonInitialized);
            AddObjectProperty("ProductWholesalePrice_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProduct_Productwholesaleprice_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BrandId_Z", gxTv_SdtProduct_Brandid_Z, false, includeNonInitialized);
            AddObjectProperty("BrandName_Z", gxTv_SdtProduct_Brandname_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierId_Z", gxTv_SdtProduct_Supplierid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierName_Z", gxTv_SdtProduct_Suppliername_Z, false, includeNonInitialized);
            AddObjectProperty("SectorId_Z", gxTv_SdtProduct_Sectorid_Z, false, includeNonInitialized);
            AddObjectProperty("SectorName_Z", gxTv_SdtProduct_Sectorname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductStock_Z", gxTv_SdtProduct_Productstock_Z, false, includeNonInitialized);
            AddObjectProperty("ProductMiniumStock_Z", gxTv_SdtProduct_Productminiumstock_Z, false, includeNonInitialized);
            AddObjectProperty("ProductDescription_Z", gxTv_SdtProduct_Productdescription_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduct_Productcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduct_Productcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduct_Productcreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProductCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProduct_Productmodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProduct_Productmodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProduct_Productmodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProductModifiedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProductMiniumQuantityWholesale_Z", gxTv_SdtProduct_Productminiumquantitywholesale_Z, false, includeNonInitialized);
            AddObjectProperty("ProductActive_Z", gxTv_SdtProduct_Productactive_Z, false, includeNonInitialized);
            AddObjectProperty("ProductCode_N", gxTv_SdtProduct_Productcode_N, false, includeNonInitialized);
            AddObjectProperty("ProductCostPrice_N", gxTv_SdtProduct_Productcostprice_N, false, includeNonInitialized);
            AddObjectProperty("ProductRetailProfit_N", gxTv_SdtProduct_Productretailprofit_N, false, includeNonInitialized);
            AddObjectProperty("ProductWholesaleProfit_N", gxTv_SdtProduct_Productwholesaleprofit_N, false, includeNonInitialized);
            AddObjectProperty("BrandId_N", gxTv_SdtProduct_Brandid_N, false, includeNonInitialized);
            AddObjectProperty("SectorId_N", gxTv_SdtProduct_Sectorid_N, false, includeNonInitialized);
            AddObjectProperty("ProductStock_N", gxTv_SdtProduct_Productstock_N, false, includeNonInitialized);
            AddObjectProperty("ProductMiniumStock_N", gxTv_SdtProduct_Productminiumstock_N, false, includeNonInitialized);
            AddObjectProperty("ProductDescription_N", gxTv_SdtProduct_Productdescription_N, false, includeNonInitialized);
            AddObjectProperty("ProductMiniumQuantityWholesale_N", gxTv_SdtProduct_Productminiumquantitywholesale_N, false, includeNonInitialized);
            AddObjectProperty("ProductActive_N", gxTv_SdtProduct_Productactive_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProduct sdt )
      {
         if ( sdt.IsDirty("ProductId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productid = sdt.gxTv_SdtProduct_Productid ;
         }
         if ( sdt.IsDirty("ProductCode") )
         {
            gxTv_SdtProduct_Productcode_N = (short)(sdt.gxTv_SdtProduct_Productcode_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcode = sdt.gxTv_SdtProduct_Productcode ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         }
         if ( sdt.IsDirty("ProductCostPrice") )
         {
            gxTv_SdtProduct_Productcostprice_N = (short)(sdt.gxTv_SdtProduct_Productcostprice_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcostprice = sdt.gxTv_SdtProduct_Productcostprice ;
         }
         if ( sdt.IsDirty("ProductRetailProfit") )
         {
            gxTv_SdtProduct_Productretailprofit_N = (short)(sdt.gxTv_SdtProduct_Productretailprofit_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprofit = sdt.gxTv_SdtProduct_Productretailprofit ;
         }
         if ( sdt.IsDirty("ProductRetailPrice") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprice = sdt.gxTv_SdtProduct_Productretailprice ;
         }
         if ( sdt.IsDirty("ProductWholesaleProfit") )
         {
            gxTv_SdtProduct_Productwholesaleprofit_N = (short)(sdt.gxTv_SdtProduct_Productwholesaleprofit_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprofit = sdt.gxTv_SdtProduct_Productwholesaleprofit ;
         }
         if ( sdt.IsDirty("ProductWholesalePrice") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprice = sdt.gxTv_SdtProduct_Productwholesaleprice ;
         }
         if ( sdt.IsDirty("BrandId") )
         {
            gxTv_SdtProduct_Brandid_N = (short)(sdt.gxTv_SdtProduct_Brandid_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandid = sdt.gxTv_SdtProduct_Brandid ;
         }
         if ( sdt.IsDirty("BrandName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandname = sdt.gxTv_SdtProduct_Brandname ;
         }
         if ( sdt.IsDirty("SupplierId") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Supplierid = sdt.gxTv_SdtProduct_Supplierid ;
         }
         if ( sdt.IsDirty("SupplierName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Suppliername = sdt.gxTv_SdtProduct_Suppliername ;
         }
         if ( sdt.IsDirty("SectorId") )
         {
            gxTv_SdtProduct_Sectorid_N = (short)(sdt.gxTv_SdtProduct_Sectorid_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorid = sdt.gxTv_SdtProduct_Sectorid ;
         }
         if ( sdt.IsDirty("SectorName") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorname = sdt.gxTv_SdtProduct_Sectorname ;
         }
         if ( sdt.IsDirty("ProductStock") )
         {
            gxTv_SdtProduct_Productstock_N = (short)(sdt.gxTv_SdtProduct_Productstock_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productstock = sdt.gxTv_SdtProduct_Productstock ;
         }
         if ( sdt.IsDirty("ProductMiniumStock") )
         {
            gxTv_SdtProduct_Productminiumstock_N = (short)(sdt.gxTv_SdtProduct_Productminiumstock_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumstock = sdt.gxTv_SdtProduct_Productminiumstock ;
         }
         if ( sdt.IsDirty("ProductDescription") )
         {
            gxTv_SdtProduct_Productdescription_N = (short)(sdt.gxTv_SdtProduct_Productdescription_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription = sdt.gxTv_SdtProduct_Productdescription ;
         }
         if ( sdt.IsDirty("ProductCreatedDate") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcreateddate = sdt.gxTv_SdtProduct_Productcreateddate ;
         }
         if ( sdt.IsDirty("ProductModifiedDate") )
         {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productmodifieddate = sdt.gxTv_SdtProduct_Productmodifieddate ;
         }
         if ( sdt.IsDirty("ProductMiniumQuantityWholesale") )
         {
            gxTv_SdtProduct_Productminiumquantitywholesale_N = (short)(sdt.gxTv_SdtProduct_Productminiumquantitywholesale_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumquantitywholesale = sdt.gxTv_SdtProduct_Productminiumquantitywholesale ;
         }
         if ( sdt.IsDirty("ProductActive") )
         {
            gxTv_SdtProduct_Productactive_N = (short)(sdt.gxTv_SdtProduct_Productactive_N);
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productactive = sdt.gxTv_SdtProduct_Productactive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductId" )]
      [  XmlElement( ElementName = "ProductId"   )]
      public int gxTpr_Productid
      {
         get {
            return gxTv_SdtProduct_Productid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if ( gxTv_SdtProduct_Productid != value )
            {
               gxTv_SdtProduct_Mode = "INS";
               this.gxTv_SdtProduct_Productid_Z_SetNull( );
               this.gxTv_SdtProduct_Productcode_Z_SetNull( );
               this.gxTv_SdtProduct_Productname_Z_SetNull( );
               this.gxTv_SdtProduct_Productcostprice_Z_SetNull( );
               this.gxTv_SdtProduct_Productretailprofit_Z_SetNull( );
               this.gxTv_SdtProduct_Productretailprice_Z_SetNull( );
               this.gxTv_SdtProduct_Productwholesaleprofit_Z_SetNull( );
               this.gxTv_SdtProduct_Productwholesaleprice_Z_SetNull( );
               this.gxTv_SdtProduct_Brandid_Z_SetNull( );
               this.gxTv_SdtProduct_Brandname_Z_SetNull( );
               this.gxTv_SdtProduct_Supplierid_Z_SetNull( );
               this.gxTv_SdtProduct_Suppliername_Z_SetNull( );
               this.gxTv_SdtProduct_Sectorid_Z_SetNull( );
               this.gxTv_SdtProduct_Sectorname_Z_SetNull( );
               this.gxTv_SdtProduct_Productstock_Z_SetNull( );
               this.gxTv_SdtProduct_Productminiumstock_Z_SetNull( );
               this.gxTv_SdtProduct_Productdescription_Z_SetNull( );
               this.gxTv_SdtProduct_Productcreateddate_Z_SetNull( );
               this.gxTv_SdtProduct_Productmodifieddate_Z_SetNull( );
               this.gxTv_SdtProduct_Productminiumquantitywholesale_Z_SetNull( );
               this.gxTv_SdtProduct_Productactive_Z_SetNull( );
            }
            gxTv_SdtProduct_Productid = value;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductCode" )]
      [  XmlElement( ElementName = "ProductCode"   )]
      public string gxTpr_Productcode
      {
         get {
            return gxTv_SdtProduct_Productcode ;
         }

         set {
            gxTv_SdtProduct_Productcode_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcode = value;
            SetDirty("Productcode");
         }

      }

      public void gxTv_SdtProduct_Productcode_SetNull( )
      {
         gxTv_SdtProduct_Productcode_N = 1;
         gxTv_SdtProduct_Productcode = "";
         SetDirty("Productcode");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcode_IsNull( )
      {
         return (gxTv_SdtProduct_Productcode_N==1) ;
      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtProduct_Productname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductCostPrice" )]
      [  XmlElement( ElementName = "ProductCostPrice"   )]
      public decimal gxTpr_Productcostprice
      {
         get {
            return gxTv_SdtProduct_Productcostprice ;
         }

         set {
            gxTv_SdtProduct_Productcostprice_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcostprice = value;
            SetDirty("Productcostprice");
         }

      }

      public void gxTv_SdtProduct_Productcostprice_SetNull( )
      {
         gxTv_SdtProduct_Productcostprice_N = 1;
         gxTv_SdtProduct_Productcostprice = 0;
         SetDirty("Productcostprice");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcostprice_IsNull( )
      {
         return (gxTv_SdtProduct_Productcostprice_N==1) ;
      }

      [  SoapElement( ElementName = "ProductRetailProfit" )]
      [  XmlElement( ElementName = "ProductRetailProfit"   )]
      public decimal gxTpr_Productretailprofit
      {
         get {
            return gxTv_SdtProduct_Productretailprofit ;
         }

         set {
            gxTv_SdtProduct_Productretailprofit_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprofit = value;
            SetDirty("Productretailprofit");
         }

      }

      public void gxTv_SdtProduct_Productretailprofit_SetNull( )
      {
         gxTv_SdtProduct_Productretailprofit_N = 1;
         gxTv_SdtProduct_Productretailprofit = 0;
         SetDirty("Productretailprofit");
         return  ;
      }

      public bool gxTv_SdtProduct_Productretailprofit_IsNull( )
      {
         return (gxTv_SdtProduct_Productretailprofit_N==1) ;
      }

      [  SoapElement( ElementName = "ProductRetailPrice" )]
      [  XmlElement( ElementName = "ProductRetailPrice"   )]
      public decimal gxTpr_Productretailprice
      {
         get {
            return gxTv_SdtProduct_Productretailprice ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprice = value;
            SetDirty("Productretailprice");
         }

      }

      public void gxTv_SdtProduct_Productretailprice_SetNull( )
      {
         gxTv_SdtProduct_Productretailprice = 0;
         SetDirty("Productretailprice");
         return  ;
      }

      public bool gxTv_SdtProduct_Productretailprice_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductWholesaleProfit" )]
      [  XmlElement( ElementName = "ProductWholesaleProfit"   )]
      public decimal gxTpr_Productwholesaleprofit
      {
         get {
            return gxTv_SdtProduct_Productwholesaleprofit ;
         }

         set {
            gxTv_SdtProduct_Productwholesaleprofit_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprofit = value;
            SetDirty("Productwholesaleprofit");
         }

      }

      public void gxTv_SdtProduct_Productwholesaleprofit_SetNull( )
      {
         gxTv_SdtProduct_Productwholesaleprofit_N = 1;
         gxTv_SdtProduct_Productwholesaleprofit = 0;
         SetDirty("Productwholesaleprofit");
         return  ;
      }

      public bool gxTv_SdtProduct_Productwholesaleprofit_IsNull( )
      {
         return (gxTv_SdtProduct_Productwholesaleprofit_N==1) ;
      }

      [  SoapElement( ElementName = "ProductWholesalePrice" )]
      [  XmlElement( ElementName = "ProductWholesalePrice"   )]
      public decimal gxTpr_Productwholesaleprice
      {
         get {
            return gxTv_SdtProduct_Productwholesaleprice ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprice = value;
            SetDirty("Productwholesaleprice");
         }

      }

      public void gxTv_SdtProduct_Productwholesaleprice_SetNull( )
      {
         gxTv_SdtProduct_Productwholesaleprice = 0;
         SetDirty("Productwholesaleprice");
         return  ;
      }

      public bool gxTv_SdtProduct_Productwholesaleprice_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BrandId" )]
      [  XmlElement( ElementName = "BrandId"   )]
      public int gxTpr_Brandid
      {
         get {
            return gxTv_SdtProduct_Brandid ;
         }

         set {
            gxTv_SdtProduct_Brandid_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandid = value;
            SetDirty("Brandid");
         }

      }

      public void gxTv_SdtProduct_Brandid_SetNull( )
      {
         gxTv_SdtProduct_Brandid_N = 1;
         gxTv_SdtProduct_Brandid = 0;
         SetDirty("Brandid");
         return  ;
      }

      public bool gxTv_SdtProduct_Brandid_IsNull( )
      {
         return (gxTv_SdtProduct_Brandid_N==1) ;
      }

      [  SoapElement( ElementName = "BrandName" )]
      [  XmlElement( ElementName = "BrandName"   )]
      public string gxTpr_Brandname
      {
         get {
            return gxTv_SdtProduct_Brandname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandname = value;
            SetDirty("Brandname");
         }

      }

      [  SoapElement( ElementName = "SupplierId" )]
      [  XmlElement( ElementName = "SupplierId"   )]
      public int gxTpr_Supplierid
      {
         get {
            return gxTv_SdtProduct_Supplierid ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Supplierid = value;
            SetDirty("Supplierid");
         }

      }

      [  SoapElement( ElementName = "SupplierName" )]
      [  XmlElement( ElementName = "SupplierName"   )]
      public string gxTpr_Suppliername
      {
         get {
            return gxTv_SdtProduct_Suppliername ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Suppliername = value;
            SetDirty("Suppliername");
         }

      }

      [  SoapElement( ElementName = "SectorId" )]
      [  XmlElement( ElementName = "SectorId"   )]
      public int gxTpr_Sectorid
      {
         get {
            return gxTv_SdtProduct_Sectorid ;
         }

         set {
            gxTv_SdtProduct_Sectorid_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorid = value;
            SetDirty("Sectorid");
         }

      }

      public void gxTv_SdtProduct_Sectorid_SetNull( )
      {
         gxTv_SdtProduct_Sectorid_N = 1;
         gxTv_SdtProduct_Sectorid = 0;
         SetDirty("Sectorid");
         return  ;
      }

      public bool gxTv_SdtProduct_Sectorid_IsNull( )
      {
         return (gxTv_SdtProduct_Sectorid_N==1) ;
      }

      [  SoapElement( ElementName = "SectorName" )]
      [  XmlElement( ElementName = "SectorName"   )]
      public string gxTpr_Sectorname
      {
         get {
            return gxTv_SdtProduct_Sectorname ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorname = value;
            SetDirty("Sectorname");
         }

      }

      [  SoapElement( ElementName = "ProductStock" )]
      [  XmlElement( ElementName = "ProductStock"   )]
      public int gxTpr_Productstock
      {
         get {
            return gxTv_SdtProduct_Productstock ;
         }

         set {
            gxTv_SdtProduct_Productstock_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productstock = value;
            SetDirty("Productstock");
         }

      }

      public void gxTv_SdtProduct_Productstock_SetNull( )
      {
         gxTv_SdtProduct_Productstock_N = 1;
         gxTv_SdtProduct_Productstock = 0;
         SetDirty("Productstock");
         return  ;
      }

      public bool gxTv_SdtProduct_Productstock_IsNull( )
      {
         return (gxTv_SdtProduct_Productstock_N==1) ;
      }

      [  SoapElement( ElementName = "ProductMiniumStock" )]
      [  XmlElement( ElementName = "ProductMiniumStock"   )]
      public int gxTpr_Productminiumstock
      {
         get {
            return gxTv_SdtProduct_Productminiumstock ;
         }

         set {
            gxTv_SdtProduct_Productminiumstock_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumstock = value;
            SetDirty("Productminiumstock");
         }

      }

      public void gxTv_SdtProduct_Productminiumstock_SetNull( )
      {
         gxTv_SdtProduct_Productminiumstock_N = 1;
         gxTv_SdtProduct_Productminiumstock = 0;
         SetDirty("Productminiumstock");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumstock_IsNull( )
      {
         return (gxTv_SdtProduct_Productminiumstock_N==1) ;
      }

      [  SoapElement( ElementName = "ProductDescription" )]
      [  XmlElement( ElementName = "ProductDescription"   )]
      public string gxTpr_Productdescription
      {
         get {
            return gxTv_SdtProduct_Productdescription ;
         }

         set {
            gxTv_SdtProduct_Productdescription_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription = value;
            SetDirty("Productdescription");
         }

      }

      public void gxTv_SdtProduct_Productdescription_SetNull( )
      {
         gxTv_SdtProduct_Productdescription_N = 1;
         gxTv_SdtProduct_Productdescription = "";
         SetDirty("Productdescription");
         return  ;
      }

      public bool gxTv_SdtProduct_Productdescription_IsNull( )
      {
         return (gxTv_SdtProduct_Productdescription_N==1) ;
      }

      [  SoapElement( ElementName = "ProductCreatedDate" )]
      [  XmlElement( ElementName = "ProductCreatedDate"  , IsNullable=true )]
      public string gxTpr_Productcreateddate_Nullable
      {
         get {
            if ( gxTv_SdtProduct_Productcreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduct_Productcreateddate).value ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduct_Productcreateddate = DateTime.MinValue;
            else
               gxTv_SdtProduct_Productcreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Productcreateddate
      {
         get {
            return gxTv_SdtProduct_Productcreateddate ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcreateddate = value;
            SetDirty("Productcreateddate");
         }

      }

      [  SoapElement( ElementName = "ProductModifiedDate" )]
      [  XmlElement( ElementName = "ProductModifiedDate"  , IsNullable=true )]
      public string gxTpr_Productmodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtProduct_Productmodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduct_Productmodifieddate).value ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduct_Productmodifieddate = DateTime.MinValue;
            else
               gxTv_SdtProduct_Productmodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Productmodifieddate
      {
         get {
            return gxTv_SdtProduct_Productmodifieddate ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productmodifieddate = value;
            SetDirty("Productmodifieddate");
         }

      }

      [  SoapElement( ElementName = "ProductMiniumQuantityWholesale" )]
      [  XmlElement( ElementName = "ProductMiniumQuantityWholesale"   )]
      public short gxTpr_Productminiumquantitywholesale
      {
         get {
            return gxTv_SdtProduct_Productminiumquantitywholesale ;
         }

         set {
            gxTv_SdtProduct_Productminiumquantitywholesale_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumquantitywholesale = value;
            SetDirty("Productminiumquantitywholesale");
         }

      }

      public void gxTv_SdtProduct_Productminiumquantitywholesale_SetNull( )
      {
         gxTv_SdtProduct_Productminiumquantitywholesale_N = 1;
         gxTv_SdtProduct_Productminiumquantitywholesale = 0;
         SetDirty("Productminiumquantitywholesale");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumquantitywholesale_IsNull( )
      {
         return (gxTv_SdtProduct_Productminiumquantitywholesale_N==1) ;
      }

      [  SoapElement( ElementName = "ProductActive" )]
      [  XmlElement( ElementName = "ProductActive"   )]
      public bool gxTpr_Productactive
      {
         get {
            return gxTv_SdtProduct_Productactive ;
         }

         set {
            gxTv_SdtProduct_Productactive_N = 0;
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productactive = value;
            SetDirty("Productactive");
         }

      }

      public void gxTv_SdtProduct_Productactive_SetNull( )
      {
         gxTv_SdtProduct_Productactive_N = 1;
         gxTv_SdtProduct_Productactive = false;
         SetDirty("Productactive");
         return  ;
      }

      public bool gxTv_SdtProduct_Productactive_IsNull( )
      {
         return (gxTv_SdtProduct_Productactive_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduct_Mode ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduct_Mode_SetNull( )
      {
         gxTv_SdtProduct_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduct_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduct_Initialized ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduct_Initialized_SetNull( )
      {
         gxTv_SdtProduct_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduct_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductId_Z" )]
      [  XmlElement( ElementName = "ProductId_Z"   )]
      public int gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtProduct_Productid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productid_Z = value;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtProduct_Productid_Z_SetNull( )
      {
         gxTv_SdtProduct_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCode_Z" )]
      [  XmlElement( ElementName = "ProductCode_Z"   )]
      public string gxTpr_Productcode_Z
      {
         get {
            return gxTv_SdtProduct_Productcode_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcode_Z = value;
            SetDirty("Productcode_Z");
         }

      }

      public void gxTv_SdtProduct_Productcode_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcode_Z = "";
         SetDirty("Productcode_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtProduct_Productname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productname_Z = value;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtProduct_Productname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCostPrice_Z" )]
      [  XmlElement( ElementName = "ProductCostPrice_Z"   )]
      public decimal gxTpr_Productcostprice_Z
      {
         get {
            return gxTv_SdtProduct_Productcostprice_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcostprice_Z = value;
            SetDirty("Productcostprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productcostprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcostprice_Z = 0;
         SetDirty("Productcostprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcostprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductRetailProfit_Z" )]
      [  XmlElement( ElementName = "ProductRetailProfit_Z"   )]
      public decimal gxTpr_Productretailprofit_Z
      {
         get {
            return gxTv_SdtProduct_Productretailprofit_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprofit_Z = value;
            SetDirty("Productretailprofit_Z");
         }

      }

      public void gxTv_SdtProduct_Productretailprofit_Z_SetNull( )
      {
         gxTv_SdtProduct_Productretailprofit_Z = 0;
         SetDirty("Productretailprofit_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productretailprofit_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductRetailPrice_Z" )]
      [  XmlElement( ElementName = "ProductRetailPrice_Z"   )]
      public decimal gxTpr_Productretailprice_Z
      {
         get {
            return gxTv_SdtProduct_Productretailprice_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprice_Z = value;
            SetDirty("Productretailprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productretailprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productretailprice_Z = 0;
         SetDirty("Productretailprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productretailprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductWholesaleProfit_Z" )]
      [  XmlElement( ElementName = "ProductWholesaleProfit_Z"   )]
      public decimal gxTpr_Productwholesaleprofit_Z
      {
         get {
            return gxTv_SdtProduct_Productwholesaleprofit_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprofit_Z = value;
            SetDirty("Productwholesaleprofit_Z");
         }

      }

      public void gxTv_SdtProduct_Productwholesaleprofit_Z_SetNull( )
      {
         gxTv_SdtProduct_Productwholesaleprofit_Z = 0;
         SetDirty("Productwholesaleprofit_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productwholesaleprofit_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductWholesalePrice_Z" )]
      [  XmlElement( ElementName = "ProductWholesalePrice_Z"   )]
      public decimal gxTpr_Productwholesaleprice_Z
      {
         get {
            return gxTv_SdtProduct_Productwholesaleprice_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprice_Z = value;
            SetDirty("Productwholesaleprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productwholesaleprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productwholesaleprice_Z = 0;
         SetDirty("Productwholesaleprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productwholesaleprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BrandId_Z" )]
      [  XmlElement( ElementName = "BrandId_Z"   )]
      public int gxTpr_Brandid_Z
      {
         get {
            return gxTv_SdtProduct_Brandid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandid_Z = value;
            SetDirty("Brandid_Z");
         }

      }

      public void gxTv_SdtProduct_Brandid_Z_SetNull( )
      {
         gxTv_SdtProduct_Brandid_Z = 0;
         SetDirty("Brandid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Brandid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BrandName_Z" )]
      [  XmlElement( ElementName = "BrandName_Z"   )]
      public string gxTpr_Brandname_Z
      {
         get {
            return gxTv_SdtProduct_Brandname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandname_Z = value;
            SetDirty("Brandname_Z");
         }

      }

      public void gxTv_SdtProduct_Brandname_Z_SetNull( )
      {
         gxTv_SdtProduct_Brandname_Z = "";
         SetDirty("Brandname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Brandname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierId_Z" )]
      [  XmlElement( ElementName = "SupplierId_Z"   )]
      public int gxTpr_Supplierid_Z
      {
         get {
            return gxTv_SdtProduct_Supplierid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Supplierid_Z = value;
            SetDirty("Supplierid_Z");
         }

      }

      public void gxTv_SdtProduct_Supplierid_Z_SetNull( )
      {
         gxTv_SdtProduct_Supplierid_Z = 0;
         SetDirty("Supplierid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Supplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierName_Z" )]
      [  XmlElement( ElementName = "SupplierName_Z"   )]
      public string gxTpr_Suppliername_Z
      {
         get {
            return gxTv_SdtProduct_Suppliername_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Suppliername_Z = value;
            SetDirty("Suppliername_Z");
         }

      }

      public void gxTv_SdtProduct_Suppliername_Z_SetNull( )
      {
         gxTv_SdtProduct_Suppliername_Z = "";
         SetDirty("Suppliername_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Suppliername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_Z" )]
      [  XmlElement( ElementName = "SectorId_Z"   )]
      public int gxTpr_Sectorid_Z
      {
         get {
            return gxTv_SdtProduct_Sectorid_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorid_Z = value;
            SetDirty("Sectorid_Z");
         }

      }

      public void gxTv_SdtProduct_Sectorid_Z_SetNull( )
      {
         gxTv_SdtProduct_Sectorid_Z = 0;
         SetDirty("Sectorid_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorName_Z" )]
      [  XmlElement( ElementName = "SectorName_Z"   )]
      public string gxTpr_Sectorname_Z
      {
         get {
            return gxTv_SdtProduct_Sectorname_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorname_Z = value;
            SetDirty("Sectorname_Z");
         }

      }

      public void gxTv_SdtProduct_Sectorname_Z_SetNull( )
      {
         gxTv_SdtProduct_Sectorname_Z = "";
         SetDirty("Sectorname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Sectorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_Z" )]
      [  XmlElement( ElementName = "ProductStock_Z"   )]
      public int gxTpr_Productstock_Z
      {
         get {
            return gxTv_SdtProduct_Productstock_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productstock_Z = value;
            SetDirty("Productstock_Z");
         }

      }

      public void gxTv_SdtProduct_Productstock_Z_SetNull( )
      {
         gxTv_SdtProduct_Productstock_Z = 0;
         SetDirty("Productstock_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productstock_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductMiniumStock_Z" )]
      [  XmlElement( ElementName = "ProductMiniumStock_Z"   )]
      public int gxTpr_Productminiumstock_Z
      {
         get {
            return gxTv_SdtProduct_Productminiumstock_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumstock_Z = value;
            SetDirty("Productminiumstock_Z");
         }

      }

      public void gxTv_SdtProduct_Productminiumstock_Z_SetNull( )
      {
         gxTv_SdtProduct_Productminiumstock_Z = 0;
         SetDirty("Productminiumstock_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumstock_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductDescription_Z" )]
      [  XmlElement( ElementName = "ProductDescription_Z"   )]
      public string gxTpr_Productdescription_Z
      {
         get {
            return gxTv_SdtProduct_Productdescription_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription_Z = value;
            SetDirty("Productdescription_Z");
         }

      }

      public void gxTv_SdtProduct_Productdescription_Z_SetNull( )
      {
         gxTv_SdtProduct_Productdescription_Z = "";
         SetDirty("Productdescription_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCreatedDate_Z" )]
      [  XmlElement( ElementName = "ProductCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Productcreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduct_Productcreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduct_Productcreateddate_Z).value ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduct_Productcreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtProduct_Productcreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Productcreateddate_Z
      {
         get {
            return gxTv_SdtProduct_Productcreateddate_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcreateddate_Z = value;
            SetDirty("Productcreateddate_Z");
         }

      }

      public void gxTv_SdtProduct_Productcreateddate_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Productcreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductModifiedDate_Z" )]
      [  XmlElement( ElementName = "ProductModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Productmodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtProduct_Productmodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProduct_Productmodifieddate_Z).value ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProduct_Productmodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtProduct_Productmodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Productmodifieddate_Z
      {
         get {
            return gxTv_SdtProduct_Productmodifieddate_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productmodifieddate_Z = value;
            SetDirty("Productmodifieddate_Z");
         }

      }

      public void gxTv_SdtProduct_Productmodifieddate_Z_SetNull( )
      {
         gxTv_SdtProduct_Productmodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Productmodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productmodifieddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductMiniumQuantityWholesale_Z" )]
      [  XmlElement( ElementName = "ProductMiniumQuantityWholesale_Z"   )]
      public short gxTpr_Productminiumquantitywholesale_Z
      {
         get {
            return gxTv_SdtProduct_Productminiumquantitywholesale_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumquantitywholesale_Z = value;
            SetDirty("Productminiumquantitywholesale_Z");
         }

      }

      public void gxTv_SdtProduct_Productminiumquantitywholesale_Z_SetNull( )
      {
         gxTv_SdtProduct_Productminiumquantitywholesale_Z = 0;
         SetDirty("Productminiumquantitywholesale_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumquantitywholesale_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductActive_Z" )]
      [  XmlElement( ElementName = "ProductActive_Z"   )]
      public bool gxTpr_Productactive_Z
      {
         get {
            return gxTv_SdtProduct_Productactive_Z ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productactive_Z = value;
            SetDirty("Productactive_Z");
         }

      }

      public void gxTv_SdtProduct_Productactive_Z_SetNull( )
      {
         gxTv_SdtProduct_Productactive_Z = false;
         SetDirty("Productactive_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCode_N" )]
      [  XmlElement( ElementName = "ProductCode_N"   )]
      public short gxTpr_Productcode_N
      {
         get {
            return gxTv_SdtProduct_Productcode_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcode_N = value;
            SetDirty("Productcode_N");
         }

      }

      public void gxTv_SdtProduct_Productcode_N_SetNull( )
      {
         gxTv_SdtProduct_Productcode_N = 0;
         SetDirty("Productcode_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcode_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCostPrice_N" )]
      [  XmlElement( ElementName = "ProductCostPrice_N"   )]
      public short gxTpr_Productcostprice_N
      {
         get {
            return gxTv_SdtProduct_Productcostprice_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productcostprice_N = value;
            SetDirty("Productcostprice_N");
         }

      }

      public void gxTv_SdtProduct_Productcostprice_N_SetNull( )
      {
         gxTv_SdtProduct_Productcostprice_N = 0;
         SetDirty("Productcostprice_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcostprice_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductRetailProfit_N" )]
      [  XmlElement( ElementName = "ProductRetailProfit_N"   )]
      public short gxTpr_Productretailprofit_N
      {
         get {
            return gxTv_SdtProduct_Productretailprofit_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productretailprofit_N = value;
            SetDirty("Productretailprofit_N");
         }

      }

      public void gxTv_SdtProduct_Productretailprofit_N_SetNull( )
      {
         gxTv_SdtProduct_Productretailprofit_N = 0;
         SetDirty("Productretailprofit_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productretailprofit_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductWholesaleProfit_N" )]
      [  XmlElement( ElementName = "ProductWholesaleProfit_N"   )]
      public short gxTpr_Productwholesaleprofit_N
      {
         get {
            return gxTv_SdtProduct_Productwholesaleprofit_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productwholesaleprofit_N = value;
            SetDirty("Productwholesaleprofit_N");
         }

      }

      public void gxTv_SdtProduct_Productwholesaleprofit_N_SetNull( )
      {
         gxTv_SdtProduct_Productwholesaleprofit_N = 0;
         SetDirty("Productwholesaleprofit_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productwholesaleprofit_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BrandId_N" )]
      [  XmlElement( ElementName = "BrandId_N"   )]
      public short gxTpr_Brandid_N
      {
         get {
            return gxTv_SdtProduct_Brandid_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Brandid_N = value;
            SetDirty("Brandid_N");
         }

      }

      public void gxTv_SdtProduct_Brandid_N_SetNull( )
      {
         gxTv_SdtProduct_Brandid_N = 0;
         SetDirty("Brandid_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Brandid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SectorId_N" )]
      [  XmlElement( ElementName = "SectorId_N"   )]
      public short gxTpr_Sectorid_N
      {
         get {
            return gxTv_SdtProduct_Sectorid_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Sectorid_N = value;
            SetDirty("Sectorid_N");
         }

      }

      public void gxTv_SdtProduct_Sectorid_N_SetNull( )
      {
         gxTv_SdtProduct_Sectorid_N = 0;
         SetDirty("Sectorid_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Sectorid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_N" )]
      [  XmlElement( ElementName = "ProductStock_N"   )]
      public short gxTpr_Productstock_N
      {
         get {
            return gxTv_SdtProduct_Productstock_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productstock_N = value;
            SetDirty("Productstock_N");
         }

      }

      public void gxTv_SdtProduct_Productstock_N_SetNull( )
      {
         gxTv_SdtProduct_Productstock_N = 0;
         SetDirty("Productstock_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productstock_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductMiniumStock_N" )]
      [  XmlElement( ElementName = "ProductMiniumStock_N"   )]
      public short gxTpr_Productminiumstock_N
      {
         get {
            return gxTv_SdtProduct_Productminiumstock_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumstock_N = value;
            SetDirty("Productminiumstock_N");
         }

      }

      public void gxTv_SdtProduct_Productminiumstock_N_SetNull( )
      {
         gxTv_SdtProduct_Productminiumstock_N = 0;
         SetDirty("Productminiumstock_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumstock_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductDescription_N" )]
      [  XmlElement( ElementName = "ProductDescription_N"   )]
      public short gxTpr_Productdescription_N
      {
         get {
            return gxTv_SdtProduct_Productdescription_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productdescription_N = value;
            SetDirty("Productdescription_N");
         }

      }

      public void gxTv_SdtProduct_Productdescription_N_SetNull( )
      {
         gxTv_SdtProduct_Productdescription_N = 0;
         SetDirty("Productdescription_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productdescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductMiniumQuantityWholesale_N" )]
      [  XmlElement( ElementName = "ProductMiniumQuantityWholesale_N"   )]
      public short gxTpr_Productminiumquantitywholesale_N
      {
         get {
            return gxTv_SdtProduct_Productminiumquantitywholesale_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productminiumquantitywholesale_N = value;
            SetDirty("Productminiumquantitywholesale_N");
         }

      }

      public void gxTv_SdtProduct_Productminiumquantitywholesale_N_SetNull( )
      {
         gxTv_SdtProduct_Productminiumquantitywholesale_N = 0;
         SetDirty("Productminiumquantitywholesale_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productminiumquantitywholesale_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductActive_N" )]
      [  XmlElement( ElementName = "ProductActive_N"   )]
      public short gxTpr_Productactive_N
      {
         get {
            return gxTv_SdtProduct_Productactive_N ;
         }

         set {
            gxTv_SdtProduct_N = 0;
            gxTv_SdtProduct_Productactive_N = value;
            SetDirty("Productactive_N");
         }

      }

      public void gxTv_SdtProduct_Productactive_N_SetNull( )
      {
         gxTv_SdtProduct_Productactive_N = 0;
         SetDirty("Productactive_N");
         return  ;
      }

      public bool gxTv_SdtProduct_Productactive_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProduct_N = 1;
         gxTv_SdtProduct_Productcode = "";
         gxTv_SdtProduct_Productname = "";
         gxTv_SdtProduct_Brandname = "";
         gxTv_SdtProduct_Suppliername = "";
         gxTv_SdtProduct_Sectorname = "";
         gxTv_SdtProduct_Productdescription = "";
         gxTv_SdtProduct_Productcreateddate = DateTime.MinValue;
         gxTv_SdtProduct_Productmodifieddate = DateTime.MinValue;
         gxTv_SdtProduct_Mode = "";
         gxTv_SdtProduct_Productcode_Z = "";
         gxTv_SdtProduct_Productname_Z = "";
         gxTv_SdtProduct_Brandname_Z = "";
         gxTv_SdtProduct_Suppliername_Z = "";
         gxTv_SdtProduct_Sectorname_Z = "";
         gxTv_SdtProduct_Productdescription_Z = "";
         gxTv_SdtProduct_Productcreateddate_Z = DateTime.MinValue;
         gxTv_SdtProduct_Productmodifieddate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "product", "GeneXus.Programs.product_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtProduct_N ;
      }

      private short gxTv_SdtProduct_N ;
      private short gxTv_SdtProduct_Productminiumquantitywholesale ;
      private short gxTv_SdtProduct_Initialized ;
      private short gxTv_SdtProduct_Productminiumquantitywholesale_Z ;
      private short gxTv_SdtProduct_Productcode_N ;
      private short gxTv_SdtProduct_Productcostprice_N ;
      private short gxTv_SdtProduct_Productretailprofit_N ;
      private short gxTv_SdtProduct_Productwholesaleprofit_N ;
      private short gxTv_SdtProduct_Brandid_N ;
      private short gxTv_SdtProduct_Sectorid_N ;
      private short gxTv_SdtProduct_Productstock_N ;
      private short gxTv_SdtProduct_Productminiumstock_N ;
      private short gxTv_SdtProduct_Productdescription_N ;
      private short gxTv_SdtProduct_Productminiumquantitywholesale_N ;
      private short gxTv_SdtProduct_Productactive_N ;
      private int gxTv_SdtProduct_Productid ;
      private int gxTv_SdtProduct_Brandid ;
      private int gxTv_SdtProduct_Supplierid ;
      private int gxTv_SdtProduct_Sectorid ;
      private int gxTv_SdtProduct_Productstock ;
      private int gxTv_SdtProduct_Productminiumstock ;
      private int gxTv_SdtProduct_Productid_Z ;
      private int gxTv_SdtProduct_Brandid_Z ;
      private int gxTv_SdtProduct_Supplierid_Z ;
      private int gxTv_SdtProduct_Sectorid_Z ;
      private int gxTv_SdtProduct_Productstock_Z ;
      private int gxTv_SdtProduct_Productminiumstock_Z ;
      private decimal gxTv_SdtProduct_Productcostprice ;
      private decimal gxTv_SdtProduct_Productretailprofit ;
      private decimal gxTv_SdtProduct_Productretailprice ;
      private decimal gxTv_SdtProduct_Productwholesaleprofit ;
      private decimal gxTv_SdtProduct_Productwholesaleprice ;
      private decimal gxTv_SdtProduct_Productcostprice_Z ;
      private decimal gxTv_SdtProduct_Productretailprofit_Z ;
      private decimal gxTv_SdtProduct_Productretailprice_Z ;
      private decimal gxTv_SdtProduct_Productwholesaleprofit_Z ;
      private decimal gxTv_SdtProduct_Productwholesaleprice_Z ;
      private string gxTv_SdtProduct_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProduct_Productcreateddate ;
      private DateTime gxTv_SdtProduct_Productmodifieddate ;
      private DateTime gxTv_SdtProduct_Productcreateddate_Z ;
      private DateTime gxTv_SdtProduct_Productmodifieddate_Z ;
      private bool gxTv_SdtProduct_Productactive ;
      private bool gxTv_SdtProduct_Productactive_Z ;
      private string gxTv_SdtProduct_Productcode ;
      private string gxTv_SdtProduct_Productname ;
      private string gxTv_SdtProduct_Brandname ;
      private string gxTv_SdtProduct_Suppliername ;
      private string gxTv_SdtProduct_Sectorname ;
      private string gxTv_SdtProduct_Productdescription ;
      private string gxTv_SdtProduct_Productcode_Z ;
      private string gxTv_SdtProduct_Productname_Z ;
      private string gxTv_SdtProduct_Brandname_Z ;
      private string gxTv_SdtProduct_Suppliername_Z ;
      private string gxTv_SdtProduct_Sectorname_Z ;
      private string gxTv_SdtProduct_Productdescription_Z ;
   }

   [DataContract(Name = @"Product", Namespace = "mtaKB")]
   public class SdtProduct_RESTInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTInterface( ) : base()
      {
      }

      public SdtProduct_RESTInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Productid
      {
         get {
            return sdt.gxTpr_Productid ;
         }

         set {
            sdt.gxTpr_Productid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductCode" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productcode
      {
         get {
            return sdt.gxTpr_Productcode ;
         }

         set {
            sdt.gxTpr_Productcode = value;
         }

      }

      [DataMember( Name = "ProductName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return sdt.gxTpr_Productname ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductCostPrice" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Productcostprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productcostprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Productcostprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductRetailProfit" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Productretailprofit
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productretailprofit, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Productretailprofit = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductRetailPrice" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Productretailprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productretailprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Productretailprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductWholesaleProfit" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Productwholesaleprofit
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productwholesaleprofit, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Productwholesaleprofit = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductWholesalePrice" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Productwholesaleprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productwholesaleprice, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Productwholesaleprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BrandId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Brandid
      {
         get {
            return sdt.gxTpr_Brandid ;
         }

         set {
            sdt.gxTpr_Brandid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "BrandName" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Brandname
      {
         get {
            return sdt.gxTpr_Brandname ;
         }

         set {
            sdt.gxTpr_Brandname = value;
         }

      }

      [DataMember( Name = "SupplierId" , Order = 10 )]
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

      [DataMember( Name = "SupplierName" , Order = 11 )]
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

      [DataMember( Name = "SectorId" , Order = 12 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Sectorid
      {
         get {
            return sdt.gxTpr_Sectorid ;
         }

         set {
            sdt.gxTpr_Sectorid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SectorName" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Sectorname
      {
         get {
            return sdt.gxTpr_Sectorname ;
         }

         set {
            sdt.gxTpr_Sectorname = value;
         }

      }

      [DataMember( Name = "ProductStock" , Order = 14 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Productstock
      {
         get {
            return sdt.gxTpr_Productstock ;
         }

         set {
            sdt.gxTpr_Productstock = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductMiniumStock" , Order = 15 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Productminiumstock
      {
         get {
            return sdt.gxTpr_Productminiumstock ;
         }

         set {
            sdt.gxTpr_Productminiumstock = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductDescription" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Productdescription
      {
         get {
            return sdt.gxTpr_Productdescription ;
         }

         set {
            sdt.gxTpr_Productdescription = value;
         }

      }

      [DataMember( Name = "ProductCreatedDate" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Productcreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Productcreateddate) ;
         }

         set {
            sdt.gxTpr_Productcreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ProductModifiedDate" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Productmodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Productmodifieddate) ;
         }

         set {
            sdt.gxTpr_Productmodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ProductMiniumQuantityWholesale" , Order = 19 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productminiumquantitywholesale
      {
         get {
            return sdt.gxTpr_Productminiumquantitywholesale ;
         }

         set {
            sdt.gxTpr_Productminiumquantitywholesale = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductActive" , Order = 20 )]
      [GxSeudo()]
      public bool gxTpr_Productactive
      {
         get {
            return sdt.gxTpr_Productactive ;
         }

         set {
            sdt.gxTpr_Productactive = value;
         }

      }

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 21 )]
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

   [DataContract(Name = @"Product", Namespace = "mtaKB")]
   public class SdtProduct_RESTLInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTLInterface( ) : base()
      {
      }

      public SdtProduct_RESTLInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return sdt.gxTpr_Productname ;
         }

         set {
            sdt.gxTpr_Productname = value;
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

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
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
            sdt = new SdtProduct() ;
         }
      }

   }

}
