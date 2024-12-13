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
namespace GeneXus.Programs.general.security {
   public class hasrole : GXProcedure
   {
      public hasrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public hasrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_RoleName ,
                           out bool aP1_Has )
      {
         this.AV14RoleName = aP0_RoleName;
         this.AV15Has = false ;
         initialize();
         executePrivate();
         aP1_Has=this.AV15Has;
      }

      public bool executeUdp( string aP0_RoleName )
      {
         execute(aP0_RoleName, out aP1_Has);
         return AV15Has ;
      }

      public void executeSubmit( string aP0_RoleName ,
                                 out bool aP1_Has )
      {
         hasrole objhasrole;
         objhasrole = new hasrole();
         objhasrole.AV14RoleName = aP0_RoleName;
         objhasrole.AV15Has = false ;
         objhasrole.context.SetSubmitInitialConfig(context);
         objhasrole.initialize();
         Submit( executePrivateCatch,objhasrole);
         aP1_Has=this.AV15Has;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((hasrole)stateInfo).executePrivate();
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
         AV15Has = false;
         AV13Context.FromXml(AV12WebSession.Get("Context"), null, "", "");
         AV8UserId = AV13Context.gxTpr_Userid;
         /* Using cursor P001K2 */
         pr_default.execute(0, new Object[] {AV8UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A104RoleId = P001K2_A104RoleId[0];
            A99UserId = P001K2_A99UserId[0];
            /* Using cursor P001K3 */
            pr_default.execute(1, new Object[] {A104RoleId, AV14RoleName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A105RoleName = P001K3_A105RoleName[0];
               AV15Has = true;
               /* Exiting from a For First loop. */
               if (true) break;
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
         AV13Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV12WebSession = context.GetSession();
         scmdbuf = "";
         P001K2_A104RoleId = new int[1] ;
         P001K2_A99UserId = new int[1] ;
         P001K3_A104RoleId = new int[1] ;
         P001K3_A105RoleName = new string[] {""} ;
         A105RoleName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.security.hasrole__default(),
            new Object[][] {
                new Object[] {
               P001K2_A104RoleId, P001K2_A99UserId
               }
               , new Object[] {
               P001K3_A104RoleId, P001K3_A105RoleName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UserId ;
      private int A104RoleId ;
      private int A99UserId ;
      private string scmdbuf ;
      private bool AV15Has ;
      private string AV14RoleName ;
      private string A105RoleName ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001K2_A104RoleId ;
      private int[] P001K2_A99UserId ;
      private int[] P001K3_A104RoleId ;
      private string[] P001K3_A105RoleName ;
      private bool aP1_Has ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV13Context ;
   }

   public class hasrole__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001K2;
          prmP001K2 = new Object[] {
          new ParDef("@AV8UserId",GXType.Int32,6,0)
          };
          Object[] prmP001K3;
          prmP001K3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0) ,
          new ParDef("@AV14RoleName",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001K2", "SELECT [RoleId], [UserId] FROM [User] WHERE [UserId] = @AV8UserId ORDER BY [UserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001K3", "SELECT [RoleId], [RoleName] FROM [Role] WHERE ([RoleId] = @RoleId) AND ([RoleName] = @AV14RoleName) ORDER BY [RoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K3,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
