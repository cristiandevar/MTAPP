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
   public class haspermission : GXProcedure
   {
      public haspermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public haspermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PermissionName ,
                           out bool aP1_Has )
      {
         this.AV8PermissionName = aP0_PermissionName;
         this.AV9Has = false ;
         initialize();
         executePrivate();
         aP1_Has=this.AV9Has;
      }

      public bool executeUdp( string aP0_PermissionName )
      {
         execute(aP0_PermissionName, out aP1_Has);
         return AV9Has ;
      }

      public void executeSubmit( string aP0_PermissionName ,
                                 out bool aP1_Has )
      {
         haspermission objhaspermission;
         objhaspermission = new haspermission();
         objhaspermission.AV8PermissionName = aP0_PermissionName;
         objhaspermission.AV9Has = false ;
         objhaspermission.context.SetSubmitInitialConfig(context);
         objhaspermission.initialize();
         Submit( executePrivateCatch,objhaspermission);
         aP1_Has=this.AV9Has;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((haspermission)stateInfo).executePrivate();
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
         AV9Has = false;
         new getcontext(context ).execute( out  AV10Context, ref  AV11AllOk) ;
         if ( ! AV11AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         /* Using cursor P001M2 */
         pr_default.execute(0, new Object[] {AV10Context.gxTpr_Userid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A104RoleId = P001M2_A104RoleId[0];
            n104RoleId = P001M2_n104RoleId[0];
            A111UserActive = P001M2_A111UserActive[0];
            n111UserActive = P001M2_n111UserActive[0];
            A99UserId = P001M2_A99UserId[0];
            /* Using cursor P001M3 */
            pr_default.execute(1, new Object[] {n104RoleId, A104RoleId, AV8PermissionName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106PermissionId = P001M3_A106PermissionId[0];
               A107PermissionName = P001M3_A107PermissionName[0];
               A107PermissionName = P001M3_A107PermissionName[0];
               AV9Has = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV10Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001M2_A104RoleId = new int[1] ;
         P001M2_n104RoleId = new bool[] {false} ;
         P001M2_A111UserActive = new bool[] {false} ;
         P001M2_n111UserActive = new bool[] {false} ;
         P001M2_A99UserId = new int[1] ;
         P001M3_A106PermissionId = new int[1] ;
         P001M3_A104RoleId = new int[1] ;
         P001M3_n104RoleId = new bool[] {false} ;
         P001M3_A107PermissionName = new string[] {""} ;
         A107PermissionName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.haspermission__default(),
            new Object[][] {
                new Object[] {
               P001M2_A104RoleId, P001M2_n104RoleId, P001M2_A111UserActive, P001M2_n111UserActive, P001M2_A99UserId
               }
               , new Object[] {
               P001M3_A106PermissionId, P001M3_A104RoleId, P001M3_A107PermissionName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A104RoleId ;
      private int A99UserId ;
      private int A106PermissionId ;
      private string scmdbuf ;
      private bool AV9Has ;
      private bool AV11AllOk ;
      private bool n104RoleId ;
      private bool A111UserActive ;
      private bool n111UserActive ;
      private string AV8PermissionName ;
      private string A107PermissionName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001M2_A104RoleId ;
      private bool[] P001M2_n104RoleId ;
      private bool[] P001M2_A111UserActive ;
      private bool[] P001M2_n111UserActive ;
      private int[] P001M2_A99UserId ;
      private int[] P001M3_A106PermissionId ;
      private int[] P001M3_A104RoleId ;
      private bool[] P001M3_n104RoleId ;
      private string[] P001M3_A107PermissionName ;
      private bool aP1_Has ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV10Context ;
   }

   public class haspermission__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001M2;
          prmP001M2 = new Object[] {
          new ParDef("@AV10Context__Userid",GXType.Int32,6,0)
          };
          Object[] prmP001M3;
          prmP001M3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@AV8PermissionName",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001M2", "SELECT [RoleId], [UserActive], [UserId] FROM [User] WHERE ([UserId] = @AV10Context__Userid) AND ([UserActive] = 1) ORDER BY [UserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001M3", "SELECT TOP 1 T1.[PermissionId], T1.[RoleId], T2.[PermissionName] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) WHERE (T1.[RoleId] = @RoleId) AND (T2.[PermissionName] = LOWER(@AV8PermissionName)) ORDER BY T1.[RoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
