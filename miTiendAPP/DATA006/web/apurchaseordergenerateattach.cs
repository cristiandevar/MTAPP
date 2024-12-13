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
   public class apurchaseordergenerateattach : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
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

      public apurchaseordergenerateattach( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public apurchaseordergenerateattach( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_PurchaseOrderId )
      {
         apurchaseordergenerateattach objapurchaseordergenerateattach;
         objapurchaseordergenerateattach = new apurchaseordergenerateattach();
         objapurchaseordergenerateattach.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objapurchaseordergenerateattach.context.SetSubmitInitialConfig(context);
         objapurchaseordergenerateattach.initialize();
         Submit( executePrivateCatch,objapurchaseordergenerateattach);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apurchaseordergenerateattach)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11923, 0, 1, 1, 0, 1, 1) )
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
            AV8FileName = "Voucher_" + StringUtil.Str( (decimal)(A50PurchaseOrderId), 6, 0) + ".pdf";
            /* Using cursor P00252 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15ProductId = P00252_A15ProductId[0];
               A77PurchaseOrderDetailQuantityRec = P00252_A77PurchaseOrderDetailQuantityRec[0];
               A76PurchaseOrderDetailQuantityOrd = P00252_A76PurchaseOrderDetailQuantityOrd[0];
               A16ProductName = P00252_A16ProductName[0];
               A61PurchaseOrderDetailId = P00252_A61PurchaseOrderDetailId[0];
               A16ProductName = P00252_A16ProductName[0];
               H250( false, 43) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 100, Gx_line+13, 414, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 447, Gx_line+13, 534, Gx_line+28, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")), 600, Gx_line+13, 687, Gx_line+28, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+43);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H250( false, 46) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Paid:", 460, Gx_line+13, 547, Gx_line+40, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99")), 587, Gx_line+19, 687, Gx_line+34, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(413, Gx_line+0, 813, Gx_line+0, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+46);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H250( true, 0) ;
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

      protected void H250( bool bFoot ,
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
                  getPrinter().GxDrawLine(7, Gx_line+0, 814, Gx_line+0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Voucher generado por", 60, Gx_line+13, 167, Gx_line+40, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("miTiendAPP", 167, Gx_line+13, 280, Gx_line+40, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
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
               getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Voucher", 333, Gx_line+13, 513, Gx_line+53, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 693, Gx_line+53, 793, Gx_line+80, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date:", 627, Gx_line+53, 687, Gx_line+80, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Qty Received", 587, Gx_line+147, 687, Gx_line+174, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Qty Required", 440, Gx_line+147, 533, Gx_line+174, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Product", 100, Gx_line+147, 167, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(13, Gx_line+187, 820, Gx_line+187, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Voucher No:", 600, Gx_line+93, 687, Gx_line+120, 2, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 693, Gx_line+93, 793, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 167, Gx_line+93, 418, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Supplier:", 100, Gx_line+93, 160, Gx_line+120, 2, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+188);
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
         AV8FileName = "";
         scmdbuf = "";
         P00252_A15ProductId = new int[1] ;
         P00252_A50PurchaseOrderId = new int[1] ;
         P00252_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00252_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00252_A16ProductName = new string[] {""} ;
         P00252_A61PurchaseOrderDetailId = new int[1] ;
         A16ProductName = "";
         Gx_date = DateTime.MinValue;
         A5SupplierName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apurchaseordergenerateattach__default(),
            new Object[][] {
                new Object[] {
               P00252_A15ProductId, P00252_A50PurchaseOrderId, P00252_A77PurchaseOrderDetailQuantityRec, P00252_A76PurchaseOrderDetailQuantityOrd, P00252_A16ProductName, P00252_A61PurchaseOrderDetailId
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
      private int A50PurchaseOrderId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A15ProductId ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A61PurchaseOrderDetailId ;
      private int Gx_OldLine ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV8FileName ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00252_A15ProductId ;
      private int[] P00252_A50PurchaseOrderId ;
      private int[] P00252_A77PurchaseOrderDetailQuantityRec ;
      private int[] P00252_A76PurchaseOrderDetailQuantityOrd ;
      private string[] P00252_A16ProductName ;
      private int[] P00252_A61PurchaseOrderDetailId ;
   }

   public class apurchaseordergenerateattach__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00252;
          prmP00252 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00252", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailQuantityOrd], T2.[ProductName], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00252,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
