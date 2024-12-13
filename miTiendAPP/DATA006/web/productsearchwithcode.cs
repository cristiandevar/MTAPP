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
   public class productsearchwithcode : GXProcedure
   {
      public productsearchwithcode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productsearchwithcode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductCode ,
                           out int aP1_ProductId )
      {
         this.AV8ProductCode = aP0_ProductCode;
         this.AV9ProductId = 0 ;
         initialize();
         executePrivate();
         aP1_ProductId=this.AV9ProductId;
      }

      public int executeUdp( string aP0_ProductCode )
      {
         execute(aP0_ProductCode, out aP1_ProductId);
         return AV9ProductId ;
      }

      public void executeSubmit( string aP0_ProductCode ,
                                 out int aP1_ProductId )
      {
         productsearchwithcode objproductsearchwithcode;
         objproductsearchwithcode = new productsearchwithcode();
         objproductsearchwithcode.AV8ProductCode = aP0_ProductCode;
         objproductsearchwithcode.AV9ProductId = 0 ;
         objproductsearchwithcode.context.SetSubmitInitialConfig(context);
         objproductsearchwithcode.initialize();
         Submit( executePrivateCatch,objproductsearchwithcode);
         aP1_ProductId=this.AV9ProductId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productsearchwithcode)stateInfo).executePrivate();
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
         AV12GXLvl1 = 0;
         /* Using cursor P002P2 */
         pr_default.execute(0, new Object[] {AV8ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A55ProductCode = P002P2_A55ProductCode[0];
            n55ProductCode = P002P2_n55ProductCode[0];
            A15ProductId = P002P2_A15ProductId[0];
            AV12GXLvl1 = 1;
            AV9ProductId = A15ProductId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV12GXLvl1 == 0 )
         {
            AV9ProductId = 0;
         }
         this.cleanup();
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
         scmdbuf = "";
         P002P2_A55ProductCode = new string[] {""} ;
         P002P2_n55ProductCode = new bool[] {false} ;
         P002P2_A15ProductId = new int[1] ;
         A55ProductCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productsearchwithcode__default(),
            new Object[][] {
                new Object[] {
               P002P2_A55ProductCode, P002P2_n55ProductCode, P002P2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12GXLvl1 ;
      private int AV9ProductId ;
      private int A15ProductId ;
      private string scmdbuf ;
      private bool n55ProductCode ;
      private string AV8ProductCode ;
      private string A55ProductCode ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002P2_A55ProductCode ;
      private bool[] P002P2_n55ProductCode ;
      private int[] P002P2_A15ProductId ;
      private int aP1_ProductId ;
   }

   public class productsearchwithcode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002P2;
          prmP002P2 = new Object[] {
          new ParDef("@AV8ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002P2", "SELECT TOP 1 [ProductCode], [ProductId] FROM [Product] WHERE [ProductCode] = @AV8ProductCode ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
