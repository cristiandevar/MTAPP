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
   public class aregistersaleproductselected : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "JSONProductSelectedId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9JSONProductSelectedId = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10JSONQuantityProduct = GetPar( "JSONQuantityProduct");
               }
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

      public aregistersaleproductselected( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aregistersaleproductselected( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSONProductSelectedId ,
                           ref string aP1_JSONQuantityProduct )
      {
         this.AV9JSONProductSelectedId = aP0_JSONProductSelectedId;
         this.AV10JSONQuantityProduct = aP1_JSONQuantityProduct;
         initialize();
         executePrivate();
         aP1_JSONQuantityProduct=this.AV10JSONQuantityProduct;
      }

      public string executeUdp( string aP0_JSONProductSelectedId )
      {
         execute(aP0_JSONProductSelectedId, ref aP1_JSONQuantityProduct);
         return AV10JSONQuantityProduct ;
      }

      public void executeSubmit( string aP0_JSONProductSelectedId ,
                                 ref string aP1_JSONQuantityProduct )
      {
         aregistersaleproductselected objaregistersaleproductselected;
         objaregistersaleproductselected = new aregistersaleproductselected();
         objaregistersaleproductselected.AV9JSONProductSelectedId = aP0_JSONProductSelectedId;
         objaregistersaleproductselected.AV10JSONQuantityProduct = aP1_JSONQuantityProduct;
         objaregistersaleproductselected.context.SetSubmitInitialConfig(context);
         objaregistersaleproductselected.initialize();
         Submit( executePrivateCatch,objaregistersaleproductselected);
         aP1_JSONQuantityProduct=this.AV10JSONQuantityProduct;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aregistersaleproductselected)stateInfo).executePrivate();
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
            AV11ProductSelectedId.FromJSonString(AV9JSONProductSelectedId, null);
            AV12QuantityProduct.FromJSonString(AV10JSONQuantityProduct, null);
            AV18Counter = 1;
            AV20Total = 0;
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV11ProductSelectedId.Count )
            {
               AV14ProductId = (int)(AV11ProductSelectedId.GetNumeric(AV24GXV1));
               /* Using cursor P000N2 */
               pr_default.execute(0, new Object[] {AV14ProductId});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A15ProductId = P000N2_A15ProductId[0];
                  A18ProductPrice = P000N2_A18ProductPrice[0];
                  A16ProductName = P000N2_A16ProductName[0];
                  AV13Quantity = (short)(AV12QuantityProduct.GetNumeric(AV18Counter));
                  AV19Subtotal = (decimal)(AV13Quantity*A18ProductPrice);
                  AV20Total = (decimal)(AV20Total+AV19Subtotal);
                  H0N0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+27, 127, Gx_line+37, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13Quantity), "ZZZ9")), 180, Gx_line+27, 287, Gx_line+37, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99")), 360, Gx_line+27, 467, Gx_line+37, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19Subtotal, "ZZZZZZ9.99")), 507, Gx_line+27, 614, Gx_line+37, 1, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(0);
               AV18Counter = (short)(AV18Counter+1);
               AV24GXV1 = (int)(AV24GXV1+1);
            }
            H0N0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Total, "ZZZZZZZZZZZ9.99")), 520, Gx_line+67, 633, Gx_line+94, 1, 0, 0, 1) ;
            getPrinter().GxDrawLine(0, Gx_line+13, 820, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Total", 400, Gx_line+67, 493, Gx_line+94, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0N0( true, 0) ;
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

      protected void H0N0( bool bFoot ,
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
               getPrinter().GxDrawText("Invoice", 20, Gx_line+13, 327, Gx_line+54, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+107, 827, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 33, Gx_line+120, 106, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+160, 827, Gx_line+160, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date:", 433, Gx_line+13, 500, Gx_line+41, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 507, Gx_line+13, 607, Gx_line+40, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Unit Price", 360, Gx_line+120, 473, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Quantity", 187, Gx_line+120, 280, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Subtotal", 507, Gx_line+120, 620, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Quantity", 187, Gx_line+120, 280, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Name", 33, Gx_line+120, 106, Gx_line+147, 1, 0, 0, 1) ;
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
         AV11ProductSelectedId = new GxSimpleCollection<int>();
         AV12QuantityProduct = new GxSimpleCollection<short>();
         scmdbuf = "";
         P000N2_A15ProductId = new int[1] ;
         P000N2_A18ProductPrice = new decimal[1] ;
         P000N2_A16ProductName = new string[] {""} ;
         A16ProductName = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aregistersaleproductselected__default(),
            new Object[][] {
                new Object[] {
               P000N2_A15ProductId, P000N2_A18ProductPrice, P000N2_A16ProductName
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
      private short GxWebError ;
      private short AV18Counter ;
      private short AV13Quantity ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV24GXV1 ;
      private int AV14ProductId ;
      private int A15ProductId ;
      private int Gx_OldLine ;
      private decimal AV20Total ;
      private decimal A18ProductPrice ;
      private decimal AV19Subtotal ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV9JSONProductSelectedId ;
      private string AV10JSONQuantityProduct ;
      private string A16ProductName ;
      private GxSimpleCollection<short> AV12QuantityProduct ;
      private GxSimpleCollection<int> AV11ProductSelectedId ;
      private IGxDataStore dsDefault ;
      private string aP1_JSONQuantityProduct ;
      private IDataStoreProvider pr_default ;
      private int[] P000N2_A15ProductId ;
      private decimal[] P000N2_A18ProductPrice ;
      private string[] P000N2_A16ProductName ;
   }

   public class aregistersaleproductselected__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          new ParDef("@AV14ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "SELECT [ProductId], [ProductPrice], [ProductName] FROM [Product] WHERE [ProductId] = @AV14ProductId ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N2,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
