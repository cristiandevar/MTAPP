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
   [XmlRoot(ElementName = "Supplier" )]
   [XmlType(TypeName =  "Supplier" , Namespace = "mtaKB" )]
   [Serializable]
   public class SdtSupplier : GxSilentTrnSdt
   {
      public SdtSupplier( )
      {
      }

      public SdtSupplier( IGxContext context )
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

      public void Load( int AV4SupplierId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV4SupplierId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Supplier");
         metadata.Set("BT", "Supplier");
         metadata.Set("PK", "[ \"SupplierId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierId\" ]");
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
         state.Add("gxTpr_Supplierid_Z");
         state.Add("gxTpr_Suppliername_Z");
         state.Add("gxTpr_Supplierdescription_Z");
         state.Add("gxTpr_Supplierphone_Z");
         state.Add("gxTpr_Supplieremail_Z");
         state.Add("gxTpr_Suppliercreateddate_Z_Nullable");
         state.Add("gxTpr_Suppliermodifieddate_Z_Nullable");
         state.Add("gxTpr_Supplierproductquantity_Z");
         state.Add("gxTpr_Supplieractive_Z");
         state.Add("gxTpr_Supplierdescription_N");
         state.Add("gxTpr_Supplierphone_N");
         state.Add("gxTpr_Supplieremail_N");
         state.Add("gxTpr_Supplierproductquantity_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSupplier sdt;
         sdt = (SdtSupplier)(source);
         gxTv_SdtSupplier_Supplierid = sdt.gxTv_SdtSupplier_Supplierid ;
         gxTv_SdtSupplier_Suppliername = sdt.gxTv_SdtSupplier_Suppliername ;
         gxTv_SdtSupplier_Supplierdescription = sdt.gxTv_SdtSupplier_Supplierdescription ;
         gxTv_SdtSupplier_Supplierphone = sdt.gxTv_SdtSupplier_Supplierphone ;
         gxTv_SdtSupplier_Supplieremail = sdt.gxTv_SdtSupplier_Supplieremail ;
         gxTv_SdtSupplier_Suppliercreateddate = sdt.gxTv_SdtSupplier_Suppliercreateddate ;
         gxTv_SdtSupplier_Suppliermodifieddate = sdt.gxTv_SdtSupplier_Suppliermodifieddate ;
         gxTv_SdtSupplier_Supplierproductquantity = sdt.gxTv_SdtSupplier_Supplierproductquantity ;
         gxTv_SdtSupplier_Supplieractive = sdt.gxTv_SdtSupplier_Supplieractive ;
         gxTv_SdtSupplier_Mode = sdt.gxTv_SdtSupplier_Mode ;
         gxTv_SdtSupplier_Initialized = sdt.gxTv_SdtSupplier_Initialized ;
         gxTv_SdtSupplier_Supplierid_Z = sdt.gxTv_SdtSupplier_Supplierid_Z ;
         gxTv_SdtSupplier_Suppliername_Z = sdt.gxTv_SdtSupplier_Suppliername_Z ;
         gxTv_SdtSupplier_Supplierdescription_Z = sdt.gxTv_SdtSupplier_Supplierdescription_Z ;
         gxTv_SdtSupplier_Supplierphone_Z = sdt.gxTv_SdtSupplier_Supplierphone_Z ;
         gxTv_SdtSupplier_Supplieremail_Z = sdt.gxTv_SdtSupplier_Supplieremail_Z ;
         gxTv_SdtSupplier_Suppliercreateddate_Z = sdt.gxTv_SdtSupplier_Suppliercreateddate_Z ;
         gxTv_SdtSupplier_Suppliermodifieddate_Z = sdt.gxTv_SdtSupplier_Suppliermodifieddate_Z ;
         gxTv_SdtSupplier_Supplierproductquantity_Z = sdt.gxTv_SdtSupplier_Supplierproductquantity_Z ;
         gxTv_SdtSupplier_Supplieractive_Z = sdt.gxTv_SdtSupplier_Supplieractive_Z ;
         gxTv_SdtSupplier_Supplierdescription_N = sdt.gxTv_SdtSupplier_Supplierdescription_N ;
         gxTv_SdtSupplier_Supplierphone_N = sdt.gxTv_SdtSupplier_Supplierphone_N ;
         gxTv_SdtSupplier_Supplieremail_N = sdt.gxTv_SdtSupplier_Supplieremail_N ;
         gxTv_SdtSupplier_Supplierproductquantity_N = sdt.gxTv_SdtSupplier_Supplierproductquantity_N ;
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
         AddObjectProperty("SupplierId", gxTv_SdtSupplier_Supplierid, false, includeNonInitialized);
         AddObjectProperty("SupplierName", gxTv_SdtSupplier_Suppliername, false, includeNonInitialized);
         AddObjectProperty("SupplierDescription", gxTv_SdtSupplier_Supplierdescription, false, includeNonInitialized);
         AddObjectProperty("SupplierDescription_N", gxTv_SdtSupplier_Supplierdescription_N, false, includeNonInitialized);
         AddObjectProperty("SupplierPhone", gxTv_SdtSupplier_Supplierphone, false, includeNonInitialized);
         AddObjectProperty("SupplierPhone_N", gxTv_SdtSupplier_Supplierphone_N, false, includeNonInitialized);
         AddObjectProperty("SupplierEmail", gxTv_SdtSupplier_Supplieremail, false, includeNonInitialized);
         AddObjectProperty("SupplierEmail_N", gxTv_SdtSupplier_Supplieremail_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSupplier_Suppliercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSupplier_Suppliercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSupplier_Suppliercreateddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SupplierCreatedDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSupplier_Suppliermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSupplier_Suppliermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSupplier_Suppliermodifieddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SupplierModifiedDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SupplierProductQuantity", gxTv_SdtSupplier_Supplierproductquantity, false, includeNonInitialized);
         AddObjectProperty("SupplierProductQuantity_N", gxTv_SdtSupplier_Supplierproductquantity_N, false, includeNonInitialized);
         AddObjectProperty("SupplierActive", gxTv_SdtSupplier_Supplieractive, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSupplier_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSupplier_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierId_Z", gxTv_SdtSupplier_Supplierid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierName_Z", gxTv_SdtSupplier_Suppliername_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierDescription_Z", gxTv_SdtSupplier_Supplierdescription_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierPhone_Z", gxTv_SdtSupplier_Supplierphone_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierEmail_Z", gxTv_SdtSupplier_Supplieremail_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSupplier_Suppliercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSupplier_Suppliercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSupplier_Suppliercreateddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SupplierCreatedDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSupplier_Suppliermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSupplier_Suppliermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSupplier_Suppliermodifieddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SupplierModifiedDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SupplierProductQuantity_Z", gxTv_SdtSupplier_Supplierproductquantity_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierActive_Z", gxTv_SdtSupplier_Supplieractive_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierDescription_N", gxTv_SdtSupplier_Supplierdescription_N, false, includeNonInitialized);
            AddObjectProperty("SupplierPhone_N", gxTv_SdtSupplier_Supplierphone_N, false, includeNonInitialized);
            AddObjectProperty("SupplierEmail_N", gxTv_SdtSupplier_Supplieremail_N, false, includeNonInitialized);
            AddObjectProperty("SupplierProductQuantity_N", gxTv_SdtSupplier_Supplierproductquantity_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSupplier sdt )
      {
         if ( sdt.IsDirty("SupplierId") )
         {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierid = sdt.gxTv_SdtSupplier_Supplierid ;
         }
         if ( sdt.IsDirty("SupplierName") )
         {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliername = sdt.gxTv_SdtSupplier_Suppliername ;
         }
         if ( sdt.IsDirty("SupplierDescription") )
         {
            gxTv_SdtSupplier_Supplierdescription_N = (short)(sdt.gxTv_SdtSupplier_Supplierdescription_N);
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierdescription = sdt.gxTv_SdtSupplier_Supplierdescription ;
         }
         if ( sdt.IsDirty("SupplierPhone") )
         {
            gxTv_SdtSupplier_Supplierphone_N = (short)(sdt.gxTv_SdtSupplier_Supplierphone_N);
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierphone = sdt.gxTv_SdtSupplier_Supplierphone ;
         }
         if ( sdt.IsDirty("SupplierEmail") )
         {
            gxTv_SdtSupplier_Supplieremail_N = (short)(sdt.gxTv_SdtSupplier_Supplieremail_N);
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieremail = sdt.gxTv_SdtSupplier_Supplieremail ;
         }
         if ( sdt.IsDirty("SupplierCreatedDate") )
         {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliercreateddate = sdt.gxTv_SdtSupplier_Suppliercreateddate ;
         }
         if ( sdt.IsDirty("SupplierModifiedDate") )
         {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliermodifieddate = sdt.gxTv_SdtSupplier_Suppliermodifieddate ;
         }
         if ( sdt.IsDirty("SupplierProductQuantity") )
         {
            gxTv_SdtSupplier_Supplierproductquantity_N = (short)(sdt.gxTv_SdtSupplier_Supplierproductquantity_N);
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierproductquantity = sdt.gxTv_SdtSupplier_Supplierproductquantity ;
         }
         if ( sdt.IsDirty("SupplierActive") )
         {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieractive = sdt.gxTv_SdtSupplier_Supplieractive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierId" )]
      [  XmlElement( ElementName = "SupplierId"   )]
      public int gxTpr_Supplierid
      {
         get {
            return gxTv_SdtSupplier_Supplierid ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            if ( gxTv_SdtSupplier_Supplierid != value )
            {
               gxTv_SdtSupplier_Mode = "INS";
               this.gxTv_SdtSupplier_Supplierid_Z_SetNull( );
               this.gxTv_SdtSupplier_Suppliername_Z_SetNull( );
               this.gxTv_SdtSupplier_Supplierdescription_Z_SetNull( );
               this.gxTv_SdtSupplier_Supplierphone_Z_SetNull( );
               this.gxTv_SdtSupplier_Supplieremail_Z_SetNull( );
               this.gxTv_SdtSupplier_Suppliercreateddate_Z_SetNull( );
               this.gxTv_SdtSupplier_Suppliermodifieddate_Z_SetNull( );
               this.gxTv_SdtSupplier_Supplierproductquantity_Z_SetNull( );
               this.gxTv_SdtSupplier_Supplieractive_Z_SetNull( );
            }
            gxTv_SdtSupplier_Supplierid = value;
            SetDirty("Supplierid");
         }

      }

      [  SoapElement( ElementName = "SupplierName" )]
      [  XmlElement( ElementName = "SupplierName"   )]
      public string gxTpr_Suppliername
      {
         get {
            return gxTv_SdtSupplier_Suppliername ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliername = value;
            SetDirty("Suppliername");
         }

      }

      [  SoapElement( ElementName = "SupplierDescription" )]
      [  XmlElement( ElementName = "SupplierDescription"   )]
      public string gxTpr_Supplierdescription
      {
         get {
            return gxTv_SdtSupplier_Supplierdescription ;
         }

         set {
            gxTv_SdtSupplier_Supplierdescription_N = 0;
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierdescription = value;
            SetDirty("Supplierdescription");
         }

      }

      public void gxTv_SdtSupplier_Supplierdescription_SetNull( )
      {
         gxTv_SdtSupplier_Supplierdescription_N = 1;
         gxTv_SdtSupplier_Supplierdescription = "";
         SetDirty("Supplierdescription");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierdescription_IsNull( )
      {
         return (gxTv_SdtSupplier_Supplierdescription_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierPhone" )]
      [  XmlElement( ElementName = "SupplierPhone"   )]
      public string gxTpr_Supplierphone
      {
         get {
            return gxTv_SdtSupplier_Supplierphone ;
         }

         set {
            gxTv_SdtSupplier_Supplierphone_N = 0;
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierphone = value;
            SetDirty("Supplierphone");
         }

      }

      public void gxTv_SdtSupplier_Supplierphone_SetNull( )
      {
         gxTv_SdtSupplier_Supplierphone_N = 1;
         gxTv_SdtSupplier_Supplierphone = "";
         SetDirty("Supplierphone");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierphone_IsNull( )
      {
         return (gxTv_SdtSupplier_Supplierphone_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierEmail" )]
      [  XmlElement( ElementName = "SupplierEmail"   )]
      public string gxTpr_Supplieremail
      {
         get {
            return gxTv_SdtSupplier_Supplieremail ;
         }

         set {
            gxTv_SdtSupplier_Supplieremail_N = 0;
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieremail = value;
            SetDirty("Supplieremail");
         }

      }

      public void gxTv_SdtSupplier_Supplieremail_SetNull( )
      {
         gxTv_SdtSupplier_Supplieremail_N = 1;
         gxTv_SdtSupplier_Supplieremail = "";
         SetDirty("Supplieremail");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplieremail_IsNull( )
      {
         return (gxTv_SdtSupplier_Supplieremail_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierCreatedDate" )]
      [  XmlElement( ElementName = "SupplierCreatedDate"  , IsNullable=true )]
      public string gxTpr_Suppliercreateddate_Nullable
      {
         get {
            if ( gxTv_SdtSupplier_Suppliercreateddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSupplier_Suppliercreateddate).value ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSupplier_Suppliercreateddate = DateTime.MinValue;
            else
               gxTv_SdtSupplier_Suppliercreateddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Suppliercreateddate
      {
         get {
            return gxTv_SdtSupplier_Suppliercreateddate ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliercreateddate = value;
            SetDirty("Suppliercreateddate");
         }

      }

      [  SoapElement( ElementName = "SupplierModifiedDate" )]
      [  XmlElement( ElementName = "SupplierModifiedDate"  , IsNullable=true )]
      public string gxTpr_Suppliermodifieddate_Nullable
      {
         get {
            if ( gxTv_SdtSupplier_Suppliermodifieddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSupplier_Suppliermodifieddate).value ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSupplier_Suppliermodifieddate = DateTime.MinValue;
            else
               gxTv_SdtSupplier_Suppliermodifieddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Suppliermodifieddate
      {
         get {
            return gxTv_SdtSupplier_Suppliermodifieddate ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliermodifieddate = value;
            SetDirty("Suppliermodifieddate");
         }

      }

      [  SoapElement( ElementName = "SupplierProductQuantity" )]
      [  XmlElement( ElementName = "SupplierProductQuantity"   )]
      public short gxTpr_Supplierproductquantity
      {
         get {
            return gxTv_SdtSupplier_Supplierproductquantity ;
         }

         set {
            gxTv_SdtSupplier_Supplierproductquantity_N = 0;
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierproductquantity = value;
            SetDirty("Supplierproductquantity");
         }

      }

      public void gxTv_SdtSupplier_Supplierproductquantity_SetNull( )
      {
         gxTv_SdtSupplier_Supplierproductquantity_N = 1;
         gxTv_SdtSupplier_Supplierproductquantity = 0;
         SetDirty("Supplierproductquantity");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierproductquantity_IsNull( )
      {
         return (gxTv_SdtSupplier_Supplierproductquantity_N==1) ;
      }

      [  SoapElement( ElementName = "SupplierActive" )]
      [  XmlElement( ElementName = "SupplierActive"   )]
      public bool gxTpr_Supplieractive
      {
         get {
            return gxTv_SdtSupplier_Supplieractive ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieractive = value;
            SetDirty("Supplieractive");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSupplier_Mode ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSupplier_Mode_SetNull( )
      {
         gxTv_SdtSupplier_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSupplier_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSupplier_Initialized ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSupplier_Initialized_SetNull( )
      {
         gxTv_SdtSupplier_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSupplier_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierId_Z" )]
      [  XmlElement( ElementName = "SupplierId_Z"   )]
      public int gxTpr_Supplierid_Z
      {
         get {
            return gxTv_SdtSupplier_Supplierid_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierid_Z = value;
            SetDirty("Supplierid_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplierid_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplierid_Z = 0;
         SetDirty("Supplierid_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierName_Z" )]
      [  XmlElement( ElementName = "SupplierName_Z"   )]
      public string gxTpr_Suppliername_Z
      {
         get {
            return gxTv_SdtSupplier_Suppliername_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliername_Z = value;
            SetDirty("Suppliername_Z");
         }

      }

      public void gxTv_SdtSupplier_Suppliername_Z_SetNull( )
      {
         gxTv_SdtSupplier_Suppliername_Z = "";
         SetDirty("Suppliername_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Suppliername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierDescription_Z" )]
      [  XmlElement( ElementName = "SupplierDescription_Z"   )]
      public string gxTpr_Supplierdescription_Z
      {
         get {
            return gxTv_SdtSupplier_Supplierdescription_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierdescription_Z = value;
            SetDirty("Supplierdescription_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplierdescription_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplierdescription_Z = "";
         SetDirty("Supplierdescription_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierPhone_Z" )]
      [  XmlElement( ElementName = "SupplierPhone_Z"   )]
      public string gxTpr_Supplierphone_Z
      {
         get {
            return gxTv_SdtSupplier_Supplierphone_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierphone_Z = value;
            SetDirty("Supplierphone_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplierphone_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplierphone_Z = "";
         SetDirty("Supplierphone_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierEmail_Z" )]
      [  XmlElement( ElementName = "SupplierEmail_Z"   )]
      public string gxTpr_Supplieremail_Z
      {
         get {
            return gxTv_SdtSupplier_Supplieremail_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieremail_Z = value;
            SetDirty("Supplieremail_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplieremail_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplieremail_Z = "";
         SetDirty("Supplieremail_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplieremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierCreatedDate_Z" )]
      [  XmlElement( ElementName = "SupplierCreatedDate_Z"  , IsNullable=true )]
      public string gxTpr_Suppliercreateddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtSupplier_Suppliercreateddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSupplier_Suppliercreateddate_Z).value ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSupplier_Suppliercreateddate_Z = DateTime.MinValue;
            else
               gxTv_SdtSupplier_Suppliercreateddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Suppliercreateddate_Z
      {
         get {
            return gxTv_SdtSupplier_Suppliercreateddate_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliercreateddate_Z = value;
            SetDirty("Suppliercreateddate_Z");
         }

      }

      public void gxTv_SdtSupplier_Suppliercreateddate_Z_SetNull( )
      {
         gxTv_SdtSupplier_Suppliercreateddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Suppliercreateddate_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Suppliercreateddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierModifiedDate_Z" )]
      [  XmlElement( ElementName = "SupplierModifiedDate_Z"  , IsNullable=true )]
      public string gxTpr_Suppliermodifieddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtSupplier_Suppliermodifieddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSupplier_Suppliermodifieddate_Z).value ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSupplier_Suppliermodifieddate_Z = DateTime.MinValue;
            else
               gxTv_SdtSupplier_Suppliermodifieddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Suppliermodifieddate_Z
      {
         get {
            return gxTv_SdtSupplier_Suppliermodifieddate_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Suppliermodifieddate_Z = value;
            SetDirty("Suppliermodifieddate_Z");
         }

      }

      public void gxTv_SdtSupplier_Suppliermodifieddate_Z_SetNull( )
      {
         gxTv_SdtSupplier_Suppliermodifieddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Suppliermodifieddate_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Suppliermodifieddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierProductQuantity_Z" )]
      [  XmlElement( ElementName = "SupplierProductQuantity_Z"   )]
      public short gxTpr_Supplierproductquantity_Z
      {
         get {
            return gxTv_SdtSupplier_Supplierproductquantity_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierproductquantity_Z = value;
            SetDirty("Supplierproductquantity_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplierproductquantity_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplierproductquantity_Z = 0;
         SetDirty("Supplierproductquantity_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierproductquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierActive_Z" )]
      [  XmlElement( ElementName = "SupplierActive_Z"   )]
      public bool gxTpr_Supplieractive_Z
      {
         get {
            return gxTv_SdtSupplier_Supplieractive_Z ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieractive_Z = value;
            SetDirty("Supplieractive_Z");
         }

      }

      public void gxTv_SdtSupplier_Supplieractive_Z_SetNull( )
      {
         gxTv_SdtSupplier_Supplieractive_Z = false;
         SetDirty("Supplieractive_Z");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplieractive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierDescription_N" )]
      [  XmlElement( ElementName = "SupplierDescription_N"   )]
      public short gxTpr_Supplierdescription_N
      {
         get {
            return gxTv_SdtSupplier_Supplierdescription_N ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierdescription_N = value;
            SetDirty("Supplierdescription_N");
         }

      }

      public void gxTv_SdtSupplier_Supplierdescription_N_SetNull( )
      {
         gxTv_SdtSupplier_Supplierdescription_N = 0;
         SetDirty("Supplierdescription_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierdescription_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierPhone_N" )]
      [  XmlElement( ElementName = "SupplierPhone_N"   )]
      public short gxTpr_Supplierphone_N
      {
         get {
            return gxTv_SdtSupplier_Supplierphone_N ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierphone_N = value;
            SetDirty("Supplierphone_N");
         }

      }

      public void gxTv_SdtSupplier_Supplierphone_N_SetNull( )
      {
         gxTv_SdtSupplier_Supplierphone_N = 0;
         SetDirty("Supplierphone_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierphone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierEmail_N" )]
      [  XmlElement( ElementName = "SupplierEmail_N"   )]
      public short gxTpr_Supplieremail_N
      {
         get {
            return gxTv_SdtSupplier_Supplieremail_N ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplieremail_N = value;
            SetDirty("Supplieremail_N");
         }

      }

      public void gxTv_SdtSupplier_Supplieremail_N_SetNull( )
      {
         gxTv_SdtSupplier_Supplieremail_N = 0;
         SetDirty("Supplieremail_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplieremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierProductQuantity_N" )]
      [  XmlElement( ElementName = "SupplierProductQuantity_N"   )]
      public short gxTpr_Supplierproductquantity_N
      {
         get {
            return gxTv_SdtSupplier_Supplierproductquantity_N ;
         }

         set {
            gxTv_SdtSupplier_N = 0;
            gxTv_SdtSupplier_Supplierproductquantity_N = value;
            SetDirty("Supplierproductquantity_N");
         }

      }

      public void gxTv_SdtSupplier_Supplierproductquantity_N_SetNull( )
      {
         gxTv_SdtSupplier_Supplierproductquantity_N = 0;
         SetDirty("Supplierproductquantity_N");
         return  ;
      }

      public bool gxTv_SdtSupplier_Supplierproductquantity_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtSupplier_N = 1;
         gxTv_SdtSupplier_Suppliername = "";
         gxTv_SdtSupplier_Supplierdescription = "";
         gxTv_SdtSupplier_Supplierphone = "";
         gxTv_SdtSupplier_Supplieremail = "";
         gxTv_SdtSupplier_Suppliercreateddate = DateTime.MinValue;
         gxTv_SdtSupplier_Suppliermodifieddate = DateTime.MinValue;
         gxTv_SdtSupplier_Mode = "";
         gxTv_SdtSupplier_Suppliername_Z = "";
         gxTv_SdtSupplier_Supplierdescription_Z = "";
         gxTv_SdtSupplier_Supplierphone_Z = "";
         gxTv_SdtSupplier_Supplieremail_Z = "";
         gxTv_SdtSupplier_Suppliercreateddate_Z = DateTime.MinValue;
         gxTv_SdtSupplier_Suppliermodifieddate_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "supplier", "GeneXus.Programs.supplier_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtSupplier_N ;
      }

      private short gxTv_SdtSupplier_N ;
      private short gxTv_SdtSupplier_Supplierproductquantity ;
      private short gxTv_SdtSupplier_Initialized ;
      private short gxTv_SdtSupplier_Supplierproductquantity_Z ;
      private short gxTv_SdtSupplier_Supplierdescription_N ;
      private short gxTv_SdtSupplier_Supplierphone_N ;
      private short gxTv_SdtSupplier_Supplieremail_N ;
      private short gxTv_SdtSupplier_Supplierproductquantity_N ;
      private int gxTv_SdtSupplier_Supplierid ;
      private int gxTv_SdtSupplier_Supplierid_Z ;
      private string gxTv_SdtSupplier_Supplierphone ;
      private string gxTv_SdtSupplier_Mode ;
      private string gxTv_SdtSupplier_Supplierphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSupplier_Suppliercreateddate ;
      private DateTime gxTv_SdtSupplier_Suppliermodifieddate ;
      private DateTime gxTv_SdtSupplier_Suppliercreateddate_Z ;
      private DateTime gxTv_SdtSupplier_Suppliermodifieddate_Z ;
      private bool gxTv_SdtSupplier_Supplieractive ;
      private bool gxTv_SdtSupplier_Supplieractive_Z ;
      private string gxTv_SdtSupplier_Suppliername ;
      private string gxTv_SdtSupplier_Supplierdescription ;
      private string gxTv_SdtSupplier_Supplieremail ;
      private string gxTv_SdtSupplier_Suppliername_Z ;
      private string gxTv_SdtSupplier_Supplierdescription_Z ;
      private string gxTv_SdtSupplier_Supplieremail_Z ;
   }

   [DataContract(Name = @"Supplier", Namespace = "mtaKB")]
   public class SdtSupplier_RESTInterface : GxGenericCollectionItem<SdtSupplier>
   {
      public SdtSupplier_RESTInterface( ) : base()
      {
      }

      public SdtSupplier_RESTInterface( SdtSupplier psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierId" , Order = 0 )]
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

      [DataMember( Name = "SupplierName" , Order = 1 )]
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

      [DataMember( Name = "SupplierDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Supplierdescription
      {
         get {
            return sdt.gxTpr_Supplierdescription ;
         }

         set {
            sdt.gxTpr_Supplierdescription = value;
         }

      }

      [DataMember( Name = "SupplierPhone" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Supplierphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Supplierphone) ;
         }

         set {
            sdt.gxTpr_Supplierphone = value;
         }

      }

      [DataMember( Name = "SupplierEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Supplieremail
      {
         get {
            return sdt.gxTpr_Supplieremail ;
         }

         set {
            sdt.gxTpr_Supplieremail = value;
         }

      }

      [DataMember( Name = "SupplierCreatedDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Suppliercreateddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Suppliercreateddate) ;
         }

         set {
            sdt.gxTpr_Suppliercreateddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SupplierModifiedDate" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Suppliermodifieddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Suppliermodifieddate) ;
         }

         set {
            sdt.gxTpr_Suppliermodifieddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SupplierProductQuantity" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Supplierproductquantity
      {
         get {
            return sdt.gxTpr_Supplierproductquantity ;
         }

         set {
            sdt.gxTpr_Supplierproductquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SupplierActive" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Supplieractive
      {
         get {
            return sdt.gxTpr_Supplieractive ;
         }

         set {
            sdt.gxTpr_Supplieractive = value;
         }

      }

      public SdtSupplier sdt
      {
         get {
            return (SdtSupplier)Sdt ;
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
            sdt = new SdtSupplier() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"Supplier", Namespace = "mtaKB")]
   public class SdtSupplier_RESTLInterface : GxGenericCollectionItem<SdtSupplier>
   {
      public SdtSupplier_RESTLInterface( ) : base()
      {
      }

      public SdtSupplier_RESTLInterface( SdtSupplier psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtSupplier sdt
      {
         get {
            return (SdtSupplier)Sdt ;
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
            sdt = new SdtSupplier() ;
         }
      }

   }

}
