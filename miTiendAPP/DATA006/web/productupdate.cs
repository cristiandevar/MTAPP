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
   public class productupdate : GXProcedure
   {
      public productupdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productupdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_CostPriceProductsSelected ,
                           ref GeneXus.Utils.SdtMessages_Message aP1_ErrorMessage ,
                           ref bool aP2_AllOk )
      {
         this.AV8CostPriceProductsSelected = aP0_CostPriceProductsSelected;
         this.AV9ErrorMessage = aP1_ErrorMessage;
         this.AV10AllOk = aP2_AllOk;
         initialize();
         executePrivate();
         aP1_ErrorMessage=this.AV9ErrorMessage;
         aP2_AllOk=this.AV10AllOk;
      }

      public bool executeUdp( GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_CostPriceProductsSelected ,
                              ref GeneXus.Utils.SdtMessages_Message aP1_ErrorMessage )
      {
         execute(aP0_CostPriceProductsSelected, ref aP1_ErrorMessage, ref aP2_AllOk);
         return AV10AllOk ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_CostPriceProductsSelected ,
                                 ref GeneXus.Utils.SdtMessages_Message aP1_ErrorMessage ,
                                 ref bool aP2_AllOk )
      {
         productupdate objproductupdate;
         objproductupdate = new productupdate();
         objproductupdate.AV8CostPriceProductsSelected = aP0_CostPriceProductsSelected;
         objproductupdate.AV9ErrorMessage = aP1_ErrorMessage;
         objproductupdate.AV10AllOk = aP2_AllOk;
         objproductupdate.context.SetSubmitInitialConfig(context);
         objproductupdate.initialize();
         Submit( executePrivateCatch,objproductupdate);
         aP1_ErrorMessage=this.AV9ErrorMessage;
         aP2_AllOk=this.AV10AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productupdate)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV12Context, ref  AV10AllOk) ;
         if ( ! AV10AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV8CostPriceProductsSelected.Count )
         {
            AV11OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV8CostPriceProductsSelected.Item(AV15GXV1));
            /* Using cursor P00152 */
            pr_default.execute(0, new Object[] {AV11OneProduct.gxTpr_Id});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15ProductId = P00152_A15ProductId[0];
               A85ProductCostPrice = P00152_A85ProductCostPrice[0];
               n85ProductCostPrice = P00152_n85ProductCostPrice[0];
               A93ProductMiniumQuantityWholesale = P00152_A93ProductMiniumQuantityWholesale[0];
               n93ProductMiniumQuantityWholesale = P00152_n93ProductMiniumQuantityWholesale[0];
               A89ProductRetailProfit = P00152_A89ProductRetailProfit[0];
               n89ProductRetailProfit = P00152_n89ProductRetailProfit[0];
               A87ProductWholesaleProfit = P00152_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = P00152_n87ProductWholesaleProfit[0];
               A85ProductCostPrice = AV11OneProduct.gxTpr_Newcostprice;
               n85ProductCostPrice = false;
               if ( ( AV11OneProduct.gxTpr_Newretailprofit != AV11OneProduct.gxTpr_Newwholesaleprofit ) && ( ( A93ProductMiniumQuantityWholesale == 0 ) || (0==A93ProductMiniumQuantityWholesale) || P00152_n93ProductMiniumQuantityWholesale[0] ) )
               {
                  A93ProductMiniumQuantityWholesale = 10;
                  n93ProductMiniumQuantityWholesale = false;
               }
               if ( ( AV11OneProduct.gxTpr_Newretailprofit == AV11OneProduct.gxTpr_Newwholesaleprofit ) && ! ( ( A93ProductMiniumQuantityWholesale == 0 ) || (0==A93ProductMiniumQuantityWholesale) || P00152_n93ProductMiniumQuantityWholesale[0] ) )
               {
                  A93ProductMiniumQuantityWholesale = 0;
                  n93ProductMiniumQuantityWholesale = false;
               }
               A89ProductRetailProfit = AV11OneProduct.gxTpr_Newretailprofit;
               n89ProductRetailProfit = false;
               A87ProductWholesaleProfit = AV11OneProduct.gxTpr_Newwholesaleprofit;
               n87ProductWholesaleProfit = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00153 */
               pr_default.execute(1, new Object[] {n85ProductCostPrice, A85ProductCostPrice, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, A15ProductId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Product");
               if (true) break;
               /* Using cursor P00154 */
               pr_default.execute(2, new Object[] {n85ProductCostPrice, A85ProductCostPrice, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, A15ProductId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Product");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("productupdate",pr_default);
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
         AV12Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV11OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         scmdbuf = "";
         P00152_A15ProductId = new int[1] ;
         P00152_A85ProductCostPrice = new decimal[1] ;
         P00152_n85ProductCostPrice = new bool[] {false} ;
         P00152_A93ProductMiniumQuantityWholesale = new short[1] ;
         P00152_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P00152_A89ProductRetailProfit = new decimal[1] ;
         P00152_n89ProductRetailProfit = new bool[] {false} ;
         P00152_A87ProductWholesaleProfit = new decimal[1] ;
         P00152_n87ProductWholesaleProfit = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productupdate__default(),
            new Object[][] {
                new Object[] {
               P00152_A15ProductId, P00152_A85ProductCostPrice, P00152_n85ProductCostPrice, P00152_A93ProductMiniumQuantityWholesale, P00152_n93ProductMiniumQuantityWholesale, P00152_A89ProductRetailProfit, P00152_n89ProductRetailProfit, P00152_A87ProductWholesaleProfit, P00152_n87ProductWholesaleProfit
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private int AV15GXV1 ;
      private int A15ProductId ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private string scmdbuf ;
      private bool AV10AllOk ;
      private bool n85ProductCostPrice ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private IGxDataStore dsDefault ;
      private GeneXus.Utils.SdtMessages_Message aP1_ErrorMessage ;
      private bool aP2_AllOk ;
      private IDataStoreProvider pr_default ;
      private int[] P00152_A15ProductId ;
      private decimal[] P00152_A85ProductCostPrice ;
      private bool[] P00152_n85ProductCostPrice ;
      private short[] P00152_A93ProductMiniumQuantityWholesale ;
      private bool[] P00152_n93ProductMiniumQuantityWholesale ;
      private decimal[] P00152_A89ProductRetailProfit ;
      private bool[] P00152_n89ProductRetailProfit ;
      private decimal[] P00152_A87ProductWholesaleProfit ;
      private bool[] P00152_n87ProductWholesaleProfit ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV8CostPriceProductsSelected ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV11OneProduct ;
      private GeneXus.Utils.SdtMessages_Message AV9ErrorMessage ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV12Context ;
   }

   public class productupdate__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00152;
          prmP00152 = new Object[] {
          new ParDef("@AV11OneProduct__Id",GXType.Int32,6,0)
          };
          Object[] prmP00153;
          prmP00153 = new Object[] {
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmP00154;
          prmP00154 = new Object[] {
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00152", "SELECT TOP 1 [ProductId], [ProductCostPrice], [ProductMiniumQuantityWholesale], [ProductRetailProfit], [ProductWholesaleProfit] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @AV11OneProduct__Id ORDER BY [ProductId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00152,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00153", "UPDATE [Product] SET [ProductCostPrice]=@ProductCostPrice, [ProductMiniumQuantityWholesale]=@ProductMiniumQuantityWholesale, [ProductRetailProfit]=@ProductRetailProfit, [ProductWholesaleProfit]=@ProductWholesaleProfit  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00153)
             ,new CursorDef("P00154", "UPDATE [Product] SET [ProductCostPrice]=@ProductCostPrice, [ProductMiniumQuantityWholesale]=@ProductMiniumQuantityWholesale, [ProductRetailProfit]=@ProductRetailProfit, [ProductWholesaleProfit]=@ProductWholesaleProfit  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00154)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
