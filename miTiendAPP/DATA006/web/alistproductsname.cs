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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class alistproductsname : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("mtaKB", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Supplier");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8Supplier = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public alistproductsname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public alistproductsname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Supplier )
      {
         this.AV8Supplier = aP0_Supplier;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_Supplier )
      {
         alistproductsname objalistproductsname;
         objalistproductsname = new alistproductsname();
         objalistproductsname.AV8Supplier = aP0_Supplier;
         objalistproductsname.context.SetSubmitInitialConfig(context);
         objalistproductsname.initialize();
         Submit( executePrivateCatch,objalistproductsname);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistproductsname)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8Supplier ,
                                                 A4SupplierId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P000J2 */
            pr_default.execute(0, new Object[] {AV8Supplier});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = P000J2_A4SupplierId[0];
               A29ProductModifiedDate = P000J2_A29ProductModifiedDate[0];
               n29ProductModifiedDate = P000J2_n29ProductModifiedDate[0];
               A28ProductCreatedDate = P000J2_A28ProductCreatedDate[0];
               A18ProductPrice = P000J2_A18ProductPrice[0];
               A69ProductMiniumStock = P000J2_A69ProductMiniumStock[0];
               A17ProductStock = P000J2_A17ProductStock[0];
               A55ProductCode = P000J2_A55ProductCode[0];
               n55ProductCode = P000J2_n55ProductCode[0];
               A16ProductName = P000J2_A16ProductName[0];
               A15ProductId = P000J2_A15ProductId[0];
               H0J0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProductCode, "")), 13, Gx_line+27, 120, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 127, Gx_line+27, 234, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")), 240, Gx_line+27, 347, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9")), 360, Gx_line+27, 467, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99")), 467, Gx_line+27, 574, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( A28ProductCreatedDate, "99/99/99"), 573, Gx_line+27, 680, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( A29ProductModifiedDate, "99/99/99"), 680, Gx_line+27, 787, Gx_line+37, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0J0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0J0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Products to Purchase", 20, Gx_line+13, 327, Gx_line+54, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+107, 827, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Supplier:", 433, Gx_line+40, 500, Gx_line+67, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Code", 13, Gx_line+120, 86, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Name", 127, Gx_line+120, 200, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Curr. Stock", 240, Gx_line+120, 333, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Min. Stock", 360, Gx_line+120, 453, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+160, 827, Gx_line+160, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date:", 433, Gx_line+13, 500, Gx_line+41, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 507, Gx_line+13, 607, Gx_line+40, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 507, Gx_line+40, 707, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Price", 467, Gx_line+120, 560, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Date Crea.", 573, Gx_line+120, 666, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Date Modi.", 680, Gx_line+120, 773, Gx_line+147, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+177);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000J2_A4SupplierId = new int[1] ;
         P000J2_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P000J2_n29ProductModifiedDate = new bool[] {false} ;
         P000J2_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000J2_A18ProductPrice = new decimal[1] ;
         P000J2_A69ProductMiniumStock = new int[1] ;
         P000J2_A17ProductStock = new int[1] ;
         P000J2_A55ProductCode = new string[] {""} ;
         P000J2_n55ProductCode = new bool[] {false} ;
         P000J2_A16ProductName = new string[] {""} ;
         P000J2_A15ProductId = new int[1] ;
         A29ProductModifiedDate = DateTime.MinValue;
         A28ProductCreatedDate = DateTime.MinValue;
         A55ProductCode = "";
         A16ProductName = "";
         Gx_date = DateTime.MinValue;
         A5SupplierName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistproductsname__default(),
            new Object[][] {
                new Object[] {
               P000J2_A4SupplierId, P000J2_A29ProductModifiedDate, P000J2_n29ProductModifiedDate, P000J2_A28ProductCreatedDate, P000J2_A18ProductPrice, P000J2_A69ProductMiniumStock, P000J2_A17ProductStock, P000J2_A55ProductCode, P000J2_n55ProductCode, P000J2_A16ProductName,
               P000J2_A15ProductId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8Supplier ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A4SupplierId ;
      private int A69ProductMiniumStock ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private int Gx_OldLine ;
      private decimal A18ProductPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A29ProductModifiedDate ;
      private DateTime A28ProductCreatedDate ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29ProductModifiedDate ;
      private bool n55ProductCode ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000J2_A4SupplierId ;
      private DateTime[] P000J2_A29ProductModifiedDate ;
      private bool[] P000J2_n29ProductModifiedDate ;
      private DateTime[] P000J2_A28ProductCreatedDate ;
      private decimal[] P000J2_A18ProductPrice ;
      private int[] P000J2_A69ProductMiniumStock ;
      private int[] P000J2_A17ProductStock ;
      private string[] P000J2_A55ProductCode ;
      private bool[] P000J2_n55ProductCode ;
      private string[] P000J2_A16ProductName ;
      private int[] P000J2_A15ProductId ;
   }

   public class alistproductsname__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000J2( IGxContext context ,
                                             short AV8Supplier ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SupplierId], [ProductModifiedDate], [ProductCreatedDate], [ProductPrice], [ProductMiniumStock], [ProductStock], [ProductCode], [ProductName], [ProductId] FROM [Product]";
         if ( ! (0==AV8Supplier) )
         {
            AddWhere(sWhereString, "([SupplierId] = @AV8Supplier)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProductName], [ProductCode]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000J2(context, (short)dynConstraints[0] , (int)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000J2;
          prmP000J2 = new Object[] {
          new ParDef("@AV8Supplier",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
