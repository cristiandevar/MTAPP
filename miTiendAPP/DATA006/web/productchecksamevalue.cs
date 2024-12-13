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
   public class productchecksamevalue : GXProcedure
   {
      public productchecksamevalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productchecksamevalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductCode ,
                           ref string aP1_ProductName ,
                           ref int aP2_SupplierId ,
                           out bool aP3_Check )
      {
         this.AV18ProductCode = aP0_ProductCode;
         this.AV8ProductName = aP1_ProductName;
         this.AV19SupplierId = aP2_SupplierId;
         this.AV10Check = false ;
         initialize();
         executePrivate();
         aP1_ProductName=this.AV8ProductName;
         aP2_SupplierId=this.AV19SupplierId;
         aP3_Check=this.AV10Check;
      }

      public bool executeUdp( string aP0_ProductCode ,
                              ref string aP1_ProductName ,
                              ref int aP2_SupplierId )
      {
         execute(aP0_ProductCode, ref aP1_ProductName, ref aP2_SupplierId, out aP3_Check);
         return AV10Check ;
      }

      public void executeSubmit( string aP0_ProductCode ,
                                 ref string aP1_ProductName ,
                                 ref int aP2_SupplierId ,
                                 out bool aP3_Check )
      {
         productchecksamevalue objproductchecksamevalue;
         objproductchecksamevalue = new productchecksamevalue();
         objproductchecksamevalue.AV18ProductCode = aP0_ProductCode;
         objproductchecksamevalue.AV8ProductName = aP1_ProductName;
         objproductchecksamevalue.AV19SupplierId = aP2_SupplierId;
         objproductchecksamevalue.AV10Check = false ;
         objproductchecksamevalue.context.SetSubmitInitialConfig(context);
         objproductchecksamevalue.initialize();
         Submit( executePrivateCatch,objproductchecksamevalue);
         aP1_ProductName=this.AV8ProductName;
         aP2_SupplierId=this.AV19SupplierId;
         aP3_Check=this.AV10Check;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productchecksamevalue)stateInfo).executePrivate();
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
         AV10Check = false;
         /* Using cursor P002M2 */
         pr_default.execute(0, new Object[] {AV8ProductName, AV18ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A16ProductName = P002M2_A16ProductName[0];
            A55ProductCode = P002M2_A55ProductCode[0];
            n55ProductCode = P002M2_n55ProductCode[0];
            A4SupplierId = P002M2_A4SupplierId[0];
            A15ProductId = P002M2_A15ProductId[0];
            if ( AV19SupplierId != A4SupplierId )
            {
               AV10Check = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P002M2_A16ProductName = new string[] {""} ;
         P002M2_A55ProductCode = new string[] {""} ;
         P002M2_n55ProductCode = new bool[] {false} ;
         P002M2_A4SupplierId = new int[1] ;
         P002M2_A15ProductId = new int[1] ;
         A16ProductName = "";
         A55ProductCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productchecksamevalue__default(),
            new Object[][] {
                new Object[] {
               P002M2_A16ProductName, P002M2_A55ProductCode, P002M2_n55ProductCode, P002M2_A4SupplierId, P002M2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV19SupplierId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private string scmdbuf ;
      private bool AV10Check ;
      private bool n55ProductCode ;
      private string AV18ProductCode ;
      private string AV8ProductName ;
      private string A16ProductName ;
      private string A55ProductCode ;
      private IGxDataStore dsDefault ;
      private string aP1_ProductName ;
      private int aP2_SupplierId ;
      private IDataStoreProvider pr_default ;
      private string[] P002M2_A16ProductName ;
      private string[] P002M2_A55ProductCode ;
      private bool[] P002M2_n55ProductCode ;
      private int[] P002M2_A4SupplierId ;
      private int[] P002M2_A15ProductId ;
      private bool aP3_Check ;
   }

   public class productchecksamevalue__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002M2;
          prmP002M2 = new Object[] {
          new ParDef("@AV8ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@AV18ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002M2", "SELECT [ProductName], [ProductCode], [SupplierId], [ProductId] FROM [Product] WHERE ([ProductName] = @AV8ProductName) AND ([ProductCode] = @AV18ProductCode) ORDER BY [ProductName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
