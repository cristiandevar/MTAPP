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
   public class userchangepassword : GXProcedure
   {
      public userchangepassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public userchangepassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UserId ,
                           ref string aP1_UserPassword ,
                           ref string aP2_NewUserPassword ,
                           out bool aP3_AllOk )
      {
         this.A99UserId = aP0_UserId;
         this.AV9UserPassword = aP1_UserPassword;
         this.AV8NewUserPassword = aP2_NewUserPassword;
         this.AV10AllOk = false ;
         initialize();
         executePrivate();
         aP1_UserPassword=this.AV9UserPassword;
         aP2_NewUserPassword=this.AV8NewUserPassword;
         aP3_AllOk=this.AV10AllOk;
      }

      public bool executeUdp( int aP0_UserId ,
                              ref string aP1_UserPassword ,
                              ref string aP2_NewUserPassword )
      {
         execute(aP0_UserId, ref aP1_UserPassword, ref aP2_NewUserPassword, out aP3_AllOk);
         return AV10AllOk ;
      }

      public void executeSubmit( int aP0_UserId ,
                                 ref string aP1_UserPassword ,
                                 ref string aP2_NewUserPassword ,
                                 out bool aP3_AllOk )
      {
         userchangepassword objuserchangepassword;
         objuserchangepassword = new userchangepassword();
         objuserchangepassword.A99UserId = aP0_UserId;
         objuserchangepassword.AV9UserPassword = aP1_UserPassword;
         objuserchangepassword.AV8NewUserPassword = aP2_NewUserPassword;
         objuserchangepassword.AV10AllOk = false ;
         objuserchangepassword.context.SetSubmitInitialConfig(context);
         objuserchangepassword.initialize();
         Submit( executePrivateCatch,objuserchangepassword);
         aP1_UserPassword=this.AV9UserPassword;
         aP2_NewUserPassword=this.AV8NewUserPassword;
         aP3_AllOk=this.AV10AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((userchangepassword)stateInfo).executePrivate();
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
         /* Using cursor P001L2 */
         pr_default.execute(0, new Object[] {A99UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A109UserHash = P001L2_A109UserHash[0];
            AV9UserPassword = Encrypt64( AV9UserPassword, A109UserHash);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV13UserHash = Crypto.GetEncryptionKey( );
         AV17GXLvl8 = 0;
         /* Using cursor P001L3 */
         pr_default.execute(1, new Object[] {A99UserId, AV9UserPassword});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A101UserPassword = P001L3_A101UserPassword[0];
            A109UserHash = P001L3_A109UserHash[0];
            AV17GXLvl8 = 1;
            AV8NewUserPassword = Encrypt64( AV8NewUserPassword, AV13UserHash);
            A101UserPassword = AV8NewUserPassword;
            A109UserHash = AV13UserHash;
            AV10AllOk = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P001L4 */
            pr_default.execute(2, new Object[] {A101UserPassword, A109UserHash, A99UserId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("User");
            if (true) break;
            /* Using cursor P001L5 */
            pr_default.execute(3, new Object[] {A101UserPassword, A109UserHash, A99UserId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("User");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV17GXLvl8 == 0 )
         {
            AV10AllOk = false;
            GX_msglist.addItem("Password is invalid");
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("userchangepassword",pr_default);
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
         P001L2_A99UserId = new int[1] ;
         P001L2_A109UserHash = new string[] {""} ;
         A109UserHash = "";
         AV13UserHash = "";
         P001L3_A99UserId = new int[1] ;
         P001L3_A101UserPassword = new string[] {""} ;
         P001L3_A109UserHash = new string[] {""} ;
         A101UserPassword = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.userchangepassword__default(),
            new Object[][] {
                new Object[] {
               P001L2_A99UserId, P001L2_A109UserHash
               }
               , new Object[] {
               P001L3_A99UserId, P001L3_A101UserPassword, P001L3_A109UserHash
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

      private short AV17GXLvl8 ;
      private int A99UserId ;
      private string scmdbuf ;
      private bool AV10AllOk ;
      private string AV9UserPassword ;
      private string AV8NewUserPassword ;
      private string A109UserHash ;
      private string AV13UserHash ;
      private string A101UserPassword ;
      private IGxDataStore dsDefault ;
      private string aP1_UserPassword ;
      private string aP2_NewUserPassword ;
      private IDataStoreProvider pr_default ;
      private int[] P001L2_A99UserId ;
      private string[] P001L2_A109UserHash ;
      private int[] P001L3_A99UserId ;
      private string[] P001L3_A101UserPassword ;
      private string[] P001L3_A109UserHash ;
      private bool aP3_AllOk ;
   }

   public class userchangepassword__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001L2;
          prmP001L2 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmP001L3;
          prmP001L3 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0) ,
          new ParDef("@AV9UserPassword",GXType.NVarChar,40,0)
          };
          Object[] prmP001L4;
          prmP001L4 = new Object[] {
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmP001L5;
          prmP001L5 = new Object[] {
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001L2", "SELECT [UserId], [UserHash] FROM [User] WHERE [UserId] = @UserId ORDER BY [UserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001L3", "SELECT TOP 1 [UserId], [UserPassword], [UserHash] FROM [User] WITH (UPDLOCK) WHERE ([UserId] = @UserId) AND ([UserPassword] = @AV9UserPassword) ORDER BY [UserId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001L4", "UPDATE [User] SET [UserPassword]=@UserPassword, [UserHash]=@UserHash  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001L4)
             ,new CursorDef("P001L5", "UPDATE [User] SET [UserPassword]=@UserPassword, [UserHash]=@UserHash  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001L5)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
