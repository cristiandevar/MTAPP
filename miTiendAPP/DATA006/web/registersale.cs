using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class registersale : GXProcedure
   {
      public registersale( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public registersale( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP0_Car ,
                           GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> aP1_SDTInvoiceAddPaymentMethod ,
                           out int aP2_InvoiceId ,
                           out bool aP3_AllOk )
      {
         this.AV9Car = aP0_Car;
         this.AV27SDTInvoiceAddPaymentMethod = aP1_SDTInvoiceAddPaymentMethod;
         this.AV16InvoiceId = 0 ;
         this.AV10AllOk = false ;
         initialize();
         executePrivate();
         aP2_InvoiceId=this.AV16InvoiceId;
         aP3_AllOk=this.AV10AllOk;
      }

      public bool executeUdp( GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP0_Car ,
                              GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> aP1_SDTInvoiceAddPaymentMethod ,
                              out int aP2_InvoiceId )
      {
         execute(aP0_Car, aP1_SDTInvoiceAddPaymentMethod, out aP2_InvoiceId, out aP3_AllOk);
         return AV10AllOk ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP0_Car ,
                                 GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> aP1_SDTInvoiceAddPaymentMethod ,
                                 out int aP2_InvoiceId ,
                                 out bool aP3_AllOk )
      {
         registersale objregistersale;
         objregistersale = new registersale();
         objregistersale.AV9Car = aP0_Car;
         objregistersale.AV27SDTInvoiceAddPaymentMethod = aP1_SDTInvoiceAddPaymentMethod;
         objregistersale.AV16InvoiceId = 0 ;
         objregistersale.AV10AllOk = false ;
         objregistersale.context.SetSubmitInitialConfig(context);
         objregistersale.initialize();
         Submit( executePrivateCatch,objregistersale);
         aP2_InvoiceId=this.AV16InvoiceId;
         aP3_AllOk=this.AV10AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registersale)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new getcontext(context ).execute( out  AV17Context, ref  AV10AllOk) ;
         if ( ! AV10AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV12Invoice = new SdtInvoice(context);
         AV10AllOk = true;
         AV18Message = "";
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV9Car.Count )
         {
            AV13CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV9Car.Item(AV33GXV1));
            AV22ProductIdAux = AV13CarItem.gxTpr_Id;
            /* Execute user subroutine: 'EXISTOTHERWITHSAMECODE' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( ! AV21Exist )
            {
               AV14InvoiceDetail = new SdtInvoice_Detail(context);
               AV14InvoiceDetail.gxTpr_Productid = AV13CarItem.gxTpr_Id;
               AV14InvoiceDetail.gxTpr_Invoicedetailquantity = AV13CarItem.gxTpr_Quantity;
               AV14InvoiceDetail.gxTpr_Invoicedetailhistoricprice = AV13CarItem.gxTpr_Unitprice;
               if ( ( AV13CarItem.gxTpr_Quantity >= AV13CarItem.gxTpr_Productminiumquantitywholesale ) && ( AV13CarItem.gxTpr_Productminiumquantitywholesale != 0 ) )
               {
                  AV14InvoiceDetail.gxTpr_Invoicedetailiswholesale = true;
               }
               AV15Product.Load(AV13CarItem.gxTpr_Id);
               if ( AV15Product.gxTpr_Productstock - AV13CarItem.gxTpr_Quantity >= 0 )
               {
                  AV12Invoice.gxTpr_Detail.Add(AV14InvoiceDetail, 0);
               }
               else
               {
                  AV18Message += "Product " + AV15Product.gxTpr_Productname + " update stock fail!";
                  AV10AllOk = false;
                  if (true) break;
               }
            }
            else
            {
               /* Execute user subroutine: 'GETIDSSAMECODE' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'ORDERIDSSAMECODE' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV24ProductAux.Load((int)(AV19SameCodeIds.GetNumeric(1)));
               if ( AV13CarItem.gxTpr_Quantity <= AV24ProductAux.gxTpr_Productstock )
               {
                  AV14InvoiceDetail = new SdtInvoice_Detail(context);
                  AV14InvoiceDetail.gxTpr_Productid = AV24ProductAux.gxTpr_Productid;
                  AV14InvoiceDetail.gxTpr_Invoicedetailquantity = AV13CarItem.gxTpr_Quantity;
                  AV14InvoiceDetail.gxTpr_Invoicedetailhistoricprice = AV13CarItem.gxTpr_Unitprice;
                  if ( AV13CarItem.gxTpr_Quantity >= AV13CarItem.gxTpr_Productminiumquantitywholesale )
                  {
                     AV14InvoiceDetail.gxTpr_Invoicedetailiswholesale = true;
                  }
                  AV15Product.Load(AV24ProductAux.gxTpr_Productid);
                  if ( AV15Product.gxTpr_Productstock - AV13CarItem.gxTpr_Quantity >= 0 )
                  {
                     AV12Invoice.gxTpr_Detail.Add(AV14InvoiceDetail, 0);
                  }
                  else
                  {
                     AV18Message += "Product " + AV15Product.gxTpr_Productname + " update stock fail!";
                     AV10AllOk = false;
                     if (true) break;
                  }
               }
               else
               {
                  AV25StockNeeded = AV13CarItem.gxTpr_Quantity;
                  AV34GXV2 = 1;
                  while ( AV34GXV2 <= AV19SameCodeIds.Count )
                  {
                     AV23SameCodeId = (int)(AV19SameCodeIds.GetNumeric(AV34GXV2));
                     if ( AV25StockNeeded > 0 )
                     {
                        AV24ProductAux.Load(AV23SameCodeId);
                        if ( AV24ProductAux.gxTpr_Productstock <= AV25StockNeeded )
                        {
                           AV26StockAux = AV24ProductAux.gxTpr_Productstock;
                           AV25StockNeeded = (int)(AV25StockNeeded-(AV24ProductAux.gxTpr_Productstock));
                        }
                        else
                        {
                           AV26StockAux = AV25StockNeeded;
                           AV25StockNeeded = 0;
                        }
                        AV14InvoiceDetail = new SdtInvoice_Detail(context);
                        AV14InvoiceDetail.gxTpr_Productid = AV24ProductAux.gxTpr_Productid;
                        AV14InvoiceDetail.gxTpr_Invoicedetailquantity = AV26StockAux;
                        AV14InvoiceDetail.gxTpr_Invoicedetailhistoricprice = AV13CarItem.gxTpr_Unitprice;
                        if ( AV13CarItem.gxTpr_Quantity >= AV13CarItem.gxTpr_Productminiumquantitywholesale )
                        {
                           AV14InvoiceDetail.gxTpr_Invoicedetailiswholesale = true;
                        }
                        AV15Product.Load(AV23SameCodeId);
                        if ( AV15Product.gxTpr_Productstock - AV26StockAux >= 0 )
                        {
                           AV12Invoice.gxTpr_Detail.Add(AV14InvoiceDetail, 0);
                        }
                        else
                        {
                           AV18Message += "Product " + AV15Product.gxTpr_Productname + " update stock fail!";
                           AV10AllOk = false;
                           if (true) break;
                        }
                     }
                     else
                     {
                        if (true) break;
                     }
                     AV34GXV2 = (int)(AV34GXV2+1);
                  }
                  if ( ! AV10AllOk )
                  {
                     if (true) break;
                  }
               }
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
         if ( AV10AllOk )
         {
            /* Execute user subroutine: 'LOADPAYMENTMETHOD' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         if ( AV10AllOk )
         {
            AV12Invoice.gxTpr_Userid = AV17Context.gxTpr_Userid;
            AV12Invoice.gxTpr_Invoiceactive = true;
            AV12Invoice.Insert();
            if ( AV12Invoice.Success() )
            {
               AV16InvoiceId = AV12Invoice.gxTpr_Invoiceid;
               AV35GXV3 = 1;
               while ( AV35GXV3 <= AV12Invoice.gxTpr_Detail.Count )
               {
                  AV14InvoiceDetail = ((SdtInvoice_Detail)AV12Invoice.gxTpr_Detail.Item(AV35GXV3));
                  AV15Product.Load(AV14InvoiceDetail.gxTpr_Productid);
                  AV15Product.gxTpr_Productstock = (int)(AV15Product.gxTpr_Productstock-(AV14InvoiceDetail.gxTpr_Invoicedetailquantity));
                  AV15Product.Update();
                  if ( ! AV15Product.Success() )
                  {
                     AV10AllOk = false;
                     AV18Message += AV15Product.GetMessages().ToJSonString(false);
                     if (true) break;
                  }
                  AV35GXV3 = (int)(AV35GXV3+1);
               }
               if ( AV10AllOk )
               {
                  context.CommitDataStores("registersale",pr_default);
               }
            }
            else
            {
               AV10AllOk = false;
               AV18Message += AV12Invoice.GetMessages().ToJSonString(false) + " " + AV12Invoice.ToJSonString(true, true) + ", Insert Invoice Fail!";
               context.RollbackDataStores("registersale",pr_default);
            }
         }
         if ( ! AV10AllOk )
         {
            GX_msglist.addItem(AV18Message);
            context.RollbackDataStores("registersale",pr_default);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GETIDSSAMECODE' Routine */
         returnInSub = false;
         AV19SameCodeIds = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         /* Using cursor P001G2 */
         pr_default.execute(0, new Object[] {AV20ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P001G2_A4SupplierId[0];
            A112SupplierActive = P001G2_A112SupplierActive[0];
            A110ProductActive = P001G2_A110ProductActive[0];
            n110ProductActive = P001G2_n110ProductActive[0];
            A17ProductStock = P001G2_A17ProductStock[0];
            n17ProductStock = P001G2_n17ProductStock[0];
            A55ProductCode = P001G2_A55ProductCode[0];
            n55ProductCode = P001G2_n55ProductCode[0];
            A15ProductId = P001G2_A15ProductId[0];
            A112SupplierActive = P001G2_A112SupplierActive[0];
            AV19SameCodeIds.Add(A15ProductId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'EXISTOTHERWITHSAMECODE' Routine */
         returnInSub = false;
         /* Using cursor P001G3 */
         pr_default.execute(1, new Object[] {AV22ProductIdAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A15ProductId = P001G3_A15ProductId[0];
            A55ProductCode = P001G3_A55ProductCode[0];
            n55ProductCode = P001G3_n55ProductCode[0];
            AV20ProductCode = A55ProductCode;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         new productexistothersamecode(context ).execute(  AV22ProductIdAux,  AV20ProductCode, out  AV21Exist) ;
      }

      protected void S131( )
      {
         /* 'ORDERIDSSAMECODE' Routine */
         returnInSub = false;
      }

      protected void S141( )
      {
         /* 'LOADPAYMENTMETHOD' Routine */
         returnInSub = false;
         if ( AV27SDTInvoiceAddPaymentMethod.Count > 0 )
         {
            AV38GXV4 = 1;
            while ( AV38GXV4 <= AV27SDTInvoiceAddPaymentMethod.Count )
            {
               AV28SDTInvoiceAddPaymentMethodItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV27SDTInvoiceAddPaymentMethod.Item(AV38GXV4));
               AV30PaymentMethod.Load(AV28SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid);
               AV29InvoicePaymentMethod = new SdtInvoice_PaymentMethod(context);
               AV29InvoicePaymentMethod.gxTpr_Paymentmethodid = AV28SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid;
               AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodimport = AV28SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport;
               GXt_decimal1 = 0;
               new roundvalue(context ).execute(  AV28SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport*(AV30PaymentMethod.gxTpr_Paymentmethoddiscount/ (decimal)(100)), out  GXt_decimal1) ;
               AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethoddiscountimport = GXt_decimal1;
               GXt_decimal1 = 0;
               new roundvalue(context ).execute(  AV28SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport*(AV30PaymentMethod.gxTpr_Paymentmethodrecarge/ (decimal)(100)), out  GXt_decimal1) ;
               AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodrechargeimport = GXt_decimal1;
               AV12Invoice.gxTpr_Paymentmethod.Add(AV29InvoicePaymentMethod, 0);
               AV38GXV4 = (int)(AV38GXV4+1);
            }
         }
         else
         {
            AV30PaymentMethod.Load(1);
            AV29InvoicePaymentMethod = new SdtInvoice_PaymentMethod(context);
            AV29InvoicePaymentMethod.gxTpr_Paymentmethodid = 1;
            AV39GXV5 = 1;
            while ( AV39GXV5 <= AV12Invoice.gxTpr_Detail.Count )
            {
               AV14InvoiceDetail = ((SdtInvoice_Detail)AV12Invoice.gxTpr_Detail.Item(AV39GXV5));
               AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodimport = (decimal)(AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodimport+((AV14InvoiceDetail.gxTpr_Invoicedetailhistoricprice*AV14InvoiceDetail.gxTpr_Invoicedetailquantity)));
               AV39GXV5 = (int)(AV39GXV5+1);
            }
            GXt_decimal1 = 0;
            new roundvalue(context ).execute(  AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodimport*(AV30PaymentMethod.gxTpr_Paymentmethoddiscount/ (decimal)(100)), out  GXt_decimal1) ;
            AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethoddiscountimport = GXt_decimal1;
            GXt_decimal1 = 0;
            new roundvalue(context ).execute(  AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodimport*(AV30PaymentMethod.gxTpr_Paymentmethodrecarge/ (decimal)(100)), out  GXt_decimal1) ;
            AV29InvoicePaymentMethod.gxTpr_Invoicepaymentmethodrechargeimport = GXt_decimal1;
            AV12Invoice.gxTpr_Paymentmethod.Add(AV29InvoicePaymentMethod, 0);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV17Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV12Invoice = new SdtInvoice(context);
         AV18Message = "";
         AV13CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV14InvoiceDetail = new SdtInvoice_Detail(context);
         AV15Product = new SdtProduct(context);
         AV24ProductAux = new SdtProduct(context);
         AV19SameCodeIds = new GxSimpleCollection<int>();
         scmdbuf = "";
         AV20ProductCode = "";
         P001G2_A4SupplierId = new int[1] ;
         P001G2_A112SupplierActive = new bool[] {false} ;
         P001G2_A110ProductActive = new bool[] {false} ;
         P001G2_n110ProductActive = new bool[] {false} ;
         P001G2_A17ProductStock = new int[1] ;
         P001G2_n17ProductStock = new bool[] {false} ;
         P001G2_A55ProductCode = new string[] {""} ;
         P001G2_n55ProductCode = new bool[] {false} ;
         P001G2_A15ProductId = new int[1] ;
         A55ProductCode = "";
         P001G3_A15ProductId = new int[1] ;
         P001G3_A55ProductCode = new string[] {""} ;
         P001G3_n55ProductCode = new bool[] {false} ;
         AV28SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
         AV30PaymentMethod = new SdtPaymentMethod(context);
         AV29InvoicePaymentMethod = new SdtInvoice_PaymentMethod(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registersale__default(),
            new Object[][] {
                new Object[] {
               P001G2_A4SupplierId, P001G2_A112SupplierActive, P001G2_A110ProductActive, P001G2_n110ProductActive, P001G2_A17ProductStock, P001G2_n17ProductStock, P001G2_A55ProductCode, P001G2_n55ProductCode, P001G2_A15ProductId
               }
               , new Object[] {
               P001G3_A15ProductId, P001G3_A55ProductCode, P001G3_n55ProductCode
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV16InvoiceId ;
      private int AV33GXV1 ;
      private int AV22ProductIdAux ;
      private int AV25StockNeeded ;
      private int AV34GXV2 ;
      private int AV23SameCodeId ;
      private int AV26StockAux ;
      private int AV35GXV3 ;
      private int A4SupplierId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private int AV38GXV4 ;
      private int AV39GXV5 ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private bool AV10AllOk ;
      private bool returnInSub ;
      private bool AV21Exist ;
      private bool A112SupplierActive ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n55ProductCode ;
      private string AV18Message ;
      private string AV20ProductCode ;
      private string A55ProductCode ;
      private GxSimpleCollection<int> AV19SameCodeIds ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001G2_A4SupplierId ;
      private bool[] P001G2_A112SupplierActive ;
      private bool[] P001G2_A110ProductActive ;
      private bool[] P001G2_n110ProductActive ;
      private int[] P001G2_A17ProductStock ;
      private bool[] P001G2_n17ProductStock ;
      private string[] P001G2_A55ProductCode ;
      private bool[] P001G2_n55ProductCode ;
      private int[] P001G2_A15ProductId ;
      private int[] P001G3_A15ProductId ;
      private string[] P001G3_A55ProductCode ;
      private bool[] P001G3_n55ProductCode ;
      private int aP2_InvoiceId ;
      private bool aP3_AllOk ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV9Car ;
      private GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV27SDTInvoiceAddPaymentMethod ;
      private SdtSDTCarProducts_SDTCarProductsItem AV13CarItem ;
      private SdtInvoice AV12Invoice ;
      private SdtInvoice_Detail AV14InvoiceDetail ;
      private SdtInvoice_PaymentMethod AV29InvoicePaymentMethod ;
      private SdtProduct AV15Product ;
      private SdtProduct AV24ProductAux ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV17Context ;
      private SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem AV28SDTInvoiceAddPaymentMethodItem ;
      private SdtPaymentMethod AV30PaymentMethod ;
   }

   public class registersale__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001G2;
          prmP001G2 = new Object[] {
          new ParDef("@AV20ProductCode",GXType.NVarChar,100,0)
          };
          Object[] prmP001G3;
          prmP001G3 = new Object[] {
          new ParDef("@AV22ProductIdAux",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001G2", "SELECT T1.[SupplierId], T2.[SupplierActive], T1.[ProductActive], T1.[ProductStock], T1.[ProductCode], T1.[ProductId] FROM ([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE (T1.[ProductStock] > 0) AND (T1.[ProductActive] = 1) AND (T2.[SupplierActive] = 1) AND (T1.[ProductCode] = @AV20ProductCode) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001G2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001G3", "SELECT [ProductId], [ProductCode] FROM [Product] WHERE [ProductId] = @AV22ProductIdAux ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001G3,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
