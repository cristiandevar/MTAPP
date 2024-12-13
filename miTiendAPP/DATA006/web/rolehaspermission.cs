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
   public class rolehaspermission : GXProcedure
   {
      public rolehaspermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public rolehaspermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_RoleId ,
                           string aP1_PermissionName ,
                           out bool aP2_Has )
      {
         this.AV12RoleId = aP0_RoleId;
         this.AV8PermissionName = aP1_PermissionName;
         this.AV9Has = false ;
         initialize();
         executePrivate();
         aP2_Has=this.AV9Has;
      }

      public bool executeUdp( int aP0_RoleId ,
                              string aP1_PermissionName )
      {
         execute(aP0_RoleId, aP1_PermissionName, out aP2_Has);
         return AV9Has ;
      }

      public void executeSubmit( int aP0_RoleId ,
                                 string aP1_PermissionName ,
                                 out bool aP2_Has )
      {
         rolehaspermission objrolehaspermission;
         objrolehaspermission = new rolehaspermission();
         objrolehaspermission.AV12RoleId = aP0_RoleId;
         objrolehaspermission.AV8PermissionName = aP1_PermissionName;
         objrolehaspermission.AV9Has = false ;
         objrolehaspermission.context.SetSubmitInitialConfig(context);
         objrolehaspermission.initialize();
         Submit( executePrivateCatch,objrolehaspermission);
         aP2_Has=this.AV9Has;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rolehaspermission)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV12RoleId ,
                                              A104RoleId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P001Z2 */
         pr_default.execute(0, new Object[] {AV12RoleId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A104RoleId = P001Z2_A104RoleId[0];
            /* Using cursor P001Z3 */
            pr_default.execute(1, new Object[] {A104RoleId, AV8PermissionName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106PermissionId = P001Z3_A106PermissionId[0];
               A107PermissionName = P001Z3_A107PermissionName[0];
               A107PermissionName = P001Z3_A107PermissionName[0];
               AV9Has = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV10Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001Z2_A104RoleId = new int[1] ;
         P001Z3_A106PermissionId = new int[1] ;
         P001Z3_A104RoleId = new int[1] ;
         P001Z3_A107PermissionName = new string[] {""} ;
         A107PermissionName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rolehaspermission__default(),
            new Object[][] {
                new Object[] {
               P001Z2_A104RoleId
               }
               , new Object[] {
               P001Z3_A106PermissionId, P001Z3_A104RoleId, P001Z3_A107PermissionName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12RoleId ;
      private int A104RoleId ;
      private int A106PermissionId ;
      private string scmdbuf ;
      private bool AV9Has ;
      private bool AV11AllOk ;
      private string AV8PermissionName ;
      private string A107PermissionName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001Z2_A104RoleId ;
      private int[] P001Z3_A106PermissionId ;
      private int[] P001Z3_A104RoleId ;
      private string[] P001Z3_A107PermissionName ;
      private bool aP2_Has ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV10Context ;
   }

   public class rolehaspermission__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001Z2( IGxContext context ,
                                             int AV12RoleId ,
                                             int A104RoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [RoleId] FROM [Role]";
         if ( ! (0==AV12RoleId) )
         {
            AddWhere(sWhereString, "([RoleId] = @AV12RoleId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RoleId]";
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
                     return conditional_P001Z2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP001Z3;
          prmP001Z3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0) ,
          new ParDef("@AV8PermissionName",GXType.NVarChar,60,0)
          };
          Object[] prmP001Z2;
          prmP001Z2 = new Object[] {
          new ParDef("@AV12RoleId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001Z3", "SELECT TOP 1 T1.[PermissionId], T1.[RoleId], T2.[PermissionName] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) WHERE (T1.[RoleId] = @RoleId) AND (T2.[PermissionName] = LOWER(@AV8PermissionName)) ORDER BY T1.[RoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z3,1, GxCacheFrequency.OFF ,false,true )
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
