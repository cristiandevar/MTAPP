using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomainemaildata
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainemaildata ()
      {
         domain["smtp.gmail.com"] = "Host Mail";
         domain["587"] = "Port Mail TLS";
         domain["465"] = "Port Mail SSL";
         domain["cristianprogramadorunsa@gmail.com"] = "User Mail";
         domain["vqzz mnxc rqah ooyu"] = "Pass Mail";
         domain["cristianprogramadorunsa@gmail.com"] = "Emitter Mail";
         domain["MTAPP"] = "Emitter Name Mail";
         domain["True"] = "Authentication Mail";
         domain["True"] = "Secure Server";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["HostMail"] = "smtp.gmail.com";
            domainMap["PortMailTLS"] = "587";
            domainMap["PortMailSSL"] = "465";
            domainMap["UserMail"] = "cristianprogramadorunsa@gmail.com";
            domainMap["PassMail"] = "vqzz mnxc rqah ooyu";
            domainMap["EmitterMail"] = "cristianprogramadorunsa@gmail.com";
            domainMap["EmitterNameMail"] = "MTAPP";
            domainMap["AuthenticationMail"] = "True";
            domainMap["SecureServer"] = "True";
         }
         return (string)domainMap[key] ;
      }

   }

}
